'**********************************************************************************************
'* Ethernet/IP for ControlLogix
'*
'* Archie Jacobs
'* Manufacturing Automation, LLC
'* ajacobs@mfgcontrol.com
'* 14-DEC-10
'*
'*
'* Copyright 2010 Archie Jacobs
'*
'* This class implements the Ethernet/IP protocol.
'*
'* Distributed under the GNU General Public License (www.gnu.org)
'*
'* This program is free software; you can redistribute it and/or
'* as published by the Free Software Foundation; either version 2
'* of the License, or (at your option) any later version.
'*
'* This program is distributed in the hope that it will be useful,
'* but WITHOUT ANY WARRANTY; without even the implied warranty of
'* MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
'* GNU General Public License for more details.

'* You should have received a copy of the GNU General Public License
'* along with this program; if not, write to the Free Software
'* Foundation, Inc., 51 Franklin Street, Fifth Floor, Boston, MA  02110-1301, USA.
'*
'*******************************************************************************************************
Imports System.ComponentModel.Design
Imports System.Text.RegularExpressions
Imports System.ComponentModel
Imports System
Imports System.Drawing
Imports System.Drawing.Design
Imports System.Reflection
Imports System.Windows.Forms
Imports System.Windows.Forms.Design


Public Class EthernetIPforCLXComm

    '* Create a common instance to share so multiple driver instances can be used in a project
    Private Shared DLL(10) As MfgControl.AdvancedHMI.Drivers.CIP
    Private MyDLLInstance As Integer





    Private QueuedCommand As New System.Collections.ObjectModel.Collection(Of Byte)
    '    Private CommandInQueue As Boolean

    Private DisableEvent As Boolean
    Private rnd As New Random
    '* create a random number as a TNS starting point
    'Private TNS As UInt16 = (rnd.Next And &H7F) + 1
    'Public DataPackets(255) As System.Collections.ObjectModel.Collection(Of Byte)

    Public Delegate Sub PLCCommEventHandler(ByVal sender As Object, ByVal e As MfgControl.AdvancedHMI.Drivers.PLCCommEventArgs)
    Public Event DataReceived As PLCCommEventHandler

    Public Event UnsolictedMessageRcvd As EventHandler

    Private Responded(255) As Boolean
    Private MsgFalla As String

    '*********************************************************************************
    '* This is used for linking a notification.
    '* An object can request a continuous poll and get a callback when value updated
    '*********************************************************************************
    Delegate Sub ReturnValues(ByVal Values As String)
    Private Structure PolledAddressInfo
        Dim PLCAddress As String
        Dim FileType As Long
        Dim FileNumber As Long
        Dim ElementNumber As Integer
        Dim SubElement As Integer
        Dim BitNumber As Integer
        Dim BytesPerElement As Integer
        Dim dlgCallBack As ICommComponent.ReturnValues
        Dim PollRate As Integer
        Dim ID As Integer
        Dim LastValue As Object
        Dim ElementsToRead As Integer
    End Structure

    Private CurrentID As Integer = 1
    '* keep the original address by ref of low TNS byte so it can be returned to a linked polling address
    Private Shared PLCAddressByTNS(255) As ParsedDataAddress
    '    Private CurrentAddressToRead As String
    Private PolledAddressList As New List(Of PolledAddressInfo)
    Private tmrPollList As New List(Of Windows.Forms.Timer)

    Public Sub New(ByVal container As System.ComponentModel.IContainer)
        MyClass.New()

        'Required for Windows.Forms Class Composition Designer support
        container.Add(Me)
    End Sub

    Public Sub New()
        MyBase.New()

        'CreateDLLInstance()

    End Sub


    '***************************************************************
    '* Create the Data Link Layer Instances
    '* if the IP Address is the same, then resuse a common instance
    '***************************************************************
    Private Sub CreateDLLInstance()
        If DLL(0) IsNot Nothing Then
            '* At least one DLL instance already exists,
            '* so check to see if it has the same IP address
            '* if so, reuse the instance, otherwise create a new one
            Dim i As Integer
            While DLL(i) IsNot Nothing AndAlso DLL(i).EIPEncap.IPAddress <> m_IPAddress AndAlso i < 11
                i += 1
            End While
            MyDLLInstance = i
        End If

        If DLL(MyDLLInstance) Is Nothing Then
            DLL(MyDLLInstance) = New MfgControl.AdvancedHMI.Drivers.CIP
            DLL(MyDLLInstance).EIPEncap.IPAddress = m_IPAddress
            DLL(MyDLLInstance).ProcessorSlot = m_ProcessorSlot
        End If
        AddHandler DLL(MyDLLInstance).DataReceived, Dr
        AddHandler DLL(MyDLLInstance).CommError, AddressOf _CommError
    End Sub

    'Component overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Sub Dispose(ByVal disposing As Boolean)
        '* The handle linked to the DataLink Layer has to be removed, otherwise it causes a problem when a form is closed
        If DLL(MyDLLInstance) IsNot Nothing Then RemoveHandler DLL(MyDLLInstance).DataReceived, Dr

        'If disposing AndAlso components IsNot Nothing Then
        '    components.Dispose()
        'End If
        'MyBase.Dispose(disposing)
    End Sub



