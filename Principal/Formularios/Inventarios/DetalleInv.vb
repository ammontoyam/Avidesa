Option Explicit On
Imports System
Imports System.Windows.Forms


Public Class DetalleInv

    Private Rep1 As CrystalRep
    Private ReadOnly OKBCDate As Boolean
    Private FechaIni As String
    Private FechaFin As String
    Private DConsultas As AdoSQL
    Private OKFecha As Boolean = True
    Private DVarios As AdoSQL
    Private DVarios2 As AdoSQL
    Private DMovInv As AdoSQL
    Private DUbic As AdoSQL
    Private DArt As AdoSQL
    Private TipoMat As Int16
    Private Tipo As String
    Private CodNombre As String
    Private Consulta As String
    Private IDInv As String
    Private DSaldosInvPT As AdoSQL

    Private Sub BCDate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BCDate.Click
        Dim RepSap As CrystalRep
        Try

            FechaIni = Format(TFechaIni.Value, "yyyy/MM/dd ") + Format(THoraIni.Value, "HH:mm")
            FechaFin = Format(TFechaFin.Value, "yyyy/MM/dd ") + Format(THoraFin.Value, "HH:mm")

            'Se requiere que si el checkbox OPSaldoBod.checked=true se ponga como fecha inicial el
            'inicio del primer registro de todos los movimientos, por seguridad se lleva al 2012/01/01
            If OPSaldoBod.Checked Then
                FechaIni = "2012/01/01 00:00"
            End If

            If CDate(FechaFin) <= CDate(FechaIni) Then
                MsgBox(DevuelveEvento(CodEvento.SISTEMA_ERROR) + " Fecha Inicial no puede ser Superior o Igual a la Fecha Final", MessageBoxButtons.OK, MessageBoxIcon.Error)
                'MsgBox("La Fecha Inicial no puede ser Superior o Igual a la Fecha Final", MsgBoxStyle.Exclamation, "Error en Fechas")
                OKFecha = False
                Exit Sub
            End If

            DConsultas.Refresh()

            DConsultas.RecordSet("F1") = FechaIni
            DConsultas.RecordSet("F2") = FechaFin
            DConsultas.Update(Me)

            RepSap = New CrystalRep
            With RepSap
                .ServerName = ServidorSQL

                .DataBaseName = NomDB
                .UserId = UserDB
                .Password = PWD
                .Formulas(0) = "PLANTA='" + Planta + "'"
                .Formulas(1) = "FECHA='" + Format(Now, "yyyy/MM/dd HH:mm") + "'"
                .Formulas(2) = "DESDE='" + FechaIni + "'"
                .Formulas(3) = "HASTA='" + FechaFin + "'"
                .Destination = CrystalRep.Destinacion.crToWindows
                .WindowState = FormWindowState.Maximized
                .ChoosePrint = True
                .MaximizeBox = True
                .MinimizeBox = True
            End With
            Rep1 = RepSap


        Catch ex As Exception
            MsgError(ex)
        End Try

    End Sub


    Private Sub DetalleInv_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try

            DConsultas = New AdoSQL("CONSULTAS")
            DVarios = New AdoSQL("VARIOS")
            DVarios2 = New AdoSQL("VARIOS")
            DArt = New AdoSQL("ARTICULOS")
            DMovInv = New AdoSQL("CMOVINV")
            DConsultas.Open("Select * from CONSULTAS")
            DUbic = New AdoSQL("UBICACIONES")

            DArt.Open("select * from ARTICULOS order by CODINT")
            DUbic.Open("Select * from UBICACIONES order by CODUBI")
            DSaldosInvPT = New AdoSQL("DSaldosInvPT")

            DVarios.Open("Delete from MOVINV where FECHA<'" + Format(DateAdd(DateInterval.Month, -3, Now), "yyyy/MM/dd") + "'")

            LLenaComboBox(CUbicacion, DUbic.DataTable, "CODUBI")

            TFechaIni.Value = Now
            TFechaFin.Value = DateAdd(DateInterval.Day, 1, Now)
            THoraIni.Value = CDate(Format(Now, "yyyy/MM/dd 00:00"))
            THoraFin.Value = CDate(Format(Now, "yyyy/MM/dd 00:00"))

        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub BFiltrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BFiltrar.Click
        Try
            Dim Consulta2 As String

            BCDate_Click(Nothing, Nothing)

            If OKFecha = False Then Return
            'CHRONOS
            Consulta2 = "Select * from CMOVINV where TIPOMOV='CHRONOS' "
            Consulta = "Select * from CMOVINV where TIPOMOV='CHRONOS' "
            If OPFis.Checked Then Consulta = "Select * from CMOVINV where TIPOMOV='FISICO' "

            Tipo = ""
            TipoMat = 0

            If OPMP.Checked Then
                Tipo = "MP"
            End If

            If OPPT.Checked Then
                Tipo = "PT"
            End If

            If OPEmpaque.Checked Then
                Tipo = "EM"
            End If

            If OPEmpaque.Checked Then
                Tipo = "ET"
            End If

            If OPLiquidos.Checked Then
                Tipo = "MP"
                TipoMat = 4
            End If

            If OPAditivos.Checked Then
                Tipo = "MP"
                TipoMat = 6
            End If

            If OPPrem.Checked Then
                Tipo = "MP"
                TipoMat = 7
            End If

            If TipoMat > 0 Then
                Consulta += " and TIPO='" + Tipo + "' and TIPOMAT=" + TipoMat.ToString + " "
            Else
                Consulta += " and TIPO='" + Tipo + "' "
            End If


            If TArticulo.TextLength > 0 And CodNombre = "NOMBRE" Then
                Consulta += " and " + CodNombre + " like '%" + TArticulo.Text + "%' "
            End If

            If TArticulo.Text.Length > 0 And CodNombre = "CODINT" Then
                Consulta += " and " + CodNombre + "='" + TArticulo.Text + "' "
                Consulta2 += " and " + CodNombre + "='" + TArticulo.Text + "' "
            End If


            If CUbicacion.Text.Length > 0 Then
                Consulta += " and CODUBI='" + CUbicacion.Text + "' "
            End If

            If TLote.Text.Length > 0 Then
                Consulta += " and LOTE='" + TLote.Text + "' "
            End If

            DMovInv.Open(Consulta)

            If Consulta2.Contains("CODINT") Then
                DVarios2.Open(Consulta2 + " order by ID desc")
                BSaldosPT_Click(Nothing, Nothing)
            End If

            AsignaDataGrid(DGMovInv, DMovInv.DataTable)

            If DGMovInv.RowCount = 0 Then Return
            'TSaldoFin.Text = Format(DGMovInv.Rows(DGMovInv.RowCount - 1).Cells("SALDOFIN").Value, "#,###.00")
            TTotEntradas.Text = Format(SumColumn(DGMovInv, "ENTRA"), "#,###.00")
            TTotSalidas.Text = Format(SumColumn(DGMovInv, "SALE"), "#,###.00")
            TSaldoFin.Text = Format(Eval(SumColumn(DGMovInv, "ENTRA")) + Eval(SumColumn(DGMovInv, "SALE")), "#,###.00")

            If DVarios.Count > 0 Then
                TSaldoPlanta.Text = Format(DVarios2.RecordSet("SALDOFIN"), "#,###.00")
            End If

        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub OPCodInt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OPCodInt.Click
        Try
            CodNombre = "CODINT"
        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub OPNombre_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OPNombre.Click
        Try
            CodNombre = "NOMBRE"
        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub BNuevaConsulta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BNuevaConsulta.Click
        Try
            Limpiar_Habilitar_TextBox(GBFiltrar.Controls, AccionTextBox.Limpiar)
            CUbicacion.Text = ""
            AsignaDataGrid(DGMovInv, Nothing)
        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub BSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BSalir.Click
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub BReportesInv_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BReportesInv.Click
        Try
            ReportesInv.ShowDialog()
        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub DGMovInv_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGMovInv.CellClick
        Try
            If DGMovInv.RowCount = 0 Then Return

            TObservaciones.Text = DGMovInv.Rows(DGMovInv.CurrentRow.Index).Cells("OBSERVACIONES").Value.ToString
            IDInv = DGMovInv.Rows(DGMovInv.CurrentRow.Index).Cells("ID").Value.ToString
            OpModificar.Checked = False
        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub DGMovInv_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DGMovInv.KeyDown
        DGMovInv_CellClick(Nothing, Nothing)
    End Sub

    Private Sub DGMovInv_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DGMovInv.KeyUp
        DGMovInv_CellClick(Nothing, Nothing)
    End Sub

    Private Sub OpModificar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OpModificar.Click
        Try
            TObservaciones.ReadOnly = False
        Catch ex As Exception
            MsgError(ex)
        End Try

    End Sub

    Private Sub BAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BAceptar.Click
        Try
            Dim DMovInvUpd As New AdoSQL("MOVINV")

            DMovInvUpd.Open("select * from MOVINV where ID=" + IDInv)
            If DMovInvUpd.Count > 0 Then
                DMovInvUpd.RecordSet("OBSERVACIONES") = CLeft(TObservaciones.Text, 50)
                DMovInvUpd.Update(Me)
            End If
            TObservaciones.ReadOnly = True
        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub BInventarios_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BInventarios.Click
        Try
            'If DRUsuario("VerRepInv") Then
            If ValidaPermiso("ReportesInventario_Ver") Then
            Else
                MsgBox(DevuelveEvento(CodEvento.USUARIO_PERMISODENEGADO))
                'MsgBox("No tiene permiso para ejecutar la acción solicitada", MsgBoxStyle.Information)
                Exit Sub
            End If

            Inventarios.ShowDialog()
        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub BDespachos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BDespachos.Click

        Try
            'If DRUsuario("Despachos") Then
            If ValidaPermiso("Despachos") Then
            Else
                MsgBox(DevuelveEvento(CodEvento.USUARIO_PERMISODENEGADO))
                'MsgBox("No tiene permiso para ejecutar la acción solicitada", MsgBoxStyle.Information)
                Exit Sub
            End If
            Despachos.ShowDialog()
        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub BAceptarEmp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BAceptarEmp.Click
        'If DRUsuario("RecEmp") = True Then
        If ValidaPermiso("RecibeEmpaqueAlmacen") Then
        Else
            MsgBox(DevuelveEvento(CodEvento.USUARIO_PERMISODENEGADO))
            'MsgBox("No tiene permiso para ejecutar la acción solicitada", MsgBoxStyle.Information)
            Exit Sub
        End If
        RecibePT.ShowDialog()
    End Sub

    Private Sub BReportes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BReportes.Click
        Try
            'If DRUsuario("RepVer") Then
            If ValidaPermiso("Reportes_Ver") Then
            Else
                MsgBox(DevuelveEvento(CodEvento.USUARIO_PERMISODENEGADO))
                'MsgBox("No tiene permiso para ejecutar la acción solicitada", MsgBoxStyle.Information)
                Exit Sub
            End If
            Reportes.ShowDialog()
        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub BSaldosPT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BSaldosPT.Click
        Try
            TSaldoPlanta.Text = ""
            TSaldoUbi.Text = ""
            CUbi.Text = ""
            If OPCodInt.Checked = False OrElse TArticulo.Text = "" Then
                Return
            End If

            DSaldosInvPT.Open("Select * from MOVINV where TIPOMOV='CHRONOS' and CODINT='" + TArticulo.Text.Trim + "' order by ID desc")

            If DSaldosInvPT.Count = 0 Then Return

            TSaldoPlanta.Text = Format(DSaldosInvPT.RecordSet("SALDOFIN"), "#,###.00")

            DVarios.Open("select DISTINCT CODUBI from MOVINV where TIPOMOV='CHRONOS' and CODINT='" + TArticulo.Text.Trim + "'")

            LLenaComboBox(CUbi, DVarios.DataTable, "CODUBI")

        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub
    Private Sub CUbi_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CUbi.SelectedIndexChanged
        Try
            Dim SaldoUbi As Double = 0

            If OPCodInt.Checked = False OrElse TArticulo.Text = "" Then Return
            If DSaldosInvPT.Count = 0 Then Return

            TSaldoUbi.Text = 0

            DSaldosInvPT.Find("CODUBI='" + CUbi.Text + "'")
            If DSaldosInvPT.EOF Then Return

            For Each Saldo As DataRow In DSaldosInvPT.Rows

                If Saldo("CodUbi") = CUbi.Text Then
                    SaldoUbi += Saldo("ENTRA") + Saldo("SALE")
                End If

            Next

            TSaldoUbi.Text = Format(SaldoUbi, "#,###.00")


        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub BAjustarInv_Click(sender As System.Object, e As System.EventArgs) Handles BAjustarInv.Click
        Try
            'If DRUsuario("InvAjuste") Then
            If ValidaPermiso("InventarioAjuste_Editar") Then
            Else
                MsgBox(DevuelveEvento(CodEvento.USUARIO_PERMISODENEGADO))
                'MsgBox("No tiene permiso para ejecutar la acción solicitada", MsgBoxStyle.Information)
                Exit Sub
            End If
            AjustesInv.ShowDialog()
        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub
End Class