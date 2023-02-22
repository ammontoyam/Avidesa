Option Explicit On

Imports System

Public Class DescInvent

    Private DArt As AdoSQL
    Private DMovInv As AdoSQL
    Private DTipo As AdoSQL

    Private CodIntArt As String
    Private Cant As Double
    Private TipoInventario As TipoInvent
    Private LoteInv As String
    Private DetalleOper As DetOperacion = DetOperacion.NINGUNO
    Private Ubi As String = "-"
    Private Cond As String = "-"
    Private Unidades As Int32 = 0
    Private PromedioSac As Double = 0
    Private Factura As String = "-"
    Private Observ As String = "-"
    Private Maquilas As String = "-"
    Private User As String = "-"
    Private ContCB As Int64 = 0
    Private Placa As String = ""
    Private IDRow As Int64 = 0
    Private DescInvent As Form


    Public Sub New()
        MyBase.New()
        DescInvent = New Form  'Solo para poder pasar el parametro a la función update para que quede en el log de eventos

        DArt = New AdoSQL("ARTICULOS")
        DMovInv = New AdoSQL("MovInv")
        DTipo = New AdoSQL("TIPOSMAT")

    End Sub

#Region "Tipos de Inventario"
    Public Enum TipoInvent As Integer
        CHRONOS = 1
        FISICO = 2
        UNO = 3
    End Enum
#End Region
#Region "Detalle de Operacion"
    Public Enum DetOperacion As Integer
        NINGUNO = 0
        ENMP = 1         'Entrada MP desde el módulo cortes
        CONSUMO = 2      'Consumos ChronoSoft
        SLPT = 3      'Despacho de  producto terminado
        INGMANUAL = 4  'Ingreso Manual(Det bache), entra consmos, entra bache
        LEEINVENTARIO = 5 'Lee inventario de sistema UNO
        SLMP = 6          'Salidas de MP en los cortes de lote
        ENPT = 7         'Entrada Producto terminado a bodega
        AJUSTEINVENTARIO = 8 'Ajuste de inventario
        ENEM = 9 'Entrada de empaques inventario fisico
        ENET = 10  'Entrada Etiquetas inventario fisico
    End Enum