#Region "Properties"
    'Private m_MyNode As Integer
    'Public Property MyNode() As Integer
    '    Get
    '        Return m_MyNode
    '    End Get
    '    Set(ByVal value As Integer)
    '        m_MyNode = value
    '    End Set
    'End Property

    Private m_ProcessorSlot As Integer
    Public Property ProcessorSlot() As Integer
        Get
            Return m_ProcessorSlot
        End Get
        Set(ByVal value As Integer)
            m_ProcessorSlot = value
            If DLL(MyDLLInstance) IsNot Nothing Then
                DLL(MyDLLInstance).ProcessorSlot = value
            End If
        End Set
    End Property

    Private m_IPAddress As String = "192.168.0.10"
    Public Property IPAddress() As String
        Get
            'Return DLL(MyDLLInstance).EIPEncap.IPAddress
            Return m_IPAddress
        End Get
        Set(ByVal value As String)
            m_IPAddress = value

            '* If a new instance needs to be created, such as a different IP Address
            CreateDLLInstance()


            If DLL(MyDLLInstance) Is Nothing Then
            Else
                DLL(MyDLLInstance).EIPEncap.IPAddress = value
            End If
        End Set
    End Property

    '**************************************************************
    '* Determine whether to wait for a data read or raise an event
    '**************************************************************
    Private m_AsyncMode As Boolean
    Public Property AsyncMode() As Boolean
        Get
            Return m_AsyncMode
        End Get
        Set(ByVal value As Boolean)
            m_AsyncMode = value
        End Set
    End Property

    '**************************************************************
    '* Stop the polling of subscribed data
    '**************************************************************
    Private m_DisableSubscriptions
    Public Property DisableSubscriptions() As Boolean 'Implements ICommComponent.DisableSubscriptions
        Get
            Return m_DisableSubscriptions
        End Get
        Set(ByVal value As Boolean)
            m_DisableSubscriptions = value

            If value Then
                '* Stop the poll timers
                For i As Int16 = 0 To tmrPollList.Count - 1
                    tmrPollList(i).Enabled = False
                Next
            Else
                '* Start the poll timers
                For i As Int16 = 0 To tmrPollList.Count - 1
                    tmrPollList(i).Enabled = True
                Next
            End If
        End Set
    End Property

    '**************************************************
    '* Its purpose is to fetch
    '* the main form in order to synchronize the
    '* notification thread/event
    '**************************************************
    Private m_SynchronizingObject As Windows.Forms.Form
    '* do not let this property show up in the property window
    ' <System.ComponentModel.Browsable(False)> _
    '  Public Property SynchronizingObject() As Windows.Forms.Form
    '   Get
    'If Me.Site.DesignMode Then

    'Dim host1 As IDesignerHost
    'Dim obj1 As Object
    'If (m_SynchronizingObject Is Nothing) AndAlso MyBase.DesignMode Then
    '    host1 = CType(Me.GetService(GetType(IDesignerHost)), IDesignerHost)
    '    If host1 IsNot Nothing Then
    '        obj1 = host1.RootComponent
    '        m_SynchronizingObject = CType(obj1, System.ComponentModel.ISynchronizeInvoke)
    '    End If
    'End If
    ''End If
    'Return m_SynchronizingObject



    'Dim dh As IDesignerHost = DirectCast(Me.GetService(GetType(IDesignerHost)), IDesignerHost)
    'If dh IsNot Nothing Then
    '    Dim obj As Object = dh.RootComponent
    '    If obj IsNot Nothing Then
    '        m_ParentForm = DirectCast(obj, Form)
    '    End If
    'End If

    'Dim instance As IDesignerHost = Me.GetService(GetType(IDesignerHost))
    'm_SynchronizingObject = instance.RootComponent
    ''End If
    'Return m_SynchronizingObject
    'End Get

    'Set(ByVal Value As Windows.Forms.Form)
    '    If Not Value Is Nothing Then
    '        m_SynchronizingObject = Value
    '    End If
    'End Set
    ' End Property
#End Region


