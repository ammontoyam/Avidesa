Public Class SaldosIni

    Private DProd As AdoSQL

    Private Sub BRevisar_Click(sender As System.Object, e As System.EventArgs) Handles BRevisar.Click
        Try

            DProd.Open("Select distinct(codint) from MOVINV where TIPO='PT' and TIPOMOV='CHRONOS' AND FECHA>'2013/12/23 09:00' and FECHA<'2013/12/27'")

            If DProd.Count Then
                TProdProc.Text = DProd.Count
            End If

        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub SaldosIni_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Try
            DProd = New AdoSQL("PRODUCTS")




        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub BCorregir_Click(sender As System.Object, e As System.EventArgs) Handles BCorregir.Click
        Try
            Dim SaldoIni As Double = 0
            Dim SaldoFin As Double = 0

            Dim DMovInv As AdoSQL
            Dim DVarios As AdoSQL
            Dim DArt As AdoSQL

            DMovInv = New AdoSQL("MOVINV")
            DVarios = New AdoSQL("MOVINV")
            DArt = New AdoSQL("ARTICULOS")

            If TCodProd.Text <> "" Then
                DProd.Open("Select top 1 * from MOVINV where CODINT='" + TCodProd.Text + "'")
            End If

            For Each RsDProd As DataRow In DProd.Rows

                'Rescatamos el saldo final y lo ponemos como saldo Inicial

                DVarios.Open("Select TOP 1 * from MOVINV where FECHA<='2013/12/23 09:00' and CODINT='" + RsDProd("CODINT") + "' order BY FECHA DESC")

                If DVarios.Count Then
                    SaldoIni = DVarios.RecordSet("SALDOFIN")
                End If

                'Abrimos todos los registros que se agregaron de ese producto despues de la fecha de corte
                DMovInv.Open("Select * from MOVINV where fecha>'2013/12/23 09:00' and CODINT='" + RsDProd("CODINT") + "' order BY FECHA")

                For Each RsDMovInv As DataRow In DMovInv.Rows
                    RsDMovInv("SALDOINI") = SaldoIni
                    RsDMovInv("SALDOFIN") = RsDMovInv("SALDOINI") + RsDMovInv("ENTRA") + RsDMovInv("SALE")
                    SaldoIni = RsDMovInv("SALDOFIN")
                    SaldoFin = RsDMovInv("SALDOFIN")
                    DMovInv.Update()
                Next

                DArt.Open("Select * from ARTICULOS where CODINT='" + RsDProd("CODINT") + "'")

                If DArt.Count > 0 Then
                    DArt.RecordSet("INVCHRONOS") = SaldoFin
                    DArt.Update()
                End If

            Next

            MsgBox("Proceso Finalizado")


        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub
End Class