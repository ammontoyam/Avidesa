Public Class FormulacionFylax

    Private DFor As AdoSQL
    Public Sub FormulacionFylax_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            DFor = New AdoSQL("FORMULAS")
        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub BAceptar_Click(sender As Object, e As EventArgs) Handles BAceptar.Click
        Try
            DFor.Open("Select * from FORMULAS where CODFOR='" + TCodFor.Text + "' and LP='" + TLP.Text + "'")
            If DFor.Count Then

                Resp = MessageBox.Show(DevuelveEvento(CodEvento.BD_REGYAEXISTE), "ChronoSoft", MessageBoxButtons.YesNo, MessageBoxIcon.Information)
                If Resp = vbNo Then Exit Sub

                If ChHabCorrHum.Checked Then
                    DFor.RecordSet("HabCorrHum") = 1
                Else
                    DFor.RecordSet("HabCorrHum") = 0
                End If

                DFor.RecordSet("TipoAlimento") = TTipoAlim.Text
                DFor.RecordSet("NumReceta") = Val(TNumRec.Text)
                DFor.RecordSet("SpHumedad") = Val(TSpHum.Text)
                DFor.RecordSet("PorcAdicAgua") = Val(TPorcAgua.Text)

                DFor.Update(Me)
                MessageBox.Show(DevuelveEvento(CodEvento.SISTEMA_PROCESOFINALIZADO), "ChronoSoft", MessageBoxButtons.OK, MessageBoxIcon.Information)

            End If
        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Public Sub BActualizar_Click(sender As Object, e As EventArgs) Handles BActualizar.Click
        Try
            If TCodFor.Text.Length > 0 Then

                DFor.Open("Select * from FORMULAS where CODFOR='" + TCodFor.Text + "' and LP='" + TLP.Text + "'")
                If DFor.Count Then

                    ChHabCorrHum.Checked = False
                    If DFor.RecordSet("HabCorrHum") = 1 Then
                        ChHabCorrHum.Checked = True
                    End If
                    TTipoAlim.Text = DFor.RecordSet("TipoAlimento")
                    TNumRec.Text = DFor.RecordSet("NumReceta")
                    TSpHum.Text = DFor.RecordSet("SpHumedad")
                    TPorcAgua.Text = DFor.RecordSet("PorcAdicAgua")
                End If

            End If
        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub BSalir_Click(sender As Object, e As EventArgs) Handles BSalir.Click
        Me.Close()
        Me.Dispose()
    End Sub


End Class