#Region "Public Methods"
    Public Function ReadAny(ByVal startAddress As String, ByVal numberOfElements As Integer) As String()
        Try
            MsgFalla = ""
            '* We must get the sequence number from the DLL
            '* and save the read information because it can comeback before this
            '* information gets put in the PLCAddressByTNS array
            Dim SequenceNumber As UInt16 = DLL(MyDLLInstance).EIPEncap.GetSequenceNumber

            Responded(SequenceNumber And 255) = False
            PLCAddressByTNS(SequenceNumber And 255).SequenceNumber = SequenceNumber
            PLCAddressByTNS(SequenceNumber And 255).InternallyRequested = InternalRequest
            PLCAddressByTNS(SequenceNumber And 255).PLCAddress = startAddress
            PLCAddressByTNS(SequenceNumber And 255).AsyncMode = m_AsyncMode

            'SequenceNumber = DLL(MyDLLInstance).ReadTagValue(startAddress, numberOfElements) And 255
            DLL(MyDLLInstance).ReadTagValue(startAddress, numberOfElements, SequenceNumber)

            If AsyncMode Then
                Dim x() As String = {SequenceNumber}
                Return x
            Else
                Dim result As Integer
                result = WaitForResponse(SequenceNumber And 255)
                If result = 0 Then
                    '* Check the status byte
                    Dim StatusByte As Int16 = DLL(MyDLLInstance).DataPacket(SequenceNumber And 255)(2)
                    '* A status of 6 just means it was a partial transfer so it can be ignored
                    If StatusByte = 0 Or StatusByte = 6 Then
                        Dim dataOffset As Integer = 6
                        '* Pass the abreviated data type (page 11 of 1756-RM005A)
                        Dim AbreviatedDataType As UInt16 = DLL(MyDLLInstance).DataPacket(SequenceNumber And 255)(4) + DLL(MyDLLInstance).DataPacket(SequenceNumber And 255)(5) * 256
                        '* Is it a structure?
                        If AbreviatedDataType = &H2A0 Then
                            AbreviatedDataType = DLL(MyDLLInstance).DataPacket(SequenceNumber And 255)(6)
                            dataOffset = 8
                        End If

                        Dim ReturnedData(DLL(MyDLLInstance).DataPacket(SequenceNumber And 255).Count - dataOffset - 1) As Byte
                        For i As Integer = 0 To ReturnedData.Length - 1
                            ReturnedData(i) = DLL(MyDLLInstance).DataPacket(SequenceNumber And 255)(i + dataOffset)
                        Next

                        Dim d() As String = ExtractData(startAddress, AbreviatedDataType, ReturnedData)

                        Return d
                    Else
                        Throw New MfgControl.AdvancedHMI.Drivers.PLCDriverException("Read Failed," & DecodeMessage(StatusByte))
                    End If
                Else
                    Throw New MfgControl.AdvancedHMI.Drivers.PLCDriverException("Read Failed - Status Code=" & result)
                End If
            End If

        Catch ex As Exception
            'MsgBox(ex.ToString)
            MsgFalla = ex.Message
            Dim Result() As String = {"Fail", 0}
            Return Result
        End Try

    End Function

    Public ReadOnly Property Conected As Boolean
        Get
            Conected = DLL(MyDLLInstance).CIPConnected
        End Get
    End Property

    Public ReadOnly Property FallasPLC As String
        Get
            FallasPLC = MsgFalla
        End Get
    End Property

    'Public Function Subscribe(ByVal PLCAddress As String, ByVal PollRate As Integer, ByVal CallBack As ICommComponent.ReturnValues) As Integer
    '    '*******************************************************************
    '    '*******************************************************************
    '    'Dim ParsedResult As ParsedDataAddress = ParseAddress(PLCAddress)

    '    '* Valid address?
    '    'If ParsedResult.FileType <> 0 Then
    '    Dim tmpPA As New PolledAddressInfo
    '    tmpPA.PLCAddress = PLCAddress
    '    'tmpPA.PollRate = CycleTime
    '    tmpPA.PollRate = PollRate
    '    tmpPA.dlgCallBack = CallBack
    '    tmpPA.ID = CurrentID
    '    'tmpPA.BytesPerElement = ParsedResult.BytesPerElements
    '    tmpPA.ElementsToRead = 1


    '    PolledAddressList.Add(tmpPA)

    '    PolledAddressList.Sort(AddressOf SortPolledAddresses)

    '    '* The ID is used as a reference for removing polled addresses
    '    CurrentID += 1


    '    '********************************************************************
    '    '* Check to see if there already exists a timer for this poll rate
    '    '********************************************************************
    '    If tmrPollList.Count < 1 Then
    '        Dim j As Integer = 0
    '        'While j < tmrPollList.Count AndAlso tmrPollList(j) IsNot Nothing AndAlso tmrPollList(j).Interval <> CycleTime
    '        '    j += 1
    '        'End While

    '        'If j >= tmrPollList.Count Then
    '        '* Add new timer
    '        Dim tmrTemp As New Windows.Forms.Timer
    '        'If CycleTime > 0 Then
    '        '    tmrTemp.Interval = CycleTime
    '        'Else
    '        '    tmrTemp.Interval = 10
    '        'End If
    '        tmrTemp.Interval = PollRate

    '        tmrPollList.Add(tmrTemp)
    '        AddHandler tmrPollList(j).Tick, AddressOf PollUpdate

    '        tmrTemp.Enabled = True
    '        'End If
    '    End If

    '    Return tmpPA.ID
    '    'End If
    '    'Return -1
    'End Function

    '***************************************************************
    '* Used to sort polled addresses by File Number and element
    '* This helps in optimizing reading
    '**************************************************************
    Private Function SortPolledAddresses(ByVal A1 As PolledAddressInfo, ByVal A2 As PolledAddressInfo) As Integer
        If A1.FileNumber = A2.FileNumber Then
            If A1.ElementNumber > A2.ElementNumber Then
                Return 1
            ElseIf A1.ElementNumber = A2.ElementNumber Then
                Return 0
            Else
                Return -1
            End If
        End If

        If A1.FileNumber > A2.FileNumber Then
            Return 1
        Else
            Return -1
        End If
    End Function

    Public Function UnSubscribe(ByVal ID As Integer) As Integer
        Dim i As Integer = 0
        While i < PolledAddressList.Count AndAlso PolledAddressList(i).ID <> ID
            i += 1
        End While

        If i < PolledAddressList.Count Then
            PolledAddressList.RemoveAt(i)
            '* If no more items to be polled, remove all polling timers 28-NOV-10
            If PolledAddressList.Count = 0 Then
                For j As Integer = 0 To tmrPollList.Count - 1
                    tmrPollList(0).Enabled = False
                    tmrPollList.Remove(tmrPollList(0))
                Next
            End If
        End If
        Return 0
    End Function

    '**************************************************************
    '* Perform the reads for the variables added for notification
    '* Attempt to optimize by grouping reads
    '**************************************************************
    Private InternalRequest As Boolean '* This is used to dinstinquish when to send data back to notification request
    Private SavedPollRate(100) As Integer
    Private Sub PollUpdate(ByVal sender As Windows.Forms.Timer, ByVal e As System.EventArgs)
        If m_DisableSubscriptions Then Exit Sub

        Dim intTimerIndex As Integer = tmrPollList.IndexOf(sender)

        If tmrPollList(0).Enabled = False Or intTimerIndex > 0 Then
            Dim dbg = 0
        End If

        '* Stop the poll timer
        tmrPollList(intTimerIndex).Enabled = False

        Dim i, NumberToRead, FirstElement As Integer
        While i < PolledAddressList.Count
            'Dim NumberToReadCalc As Integer
            NumberToRead = PolledAddressList(i).ElementsToRead
            FirstElement = i
            '            Dim PLCAddress As String = PolledAddressList(FirstElement).PLCAddress



            '* This eliminates the error of late binding when porting to Win CE
            'Dim tmr As Windows.Forms.Timer = sender

            If PolledAddressList(i).PollRate = sender.Interval Or SavedPollRate(i) > 0 Then
                '* Make sure it does not wait for return value befoe coming back
                Dim tmp As Boolean = Me.AsyncMode
                Me.AsyncMode = True
                Try
                    InternalRequest = True
                    Dim SequenceNumber As UInt16 = DLL(MyDLLInstance).EIPEncap.GetSequenceNumber
                    PLCAddressByTNS(SequenceNumber And 255).SequenceNumber = SequenceNumber
                    PLCAddressByTNS(SequenceNumber And 255).InternallyRequested = True
                    PLCAddressByTNS(SequenceNumber And 255).PLCAddress = PolledAddressList(FirstElement).PLCAddress
                    PLCAddressByTNS(SequenceNumber And 255).AsyncMode = True

                    SequenceNumber = Me.ReadAny(PolledAddressList(FirstElement).PLCAddress, NumberToRead)(0)

                    InternalRequest = False
                    'Me.ReadAny(PolledAddressList(FirstElement).PLCAddress, 1)
                    '* Return poll rate back to normal after an error goes away
                    If SavedPollRate(0) <> 0 Then
                        tmrPollList(0).Interval = SavedPollRate(0)
                        SavedPollRate(0) = 0
                    End If
                Catch ex As Exception
                    '* Send this message back to the requesting control
                    Dim TempArray() As String = {ex.Message}

                    m_SynchronizingObject.BeginInvoke(PolledAddressList(i).dlgCallBack, CObj(TempArray))
                    'Dim x As New MfgControl.AdvancedHMI.Drivers.PLCCommEventArgs(TempArray, Nothing, Nothing, PolledAddressList(i).dlgCallBack)
                    'm_SynchronizingObject.BeginInvoke(drsd, x)
                    '* Slow down the poll rate to avoid app freezing
                    If SavedPollRate(0) = 0 Then SavedPollRate(0) = tmrPollList(intTimerIndex).Interval
                    tmrPollList(intTimerIndex).Interval = 5000
                Finally
                    '* Start the poll timer
                    'tmrPollList(intTimerIndex).Enabled = True

                    Me.AsyncMode = tmp
                End Try
            End If
            i += 1
        End While
        '* Start the poll timer
        tmrPollList(intTimerIndex).Enabled = True
    End Sub


    '********************************************************************
    '* Extract the data from the byte stream returned
    '* Use the abreviated type byte that is returned with data
    '********************************************************************
    Private Shared Function ExtractData(ByVal startAddress As String, ByVal AbreviatedType As Byte, ByVal ReturnedData() As Byte) As String()
        '* Get the element size in bytes
        Dim ElementSize As Integer
        Select Case AbreviatedType
            Case &HC1 '* BIT
                ElementSize = 1
            Case &HC2 '* SINT
                ElementSize = 1
            Case &HC3 ' * INT
                ElementSize = 2
            Case &HC4, &HCA '* DINT, REAL Value read (&H91)
                ElementSize = 4
            Case &HD3 '* Bit Array
                ElementSize = 4
            Case &H82, &H83 ' * Timer, Counter, Control
                ElementSize = 14
            Case &HCE '* String
                'ElementSize = ReturnedData(0) + ReturnedData(1) * 256
                ElementSize = 88
            Case Else
                ElementSize = 2
        End Select

        '***************************************************
        '* Extract returned data into appropriate data type
        '***************************************************
        Dim ElementsToReturn As UInt16 = Math.Floor(ReturnedData.Length / ElementSize) - 1
        '* Bit Arrays are return as DINT, so it will have to be extracted
        Dim BitIndex As UInt16
        If AbreviatedType = &HD3 Then
            If startAddress.LastIndexOf("[") > 0 Then
                BitIndex = startAddress.Substring(startAddress.LastIndexOf("[") + 1, startAddress.LastIndexOf("]") - startAddress.LastIndexOf("[") - 1)
            End If
            BitIndex -= Math.Floor(BitIndex / 32) * 32
            '* Return all the bits that came back even if less were requested
            ElementsToReturn = ReturnedData.Length * 8 - BitIndex - 1
        End If
        Dim result(ElementsToReturn) As String

        '* If requesting 0 elements, then default to 1
        'Dim ArrayElements As Int16 = Math.Max(result.Length - 1 - 1, 0)


        Select Case AbreviatedType
            Case &HC1 '* BIT
                For i As Integer = 0 To result.Length - 1
                    If ReturnedData(i) Then
                        result(i) = True
                    Else
                        result(i) = False
                    End If
                Next
            Case &HCA '* REAL read (&H8A)
                For i As Integer = 0 To result.Length - 1
                    result(i) = BitConverter.ToSingle(ReturnedData, (i * 4))
                Next
            Case &HC3 '* INT Value read 
                For i As Integer = 0 To result.Length - 1
                    result(i) = BitConverter.ToInt16(ReturnedData, (i * 2))
                Next
            Case &HC4 '* DINT Value read (&H91)
                For i As Integer = 0 To result.Length - 1
                    result(i) = BitConverter.ToInt32(ReturnedData, (i * 4))
                Next
            Case &HC2 '* SINT
                For i As Integer = 0 To result.Length - 1
                    result(i) = ReturnedData(i)
                Next
            Case &HD3 '* BOOL Array
                Dim x, i, l As UInt32
                Dim CurrentBitPos As UInt16 = BitIndex
                For j As Integer = 0 To (ReturnedData.Length / 4) - 1
                    x = BitConverter.ToUInt32(ReturnedData, (j * 4))
                    While CurrentBitPos < 32
                        l = (2 ^ (CurrentBitPos))
                        result(i) = (x And l) > 0
                        i += 1
                        CurrentBitPos += 1
                    End While
                    CurrentBitPos = 0
                Next
            Case &H82, &H83 '* TODO: Timer, Counter, Control 
                Dim StartByte As Int16 = 2
                '                Dim x = startAddress
                '* Look for which sub element is specificed
                If startAddress.IndexOf(".") >= 0 Then
                    If startAddress.ToUpper.IndexOf("PRE") > 0 Then
                        StartByte = 6
                    ElseIf startAddress.ToUpper.IndexOf("ACC") > 0 Then
                        StartByte = 10
                    End If
                Else
                    '* If no subelement, then use ACC
                End If

                For i As Integer = 0 To result.Length - 1
                    result(i) = BitConverter.ToInt32(ReturnedData, (i + StartByte))
                Next
            Case &HCE ' * String
                For i As Integer = 0 To result.Length - 1
                    result(i) = System.Text.Encoding.ASCII.GetString(ReturnedData, 88 * i + 4, ReturnedData(88 * i) + ReturnedData(88 * i + 1) * 256)
                Next
            Case Else
                For i As Integer = 0 To result.Length - 1
                    result(i) = BitConverter.ToInt16(ReturnedData, (i * 2))
                Next
        End Select


        Return result
    End Function
    '*************************************************************
    '* Overloaded method of ReadAny - that reads only one element
    '*************************************************************
    ''' <summary>
    ''' Synchronous read of any data type
    ''' this function returns results as a string
    ''' </summary>
    ''' <param name="startAddress"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function ReadAny(ByVal startAddress As String) As String '
        Return ReadAny(startAddress, 1)(0)
    End Function



    '*****************************************************************
    '* Write Section
    '*
    '* Address is in the form of <file type><file Number>:<offset>
    '* examples  N7:0, B3:0,
    '******************************************************************

    '* Handle one value of Integer type
    ''' <summary>
    ''' Write a single integer value to a PLC data table
    ''' The startAddress is in the common form of AB addressing (e.g. N7:0)
    ''' </summary>
    ''' <param name="startAddress"></param>
    ''' <param name="dataToWrite"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function WriteData(ByVal startAddress As String, ByVal dataToWrite As Integer) As Integer
        Dim temp(1) As Integer
        temp(0) = dataToWrite
        Return WriteData(startAddress, 1, temp)
    End Function


    '* Write an array of integers
    ''' <summary>
    ''' Write multiple consectutive integer values to a PLC data table
    ''' The startAddress is in the common form of AB addressing (e.g. N7:0)
    ''' </summary>
    ''' <param name="startAddress"></param>
    ''' <param name="numberOfElements"></param>
    ''' <param name="dataToWrite"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function WriteData(ByVal startAddress As String, ByVal numberOfElements As Integer, ByVal dataToWrite() As Integer) As Integer
        Try
            MsgFalla = ""
            Dim StringVals(numberOfElements) As String
            For i As Integer = 0 To numberOfElements - 1
                StringVals(i) = CStr(dataToWrite(i))
            Next
            DLL(MyDLLInstance).WriteTagValue(startAddress, StringVals, numberOfElements)
            WriteData = 1

        Catch ex As Exception
            'MsgBox(ex.ToString)
            MsgFalla = ex.Message
            Return -1
        End Try
        'Return WriteRawData(ParsedResult, numberOfElements * ParsedResult.BytesPerElements, ConvertedData)
    End Function

    '* Handle one value of Single type
    ''' <summary>
    ''' Write a single floating point value to a data table
    ''' The startAddress is in the common form of AB addressing (e.g. F8:0)
    ''' </summary>
    ''' <param name="startAddress"></param>
    ''' <param name="dataToWrite"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function WriteData(ByVal startAddress As String, ByVal dataToWrite As Single) As Integer
        Dim temp(1) As Single
        temp(0) = dataToWrite
        Return WriteData(startAddress, 1, temp)
    End Function

    '* Write an array of Singles
    ''' <summary>
    ''' Write multiple consectutive floating point values to a PLC data table
    ''' The startAddress is in the common form of AB addressing (e.g. F8:0)
    ''' </summary>
    ''' <param name="startAddress"></param>
    ''' <param name="numberOfElements"></param>
    ''' <param name="dataToWrite"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function WriteData(ByVal startAddress As String, ByVal numberOfElements As Integer, ByVal dataToWrite() As Single) As Integer
        Dim ParsedResult As ParsedDataAddress = ParseAddress(startAddress)

        Dim ConvertedData(numberOfElements * ParsedResult.BytesPerElements) As Byte

        Dim i As Integer
        If ParsedResult.FileType = &H8A Then
            '*Write to a floating point file
            Dim bytes(4) As Byte
            For i = 0 To numberOfElements - 1
                bytes = BitConverter.GetBytes(CSng(dataToWrite(i)))
                For j As Integer = 0 To 3
                    ConvertedData(i * 4 + j) = CByte(bytes(j))
                Next
            Next
        ElseIf ParsedResult.FileType = &H91 Then
            '* Write to a Long integer file
            While i < numberOfElements
                '* Validate range
                If dataToWrite(i) > 2147483647 Or dataToWrite(i) < -2147483648 Then
                    Throw New MfgControl.AdvancedHMI.Drivers.PLCDriverException("Integer data out of range, must be between -2147483648 and 2147483647")
                End If

                Dim b(3) As Byte
                b = BitConverter.GetBytes(CInt(dataToWrite(i)))

                ConvertedData(i * 4) = b(0)
                ConvertedData(i * 4 + 1) = b(1)
                ConvertedData(i * 4 + 2) = b(2)
                ConvertedData(i * 4 + 3) = b(3)
                i += 1
            End While
        Else
            '* Write to an integer file
            While i < numberOfElements
                '* Validate range
                If dataToWrite(i) > 32767 Or dataToWrite(i) < -32768 Then
                    Throw New MfgControl.AdvancedHMI.Drivers.PLCDriverException("Integer data out of range, must be between -32768 and 32767")
                End If

                ConvertedData(i * 2) = CByte(dataToWrite(i) And &HFF)
                ConvertedData(i * 2 + 1) = CByte((dataToWrite(i) >> 8) And &HFF)
                i += 1
            End While
        End If
        WriteData = 1
        'Return WriteRawData(ParsedResult, numberOfElements * ParsedResult.BytesPerElements, ConvertedData)
    End Function

    '* Write a String
    ''' <summary>
    ''' Write a string value to a string data table
    ''' The startAddress is in the common form of AB addressing (e.g. ST9:0)
    ''' </summary>
    ''' <param name="startAddress"></param>
    ''' <param name="dataToWrite"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function WriteData(ByVal startAddress As String, ByVal dataToWrite As String) As String
        If dataToWrite Is Nothing Then
            Return 0
        End If

        Dim StringVals() As String = {dataToWrite}
        DLL(MyDLLInstance).WriteTagValue(startAddress, StringVals, 1)

        Return 0
    End Function

    'End of Public Methods
#End Region


#Region "Shared Methods"
    '****************************************************************
    '* Convert an array of words into a string as AB PLC's represent
    '* Can be used when reading a string from an Integer file
    '****************************************************************
    ''' <summary>
    ''' Convert an array of integers to a string
    ''' This is used when storing strings in an integer data table
    ''' </summary>
    ''' <param name="words"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function WordsToString(ByVal words() As Int32) As String
        Dim WordCount As Integer = words.Length
        Return WordsToString(words, 0, WordCount)
    End Function

    ''' <summary>
    ''' Convert an array of integers to a string
    ''' This is used when storing strings in an integer data table
    ''' </summary>
    ''' <param name="words"></param>
    ''' <param name="index"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function WordsToString(ByVal words() As Int32, ByVal index As Integer) As String
        Dim WordCount As Integer = (words.Length - index)
        Return WordsToString(words, index, WordCount)
    End Function

    ''' <summary>
    ''' Convert an array of integers to a string
    ''' This is used when storing strings in an integer data table
    ''' </summary>
    ''' <param name="words"></param>
    ''' <param name="index"></param>
    ''' <param name="wordCount"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function WordsToString(ByVal words() As Int32, ByVal index As Integer, ByVal wordCount As Integer) As String
        Dim j As Integer = index
        Dim result2 As New System.Text.StringBuilder
        While j < wordCount
            result2.Append(Chr(words(j) / 256))
            '* Prevent an odd length string from getting a Null added on
            If CInt(words(j) And &HFF) > 0 Then
                result2.Append(Chr(words(j) And &HFF))
            End If
            j += 1
        End While

        Return result2.ToString
    End Function


    '**********************************************************
    '* Convert a string to an array of words
    '*  Can be used when writing a string to an Integer file
    '**********************************************************
    ''' <summary>
    ''' Convert a string to an array of words
    ''' Can be used when writing a string into an integer data table
    ''' </summary>
    ''' <param name="source"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function StringToWords(ByVal source As String) As Int32()
        If source Is Nothing Then
            Return Nothing
            ' Throw New ArgumentNullException("input")
        End If

        Dim ArraySize As Integer = CInt(Math.Ceiling(source.Length / 2)) - 1

        Dim ConvertedData(ArraySize) As Int32

        Dim i As Integer
        While i <= ArraySize
            ConvertedData(i) = Asc(source.Substring(i * 2, 1)) * 256
            '* Check if past last character of odd length string
            If (i * 2) + 1 < source.Length Then ConvertedData(i) += Asc(source.Substring((i * 2) + 1, 1))
            i += 1
        End While

        Return ConvertedData
    End Function

