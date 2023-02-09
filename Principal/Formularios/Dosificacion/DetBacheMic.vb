Option Explicit On

Imports System.Windows.Forms
Imports System.Data.Common
Imports System.Data
Imports ChronoSoftNet

Public Class DetBacheMic
    Private DConsumos As AdoSQL
    Private DConsumosMed As AdoSQL
    Private DBaches As AdoSQL
    Private DDatosFor As AdoSQL
    Private DCortes As AdoSQL
    Private DTolvas As AdoSQL
    Private DVarios As AdoSQL

    Private DFila() As DataRow
    Private DR As DataRow
    Private Row As Integer = 0

    Private SumaMetaFor As Single
    Private SumaMetaCons As Single

    Private Sub DetBache_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            DBaches = New AdoSQL("Baches")
            DConsumos = New AdoSQL("Baches")
            DConsumosMed = New AdoSQL("ConsumosMed")
            DDatosFor = New AdoSQL("DatosFor")
            DCortes = New AdoSQL("Cortes")
            DTolvas = New AdoSQL("Tolvas")
            DVarios = New AdoSQL("Varios")

            DConsumosMed.Open("select TOP 1 * from CONSUMOSMED WHERE ESTADO<>50 order by FECHA DESC")

            If DConsumosMed.Count Then
                TContador.Text = DConsumosMed.RecordSet("Cont2").ToString
                BVerBache_Click(Nothing, Nothing)
            End If

        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub BVerBache_Click(ByVal sender As System.Object, ByVal e As System.EventArgs, Optional NumFilas As String = "50") Handles BVerBache.Click
        Try
            LAviso.Text = ""
            DGDetBach.Rows.Clear()
            TTotMeta.Text = 0
            TTotReal.Text = 0

            If TContador.Text = "" Then Exit Sub

            DConsumosMed.Open("select * from CONSUMOSMED where CONT2=" + TContador.Text + " order by NOMMAT")

            If DConsumosMed.Count = 0 Then Exit Sub

            TOPs.Text = DConsumosMed.RecordSet("OP")
            TCodFor.Text = DConsumosMed.RecordSet("CODFOR")
            TCodForB.Text = DConsumosMed.RecordSet("CODFORB")
            TBacheNo.Text = DConsumosMed.RecordSet("BACHE").ToString
            'TNomFor.Text = DConsumosMed.RecordSet("NOMFOR")
            TFecha.Text = DConsumosMed.RecordSet("FECHA")

            DVarios.Open("Select * from OPS where OP='" + TOPs.Text + "'")

            If DVarios.Count = 0 Then Return

            TLP.Text = DVarios.RecordSet("LP")
            TNomFor.Text = DVarios.RecordSet("NOMFOR")

            AsignaDataGrid(DGDetBach, DConsumosMed.DataTable)

            For Each Fil As DataRow In DConsumosMed.DataTable.Rows
                TTotMeta.Text = Eval(TTotMeta.Text) + Eval(Fil("PESOMETA").ToString)
                TTotReal.Text = Eval(TTotReal.Text) + Eval(Fil("PESOREAL").ToString)
                If Fil("PESOREAL") = 0 Then LAviso.Text += "El ingrediente " + Fil("NOMMAT").ToString + " tiene el PESO META en ceros, favor verificar"
                If Fil("PESOMETA") = 0 Then LAviso.Text += "El ingrediente " + Fil("NOMMAT").ToString + " tiene el PESO META en ceros, favor verificar"
            Next

            'Se seleccionan los baches que falten por verificar el estado
            DConsumosMed.Open("select TOP " + NumFilas + " CONT2,min(codfor) as codfor,min(lp) as lp,MAX(ID) AS ID from CONSUMOSMED where ESTADO<10 GROUP BY CONT2 order by ID DESC")

            For Each RecordSet As DataRow In DConsumosMed.Rows

                'Sacamos el pesometa del agua de la fórmula ya que no está reportado en la tabla 
                'consumos 

                DVarios.Open("Select SUM(PESOMETA) as PESOMETA from DATOSFOR where TIPOMAT=6 and CODFOR='" + RecordSet("CODFOR") + "' and LP='" + RecordSet("LP") + "'")

                If DVarios.Count AndAlso Not IsDBNull(DVarios.RecordSet("PESOMETA")) Then
                    SumaMetaFor = DVarios.RecordSet("PESOMETA")
                End If

                DConsumosMed.Open("select SUM(PESOMETA) AS PESOMETA from CONSUMOSMED where CONT2=" + RecordSet("CONT2").ToString)

                If DConsumosMed.Count AndAlso Not IsDBNull(DConsumosMed.RecordSet("PESOMETA")) Then
                    SumaMetaCons = DConsumosMed.RecordSet("PESOMETA")
                End If

                'Si la suma del peso meta de los consumos es igual al peso meta del bache se cambia el estado del bache a 10
                If Math.Abs((SumaMetaFor - SumaMetaCons)) < SumaMetaFor * 0.00005 Then
                    DVarios.Open("Update CONSUMOSMED set ESTADO=10 where CONT2=" + RecordSet("CONT2").ToString)
                End If

            Next

            DDatosFor.Open("select * from DATOSFOR where CODFOR='" + TCodFor.Text + "' and TIPOMAT=6 and LP='" + TLP.Text + "' Order by NOMMAT")
            DConsumosMed.Open("select * from CONSUMOSMED where CONT2=" + TContador.Text + " order by NOMMAT")

            If DDatosFor.Count = 0 Then Exit Sub

            For Each Reg As DataRow In DDatosFor.DataTable.Rows

                DConsumosMed.Find("CODMAT='" + Reg("CODMAT").ToString + "'") ' and PESOMETA=" + Replace(Format(Reg("PESOMETA"), "0.000"), ",", "."))
                If DConsumosMed.EOF Then
                    Resp = MsgBox("Falta el ingrediente " + Reg("CodMat").ToString + " " + Reg("NOMMAT").ToString.Trim + " Peso Meta " + Reg("PESOMETA").ToString + " Kg. Desea agregarlo a los reportes con el peso teórico?", MsgBoxStyle.Information + vbYesNo)
                    If Resp = vbYes Then

                        DConsumosMed.AddNew()

                        DConsumosMed.RecordSet("CONT") = TContador.Text
                        DConsumosMed.RecordSet("CONT2") = TContador.Text
                        DConsumosMed.RecordSet("Paso") = 80
                        DConsumosMed.RecordSet("CodMat") = Reg("CodMat")
                        DConsumosMed.RecordSet("PESOREAL") = Reg("PESOMETA") 'DDatosFor!VALORB * B.DOPs!TAMBACHE / 100
                        DConsumosMed.RecordSet("ALARMAS") = 125
                        DConsumosMed.RecordSet("PesoMeta") = Reg("PESOMETA") 'Format(DDatosFor!VALORB * B.DOPs!TAMBACHE / 100, "######0.000")
                        DConsumosMed.RecordSet("CodFor") = TCodFor.Text
                        DConsumosMed.RecordSet("CodForB") = Reg("CodForB")
                        DConsumosMed.RecordSet("NOMMAT") = Reg("NOMMAT")
                        DConsumosMed.RecordSet("CodMatB") = Reg("CodMatB")
                        DConsumosMed.RecordSet("TIPOMAT") = 6
                        DConsumosMed.RecordSet("OP") = TOPs.Text
                        DConsumosMed.RecordSet("ESTADO") = 10
                        DConsumosMed.RecordSet("FECHA") = FechaC()
                        DConsumosMed.RecordSet("LP") = TLP.Text
                        DConsumosMed.RecordSet("NOMFOR") = TNomFor.Text
                        DConsumosMed.RecordSet("FACTOR") = 100
                        DConsumosMed.RecordSet("BACHE") = Val(TBacheNo.Text)

                        CortesLote(DConsumosMed.RecordSet("CODMAT").ToString, DConsumosMed.RecordSet("PESOREAL"), LoteCortesMP, ContCortesMP, UbicLoteMP)
                        If LoteCortesMP <> "" AndAlso ContCortesMP <> "" Then
                            DConsumosMed.RecordSet("CORTELOTE") = ContCortesMP
                            DConsumosMed.RecordSet("Lote") = LoteCortesMP
                            DConsumosMed.RecordSet("UbicLote") = UbicLoteMP
                        End If

                        DConsumosMed.Update(Me)

                        DVarios.Open("Update CONSUMOSMED set ESTADO=10 where ESTADO=0 AND CONT2=" + TContador.Text)

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
            TContador.Text = Val(TContador.Text) - 1
            If Val(TContador.Text) > 0 Then BVerBache_Click(Nothing, Nothing)
        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub BSiguiente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BSiguiente.Click
        Try
            Row -= 1
            If Row < 0 Then Row = 0
            TContador.Text = Val(TContador.Text) + 1
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

    Private Sub mnEliminaIng_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnEliminaIng.Click
        Try
            Dim CodMat As String
            Dim Valor As String
            Dim ID As String

            'If DRUsuario("RepMod") Then
            If ValidaPermiso("Reportes_Editar") Then
            Else
                MsgBox(DevuelveEvento(CodEvento.USUARIO_PERMISODENEGADO), MsgBoxStyle.Information)
                Exit Sub
            End If

            Resp = MsgBox("Desea eliminar el ingrediente " + DGDetBach.Rows(DGDetBach.CurrentRow.Index).Cells("NOMMAT").Value.ToString.Trim + " de este bache??", vbCritical + vbYesNo)
            If Resp = vbYesNo Then Return

            CodMat = DGDetBach.Rows(DGDetBach.CurrentRow.Index).Cells("CODMAT").Value.ToString.Trim
            Valor = DGDetBach.Rows(DGDetBach.CurrentRow.Index).Cells("PESOMETA").Value.ToString.Trim
            ID = DGDetBach.Rows(DGDetBach.CurrentRow.Index).Cells("ID").Value

            DConsumosMed.Delete("delete FROM CONSUMOSMED where ID=" + ID, Me)

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