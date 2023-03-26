Imports System.Windows.Forms
Imports System.Data.Common
Imports System.Data
Imports System.IO
Imports ClassLibrary

Public Class TablaModEnsaque

    Private DEmpaqueMod As AdoSQL
    Private DOPs As AdoSQL
    Private DProd As AdoSQL
    Private DVarios As AdoSQL


    Private Sub TablaModEnsaque_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try


            DEmpaqueMod = New AdoSQL("MODEMPAQUE")
            DOPs = New AdoSQL("OPS")
            DProd = New AdoSQL("PRODUCTOS")
            DVarios = New AdoSQL("VARIOS")

            DEmpaqueMod.Open("select * from EMPAQUE WHERE CONT=" + TContador.Text)
            If DEmpaqueMod.Count = 0 Then Return

            TConsecutivo.Text = DEmpaqueMod.RecordSet("CONSEC")
            TOrdDespacho.Text = DEmpaqueMod.RecordSet("ORDENDESP")
            TOP.Text = DEmpaqueMod.RecordSet("OP")
            'TCodFor = DEmpaqueMod.RecordSet("CODFORB")
            TCodProducto.Text = DEmpaqueMod.RecordSet("CODPROD")
            TNomProducto.Text = DEmpaqueMod.RecordSet("NOMPROD")
            'TNomForB = DEmpaqueMod.RecordSet("NOMFORB")
            TMaquina.Text = DEmpaqueMod.RecordSet("MAQUINA")
            TSacos.Text = DEmpaqueMod.RecordSet("SACOS")
            TPromedio.Text = DEmpaqueMod.RecordSet("PROMEDIO")
            TPeso.Text = DEmpaqueMod.RecordSet("PESO")
            TPresentacion.Text = DEmpaqueMod.RecordSet("PRESENT")
            TResiduo.Text = DEmpaqueMod.RecordSet("RESIDUO")
            TFecha.Text = DEmpaqueMod.RecordSet("FECHAINI")
            TCodEmpaque.Text = DEmpaqueMod.RecordSet("CODEMP")
            TCodEtiqueta.Text = DEmpaqueMod.RecordSet("CODETIQ")
            TCodHilaza.Text = DEmpaqueMod.RecordSet("CODHILAZA")
            TSacosDev.Text = DEmpaqueMod.RecordSet("SACOSDEV")
            TPesoDev.Text = DEmpaqueMod.RecordSet("PESODEV")

        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub BAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BAceptar.Click
        Try


            If Eval(TOrdDespacho.Text) = 0 Then
                MsgBox(DevuelveEvento(CodEvento.SISTEMA_FALTACAMPO) + "Ordén de despacho")
                Exit Sub
            End If

            If Eval(TMaquina.Text) = 0 Then
                MsgBox(DevuelveEvento(CodEvento.SISTEMA_FALTACAMPO) + " Máquina")
                Exit Sub
            End If

            If Eval(TOP.Text) = 0 Then
                MsgBox(DevuelveEvento(CodEvento.SISTEMA_FALTACAMPO) + " OP")
                Exit Sub
            End If

            If Eval(TPresentacion.Text) = 0 Then
                MsgBox(DevuelveEvento(CodEvento.SISTEMA_FALTACAMPO) + "Presentación")
                Exit Sub
            End If

            If Eval(TPeso.Text) = 0 Then
                MsgBox(DevuelveEvento(CodEvento.SISTEMA_FALTACAMPO) + " Peso")
                Exit Sub
            End If

            If Eval(TPromedio.Text) = 0 Then
                MsgBox(DevuelveEvento(CodEvento.SISTEMA_FALTACAMPO) + " Promedio")
                Exit Sub
            End If

            If Eval(TResiduo.Text) = 0 Then
                MsgBox(DevuelveEvento(CodEvento.SISTEMA_FALTACAMPO) + " Residuo")
                Exit Sub
            End If

            If Eval(TSacosDev.Text) = 0 Then
                MsgBox(DevuelveEvento(CodEvento.SISTEMA_FALTACAMPO) + " Sacos Dev.")
                Exit Sub
            End If

            DEmpaqueMod.Open("select * from EMPAQUE WHERE CONT=" + TContador.Text)

            If DEmpaqueMod.Count > 0 Then
                Resp = MessageBox.Show(DevuelveEvento(CodEvento.BD_REGYAEXISTE), "ChronoSoft", MessageBoxButtons.YesNo, MessageBoxIcon.Information)
                If Resp = vbNo Then Exit Sub
            Else
                DEmpaqueMod.AddNew()
            End If

            DEmpaqueMod.RecordSet("OP") = TOP.Text
            'DEmpaqueMod.RecordSet("CODFORB") = TCodForB
            DEmpaqueMod.RecordSet("CODPROD") = TCodProducto.Text
            DEmpaqueMod.RecordSet("NOMPROD") = TNomProducto.Text
            'DEmpaqueMod.RecordSet("NOMFORB") = TNomForB.text
            DEmpaqueMod.RecordSet("PROMEDIO") = Val(TPromedio.Text)
            DEmpaqueMod.RecordSet("PESO") = Val(TPeso.Text)
            DEmpaqueMod.RecordSet("RESIDUO") = Val(TResiduo.Text)
            DEmpaqueMod.RecordSet("CODEMP") = TCodEmpaque.Text
            DEmpaqueMod.RecordSet("CODETIQ") = TCodEtiqueta.Text
            DEmpaqueMod.RecordSet("CODHILAZA") = TCodHilaza.Text
            DEmpaqueMod.RecordSet("SACOSDEV") = Val(TSacosDev.Text)
            DEmpaqueMod.RecordSet("PESODEV") = Val(TPesoDev.Text)
            DEmpaqueMod.RecordSet("PRESENT") = Val(TPresentacion.Text)
            DEmpaqueMod.RecordSet("MAQUINA") = TMaquina.Text

            DEmpaqueMod.Update()

            DVarios.Open("select * from PRODTERM where CONTEMP=" + TContador.Text)
            If DVarios.Count > 0 Then
                DVarios.RecordSet("UNIDADESREAL") = DEmpaqueMod.RecordSet("SACOS") + DEmpaqueMod.RecordSet("SACOSDEV")
                DVarios.RecordSet("PESOREAL") = (DEmpaqueMod.RecordSet("SACOS") + DEmpaqueMod.RecordSet("SACOSDEV")) * DEmpaqueMod.RecordSet("PRESENT")
                DVarios.Update()
                'Else
                'Resp = CopyProdTerm(Val(TMaquina.Text), DEmpaqueMod.RecordSet("CONT"))

            End If

            MsgBox("Proceso finalizado", vbInformation)
            BSalir_Click(Nothing, Nothing)

        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub


    Private Sub BSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BSalir.Click
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub BFCambiar_Click(sender As Object, e As EventArgs) Handles BFCambiar.Click
        Try

            TPesoDev.Text = Val(TSacosDev.Text) * Val(TPresentacion.Text)
            If Val(TMaquina.Text) = 2 Then TPeso.Text = Val(TSacos.Text) * Val(TPresentacion.Text)

            DOPs.Open("select * from OPs where OP=" + TOP.Text)

            If DOPs.Count > 0 Then
                TCodProducto.Text = DOPs.RecordSet("CODPROD")
                TCodEmpaque.Text = DOPs.RecordSet("CODEMP")
                TCodEtiqueta.Text = DOPs.RecordSet("CODETIQ")
                TCodHilaza.Text = DOPs.RecordSet("CODHILAZA")
                TCodForm.Text = DOPs.RecordSet("CODFOR")
                TNomForm.Text = DOPs.RecordSet("NOMFOR")

                DProd.Open("select * From ARTICULOS where TIPO='PT' and CODINT='" + DOPs.RecordSet("CODPROD") + "'")

                If DProd.Count > 0 Then
                    TNomProducto.Text = DProd.RecordSet("NOMBRE")
                Else
                    TCodProducto.Text = "-"
                    TCodEmpaque.Text = "-"
                    TCodEtiqueta.Text = "-"
                    TCodHilaza.Text = "-"
                    TCodForm.Text = "-"
                    TNomForm.Text = "-"
                    TNomProducto.Text = "-"
                End If
            End If

        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub TOP_KeyUp(sender As Object, e As KeyEventArgs) Handles TOP.KeyUp
        If Val(TOP.Text) = 0 Then Return

        BFCambiar_Click(Nothing, Nothing)
    End Sub

    Private Sub TPresentacion_KeyUp(sender As Object, e As KeyEventArgs) Handles TPresentacion.KeyUp
        If Val(TPresentacion.Text) = 0 Then Return
        BFCambiar_Click(Nothing, Nothing)
    End Sub

    Private Sub TSacosDev_KeyUp(sender As Object, e As KeyEventArgs) Handles TSacosDev.KeyUp
        If Val(TSacosDev.Text) = 0 Then Return
        BFCambiar_Click(Nothing, Nothing)
    End Sub
End Class