#End Region

#Region "Helper"
    Private Structure ParsedDataAddress
        Dim PLCAddress As String
        Dim FileType As Integer
        Dim SequenceNumber As Integer
        Dim Element As Integer
        Dim SubElement As Integer
        Dim BitNumber As Integer
        Dim BytesPerElements As Integer
        Dim TableSizeInBytes As Integer
        Dim NumberRead As Integer
        Dim InternallyRequested As Boolean
        Dim NumberOfElements As Integer
        Dim AsyncMode As Boolean
    End Structure

    '*********************************************************************************
    '* Parse the address string and validate, if invalid, Return 0 in FileType
    '*********************************************************************************
    Private Shared Function ParseAddress(ByVal DataAddress As String) As ParsedDataAddress
        Dim result As New ParsedDataAddress

        result.BitNumber = 99  '* Let a 99 indicate no bit level requested

        '*******************************************************************
        '* Keep the originall address with the parsed values for later use
        '*******************************************************************
        result.PLCAddress = DataAddress


        '* These subelements are bit level
        If result.SubElement > 8 Then
            result.BitNumber = result.SubElement
            result.SubElement = 0
        End If

        Return result
    End Function

    '****************************************************
    '* Wait for a response from PLC before returning
    '****************************************************
    Dim MaxTicks As Integer = 85  '* 50 ticks per second
    Private Function WaitForResponse(ByVal rTNS As Integer) As Integer
        'Responded = False

        Dim Loops As Integer = 0
        While Not Responded(rTNS) And Loops < MaxTicks
            'Application.DoEvents()
            System.Threading.Thread.Sleep(20)
            Loops += 1
        End While

        If Loops >= MaxTicks Then
            Return -20
        Else
            Return 0
        End If
    End Function

    '**************************************************************
    '* This method implements the common application routine
    '* as discussed in the Software Layer section of the AB manual
    '**************************************************************
    '**************************************************************
    '* This method Sends a response from an unsolicited msg
    '**************************************************************
    'Private Function SendResponse(ByVal Command As Byte, ByVal rTNS As Integer) As Integer
    'End Function

    ' TODO : Put this in a New event
    'Private EventHandleAdded As Boolean
    '* This is needed so the handler can be removed
    Private Dr As EventHandler = AddressOf DataLinkLayer_DataReceived
    Private Function SendData(ByVal data() As Byte, ByVal MyNode As Byte, ByVal TargetNode As Byte) As Integer
        If DLL(0) Is Nothing Then
            CreateDLLInstance()
        End If


        'If Not EventHandleAdded Then
        '    AddHandler DLL.DataReceived, AddressOf DataLinkLayer_DataReceived
        '    EventHandleAdded = True
        'End If

        Return DLL(MyDLLInstance).ExecutePCCC(data)
    End Function

    '************************************************
    '* Convert the message code number into a string
    '* Ref Page 8-3
    '************************************************
    Public Shared Function DecodeMessage(ByVal msgNumber As Integer) As String
        Select Case msgNumber
            Case 0
                DecodeMessage = ""
            Case -2
                Return "Not Acknowledged (NAK)"
            Case -3
                Return "No Reponse, Check COM Settings"
            Case -4
                Return "Unknown Message from DataLink Layer"
            Case -5
                Return "Invalid Address"
            Case -6
                Return "Could Not Open Com Port"
            Case -7
                Return "No data specified to data link layer"
            Case -8
                Return "No data returned from PLC"
            Case -20
                Return "No Data Returned"
            Case -21
                Return "Received Message NAKd from invalid checksum"

                '*** Errors coming from PLC
            Case 4
                Return "Invalid Tag Address."
            Case 32
                Return "PLC Has a Problem and Will Not Communicate"

                '* EXT STS Section - 256 is added to code to distinguish EXT codes
            Case 257
                Return "A field has an illegal value"
            Case 258
                Return "Less levels specified in address than minimum for any address"
            Case 270
                Return "Command cannot be executed"

            Case Else
                Return "Unknown Message - " & msgNumber
        End Select
    End Function


    '***************************************************************************************
    '* If an error comes back from the driver, return the description back to the control
    '***************************************************************************************
    Private Sub _CommError(ByVal sender As Object, ByVal e As MfgControl.AdvancedHMI.Drivers.PLCCommErrorEventArgs)
        Dim d() As String = {e.ErrorMessage}
        Dim x As New MfgControl.AdvancedHMI.Drivers.PLCCommEventArgs(d, Nothing, Nothing)
        If m_SynchronizingObject IsNot Nothing Then
            If PolledAddressList(0).dlgCallBack Is Nothing Then
                Dim Parameters() As Object = {Me, x}
                m_SynchronizingObject.BeginInvoke(drsd, Parameters)
            Else
                m_SynchronizingObject.BeginInvoke(PolledAddressList(0).dlgCallBack, CObj(d))
            End If
        Else
            RaiseEvent DataReceived(Me, x)
        End If

    End Sub

    'Private mut As New System.Threading.Mutex
    Private Sub DataLinkLayer_DataReceived(ByVal sender As Object, ByVal e As MfgControl.AdvancedHMI.Drivers.PLCCommEventArgs)
        'mut.WaitOne()
        '* A number less than 0 indicates an error
        If e.SequenceNumber < 0 Then
            '* Return this error to all the components
            For i As Integer = 0 To PolledAddressList.Count - 1
                m_SynchronizingObject.BeginInvoke(PolledAddressList(i).dlgCallBack, CObj(e.Values))
                'Dim x As New MfgControl.AdvancedHMI.Drivers.PLCCommEventArgs(e.Values, Nothing, Nothing, PolledAddressList(i).dlgCallBack)
                'm_SynchronizingObject.BeginInvoke(drsd, x)
            Next

            '* Slow down the polling to prevent freezing
            'For i As Integer = 0 To tmrPollList.Count - 1
            '    If SavedPollRate(i) = 0 Then SavedPollRate(i) = tmrPollList(i).Interval
            '    tmrPollList(i).Interval = 5000
            '    tmrPollList(i).Enabled = False
            '    tmrPollList(i).Enabled = True
            'Next

            Exit Sub
        End If

        Dim SequenceNumber As UInt16 = e.SequenceNumber And 255

        'Dim mc As Int32
        'While GettingSeqNumber(SequenceNumber) And mc < 9999
        '    mc += 1
        'End While


        '**************************************************************************
        '* If the parent form property (Synchronizing Object) is set, then sync the event with its thread
        '**************************************************************************
        '* Get the low byte from the Sequence Number
        '* The sequence number was added onto the end of the CIP packet by the EthernetIPLayer object
        'Dim SequenceNumber As Integer = DLL(MyDLLInstance).DataPacket(SequenceNumber)(DLL(MyDLLInstance).DataPacket(SequenceNumber).Count - 2)
        'DataPackets(e.SequenceNumber) = DLL(MyDLLInstance).DataPacket(e.SequenceNumber)

        Responded(SequenceNumber) = True

        If PLCAddressByTNS(SequenceNumber).AsyncMode Then
            '* Check the status byte
            Dim StatusByte As Int16 = DLL(MyDLLInstance).DataPacket(SequenceNumber)(2)
            If StatusByte = 0 Then
                '**************************************************************
                '* Only extract and send back if this response contained data
                '**************************************************************
                If DLL(MyDLLInstance).DataPacket(SequenceNumber).Count > 5 Then
                    '***************************************************
                    '* Extract returned data into appropriate data type
                    '* Transfer block of data read to the data table array
                    '***************************************************
                    '* TODO: Check array bounds
                    Try
                        Dim DataType As Byte = DLL(MyDLLInstance).DataPacket(SequenceNumber)(4)
                        Dim DataStartIndex As UInt16 = 6
                        '* Is it a complex data type
                        If DataType = &HA0 Then
                            DataType = DLL(MyDLLInstance).DataPacket(SequenceNumber)(6)
                            DataStartIndex = 8
                        End If
                        Dim ReturnedData(DLL(MyDLLInstance).DataPacket(SequenceNumber).Count - DataStartIndex - 1) As Byte
                        For i As Integer = 0 To ReturnedData.Length - 1
                            ReturnedData(i) = DLL(MyDLLInstance).DataPacket(SequenceNumber)(i + DataStartIndex)
                        Next

                        '* Pass the abrevaited data type (page 11 of 1756-RM005A)
                        Dim d() As String = ExtractData(PLCAddressByTNS(SequenceNumber).PLCAddress, DataType, ReturnedData)


                        If Not PLCAddressByTNS(SequenceNumber).InternallyRequested Then
                            If Not DisableEvent Then
                                Dim x As New MfgControl.AdvancedHMI.Drivers.PLCCommEventArgs(d, PLCAddressByTNS(SequenceNumber).PLCAddress, SequenceNumber)
                                If m_SynchronizingObject IsNot Nothing Then
                                    Dim Parameters() As Object = {Me, x}
                                    m_SynchronizingObject.BeginInvoke(drsd, Parameters)
                                Else
                                    'RaiseEvent DataReceived(Me, System.EventArgs.Empty)
                                    RaiseEvent DataReceived(Me, x)
                                End If
                            End If
                        Else
                            '*********************************************************
                            '* Check to see if this is from the Polled variable list
                            '*********************************************************
                            For i As Integer = 0 To PolledAddressList.Count - 1
                                If PolledAddressList(i).PLCAddress = PLCAddressByTNS(SequenceNumber).PLCAddress Then
                                    'Dim PA As ParsedDataAddress = PLCAddressByTNS(SequenceNumber)
                                    'Dim sn As UInt16 = SequenceNumber
                                    'Dim plcAddress As String = PA.PLCAddress

                                    Dim BitResult(PolledAddressList(i).ElementsToRead - 1) As String

                                    '* All other data types
                                    For k As Integer = 0 To PolledAddressList(i).ElementsToRead - 1
                                        BitResult(k) = d((PolledAddressList(i).ElementNumber - PLCAddressByTNS(SequenceNumber).Element + k))
                                    Next

                                    m_SynchronizingObject.BeginInvoke(PolledAddressList(i).dlgCallBack, CObj(BitResult))
                                    'Dim x As New MfgControl.AdvancedHMI.Drivers.PLCCommEventArgs(BitResult, Nothing, Nothing, PolledAddressList(i).dlgCallBack)
                                    'm_SynchronizingObject.BeginInvoke(drsd, x)
                                End If
                            Next
                        End If
                    Catch ex As Exception
                        Dim dbg = 0
                    End Try
                End If
            Else
                '*****************************
                '* Failed Status was returned
                '*****************************
                Dim d() As String = {DecodeMessage(StatusByte) & " CIP Status " & StatusByte}
                If Not PLCAddressByTNS(SequenceNumber).InternallyRequested Then
                    If Not DisableEvent Then

                        Dim x As New MfgControl.AdvancedHMI.Drivers.PLCCommEventArgs(d, PLCAddressByTNS(SequenceNumber).PLCAddress, SequenceNumber)
                        If m_SynchronizingObject IsNot Nothing Then
                            Dim Parameters() As Object = {Me, x}
                            m_SynchronizingObject.BeginInvoke(drsd, Parameters)
                        Else
                            'RaiseEvent DataReceived(Me, System.EventArgs.Empty)
                            RaiseEvent DataReceived(Me, x)
                        End If
                    End If
                Else
                    For i As Integer = 0 To PolledAddressList.Count - 1
                        If PolledAddressList(i).PLCAddress = PLCAddressByTNS(SequenceNumber).PLCAddress Then
                            m_SynchronizingObject.BeginInvoke(PolledAddressList(i).dlgCallBack, CObj(d))
                        End If
                    Next
                End If
            End If
        End If
        'mut.ReleaseMutex()
    End Sub

    '******************************************************************
    '* This is called when a message instruction was sent from the PLC
    '******************************************************************
    Private Sub DF1DataLink1_UnsolictedMessageRcvd()
        If m_SynchronizingObject IsNot Nothing Then
            Dim Parameters() As Object = {Me, EventArgs.Empty}
            m_SynchronizingObject.BeginInvoke(drsd, Parameters)
        Else
            RaiseEvent UnsolictedMessageRcvd(Me, System.EventArgs.Empty)
        End If
    End Sub


    '****************************************************************************
    '* This is required to sync the event back to the parent form's main thread
    '****************************************************************************
    Dim drsd As EventHandler = AddressOf DataReceivedSync
    'Delegate Sub DataReceivedSyncDel(ByVal sender As Object, ByVal e As EventArgs)
    Private Sub DataReceivedSync(ByVal sender As Object, ByVal e As MfgControl.AdvancedHMI.Drivers.PLCCommEventArgs)
        RaiseEvent DataReceived(Me, e)
    End Sub

    Private Sub UnsolictedMessageRcvdSync(ByVal sender As Object, ByVal e As EventArgs)
        RaiseEvent UnsolictedMessageRcvd(sender, e)
    End Sub

    'Dim rsv As Ico = AddressOf ReturnSubscribedValues
    'Private Sub ReturnSubscribedValues(ByVal ar As IAsyncResult, ByVal e As MfgControl.AdvancedHMI.Drivers.PLCCommEventArgs)
    '    If e.dlgCallBack IsNot Nothing Then
    '        m_SynchronizingObject.Invoke(e.dlgCallBack, e.Values)

    '    End If
    '    m_SynchronizingObject.EndInvoke(ar)
    'End Sub

#End Region

End Class

Public Interface ICommComponent
    Delegate Sub ReturnValues(ByVal Values As String())
    Function Subscribe(ByVal PLCAddress As String, ByVal updateRate As Integer, ByVal callBack As ReturnValues) As Integer
    Function UnSubscribe(ByVal ID As Integer) As Integer
    Function ReadAny(ByVal startAddress As String) As String
    Function ReadAny(ByVal startAddress As String, ByVal numberOfElements As Integer) As String()
    Function WriteData(ByVal startAddress As String, ByVal dataToWrite As String) As String
    Property DisableSubscriptions() As Boolean
End Interface