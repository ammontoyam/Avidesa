Option Explicit On

Imports System.Data.Common
Imports System.Windows.Forms
Imports System.Data
Imports ClassLibrary

Public Class EntraConsumos
    Private DConsumos As AdoSQL
    Private DBaches As AdoSQL
    Private DDatosFor As AdoSQL
    Private DCortes As AdoSQL
    Private DTolvas As AdoSQL
    Private DArt As AdoSQL

    Private DFila() As DataRow
    Private DR As DataRow
    Private Row As Long


    Private Sub EntraConsumos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try


            DBaches = New AdoSQL("Baches")
            DConsumos = New AdoSQL("Consumos")
            DDatosFor = New AdoSQL("DatosFor")
            DCortes = New AdoSQL("Cortes")
            DTolvas = New AdoSQL("Tolvas")
            DArt = New AdoSQL("ARTICULOS")

            DArt.Open("select * from ARTICULOS order by CODINT")

            'Se envia el textbox al cual solo se permite el ingreso de números
            TextNum(TContador)
            TextNum(TCantidad, True)

        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub TContador_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TContador.KeyDown
        Try
            If e.KeyData <> Keys.Enter Then Exit Sub

            If TContador.Text = "" Then Exit Sub
            DBaches.Open("Select * from BACHES where CONT=" + TContador.Text)

            If DBaches.Count = 0 Then
                MsgBox(DevuelveEvento(CodEvento.ARCHIVO_NOEXISTE), vbInformation)
                BCancelar_Click(Nothing, Nothing)
                Exit Sub
            End If

            DConsumos.Open("select * from CONSUMOS where CONT=" + TContador.Text + " order by NOMMAT")

            TCodForB.Text = DBaches.RecordSet("CodForB").ToString
            TNomFor.Text = DBaches.RecordSet("NomFor").ToString
            TCodFor.Text = DBaches.RecordSet("CodFor").ToString
            PanDatos.Enabled = True
            TCodInt.Focus()
            TTotMeta.Text = 0
            TTotReal.Text = 0


            If DConsumos.Count = 0 Then Exit Sub
            AsignaDataGrid(DGConsumos, DConsumos.DataTable)

            TTotMeta.Text = SumColumn(DGConsumos, "PESOMETA")
            TTotReal.Text = SumColumn(DGConsumos, "PesoReal")

        Catch ex As Exception
            MsgError(ex)
        End Try

    End Sub

    Private Sub BCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BCancelar.Click
        Try
            TCodFor.Text = ""
            TCodForB.Text = ""
            TCodInt.Text = "0"
            TNomFor.Text = ""
            TCodExt.Text = ""
            TNombre.Text = ""
            TCantidad.Text = "0.00"

        Catch ex As Exception

        End Try
    End Sub

    Private Sub TCodMat_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TCodInt.KeyDown
        Try

            If e.KeyCode <> Keys.Enter Then Exit Sub

            If TCodInt.Text = "" Then Exit Sub
            DArt.Find("CODINT='" + TCodInt.Text.Trim + "'")
            If DArt.EOF Then
                MsgBox(DevuelveEvento(CodEvento.BD_REGNOEXISTE) + ": Ingrediente", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                'MsgBox("El Ingrediente ingresado no existe", MsgBoxStyle.Information)
                Exit Sub
            End If

            TNombre.Text = DArt.RecordSet("NOMBRE").ToString
            TCodExt.Text = DArt.RecordSet("CODEXT").ToString

            TCantidad.Focus()

        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub BAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BAceptar.Click
        Try
            If Eval(TCodFor.Text) <= 0 Then
                MsgBox(DevuelveEvento(CodEvento.SISTEMA_ERROR) + " la identificación de la fórmula", MessageBoxButtons.OK, MessageBoxIcon.Error)
                'MsgBox("Existe un error en la identificación de la fórmula", MsgBoxStyle.Information)
                TContador.Focus()
                Exit Sub
            End If

            If TCantidad.Text = "" Then
                MsgBox(DevuelveEvento(CodEvento.SISTEMA_FALTACAMPO) + " cantidad")
                'MsgBox("Debe indicar un valor de peso válido", MsgBoxStyle.Information)
                TCantidad.Focus()
                Exit Sub
            End If

            If TCodExt.Text = "" Then
                MsgBox(DevuelveEvento(CodEvento.SISTEMA_FALTACAMPO) + " Código de material")
                'MsgBox("Debe indicar un código de material válido", MsgBoxStyle.Information)
                TCodInt.Focus()
                Exit Sub
            End If

            DBaches.Open("Select * from BACHES where ESTADO>10 AND CONT=" + TContador.Text)

            If DBaches.Count Then
                MsgBox(DevuelveEvento(CodEvento.SISTEMA_ERROR) + " El bache ya está completo o ya fue procesado por costos", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Limpiar_Habilitar_TextBox(Me.Controls, AccionTextBox.Limpiar)
                Exit Sub
            End If

            DConsumos.AddNew()

            DConsumos.RecordSet("CONT") = TContador.Text
            DConsumos.RecordSet("CodForB") = TCodForB.Text
            DConsumos.RecordSet("CodFor") = TCodFor.Text
            DConsumos.RecordSet("Paso") = 90
            DConsumos.RecordSet("CodMat") = TCodInt.Text
            DConsumos.RecordSet("CodMatB") = TCodExt.Text
            DConsumos.RecordSet("NOMMAT") = TNombre.Text
            DConsumos.RecordSet("PesoMeta") = Eval(TCantidad.Text)
            DConsumos.RecordSet("PESOREAL") = Eval(TCantidad.Text)
            DConsumos.RecordSet("ALARMAS") = 126
            DConsumos.RecordSet("TIPOMAT") = 15

            CortesLote(DConsumos.RecordSet("CODMAT").ToString, DConsumos.RecordSet("PESOREAL"), LoteCortesMP, ContCortesMP, UbicLoteMP)
            If LoteCortesMP <> "" AndAlso ContCortesMP <> "" Then
                DConsumos.RecordSet("CORTELOTE") = ContCortesMP
                DConsumos.RecordSet("Lote") = LoteCortesMP
                DConsumos.RecordSet("UbicLote") = UbicLoteMP
            End If


            ' Actualiza el inventario de tolvas
            DTolvas.Open("select * from TOLVAS where CODINT='" + DConsumos.RecordSet("CODMAT").ToString + "'")
            If DTolvas.Count > 0 Then
                DescTolvas(DTolvas.RecordSet("TOLVA"), -DConsumos.RecordSet("PESOREAL"), DConsumos.RecordSet("CODMAT").ToString, ProcesoPlanta.DOSIFICACION)
                'DTolvas.RecordSet("TOTAL") -= DConsumos.RecordSet("PESOREAL")
                'DTolvas.Update(Me)
            End If
            DConsumos.Update(Me)

            'If Not IsDBNull(DConsumos.RecordSet("LOTE")) Then
            '    'Inventario(TCodInt.Text, -Eval(TCantidad.Text), TipoInv.CHRONOS, DConsumos.RecordSet("LOTE"), DetOperacion.INGMANUAL, , , , , , , , Usuario)

            '    'Objeto usado para realizar el descuento del inventario
            '    Dim Invent As New DescInvent

            '    With Invent
            '        .CodInt = TCodInt.Text
            '        .Cantidad = -Eval(TCantidad.Text)
            '        .TipoInv = DescInvent.TipoInvent.CHRONOS
            '        .Lote = DConsumos.RecordSet("LOTE")
            '        .Detalle = DetOperacion.INGMANUAL
            '        .Usuario = UsuarioPrincipal
            '        .Inventario()
            '    End With

            'End If

            Evento("Reporte Manual Entra.Consumo Form." + (TCodFor.Text) + " Mat." + TCodInt.Text + " N." + TContador.Text)


            ActualizaEstadoBache(Val(TContador.Text))

            TContador_KeyDown(Nothing, New KeyEventArgs(Keys.Enter))

        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub BEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BEliminar.Click
        Try
            Dim CodMat As String
            Dim Valor As String
            Dim ID As String

            Resp = MsgBox("Desea eliminar el ingrediente " + DGConsumos.Rows(DGConsumos.CurrentRow.Index).Cells("NOMMAT").Value.ToString.Trim + " de este bache??", vbCritical + vbYesNo)
            If Resp = vbNo Then Exit Sub

            CodMat = DGConsumos.Rows(DGConsumos.CurrentRow.Index).Cells("CODMAT").Value.ToString.Trim
            Valor = DGConsumos.Rows(DGConsumos.CurrentRow.Index).Cells("PESOMETA").Value.ToString.Trim
            ID = DGConsumos.Rows(DGConsumos.CurrentRow.Index).Cells("ID").Value

            DConsumos.Delete("Delete from consumos where ID=" + ID)

            Evento("Detalle de Bache Elimina Mat. " + CodMat + "Bache. No " + TContador.Text)

            DBaches.Find("CONT=" + TContador.Text)
            If DBaches.EOF = False Then
                If DBaches.RecordSet("PESOREAL") > 0 Then
                    DBaches.RecordSet("PESOREAL") -= Eval(Valor)
                    DBaches.Update(Me)
                End If
            End If

            TTotMeta.Text = 0
            TTotReal.Text = 0

            If DConsumos.Count = 0 Then Exit Sub
            AsignaDataGrid(DGConsumos, DConsumos.DataTable)

            TTotMeta.Text = SumColumn(DGConsumos, "PESOMETA")
            TTotReal.Text = SumColumn(DGConsumos, "PESOREAL")

            'BCancelar_Click(Nothing, Nothing)

        Catch ex As Exception

        End Try
    End Sub

    Private Sub BSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BSalir.Click
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub MaterialesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MaterialesToolStripMenuItem.Click
        Materiales.ShowDialog()
    End Sub

    Private Sub AcercaDeToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AcercaDeToolStripMenuItem.Click
        AcercaD.ShowDialog()
    End Sub

    Private Sub BAceptar_KeyUp(sender As Object, e As KeyEventArgs) Handles BAceptar.KeyUp
        If e.KeyCode <> Keys.Enter Then Return
        BAceptar_Click(Nothing, Nothing)
    End Sub
End Class