#End Region




    Public Property CodInt As String
        Get
            CodInt = CodIntArt
        End Get
        Set(ByVal value As String)
            CodIntArt = value
        End Set
    End Property

    Public Property Cantidad As Double
        Get
            Cantidad = Cant
        End Get
        Set(ByVal value As Double)
            Cant = value
        End Set
    End Property

    Public Property TipoInv As TipoInvent
        Get
            TipoInv = TipoInventario
        End Get
        Set(ByVal value As TipoInvent)
            TipoInventario = value
        End Set
    End Property

    Public Property Lote As String
        Get
            Lote = LoteInv
        End Get
        Set(ByVal value As String)
            LoteInv = value
        End Set
    End Property

    Public Property Detalle As DetOperacion
        Get
            Detalle = DetalleOper
        End Get
        Set(ByVal value As DetOperacion)
            DetalleOper = value
        End Set
    End Property

    Public Property Ubicacion As String
        Get
            Ubicacion = Ubi
        End Get
        Set(ByVal value As String)
            Ubi = value
        End Set
    End Property

    Public Property Unds As Int32
        Get
            Unds = Unidades
        End Get
        Set(ByVal value As Int32)
            Unidades = value
        End Set
    End Property

    Public Property PromSac As Double
        Get
            PromSac = PromedioSac
        End Get
        Set(ByVal value As Double)
            PromedioSac = value
        End Set
    End Property

    Public Property FacturaNro As String
        Get
            FacturaNro = Factura
        End Get
        Set(ByVal value As String)
            Factura = value
        End Set
    End Property

    Public Property Observaciones As String
        Get
            Observaciones = Observ
        End Get
        Set(ByVal value As String)
            Observ = value
        End Set
    End Property

    Public Property Maquila As String
        Get
            Maquila = Maquilas
        End Get
        Set(ByVal value As String)
            Maquilas = value
        End Set
    End Property

    Public Property Usuario As String
        Get
            Usuario = User
        End Get
        Set(ByVal value As String)
            User = value
        End Set
    End Property

    Public Property Condicion As String
        Get
            Condicion = Cond
        End Get
        Set(ByVal value As String)
            Cond = value
        End Set
    End Property

    Public Property ContadorCB As Int32
        Get
            ContadorCB = ContCB
        End Get
        Set(ByVal value As Int32)
            ContCB = value
        End Set
    End Property

    Public Property IDRowCB As Int32
        Get
            IDRowCB = IDRow
        End Get
        Set(ByVal value As Int32)
            IDRow = value
        End Set
    End Property

    Public Property PlacaCB As String
        Get
            PlacaCB = Placa
        End Get
        Set(ByVal value As String)
            Placa = value
        End Set
    End Property


    Public Function Inventario() As Boolean
        Try
            Inventario = False

            Dim SaldoIni As Double




            DArt.Open("Select * from ARTICULOS where CODINT='" + CodInt + "'")
            DTipo.Open("Select * from TIPOSMAT")

            If DArt.Count = 0 Then
                'Throw New ArgumentException( _
                '           "El código a no se encuentra registrado en tabla Artículos")
                MsgBox("El código " + CodInt + " no se encuentra registrado en tabla Artículos", MsgBoxStyle.Critical)
                Return False
            End If

            If Cantidad = 0 Then Return False


            'Abrimos el recordset con el codint y lote para buscar el saldo anterior
            ' Si es mov de PT,EM,ET  no se tiene encuenta el LOTE

            Select Case Detalle
                Case DetOperacion.ENEM, DetOperacion.ENET, DetOperacion.SLPT, DetOperacion.ENPT, DetOperacion.AJUSTEINVENTARIO
                    'Abrimos el recordset sin tener en cuenta el lote
                    DMovInv.Open("Select * from MovInv where CODINT='" + CodInt +
                                     "' and TIPOMOV='" + TipoInv.ToString + "' order by ID desc")
                Case Else
                    DMovInv.Open("Select * from MovInv where CODINT='" + CodInt + "' and LOTE='" +
                                    Lote + "' and TIPOMOV='" + TipoInv.ToString + "' order by ID desc")
            End Select


            SaldoIni = DArt.RecordSet("INVCHRONOS")
            If DMovInv.Count > 0 Then
                SaldoIni = DMovInv.RecordSet("SALDOFIN")
            End If

            'Creamos un registro en la tabla DetInventarios para tener historico de movimientos

            DMovInv.Open("Select * from MOVINV where ID=0")

            DMovInv.AddNew()
            DMovInv.RecordSet("TIPOMOV") = TipoInv.ToString
            DMovInv.RecordSet("DETALLE") = Detalle.ToString.Trim
            DMovInv.RecordSet("CODINT") = DArt.RecordSet("CODINT")
            DMovInv.RecordSet("NOMBRE") = DArt.RecordSet("NOMBRE")
            DMovInv.RecordSet("SALDOINI") = SaldoIni
            DMovInv.RecordSet("SALDOFIN") = DMovInv.RecordSet("SALDOINI") + Cantidad
            DMovInv.RecordSet("CONTADORCB") = ContadorCB
            DMovInv.RecordSet("IDROWCB") = IDRowCB
            DMovInv.RecordSet("PLACA") = PlacaCB

            'Buscamos en la tabla TIPOSMAT el tipo para almacenarlo en la tabla MOVINV
            DTipo.Find("TIPOMAT=" + DArt.RecordSet("TIPOMAT").ToString)
            If Not DTipo.EOF And DArt.RecordSet("TIPOMAT") > 0 Then
                DMovInv.RecordSet("TIPO") = DTipo.RecordSet("TIPO")
            Else
                DMovInv.RecordSet("TIPO") = DArt.RecordSet("TIPO")
            End If

            'Si el saldofin es negativo para el los articulos<> de materia prima no se puede registrar el
            'movimiento del inventario

            If DMovInv.RecordSet("TIPO") <> "MP" And DMovInv.RecordSet("DETALLE") = "SLPT" Then
                If DMovInv.RecordSet("SALDOFIN") < 0 Then
                    'MsgBox("No se puede realizar el movimiento, se crearían saldos negativos para el artículo", MsgBoxStyle.Critical)
                    Return False
                End If
            End If


            Select Case TipoInv
                Case 1 'Inventario ChronoSoft
                    DArt.RecordSet("INVCHRONOS") = DMovInv.RecordSet("SALDOFIN")
                Case 2

                    DMovInv.RecordSet("UNDS") = Unds
                    'Solo si se hace un ajuste físico se pueden ajustar los kilos en la tabla de articulos
                    If Detalle = DetOperacion.AJUSTEINVENTARIO Then
                        DArt.RecordSet("INVFISICO") += Cantidad
                    End If
                Case 3
                    DArt.RecordSet("INVUNO") = Cantidad
                    DMovInv.RecordSet("SALDOFIN") = Cantidad

                    'Si es inventario UNO se actualiza la fecha de la tabla FECHASCIERRE para saber cual fue la última fecha
                    'de importación del ARCHIVO DE UNO

                    If ReadFechasCierre(DMovInv.RecordSet("TIPO"), ClaseFecha.UNO) <> Format(Now, "yyyy/MM/dd HH:mm") Then
                        WriteFechasCierre(DMovInv.RecordSet("TIPO"), Format(Now, "yyyy/MM/dd HH:mm"), ClaseFecha.UNO)
                    End If

            End Select

            ' DMovInv.RecordSet("CANTIDAD") = Cantidad

            If Cantidad > 0 Then
                DMovInv.RecordSet("ENTRA") = Cantidad
            Else
                DMovInv.RecordSet("SALE") = Cantidad
            End If

            DMovInv.RecordSet("FECHA") = Format(Now, "yyyy/MM/dd HH:mm:ss")
            DMovInv.RecordSet("LOTE") = Lote
            DMovInv.RecordSet("CODUBI") = Ubicacion
            DMovInv.RecordSet("PROMSAC") = PromSac


            DMovInv.RecordSet("UNDS") = Unds
            DMovInv.RecordSet("FACTURANRO") = FacturaNro
            DMovInv.RecordSet("OBSERVACIONES") = CLeft(Observaciones, 50)
            DMovInv.RecordSet("CODMAQ") = Maquila
            DMovInv.RecordSet("USUARIO") = Usuario
            DMovInv.RecordSet("LINEA") = DArt.RecordSet("LINEA")

            ' If DArt.RecordSet("TIPO") = "PT" Then DMovInv.RecordSet("UNDS") = Cantidad \ DArt.RecordSet("PRESKG")

            DMovInv.Update(DescInvent)
            DArt.Update()

            Evento("Actualiza Inventario " + TipoInv.ToString + " Cantidad " + Cantidad.ToString + " Articulo " + CodInt.ToString)
            Return True

        Catch ex As Exception
            MsgError(ex)
            Return False
        End Try
    End Function

End Class
