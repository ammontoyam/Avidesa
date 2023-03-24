Option Explicit On
Imports System.Text
Imports System.Windows.Forms
Imports System.IO
Imports System.Data.Common
Imports System.Data
Imports System.Threading.Thread
Imports ClassLibrary
Imports iTextSharp.text.pdf
Imports iTextSharp.text

Public Class ImportFor

    Private DFor As AdoSQL
    Private DDatosFor As AdoSQL
    Private DArt As AdoSQL
    Private DTolvas As AdoSQL
    Private DVarios As AdoSQL
    Private DBaches As AdoSQL
    Private DEquivFormProd As AdoSQL
    Private DConfigVar As AdoSQL
    Private DNutFor As AdoSQL


    Private Filas() As String, Campos() As String


    Private RutaArchivo As String = vbNullString
    Private Renglon, CodFormula, NomFormula, Lp, FechaFor, TolSup, TolInf,
        CodMat, PesoMeta, Bascula, CodMatB, NomMat, Especie, Grupo, Cantidad,
        Fecha, TipoMat, A, CodForB, TiempoMSeca, TiempoMHumeda As String
    'Private CodEstablecimiento As String
    Private TiempoMSecaDef As String
    Private TiempoMHumedaDef As String
    'Private DR As DataRow
    'Private DFila() As DataRow 
    Private LEnc As StreamReader
    Private Contenido As String
    Private Posi As Int64 = 0, Posi2 As Int64 = 0
    'Private CodFylax As String
    'Private CodPaquetePrem As Boolean
    Private ManejaPx As Boolean

    'Private SpHumedad As Single
    'Private HabCorreccionHum As Int16
    'Private NumReceta As Int16
    'Private TipoAlimento As Int16
    'Private PorcAgua As Single
    Private RenglonAux() As String = Nothing



    Private Sub ImportFor_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            DFor = New AdoSQL("Formulas")
            DDatosFor = New AdoSQL("DatosFor")
            DArt = New AdoSQL("Materiales")
            DTolvas = New AdoSQL("TOLVAS")
            DVarios = New AdoSQL("VARIOS")
            DBaches = New AdoSQL("BACHES")
            DEquivFormProd = New AdoSQL("EQUIVFORMPROD")

            DNutFor = New AdoSQL("NUTFOR")
            DConfigVar = New AdoSQL("CONFIVAR")

            DArt.Open("select * from ARTICULOS where TIPO='MP' order by CODINT")
            DFor.Open("Select * from FORMULAS where CODFOR='0'")
            DDatosFor.Open("Select * from DATOSFOR where CODFOR='0'")
            DTolvas.Open("Select * from TOLVAS")

            'Traemos los tiempos de mezcla por defecto configurados en la base de datos
            TiempoMSecaDef = ConfigParametros("TiempoMezclaSeca")
            TiempoMHumedaDef = ConfigParametros("TiempoMezclaHumeda")

            ''Si hay dosificacion de Fylax en la planta, se trae el codigo del Fylax
            'If Funcion_ManejaFylax Then CodFylax = ConfigParametros("CodigoFylax")

        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub
    Private Sub BBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BBuscar.Click
        Try

            If TRuta.Text = "" Then
                OpenFile.InitialDirectory = Ruta '"C:\"
            Else
                OpenFile.InitialDirectory = CLeft(TRuta.Text, InStrRev(TRuta.Text, "\"))
            End If

            OpenFile.Filter = "pdf files (*.pdf)|*.pdf|All files (*.*)|*.*"
            OpenFile.FilterIndex = 0
            OpenFile.RestoreDirectory = True

            If (OpenFile.ShowDialog() = DialogResult.OK) Then
                TRuta.Text = OpenFile.FileName
                BTraerFor_Click(0, Nothing)
            End If

        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub BTraerFor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTraerFor.Click
        Try
            Dim CodForAux As String = ""
            Dim PrefijoPlanta As String = ""

            If TRuta.Text.Trim = vbNullString Then
                MessageBox.Show("Debe seleccionar primero el archivo donde se encuentran las fórmulas", "ChronoSoft", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If

            DGFor.Rows.Clear()

            If File.Exists(Ruta + "formula.txt") Then File.Delete(Ruta + "formula.txt")
            If File.Exists(Ruta + "formula.pdf") Then File.Delete(Ruta + "formula.pdf")

            RutaArchivo = Ruta + "formula.pdf"
            FileCopy(TRuta.Text.Trim, RutaArchivo)

            Resp = Shell(Ruta + "PDF\p2tagent --src=" + Ruta + "formula.pdf --dest=" + Ruta + "formula.txt")
            'Resp = Shell("cmd.exe /k pdftotext  -layout formula.pdf  && call exit")
            Sleep(1800) ' Tiempo de espera para que se cree el archivo formula.txt
            Application.DoEvents()

            RutaArchivo = Ruta + "formula.txt"
            LEnc = File.OpenText(RutaArchivo)
            Contenido = LEnc.ReadToEnd
            LEnc.Close()

            RenglonAux = Split(Contenido, vbCrLf)

            For i As UShort = 0 To RenglonAux.Length - 1
                Posi = InStr(RenglonAux(i), "Pricing Plant : AVIBU - AVIDESA MAC POLLO BUCARAMANGA")

                If Posi > 0 Then
                    i = i + 2
                    FechaFor = (RenglonAux(i)).Trim
                End If

                Posi = InStr(RenglonAux(i), "Formula")
                If Posi > 0 Then

                    i = i + 2

                    CodFormula = Eval(RenglonAux(i).Trim)
                    NomFormula = Mid(RenglonAux(i), 10).Trim
                    Lp = "-" 'Eval(Renglon)

                    'If Val(CodFormula) < 1 Or Val(CodFormula) > 2680 Then
                    '    MsgBox("Número de fórmula no válido para el equipo de dosificación", vbInformation)
                    '    Continue For
                    'End If

                    DGFor.Rows.Add()
                    DGFor.Rows(DGFor.Rows.Count - 1).Cells("CodFor").Value = CodFormula
                    DGFor.Rows(DGFor.Rows.Count - 1).Cells("NomFor").Value = NomFormula
                    DGFor.Rows(DGFor.Rows.Count - 1).Cells("Version").Value = Lp
                    'DGFor.Rows(DGFor.Rows.Count - 1).Cells("Establecimiento").Value = CodEstablecimiento
                    DGFor.Rows(DGFor.Rows.Count - 1).Cells("FechaForm").Value = FechaFor

                End If
            Next


            If DGFor.RowCount > 0 Then TMensaje.Text = "El Archivo Contiene " + DGFor.RowCount.ToString + " Fórmulas "

        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub BSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BSalir.Click, mnSalir.Click
        Try
            DGFor.Rows.Clear()
            Me.Hide()
        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub BImportar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BImportar.Click
        Try
            If DGFor.RowCount = 0 Then Exit Sub

            Dim CodForSinEstb As String = ""
            Dim Paso As Integer = 1
            Dim NumIngred As Integer = 0
            Dim CodPrem As String = ""
            Dim HumedadFor As Double = 0
            Dim MezcExt As Boolean = False
            Dim GrasaFor As Single = 0
            Dim TamBache As Single = 0
            Dim PorcAdicFilax As Single = 0
            'Dim PosNomMat As Short
            Dim NomNut As String = ""
            Dim item As UShort = 0
            Dim unidad As String = ""
            Dim MotoNave As String = ""

            Posi = 0

            For j As Integer = DGFor.SelectedRows.Count - 1 To 0 Step -1

                CodFormula = DGFor.SelectedRows(j).Cells("CodFor").Value.ToString
                NomFormula = DGFor.SelectedRows(j).Cells("NomFor").Value.ToString
                FechaFor = DGFor.SelectedRows(j).Cells("FechaForm").Value.ToString
                Lp = DGFor.SelectedRows(j).Cells("Version").Value.ToString
                'CodEstablecimiento = DGFor.SelectedRows(j).Cells("Establecimiento").Value.ToString

                'Validaciones para dejar importar la formula
                'Se revisa si ya hay premezclas exportadas con esta formula, si es asi no se deja importar
                DVarios.Open("select * from CONSUMOSMED WHERE ESTADO<10 and CODFOR='" + CodFormula + "' AND LP='" + Lp + "'")

                If DVarios.Count Then
                    Resp = MsgBox("No debe alterar ni agregar códigos de materia prima a esta fórmula " +
                                " debido a que la premezcla ya fue procesada por el departamento de costos", MsgBoxStyle.Critical)
                    Return
                End If

                'Revisa que los ultimos baches no sean de la fórmula a editar                                
                DBaches.Open("select TOP 5 * from BACHES ORDER by FECHA desc")

                For Each RSBaches As DataRow In DBaches.Rows
                    If (RSBaches("CODFOR") = CodFormula AndAlso RSBaches("LP") = Lp) Then
                        Resp = MsgBox("No debe alterar ni agregar códigos de materia prima a esta fórmula ya que se " +
                        " encuentra en proceso de dosificación y alteraría los Reportes" +
                        vbCrLf + "Desea continuar de todas formas?", MsgBoxStyle.Information + MsgBoxStyle.YesNo)
                        If Resp = vbNo Then Return
                    End If
                Next


                'ASIGNACIÓN AUTOMÁTICA DE LA VERSIÓN POR FÓRMULA IMPORTADA       
                'DConfigVar.Find("CAMPO = 'VersionFor'")
                'If DConfigVar.EOF Then 'Formula Nueva
                If Val(ConfigParametros("VersionFor")) = 0 Then
                    'RespInput = InputBox.InputBox("Indique la VERSIÓN que le dará a la fórmula " + CodForB + " " + NomFormula, "ChronoSoft", "")
                    If InputBox.InputBox("Importar Fórmula", "Ingrese la versión de la fórmula seleccionada", RespInput) = DialogResult.Cancel Then
                        Continue For
                    End If
                    Lp = Val(RespInput)
                Else
                    'Lp = Val(DConfigVar.RecordSet("VersionFor")) + 1
                    Lp = Val(ConfigParametros("VersionFor")) + 1
                End If

                DVarios.Open("select * from FORMULAS where CODFOR=" + Trim(CodFormula) + " and LP=" + Trim(Lp))

                If DVarios.Count > 0 Then
                    MsgBox(" La Fórmula " + CodFormula + " " + NomFormula + " Ya tiene asignada la Versión Ingresada, debe ingresar una versión válida", vbCritical)
                    Exit Sub
                End If

                CodPrem = "0"
                CodForB = CodFormula
                Especie = "0"
                Grupo = "0"
                ManejaPx = False
                'Por Defecto estos valores
                TiempoMSeca = TiempoMSecaDef
                TiempoMHumeda = TiempoMHumedaDef


                'Recuperamos la especie y el grupo de Formula
                'DFor.Open("select top 1 * from FORMULAS where CODFOR=" + Trim(CodFormula))
                DFor.Open("select top 1 * from FORMULAS where CODFOR='" + CodFormula.Trim + "' and LP='" + Lp + "'")

                If DFor.Count Then
                    Resp = MessageBox.Show(" La Fórmula " + CodFormula.Trim + " " + NomFormula.ToString.Trim + " ya existe, desea reemplazarla ", "ChronoSoft Net", MessageBoxButtons.YesNo, MessageBoxIcon.Information)
                    If Resp = vbNo Then
                        Continue For
                    End If
                    Especie = DFor.RecordSet("CODESPECIE")
                    Grupo = DFor.RecordSet("CODGRPFOR")
                    CodPrem = DFor.RecordSet("CODPREMEZCLA")
                    TiempoMSeca = DFor.RecordSet("TMSECA")
                    TiempoMHumeda = DFor.RecordSet("TMHUMEDA")
                    DFor.RecordSet.Delete()

                    DFor.Update()

                    DDatosFor.Delete("delete from DATOSFOR where CODFOR='" + CodFormula.Trim + "' and LP='" + Lp + "'")
                    DFor.Delete("delete from FORMULAS where CODFOR='" + CodFormula.Trim + "' and LP='" + Lp + "'")
                    'Eliminamos la composicion nutricional de la Fórmula
                    DNutFor.Open("delete from NUTFOR where CODFOR=" + CodFormula.Trim + " and LP=" + Lp)
                End If

                RespInput = ""

                DFor.AddNew()
                DFor.RecordSet("CODFOR") = CodFormula
                DFor.RecordSet("CODFORB") = CodForB
                DFor.RecordSet("NOMFOR") = CLeft(NomFormula.ToUpper, 30)
                'DFor.RecordSet("TOTALFOR") = TamBache
                DFor.RecordSet("CODESPECIE") = Especie
                DFor.RecordSet("CODGRPFOR") = Grupo
                DFor.RecordSet("TMSECA") = TiempoMSeca
                DFor.RecordSet("TMHUMEDA") = TiempoMHumeda
                'DFor.RecordSet("MANEJAPX") = ManejaPx
                DFor.RecordSet("CODPREMEZCLA") = CodPrem
                DFor.RecordSet("FECHAFOR") = FechaFor
                DFor.RecordSet("USUARIOIMPFOR") = CLeft(UsuarioPrincipal, 20)
                'DFor.RecordSet("CODESTABLECIMIENTO") = CodEstablecimiento
                DFor.RecordSet("LP") = Lp
                DFor.RecordSet("FECHAIMPFOR") = FechaC()
                'DFor.RecordSet("MEZCEXT") = MezcExt

                DFor.Update(Me)

                If Funcion_AprobarFormulaImportada Then
                    'Quitamos el aprobado a todas las formulas del mismo código menos a la versión que acabamos 
                    'de importar
                    'DVarios.Open("Update FORMULAS set ESTADO='-' where CODESTABLECIMIENTO='" + CodEstablecimiento + "' and CODFOR='" + CodFormula + "' AND LP<>'" + Lp + "'")
                    DVarios.Open("Update FORMULAS set ESTADO='-' where CODFOR='" + CodFormula + "' AND LP<>'" + Lp + "'")
                End If

                Paso = 1

                '---------------------------------------------LLENA LA TABLA DATOSFOR------------------------------------------------------------------------------------------
                RenglonAux = Split(Contenido, vbCrLf)


                For i As UShort = 0 To RenglonAux.Length - 1

                    Posi = InStr(1, RenglonAux(i), NomFormula)
                    Posi2 = InStr(1, RenglonAux(i), Trim(CodFormula))

                    If ((Posi > 0 And Posi2 = 1) AndAlso (Posi2 < Posi)) Then  'Se acota que renglón tenga nombre de fórmula, y el código de fórmula posicionado en la primera columna
                        For k As UShort = i + 2 To RenglonAux.Length - 1


                            If InStr(1, RenglonAux(k), "---------------") > 0 Then
                                k = k + 1
                                i = k
                                Renglon = RenglonAux(k)
                                Renglon = Replace(Renglon, ".", "")
                                TamBache = Eval(Renglon)
                                Exit For
                            End If
                            Renglon = RenglonAux(k)

                            CodMat = Eval(Renglon)
                            Posi = InStr(1, Renglon, " ")
                            Renglon = Trim(Mid(Renglon, Posi))

                            'Encontrar la primera "," hacia la derecha y luego el primer espacio de ese resultado hacia la izquierda
                            Posi = InStrRev(Renglon, " ", InStr(1, Renglon, ","))

                            NomMat = Trim(Mid(Renglon, 1, Posi))
                            Renglon = Trim(Mid(Renglon, Posi))
                            Posi = InStr(1, Renglon, " ")
                            PesoMeta = Trim(Mid(Renglon, 1, Posi))
                            PesoMeta = Replace(PesoMeta, ".", "")
                            PesoMeta = Replace(PesoMeta, ",", ".")

                            If PesoMeta > 25 Then 'If Valor > 15 Then
                                PesoMeta = Math.Round(CDec(PesoMeta), 0)
                            Else
                                PesoMeta = Math.Round(CDec(PesoMeta), 2)
                                'AJUSTE REDONDEO DE DECIMALES A 2 DIGITOS
                                PesoMeta = Int((PesoMeta * 10 ^ 2) + 0.5) / 10 ^ 2
                                'If (Valor - Int(Valor)) * 100 Mod 2 <> 0 Then Valor = Int(Valor) + ((Valor - Int(Valor)) * 100 + 1) / 100
                            End If

                            If Val(PesoMeta) = 0 Then
                                MsgBox("No se puede importar la Fórmula, ya que el archivo no tiene el formato " + vbCrLf + Renglon, vbCritical)
                                Evento("No se puede importar la Fórmula, ya que el archivo no tiene el formato " + Renglon)
                                Exit Sub
                            End If

                            DArt.Open("select * from ARTICULOS where CODINT='" + CodMat + "'")
                            CodMatB = CodMat
                            TolSup = 0
                            TolInf = 0
                            If DArt.Count > 0 Then
                                CodMatB = DArt.RecordSet("CODEXT")
                                MotoNave = DArt.RecordSet("MOTONAVE")
                                NomMat = DArt.RecordSet("NOMBRE")
                                TipoMat = DArt.RecordSet("TIPOMAT")
                                Bascula = DArt.RecordSet("BASCULA")
                                A = DArt.RecordSet("A")
                                TolSup = DArt.RecordSet("TOLMAXKG")
                                TolInf = DArt.RecordSet("TOLMINKG")
                            Else
                                DArt.AddNew()
                                DArt.RecordSet("CODINT") = CodMat
                                'DArt.RecordSet("CodExt") = CodMat
                                DArt.RecordSet("NOMBRE") = CLeft(NomMat, 30)
                                DArt.RecordSet("TOLMINKG") = 0
                                DArt.RecordSet("TOLINFPORC") = 0
                                DArt.RecordSet("TOLMAXKG") = 0
                                DArt.RecordSet("TOLSUPPORC") = 0
                                DArt.RecordSet("CODGRPMAT") = 0
                                DArt.RecordSet("TIPO") = "MP"
                                DArt.RecordSet("BASCULA") = 0
                                DArt.RecordSet("TIPOMAT") = 0
                                DArt.RecordSet("A") = "-"
                                DArt.Update(Me)

                                CodMatB = CodMat
                                TipoMat = 0
                                Bascula = 0
                                A = "-"
                                MotoNave = 0

                            End If

                            If Val(PesoMeta) > 0 And CodMat > 0 Then
                                DDatosFor.AddNew()

                                DDatosFor.RecordSet("CODFOR") = CodFormula
                                DDatosFor.RecordSet("CODFORB") = CLeft(CodForB, 15)
                                DDatosFor.RecordSet("CODMATB") = CodMatB.Trim
                                DDatosFor.RecordSet("CODMAT") = CodMat.Trim
                                DDatosFor.RecordSet("NOMMAT") = CLeft(NomMat, 30)
                                DDatosFor.RecordSet("PESOMETA") = Eval(PesoMeta)
                                DDatosFor.RecordSet("PESOMETAB") = Eval(PesoMeta)
                                DDatosFor.RecordSet("PASO") = Paso
                                DDatosFor.RecordSet("LP") = Lp
                                DDatosFor.RecordSet("TIPOMAT") = TipoMat
                                DDatosFor.RecordSet("BASCULA") = Bascula
                                DDatosFor.RecordSet("A") = A
                                DDatosFor.RecordSet("TOLSUP") = Eval(TolSup)
                                DDatosFor.RecordSet("TOLINF") = Eval(TolInf)
                                DDatosFor.RecordSet("MOTONAVE") = MotoNave

                                'Buscamos el material en la matriz de tolvas para actualizarle la tolva
                                DTolvas.Refresh()
                                DTolvas.Find("CODINT='" + CodMat + "'")
                                If Not DTolvas.EOF Then
                                    DDatosFor.RecordSet("TOLVA") = DTolvas.RecordSet("TOLVA")
                                    DDatosFor.RecordSet("BASCULA") = DTolvas.RecordSet("BASCULA")
                                End If

                                DDatosFor.Update(Me)

                            End If

                            'ValorMetaTot = Val(ValorMetaTot) + Val(Valor)
                            Paso += 1

                        Next

                        'Actualizamos pesometa/bache en fórmula
                        DFor.Open("select top 1 * from FORMULAS where CODFOR='" + CodFormula.Trim + "' and LP='" + Lp + "'")
                        If DFor.Count Then
                            DFor.RecordSet("TOTALFOR") = TamBache
                            DFor.Update()
                        End If

                        DNutFor.Open("select * from NUTFOR where CODFOR=" + CodFormula.Trim + " and LP=" + Lp)
                        If DNutFor.Count > 0 Then
                            MsgBox("Ya existe informacion nutricional para la fórmula " + CodFormula.Trim + "versión " + Lp, vbCritical)
                        End If

                        'informacion nutricional
                        i = i + 1
                        Renglon = RenglonAux(i)
                        Posi = InStr(1, Renglon, "Nutrient Name")
                        If Posi > 0 Then
                            'For k = i + 1 To RenglonAux.Length - 1
                            For k As UShort = i + 1 To RenglonAux.Length - 1

                                Renglon = RenglonAux(k)

                                If Trim(Renglon) = "" Then
                                    Exit For
                                End If

                                item = Eval(Renglon)
                                Posi = InStr(1, Renglon, " ")
                                Renglon = Trim(Mid(Renglon, Posi))

                                'Encontrar la primera "," hacia la derecha y luego el primer espacio de ese resultado hacia la izquierda
                                Posi = InStrRev(Renglon, " ", InStr(1, Renglon, ","))

                                NomNut = Trim(Mid(Renglon, 1, Posi))
                                Renglon = Trim(Mid(Renglon, Posi))
                                Posi = InStr(1, Renglon, " ")

                                If Posi > 0 Then
                                    Cantidad = Trim(Mid(Renglon, 1, Posi))
                                Else
                                    Cantidad = Renglon.Trim
                                End If

                                Cantidad = Replace(Cantidad, ".", "")
                                Cantidad = Replace(Cantidad, ",", ".")

                                Posi = InStr(1, Renglon, " ")
                                If Posi > 0 Then
                                    Renglon = Trim(Mid(Renglon, Posi))
                                    unidad = Renglon.Trim
                                Else
                                    unidad = "-"
                                End If

                                DNutFor.AddNew()
                                DNutFor.RecordSet("CODFOR") = CodFormula
                                DNutFor.RecordSet("LP") = Lp
                                DNutFor.RecordSet("ITEM") = item
                                DNutFor.RecordSet("NOMNUT") = NomNut
                                DNutFor.RecordSet("CANTIDAD") = Cantidad
                                DNutFor.RecordSet("UNDS") = unidad
                                DNutFor.Update()
                                i = k

                            Next
                        End If
                    End If
                Next
            Next

            MessageBox.Show(DevuelveEvento(CodEvento.SISTEMA_PROCESOFINALIZADO), "Importación de Fórmulas ChronoSoft", MessageBoxButtons.OK, MessageBoxIcon.Information)

            Formulacion.BActualizar_Click(Nothing, Nothing)
            Formulacion.BBuscaForm_Click(Nothing, Nothing, CodFormula, Lp)
            WriteConfigParametros("VersionFor", Val(ConfigParametros("VersionFor")) + 1)

        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub


    Private Sub BSplitPDF_Click(sender As Object, e As EventArgs) Handles BSplitPDF.Click
        Try

            If TRuta.Text = "" Then
                OpenFile.InitialDirectory = Ruta '"C:\"
            Else
                OpenFile.InitialDirectory = CLeft(TRuta.Text, InStrRev(TRuta.Text, "\"))
            End If

            OpenFile.Filter = "pdf files (*.pdf)|*.pdf"
            OpenFile.FilterIndex = 0
            OpenFile.RestoreDirectory = True

            If (OpenFile.ShowDialog() = DialogResult.OK) Then
                TRuta.Text = OpenFile.FileName
            End If

            ConvertPDFToText(TRuta.Text)

        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub


    Function ConvertPDFToText(ByVal inputFile As String) As Boolean

        ' Abrir el archivo PDF de entrada
        Dim reader As New PdfReader(inputFile)

        Dim totalPaginas As Integer = reader.NumberOfPages
        '***************************************************************************************
        '******          Extraer un numero de paginas                         ******************
        '***************************************************************************************
        'Dim document As New Document()
        'Dim copy As New PdfCopy(document, New System.IO.FileStream(Ruta + "\splitPDF.pdf", System.IO.FileMode.Create))
        'document.Open()

        'Dim inicio As Integer = 1 ' Página inicial del rango
        'Dim fin As Integer = 5 ' Página final del rango

        'For i As Integer = inicio To fin
        '    Dim page As PdfImportedPage = copy.GetImportedPage(reader, i)
        '    copy.AddPage(page)
        'Next

        'document.Close()
        'reader.Close()

        '***************************************************************************************
        '******          Dividir en documentos de a una pagina                ******************
        '***************************************************************************************
        For i As Integer = 1 To totalPaginas
            Dim document As New Document()
            Dim copy As New PdfCopy(document, New System.IO.FileStream(Ruta + "\splitPDF_" + i.ToString + ".pdf", FileMode.Create))
            document.Open()

            Dim page As PdfImportedPage = copy.GetImportedPage(reader, i)
            copy.AddPage(page)

            document.Close()
        Next

        reader.Close()

        MsgBox("Archivo PDF dividido exitosamente.")
        Return True

    End Function

End Class