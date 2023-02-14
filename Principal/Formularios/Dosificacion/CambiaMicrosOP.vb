Imports ClassLibrary

Public Class CambiaMicrosOP

    Private DOPs As AdoSQL
    Private DConsumosMed As AdoSQL
    Private DVarios As AdoSQL

    Private Sub BSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BSalir.Click
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub CambiaMicrosOP_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            DOPs = New AdoSQL("DOPs")
            DConsumosMed = New AdoSQL("DConsumosMed")
            DVarios = New AdoSQL("DVarios")
        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub TOPOrig_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TOPOrig.KeyUp
        Try
            If e.KeyCode <> Keys.Enter Then Return

            DOPs.Open("Select * from OPS WHERE OP='" + TOPOrig.Text + "'")

            If DOPs.Count = 0 Then
                MsgBox("La OP ingresada no existe o esta Finalizada", vbInformation)
                Return
            End If

            TCodForOrig.Text = DOPs.RecordSet("CodFor")
            TNomForOrig.Text = DOPs.RecordSet("NomFor")
            TLPOrig.Text = DOPs.RecordSet("LP")
            TMetaOrig.Text = DOPs.RecordSet("Meta")
            TRealOrig.Text = DOPs.RecordSet("Real")
            TRealMedOrig.Text = DOPs.RecordSet("RealMed")
            TCodPremOrig.Text = DOPs.RecordSet("CodPremezcla")

            DConsumosMed.Open("select MIN(OP) as OP,MIN(CodFor) AS CodFor,min(NomFor) as NomFor,min(Bache) as Bache,Cont from ConsumosMed where reportado=0 AND OP='" + TOPOrig.Text + "' Group by Cont")

            If DConsumosMed.Count = 0 Then
                MsgBox("La OP Ingresada no tiene baches de micros disponibles para traslado", vbInformation)
                Return
            End If

            AsignaDataGrid(DGConsumosMed, DConsumosMed.DataTable)

        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub TOPDest_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TOPDest.KeyUp
        Try

            If e.KeyCode <> Keys.Enter Then Return

            DOPs.Open("Select * from OPS where OP='" + TOPDest.Text + "'")

            If DOPs.Count = 0 Then
                MsgBox("La OP ingresada no existe o esta Finalizada", vbInformation)
                Return
            End If

            TCodForDest.Text = DOPs.RecordSet("CodFor")
            TNomForDest.Text = DOPs.RecordSet("NomFor")
            TLPDest.Text = DOPs.RecordSet("LP")
            TMetaDest.Text = DOPs.RecordSet("Meta")
            TRealDest.Text = DOPs.RecordSet("Real")
            TRealMedDest.Text = DOPs.RecordSet("RealMed")
            TCodPremDest.Text = DOPs.RecordSet("CodPremezcla")

        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub BAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BAceptar.Click
        Try
            If TOPOrig.Text = "" OrElse TOPDest.Text = "" Then
                MsgBox("Datos de OPs incompletos", vbInformation)
                Return
            End If

            If TCodPremOrig.Text <> TCodPremDest.Text Then
                MsgBox("Códigos de premezcla diferentes", vbInformation)
                Return
            End If

            'If TLPOrig.Text <> TLPDest.Text Then
            '    MsgBox("Números de orden diferentes", vbInformation)
            '    Return
            'End If

            If TCodForOrig.Text = "" OrElse TCodForDest.Text = "" Then
                MsgBox("Datos de Fórmulas incompletos", vbInformation)
                Return
            End If

            If Val(TBaches.Text) = 0 Then
                MsgBox("Ingrese un número de baches válido", vbInformation)
                Return
            End If

            If DConsumosMed.Count = 0 Then
                MsgBox("No hay Baches disponibles de micros de la OP de origen para trasladar", vbInformation)
                Return
            End If


            If Val(TBaches.Text) > (DOPs.RecordSet("META") - DOPs.RecordSet("REALMED")) Then
                MsgBox("El número de baches ingresados supera los baches pendientes de la OP destino", vbInformation)
                Return
            End If

            If Val(TBaches.Text) > DGConsumosMed.Rows.Count Then
                MsgBox("El número de baches ingresados supera los baches disponibles para trasladar en la OP Origen", vbInformation)
                Return
            End If

            DOPs.Open("Select * from OPS WHERE OP='" + TOPOrig.Text + "'")

            If DOPs.Count = 0 Then
                MsgBox("OP no existe")
                Return
            End If

            If DOPs.Count Then
                DOPs.RecordSet("RealMed") -= Val(TBaches.Text)
                DOPs.Update(Me)
            End If

            DOPs.Open("Select * from OPS WHERE OP='" + TOPDest.Text + "'")

            If DOPs.Count = 0 Then
                MsgBox("OP no existe")
                Return
            End If

            DOPs.RecordSet("RealMed") += Val(TBaches.Text)
            DOPs.Update(Me)

            Dim Cont As String = ""
            Dim BacheMic As Integer = 0

            DVarios.Open("Select MAX(BACHE) as MAXBACHE FROM CONSUMOSMED where OP='" + TOPDest.Text + "'")
            If DVarios.Count AndAlso Not IsDBNull(DVarios.RecordSet("MAXBACHE")) Then
                BacheMic = DVarios.RecordSet("MAXBACHE")
            End If

            For j As Integer = DGConsumosMed.SelectedRows.Count - 1 To 0 Step -1
                Cont = DGConsumosMed.SelectedRows(j).Cells("Cont").Value.ToString
                BacheMic += 1
                DConsumosMed.Open("SELECT * FROM CONSUMOSMED WHERE CONT=" + Cont)

                For Each Fila As DataRow In DConsumosMed.Rows
                    Fila("OP") = TOPDest.Text
                    Fila("CODFOR") = TCodForDest.Text
                    Fila("CODFORB") = TCodForDest.Text
                    Fila("NOMFOR") = TNomForDest.Text
                    Fila("BACHE") = BacheMic
                    Fila("TRASLADO") = 1
                    'La se guarda la fecha de fabricacion en otro campo para saber cuando se hizo la premezcla
                    Fila("FECHAFABRICACION") = Fila("FECHA")
                    Fila("FECHA") = FechaC()
                    Fila("OPORIGEN") = TOPOrig.Text
                    DConsumosMed.Update(Me)

                    Evento("Traslada micros OP Origen:" + TOPOrig.Text + " OP Destino: " + TOPDest.Text + " Contador: " + Cont + " CodMat:" + Fila("CODMAT"))
                Next
            Next
            Evento(DevuelveEvento(CodEvento.SISTEMA_PROCESOFINALIZADO), Me)
            MsgBox(DevuelveEvento(CodEvento.SISTEMA_PROCESOFINALIZADO), vbInformation)
            BCancelar_Click(Nothing, Nothing)
        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub DGConsumosMed_CellMouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles DGConsumosMed.CellMouseUp
        If DGConsumosMed.RowCount = 0 Then Return
        TBaches.Text = DGConsumosMed.SelectedRows.Count.ToString
    End Sub

    Private Sub BCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BCancelar.Click
        Limpiar_Habilitar_TextBox(Me.Controls, AccionTextBox.Limpiar)
        DGConsumosMed.Rows.Clear()
    End Sub

    Private Sub DGConsumosMed_SelectionChanged(sender As System.Object, e As System.EventArgs) Handles DGConsumosMed.SelectionChanged
        If DGConsumosMed.RowCount = 0 Then Return
        TBaches.Text = DGConsumosMed.SelectedRows.Count.ToString
    End Sub

End Class