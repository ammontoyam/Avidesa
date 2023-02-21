Public Class CambioTolva

    Private DTolvas As AdoNet
    Private DVarios As AdoNet


    Public Sub CambioTolva_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            DTolvas = New AdoNet("Tolvas", CONN, DbProvedor)
            DVarios = New AdoNet("Tolvas", CONN, DbProvedor)
        Catch ex As Exception
            MsgError(ex.ToString)
        End Try
    End Sub

  
    Private Sub TTolvaAct_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TTolvaAct.TextChanged
        Try

            Try
                If Val(TTolvaAct.Text) = 0 Then Return

                DTolvas.Open("Select * from TOLVASDOSIF where TOLVA=" + TTolvaAct.Text)

                If DTolvas.RecordCount Then
                    TCodMat.Text = DTolvas.RecordSet("CODINT")
                    TNomMat.Text = DTolvas.RecordSet("NOMBRE")
                    TNomTv.Text = DTolvas.RecordSet("NOMTOLVA")
                End If

                'Llenamos el combobox de las tolvas disponibles para ese material

                DTolvas.Open("Select * from TOLVASDOSIF where CODINT='" + TCodMat.Text + "'")

                LLenaComboBox(CBNuevaTolva, DTolvas.DataTable, "NOMTOLVA")


            Catch ex As Exception
                MsgError(ex.ToString)
            End Try
        Catch ex As Exception
            MsgError(ex.ToString)
        End Try
    End Sub

    Private Sub CBNuevaTolva_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CBNuevaTolva.SelectedIndexChanged
        Try

            If CBNuevaTolva.Text = "" Then Return

            DVarios.Open("Select * from TOLVASDOSIF where NOMTOLVA='" + CBNuevaTolva.Text + "'")

            If DVarios.RecordCount = 0 Then Return

            TTolva.Text = DVarios.RecordSet("TOLVA")
            TBascNueva.Text = DVarios.RecordSet("BASCULA")

        Catch ex As Exception
            MsgError(ex.ToString)
        End Try
    End Sub

    Private Sub BCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BCancelar.Click
        NuevaTolva = 0
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub BAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BAceptar.Click
        Try
            Dim Msg As String
            If Val(TTolva.Text) = 0 Then
                MsgBox("Tolva en cero", vbCritical)
                BCancelar_Click(Nothing, Nothing)
            End If

            If CBNuevaTolva.Text = TTolvaAct.Text Then
                MsgBox("No puede elegir la misma tolva", vbCritical)
                Return
            End If

            If Val(TBascActual.Text) <> Val(TBascNueva.Text) Then CambioTolvaBasc = 10

            NuevaTolva = TTolva.Text
            NuevaBascula = TBascNueva.Text

            Msg = "CAMBIO TOLVA ORIGEN " + TTolvaAct.Text + " BASCULA " + TBascActual.Text
            Evento(Msg)
            APlanoPLC(2, Msg)

            Me.Close()
            Me.Dispose()

        Catch ex As Exception
            MsgError(ex.ToString)
        End Try
    End Sub
End Class