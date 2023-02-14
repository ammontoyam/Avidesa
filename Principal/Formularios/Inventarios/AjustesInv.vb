Option Explicit On
Imports System
Imports System.Data
Imports System.IO
Imports ClassLibrary

Public Class AjustesInv

    Private DArt As AdoSQL
    Private DUbic As AdoSQL
    Private DMovInv As AdoSQL
    Private DVarios As AdoSQL
    Private Fila As Int32
    Private Consulta As String

    Private Sub AjustesInv_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            DArt = New AdoSQL("ARTICULOS")
            DUbic = New AdoSQL("UBICACIONES")
            DMovInv = New AdoSQL("MOVINV")
            DVarios = New AdoSQL("VARIOS")

            DArt.Open("select * from ARTICULOS order by CODINT")

            'Solo se cargan las ubicaciones del producto terminado ya que solo se hacen ajustes de PT
            DUbic.Open("Select * from UBICACIONES where TIPO='PT' order by CODUBI")


            'Llenamos el combobox ubicaciones
            LLenaComboBox(CUbicacion, DUbic.DataTable, "CODUBI")
            TextNum(TCantidad, True)

            Consulta = "select * from MOVINV where Detalle = 'AJUSTEINVENTARIO' "


            If OpChronos.Checked Then Consulta += "and TIPOMOV='CHRONOS' "
            If OpFisico.Checked Then Consulta += "and TIPOMOV='FISICO' "

            If OpEntra.Checked Then
                TTipoMov.Text = "ENTRADAS INVENTARIO"
                TTipoMov.BackColor = Color.SteelBlue
            End If

            If OpSale.Checked Then
                TTipoMov.Text = "SALIDAS INVENTARIO"
                TTipoMov.BackColor = Color.YellowGreen
            End If


            Consulta += " and FECHA>='" + Now.ToString("yyyy/MM/dd") + "' order by ID"

            DMovInv.Open(Consulta)

            AsignaDataGrid(DGAjustInv, DMovInv.DataTable)


        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub TCodInt_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TCodInt.KeyUp
        Try
            If e.KeyCode <> Keys.Enter Then Return

            DArt.Find("CODINT='" + TCodInt.Text.Trim + "'")
            TNombre.Text = ""
            If DArt.EOF Then
                MsgBox(DevuelveEvento(CodEvento.BD_REGNOEXISTE) + ", el Artículo ingresado no existe", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                'MsgBox("Artículo ingresado no existe", MsgBoxStyle.Information)
                Return
            End If

            TNombre.Text = DArt.RecordSet("NOMBRE")

        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub BAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BAceptar.Click
        Try
            Dim Cantidad As Double
            Dim Unidades As Integer
            Dim TipoMat As String
            Dim Observaciones As String
            Dim InvTipo As Int32

            BAceptar.Enabled = False

            If TCodInt.Text = "" Then
                MsgBox(DevuelveEvento(CodEvento.SISTEMA_FALTACAMPO) + "Artículo", MessageBoxButtons.OK, MessageBoxIcon.Information)
                'MsgBox("Artículo ingresado no es válido", MsgBoxStyle.Information)
                GoTo Salir
            End If

            If TLote.Text = "" Then
                MsgBox(DevuelveEvento(CodEvento.SISTEMA_FALTACAMPO) + "lote", MessageBoxButtons.OK, MessageBoxIcon.Information)
                ' MsgBox("Campo lote no puede ser vacio", vbInformation)
                GoTo Salir
            End If

            DArt.Find("CODINT='" + TCodInt.Text.Trim + "'")
            If DArt.EOF Then
                MsgBox(DevuelveEvento(CodEvento.BD_REGNOEXISTE) + ", el Artículo ingresado no existe", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                'MsgBox("Artículo ingresado no existe", MsgBoxStyle.Information)
                GoTo Salir
            End If

            If CUbicacion.Text = "" Then
                MsgBox(DevuelveEvento(CodEvento.SISTEMA_FALTACAMPO) + ":ubicación", MessageBoxButtons.OK, MessageBoxIcon.Information)
                'MsgBox("Debe ingresar una ubicación válida", MsgBoxStyle.Information)
                GoTo Salir
            End If

            TNombre.Text = DArt.RecordSet("NOMBRE")

            If Eval(TCantidad.Text) <= 0 Then
                MsgBox(DevuelveEvento(CodEvento.SISTEMA_ERROR) + "No puede realizar un ajuste con cantidad negativa", MessageBoxButtons.OK, MessageBoxIcon.Information)
                'MsgBox("No puede realizar un ajuste con cantidad negativa", MsgBoxStyle.Critical)
                GoTo Salir
            End If


            TipoMat = DArt.RecordSet("TIPO")

            If OpEntra.Checked Then Cantidad = Eval(TCantidad.Text)
            If OpSale.Checked Then Cantidad = -Eval(TCantidad.Text)
            If Cantidad = 0 Then GoTo Salir


            Unidades = 0
            InvTipo = 0

            If OpFisico.Checked Then InvTipo = TipoInv.FISICO
            If OpChronos.Checked Then InvTipo = TipoInv.CHRONOS

            If InvTipo = TipoInv.FISICO And TipoMat = "PT" Then
                DVarios.Open("Select * from ARTICULOS where TIPO='PT' and CODINT='" + TCodInt.Text.Trim + "'")
                If DVarios.Count > 0 Then
                    If DVarios.RecordSet("PRESKG") And Not IsDBNull(DVarios.RecordSet("PRESKG")) > 0 Then
                        Unidades = Cantidad / DVarios.RecordSet("PRESKG")
                        Cantidad = Unidades
                    End If

                End If
            End If

            If TObservaciones.TextLength > 0 Then
                Observaciones = TObservaciones.Text
            Else
                Observaciones = "Ajuste de inventario Art. " + TCodInt.Text + " " + TNombre.Text + " Cant " + TCantidad.Text
            End If

            Observaciones = CLeft(Observaciones, 50).ToUpper
            'Inventario(TCodInt.Text, Cantidad, InvTipo, TLote.Text, DetOperacion.AJUSTEINVENTARIO, CUbicacion.Text, , Unidades, , , Observaciones, , Usuario)

            Dim Invent As New DescInvent

            With Invent
                .CodInt = TCodInt.Text
                .Cantidad = Cantidad
                .TipoInv = InvTipo
                .Lote = TLote.Text
                .Detalle = DescInvent.DetOperacion.AJUSTEINVENTARIO
                .Ubicacion = CUbicacion.Text
                .Unds = Unidades
                .Observaciones = Observaciones
                .Usuario = UsuarioPrincipal
                .Inventario()
            End With
            MsgBox(DevuelveEvento(CodEvento.SISTEMA_PROCESOFINALIZADO))
            'MsgBox("Datos almacenados correctamente", MsgBoxStyle.Information)

            BCancelar_Click(Nothing, Nothing)
            AjustesInv_Load(Nothing, Nothing)

Salir:
            BAceptar.Enabled = True

        Catch ex As Exception
            MsgBox(ex)
        End Try
    End Sub

    Private Sub BCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BCancelar.Click
        Try
            TCodInt.Text = ""
            TNombre.Text = ""
            TLote.Text = ""
            TCantidad.Text = ""
            CUbicacion.Text = ""
            TObservaciones.Text = ""

        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

   
    Private Sub OpSale_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OpSale.Click
        Try

            If OpSale.Checked Then
                TTipoMov.Text = "SALIDAS INVENTARIO"
                TTipoMov.BackColor = Color.YellowGreen
            End If
        Catch ex As Exception
            MsgBox(ex)
        End Try
    End Sub

    Private Sub OpEntra_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OpEntra.Click
        Try
            If OpEntra.Checked Then
                TTipoMov.Text = "ENTRADAS INVENTARIO"
                TTipoMov.BackColor = Color.SteelBlue
            End If

        Catch ex As Exception
            MsgBox(ex)
        End Try
    End Sub

    Private Sub BNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BNuevo.Click
        BCancelar_Click(Nothing, Nothing)
    End Sub

    Private Sub BActualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BActualizar.Click
        AjustesInv_Load(Nothing, Nothing)
    End Sub

    Private Sub BSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BSalir.Click
        Me.Close()
        Me.Dispose()

    End Sub

    Private Sub BAceptar_KeyUp(sender As Object, e As KeyEventArgs) Handles BAceptar.KeyUp
        If e.KeyCode = Keys.Enter Then BAceptar_Click(Nothing, Nothing)
    End Sub
End Class