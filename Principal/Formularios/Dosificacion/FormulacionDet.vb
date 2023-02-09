Option Explicit On

Imports System.Data.Common
Imports System.Data
Imports System.Windows.Forms

Public Class FormulacionDet
    Private DFor As AdoSQL
    Private DDatosFor As AdoSQL
    Private DArt As AdoSQL
    Private DVarios As AdoSQL
    Private DBasculas As AdoSQL
    Private DTolvas As AdoSQL
    Private DFormFiltros As AdoSQL
    Private Campos() As String
    Private Fila As Int32
    Private ModCrea As String
    Private TipoMatTolva As String
    Private BBascula As ArrayControles(Of Button)
    Private RBFiltro As ArrayControles(Of RadioButton)
    Private FormLoad As Boolean
    Private TolInfAux As Single
    Private TolSupAux As Single
    Private IDsBorrarDatosFor As String = ""
    Private GuardarCambios As Boolean = False
    Private ValorMaxSalCurp As String
    Private ValorMaxMycoCurp As String
    Private CodAguaHC As String
    Private PorcOpticurpAdicionar As Single
    Private InclusionMin(100) As Single
    Private DGPesoMPAnt As UShort
    Private CodEspecie As String
    Private CodGrpFor As String
    Private BascLiquidos(3) As Integer
    Private CodMelaza As String


    Public Sub Formulas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try

            If FormLoad Then Return

            DFor = New AdoSQL("Formulas")
            DDatosFor = New AdoSQL("DatosFor")
            DArt = New AdoSQL("ARTICULOS")
            DVarios = New AdoSQL("VARIOS")
            DBasculas = New AdoSQL("Basculas")
            DTolvas = New AdoSQL("Tolvas")
            DFormFiltros = New AdoSQL("Filtros")
            Dim i As Int16 = 0
            DBasculas.Open("Select * from Basculas where A='A' order by BASCULA") ' Para llenar el array de valores de inclusión mínima de basculas automáticas
            For Each Fila As DataRow In DBasculas.Rows
                InclusionMin(Fila("BASCULA")) = Fila("INCLUSIONMIN")
                If Fila("DESCRIPCION").ToString.Contains("Líquidos") Then
                    BascLiquidos(i) = Fila("BASCULA")
                    i += 1
                End If
            Next

            DArt.Open("select * from ARTICULOS where TIPO='MP'")
            DBasculas.Open("Select * from Basculas where HABILITADA=1 order by BASCULA")
            DTolvas.Open("Select * from TOLVAS where PROCESO='DOSIFICACION'")
            DFormFiltros.Open("Select * from FORMFILTROS where HABILITADO=1 order by POSICION")

            GBVehiculo.Visible = True
            DGMat.Height = 220

            If Funcion_FuncionesPlantaPremezclas = False Then
                DGFor.Columns.Remove("SACOS")
                DGFor.Columns.Remove("TARA")
                DGFor.Columns.Remove("PESOMETAB")
                DGFor.Columns.Remove("TIPOVEHICULO")
                GBVehiculo.Visible = False
                GBModTamBache.Visible = False
                BDivideForm.Enabled = False
                GBFiltro.Width = 432
                DGMat.Height = 396
            Else
                'Se eliminan las colomnas del datagrid que no se utilizan
                DGFor.Columns("TOLVA").Visible = False
                DGFor.Columns("TOLSUP").Visible = False
                DGFor.Columns("TOLINF").Visible = False
                DGFor.Columns("NOMTOLVA").Visible = False
                DGFor.Columns("A2").Visible = False
                GBFiltro.Width = 432
                DArt.Open("Select * from ARTICULOS where TIPOVEHICULO=1 order by NOMBRE")
                LLenaComboBox(CBNomVehiculo, DArt.DataTable, "NOMBRE")
                'Se vuelve a cargar la tabla de materias primas
                DArt.Open("select * from ARTICULOS where TIPO='MP' or TIPO='PT'")
            End If

            If Funcion_ManejaOpticurp Then
                ValorMaxSalCurp = ConfigParametros("ValorMaxSalCurp")
                ValorMaxMycoCurp = ConfigParametros("ValorMaxMycoCurp")
                CodAguaHC = ConfigParametros("CodigoAguaHC")
                PorcOpticurpAdicionar = Val(ConfigParametros("PorcOpticurpAdicionar"))
            End If

            mnParamFylax.Enabled = False
            If Funcion_ManejaFylax Then mnParamFylax.Enabled = True

            CodMelaza = ConfigParametros("CodigoMelaza")

            'Se crean y posicionan los controles de las básculas 
            Dim Y As Integer = 0

            For Each Recordset As DataRow In DBasculas.Rows

                If Y > 14 Then Exit For

                Dim B As Button = New Button()
                With BBas
                    B.Name = "BBascula" + Recordset("BASCULA").ToString
                    B.Location = New Point(8, 20 + Y * 36)
                    B.Size = .Size
                End With
                B.Text = Recordset("TEXTOBOTON")
                ToolTip1.SetToolTip(B, Recordset("DESCRIPCION"))
                B.BackColor = Color.SteelBlue
                B.Parent = GrpBasc
                Y += 1
            Next


            BBascula = New ArrayControles(Of Button)("BBascula", Me)

            Dim PosY As Integer = 20
            For Each Boton As Button In BBascula.Values
                AddHandler Boton.Click, AddressOf BBascula_Click
            Next

            'Se crean y posicionan los botones de los filtros
            FiltrosFormulacion(Me.GBFiltro, OPTodos, 8, 16, Me)

            RBFiltro = New ArrayControles(Of RadioButton)("RBFiltro", Me)

            For Each RB As RadioButton In RBFiltro.Values
                AddHandler RB.Click, AddressOf RBFiltro_Click
            Next


            AsignaDataGrid(DGMat, DArt.DataTable, True)


            Campos = {"CodInt@Cód.Int.", "CodExt@Cód.Ext.", "NOMBRE@Nombre"}

            Campos = AsignaItemsCB(Campos, CBBuscar, DArt.DataTable)

            TextNum(TCantidad, True)
            'If DRUsuario("CALIDAD") Then
            If ValidaPermiso("Calidad") Then
            Else
                TEstado.Enabled = False
                TCodEspecie.Enabled = False
                TNomCodPremezcla.ReadOnly = True
                TNomEspecie.ReadOnly = True
                TNomGrpForm.ReadOnly = True
                TCodGrpFor.Enabled = False
                TCodPremezcla.ReadOnly = True
                ChManejaPx.Enabled = False
                TCodEstablecimiento.ReadOnly = True
            End If

            OPTodos.Checked = True
            OPTodos_Click(Nothing, Nothing)

            FormLoad = True
        Catch ex As Exception
            MsgError(ex)
        End Try

    End Sub


    Private Sub Buscar()

        For Each Filasel As DataGridViewRow In DGMat.Rows
            If Filasel.Cells("CODINT").Value Is Nothing _
                OrElse Filasel.Cells Is Nothing Then
                Continue For
            End If
            'MsgBox(filas("NOMBRE").ToString)
            If TCodInt.Text = Filasel.Cells("CODINT").Value.ToString Then

                DGMat.Rows(Filasel.Index).Selected = True

                DGMat.FirstDisplayedScrollingRowIndex = Filasel.Index
                Fila = Filasel.Index
                DGMat.CurrentCell = DGMat(0, Fila)

                'MsgBox(Filasel.Index)
                ' Mostar(Filasel.Index)

                Exit For
            End If
        Next

    End Sub


    Private Sub TCodMat_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        If e.KeyCode = Keys.Enter Then Buscar()
    End Sub

    Private Sub FAgregarFilaDGFor(Optional ByVal A As String = "", Optional Posicion As Integer = 0, Optional ByVal TaraTot As Single = 0, Optional ByVal Sacos As Int16 = 0, Optional ByVal Basc As Int16 = 0, Optional PesoMeta As Single = 0)
        Try
            If TCodInt.Text = "" OrElse TNombre.Text = "" Then
                Return
            End If

            If ModCrea = "EDITAR" Then
                DGFor.Rows(DGFor.CurrentRow.Index).Cells("CodMat").Value = TCodInt.Text
                DGFor.Rows(DGFor.CurrentRow.Index).Cells("NomMat").Value = TNombre.Text
                DGFor.Rows(DGFor.CurrentRow.Index).Cells("A").Value = "-"
                DGFor.Rows(DGFor.CurrentRow.Index).Cells("A2").Value = "-"
                If CBBuscar.Text = "" Then Return
                TBuscar.Text = ""
                TBuscar_KeyUp(Nothing, Nothing)
                TBuscar.Focus()
                Exit Sub
            End If

            If ModCrea = "NUEVO" Then
                Dim PosInsert As Int32 = 0

                If DGFor.RowCount = 0 Then
                    PosInsert = 0
                    DGFor.Rows.Add()
                Else
                    If DGFor.CurrentRow Is Nothing Then
                        PosInsert = DGFor.Rows.Count
                    Else
                        PosInsert = DGFor.CurrentRow.Index + 1
                    End If

                    If Posicion > 0 Then
                        PosInsert = Posicion
                    End If
                    DGFor.Rows.Insert(PosInsert)
                End If

                DGFor.Rows(PosInsert).Cells("Paso").Value = PosInsert
                DGFor.Rows(PosInsert).Cells("CodMat").Value = TCodInt.Text
                DGFor.Rows(PosInsert).Cells("NomMat").Value = TNombre.Text
                DGFor.Rows(PosInsert).Cells("NomTolva").Value = "-"
                DGFor.Rows(PosInsert).Cells("A2").Value = "-"
                DGFor.Rows(PosInsert).Cells("PesoMeta").Value = Format(Eval(TCantidad.Text), "######0.000")
                If PesoMeta > 0 Then DGFor.Rows(PosInsert).Cells("PesoMeta").Value = Format(PesoMeta, "######0.000")

                For h As Integer = 0 To DGFor.RowCount - 1
                    DGFor.Rows(h).Cells(0).Value = h + 1
                Next

                DGFor.Rows(PosInsert).Selected = True
                DGFor.FirstDisplayedScrollingRowIndex = PosInsert
                DGFor.CurrentCell = DGFor(0, PosInsert)


                If Funcion_ManejaVehiculo = False Then
                    DVarios.Open("Select * from ARTICULOS where TIPO='MP' and CODINT='" + TCodInt.Text + "'")
                Else
                    DVarios.Open("Select * from ARTICULOS where (TIPO='MP' or TIPO='PT') and CODINT='" + TCodInt.Text + "'")
                End If


                If DVarios.Count > 0 Then
                    DGFor.Rows(PosInsert).Cells("Bascula").Value = DVarios.RecordSet("BASCULA")
                    DGFor.Rows(PosInsert).Cells("A").Value = DVarios.RecordSet("A")
                    DGFor.Rows(PosInsert).Cells("TIPOMAT").Value = DVarios.RecordSet("TIPOMAT")
                    If A <> "" Then DGFor.Rows(PosInsert).Cells("A").Value = A
                    If A = "PR" Then DGFor.Rows(PosInsert).Cells("TIPOMAT").Value = 7
                    DGFor.Rows(PosInsert).Cells("NOMMAT").Value = DVarios.RecordSet("NOMBRE")
                    If Funcion_ManejaVehiculo = False Then
                        'Si el material es automa
                        DGFor.Rows(PosInsert).Cells("TOLVA").Value = 0
                        If DVarios.RecordSet("A") = "A" Then
                            DTolvas.Refresh()
                            DTolvas.Find("CODINT='" + TCodInt.Text + "'")
                            If Not DTolvas.EOF Then
                                DGFor.Rows(PosInsert).Cells("TOLVA").Value = DTolvas.RecordSet("TOLVA")
                                DGFor.Rows(PosInsert).Cells("NOMTOLVA").Value = DTolvas.RecordSet("NOMTOLVA")
                            End If
                        End If

                    End If

                Else
                    DGFor.Rows(PosInsert).Cells("Bascula").Value = 0
                End If

                If Funcion_ManejaVehiculo Then
                    DGFor.Rows(PosInsert).Cells("TIPOVEHICULO").Value = DVarios.RecordSet("TIPOVEHICULO")
                    DGFor.Rows(PosInsert).Cells("Sacos").Value = Sacos
                    DGFor.Rows(PosInsert).Cells("TARA").Value = TaraTot
                    If Basc > 0 Then
                        DGFor.Rows(PosInsert).Cells("Bascula").Value = Basc
                        DGFor.Rows(PosInsert).Cells("TIPOMAT").Value = 6
                        DGFor.Rows(PosInsert).Cells("A").Value = "PF"
                    End If

                    If A <> "-" Then
                        DGFor.Rows(PosInsert).Cells("A").Value = A
                        DGFor.Rows(PosInsert).Cells("TIPOMAT").Value = 5
                    End If

                    If Funcion_FuncionesPlantaPremezclas And A = "PF" Then
                        DGFor.Rows(PosInsert).Cells("Bascula").Value = 0
                        DGFor.Rows(PosInsert).Cells("TIPOMAT").Value = 6
                    End If

                End If

                ModCrea = "EDITAR"
                FrmIngAdcFor.Visible = False
                If CBBuscar.Text <> "" Then
                    TBuscar.Text = ""
                    TBuscar_KeyUp(Nothing, Nothing)
                    TBuscar.Focus()
                End If
            End If

            TCodInt.Text = ""
            TNombre.Text = ""
            TCantidad.Text = ""

            GuardarCambios = True
        Catch ex As Exception
            MsgError(ex)
        End Try

    End Sub




    Private Sub BGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BGuardar.Click

        Dim FormOk As Boolean = True
        Dim Datos As String = ""
        Dim ID As Int64 = 0
        Dim Paso As Int16 = 0
        Dim PorcAdicFylax As Single = 0
        Dim PorcAdicFysal As Single = 0
        Try
            If ValidaPermiso("Formulas_Editar, Formulas_EditarBasculas") Then
            Else
                MsgBox(DevuelveEvento(CodEvento.USUARIO_PERMISODENEGADO), MsgBoxStyle.Information)
                Exit Sub
            End If

            If ChManejaPx.Checked And TCodPremezcla.Text = "" Then
                MsgBox(DevuelveEvento(CodEvento.SISTEMA_FALTACAMPO, " código Premezcla"), vbCritical)
                Return
            End If

            If TCodEspecie.Text = "" Then
                MsgBox(DevuelveEvento(CodEvento.SISTEMA_FALTACAMPO, " código especie"), vbCritical)
                Return
            End If

            If TCodGrpFor.Text = "" Then
                MsgBox(DevuelveEvento(CodEvento.SISTEMA_FALTACAMPO, " código grupo fórmula"), vbCritical)
                Return
            End If

            OPTodos_Click(Nothing, Nothing)

            BVerificar_Click(Nothing, Nothing, FormOk)

            If FormOk = False Then
                MsgBox(DevuelveEvento(CodEvento.FORMULA_GUARDARERROR), MsgBoxStyle.Information)
                Exit Sub
            End If

            'Se realiza el borrado de los ingredientes que se eliminaron en el DGFor
            If IDsBorrarDatosFor.Length > 0 Then
                IDsBorrarDatosFor = CLeft(IDsBorrarDatosFor, InStrRev(IDsBorrarDatosFor, ",") - 1)
                DVarios.Delete("delete from DATOSFOR where ID IN(" + IDsBorrarDatosFor + ")", Me)
                IDsBorrarDatosFor = ""
            End If

            DFor.Open("select * from FORMULAS where CODFOR='" + TCodFor.Text + "' and LP='" + TLP.Text + "'")

            DDatosFor.Open("select * from DATOSFOR where CODFOR='" + TCodFor.Text + "' and LP='" + TLP.Text + "'")
            For Each RecordSet In DDatosFor.Rows
                Datos += RecordSet("CODMAT").ToString + " " + RecordSet("NOMMAT").ToString + " " + RecordSet("PESOMETA").ToString + " " + RecordSet("BASCULA").ToString + vbCrLf
            Next

            ''Se realiza el borrado de los ingredientes que se eliminaron en el DGFor
            'If IDsBorrarDatosFor.Length > 0 Then
            '    IDsBorrarDatosFor = CLeft(IDsBorrarDatosFor, InStrRev(IDsBorrarDatosFor, ",") - 1)
            '    DVarios.Delete("delete from DATOSFOR where ID IN(" + IDsBorrarDatosFor + ")", Me)
            '    IDsBorrarDatosFor = ""
            'End If


            If DFor.Count = 0 Then
                DFor.AddNew()
                DFor.RecordSet("TMSECA") = ConfigParametros("TiempoMezclaSeca")
                DFor.RecordSet("TMHUMEDA") = ConfigParametros("TiempoMezclaHumeda")
                Evento("Crea Fórmula " + TCodFor.Text + " " + TNomFor.Text + " LP " + TLP.Text)
            Else
                Evento("Modifica Fórmula " + TCodFor.Text + vbCrLf + Datos)
            End If

            DFor.RecordSet("CODFOR") = TCodFor.Text
            DFor.RecordSet("CODFORB") = TCodForB.Text
            DFor.RecordSet("NOMFOR") = TNomFor.Text
            DFor.RecordSet("TOTALFOR") = Eval(TSumaIng.Text)
            DFor.RecordSet("CODESPECIE") = Mid(TCodEspecie.Text.Trim.ToUpper, 1, 5).Trim
            DFor.RecordSet("CODGRPFOR") = Mid(TCodGrpFor.Text.Trim.ToUpper, 1, 5).Trim
            DFor.RecordSet("LP") = TLP.Text
            DFor.RecordSet("MANEJAPX") = ChManejaPx.Checked
            If TEstado.Enabled Then DFor.RecordSet("ESTADO") = TEstado.Text
            DFor.RecordSet("CODPREMEZCLA") = TCodPremezcla.Text
            DFor.RecordSet("CODESTABLECIMIENTO") = TCodEstablecimiento.Text

            If Funcion_ManejaVehiculo Then
                DFor.RecordSet("PESOFORMINI") = Val(TPesoPaq.Text)
                DFor.RecordSet("PESOPAQ") = Val(TPesoPaq2.Text)
                DFor.RecordSet("NUMPAQ") = Val(TNumPaq.Text)
                DFor.RecordSet("DOSIS") = TDosis.Text
                DFor.RecordSet("NUMPAQXBACHE") = Val(TPaqxBache.Text)
            End If

            DFor.Update(Me)


            Datos = ""

            For Each Filasel As DataGridViewRow In DGFor.Rows

                'Sacamos el ID de la tabla, si tiene un valor es porque se está editando un registro, si no tiene es porque el registro es
                'nuevo
                ID = 0
                If Not Filasel.Cells("ID").Value Is Nothing Then
                    ID = Filasel.Cells("ID").Value
                End If

                If Filasel.Cells("CODMAT").Value Is Nothing _
                    OrElse Filasel.Cells Is Nothing Then
                    Continue For
                End If

                DDatosFor.Find("ID=" + ID.ToString)

                If DDatosFor.EOF Then
                    DDatosFor.AddNew()
                End If

                DDatosFor.RecordSet("CODMAT") = Filasel.Cells("CODMAT").Value.ToString
                DDatosFor.RecordSet("NOMMAT") = Filasel.Cells("NOMMAT").Value.ToString.ToUpper
                DDatosFor.RecordSet("PESOMETA") = Format(Eval(Filasel.Cells("PESOMETA").Value), "0.000")
                DDatosFor.RecordSet("BASCULA") = Filasel.Cells("BASCULA").Value.ToString
                DDatosFor.RecordSet("PASO") = Filasel.Cells("PASO").Value.ToString
                Paso = DDatosFor.RecordSet("PASO")
                DDatosFor.RecordSet("A") = Filasel.Cells("A").Value.ToString

                'Se revisa si se maneja fylax y fysal actualizar el porcentaje de estos ingredientes en la fórmula

                If Funcion_ManejaFylax Then
                    If DDatosFor.RecordSet("A") = "FX" AndAlso Eval(TSumaIng.Text) > 0 Then
                        Dim PesoReproceso As Single = 0
                        'Para la planta funza, se debe quitar el reproceso de la fórmula
                        If Planta.Contains("FUNZA") Then
                            DVarios.Open("Select sum(PESOMETA) AS PESOREPROCESO from DATOSFOR where NOMMAT LIKE '%REPROCESO%' and CODFOR='" + TCodFor.Text + "' and LP='" + TLP.Text + "'")
                            If DVarios.Count > 0 AndAlso Not IsDBNull(DVarios.RecordSet("PESOREPROCESO")) Then
                                PesoReproceso = DVarios.RecordSet("PESOREPROCESO")
                            End If
                        End If

                        PorcAdicFylax = DDatosFor.RecordSet("PESOMETA") / (Eval(TSumaIng.Text) - Math.Round(PesoReproceso, 1)) * 100
                        DFor.Open("Update FORMULAS set PORCADICFILAX=" + PorcAdicFylax.ToString + " WHERE CODFOR='" + TCodFor.Text + "' and LP='" + TLP.Text + "'")
                    End If
                End If

                If Funcion_ManejaFysal Then
                    If DDatosFor.RecordSet("A") = "FS" AndAlso Eval(TSumaIng.Text) > 0 Then
                        PorcAdicFysal = DDatosFor.RecordSet("PESOMETA") / Eval(TSumaIng.Text) * 100
                        DFor.Open("Update FORMULAS set PORCADICFYSAL=" + PorcAdicFysal.ToString + " WHERE CODFOR='" + TCodFor.Text + "' and LP='" + TLP.Text + "'")
                    End If
                End If

                If Not Funcion_FuncionesPlantaPremezclas Then
                    DDatosFor.RecordSet("A2") = Filasel.Cells("A2").Value.ToString
                    DDatosFor.RecordSet("NOMTOLVA") = Filasel.Cells("NOMTOLVA").Value.ToString
                    DDatosFor.RecordSet("TOLVA") = Eval(Filasel.Cells("TOLVA").Value.ToString)
                End If
                DDatosFor.RecordSet("TIPOMAT") = Filasel.Cells("TIPOMAT").Value.ToString
                DDatosFor.RecordSet("CODFOR") = TCodFor.Text.ToString
                DDatosFor.RecordSet("CODFORB") = TCodForB.Text.ToString
                DDatosFor.RecordSet("LP") = TLP.Text.ToString


                If Funcion_ManejaVehiculo Then
                    If Eval(TSumaIng.Text) > 0 Then
                        DDatosFor.RecordSet("PESOMETAB") = DDatosFor.RecordSet("PESOMETA") / Eval(TSumaIng.Text) * 100
                        DDatosFor.RecordSet("TIPOVEHICULO") = Filasel.Cells("TIPOVEHICULO").Value
                        DDatosFor.RecordSet("SACOS") = Filasel.Cells("SACOS").Value.ToString
                        DDatosFor.RecordSet("TARA") = Eval(Filasel.Cells("TARA").Value.ToString)
                    End If
                End If

                DArt.Open("select * from ARTICULOS where CODINT='" + DDatosFor.RecordSet("CODMAT") + "'")
                If DArt.Count > 0 Then
                    DDatosFor.RecordSet("CODMATB") = DArt.RecordSet("CODEXT")
                    DArt.RecordSet("TIPOMAT") = DDatosFor.RecordSet("TIPOMAT")
                    DArt.RecordSet("A") = DDatosFor.RecordSet("A")
                    DArt.RecordSet("BASCULA") = DDatosFor.RecordSet("BASCULA")
                    DDatosFor.RecordSet("TOLINF") = DArt.RecordSet("TolMinKg")
                    DDatosFor.RecordSet("TOLSUP") = DArt.RecordSet("TolMaxKg")

                    If Funcion_ManejaVehiculo Then
                        DArt.RecordSet("TARA") = DDatosFor.RecordSet("TARA")
                    End If

                    'Calculamos tolerancias de acuerdo a porcentajes, si es menor que la tolerancia minima, ponemos la minima, si es mayor que la tolerancia 
                    'maxima ponemos la maxima

                    TolInfAux = 0
                    TolSupAux = 0

                    If DArt.RecordSet("TOLINFPORC") > 0 Then
                        TolInfAux = Math.Round(DDatosFor.RecordSet("PESOMETA") * DArt.RecordSet("TOLINFPORC") / 100, 1)
                    End If

                    If DArt.RecordSet("TOLSUPPORC") > 0 Then
                        TolSupAux = Math.Round(DDatosFor.RecordSet("PESOMETA") * DArt.RecordSet("TOLSUPPORC") / 100, 1)
                    End If

                    If TolSupAux > 0 Then
                        DDatosFor.RecordSet("TOLSUP") = TolSupAux
                        If TolSupAux > DArt.RecordSet("TolMaxKg") Then
                            DDatosFor.RecordSet("TOLSUP") = DArt.RecordSet("TolMaxKg")
                        End If
                    End If

                    If TolInfAux > 0 Then
                        DDatosFor.RecordSet("TOLINF") = TolInfAux
                        If TolInfAux > DArt.RecordSet("TolMinKg") Then
                            DDatosFor.RecordSet("TOLINF") = DArt.RecordSet("TolMinKg")
                        End If
                    End If

                End If

                DArt.Update()
                DDatosFor.Update(Me)

                Datos += Filasel.Cells("CODMAT").Value.ToString + " " + Filasel.Cells("NOMMAT").Value.ToString + " " + Filasel.Cells("PESOMETA").Value.ToString + " " + Filasel.Cells("BASCULA").Value.ToString + vbCrLf
            Next


            'Agrega un ingrediente con la suma de los ingredientes por bandeja

            If Funcion_MaterialesXBandeja Then
                For i = 26 To 29
                    If i = 27 Then i = 28
                    DDatosFor.Delete("delete from DATOSFOR where CODFOR='" + TCodFor.Text + "' and LP='" + TLP.Text + "' and A='A' and CODMAT='" + i.ToString.PadRight(6, Chr(48)) + "'")
                    DVarios.Open("select SUM(PesoMeta) as SUMBANDEJA, MAX(BASCULA) AS BASCULA, MAX(TOLVA) AS TOLVA  from DATOSFOR where CODFOR='" + TCodFor.Text + "' and LP='" + TLP.Text + "' AND NOMTOLVA='B" + i.ToString + "'")
                    DDatosFor.Open("Select * from DATOSFOR where CODFOR='" + TCodFor.Text + "' and LP='" + TLP.Text + "'")

                    If DVarios.Count = 1 AndAlso Not IsDBNull(DVarios.RecordSet("SUMBANDEJA")) Then
                        Paso += 1
                        FAgregarIng_Click(50, "A", DVarios.RecordSet("SUMBANDEJA"), i.ToString.PadRight(6, Chr(48)), Paso, DVarios.RecordSet("BASCULA"), DVarios.RecordSet("TOLVA"))
                    End If
                Next
            End If

            'Se actualiza nuevamente el peso de la formula total con el peso de de la tabla datosfor por seguridad
            'donde tipomat<20 porque en girardota se hace una suma de materiales por bandeja y se pone con tipomat=50
            If ChManejaPx.Checked Then
                DDatosFor.Open("Select SUM(PESOMETA) AS SUMPESOMETA FROM DATOSFOR where TIPOMAT<20 and CODFOR='" + TCodFor.Text + "' and LP='" + TLP.Text + "' and A<>'PR'")
            Else
                DDatosFor.Open("Select SUM(PESOMETA) AS SUMPESOMETA FROM DATOSFOR where TIPOMAT<20 and CODFOR='" + TCodFor.Text + "' and LP='" + TLP.Text + "'")
            End If


            If DDatosFor.Count AndAlso Not IsDBNull(DDatosFor.RecordSet("SUMPESOMETA")) Then
                DFor.Open("UPDATE FORMULAS SET TOTALFOR=" + Math.Round(DDatosFor.RecordSet("SUMPESOMETA"), 3).ToString + " where CODFOR='" + TCodFor.Text + "' and LP='" + TLP.Text + "'")
                Evento("Actualiza TOTALFOR: " + Math.Round(DDatosFor.RecordSet("SUMPESOMETA"), 3).ToString + " CODFOR:" + TCodFor.Text + "' and LP:" + TLP.Text)
            End If


            Evento(Datos)
            GuardarCambios = False
            BActualizar_Click(Nothing, Nothing)

            MsgBox(DevuelveEvento(CodEvento.SISTEMA_PROCESOFINALIZADO), MsgBoxStyle.Information)

        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub BSubePaso_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BSubePaso.Click
        Try
            Dim Ran() As String
            Dim Rac() As String
            Dim i As Integer

            If DGFor.CurrentRow Is Nothing Then Return

            i = DGFor.CurrentRow.Index
            If i = 0 Then Exit Sub
            ReDim Ran(DGFor.ColumnCount)
            ReDim Rac(DGFor.ColumnCount)


            For t As Integer = 1 To Me.DGFor.ColumnCount - 1
                Rac(t) = Me.DGFor.Rows(i).Cells(t).Value.ToString
                Ran(t) = Me.DGFor.Rows(i - 1).Cells(t).Value.ToString
                Me.DGFor(t, i).Value = Ran(t).ToString
                Me.DGFor(t, i - 1).Value = Rac(t).ToString
            Next
            DGFor.Rows(i - 1).Selected = True
            DGFor.FirstDisplayedScrollingRowIndex = i - 1
            DGFor.CurrentCell = DGFor(0, i - 1)

            GuardarCambios = True

        Catch ex As ArgumentOutOfRangeException
        Catch ex As NullReferenceException
        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub BBajaPaso_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BBajaPaso.Click
        Try
            Dim Ran() As String
            Dim Rac() As String
            Dim i As Integer

            If DGFor.CurrentRow Is Nothing Then Return

            i = DGFor.CurrentRow.Index
            If i = DGFor.RowCount - 1 Then Exit Sub
            ReDim Ran(DGFor.ColumnCount)
            ReDim Rac(DGFor.ColumnCount)


            For t As Integer = 1 To Me.DGFor.ColumnCount - 1
                Rac(t) = Me.DGFor.Rows(i).Cells(t).Value.ToString
                Ran(t) = Me.DGFor.Rows(i + 1).Cells(t).Value.ToString
                Me.DGFor(t, i).Value = Ran(t).ToString
                Me.DGFor(t, i + 1).Value = Rac(t).ToString
            Next
            DGFor.Rows(i + 1).Selected = True
            DGFor.FirstDisplayedScrollingRowIndex = i + 1
            DGFor.CurrentCell = DGFor(0, i + 1)
            GuardarCambios = True

        Catch ex As ArgumentOutOfRangeException
        Catch ex As NullReferenceException
        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub


    Private Sub BEditar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BEditar.Click
        Try
            'If DRUsuario("FormMod") Or DRUsuario("FormModDosif") Then
            If ValidaPermiso("Formulas_Editar, Formulas_EditarBasculas") Then
            Else
                MsgBox(DevuelveEvento(CodEvento.USUARIO_PERMISODENEGADO), MsgBoxStyle.Information)
                Exit Sub
            End If
            PanPrincipal.Enabled = True
            If DGFor.RowCount = 0 Then Exit Sub
            FrmFor.Enabled = False
            FrmIngAdcFor.Visible = False
            BAgregar.Enabled = True
            ModCrea = "EDITAR"
        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub DGMat_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGMat.CellClick, DGFor.CellClick
        Try
            If DGMat Is Nothing Then Return
            If DGMat.CurrentRow Is Nothing Then Return
            TCodInt.Text = DGMat.Rows(DGMat.CurrentRow.Index).Cells("DGMAT_CODINT").Value.ToString.Trim
            TNombre.Text = DGMat.Rows(DGMat.CurrentRow.Index).Cells("DGMAT_NOMBRE").Value.ToString.Trim
        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub BSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnSalir.Click, BSalir.Click
        Try
            'Se revisa si se han realizado cambios en la formulacion y se alerta al operario para
            'que no salga sin guardar
            If GuardarCambios Then
                Resp = MsgBox(DevuelveEvento(CodEvento.SISTEMA_GUARDARCAMBIOS), vbYesNo + vbInformation)
                If Resp = vbYes Then
                    BGuardar_Click(Nothing, Nothing)
                End If
            End If

            GuardarCambios = False
            IDsBorrarDatosFor = ""
            If DGFor.RowCount <> 0 And Eval(TCodFor.Text) <> 0 Then
                Formulacion.BActualizar_Click(Nothing, Nothing)
                Formulacion.BBuscaForm_Click(Nothing, Nothing, TCodFor.Text, TLP.Text)
            End If
        Catch ex As Exception
            MsgError(ex)
        End Try
        Me.Hide()
    End Sub

    Private Sub BBorrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BBorrar.Click
        Try
            'If DRUsuario("FormMod") Then
            If ValidaPermiso("Formulas_Editar") Then
            Else
                MsgBox(DevuelveEvento(CodEvento.USUARIO_PERMISODENEGADO), MsgBoxStyle.Information)
                Exit Sub
            End If

            Dim CodMat As String = ""

            CodMat = DGFor.CurrentRow.Cells("CODMAT").Value.ToString

            If ValidaPermiso("Formulas_Editar") Then
            Else
                MsgBox(DevuelveEvento(CodEvento.USUARIO_PERMISODENEGADO), MsgBoxStyle.Information)
                Exit Sub
            End If

            'Se almacena el ID a borrar para borrarlo luego en la tabla DATOSFOR
            If Not DGFor.CurrentRow.Cells("ID").Value Is Nothing Then
                IDsBorrarDatosFor += DGFor.CurrentRow.Cells("ID").Value.ToString + ","
            End If

            DGFor.Rows.RemoveAt(DGFor.CurrentRow.Index)
            GuardarCambios = True

            For y As Integer = 0 To DGFor.RowCount - 1
                DGFor.Rows(y).Cells(0).Value = y + 1
            Next

            If OPTodos.Checked Then
                OPTodos_Click(Nothing, Nothing)
            Else
                TSumaIng.Text = SumColumn(DGFor, "PesoMeta").ToString
            End If

        Catch ex As Exception
            MsgError(ex)
        End Try

    End Sub

    Private Sub DGDatosFor_EditingControlShowing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles DGFor.EditingControlShowing
        Try
            Dim Txt As TextBox = CType(e.Control, TextBox)
            TextNum(Txt, True)
        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub


    Private Sub OPTodos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OPTodos.Click
        Try
            Dim SumaAditivos As Single = SumPaqPrem(DGFor, ChManejaPx.Checked)
            Dim PaquetePremezcla As Boolean = False
            BusquedaDG(DGFor, "", "", , True)
            TSumaIng.Text = Eval(SumColumn(DGFor, "PesoMeta").ToString) - SumaAditivos

            'Se actualiza el valor del peso de la premezcla

            If ChManejaPx.Checked = False Then Return

            For Each Fila As DataGridViewRow In DGFor.Rows
                If Fila.Cells("A").Value <> "PR" Then Continue For
                PaquetePremezcla = True
                Fila.Cells("PESOMETA").Value = Math.Round(SumaAditivos, 3).ToString
            Next

            If PaquetePremezcla = False And ChManejaPx.Checked Then
                'Si no encontro el paquete de la premezcla se intenta adicionar el ingrediente con el modo "PR"
                If TCodPremezcla.Text <> "" Then
                    TCodInt.Text = TCodPremezcla.Text
                    TNombre.Text = TNomCodPremezcla.Text
                    TCantidad.Text = SumaAditivos
                    ModCrea = "NUEVO"
                    FAgregarFilaDGFor("PR", DGFor.Rows.Count)
                Else
                    MsgBox(DevuelveEvento(CodEvento.FORMULA_ERRORCODPREMEZCLA), vbCritical)
                End If

            End If

        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub DGFor_CellValidating(ByVal sender As Object,
   ByVal e As DataGridViewCellValidatingEventArgs) Handles DGFor.CellValidating

        Try
            Dim Campo As String =
            DGFor.Columns(e.ColumnIndex).Name

            ' Abort validation if cell is not VALOR column.
            If Not Campo.ToUpper.Equals("PESOMETA") Then Return

            ' Confirm that the cell is not empty.
            If (String.IsNullOrEmpty(e.FormattedValue.ToString())) Then
                DGFor.Rows(e.RowIndex).ErrorText = DevuelveEvento(CodEvento.SISTEMA_VALORINCORRECTO)
                e.Cancel = True
            End If



        Catch ex As Exception
            MsgError(ex)
        End Try

    End Sub

    Private Sub DGFor_CellBeginEdit(sender As Object, e As DataGridViewCellCancelEventArgs) Handles DGFor.CellBeginEdit
        If (DGFor.Columns(e.ColumnIndex).Name.ToUpper = "PESOMETA") Then
            DGPesoMPAnt = DGFor.Rows(e.RowIndex).Cells("PESOMETA").Value
        End If

    End Sub

    Private Sub DGFor_CellEndEdit(ByVal sender As Object,
        ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGFor.CellEndEdit

        Try
            ' Se revisa al finalizar la edición de un PESOMETA si la MP es Automático con peso menor a la inclusión mínima de la báscula
            Dim CodMP, NomMP, ModoMP, DGPesoMP, BascMP As String
            ' Se mira si edito un valor de la columna PESOMETA
            If (DGFor.Columns(e.ColumnIndex).Name.ToUpper = "PESOMETA") Then

                ModoMP = DGFor.Rows(e.RowIndex).Cells("A").Value

                If ModoMP = "A" Then ' Sí el material es Automatico se verifica la regla de inclusión mínima
                    CodMP = DGFor.Rows(e.RowIndex).Cells("CODMAT").Value
                    NomMP = DGFor.Rows(e.RowIndex).Cells("NOMMAT").Value
                    DGPesoMP = DGFor.Rows(e.RowIndex).Cells("PESOMETA").Value
                    BascMP = DGFor.Rows(e.RowIndex).Cells("BASCULA").Value

                    If DGPesoMP < InclusionMin(BascMP) Then
                        MsgBox("El Ingrediente: " + CodMP + "  " & NomMP.Trim + " tiene PESO META menor al mínimo permitido de la báscula." + vbNewLine +
                              "La inclusión minima de la báscula " + BascMP + " es: " + InclusionMin(BascMP).ToString + " kg", MsgBoxStyle.Information)
                        DGFor.Rows(e.RowIndex).Cells("PESOMETA").Value = DGPesoMPAnt
                        Exit Sub
                    End If
                End If
            End If

            ' Clear the row error in case the user presses ESC.   
            DGFor.Rows(e.RowIndex).ErrorText = String.Empty
            'TSumaIng.Text = SumColumn(DGFor, "PesoMeta").ToString
            OPTodos_Click(Nothing, Nothing)
            GuardarCambios = True
        Catch ex As Exception
            MsgError(ex)
        End Try

    End Sub

    Private Sub BModo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs,
    Optional ByVal Basc As String = "", Optional ByVal Asig As String = "",
    Optional ByVal TipoMat As String = "", Optional ByVal Tolva As String = "", Optional ByVal NomTolva As String = "") Handles BModo.Click
        Try
            If DGFor.RowCount = 0 Then Exit Sub

            Dim F As Int32 = DGFor.CurrentRow.Index
            If Basc = "" OrElse Asig = "" Then Exit Sub

            F += 1
            If F > DGFor.RowCount - 1 Then F = DGFor.RowCount - 1

            DGFor.Rows(DGFor.CurrentRow.Index).Cells("Bascula").Value = Basc

            DGFor.Rows(DGFor.CurrentRow.Index).Cells("A2").Value = Asig

            If Basc > 20 Then Basc = 0

            'Tratamiento especial para los aditivos que ya vienen pesados se les asigna en el campo A2 la palabra ADL (Aditivos listos)
            If Asig = "ADL" Then
                DGFor.Rows(DGFor.CurrentRow.Index).Cells("A").Value = "AD"
            Else
                DGFor.Rows(DGFor.CurrentRow.Index).Cells("A").Value = Asig
            End If

            ''DGFor.Rows(DGFor.CurrentRow.Index).Cells("A").Value = Asig
            DGFor.Rows(DGFor.CurrentRow.Index).Cells("TIPOMAT").Value = TipoMat
            DGFor.Rows(DGFor.CurrentRow.Index).Cells("TOLVA").Value = Tolva
            DGFor.Rows(DGFor.CurrentRow.Index).Cells("NOMTOLVA").Value = NomTolva

            DGFor.Rows(F).Selected = True
            DGFor.FirstDisplayedScrollingRowIndex = F
            DGFor.CurrentCell = DGFor(0, F)

            ''Evento("Asigna a material: " + DGFor.Rows(DGFor.CurrentRow.Index).Cells("NomMat").Value.ToString + " báscula: " + Basc + " Modo: " + Asig + "TipoMat: " + TipoMat)

        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub BBascula_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try

            Dim Boton As Button = CType(sender, Button)
            Dim Index As Integer = BBascula.Index(Boton)

            Dim TipoMat As Integer = 0
            Dim Modo As String = ""
            Dim Tolva As Int16 = 0
            Dim NomTolva As String = ""
            Dim CodMat As String = 0
            Dim Basc As Integer = 0


            DBasculas.Find("BASCULA=" + Index.ToString)

            If Not DBasculas.EOF Then
                TipoMat = DBasculas.RecordSet("TIPOMAT")
                Modo = DBasculas.RecordSet("A")
                TipoMatTolva = TipoMat

                Select Case Modo
                    Case "A", "EX", "P"  'Si el ingrediente va en modo automatico, pulsado o extruido
                        CodMat = DGFor.Rows(DGFor.CurrentRow.Index).Cells("CODMAT").Value.ToString
                        DVarios.Open("select * from TOLVAS where BASCULA<10 and CODINT='" + CodMat + "'")

                        If DVarios.Count > 1 Then
                            AsignaDataGrid(DGAsigTolva, DVarios.DataTable, True)
                            DGAsigTolva.Visible = True
                            Return
                        Else
                            DTolvas.Refresh()
                            DTolvas.Find("CODINT='" + CodMat + "' and BASCULA<13")
                            If Not DTolvas.EOF Then
                                Tolva = DTolvas.RecordSet("TOLVA")
                                NomTolva = DTolvas.RecordSet("NOMTOLVA")
                                Basc = DTolvas.RecordSet("BASCULA")

                                'If Basc = 3 Then TipoMat = 4 'Tipo liquidos, solo para no modificar la tabla de MovInv
                            End If

                        End If
                    Case "AD"
                        'If DRUsuario("Calidad") Then
                        If ValidaPermiso("Calidad") Then
                        Else
                            MsgBox(DevuelveEvento(CodEvento.USUARIO_PERMISODENEGADO), MsgBoxStyle.Information)
                            Return
                        End If
                    Case "FL"
                        DVarios.Open("Select * from ARTICULOS where CODINT='" + CodMat + "'")
                        If Modo = "FL" AndAlso DVarios.Count > 0 AndAlso Not DVarios.RecordSet("LINEA").ToString.Contains("LIQUIDOS") Then
                            MsgBox("No debe usar este modo de dosificación para un material diferente a aceites o grasas", vbInformation)
                            Return
                        End If
                End Select

                Select Case TipoMat
                    Case 5, 8
                        Basc = DBasculas.RecordSet("BASCULA")
                    Case 1
                        If Funcion_ManejaVehiculo Then Basc = DBasculas.RecordSet("BASCULA")
                End Select


                If Funcion_MaterialesXBandeja Then
                    If (Modo = "A" AndAlso TipoMat = 8) Then             'Si el ingrediente va en modo bandeja se despliegan todas las bandejas
                        DVarios.Open("select * from TOLVAS where NOMTOLVA LIKE'%B%'")

                        If DVarios.Count > 1 Then
                            AsignaDataGrid(DGAsigTolva, DVarios.DataTable, True)
                            DGAsigTolva.Visible = True
                            Return
                        End If
                    End If
                End If

                BModo_Click(Nothing, Nothing, Basc, Modo, TipoMat.ToString, Tolva, NomTolva)
            End If

        Catch ex As Exception
            MsgError(ex)
        End Try



    End Sub

    Private Sub BVerificar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs, Optional ByRef FormOK As Boolean = True) Handles BVerificar.Click

        Dim CodIni As String = ""
        Dim NomIni As String = ""
        Dim PesoIni As String = ""
        Dim Cont As Integer = 0
        Dim Pasos As Integer = 0
        Dim PE As Boolean = False  'Variable para indicar si una formula lleva ingredientes post engrase por peletizado
        Dim Ext As Boolean = False 'Variable para indicar si una formula lleva ingredientes post engrase por Extruder
        Dim A As String = ""
        Dim LLevaOC As Boolean = False
        Dim LLevaAgua As Boolean = False
        Dim SumOC As Double = 0
        Dim SumAguaOC As Double = 0
        Dim LLevaPR As Boolean = False
        Dim NoPermiteModPrem As Boolean
        Dim PesoPremezcla As Single = 0
        Dim Basc As Integer = 0
        Dim PesoLiquidos As Single = 0

        Dim ListFilRep As New List(Of String) '({"-"}) 'Se Agrega un elemento a la lista para poder evaluar el método "ListFilRep.Exists". Se produce una excepción en una lista vacía.

        Try
            'ListFilRep.Add("-") 'Se Agrega un elemento a la lista para poder evaluar el método "ListFilRep.Exists". Se produce una excepción en una lista vacía.

            If (TCodPremezcla.Text = "" Or TNomCodPremezcla.Text = "" Or TCodPremezcla.Text = "0") And ChManejaPx.Checked Then
                MsgBox("Falta código de premezcla", vbInformation)
                Return
            End If

            For Each R As DataGridViewRow In DGFor.Rows
                CodIni = R.Cells("CODMAT").Value
                NomIni = R.Cells("NOMMAT").Value
                PesoIni = R.Cells("PESOMETA").Value
                Basc = R.Cells("BASCULA").Value
                Cont = 0
                A = R.Cells("A").Value

                If Not ListFilRep.Contains(CodIni) Then 'Se verifica que no sea un código de MP evaluado que ya haya cumplido la repetición                

                    For Each Filasel As DataGridViewRow In DGFor.Rows
                        If Filasel.Cells("CODMAT").Value Is Nothing OrElse Filasel.Cells Is Nothing Then
                            Continue For
                        End If
                        'MsgBox(filas("NOMMAT").ToString) 

                        If ListFilRep.Contains(Filasel.Cells("CODMAT").Value) Then
                            Continue For 'Se verifica que no sea un código de MP evaluada que ya haya cumplido la repetición
                        End If

                        ' Se revisa si hay MP repetidas 
                        If CodIni = Filasel.Cells("CODMAT").Value.ToString AndAlso Eval(PesoIni) = Eval(Filasel.Cells("PESOMETA").Value) Then
                            Cont += 1
                            If Cont > 1 Then ' se verifica que no sea la primera coincidencia (comparación de la fila del ciclo For externo con la misma fila del ciclo For interno)
                                If Not ListFilRep.Contains(Filasel.Cells("CODMAT").Value) Then
                                    ListFilRep.Add(Filasel.Cells("CODMAT").Value.ToString)
                                End If
                            End If
                        End If

                    Next

                End If

                If Cont > 1 Then
                    MsgBox("El Ingrediente: " + CodIni + " " & NomIni.Trim + ", está repetido." + vbCrLf +
                           "Recuerde que debe tener pesos meta diferentes.", MsgBoxStyle.Information)
                End If
                Pasos += 1
                R.Cells("PASO").Value = Pasos

                If String.IsNullOrEmpty(R.Cells("A").Value) Or R.Cells("A").Value = "-" Then
                    MsgBox("Ingredientes sin definir Manual o Autómatico ", MsgBoxStyle.Information)
                    FormOK = False
                ElseIf Not IsDBNull(R.Cells("A").Value) AndAlso (R.Cells("A").Value = "A" Or R.Cells("A").Value = "P") Then

                    If Not IsDBNull(R.Cells("BASCULA").Value) Then
                        If R.Cells("BASCULA").Value = 0 Then
                            MsgBox("Ingrediente automático con báscula en cero", MsgBoxStyle.Information)
                            FormOK = False
                        End If
                    Else
                        MsgBox("Ingrediente automático sin báscula asignada")
                        FormOK = False
                    End If
                End If

                If String.IsNullOrEmpty(R.Cells("TIPOMAT").Value) Or R.Cells("TIPOMAT").Value = 0 Then
                    MsgBox("Ingredientes sin definir el Tipo ", MsgBoxStyle.Information)
                    FormOK = False
                End If
                If Eval(R.Cells("PESOMETA").Value) = 0 Then
                    MsgBox("Ingredientes con peso meta en cero ", MsgBoxStyle.Information)
                    FormOK = False
                End If

                If R.Cells("A").Value = "A" AndAlso Eval(R.Cells("PESOMETA").Value) < InclusionMin(Basc) Then
                    MsgBox("El Ingrediente: " + CodIni + "  " & NomIni + " tiene PESO META menor al mínimo permitido de la báscula." + vbNewLine +
                              "La inclusión minima de la báscula " + Basc.ToString + " es: " + InclusionMin(Basc).ToString + " kg", MsgBoxStyle.Information)
                    FormOK = False
                End If

                If Not IsDBNull(R.Cells("A").Value) AndAlso Not IsDBNull(R.Cells("TOLVA").Value) Then
                    If (R.Cells("A").Value = "A" Or R.Cells("A").Value = "P") AndAlso Val(R.Cells("TOLVA").Value) = 0 Then
                        MsgBox("Ingredientes automáticos sin tolva asignada", MsgBoxStyle.Information)
                        FormOK = False
                    End If

                    If R.Cells("A").Value = "EX" AndAlso Val(R.Cells("TOLVA").Value) = 0 Then
                        MsgBox("Ingredientes Extruder sin tanque asignado", MsgBoxStyle.Information)
                        FormOK = False
                    End If

                End If


                If Not IsDBNull(R.Cells("A").Value) AndAlso R.Cells("A").Value = "PE" Then PE = True
                If Not IsDBNull(R.Cells("A").Value) AndAlso R.Cells("A").Value = "EX" Then Ext = True

                If A = "PR" Then
                    LLevaPR = True
                    PesoPremezcla = PesoIni
                End If


                If Funcion_ManejaOpticurp Then
                    'LLeva agua
                    If A = "HC" Then
                        LLevaAgua = True
                        SumAguaOC = R.Cells("PESOMETA").Value
                    End If
                    'Lleva mycocurp o salcurp
                    If A = "MC" Or A = "SC" Then
                        LLevaOC = True
                        SumOC += R.Cells("PESOMETA").Value
                    End If

                    'validaciones para que en planta no vayan a colocar otro ingrediente como HC

                    If A = "HC" And CodIni <> CodAguaHC Then
                        MsgBox("Hay un ingrediente que no puede ser HC, recuerde que solo debe ser el agua", MsgBoxStyle.Information)
                        FormOK = False
                    End If

                    If A = "SC" And Eval(R.Cells("PESOMETA").Value) > ValorMaxSalCurp Then
                        MsgBox("Favor verificar cantidad de ingrediente con asignación SC", MsgBoxStyle.Information)
                        FormOK = False
                    End If

                    If A = "MC" And Eval(R.Cells("PESOMETA").Value) > ValorMaxMycoCurp Then
                        MsgBox("Favor verificar cantidad de ingrediente con asignación MC", MsgBoxStyle.Information)
                        FormOK = False
                    End If

                End If

                'Se realiza la sumatoria del peso si la báscula es de líquidos excluyendo la miel de purga o melaza
                If A = "A" And BascLiquidos.Contains(Basc) And CodIni <> CodMelaza Then
                    PesoLiquidos += PesoIni
                End If

            Next

            If PE And Ext Then
                MsgBox("Fórmula con aceites por extruder y peletizado", MsgBoxStyle.Information)
                FormOK = False
            End If

            If LLevaPR = False AndAlso ChManejaPx.Checked Then
                MsgBox("Error en fórmula, no contiene ingrediente modo PR (PreMezclas)", vbInformation)
                FormOK = False
            End If

            If Funcion_ManejaOpticurp Then
                'If LLevaAgua And LLevaOC = False Then
                '    MsgBox("Error en mezcla OptiCurb. Además de agua debe llevar otro componente Opticurb", vbInformation)
                '    FormOK = False
                'End If

                'If LLevaAgua = False And LLevaOC = True Then
                '    MsgBox("Error en mezcla OptiCurb. La mezcla debe contener agua en modo OptiCurb", vbInformation)
                '    FormOK = False
                'End If

                'Se evalua que las cantidades de Opticurb no sean inferiores al 5% del total del agua

                'If SumOC < SumAguaOC * PorcOpticurpAdicionar Then
                '    MsgBox("La suma de SalCurp + Myco Curp no puede ser menor al 5% del agua a adicionar", vbInformation)
                '    FormOK = False
                'End If
            End If

            If ChManejaPx.Checked Then
                'Se revisa si ya existe dosificación en tabla consumosmed de la formula a modificar
                'si ya hay consumos, no se deja modificar la premezcla
                DVarios.Open("Select * from CONSUMOSMED where ESTADO<10 and CODFOR='" + TCodFor.Text + "' AND LP='" + TLP.Text + "'")

                If DVarios.Count Then
                    NoPermiteModPrem = True
                End If

                If NoPermiteModPrem Then
                    'Abrimos el componente código de premezcla de la fórmula para saber cuanto pesa 
                    DVarios.Open("Select sum(PESOMETA) as PESOMETA from DATOSFOR where A='AD' AND CODFOR='" + TCodFor.Text + "' AND LP='" + TLP.Text + "'")

                    If DVarios.Count AndAlso Not IsDBNull(DVarios.RecordSet("PESOMETA")) Then
                        If Math.Abs(DVarios.RecordSet("PESOMETA") - PesoPremezcla) > 0.2 Then
                            MsgBox("No se puede modificar el valor de la premezcla, esta fórmula ya se encuentra en proceso de producción", vbInformation)
                            FormOK = False
                        End If
                    End If
                End If
            End If

            If OPTodos.Checked Then
                OPTodos_Click(Nothing, Nothing)
            Else
                TSumaIng.Text = SumColumn(DGFor, "PesoMeta").ToString
            End If

            'Se calcula el porcentaje de liquido con respecto a la formula, para sacar una alarma y no dejar guardar la fórmula

            If Val(TSumaIng.Text) > 0 Then
                Dim PorcLiquidos As Single = (PesoLiquidos / Val(TSumaIng.Text)) * 100
                If PorcLiquidos > 2 Then
                    Resp = MsgBox("Porcentaje de aceites por mezcladora superior al 2%, ¿Desea guardar la fórmula?", vbInformation + vbYesNo)
                    If Resp = vbNo Then FormOK = False
                    Evento("Guarda fórmula con porcentaje de aceites por mezcladora superior al 2%")
                End If
            End If

        Catch ex As Exception
            MsgError(ex)
        End Try

    End Sub

    Private Sub TCodFor_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TCodFor.KeyDown
        If e.KeyCode <> Keys.Enter Then Return
        TCodForB.Focus()
    End Sub
    Private Sub TCodForB_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TCodForB.KeyDown
        If e.KeyCode <> Keys.Enter Then Return
        TNomFor.Focus()
    End Sub

    Private Sub TBuscar_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TBuscar.KeyUp
        Try
            'If CBBuscar.Text = "" Then
            '    CBBuscar.Focus()
            '    MsgBox("Debe seleccionar el campo a buscar", MsgBoxStyle.Exclamation)
            '    TBuscar.Text = ""
            '    Exit Sub
            'End If

            If TBuscar.Text = "" Then
                AsignaDataGrid(DGMat, DArt.DataTable, True)
                Exit Sub
            End If

            Dim x As Integer
            Dim Hallado As Boolean

            x = CBBuscar.SelectedIndex

            'If TipoCampo(Campos(x), DTMat) <> "String" AndAlso e.KeyCode <> Keys.Enter Then Exit Sub


            BusquedaDG(DGMat, DArt.DataTable, TBuscar.Text, Campos(x), Hallado)

            If Hallado = False Then
                'CBBuscar.Focus()
                'MsgBox("Registro no encontrado", MsgBoxStyle.Information)
                Exit Sub
            End If

            DGMat_CellClick(Nothing, Nothing)


        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub BNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BNuevo.Click
        Try
            'If DRUsuario("FormMod") Then
            If ValidaPermiso("Formulas_Editar") Then
            Else
                MsgBox(DevuelveEvento(CodEvento.USUARIO_PERMISODENEGADO), MsgBoxStyle.Information)
                Exit Sub
            End If

            If Eval(TCodFor.Text) = 0 And TCodForB.Text = "" And TNomFor.Text = "" Then Exit Sub

            'PanPrincipal.Enabled = True
            'FrmIngAdcFor.Visible = True
            'FrmFor.Enabled = True
            BAgregar.Enabled = True
            ModCrea = "NUEVO"
            GuardarCambios = True
            FAgregarFilaDGFor()
        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub


    Private Sub TCodForB_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TCodForB.TextChanged
        TCodForB.CharacterCasing = CharacterCasing.Upper
    End Sub

    Private Sub TNomFor_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TNomFor.TextChanged
        TNomFor.CharacterCasing = CharacterCasing.Upper
    End Sub


    Private Sub MaterialesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MaterialesToolStripMenuItem.Click
        Materiales.ShowDialog()
    End Sub

    Private Sub AcercaDeToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AcercaDeToolStripMenuItem.Click
        AcercaD.ShowDialog()
    End Sub

    Private Sub BTolvas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTolvas.Click
        Tolvas.ShowDialog()
    End Sub


    Private Sub BCamCodMat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BCamCodMat.Click
        If ValidaPermiso("Formulas_Editar") Then
        Else
            MsgBox(DevuelveEvento(CodEvento.USUARIO_PERMISODENEGADO), MsgBoxStyle.Information)
            Return
        End If
        CamCodMat.ShowDialog()
    End Sub

    Private Sub ProductosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnProductos.Click
        Try
            If ValidaPermiso("Productos_Ver, Productos_Editar") Then
            Else
                MsgBox(DevuelveEvento(CodEvento.USUARIO_PERMISODENEGADO), MsgBoxStyle.Information)
                Exit Sub
            End If
            Productos.ShowDialog()
        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub ReportesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnReportes.Click
        Try
            If ValidaPermiso("Reportes_Ver") Then
            Else
                MsgBox(DevuelveEvento(CodEvento.USUARIO_PERMISODENEGADO), MsgBoxStyle.Information)
                Exit Sub
            End If
            Reportes.ShowDialog()
        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub BMultCant_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BMultCant.Click
        Try
            If ValidaPermiso("Formulas_Editar") Then
            Else
                MsgBox(DevuelveEvento(CodEvento.USUARIO_PERMISODENEGADO), MsgBoxStyle.Information)
                Return
            End If

            If Funcion_ManejaVehiculo = False Then

                Dim NuevoPorc As Single

                RespInput = MsgBox(DevuelveEvento(CodEvento.SISTEMA_PROCESOCONFIRMACION), vbInformation + vbYesNo, "Multiplicar cantidad por un porcentaje")

                If RespInput = vbNo Then Exit Sub

                RespInput = "100"
                InputBox.InputBox("Múltiplo de fórmula", "Ingrese el porcentaje por el cual se multiplicará la fórmula", RespInput)


                NuevoPorc = Eval(RespInput)

                If NuevoPorc < 10 Or NuevoPorc > 600 Then
                    MsgBox(DevuelveEvento(CodEvento.SISTEMA_VALORINCORRECTO), vbInformation)
                    Exit Sub
                End If

                For Each Filasel As DataGridViewRow In DGFor.Rows
                    Filasel.Cells("PESOMETA").Value = Filasel.Cells("PESOMETA").Value * NuevoPorc / 100
                Next

            Else

                'APLICA PARA PLANTA PREMEZCLAS
                Dim Factor As Double

                RespInput = ""
                InputBox.InputBox("Número de paquetes", "Ingrese el número de paquetes a realizar", RespInput)

                If Val(RespInput) <= 0 Then
                    MsgBox("Cantidad de paquetes no válida", vbCritical)
                    Return
                End If


                Factor = Eval(RespInput)

                Resp = MsgBox("El peso total para el número de paquetes seleccionado es: " + (Val(TSumaIng.Text) * Factor).ToString + " kg, y se adicionarán 100 gramos para la contramuestra ¿Desea continuar?", vbYesNo + vbInformation)

                If Resp = vbNo Then Return


                For Each Filasel As DataGridViewRow In DGFor.Rows
                    If Filasel.Cells("TIPOVEHICULO").Value Then
                        'Se suman 100 gramos para contramuestra
                        Filasel.Cells("PESOMETA").Value = Filasel.Cells("PESOMETA").Value * Factor + 0.1
                    Else
                        Filasel.Cells("PESOMETA").Value = Filasel.Cells("PESOMETA").Value * Factor
                    End If

                Next

            End If

            OPTodos_Click(Nothing, Nothing)

        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub BActualizar_Click(sender As System.Object, e As System.EventArgs) Handles BActualizar.Click
        Try
            FCargaDatosFor_Click(Nothing, Nothing)
            If Funcion_ManejaVehiculo Then
                DArt.Open("select * from ARTICULOS where TIPO='MP' or TIPO='PT'")
            Else
                DArt.Open("select * from ARTICULOS where TIPO='MP'")
            End If

            AsignaDataGrid(DGMat, DArt.DataTable, True)
            OPTodos_Click(Nothing, Nothing)
        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub DGFor_CellClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs)

    End Sub



    Private Sub DGAsigTolva_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGAsigTolva.CellClick
        Try

            If DGAsigTolva.RowCount = 0 Then Return
            Dim Tolva As String = DGAsigTolva.Rows(DGAsigTolva.CurrentRow.Index).Cells("Tolva_Tolva").Value.ToString()
            Dim Basc As String = DGAsigTolva.Rows(DGAsigTolva.CurrentRow.Index).Cells("Tolva_Bascula").Value.ToString()
            Dim NomTolva As String = DGAsigTolva.Rows(DGAsigTolva.CurrentRow.Index).Cells("Tolva_NomTolva").Value.ToString()

            'BModo_Click(Nothing, Nothing, Basc, "A", TipoMatTolva.ToString, Tolva)
            BModo_Click(Nothing, Nothing, Basc, "A", TipoMatTolva.ToString, Tolva, NomTolva)
            DGAsigTolva.Visible = False
        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub TCodEspecie_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TCodEspecie.SelectedIndexChanged
        Try
            TNomEspecie.Text = Formulacion.Devuelve_NombreEspecie(TCodEspecie.Text)
        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub TCodGrpFor_SelectedIndexChange(sender As Object, e As EventArgs) Handles TCodGrpFor.SelectedIndexChanged
        Try
            TNomGrpForm.Text = Formulacion.Devuelve_NombreGrpFor(TCodGrpFor.Text)
        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub



    Public Sub FCargaDatosFor_Click(sender As Object, e As EventArgs) Handles FCargaDatosFor.Click
        Try

            DFor.Open("select * from FORMULAS where CODFOR='" + TCodFor.Text + "' and LP='" + TLP.Text + "'")
            DDatosFor.Open("select * from DATOSFOR where TIPOMAT<40 and CODFOR='" + TCodFor.Text + "' and LP='" + TLP.Text + "' order by PASO")
            CodEspecie = DFor.RecordSet("CODESPECIE")
            CodGrpFor = DFor.RecordSet("CODGRPFOR")


            AsignaDataGrid(DGFor, DDatosFor.DataTable)
            For h As Integer = 0 To DGFor.RowCount - 1
                DGFor.Rows(h).Cells(0).Value = h + 1
            Next

            If TNuevoEditar.Text = "EDITAR" Then
                If DFor.Count = 0 Then Exit Sub
                BEditar_Click(Nothing, Nothing)
                TCodForB.Text = DFor.RecordSet("CODFORB").ToString
                TNomFor.Text = DFor.RecordSet("NOMFOR").ToString
                TCodPremezcla.Text = DFor.RecordSet("CODPREMEZCLA").ToString

                DVarios.Open("Select * FROM ESPECIES where CODESPECIE='" + CodEspecie + "'")
                If DVarios.Count Then TCodEspecie.Text = Mid(DVarios.RecordSet("CODESPECIE") + Space(5), 1, 5) + DVarios.RecordSet("NOMESPECIE")

                DVarios.Open("Select * FROM GRPFORMULAS where CODGRPFOR='" + CodGrpFor + "'")
                If DVarios.Count Then TCodGrpFor.Text = Mid(DVarios.RecordSet("CODGRPFOR") + Space(5), 1, 5) + DVarios.RecordSet("NOMGRPFOR")

                TCodEspecie.Text = DFor.RecordSet("CODESPECIE").ToString
                TNomEspecie.Text = Formulacion.Devuelve_NombreEspecie(TCodEspecie.Text)
                TCodGrpFor.Text = DFor.RecordSet("CODGRPFOR").ToString
                TNomGrpForm.Text = Formulacion.Devuelve_NombreGrpFor(TCodGrpFor.Text)
                TEstado.SelectedItem = DFor.RecordSet("ESTADO")
                ChManejaPx.Checked = DFor.RecordSet("MANEJAPX")
                TCodEstablecimiento.Text = DFor.RecordSet("CODESTABLECIMIENTO")

                If Funcion_ManejaVehiculo Then
                    TPesoPaq.Text = DFor.RecordSet("PESOFORMINI")
                    TPesoPaq2.Text = DFor.RecordSet("PESOPAQ")
                    TNumPaq.Text = DFor.RecordSet("NUMPAQ")
                    TDosis.Text = DFor.RecordSet("DOSIS")
                    TPaqxBache.Text = DFor.RecordSet("NUMPAQXBACHE")
                End If

                TCodFor.ReadOnly = True
                TLP.ReadOnly = True
                FrmFor.Enabled = True
            ElseIf TNuevoEditar.Text = "NUEVA" Then
                TCodFor.Text = ""
                TCodForB.Text = ""
                TNomFor.Text = ""
                TLP.Text = ""
                TEstado.SelectedItem = "-"
                TCodPremezcla.Text = ""
                TCodEstablecimiento.Text = ""
                TextNum(TCodFor.TextBox)
            End If

            If OPTodos.Checked Then
                OPTodos_Click(Nothing, Nothing)
            Else
                TSumaIng.Text = SumColumn(DGFor, "PesoMeta").ToString
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub TCodPremezcla_TextChanged(sender As Object, e As EventArgs) Handles TCodPremezcla.TextChanged
        Try
            FBuscaCodPremezcla()
        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub RBFiltro_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Dim Hallado As Boolean

            Dim RB As RadioButton = CType(sender, RadioButton)
            Dim Index As Integer = RBFiltro.Index(RB)

            DFormFiltros.Find("POSICION=" + Index.ToString)

            If Not DFormFiltros.EOF Then

                If DFormFiltros.RecordSet("CAMPO") = "TIPOMAT" Then
                    BusquedaDG(DGFor, "TipoMat", DFormFiltros.RecordSet("VALOR"), Hallado)
                ElseIf DFormFiltros.RecordSet("CAMPO") = "BASCULA" Then
                    BusquedaDG(DGFor, "Bascula", DFormFiltros.RecordSet("VALOR"), Hallado)
                ElseIf DFormFiltros.RecordSet("CAMPO") = "A" Then
                    BusquedaDG(DGFor, "A", DFormFiltros.RecordSet("VALOR"), Hallado)
                End If

            End If
            If Hallado = False Then
                'CBBuscar.Focus()
                'MsgBox("Registros no encontrados", MsgBoxStyle.Information)
                Exit Sub
            End If

            TSumaIng.Text = SumColumn(DGFor, "PesoMeta").ToString

        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub BDividePeso_Click(sender As Object, e As EventArgs) Handles BDividePeso.Click
        Try
            'If DRUsuario("FORMMOD") Or DRUsuario("FormModDosif") Then
            If ValidaPermiso("Formulas_Editar, Formulas_EditarBasculas") Then
            Else
                MsgBox(DevuelveEvento(CodEvento.USUARIO_PERMISODENEGADO), MsgBoxStyle.Information)
                Return
            End If

            If DGFor.CurrentRow Is Nothing Then
                MsgBox(DevuelveEvento(CodEvento.BD_REGNOSELECCIONADO), MsgBoxStyle.Information)
                Return
            End If


            Dim NuevoVal As Single
            Dim ValTotal As Single = DGFor.CurrentRow.Cells("PESOMETA").Value
            Dim Nommat As String = DGFor.CurrentRow.Cells("NOMMAT").Value.ToString

            Select Case Planta
                Case Planta.Contains("GIRARDOTA")
                    'Se verifica que el material a particionar solamente este una vez en la formula
                    ''no se puede particionar mas de 2 veces

                    Dim Codmat As String = DGFor.Rows(DGFor.CurrentRow.Index).Cells("CodMat").Value.ToString
                    Dim Cont As Integer = 0

                    For Each R As DataGridViewRow In DGFor.Rows
                        If Codmat = R.Cells("CODMAT").Value Then Cont += 1
                    Next

                    RespInput = 0
                    'MsgBox("El valor total en Kg debe ser :" + ValTotal.ToString, vbInformation)
                    If InputBox.InputBox("Dividir Ingrediente", "Ingrese el primer valor en Kg", NuevoVal) Then

                        If NuevoVal <= 0 Then
                            MsgBox("El valor no puede ser cero o negativo", MsgBoxStyle.Critical)
                            Return
                        End If

                        If NuevoVal > ValTotal Then
                            MsgBox("El valor no puede ser mayor al valor total", vbInformation)
                            Return
                        End If


                        Dim Valor1 As Single = NuevoVal
                        Dim Valor2 As Single = Format(ValTotal - Valor1, "0.000")
                        Dim Valor3 As Single = 0
                        Dim Index As Int16 = 0



                        If Cont = 1 Then

                            If (Codmat = "2" Or Codmat = "6" Or Codmat = "7" Or Codmat = "12" Or Codmat = "190") And (Valor1 < 300 Or Valor2 < 300) Then
                                MsgBox("El valor para el MAIZ no puede ser menor a 300 Kg", vbInformation)
                                Return
                            End If

                            DGFor.Rows(DGFor.CurrentRow.Index).Cells("PesoMeta").Value = Format(Valor1, "0.000")

                            TCodInt.Text = DGFor.Rows(DGFor.CurrentRow.Index).Cells("CodMat").Value.ToString
                            TNombre.Text = DGFor.Rows(DGFor.CurrentRow.Index).Cells("NomMat").Value.ToString
                            TCantidad.Text = Valor2

                            ModCrea = "NUEVO"
                            FAgregarFilaDGFor()
                        Else

                            'Se ubica el otro peso del maiz para agregarle el peso restante del ingrediente 1, siempre debera ser 2 registros de maiz solamente, uno por bascula

                            For Each R As DataGridViewRow In DGFor.Rows
                                If Codmat = R.Cells("CODMAT").Value And ValTotal <> R.Cells("PESOMETA").Value Then
                                    Valor3 = R.Cells("PESOMETA").Value + Valor2
                                    Index = R.Index
                                    Exit For
                                End If
                            Next

                            If (Codmat = "2" Or Codmat = "6" Or Codmat = "7" Or Codmat = "12" Or Codmat = "190") And (Valor1 < 300 Or Valor3 < 300) Then
                                MsgBox("El valor para el MAIZ no puede ser menor a 300 Kg", vbInformation)
                                Return
                            End If
                            DGFor.Rows(DGFor.CurrentRow.Index).Cells("PesoMeta").Value = Format(Valor1, "0.000")
                            DGFor.Rows(Index).Cells("PESOMETA").Value = Format(Valor3, "0.000")
                        End If
                    End If

                Case Else

                    RespInput = 0

                    If InputBox.InputBox("Dividir Ingrediente", "Ingrese el primer valor en Kg", NuevoVal) Then

                        If NuevoVal <= 0 Then
                            MsgBox("El valor no puede ser cero o negativo", MsgBoxStyle.Critical)
                            Return
                        End If

                        If NuevoVal > ValTotal Then
                            MsgBox("El valor no puede ser mayor al valor total", vbInformation)
                            Return
                        End If


                        Dim Valor1 As Single = NuevoVal
                        Dim Valor2 As Single = Format(DGFor.Rows(DGFor.CurrentRow.Index).Cells("PesoMeta").Value - Valor1, "0.000")

                        DGFor.Rows(DGFor.CurrentRow.Index).Cells("PesoMeta").Value = Format(Valor1, "0.000")

                        TCodInt.Text = DGFor.Rows(DGFor.CurrentRow.Index).Cells("CodMat").Value.ToString
                        TNombre.Text = DGFor.Rows(DGFor.CurrentRow.Index).Cells("NomMat").Value.ToString
                        TCantidad.Text = Valor2

                        ModCrea = "NUEVO"
                        FAgregarFilaDGFor()
                        Return

                    End If

            End Select
        Catch ex As Exception
            MsgError(ex)
        End Try

    End Sub

    Private Sub DGFor_CellFormatting(sender As System.Object, e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles DGFor.CellFormatting
        Try

            If DGFor.Columns(e.ColumnIndex).Name = "PesoMeta" Then
                If e.Value IsNot Nothing Then
                    Dim valor As String = CType(e.Value, String)
                    If (Eval(valor) = 0) Then
                        DGFor.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.Yellow
                        ' DGSoliCargue.RowsDefaultCellStyle.BackColor = Color.Yellow
                        ' e.CellStyle.BackColor = Color.Yellow
                    End If
                End If
            End If
        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub BAgrupar_Click(sender As Object, e As EventArgs) Handles BAgrupar.Click
        Try
            'If DRUsuario("FormMod") Then
            If ValidaPermiso("Formulas_Editar, Formulas_EditarBasculas ") Then
            Else
                MsgBox(DevuelveEvento(CodEvento.USUARIO_PERMISODENEGADO), MsgBoxStyle.Information)
                Return
            End If

            If Funcion_FuncionesPlantaPremezclas = False Then

                Dim CodInt As String = DGFor.Rows(DGFor.CurrentRow.Index).Cells("CodMat").Value.ToString
                Dim NomMat As String = DGFor.Rows(DGFor.CurrentRow.Index).Cells("NomMat").Value.ToString
                Dim ValorTotal As Double = 0

                Resp = MsgBox("Seguro desea agrupar el peso del material " + NomMat + "?", vbYesNo + vbInformation)
                If Resp = vbNo Then Return

                'Se agrupa el pesometa del código solicitado para cambiarlo en un registro de la tabla y eliminar el otro
                DVarios.Open("Select sum(PESOMETA) As PESOMETA from DATOSFOR where CODFOR='" + TCodFor.Text + "' and LP='" + TLP.Text + "' and CODMAT='" + CodInt + "'")

                If DVarios.Count AndAlso Not IsDBNull(DVarios.RecordSet("PESOMETA")) Then
                    ValorTotal = DVarios.RecordSet("PESOMETA")
                End If

                'Se revisa en el datagrid donde se encuentran los registros de la materia prima a agrupar

                Dim Modificado As Int16 = 0

                For Each FilaDG As DataGridViewRow In DGFor.Rows
                    If Val(FilaDG.Cells("CodMat").Value) <> Val(CodInt) Then Continue For

                    'Se almacena el ID a borrar para borrarlo luego en la tabla DATOSFOR
                    If Not DGFor.CurrentRow.Cells("ID").Value Is Nothing Then
                        'IDsBorrarDatosFor += DGFor.CurrentRow.Cells("ID").Value.ToString + ","
                        IDsBorrarDatosFor += FilaDG.Cells("ID").Value.ToString + ","
                    End If

                    If Modificado > 0 Then
                        ''Se almacena el ID a borrar para borrarlo luego en la tabla DATOSFOR
                        'If Not DGFor.CurrentRow.Cells("ID").Value Is Nothing Then
                        '    IDsBorrarDatosFor += DGFor.CurrentRow.Cells("ID").Value.ToString + ","
                        'End If
                        'Se borrra el material
                        DGFor.Rows.RemoveAt(FilaDG.Index)

                        For y As Integer = 0 To DGFor.RowCount - 1
                            DGFor.Rows(y).Cells(0).Value = y + 1
                        Next
                    Else
                        FilaDG.Cells("PesoMeta").Value = Format(ValorTotal, "######0.000")
                        Modificado += 1
                    End If
                Next

                If OPTodos.Checked Then
                    OPTodos_Click(Nothing, Nothing)
                Else
                    TSumaIng.Text = SumColumn(DGFor, "PesoMeta").ToString
                End If
            Else
                'Vuelve a reagrupar la formula para usarla por la linea 2

                DVarios.Open("Select sum(PESOMETA) as PESOMETA, min(NOMMAT) as NOMMAT, min(CODMAT) as CODMAT from DATOSFOR where CODFOR='" + TCodFor.Text + "' AND LP='" + TLP.Text + "' group BY CODMAT")
                IDsBorrarDatosFor = ""
                For Each Fila As DataGridViewRow In DGFor.Rows
                    'Se almacena el ID a borrar para borrarlo luego en la tabla DATOSFOR
                    IDsBorrarDatosFor += Fila.Cells("ID").Value.ToString + ","
                Next

                DGFor.Rows.Clear()

                Dim RowIndex As Int16 = 0
                Dim PesoMeta As Single = 0
                Dim Basc As Int16 = 0

                For Each Fila As DataRow In DVarios.Rows
                    PesoMeta = Math.Round(Fila("PESOMETA"), 3)
                    If PesoMeta <= 20 Then
                        Basc = 5
                    Else
                        Basc = 6
                    End If
                    TCodInt.Text = Fila("CODMAT")
                    TNombre.Text = Fila("NOMMAT")
                    ModCrea = "NUEVO"
                    FAgregarFilaDGFor("PM", ,,, Basc, PesoMeta)
                Next
                BGuardar_Click(Nothing, Nothing)
            End If

            ''Vuelve a reagrupar la formula para usarla por la linea 2

            'DVarios.Open("Select sum(PESOMETA) as PESOMETA, min(NOMMAT) as NOMMAT, min(CODMAT) as CODMAT from DATOSFOR where CODFOR='" + TCodFor.Text + "' AND LP='" + TLP.Text + "' group BY CODMAT")

            'DGFor.Rows.Clear()

            'Dim RowIndex As Int16 = 0
            'Dim PesoMeta As Single = 0
            'Dim Basc As Int16 = 0

            'For Each Fila As DataRow In DVarios.Rows
            '    PesoMeta = Math.Round(Fila("PESOMETA"), 3)
            '    If PesoMeta <= 20 Then
            '        Basc = 5
            '    Else
            '        Basc = 6
            '    End If
            '    TCodInt.Text = Fila("CODMAT")
            '    TNombre.Text = Fila("NOMMAT")
            '    ModCrea = "Nuevo"
            '    BAgregar_Click(Nothing, Nothing, PesoMeta, Basc, , , "PM")
            'Next

            'BGuardar_Click(Nothing, Nothing)




        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub FBuscaCodPremezcla()
        Try
            If TCodPremezcla.Text = "" Then Return
            DVarios.Open("select NOMBRE from ARTICULOS where TIPO='MP' and CODINT='" + TCodPremezcla.Text + "'")
            If DVarios.Count Then
                TNomCodPremezcla.Text = DVarios.RecordSet("NOMBRE")
            End If
        Catch ex As Exception
            MsgError(ex)
        End Try

    End Sub

    Private Sub TCodPremezcla_KeyUp(sender As Object, e As KeyEventArgs) Handles TCodPremezcla.KeyUp
        Try
            If e.KeyCode <> Keys.Enter Then Return
            FBuscaCodPremezcla()
        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub FAgregarIng_Click(ByVal TipoMat As String, ByVal A As String, ByVal PesoMeta As Single, ByVal CodMat As String, ByVal Paso As Int16, ByVal Basc As Int16, ByVal Tolva As Int16)
        Try

            If TipoMat = "" Or A = "" Or PesoMeta = 0 Or CodMat = "" Then Return

            DDatosFor.Open("Select * from DATOSFOR WHERE CODFOR='0'")

            DDatosFor.AddNew()
            DDatosFor.RecordSet("CODMAT") = CodMat
            DDatosFor.RecordSet("PASO") = Paso
            DDatosFor.RecordSet("TIPOMAT") = TipoMat
            DDatosFor.RecordSet("A") = A
            DDatosFor.RecordSet("CODFOR") = TCodFor.Text
            DDatosFor.RecordSet("CODFORB") = TCodForB.Text
            DDatosFor.RecordSet("LP") = TLP.Text

            DDatosFor.RecordSet("BASCULA") = Basc
            DDatosFor.RecordSet("PESOMETA") = Format(PesoMeta, ".000")
            DDatosFor.RecordSet("TOLVA") = Tolva

            If TipoMat = 7 Then
                DArt.Open("Select * from ARTICULOS where CODINT='" + CodMat + "'")
                DDatosFor.RecordSet("NOMMAT") = DArt.RecordSet("NOMBRE")
                DDatosFor.RecordSet("CODMATB") = DArt.RecordSet("CODEXT")

                DArt.RecordSet("TIPOMAT") = DDatosFor.RecordSet("TIPOMAT")
                DArt.RecordSet("A") = DDatosFor.RecordSet("A")
                DArt.RecordSet("BASCULA") = DDatosFor.RecordSet("BASCULA")
                DDatosFor.RecordSet("TOLINF") = 0.1
                DDatosFor.RecordSet("TOLSUP") = 0.1
                DArt.Update()

            Else
                DDatosFor.RecordSet("NOMMAT") = "SUMA ING. B" + CLeft(CodMat, 2)
                DDatosFor.RecordSet("CODMATB") = CodMat
                DDatosFor.RecordSet("INCLUIR") = 0
                DDatosFor.RecordSet("TOLINF") = 3
                DDatosFor.RecordSet("TOLSUP") = 3
            End If


            DDatosFor.Update()

        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub BAdVehiculo_Click(sender As Object, e As EventArgs) Handles BAdVehiculo.Click
        Try
            'If DRUsuario("FormMod") Then
            If ValidaPermiso("Formulas_Editar") Then
            Else
                MsgBox(DevuelveEvento(CodEvento.USUARIO_PERMISODENEGADO), MsgBoxStyle.Information)
                Exit Sub
            End If


            If TCodVehiculo.Text = "" OrElse CBNomVehiculo.Text = "" Then
                Return
            End If

            Dim PosInsert As Int32 = 0

            If DGFor.RowCount = 0 Then
                PosInsert = 0
                DGFor.Rows.Add()
            Else
                PosInsert = DGFor.RowCount
                DGFor.Rows.Insert(PosInsert)
            End If

            DGFor.Rows(PosInsert).Cells("Paso").Value = PosInsert
            DGFor.Rows(PosInsert).Cells("CodMat").Value = TCodVehiculo.Text
            DGFor.Rows(PosInsert).Cells("NomMat").Value = CBNomVehiculo.Text
            DGFor.Rows(PosInsert).Cells("Sacos").Value = 0
            'DGFor.Rows(PosInsert).Cells("NomTolva").Value = "-"
            DGFor.Rows(PosInsert).Cells("TipoVehiculo").Value = True

            DGFor.Rows(PosInsert).Cells("PesoMeta").Value = Format(Eval(TPesoVehi.Text), "######0.000")

            For h As Integer = 0 To DGFor.RowCount - 1
                DGFor.Rows(h).Cells(0).Value = h + 1
            Next

            DGFor.Rows(PosInsert).Selected = True
            DGFor.FirstDisplayedScrollingRowIndex = PosInsert
            DGFor.CurrentCell = DGFor(0, PosInsert)

            DVarios.Open("Select * from ARTICULOS where CODINT='" + TCodVehiculo.Text + "'")

            If DVarios.Count > 0 Then
                DGFor.Rows(PosInsert).Cells("Bascula").Value = DVarios.RecordSet("BASCULA")
                DGFor.Rows(PosInsert).Cells("A").Value = DVarios.RecordSet("A")
                DGFor.Rows(PosInsert).Cells("TIPOMAT").Value = DVarios.RecordSet("TIPOMAT")
                DGFor.Rows(PosInsert).Cells("TARA").Value = DVarios.RecordSet("TARA")
                'Si el material es automa
                If DVarios.RecordSet("A") = "A" Then
                    DTolvas.Refresh()
                    DTolvas.Find("CODINT='" + TCodInt.Text + "'")
                    If Not DTolvas.EOF Then
                        DGFor.Rows(PosInsert).Cells("TOLVA").Value = DTolvas.RecordSet("TOLVA")
                    Else
                        DGFor.Rows(PosInsert).Cells("TOLVA").Value = 0
                    End If
                Else
                    DGFor.Rows(PosInsert).Cells("TOLVA").Value = 0

                End If
            Else
                DGFor.Rows(PosInsert).Cells("Bascula").Value = 0
            End If

            OPTodos_Click(Nothing, Nothing)

        Catch ex As Exception
            MsgError(ex)
        End Try

    End Sub



    Private Sub TPesoPaq_TextChanged(sender As Object, e As EventArgs) Handles TPesoPaq.TextChanged
        Try
            If Val(TPesoPaq.Text) = 0 Then
                TPesoVehi.Text = 0
                Return
            End If
            If Val(TCodVehiculo.Text) = 0 Then Return
            If Val(TSumaIng.Text) = 0 Then Return

            TPesoVehi.Text = Val(TPesoPaq.Text) - (TSumaIng.Text)

            If Val(TPesoPaq.Text) <= 40 Then
                TPesoPaq2.Text = TPesoPaq.Text
                TNumPaq.Text = 1
            ElseIf Val(TPesoPaq.Text) > 40 AndAlso Val(TPesoPaq.Text) <= 80 Then
                TPesoPaq2.Text = Math.Round(Val(TPesoPaq.Text) / 2, 2)
                TNumPaq.Text = 2
            ElseIf Val(TPesoPaq.Text) > 80 AndAlso Val(TPesoPaq.Text) <= 120 Then
                TPesoPaq2.Text = Math.Round(Val(TPesoPaq.Text) / 3, 2)
                TNumPaq.Text = 3
            Else
                TPesoPaq2.Text = Math.Round(Val(TPesoPaq.Text) / 4, 2)
                TNumPaq.Text = 4
            End If

            If Val(TNumPaq.Text) = 0 Then Return
            If Val(TPesoPaq2.Text) = 0 Then Return

            'Se busca el tamaño del bache para sacar un sugerido de dosis

            DVarios.Open("Select * from FORMULAS where CODFOR='" + TCodFor.Text + "' AND LP='" + TLP.Text + "'")
            If DVarios.Count Then
                If Val(TNumPaq.Text) = 1 Then
                    TDosis.Text = TPesoPaq2.Text + " Kg/BACHE DE " + (DFor.RecordSet("TOTALFOR") / 1000).ToString + " Ton"
                Else
                    TDosis.Text = TNumPaq.Text + " PQTS X " + TPesoPaq2.Text + " Kg/BACHE DE " + (DFor.RecordSet("TOTALFOR") / 1000).ToString + " Ton"
                End If

            End If

        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub CBNomVehiculo_TextChanged(sender As Object, e As EventArgs) Handles CBNomVehiculo.TextChanged
        Try
            If CBNomVehiculo.Text = "" Then Return

            DVarios.Open("Select CODINT FROM ARTICULOS WHERE NOMBRE='" + CBNomVehiculo.Text + "'")

            If DVarios.Count Then
                TCodVehiculo.Text = DVarios.RecordSet("CODINT")
            End If

        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub TNuevoTotalFor_KeyUp(sender As Object, e As KeyEventArgs) Handles TNuevoTotalFor.KeyUp
        Try
            If e.KeyCode <> Keys.Enter Then Return

            Dim Porc As Double = 0
            For Each Fila As DataGridViewRow In DGFor.Rows
                Porc = Fila.Cells("PesoMetaB").Value
                Fila.Cells("PesoMeta").Value = Porc * Val(TNuevoTotalFor.Text) / 100
            Next
            OPTodos_Click(Nothing, Nothing)
        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub TSumaIng_TextChanged(sender As Object, e As EventArgs) Handles TSumaIng.TextChanged
        Try
            If Funcion_ManejaVehiculo Then
                If Val(TPesoPaq2.Text) = 0 Then Return
                TPaqxBache.Text = Math.Round(Val(TSumaIng.Text) / Val(TPesoPaq2.Text), 1)
            End If

            If TSumaIng.Text = "" Then Return
            TSumaIng.Text = Math.Round(Val(TSumaIng.Text), 3)

        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub BDivideForm_Click(sender As System.Object, e As System.EventArgs) Handles BDivideForm.Click
        Try

            If ValidaPermiso("Formulas_Editar, Formulas_EditarBasculas") Then
            Else
                MsgBox(DevuelveEvento(CodEvento.USUARIO_PERMISODENEGADO), MsgBoxStyle.Information)
                Return
            End If

            'Dim PresKg As Single = 0
            'Dim NumSacos As Int16 = 0
            'Dim Saldo As Double = 0
            'Dim Basc As Int16 = 0
            'Dim PesoMeta As Single = 0
            'Dim CodMat As String
            'Dim Paso As Int16 = 0
            'Dim Tara As Single = 0
            'Dim PesoEntero As Single = 0
            ''Se recorre cada materia prima para verificar segun unas reglas porque bascula va

            'For Each Fila As DataGridViewRow In DGFor.Rows

            '    PesoMeta = Fila.Cells("PESOMETA").Value
            '    CodMat = Fila.Cells("CODMAT").Value
            '    Paso = Fila.Cells("PASO").Value

            '    'If CodMat = "1419" Then
            '    '    Continue For
            '    'End If

            '    DVarios.Open("Select * from ARTICULOS where TIPO='MP' and CODINT='" + CodMat + "'")
            '    PresKg = 0
            '    Tara = 0
            '    If DVarios.Count Then
            '        PresKg = DVarios.RecordSet("PRESKG")
            '        Tara = DVarios.RecordSet("TARAEMP")
            '    End If

            '    If PresKg = 0 Then
            '        MsgBox("Falta configurar el peso de la materia prima con " + CodMat + " " + Fila.Cells("NOMMAT").Value.ToString, vbInformation)
            '        Return
            '    End If

            '    NumSacos = Int(PesoMeta / PresKg)
            '    Saldo = Math.Round(PesoMeta - (NumSacos * PresKg), 3)
            '    PesoEntero = NumSacos * PresKg

            '    If PesoMeta < 5 And PesoEntero = 0 Then
            '        Fila.Cells("BASCULA").Value = 1
            '        Fila.Cells("A").Value = "PM"
            '        Fila.Cells("TIPOMAT").Value = 5
            '        Fila.Cells("Sacos").Value = 0
            '    ElseIf PesoMeta > 5 And PesoMeta < 25 And PesoEntero = 0 Then
            '        Fila.Cells("BASCULA").Value = 2
            '        Fila.Cells("A").Value = "PM"
            '        Fila.Cells("TIPOMAT").Value = 5
            '        Fila.Cells("Sacos").Value = 0
            '    ElseIf PesoEntero >= PresKg And PesoEntero <= 100 Then
            '        If PresKg > 0 Then
            '            'Çalculamos numero de sacos y despues sacamos el residuo

            '            'Se agregan los ingredientes particionados

            '            If Saldo = 0 Then
            '                Fila.Cells("PESOMETA").Value = NumSacos * PresKg
            '                Fila.Cells("BASCULA").Value = 3
            '                Fila.Cells("A").Value = "PF"
            '                Fila.Cells("TIPOMAT").Value = 6
            '                Fila.Cells("SACOS").Value = NumSacos
            '                Fila.Cells("TARA").Value = Tara * NumSacos
            '            Else
            '                TCodInt.Text = CodMat
            '                TNombre.Text = Fila.Cells("NOMMAT").Value
            '                ModCrea = "NUEVO"
            '                FAgregarFilaDGFor(, , Tara * NumSacos, NumSacos, 3, NumSacos * PresKg)
            '                If Saldo < 5 Then
            '                    Basc = 1
            '                Else
            '                    Basc = 2
            '                End If
            '                Fila.Cells("PESOMETA").Value = Saldo
            '                Fila.Cells("BASCULA").Value = Basc
            '            End If
            '        End If
            '    ElseIf PesoEntero > 100 Then
            '        If PresKg > 0 Then

            '            'Se agregan los ingredientes particionados

            '            If Saldo = 0 Then
            '                Fila.Cells("PESOMETA").Value = NumSacos * PresKg
            '                Fila.Cells("BASCULA").Value = 4
            '                Fila.Cells("A").Value = "PF"
            '                Fila.Cells("TIPOMAT").Value = 6
            '                Fila.Cells("SACOS").Value = NumSacos
            '                Fila.Cells("TARA").Value = Tara * NumSacos
            '            Else
            '                TCodInt.Text = CodMat
            '                TNombre.Text = Fila.Cells("NOMMAT").Value
            '                ModCrea = "NUEVO"
            '                FAgregarFilaDGFor(,, (Tara * NumSacos) + 24, NumSacos, 4, NumSacos * PresKg)
            '                If Saldo < 5 Then
            '                    Basc = 1
            '                Else
            '                    Basc = 2
            '                End If
            '                Fila.Cells("PESOMETA").Value = Saldo
            '                Fila.Cells("BASCULA").Value = Basc
            '            End If
            '        End If
            '    End If
            'Next

            'BGuardar_Click(Nothing, Nothing)
            'BActualizar_Click(Nothing, Nothing)
            'DGFor.Sort(DGFor.Columns("PESOMETA"), System.ComponentModel.ListSortDirection.Descending)

            ''Se reorden el paso de la formula

            'Paso = 1
            'For Each Fila As DataGridViewRow In DGFor.Rows
            '    Fila.Cells("PASO").Value = Paso
            '    Paso += 1
            'Next

            Dim PresKg As Single = 0
            Dim NumSacos As Int16 = 0
            Dim Saldo As Double = 0
            Dim Basc As Int16 = 0
            Dim PesoMeta As Single = 0
            Dim CodMat As String
            Dim Paso As Int16 = 0
            Dim Tara As Single = 0
            Dim PesoEntero As Single = 0
            'Se recorre cada materia prima para verificar segun unas reglas porque bascula va



            For Each Fila As DataGridViewRow In DGFor.Rows

                PesoMeta = Fila.Cells("PESOMETA").Value
                CodMat = Fila.Cells("CODMAT").Value
                Paso = Fila.Cells("PASO").Value

                'If CodMat = "1419" Then
                '    Continue For
                'End If

                DVarios.Open("Select * from ARTICULOS where TIPO='MP' and CODINT='" + CodMat + "'")
                PresKg = 0
                Tara = 0
                If DVarios.Count Then
                    PresKg = DVarios.RecordSet("PRESKG")
                    Tara = DVarios.RecordSet("TARAEMP")
                End If

                If PresKg = 0 Then
                    MsgBox("Falta configurar el peso de la materia prima con " + CodMat + " " + Fila.Cells("NOMMAT").Value.ToString, vbInformation)
                    Return
                End If

                NumSacos = Int(PesoMeta / Math.Round(PresKg, 2))
                If PesoMeta - PresKg > 0 Then
                    Saldo = Math.Round(PesoMeta - (NumSacos * PresKg), 3)
                Else
                    Saldo = 0
                End If

                PesoEntero = NumSacos * PresKg

                If PesoMeta < 5 And PesoEntero = 0 Then
                    Fila.Cells("BASCULA").Value = 1
                    Fila.Cells("A").Value = "PM"
                    Fila.Cells("TIPOMAT").Value = 5
                    Fila.Cells("Sacos").Value = 0
                ElseIf PesoMeta > 5 And PesoMeta < 25 And PesoEntero = 0 Then
                    Fila.Cells("BASCULA").Value = 2
                    Fila.Cells("A").Value = "PM"
                    Fila.Cells("TIPOMAT").Value = 5
                    Fila.Cells("Sacos").Value = 0
                ElseIf PesoEntero >= PresKg And PesoEntero <= 100 Then
                    If PresKg > 0 Then
                        'Çalculamos numero de sacos y despues sacamos el residuo

                        'Se agregan los ingredientes particionados

                        If Saldo = 0 Then
                            Fila.Cells("PESOMETA").Value = NumSacos * PresKg
                            Fila.Cells("BASCULA").Value = 0
                            Fila.Cells("A").Value = "PF"
                            Fila.Cells("TIPOMAT").Value = 6
                            Fila.Cells("SACOS").Value = NumSacos
                            Fila.Cells("TARA").Value = Tara * NumSacos
                        Else
                            TCodInt.Text = CodMat
                            TNombre.Text = Fila.Cells("NOMMAT").Value
                            ModCrea = "NUEVO"
                            FAgregarFilaDGFor("PF", , Tara * NumSacos, NumSacos, 3, NumSacos * PresKg)
                            If Saldo < 5 Then
                                Basc = 1
                            Else
                                Basc = 2
                            End If
                            Fila.Cells("PESOMETA").Value = Saldo
                            Fila.Cells("BASCULA").Value = Basc
                        End If
                    End If
                ElseIf PesoEntero > 100 Then
                    If PresKg > 0 Then

                        'Se agregan los ingredientes particionados

                        If Saldo = 0 Then
                            Fila.Cells("PESOMETA").Value = NumSacos * PresKg
                            Fila.Cells("BASCULA").Value = 4
                            Fila.Cells("A").Value = "PF"
                            Fila.Cells("TIPOMAT").Value = 6
                            Fila.Cells("SACOS").Value = NumSacos
                            Fila.Cells("TARA").Value = Tara * NumSacos
                        Else
                            TCodInt.Text = CodMat
                            TNombre.Text = Fila.Cells("NOMMAT").Value
                            ModCrea = "NUEVO"
                            FAgregarFilaDGFor("PF",, (Tara * NumSacos) + 24, NumSacos, 4, NumSacos * PresKg)
                            If Saldo < 5 Then
                                Basc = 1
                            Else
                                Basc = 2
                            End If
                            Fila.Cells("PESOMETA").Value = Saldo
                            Fila.Cells("BASCULA").Value = Basc
                        End If
                    End If
                End If
            Next

            BGuardar_Click(Nothing, Nothing)
            BActualizar_Click(Nothing, Nothing)
            DGFor.Sort(DGFor.Columns("PESOMETA"), System.ComponentModel.ListSortDirection.Descending)

            'Se reorden el paso de la formula

            Paso = 1
            For Each Fila As DataGridViewRow In DGFor.Rows
                Fila.Cells("PASO").Value = Paso
                Paso += 1
            Next


        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub BAgregar_Click(sender As Object, e As EventArgs) Handles BAgregar.Click
        Try
            If ValidaPermiso("Formulas_Editar") Then
            Else
                MsgBox(DevuelveEvento(CodEvento.USUARIO_PERMISODENEGADO), MsgBoxStyle.Information)
                Exit Sub
            End If
            FAgregarFilaDGFor()
        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub mnParamFylax_Click(sender As Object, e As EventArgs) Handles mnParamFylax.Click
        Try
            FormulacionFylax.FormulacionFylax_Load(Nothing, Nothing)
            FormulacionFylax.TCodFor.Text = TCodFor.Text
            FormulacionFylax.TCodForB.Text = TCodForB.Text
            FormulacionFylax.TLP.Text = TLP.Text
            FormulacionFylax.TNomFor.Text = TNomFor.Text
            FormulacionFylax.BActualizar_Click(Nothing, Nothing)
            FormulacionFylax.ShowDialog()
        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

End Class