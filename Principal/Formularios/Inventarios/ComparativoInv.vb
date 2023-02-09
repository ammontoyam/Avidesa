Option Explicit On
Imports System
Imports System.Windows.Forms
Imports System.Threading.Thread
Imports System.IO


Public Class ComparativoInv
    Private BSResInvent As BindingSource
    Private DCompInv As AdoSQL
    Private DCompInvHist As AdoSQL
    Private DArt As AdoSQL
    Private DMovInv As AdoSQL
    Private DTiposMat As AdoSQL
    Private DVarios As AdoSQL

    Private Rep As CrystalRep
    Private Tipo As String = "MP"
    Private ErrActInv As Boolean
    Private FechaCorte As String
    Private Campos() As String
    Private CeldaX As Integer
    Private CeldaY As Integer

    Private Sub ResInventarios_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            BSResInvent = New BindingSource
            DCompInvHist = New AdoSQL("COMPARATIVOINVHIST")
            DCompInv = New AdoSQL("COMPARATIVOINV")

            DCompInvHist.Open("Delete from COMPARATIVOINVHIST WHERE FECHA<='" + Format(DateAdd(DateInterval.Month, -1, Now), "yyyy/MM/dd") + "'")
            'Valida si en la planta estan habilitadas las funcionalidades
            If ValidaFuncionalidad("Act.Inv.Físico") Then
                TBActInvFisico.Enabled = True
                BActInvFisico.Enabled = True
                TBActInvFisico.Visible = True
                BActInvFisico.Visible = True
            End If
            'Se abre solo para que se puedan asignar los campos de busqueda
            DCompInv.Open("Select * from COMPARATIVOINV WHERE ID=0")
            Campos = {"CodInt@Cód.Int.", "Linea@Linea", "Nombre@Nombre"}
            Campos = AsignaItemsCB(Campos, CBBuscar.ComboBox, DCompInv.DataTable)

            DArt = New AdoSQL("ARTICULOS")
            DMovInv = New AdoSQL("MOVINV")
            DTiposMat = New AdoSQL("TIPOSMAT")
            DTiposMat.Open("Select * from TIPOSMAT")
            DVarios = New AdoSQL("VARIOS")

            DGCompInv.AutoGenerateColumns = False

            'If DRUsuario("VerInvMP") Then
            If ValidaPermiso("InventarioMP_Ver") Then
                OPMP.Checked = True
                Tipo = "MP"
                'ElseIf DRUsuario("VerInvPT") Then
            ElseIf ValidaPermiso("InventarioPT_Ver") Then
                OPPT.Checked = True
                Tipo = "PT"
                'ElseIf DRUsuario("VerInvAD") Then
            ElseIf ValidaPermiso("InventarioAD_Ver") Then
                OPAditivos.Checked = True
                Tipo = "AD"
                'ElseIf DRUsuario("VerInvPR") Then
            ElseIf ValidaPermiso("InventarioPR_Ver") Then
                OPPrem.Checked = True
                Tipo = "PR"
                'ElseIf DRUsuario("VerInvEM") Then
            ElseIf ValidaPermiso("InventarioEM_Ver") Then
                OPEmpaque.Checked = True
                Tipo = "EM"
                'ElseIf DRUsuario("VerInvET") Then
            ElseIf ValidaPermiso("InventarioET_Ver") Then
                OPEtiquetas.Checked = True
                Tipo = "ET"
            End If

            FRefrescaDG_Click(Nothing, Nothing)

        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub MnAdicionarArt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnAdicionarArt.Click
        Try
            Dim CodInt As String = ""
            If InputBox.InputBox("Adicionar Artículo", "Ingrese el código del artículo a adicionar", CodInt) = DialogResult.Cancel Then Return

            If CodInt = "" Then
                MsgBox(DevuelveEvento(CodEvento.SISTEMA_FALTACAMPO) + " código de artículo", MessageBoxButtons.OK, MessageBoxIcon.Information)
                'MsgBox("El código de artículo ingresado no es válido", MsgBoxStyle.Information)
                Return
            End If

            DArt.Open("select * from ARTICULOS where CODINT='" + CodInt + "'")
            If DArt.Count = 0 Then
                MsgBox(DevuelveEvento(CodEvento.BD_REGNOEXISTE) + "el Producto ingresado no existe", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return
            End If

            DCompInv.Open("Select * from COMPARATIVOINV WHERE ID=0")

            DCompInv.AddNew()
            DCompInv.RecordSet("CODINT") = DArt.RecordSet("CODINT")
            DCompInv.RecordSet("NOMBRE") = DArt.RecordSet("NOMBRE")
            DCompInv.RecordSet("TIPO") = DArt.RecordSet("TIPO")
            'Buscamos el subtipo si es MP (AD,PR)
            If DArt.RecordSet("TIPOMAT") = 6 Or DArt.RecordSet("TIPOMAT") = 7 Then
                DTiposMat.Find("TIPOMAT=" + DArt.RecordSet("TIPOMAT").ToString)
                If Not DTiposMat.EOF Then DCompInv.RecordSet("TIPO") = DTiposMat.RecordSet("TIPO")
            End If
            DCompInv.RecordSet("LINEA") = DArt.RecordSet("LINEA")
            DCompInv.Update(Me)
            FRefrescaDG_Click(Nothing, Nothing)


        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub BSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BSalir.Click
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub MnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnSalir.Click
        BSalir_Click(Nothing, Nothing)
    End Sub


    Private Sub DGResInven_CellEndEdit(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGCompInv.CellEndEdit
        Try

            Select Case DGCompInv.Columns(e.ColumnIndex).Name.ToUpper
                Case "INVMIN", "ENTPEND", "SALPEND", "OBSERVBODEGA", "OBSERVCOSTOS", "OBSERVMAQUILAS", "OBSERVVENTAS"
                Case Else
                    CeldaX = -99
                    CeldaY = -99
                    Return
            End Select

            CeldaX = e.RowIndex
            CeldaY = e.ColumnIndex

            Dim CodInt As String = DGCompInv.Rows(e.RowIndex).Cells("CODINT").Value

            If CodInt Is Nothing Then Return

            DCompInv.Open("Select * from COMPARATIVOINV where CODINT='" + CodInt + "'")

            If IsNothing(DGCompInv.Rows(e.RowIndex).Cells(e.ColumnIndex).Value) = False AndAlso DCompInv.Count > 0 Then
                DCompInv.RecordSet(DGCompInv.Columns(e.ColumnIndex).Name.ToUpper) = DGCompInv.Rows(e.RowIndex).Cells(e.ColumnIndex).Value
                DCompInv.Update(Me)
            End If
            FRefrescaDG_Click(Nothing, Nothing)
        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub FRefrescaDG_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FRefrescaDG.Click
        Try
            If Tipo = "" Then Return

            DCompInv.Open("Select * from COMPARATIVOINV where TIPO='" + Tipo + "' order by LINEA,NOMBRE")
            AsignaDataGrid(DGCompInv, DCompInv.DataTable)
            If DCompInv.Count = 0 Then Return
            FSeparador_Click(Nothing, Nothing)
            FResetInv_Click(Nothing, Nothing)
            FRevEstadoCierre_Click(Nothing, Nothing)
            FCalcTot_Click(Nothing, Nothing)

            If CeldaX >= 0 AndAlso CeldaY >= 0 AndAlso DGCompInv.Rows.Count > 0 Then DGCompInv.CurrentCell = DGCompInv(CeldaY, CeldaX)

        Catch ex As System.InvalidOperationException
            ErrActInv = True
        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub BActualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BActualizar.Click
        Try
            ResInventarios_Load(Nothing, Nothing)
        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub



    Private Sub FSeparador_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FSeparador.Click

        Try

            'Objeto tipo fuente para mostrar la linea de producto
            Dim Fuente As Font
            Fuente = New Font("Arial", 10, System.Drawing.FontStyle.Bold)

            Dim CampoSep As String = "LINEA"
            Dim DG As DataGridView = DGCompInv

            DG.EnableHeadersVisualStyles = False
            'DGVerifCons.ColumnHeadersDefaultCellStyle.BackColor = Color.Blue
            DG.ColumnHeadersVisible = True

            'recorre toda la grilla de baches para agregar una fila para separar el final de un código de material
            Dim Valor As String
            Dim ValorAnt As String = ""

            'Se pone a las columnas del datagrid la propiedad de que no se pueda organizar para no dañar la tabla
            For Each Col As DataGridViewColumn In DG.Columns
                Col.SortMode = DataGridViewColumnSortMode.NotSortable
            Next
            For Each Fila As DataGridViewRow In DG.Rows
                If Fila.Index = 0 Then
                    ValorAnt = Fila.Cells(CampoSep).Value.ToString
                    Valor = 0
                    DG.Rows.Insert(Fila.Index, 1)
                    DG.Rows(Fila.Index - 1).Cells("NOMBRE").Value = ValorAnt
                    DG.Rows(Fila.Index - 1).Cells("NOMBRE").Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                    DG.Rows(Fila.Index - 1).Cells("NOMBRE").Style.Font = Fuente
                    DG.Rows(Fila.Index - 1).Cells("NOMBRE").Style.ForeColor = Color.White
                    DG.Rows(Fila.Index - 1).DefaultCellStyle.BackColor = Color.SteelBlue
                    Continue For
                End If
                If Fila.Cells(CampoSep).Value Is Nothing OrElse Fila.Cells(CampoSep).Value.ToString Is String.Empty Then Continue For

                If Fila.Index <= DG.RowCount - 1 Then
                    Valor = Fila.Cells(CampoSep).Value.ToString
                    If Valor = ValorAnt Then
                    Else
                        DG.Rows.Insert(Fila.Index, 1)
                        DG.Rows(Fila.Index - 1).Cells("NOMBRE").Value = Valor
                        DG.Rows(Fila.Index - 1).Cells("NOMBRE").Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                        DG.Rows(Fila.Index - 1).Cells("NOMBRE").Style.Font = Fuente
                        DG.Rows(Fila.Index - 1).Cells("NOMBRE").Style.ForeColor = Color.White
                        DG.Rows(Fila.Index - 1).DefaultCellStyle.BackColor = Color.SteelBlue
                    End If
                    ValorAnt = Valor
                End If

            Next

        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub


    Private Sub OPMP_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OPMP.Click
        'If DRUsuario("VerInvMP") Then
        If ValidaPermiso("InventarioMP_Ver") Then
        Else
            MsgBox(DevuelveEvento(CodEvento.USUARIO_PERMISODENEGADO))
            ResInventarios_Load(Nothing, Nothing)
            Exit Sub
        End If
        Tipo = "MP"
        FRefrescaDG_Click(Nothing, Nothing)
    End Sub

    Private Sub OPAditivos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OPAditivos.Click
        'If DRUsuario("VerInvAD") Then
        If ValidaPermiso("InventarioAD_Ver") Then
        Else
            MsgBox(DevuelveEvento(CodEvento.USUARIO_PERMISODENEGADO))
            ResInventarios_Load(Nothing, Nothing)
            Exit Sub
        End If
        Tipo = "AD"
        FRefrescaDG_Click(Nothing, Nothing)
    End Sub


    Private Sub OPPrem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OPPrem.Click
        'If DRUsuario("VerInvPR") Then
        If ValidaPermiso("InventarioPR_Ver") Then
        Else
            MsgBox(DevuelveEvento(CodEvento.USUARIO_PERMISODENEGADO))
            ResInventarios_Load(Nothing, Nothing)
            Exit Sub
        End If
        Tipo = "PR"
        FRefrescaDG_Click(Nothing, Nothing)
    End Sub

    Private Sub OPPT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OPPT.Click
        'If DRUsuario("VerInvPT") Then
        If ValidaPermiso("InventarioPT_Ver") Then
        Else
            MsgBox(DevuelveEvento(CodEvento.USUARIO_PERMISODENEGADO))
            ResInventarios_Load(Nothing, Nothing)
            Exit Sub
        End If
        Tipo = "PT"
        FRefrescaDG_Click(Nothing, Nothing)

    End Sub

    Private Sub OPEmpaque_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OPEmpaque.Click
        'If DRUsuario("VerInvEM") Then
        If ValidaPermiso("InventarioEM_Ver") Then
        Else
            MsgBox(DevuelveEvento(CodEvento.USUARIO_PERMISODENEGADO))
            ResInventarios_Load(Nothing, Nothing)
            Exit Sub
        End If
        Tipo = "EM"
        FRefrescaDG_Click(Nothing, Nothing)

    End Sub

    Private Sub OPEtiquetas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OPEtiquetas.Click
        'If DRUsuario("VerInvET") Then
        If ValidaPermiso("InventarioET_Ver") Then
        Else
            MsgBox(DevuelveEvento(CodEvento.USUARIO_PERMISODENEGADO))
            ResInventarios_Load(Nothing, Nothing)
            Exit Sub
        End If
        Tipo = "ET"
        FRefrescaDG_Click(Nothing, Nothing)

    End Sub

    Private Sub TimSeg_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TimSeg.Tick
        Try

            TSeg.Text = Eval(TSeg.Text) + 1

            If Eval(TSeg.Text) > 10000 Then TSeg.Text = 1

            If Eval(TSeg.Text) Mod 1 = 0 AndAlso ErrActInv Then
                FRefrescaDG_Click(Nothing, Nothing)
                ErrActInv = False
            End If

        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub DGResInven_CellLeave(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGCompInv.CellLeave
        DGCompInv.Rows(e.RowIndex).ErrorText = String.Empty
    End Sub


    Private Sub FResetInv_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FResetInv.Click
        Try
            'Hace un ciclo por toda la grilla para evaluar si debe resear los valores para el inventariofisico y sistema UNO

            If ReadFechasCierre(Tipo, ClaseFecha.ULTRESET) = Format(Now, "yyyy/MM/dd") Then
                GBFiltrar.Enabled = True
                DGCompInv.Enabled = True
                Return
            End If

            mnSalir.Enabled = False
            BSalir.Enabled = False

            Dim CodIntAct As String = ""
            Dim ContFilas As Integer = 0

            'Asignamos la fecha de corte para el inventario

            If Tipo = "PT" Then
                'En fecha corte asignamos a fecha del último cierre de inventario físico para PT
                FechaCorte = ReadFechasCierre(Tipo, ClaseFecha.FISICO)
            Else
                FechaCorte = Format(Now, "yyyy/MM/dd 00:00")
            End If

            BarraProgreso.Value = 0
            TEstadoBarra.Text = "Verificando reinicio inventario físico"
            'Application.DoEvents()



            For Each FilaDGResInv As DataGridViewRow In DGCompInv.Rows

                If FilaDGResInv.Cells("CODINT").Value Is Nothing Then Continue For
                ContFilas += 1

                CodIntAct = FilaDGResInv.Cells("CODINT").Value.ToString
                'Se revisa si no hay movimiento de inventario FISICO 
                DMovInv.Open("Select * from MOVINV where TIPOMOV='FISICO' and FECHA>='" + FechaCorte + "' and  CODINT='" + CodIntAct + "'")

                If DMovInv.Count = 0 Then
                    DCompInv.Open("Update COMPARATIVOINV set INVFISICO=0 where CODINT='" + CodIntAct + "'")
                End If
                DCompInv.Open("Update COMPARATIVOINV set INVUNO=0 where CODINT='" + CodIntAct + "'")
                BarraProgreso.Value = Int(ContFilas / DGCompInv.RowCount * 100)
                TEstadoBarra.Text = "ACTUALIZANDO INVENTARIO " + FilaDGResInv.Cells("NOMBRE").Value.ToString
                Application.DoEvents()
            Next

            BarraProgreso.Value = 100
            TEstadoBarra.Text = "PROCESO ACTUALIZACIÓN FINALIZADO"

            WriteFechasCierre(Tipo, Format(Now, "yyyy/MM/dd"), ClaseFecha.ULTRESET)

            mnSalir.Enabled = True
            BSalir.Enabled = True
            GBFiltrar.Enabled = True
            DGCompInv.Enabled = True
        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub


    Private Sub FRevEstadoCierre_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FRevEstadoCierre.Click
        Try

            DTiposMat.Find("TIPO='" + Tipo + "'")
            If ReadFechasCierre(Tipo, ClaseFecha.COMPARATIVOINV) >= Format(Now, "yyyy/MM/dd") Then
                TEstadoInv.Image = Iconos.Images(0)
                TEstadoInv.Text = "COMPARATIVO DE INVENTARIOS DE " + DTiposMat.RecordSet("DESCRIPCION") + " CERRADO"
                TEstadoInv.BackColor = Color.LightCoral
            Else
                TEstadoInv.Image = Iconos.Images(1)
                TEstadoInv.Text = "COMPARATIVO DE INVENTARIOS DE ".ToUpper + DTiposMat.RecordSet("DESCRIPCION") + " SIN CERRAR"
                TEstadoInv.BackColor = Color.Lime
            End If

            'Trae las fechas ce cierre de inventarios de uno y físico

            TFechaActUNO.Text = ReadFechasCierre(Tipo, ClaseFecha.UNO)
            TFechaCierreInvFisico.Text = ReadFechasCierre(Tipo, ClaseFecha.FISICO)

        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub BCerrarInv_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BCerrarInv.Click
        Try
            If Tipo = "" Then Return

            'If DRUsuario("ModInv" + Tipo) Then
            If ValidaPermiso("Inventario" + Tipo + "_Editar") Then
            Else
                MsgBox(DevuelveEvento(CodEvento.USUARIO_PERMISODENEGADO))
                Return
            End If

            If ReadFechasCierre(Tipo, ClaseFecha.COMPARATIVOINV) = Format(Now, "yyyy/MM/dd") Then
                MsgBox(DevuelveEvento(CodEvento.SISTEMA_ERROR) + "el tipo " + Tipo + " ya está cerrado", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                ' MsgBox("El comparativo del inventario para el tipo " + Tipo + " ya está cerrado", vbInformation)
                Return
            End If

            Resp = MsgBox("Seguro desea cerrar la edición de inventario para el tipo seleccionado", vbYesNo + vbInformation)
            If Resp = vbNo Then Return

            WriteFechasCierre(Tipo, Format(Now, "yyyy/MM/dd"), ClaseFecha.COMPARATIVOINV)
            DevuelveEvento(CodEvento.INVENTARIO_CIERRE + "tipo: " + Tipo + "")
            'Evento("Cierra resumen inventarios tipo: " + Tipo)
            FExportExcel_Click(Nothing, Nothing)
            FGuardaHist_Click(Nothing, Nothing)
            FRevEstadoCierre_Click(Nothing, Nothing)

        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub


    Private Sub MnAdicionaTodos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnAdicionaTodos.Click
        Try
            Resp = MsgBox("Seguro desea adicionar todo el catalogo de articulos a la tabla", vbYesNo + vbInformation)
            If Resp = vbNo Then Return

            DArt.Open("select * from ARTICULOS order BY TIPO")

            For Each DRArt As DataRow In DArt.Rows
                DCompInv.Open("Select * from COMPARATIVOINV WHERE CODINT='" + DRArt("CODINT") + "'")

                If DCompInv.Count > 0 Then Continue For

                DCompInv.AddNew()
                DCompInv.RecordSet("CODINT") = DRArt("CODINT")
                DCompInv.RecordSet("NOMBRE") = DRArt("NOMBRE")
                DCompInv.RecordSet("TIPO") = DRArt("TIPO")
                'Buscamos el subtipo si es MP (AD,PR)
                If DArt.RecordSet("TIPOMAT") = 6 Or DArt.RecordSet("TIPOMAT") = 7 Then
                    DTiposMat.Find("TIPOMAT=" + DRArt("TIPOMAT").ToString)
                    If Not DTiposMat.EOF Then DCompInv.RecordSet("TIPO") = DTiposMat.RecordSet("TIPO")
                End If
                DCompInv.RecordSet("LINEA") = DRArt("LINEA")
                DCompInv.Update(Me)
            Next



            FRefrescaDG_Click(Nothing, Nothing)
            MsgBox(DevuelveEvento(CodEvento.SISTEMA_PROCESOFINALIZADO))


        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub BImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BImprimir.Click
        Try
            Rep = New CrystalRep

            With Rep
                .ServerName = ServidorSQL
                .DataBaseName = NomDB
                .UserId = UserDB
                .Password = PWD
                .Formulas(0) = "PLANTA='" + Planta + "'"
                .Formulas(1) = "FECHA='" + Format(Now, "yyyy/MM/dd HH:mm") + "'"
                .SelectionFormula = "{COMPARATIVOINV.TIPO}='" + Tipo + "'"
                .Destination = CrystalRep.Destinacion.crToWindows
                .WindowState = FormWindowState.Maximized
                .ChoosePrint = True
                .MaximizeBox = True
                .MinimizeBox = True
            End With
            Rep.ReportFileName = RutaRep + "rpComparativoInv.rpt"
            Rep.PrintReport()

        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub TimIni_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TimIni.Tick
        Try
            TimIni.Enabled = False
            'Se llama el boton de reset
            'GBFiltrar.Enabled = False
            'DGResInv.Enabled = False
            FRevEstadoCierre_Click(Nothing, Nothing)

        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub FCalcTot_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FCalcTot.Click
        Try

            Dim CadenaFiltrar As String = ""

            CadenaFiltrar = "TIPO='" + Tipo + "'"


            DVarios.Open("Select * from LINEASPROD where LINEA='" + TBuscar.Text + "'")

            If CBBuscar.Text.ToUpper = "LINEA" AndAlso TBuscar.Text <> "" AndAlso DVarios.Count > 0 Then
                CadenaFiltrar += " and LINEA='" + TBuscar.Text + "'"
            End If

            DVarios.Open("Select SUM(INVMIN) as SUMINVMIN, SUM(INVFISICO) AS SUMINVFISICO, SUM(ENTPEND) AS SUMENTPEND, " +
                         "SUM(SALPEND) AS SUMSALPEND, SUM(INVUNO) AS SUMINVUNO from COMPARATIVOINV where " + CadenaFiltrar)

            If DVarios.Count = 0 Then Return

            If Not IsDBNull(DVarios.RecordSet("SUMINVMIN")) Then TSumInvMin.Text = Format(DVarios.RecordSet("SUMINVMIN"), "0.00")
            If Not IsDBNull(DVarios.RecordSet("SUMINVFISICO")) Then TSumInvFisico.Text = Format(DVarios.RecordSet("SUMINVFISICO"), "0.00")
            If Not IsDBNull(DVarios.RecordSet("SUMENTPEND")) Then TSumEntPend.Text = Format(DVarios.RecordSet("SUMENTPEND"), "0.00")
            If Not IsDBNull(DVarios.RecordSet("SUMSALPEND")) Then TSumSalPend.Text = Format(DVarios.RecordSet("SUMSALPEND"), "0.00")
            If Not IsDBNull(DVarios.RecordSet("SUMINVUNO")) Then TSumInvUno.Text = Format(DVarios.RecordSet("SUMINVUNO"), "0.00")

        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub BActInvUNO_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BActInvUNO.Click
        Try
            Inventarios.BActInvUNO_Click(Nothing, Nothing)
            BActualizar_Click(Nothing, Nothing)
        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub BBorrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BBorrar.Click
        Try

            Resp = MsgBox("¿Seguro desea eliminar el(los) articulo(s) seleccionado(s) del comparativo de inventarios?", vbYesNo + vbInformation)
            If Resp = vbNo Then Return

            Dim CadenaBorrar As String = ""

            CadenaBorrar = " CODINT IN("
            For Each FilaBorrar As DataGridViewRow In DGCompInv.SelectedRows
                CadenaBorrar += "'" + FilaBorrar.Cells("CODINT").Value + "'" + ","
            Next

            If CadenaBorrar = " CODINT IN(" Then Return

            CadenaBorrar = CLeft(CadenaBorrar, InStrRev(CadenaBorrar, ",") - 1)

            CadenaBorrar += ")"

            DVarios.Open("Delete FROM COMPARATIVOINV where " + CadenaBorrar)

            MsgBox(DevuelveEvento(CodEvento.SISTEMA_PROCESOFINALIZADO))
            FRefrescaDG_Click(Nothing, Nothing)


        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub


    Private Sub MnMenuDGNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnMenuDGNuevo.Click
        MnAdicionarArt_Click(Nothing, Nothing)
    End Sub

    Private Sub MnMenuDGEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnMenuDGEliminar.Click
        BBorrar_Click(Nothing, Nothing)
    End Sub

    Private Sub TBuscar_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TBuscar.KeyUp, CBBuscar.KeyUp
        Try
            If CBBuscar.Text = "" Then
                CBBuscar.Focus()
                MsgBox(DevuelveEvento(CodEvento.SISTEMA_FALTACAMPO) + "a buscar", MessageBoxButtons.OK, MessageBoxIcon.Information)
                ' MsgBox("Debe seleccionar el campo a buscar", MsgBoxStyle.Exclamation)
                TBuscar.Text = ""
                Exit Sub
            End If

            If TBuscar.Text = "" Then
                FRefrescaDG_Click(Nothing, Nothing)
                Exit Sub
            End If

            Dim x As Integer
            Dim Hallado As Boolean

            x = CBBuscar.SelectedIndex

            'If TipoCampo(Campos(x), DTMat) <> "String" AndAlso e.KeyCode <> Keys.Enter Then Exit Sub
            BusquedaDG(DGCompInv, DCompInv.DataTable, TBuscar.Text, Campos(x), Hallado)

            If Hallado = False Then
                'CBBuscar.Focus()
                'MsgBox("Registro no encontrado", MsgBoxStyle.Information)
                Exit Sub
            End If

            If CBBuscar.Text.ToUpper = "LINEA" Then FCalcTot_Click(Nothing, Nothing)

        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub BMateriales_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BMateriales.Click
        Try
            'If DRUsuario("MatPVer") Or DRUsuario("MatPMod") Then
            If ValidaPermiso("Materiales_Ver, Materiales_Editar") Then
            Else
                MsgBox(DevuelveEvento(CodEvento.USUARIO_PERMISODENEGADO))
                Exit Sub
            End If
            Materiales.ShowDialog()
        Catch ex As Exception
            MsgError(ex)
        End Try

    End Sub

    Private Sub BProductos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BProductos.Click
        Try
            'If DRUsuario("ProdVer") Or DRUsuario("ProdMod") Then
            If ValidaPermiso("Productos_Ver, Productos_Editar") Then
            Else
                MsgBox(DevuelveEvento(CodEvento.USUARIO_PERMISODENEGADO))
                Exit Sub
            End If
            Productos.ShowDialog()
        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub BAjustarInv_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BAjustarInv.Click
        Try
            'If DRUsuario("InvAjuste") Then
            If ValidaPermiso("InventarioAjuste_Editar") Then
            Else
                MsgBox(DevuelveEvento(CodEvento.USUARIO_PERMISODENEGADO))
                Exit Sub
            End If
            AjustesInv.ShowDialog()
        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub DGResInv_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGCompInv.CellClick
        Try

            If e.ColumnIndex < 0 OrElse e.RowIndex < 0 Then Return

            If Tipo = "" Then Return

            If TEstadoInv.Text.Contains("CERRADO") Then
                DGCompInv.Rows(e.RowIndex).ErrorText = "Inventario Cerrado"
                Return
            End If

            DGCompInv.ReadOnly = True

            'If DRUsuario("ModInv" + Tipo) Then
            If ValidaPermiso("Inventario" + Tipo + "_Editar") Then
            Else
                DGCompInv.Rows(e.RowIndex).ErrorText = "No tiene permiso para ejecutar la acción solicitada"
                Return
            End If

            Select Case DGCompInv.Columns(e.ColumnIndex).Name.ToUpper

                Case "INVMIN", "ENTPEND", "SALPEND", "OBSERVBODEGA", "OBSERVCOSTOS", "OBSERVMAQUILAS", "OBSERVVENTAS"
                    DGCompInv.ReadOnly = False
            End Select

        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub FExportExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FExportExcel.Click
        Try


            Dim objExcel As Microsoft.Office.Interop.Excel.Application
            Dim WorkBook As Microsoft.Office.Interop.Excel.Workbook
            Dim Cont As Integer
            Dim iCol As Integer
            Dim Heading() As String
            Dim CantCamp() As Integer
            Dim FilaForm() As String
            Dim H As Integer
            Dim V As Integer
            Dim i As Integer
            Dim NomArchivo As String = Ruta + "CompInvent\" + Tipo + "\" + Tipo + "_" + Format(Now, "yyMMdd_HHmm") + ".xlsx"


            'Todos los ciclos van hasta DGResInv.Columns.Count-2 o Cont-3 ya que no se quiere mostrar las ultimas 2 columnas
            Cont = DGCompInv.Columns.Count

            ReDim Heading(Cont)
            ReDim CantCamp(Cont)
            ReDim FilaForm(Cont)


            'Encabezados
            For iCol = 0 To Cont - 3
                If DGCompInv.Columns(iCol).Visible = False Then Continue For
                Heading(iCol) = DGCompInv.Columns(iCol).Name
            Next

            objExcel = New Microsoft.Office.Interop.Excel.Application With {
                .Visible = True, 'lo hacemos visible
                .SheetsInNewWorkbook = 1 'decimos cuantas hojas queremos en el nuevo documento
                }
            'objExcel.Workbooks.Add() ' añadimos el objeto al workbook
            WorkBook = objExcel.Workbooks.Add

            With objExcel.ActiveSheet

                'Formato de las celdas de los encabezados
                .Range(.Cells(1, 1), .Cells(1, Cont - 3)).Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
                .Range(.Cells(1, 1), .Cells(1, Cont - 3)).Font.Bold = True
                .Range(.Cells(1, 1), .Cells(1, Cont - 3)).Font.color = Color.White
                .Range(.Cells(1, 1), .Cells(1, Cont - 3)).interior.color = Color.SteelBlue
                '    .Range(.Cells(1, 1), .Cells(1, Cont)).AutoFilter = True
                'Ingresamos el texto a las celdas
                For i = 1 To Cont - 2 Step 1
                    If DGCompInv.Columns(i).Visible = False Then Continue For
                    .Cells(1, i) = Heading(i - 1)
                    .Cells(1, i).EntireColumn.AutoFit()
                Next i

            End With

            V = 2 ' fila donde comenzara a insertar los datos
            H = 1 ' columna donde comenzara a insertar los datos

            i = 0

            While i <= Cont - 2
                CantCamp(i) = i
                i += 1
            End While


            For Each DGExport As DataGridViewRow In DGCompInv.Rows
                For i = 0 To Cont - 3
                    If DGExport.Cells(i).Visible = False Then Continue For
                    With objExcel.ActiveSheet
                        If DGExport.Cells(i).Value Is Nothing Then
                            .range(.Cells(V, 1), .Cells(V, Cont - 3)).Interior.Color = Color.SteelBlue
                            Continue For
                        End If

                        .Cells(V, H + CantCamp(i)) = DGExport.Cells(i).Value.ToString
                        'If i = Cont - 1 Then objExcel.ActiveSheet.Cells(V, H + CantCamp(i)) = Format(RecordSet(i), ".00")
                    End With
                Next
                V += 1

            Next

            If File.Exists(NomArchivo) Then File.Delete(NomArchivo)

            WorkBook.SaveAs(NomArchivo)
            WorkBook.Close()
            objExcel.Quit()

        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub


    Private Sub FGuardaHist_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FGuardaHist.Click
        Try
            'Crea una copia de la tabla y la guarda con fecha para poder generar consulta

            DCompInvHist.Open("Select * from COMPARATIVOINVHIST where ID=0")

            For Each FilaDG As DataGridViewRow In DGCompInv.Rows
                If FilaDG.Cells("CODINT").Value Is Nothing Then Continue For
                DCompInvHist.AddNew()
                For i = 0 To DGCompInv.ColumnCount - 1
                    If DGCompInv.Columns(i).Name.ToUpper = "ID" Then Continue For
                    If IsNothing(FilaDG.Cells(DGCompInv.Columns(i).Name.ToUpper).Value) = False Then
                        DCompInvHist.RecordSet(DGCompInv.Columns(i).Name.ToUpper) = FilaDG.Cells(DGCompInv.Columns(i).Name.ToUpper).Value
                    End If

                Next
                DCompInvHist.RecordSet("FECHA") = Format(Now, "yyyy/MM/dd")
                DCompInvHist.RecordSet("TIPO") = Tipo
                DCompInvHist.Update(Me)

            Next
            MsgBox("Registros almacenados con fecha de cierre " + ReadFechasCierre(Tipo, ClaseFecha.COMPARATIVOINV), vbInformation)
        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub BReportesInv_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BReportesInv.Click
        'If DRUsuario("VerRepInv") Then
        If ValidaPermiso("ReportesInventario_Ver") Then
        Else
            MsgBox(DevuelveEvento(CodEvento.USUARIO_PERMISODENEGADO))
            Exit Sub
        End If
        DetalleInv.ShowDialog()
    End Sub

    Private Sub BActInvFisico_Click(sender As System.Object, e As System.EventArgs) Handles BActInvFisico.Click
        Try
            Dim RutaArchivo As String = ""
            Dim LecturaArchivo As StreamReader
            Dim ContenidoArchivo As String = ""
            Dim Renglones() As String
            Dim Campos() As String
            Dim Invent As New DescInvent
            Dim RutaBackup As String = Ruta + "Inventarios\Backup\Inv" + Now.ToString("yyyyMMdd_HH_mm") + ".inv"


            OpenFile.InitialDirectory = ReadConfigVar("RutaInv")

            OpenFile.Filter = "inv files (*.inv)|*.inv"
            OpenFile.FilterIndex = 0
            OpenFile.RestoreDirectory = True

            If (OpenFile.ShowDialog() = DialogResult.OK) Then
                ''TRuta.Text = OpenFile.FileName
            Else
                MsgBox(DevuelveEvento(CodEvento.SISTEMA_PROCESOCANCELADO))
                Return
            End If


            'Realizamos la lectura del archivo
            RutaArchivo = Ruta + "CopyArchivoInv.txt"
            FileCopy(OpenFile.FileName, RutaArchivo)

            'Creamos copia de los archivos de inventario

            FileCopy(OpenFile.FileName, RutaBackup)

            LecturaArchivo = File.OpenText(RutaArchivo)
            ContenidoArchivo = LecturaArchivo.ReadToEnd
            LecturaArchivo.Close()

            'Separamos el archivo en renglones para agregarlo a una datatable

            Renglones = Split(ContenidoArchivo, vbCrLf)

            'Recorremos los renglones para almacenarlos en un datatable

            'Cadena += Fila.DataBoundItem("CODMAT").ToString + Separador
            'Cadena += Fila.DataBoundItem("NOMMAT").ToString + Separador
            'Cadena += Fila.DataBoundItem("LOTE").ToString + Separador
            'Cadena += Fila.DataBoundItem("CANTIDAD").ToString + Separador
            'Cadena += Fila.DataBoundItem("CANTIDADKG").ToString + Separador
            'Cadena += Fila.DataBoundItem("UBICACION").ToString + Separador
            ''Cadena += Fila.DataBoundItem("CONDICION").ToString + Separador

            For i = 0 To Renglones.Length - 2

                Campos = Split(Renglones(i), ";")

                If Campos.Length < 2 Then Continue For

                'Cargamos el inventario fisico

                With Invent
                    .CodInt = Campos(0)
                    .Cantidad = Campos(4)
                    .TipoInv = DescInvent.TipoInvent.FISICO
                    .Lote = Campos(2)
                    .Detalle = DescInvent.DetOperacion.ENMP
                    .Ubicacion = Campos(5)
                    .Condicion = Campos(6)
                    .Unds = Campos(3)
                    .PromSac = Campos(7)
                    .Usuario = UsuarioPrincipal
                    .Inventario()
                End With

                Sleep(10)

            Next 'Cambio de renglon


            Evento("Carga inventario físico desde archivo plano generado por ChronoStock")

            'Se elimina el archivo para que no vuelvan a subir el mismo inventario

            File.Delete(OpenFile.FileName)
            File.Delete(RutaArchivo)

            BActualizar_Click(Nothing, Nothing)

            MsgBox(DevuelveEvento(CodEvento.SISTEMA_PROCESOFINALIZADO))


        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub


End Class