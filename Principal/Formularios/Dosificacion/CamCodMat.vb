Option Explicit On

Imports System.Windows.Forms
Imports System.Data.Common
Imports System.Data
Imports System.IO
Imports ClassLibrary
Public Class CamCodMat

    Private DArt As AdoSQL
    Private DFor As AdoSQL
    Private DDatosFor As AdoSQL
    Private DVarios As AdoSQL
    Private DConsultas As AdoSQL

    Private Sub CamCodMat_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try

            DArt = New AdoSQL("Materiales")
            DFor = New AdoSQL("Formulas Afectadas")
            DDatosFor = New AdoSQL("DATOSFOR")
            DConsultas = New AdoSQL("CONSULTAS")

            DArt.Open("Select * from ARTICULOS where TIPO='MP'")

            TextNum(TCodInt)
            'TCodInt.Focus()
        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub TCodMat_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TCodInt.KeyUp
        Try

            If Eval(TCodInt.Text) = 0 Then Return
            If e.KeyCode = Keys.Enter Then TCodInt2.Focus()


            DArt.Find("CODINT='" + TCodInt.Text + "'")

            If DArt.EOF Then
                TCodExt.Text = ""
                TNombre.Text = ""
                AsignaDataGrid(DGForAfectadas, Nothing)
                Return
            End If

            TCodExt.Text = DArt.RecordSet("CODEXT")
            TNombre.Text = DArt.RecordSet("NOMBRE")


            'DFor.Open("SELECT DatosFor.CodFor, DatosFor.PesoMeta, MIN(Formulas.NomFor) AS Nomfor" + _
            '          " FROM DatosFor INNER JOIN Formulas ON DatosFor.CodFor = Formulas.CodFor " + _
            '            " WHERE (DatosFor.CodMat = '" + TCodInt.Text + "') AND (DatosFor.CodFor = ANY " + _
            '              " (SELECT DISTINCT CodFor FROM  Formulas AS Formulas_1)) " + _
            '               " GROUP BY DatosFor.CodFor, DatosFor.PesoMeta ")

            'DFor.Open("SELECT CodFor, PesoMeta, LP, CodForB FROM dbo.DatosFor " + _
            '          "WHERE (CodFor = ANY (SELECT DISTINCT CodFor FROM dbo.Formulas)) AND (CodMat = '" + TCodInt.Text + "')")

            DFor.Open("Select dbo.Formulas.CodFor, dbo.Formulas.CodForB, dbo.Formulas.LP, dbo.Formulas.NomFor, sum(dbo.DatosFor.PesoMeta) as PesoMeta FROM dbo.Formulas INNER JOIN " +
                      " dbo.DatosFor ON dbo.Formulas.CodFor = dbo.DatosFor.CodFor AND dbo.Formulas.LP = dbo.DatosFor.LP WHERE (dbo.DatosFor.CodMat = '" + TCodInt.Text + "') group by  dbo.Formulas.CodFor, dbo.Formulas.nomfor, dbo.Formulas.codforb, dbo.Formulas.LP")



            AsignaDataGrid(DGForAfectadas, DFor.DataTable)


        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub BSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BSalir.Click
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub TCodMatB_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TCodExt.KeyUp
        Try

            If TCodExt.Text = "" Then Return
            If e.KeyCode = Keys.Enter Then TCodInt2.Focus()


            DArt.Find("CODEXT='" + TCodExt.Text + "'")

            If DArt.EOF Then
                TCodInt.Text = ""
                TNombre.Text = ""
                AsignaDataGrid(DGForAfectadas, Nothing)
                Return
            End If


            TCodInt.Text = DArt.RecordSet("CODINT")
            TNombre.Text = DArt.RecordSet("NOMBRE")

            DFor.Open("SELECT DatosFor.CodFor,DatosFor.PesoMeta, Formulas.NomFor " +
                                                "FROM DatosFor INNER JOIN Formulas ON DatosFor.CodFor = Formulas.CodFor AND dbo.Formulas.LP = dbo.DatosFor.LP" +
                                                "WHERE DatosFor.CodMat='" + TCodExt.Text + "' order by Formulas.NomFor")

            AsignaDataGrid(DGForAfectadas, DFor.DataTable)

        Catch ex As Exception
            MsgError(ex)
        End Try

    End Sub

    Private Sub BAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BAceptar.Click
        Try

            'If DRUsuario("FormMod") Then
            If ValidaPermiso("Formulas_Editar") Then
            Else
                MsgBox("No tiene permiso para ejecutar la acción solicitada", MsgBoxStyle.Information)
                Return
            End If


            If Eval(TCodInt.Text) = 0 Then Return
            If TCodExt.Text = "" Then Return
            If Eval(TCodInt2.Text) = 0 Then Return
            If TCodExt2.Text = "" Then Return
            If TNombre.Text = "" Then Return
            If TNombre2.Text = "" Then Return

            Resp = MsgBox("¿Está seguro que desea cambiar el ingrediente en todas las Fórmulas?", vbInformation + vbYesNo)
            If Resp = vbNo Then Exit Sub

            DArt.Find("CODINT='" + TCodInt2.Text + "'")

            If DArt.EOF Then
                MsgBox("El código de material " + TCodInt2.Text + " no se encuentra registado en la tabla de MATERIALES", vbInformation)
                Return
            End If

            DDatosFor.Open("Select * from DATOSFOR where CODMAT='" + TCodInt.Text + "'")


            For Each RecordSet As DataRow In DDatosFor.Rows
                RecordSet("CODMAT") = DArt.RecordSet("CODINT")
                RecordSet("CODMATB") = DArt.RecordSet("CODEXT")
                RecordSet("NOMMAT") = DArt.RecordSet("NOMBRE")
                RecordSet("TIPOMAT") = DArt.RecordSet("TIPOMAT")
                RecordSet("A") = DArt.RecordSet("A")
                If Val(TFactor.Text) > 0 And Val(TFactor.Text) < 1000 Then
                    DDatosFor.RecordSet("PESOMETA") = DDatosFor.RecordSet("PESOMETA") * Eval(TFactor.Text) / 100
                End If
                DDatosFor.Update(Me)
            Next


            MsgBox(DevuelveEvento(CodEvento.SISTEMA_PROCESOFINALIZADO), MsgBoxStyle.Information)

            BCancelar_Click(Nothing, Nothing)

            Evento(DevuelveEvento(CodEvento.BD_MODIFICAR), Me)
            'Evento("Cambia los códigos " + TCodInt.Text + " por " + TCodInt2.Text + " en todas las fórmulas")

        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub TCodMatB2_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TCodExt2.KeyUp
        Try

            If TCodExt2.Text = "" Then Return
            If e.KeyCode = Keys.Enter Then TFactor.Focus()


            DArt.Find("CODEXT='" + TCodExt2.Text + "'")

            If DArt.EOF Then
                TCodInt2.Text = ""
                TNombre2.Text = ""
                Return
            End If

            TCodInt2.Text = DArt.RecordSet("CODINT")
            TNombre2.Text = DArt.RecordSet("NOMBRE")

        Catch ex As Exception
            MsgError(ex)
        End Try

    End Sub

    Private Sub TCodMat2_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TCodInt2.KeyUp
        Try

            If Eval(TCodInt2.Text) = 0 Then Return
            If e.KeyCode = Keys.Enter Then TFactor.Focus()


            DArt.Find("CODINT='" + TCodInt2.Text + "'")

            If DArt.EOF Then
                TCodExt2.Text = ""
                TNombre2.Text = ""
                Return
            End If

            TCodExt2.Text = DArt.RecordSet("CODEXT")
            TNombre2.Text = DArt.RecordSet("NOMBRE")

        Catch ex As Exception
            MsgError(ex)
        End Try

    End Sub

    Private Sub BCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BCancelar.Click
        Try
            Limpiar_Habilitar_TextBox(Me.Controls, AccionTextBox.Limpiar)
            TFactor.Text = "100"
            AsignaDataGrid(DGForAfectadas, Nothing)
        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub BImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BImprimir.Click
        Dim RepSap As CrystalRep

        Try

            RepSap = New CrystalRep

            'Escribimos el codigo de amterial en el campo T8  de la tabla consultas

            If TCodInt.Text <> "" Then
                DConsultas.Open("Select * from CONSULTAS")

                If DConsultas.Count Then
                    DConsultas.RecordSet("T11") = TCodInt.Text
                    DConsultas.Update()
                End If
            End If


            With RepSap
                .ServerName = ServidorSQL

                .DataBaseName = NomDB
                .UserId = UserDB
                .Password = PWD
                .Formulas(0) = "PLANTA='" + Planta + "'"

                '.SelectionFormula = "{DatosFor.CodMat}='" + TCodInt.Text + "'"
                .Formulas(1) = "FECHA='" + Format(Now, "yyyy/MM/dd HH:mm") + "'"
                .Destination = CrystalRep.Destinacion.crToWindows
                .WindowState = FormWindowState.Maximized
                .ChoosePrint = True
                .MaximizeBox = True
                .MinimizeBox = True
                .ReportFileName = RutaRep + "rpMatxFor.rpt"
                .PrintReport()
            End With


        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub mnMateriales_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnMateriales.Click
        Materiales.ShowDialog()
    End Sub


    Private Sub mnFormulación_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnFormulación.Click
        Formulacion.ShowDialog()
    End Sub

    Private Sub mnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnSalir.Click
        Try
            BSalir_Click(Nothing, Nothing)
        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub mnReportes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnReportes.Click
        Reportes.ShowDialog()
    End Sub

    Private Sub CamCodMat_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        TCodInt.Focus()
    End Sub
End Class