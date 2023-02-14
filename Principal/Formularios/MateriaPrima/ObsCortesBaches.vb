Imports ClassLibrary

Public Class ObsCortesBaches

    Private DCortesBaches As AdoSQL
    Private DVarios As AdoSQL
    Private Sub ObsCortesBaches_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try

            DCortesBaches = New AdoSQL("CORTESBACHES")
            DVarios = New AdoSQL("VARIOS")
            TContBache.Focus()

        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub BAceptarObsCorte_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BAceptarObsCorte.Click
        Try
            'Buscamos si el código del contador existe, es decir si ya está reportado este número de bache

            If TObservaciones.Text.Length < 3 Then
                MsgBox(DevuelveEvento(CodEvento.SISTEMA_FALTACAMPO) + " 'Observación' ", vbInformation)
                Return
            End If

            If Eval(TContBache.Text) > 0 Then
            Else
                MsgBox(DevuelveEvento(CodEvento.SISTEMA_FALTACAMPO) + " 'Contador Bache' ", vbInformation)
                'CortesMP.TObserv.Text = CLeft(TObservaciones.Text, 250)
                'Me.Close()
                'Me.Dispose()               
                Return
            End If

            DVarios.Open("Select * from BACHES where CONT=" + TContBache.Text.Trim)

            If DVarios.Count = 0 Then
                MsgBox(DevuelveEvento(CodEvento.BD_REGNOEXISTE) + ":Numero de Bache", vbInformation)
                Return
            End If

            'Buscamos si el código del material ya está reportado en la tabla consumos

            DVarios.Open("Select * from CONSUMOS where CONT=" + TContBache.Text.Trim + " and CODMAT='" + TCodMat.Text + "'")

            If DVarios.Count = 0 Then
                MsgBox(DevuelveEvento(CodEvento.BD_REGNOEXISTE) + " Contador de bache sin material reportado", vbInformation)
                Return
            End If

            DCortesBaches.Open("Select * from CORTESBACHES where ID=0")

            DCortesBaches.AddNew()

            DCortesBaches.RecordSet("CONTCORTE") = Eval(TContCorte.Text)
            DCortesBaches.RecordSet("CONTBACHE") = Eval(TContBache.Text)
            DCortesBaches.RecordSet("CODMAT") = TCodMat.Text
            DCortesBaches.RecordSet("NOMMAT") = TNomMat.Text
            DCortesBaches.RecordSet("PESOMETA") = DVarios.RecordSet("PESOMETA")
            DCortesBaches.RecordSet("PESOREAL") = DVarios.RecordSet("PESOREAL")
            DCortesBaches.RecordSet("LOTE") = TLote.Text.Trim
            DCortesBaches.RecordSet("DIFERENCIAKG") = Eval(TDiferenciaKg.Text)
            DCortesBaches.RecordSet("OBSERV") = CLeft(TObservaciones.Text, 250)

            DCortesBaches.Update(Me)

            'Si chcerrarubicaciom esta checkeada se actualizan todos los cortes de lote de esta mp que no tengan FechaFinUbic y que esten cerrados
            If ChCerrarUbicacion.Checked Then
                DVarios.Open("Update CORTESLOTE set FechaFinUbic='" + FechaC() + "' where FechaFinUbic='-' AND ESTADO='C' and CODMAT='" + TCodMat.Text + "'")
                Evento("ACTUALIZA CORTESLOTE FechaFinUbic='" + FechaC() + "' where ESTADO='C' and CODMAT='" + TCodMat.Text + "'")
            End If

            Me.Close()
            Me.Dispose()

        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub TContBache_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        If e.KeyCode = Keys.Enter Then TObservaciones.Focus()
    End Sub

    Private Sub BAceptarObsCorte_KeyUp(sender As Object, e As KeyEventArgs) Handles BAceptarObsCorte.KeyUp
        If e.KeyCode <> Keys.Enter Then Return
        BAceptarObsCorte_Click(Nothing, Nothing)
    End Sub

    Private Sub BCancelar_Click(sender As Object, e As EventArgs) Handles BCancelar.Click
        CortesMP.cancelarCortes = True
        Me.Close()
        Me.Dispose()
    End Sub
End Class