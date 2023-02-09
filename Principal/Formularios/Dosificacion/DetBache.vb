Option Explicit On

Imports System.Windows.Forms
Imports System.Data.Common
Imports System.Data
Imports ChronoSoftNet

Public Class DetBache
    Private DConsumos As AdoSQL
    Private DBaches As AdoSQL
    Private DDatosFor As AdoSQL
    Private DCortes As AdoSQL
    Private DTolvas As AdoSQL
    Private Dvarios As AdoSQL
    Private DFor As AdoSQL

    Private DFila() As DataRow
    Private DR As DataRow
    Private Row As Integer = 0

    Private Sub DetBache_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            DBaches = New AdoSQL("Baches")
            DConsumos = New AdoSQL("Baches")
            DDatosFor = New AdoSQL("DatosFor")
            DCortes = New AdoSQL("Cortes")
            DTolvas = New AdoSQL("Tolvas")
            DFor = New AdoSQL("Formulas")

            Dvarios = New AdoSQL("Varios")
            'Se abren los baches de las ultimas 2 semanas para no sobrecargar el formulario
            DBaches.Open("select * from BACHES where FECHA>'" + DateAdd(DateInterval.WeekOfYear, -3, Now).ToString("yyyy/MM/dd") + "' order by FECHA DESC")

            If DBaches.Count Then
                TContador.Text = DBaches.RecordSet("Cont").ToString
                BVerBache_Click(Nothing, Nothing)
            End If

        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub BVerBache_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BVerBache.Click
        Try
            'Dim SumaMeta As Single
            'Dim SumaReal As Single
            Dim Proceso As ProcesoPlanta = ProcesoPlanta.EMPAQUE

            LAviso.Text = ""
            Dim RenglonCons As String = ""
            DGDetBach.Rows.Clear()
            TTotMeta.Text = 0
            TTotReal.Text = 0

            If TContador.Text = "" Then Exit Sub

            DBaches.Find("CONT=" + TContador.Text)

            If DBaches.EOF Then
                TOPs.Text = ""
                TCodFor.Text = ""
                TCodForB.Text = ""
                TLP.Text = ""
                TBacheNo.Text = ""
                TNomFor.Text = ""
                TFecha.Text = ""
                Exit Sub
            End If

            If DBaches.RecordSet("ESTADO") > 10 Then
                MsgBox(DevuelveEvento(CodEvento.OP_BACHEREPORTADO), MessageBoxButtons.OK + MessageBoxIcon.Exclamation)
                'MsgBox("El bache ya está completo o ya fue procesado por costos, no se podrá realizar ninguna adición o eliminación de ingredientes", vbCritical)
                Limpiar_Habilitar_TextBox(Me.Controls, AccionTextBox.Limpiar)
                Exit Sub
            End If

            If DBaches.RecordSet("NomFor").ToString = "ANULADO" Then
                Limpiar_Habilitar_TextBox(Me.Controls, AccionTextBox.Limpiar)
                Exit Sub
            End If



            TOPs.Text = DBaches.RecordSet("OP")
            TCodFor.Text = DBaches.RecordSet("CODFOR")
            TCodForB.Text = DBaches.RecordSet("CODFORB")
            TBacheNo.Text = DBaches.RecordSet("BACHE").ToString
            TNomFor.Text = DBaches.RecordSet("NOMFOR")
            TFecha.Text = DBaches.RecordSet("FECHA")
            TLP.Text = DBaches.RecordSet("LP")

            DConsumos.Open("select *, CONVERT(VARCHAR, PESOMETA) as PMETA from CONSUMOS where CONT=" + TContador.Text + " order by NOMMAT")
            If DConsumos.Count = 0 Then Exit Sub
            AsignaDataGrid(DGDetBach, DConsumos.DataTable)


            For Each Fil As DataRow In DConsumos.DataTable.Rows
                TTotMeta.Text = Eval(TTotMeta.Text) + Eval(Fil("PESOMETA").ToString)
                TTotReal.Text = Eval(TTotReal.Text) + Eval(Fil("PESOREAL").ToString)
                If Fil("PESOREAL") = 0 Then LAviso.Text += "El ingrediente " + Fil("NOMMAT").ToString + " tiene el PESO META en ceros, favor verificar"
                If Fil("PESOMETA") = 0 Then LAviso.Text += "El ingrediente " + Fil("NOMMAT").ToString + " tiene el PESO META en ceros, favor verificar"
                DConsumos.Open("select *, CONVERT(VARCHAR, PESOMETA) as PMETA from CONSUMOS where CONT=" + TContador.Text + " order by NOMMAT")
            Next

            'Se pregunta si la formula Maneja paquetepx 

            DFor.Open("select * from FORMULAS where CODFOR='" + TCodFor.Text + "' and LP='" + TLP.Text + "'")

            If DFor.Count Then

                If DFor.RecordSet("ManejaPX") Then
                    If Funcion_PlantasExternas Then
                        DDatosFor.Open("select * from DATOSFOR where TIPOMAT<40 and CODFOR='" + TCodFor.Text + "' and  TIPOMAT=6 and LP='" + TLP.Text + "' Order by NOMMAT")
                    Else
                        DDatosFor.Open("select * from DATOSFOR where TIPOMAT<40 and CODFOR='" + TCodFor.Text + "' and  TIPOMAT<>6 and LP='" + TLP.Text + "' Order by NOMMAT")
                    End If
                Else
                    DDatosFor.Open("select * from DATOSFOR where TIPOMAT<40 and CODFOR='" + TCodFor.Text + "' and LP='" + TLP.Text + "' Order by NOMMAT")
                End If

            End If


            If DDatosFor.Count = 0 Then Exit Sub

            For Each Reg As DataRow In DDatosFor.DataTable.Rows

                DConsumos.Find("CODMAT='" + Reg("CODMAT").ToString + "' and PMETA like '" + Int(Reg("PESOMETA")).ToString + "%'")
                If DConsumos.EOF Then
                    Resp = MsgBox("Falta el ingrediente " + Reg("CodMat").ToString + " " + Reg("NOMMAT").ToString.Trim + " Peso Meta " + Reg("PESOMETA").ToString + " Kg. Desea agregarlo a los reportes con el peso teórico?", MsgBoxStyle.Information + vbYesNo)
                    If Resp = vbYes Then

                        DConsumos.AddNew()

                        DConsumos.RecordSet("CONT") = TContador.Text
                        DConsumos.RecordSet("Paso") = 80
                        DConsumos.RecordSet("CodMat") = Reg("CodMat")
                        DConsumos.RecordSet("PESOREAL") = Reg("PESOMETA") 'DDatosFor!VALORB * B.DOPs!TAMBACHE / 100
                        DConsumos.RecordSet("ALARMAS") = 125
                        DConsumos.RecordSet("PesoMeta") = Reg("PESOMETA") 'Format(DDatosFor!VALORB * B.DOPs!TAMBACHE / 100, "######0.000")
                        DConsumos.RecordSet("CodFor") = TCodFor.Text
                        DConsumos.RecordSet("CodForB") = Reg("CodForB")
                        DConsumos.RecordSet("NOMMAT") = Reg("NOMMAT")
                        DConsumos.RecordSet("CodMatB") = Reg("CodMatB")
                        DConsumos.RecordSet("A") = Reg("A")
                        DConsumos.RecordSet("TIPOMAT") = 125

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
                        End If
                        DConsumos.Update(Me)

                        ''Actualiza el inventario en la tabla ARTICULOS
                        'If Not IsDBNull(DConsumos.RecordSet("LOTE")) Then
                        '    Inventario(DConsumos.RecordSet("CODMAT"), -DConsumos.RecordSet("PESOREAL"), TipoInv.CHRONOS, DConsumos.RecordSet("LOTE"), DetOperacion.INGMANUAL, , , , , , , , UsuarioPrincipal)
                        'End If

                        'Si se realiza alguna adición al bache, este se verifica para revisar si esta completo y poner estado en 10 para que lo vea
                        'el depto de costos.
                        ActualizaEstadoBache(TContador.Text)

                        BVerBache_Click(Nothing, Nothing)

                    End If
                End If
            Next


        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub


    Private Sub BAnterior_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BAnterior.Click
        Try
            Row += 1
            If Row > DBaches.Count - 1 Then Row = DBaches.Count - 1
            TContador.Text = DBaches.DataTable.Rows(Row)("Cont").ToString
            BVerBache_Click(Nothing, Nothing)
        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub BSiguiente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BSiguiente.Click
        Try
            Row -= 1
            If Row < 0 Then Row = 0
            TContador.Text = DBaches.Rows(Row)("Cont").ToString
            BVerBache_Click(Nothing, Nothing)
        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub BSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BSalir.Click
        Try
            Me.Close()
            Me.Dispose()
        Catch ex As Exception
            MsgError(ex)
        End Try

    End Sub


    Private Sub mnEliminaBache_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnEliminaBache.Click
        Try
            'If DRUsuario("RepMod") Then
            If ValidaPermiso("Reportes_Editar") Then
            Else
                MsgBox(DevuelveEvento(CodEvento.USUARIO_PERMISODENEGADO), MsgBoxStyle.Information)
                Exit Sub
            End If

            If TContador.Text = "" Then Return
            Resp = MsgBox("Desea eliminar el Bache COMPLETO??", vbCritical + vbYesNo)
            If Resp = vbNo Then Return

            DBaches.Find("CONT=" + TContador.Text)

            If DBaches.EOF Then Return



            If DBaches.RecordSet("ESTADO") > 10 Then
                MsgBox(DevuelveEvento(CodEvento.OP_BACHEREPORTADO), MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Limpiar_Habilitar_TextBox(Me.Controls, AccionTextBox.Limpiar)
                Exit Sub
            End If


            DBaches.RecordSet("NOMFOR") = "ANULADO"
            DBaches.Update(Me)

            DConsumos.Delete("delete from CONSUMOS where CONT=" + TContador.Text, Me)

            Evento("Detalle de Bache Anula Bache." + TContador.Text)

            BSiguiente_Click(Nothing, Nothing)

        Catch ex As Exception
            MsgError(ex)
        End Try

    End Sub

    Private Sub mnEliminaIng_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnEliminaIng.Click
        Try
            Dim CodMat As String
            Dim Valor As String
            Dim Real As String
            Dim ID As String
            'If DRUsuario("RepMod") Then
            If ValidaPermiso("Reportes_Editar") Then
            Else
                MsgBox(DevuelveEvento(CodEvento.USUARIO_PERMISODENEGADO), MsgBoxStyle.Information)
                Exit Sub
            End If

            Dvarios.Open("Select * from BACHES where ESTADO>10 AND CONT=" + TContador.Text)

            If Dvarios.Count Then
                MsgBox(DevuelveEvento(CodEvento.OP_BACHEREPORTADO), MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Limpiar_Habilitar_TextBox(Me.Controls, AccionTextBox.Limpiar)
                Exit Sub
            End If

            Resp = MsgBox(DevuelveEvento(CodEvento.BD_REGELIMINAR), vbCritical + vbYesNo)
            If Resp = vbYesNo Then Return

            CodMat = DGDetBach.Rows(DGDetBach.CurrentRow.Index).Cells("CODMAT").Value.ToString.Trim
            Valor = DGDetBach.Rows(DGDetBach.CurrentRow.Index).Cells("PESOMETA").Value.ToString.Trim
            Real = DGDetBach.Rows(DGDetBach.CurrentRow.Index).Cells("PESOREAL").Value.ToString.Trim
            ID = DGDetBach.Rows(DGDetBach.CurrentRow.Index).Cells("ID").Value


            DConsumos.Delete("Delete from consumos where ID=" + ID, Me)

            Dvarios.Open("Update BACHES set PESOREAL=PESOREAL-" + Real + ",PESOMETA=PESOMETA-" + Valor + " WHERE CONT=" + TContador.Text)
            Evento("Detalle de Bache descuenta " + Real + " de Bache. No " + TContador.Text)
            Evento("Detalle de Bache Elimina Mat. " + CodMat + "Bache. No " + TContador.Text)
            BVerBache_Click(Nothing, Nothing)


        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub


    Private Sub MaterialesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MaterialesToolStripMenuItem.Click
        Materiales.ShowDialog()
    End Sub

    Private Sub AcercaDeToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AcercaDeToolStripMenuItem.Click
        AcercaD.ShowDialog()
    End Sub
End Class