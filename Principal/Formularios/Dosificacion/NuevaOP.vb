Option Explicit On

Imports System.Windows.Forms
Imports System.Data.Common
Imports System.Data
Imports System.IO
Imports ClassLibrary

Public Class NuevaOP
    Private DOPs As AdoSQL
    Private DOPsPrem As AdoSQL
    Private DOPsEmp As AdoSQL
    Private DFor As AdoSQL
    Private DArt As AdoSQL
    Private DClientes As AdoSQL
    Private DVarios As AdoSQL
    Private DCodEmpEtiq As AdoSQL
    Private DLineasProd As AdoSQL
    Private DEmp As AdoSQL
    Private DDatosFor As AdoSQL
    Private DConsumosMed As AdoSQL
    Private Dtolvas As AdoSQL
    Private DConfig As AdoSQL
    Private DCortes As AdoSQL
    Private DBaches As AdoSQL
    Private DEmpEtiqDet As AdoSQL
    Private DCortesMP As AdoSQL
    Private DEquivFormProd As AdoSQL
    Private DEspecies As AdoSQL
    Private PlantaExt As String
    Private FiltroPlantaExt As String


    ' Private Rep1 As CrystalRep

    Private SentenciaSQL As String

    Private Fila As Integer
    Private Campos() As String
    Private FechaProg As Date
    Private EmpEtiq As String
    Private FormLoad
    Private EncontroEmp As Boolean = False
    Private EncontroEtiq As Boolean = False

    Private NuevaOP As Boolean


    Public Sub NuevaOP_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            NuevaOP = False
            If FormLoad Then
                BActualizar_Click(Nothing, Nothing)
                Return
            End If

            GBDestinosPeletizado.Enabled = False
            GBFunPremezcla.Enabled = False

            If Funcion_PlantasExternas Then
                GBPlantas.Visible = True
                If OPPlantaGir.Checked Then
                    FiltroPlantaExt = "GIR"
                ElseIf OPPlantaYar.Checked Then
                    FiltroPlantaExt = "YAR"
                Else
                    FiltroPlantaExt = "STRO"
                End If
            End If

            If Not Funcion_MaterialesBandeja And Not Planta.Contains("ITALCOL S.A PLANTA FUNZA") Then 'Se esconden los campos de los catagrid de OPs
                DGOPsDos.Columns.Remove("DGOPsDos_RealMan1") 'Pesada menor 1
                DGOPsDos.Columns.Remove("DGOPsDos_RealMan2") 'Bandeja
                DGOPsPrem.Columns.Remove("DGOPsPrem_RealMan1") 'Pesada menor 1
                DGOPsPrem.Columns.Remove("DGOPsPrem_RealMan2") 'Bandejas
            End If

            If Planta.Contains("ITALCOL S.A PLANTA FUNZA") Then
                DGOPsDos.Columns.Remove("DGOPsDos_RealMan") 'Pesada menor 1
                DGOPsDos.Columns("DGOPsDos_RealMan2").HeaderText = "P.M2"
            End If

            If Funcion_FuncionesPlantaPremezclas Then
                GBDestinosPeletizado.Visible = False
                GBDestinosPeletizado.SendToBack()
                GBDestino.Location = New Point(12, 397)
                GBDestino.Visible = True
                GBDestino.BringToFront()
                GBEmpEtiqAdic.Location = New Point(12, 533)
                GBEmpEtiqAdic.Width = 456
                GBEmpEtiqAdic.Visible = True
                GBEmpEtiqAdic.BringToFront()
                BSubeOPDosif.Visible = False
                BBajaOPDosif.Visible = False
                LOpsPrem.Visible = False
                DGOPsPrem.Visible = False
                DGListEmp.Visible = True
                LEmpaquesEtiquetas.Visible = True
                TNumPaq.Visible = True
                LNumPaq.Visible = True

                DGOPsDos.Columns("DGOPsDos_MicHab").Visible = False
                DGOPsDos.Columns("DGOPsDos_RealMan").Visible = False
                ' DGOPsDos.Columns("DGOPsDos_RealMan1").Visible = False
                DGOPsDos.Columns("DGOPsDos_RealMed").Visible = False
            Else
                GBDestinosPeletizado.Visible = True
                GBDestinosPeletizado.BringToFront()
                GBDestinosPeletizado.Location = New Point(12, 397)
                GBDestino.Visible = False
                LTotalFor.Visible = False
                TTotalFor.Visible = False
                LPaqxBache.Visible = False
                TNumPaqxBache.Visible = False
            End If

            If Funcion_ManejaFunPremezcla Then GBFunPremezcla.Enabled = True
            If Funcion_DestinosPeletizado Then GBDestinosPeletizado.Enabled = True

            GBDestinoPLC.Visible = False
            If Funcion_ManejaDestinoPLC Then
                GBDestinoPLC.Visible = True
                GBDestinoPLC.Enabled = True
            End If


            DOPs = New AdoSQL("OPs")
            DOPsPrem = New AdoSQL("OPs")
            DFor = New AdoSQL("FORMULAS")
            DArt = New AdoSQL("ARTICULOS")
            DClientes = New AdoSQL("CLIENTES")
            DVarios = New AdoSQL("VARIOS")
            DLineasProd = New AdoSQL("LineasProd")
            DDatosFor = New AdoSQL("DatosFor")
            DConsumosMed = New AdoSQL("ConsumosMed")
            Dtolvas = New AdoSQL("Tolvas")
            DConfig = New AdoSQL("Config")
            DCortes = New AdoSQL("CortesLote")
            DEmp = New AdoSQL("Empaque")
            DBaches = New AdoSQL("Baches")
            DEmpEtiqDet = New AdoSQL("EmpaquesyEtiquetas")
            DCortesMP = New AdoSQL("CortesLote")
            DEquivFormProd = New AdoSQL("EquivFormProd")
            DEspecies = New AdoSQL("Especies")

            'Restringe campos a solo numericos

            TextNum(TOPs)
            TextNum(TMeta)
            TextNum(TBAhora)
            TextNum(TPorc)

            DGOPsPrem.Enabled = True
            DGOPsDos.Enabled = True

            DGFor.Visible = False
            DGProd.Visible = False
            DGClientes.Visible = False

            DLineasProd.Open("Select LINEA FROM LINEASPROD where TIPO='LN'")

            LLenaComboBox(CBLinea, DLineasProd.DataTable, "LINEA")
            LLenaComboBox(CLinea, DLineasProd.DataTable, "LINEA")

            'Cargamos los DGs de OPs
            BActualizar_Click(Nothing, Nothing)

            Campos = {"OP@OP", "CODFOR@Cod.For"}
            Campos = AsignaItemsCB(Campos, CBBuscar.ComboBox, DOPs.DataTable)
            Limpiar_Habilitar_TextBox(Me.Controls, AccionTextBox.Deshabilitar)
            CBLinea.Enabled = False

            FormLoad = True

            'Deshabilita el botón de traslado de micros
            If Not Funcion_ManejaTrasladoMicros Then BCambiaOPMic.Enabled = False

            'Se carga el módulo de formulación por si se ingreso al modulo de Ops sin abrir el de formulacion
            Formulacion.Formulacion_Load(Nothing, Nothing)

        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub
    Private Sub TBuscar_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TBuscar.KeyUp
        Try

            Dim x As Integer
            Dim Hallado As Boolean

            If CBBuscar.Text = "" Then
                CBBuscar.Focus()
                MsgBox("Debe seleccionar el campo a buscar", MsgBoxStyle.Exclamation)
                TBuscar.Text = ""
                Exit Sub
            End If

            If TBuscar.Text = "" Then
                'NuevaOP_Load(Nothing, Nothing)
                BActualizar_Click(Nothing, Nothing)
                Exit Sub
            End If

            x = CBBuscar.SelectedIndex

            If Funcion_FuncionesPlantaPremezclas Then
            Else
                If TipoCampo(Campos(x), DOPsPrem.DataTable) <> "String" And e.KeyCode <> Keys.Enter Then Return
                BusquedaDG(DGOPsPrem, DOPsPrem.DataTable, TBuscar.Text, Campos(x), Hallado)
            End If

            If Hallado = False Then
                BusquedaDG(DGOPsDos, DOPs.DataTable, TBuscar.Text, Campos(x), Hallado)
                If Hallado = False Then
                    ''BusquedaDG(DGOPsEmp, DOPsEmp.DataTable, TBuscar.Text, Campos(x), Hallado)
                    If Hallado = False Then
                        'CBBuscar.Focus()
                        'MsgBox("Registro no encontrado", MsgBoxStyle.Information)
                        Exit Sub
                    End If
                    Return
                End If
                DGOPsDos_CellClick(Nothing, Nothing)
                Return
            End If
            If Funcion_FuncionesPlantaPremezclas Then
            Else
                DGOPsPrem_CellClick(Nothing, Nothing)
            End If


        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub BSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BSalir.Click, mnSalir.Click
        Try
            ''Formulacion.Formulacion_Load(Nothing, Nothing)
            If Eval(TOPs.Text) > 0 Then
                ''Formulacion.BActualizar_Click(Nothing, Nothing)
                ''Formulacion.BBuscaForm_Click(Nothing, Nothing, TCodFor.Text, TLP.Text)
                Formulacion.TPorc.Text = TPorc.Text
                Formulacion.TBaches.Text = TMeta.Text
                Formulacion.TOPs.Text = TOPs.Text
            End If
            Me.Hide()

            If Formulacion.Visible Then
                'Formulacion.BActualizar_Click(Nothing, Nothing)
                Formulacion.BBuscaForm_Click(Nothing, Nothing, TCodFor.Text, TLP.Text)
            End If

        Catch ex As Exception
            MsgError(ex)
        End Try

    End Sub

    Private Sub DGFor_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGFor.CellClick
        Try
            If DGFor.Rows.Count = 0 Then Exit Sub

            DFor.Find("CODFOR='" + DGFor.Rows(DGFor.CurrentRow.Index).Cells("DGFOR_CODFOR").Value.ToString + "' AND LP='" + DGFor.Rows(DGFor.CurrentRow.Index).Cells("DGFOR_LP").Value.ToString + "'")
            TCodPrem.Text = DGFor.Rows(DGFor.CurrentRow.Index).Cells("DGFOR_CODPREMEZCLA").Value.ToString
            If DFor.EOF = False Then
                TTotalFor.Text = DFor.RecordSet("TOTALFOR")

                If Funcion_ManejaSecuenciaMezcla Then
                    If Eval(DFor.RecordSet("CODESPECIE").ToString) = 0 Then
                        MsgBox(DevuelveEvento(CodEvento.SISTEMA_FALTACAMPO, " Código especie"), MsgBoxStyle.Information)
                        TCodFor.Text = ""
                        TCodFor.Focus()
                        Return
                    ElseIf Eval(DFor.RecordSet("CODGRPFOR").ToString) = 0 Then
                        MsgBox(DevuelveEvento(CodEvento.SISTEMA_FALTACAMPO, " Código grupo de fórmula"), MsgBoxStyle.Information)
                        TCodFor.Text = ""
                        TCodFor.Focus()
                        Return
                    ElseIf DFor.RecordSet("MANEJAPX") And TCodPrem.Text = "" Then
                        MsgBox(DevuelveEvento(CodEvento.SISTEMA_FALTACAMPO, " Código premezcla"), MsgBoxStyle.Information)
                        Exit Sub
                    End If
                End If
            End If

            TCodFor.Text = DGFor.Rows(DGFor.CurrentRow.Index).Cells("DGFOR_CODFOR").Value.ToString
            TCodForB.Text = DGFor.Rows(DGFor.CurrentRow.Index).Cells("DGFOR_CODFORB").Value.ToString
            TNomFor.Text = DGFor.Rows(DGFor.CurrentRow.Index).Cells("DGFOR_NOMFOR").Value.ToString
            TLP.Text = DGFor.Rows(DGFor.CurrentRow.Index).Cells("DGFOR_LP").Value.ToString
            ChManejaPx.Checked = DGFor.Rows(DGFor.CurrentRow.Index).Cells("DGFOR_MANEJAPX").Value
            DGFor.Visible = False

            If Funcion_ManejaFunPremezcla Then
                FComboPrem_Click(Nothing, Nothing)
            End If

            FBuscaProdEquivalentes()

            If Funcion_FuncionesPlantaPremezclas Then
                If DFor.RecordSet("CODFORB") <> "-" Then
                    TCodProd.Text = DFor.RecordSet("CODFORB")
                Else
                    TCodProd.Text = TCodFor.Text
                End If
                TPresKg.Text = DFor.RecordSet("PESOPAQ")
                TTotalFor.Text = DFor.RecordSet("TOTALFOR")
                TNumPaqxBache.Text = DFor.RecordSet("NUMPAQXBACHE")

                'Buscamos el código de producto
                DVarios.Open("Select * from ARTICULOS where TIPO='PT' and CODINT='" + TCodProd.Text + "'")
                If DVarios.Count = 0 Then
                    MsgBox("Producto no creado para la fórmula, favor crear el producto en el sistema", vbCritical)
                    BActualizar_Click(Nothing, Nothing)
                    Return
                End If

                TCodEmp.Text = DVarios.RecordSet("CODEMP")
                TCodEtiq.Text = DVarios.RecordSet("CODETIQ")
                TPresEmp.Text = DVarios.RecordSet("PRESEMP")
                TPresText.Text = DVarios.RecordSet("PRESTEXT")
                TNomProd.Text = DVarios.RecordSet("NOMBRE")

                If DVarios.RecordSet("MANEJAEMP") Then
                    DArt.Open("Select * from ARTICULOS where TIPO='EM' and CODINT='" + TCodEmp.Text + "'")

                    If DArt.Count = 0 Then
                        MsgBox("Empaque no creado para el producto", vbCritical)
                        BActualizar_Click(Nothing, Nothing)
                        Return
                    Else
                        TNomEmp.Text = DArt.RecordSet("NOMBRE")
                    End If

                End If

                'If DVarios.RecordSet("MANEJAETIQ") Then

                '    DArt.Open("Select * from ARTICULOS where TIPO='ET' and CODINT='" + TCodEtiq.Text + "'")

                '    If DArt.Count = 0 Then
                '        MsgBox("Etiqueta no creada para el producto", vbCritical)
                '        BActualizar_Click(Nothing, Nothing)
                '        Return
                '    Else
                '        TNomEtiq.Text = DArt.RecordSet("NOMBRE")
                '    End If
                'End If
            End If



            TMeta.Focus()

        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub TMeta_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TMeta.Enter
        Try
            DGFor.Visible = False
        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub BNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BNuevo.Click
        Try

            'If DRUsuario("OPsMod") Then
            If ValidaPermiso("OPs_Editar") Then
            Else
                MsgBox(DevuelveEvento(CodEvento.USUARIO_PERMISODENEGADO), MsgBoxStyle.Information)
                Exit Sub
            End If

            BCancelar_Click(Nothing, Nothing)
            Limpiar_Habilitar_TextBox(Me.Controls, AccionTextBox.Habilitar)
            FReadOnly_Click(Nothing, Nothing)
            TBachesTanda.Text = "1"


            If Funcion_DestinosPeletizado Then
                CBLinea.Enabled = True
                CDestino1.Enabled = True
                CDestino2.Enabled = True
                CDestino3.Enabled = True
            End If

            If Funcion_ManejaFunPremezcla Then
                CCodPrem.Enabled = True
                CLotePrem.Enabled = True
            End If

            'se deshabilita el grupo de plantas externas para evitar generar un consecutivo de OP y guardar para otra planta
            If GBPlantas.Visible = True Then GBPlantas.Enabled = False

            'Si se debe tener en cuenta para el consecutivo de la OP
            If Funcion_PlantasExternas Then
                If OPPlantaGir.Checked Then
                    FiltroPlantaExt = "GIR"
                    'PlantaExt = "GIR"
                ElseIf OPPlantaSantaRosa.Checked Then
                    FiltroPlantaExt = "STRO"
                    'PlantaExt = "STRO"
                ElseIf OPPlantaYar.Checked Then
                    FiltroPlantaExt = "YAR"
                    PlantaExt = "YAR"
                End If
                Dim CampoConfigOP As String = "ULTIMAOP" + FiltroPlantaExt 'PlantaExt
                DConfig.Open("select * from CONFIG")
                If DConfig.Count Then
                    TOPs.Text = Val(DConfig.RecordSet(CampoConfigOP)) + 1
                    DVarios.Open("select OP from OPS where OP='" + TOPs.Text + "' AND PLANTA='" + FiltroPlantaExt + "'") 'PlantaExt + "'")
                    Do While DVarios.Count
                        TOPs.Text = Val(TOPs.Text) + 1
                        DVarios.Open("select OP from OPS where OP='" + TOPs.Text + "' AND PLANTA='" + FiltroPlantaExt + "'") 'PlantaExt + "'")
                    Loop
                End If
            Else
                DVarios.Open("Select max(convert(bigint,op)) as ULTIMAOP from ops")
                DGOPsPrem.Enabled = False
                If Not IsDBNull(DVarios.RecordSet("ULTIMAOP")) Then
                    TOPs.Text = (Eval(DVarios.RecordSet("ULTIMAOP")) + 1).ToString
                Else
                    TOPs.Text = 1
                End If
            End If

            NuevaOP = True

            TCodFor.Focus()

        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub DGOPsPrem_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGOPsPrem.CellClick
        Try
            If e Is Nothing OrElse e.RowIndex < 0 Then Return 'Cuando dan click en el encabezado de alguna columna del datagrid

            If DGOPsPrem.CurrentRow Is Nothing Then Return
            If DGOPsPrem.Rows.Count = 0 Then Exit Sub
            Fila = DGOPsPrem.CurrentRow.Index + 1
            BBuscaOP_Click(Nothing, Nothing, DGOPsPrem.Rows(DGOPsPrem.CurrentRow.Index).Cells("DGOPsPrem_OP").Value.ToString)

        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub TCodFor_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles TCodFor.Enter
        Try
            DGFor.Location = New Point(138, 123)
            DGFor.Visible = True
            DGFor.BringToFront()
        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub


    Private Sub TCodProd_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TCodProd.Enter
        Try
            DGProd.Height = 251
            DGProd.Location = New Point(139, 206)
            DGProd.Visible = True
            DGProd.BringToFront()
        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub TCodProd_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TCodProd.Leave
        Try
            'DGProd.Visible = False
        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub TCodCli_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TCodCli.Enter
        Try
            DGClientes.Height = 251
            DGClientes.Location = New Point(139, 360)
            DGClientes.Visible = True
            DGProd.Visible = False
        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub TCodCli_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TCodCli.Leave
        Try
            'DGClientes.Visible = False
        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub
    Private Sub TCodFor_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TCodFor.KeyUp
        Try
            If e.KeyCode = Keys.Enter AndAlso DGFor.Rows.Count = 1 Then
                DGFor_CellClick(Nothing, Nothing)
                Exit Sub
            End If

            If e.KeyCode = Keys.Back Then
                TNomFor.Text = ""
                'TNomForB.Text = ""
                TLP.Text = ""
                TCodForB.Text = ""
            End If

            If TCodFor.Text = "" Then
                'Vuelve a asignar al datagrid todas las formulas de la tabla
                AsignaDataGrid(DGFor, DFor.DataTable, True)
                Exit Sub
            End If

            Dim Hallado As Boolean

            BusquedaDG(DGFor, DFor.DataTable, TCodFor.Text, "CODFOR", Hallado)

            If Hallado = False Then
                TCodForB.Focus()
                'MsgBox("Registro no encontrado", MsgBoxStyle.Information)
                Exit Sub
            End If

        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub BCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BCancelar.Click
        Try
            Limpiar_Habilitar_TextBox(Me.Controls, AccionTextBox.Limpiar)
            Limpiar_Habilitar_TextBox(Me.Controls, AccionTextBox.Deshabilitar)
            TPorc.Text = 100
            TPresKg.Text = ""
            TPresEmp.Text = ""
            TPresText.Text = ""

            If Funcion_ManejaFunPremezcla Then
                CCodPrem.Text = ""
                CLotePrem.Text = ""
                CCodPrem.Enabled = False
                CLotePrem.DropDownStyle = ComboBoxStyle.DropDownList
                CCodPrem.DropDownStyle = ComboBoxStyle.DropDownList
            End If

            If Funcion_DestinosPeletizado Then
                CBLinea.Enabled = False
                CDestino1.Items.Clear()
                CDestino2.Items.Clear()
                CDestino3.Items.Clear()
                CDestino1.Enabled = False
                CDestino2.Enabled = False
                CDestino3.Enabled = False
                CDestino1.Text = "X"
                CDestino2.Text = "X"
                CDestino3.Text = "X"
            End If

            DOPs.Open("Select * from OPS where ESTADO=10 and FINALIZADO='N' order by SECUENCIA")

            DGOPsPrem.Enabled = True
            DGFor.Visible = False
            DGProd.Visible = False
            DGClientes.Visible = False
            ChVentas.Checked = False
            NuevaOP = False
            'Luego de finalizar la creación de una OP se habilita el grupo de plantas externas
            If GBPlantas.Visible = True Then GBPlantas.Enabled = True

        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub



    Private Sub TCodProd_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TCodProd.KeyUp
        Try
            If e.KeyCode = Keys.Escape Then Return
            Dim Hallado As Boolean
            If e.KeyCode = Keys.Enter AndAlso DGProd.Rows.Count = 1 Then
                DGProd_CellClick(Nothing, Nothing)
                TCodCli.Focus()
                Exit Sub
            End If

            If e.KeyCode = Keys.Back Then
                TNomProd.Text = ""
                TCodEmp.Text = ""
                TCodEtiq.Text = ""
                TPresEmp.Text = ""
                TPresKg.Text = ""
                TPresText.Text = ""
                TNomEmp.Text = ""
                TNomEtiq.Text = ""
            End If

            'Se vuelve a cargar el DGProd con con la tabla de articulos
            DArt.Open("select * from ARTICULOS where TIPO='PT' ORDER BY NOMBRE")
            If DArt.Count = 0 Then Exit Sub

            If TCodProd.Text = "" Then
                AsignaDataGrid(DGProd, DArt.DataTable)
            End If

            BusquedaDG(DGProd, DArt.DataTable, TCodProd.Text, "CODINT", Hallado)

            If Hallado = False Then
                ' TCodForB.Focus()
                'MsgBox("Registro no encontrado", MsgBoxStyle.Information)
                Exit Sub
            End If
        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub





    Private Sub DGClientes_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGClientes.CellClick

        Try
            If DGClientes.Rows.Count = 0 Then Exit Sub

            TCodCli.Text = DGClientes.Rows(DGClientes.CurrentRow.Index).Cells("CODCLI").Value.ToString
            TNomCli.Text = DGClientes.Rows(DGClientes.CurrentRow.Index).Cells("NOMCLI").Value.ToString

            If Funcion_FuncionesPlantaPremezclas Then
                CLinea.DroppedDown = True
            Else
                TObservOP.Focus()
            End If

            DGClientes.Visible = False

        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub TCodCli_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TCodCli.KeyUp
        Try
            Dim Hallado As Boolean
            If e.KeyCode = Keys.Enter AndAlso DGClientes.Rows.Count = 1 Then
                DGClientes_CellClick(Nothing, Nothing)
                Exit Sub
            End If

            If e.KeyCode = Keys.Back Then
                TNomCli.Text = ""
            End If

            'Se vuelve a cargar el DGClientes con con la tabla de clientes

            If TCodCli.Text = "" Then
                AsignaDataGrid(DGClientes, DClientes.DataTable)
            End If

            BusquedaDG(DGClientes, DClientes.DataTable, TCodCli.Text, "CODCLI", Hallado)

            If Hallado = False Then
                TCodProd.Focus()
                'MsgBox("Registro no encontrado", MsgBoxStyle.Information)
                Exit Sub
            End If

            If e.KeyCode = Keys.Enter Then
                If Funcion_DestinosPeletizado Then CBLinea.Focus()
                If Funcion_FuncionesPlantaPremezclas Then CLinea.Focus()
            End If
        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub


    Private Sub DGProd_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGProd.CellClick
        Try
            Dim CodEtiq, CodEmp As String
            If DGProd.Rows.Count = 0 Then Exit Sub

            DArt.Open("select * from ARTICULOS where TIPO='PT' and CODINT='" + DGProd.Rows(DGProd.CurrentRow.Index).Cells("CODINT").Value.ToString + "'")
            If DArt.Count = 0 Then Exit Sub

            TCodProd.Text = DArt.RecordSet("CODINT").ToString
            TNomProd.Text = DArt.RecordSet("NOMBRE").ToString
            TPresEmp.Text = DArt.RecordSet("PRESEMP").ToString
            TPresText.Text = DArt.RecordSet("PRESTEXT").ToString
            TPresKg.Text = DArt.RecordSet("PRESKG").ToString
            CodEmp = DArt.RecordSet("CODEMP").ToString
            CodEtiq = DArt.RecordSet("CODETIQ").ToString

            TCodEmp.Text = CodEmp
            TCodEtiq.Text = CodEtiq
            DGProd.Visible = False

            'Seguridad sólo para Premezclas Girardota. El código del producto debe ser el mismo de la Premezcla
            If Funcion_PlantasExternas Then
                If TCodPrem.Text.Trim.ToUpper <> TCodProd.Text.Trim.ToUpper Then
                    MsgBox("El código del producto es diferente al código de la Premezcla", MsgBoxStyle.Critical)
                    TCodProd.Text = ""
                    TNomProd.Text = ""
                End If
            End If

        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub TObservOP_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TObservOP.Enter
        Try
            DGClientes.Visible = False
        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub BAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BAceptar.Click
        Try

            'Validación de campos

            If Eval(TOPs.Text) = 0 Then
                MsgBox(DevuelveEvento(CodEvento.SISTEMA_FALTACAMPO, "OP"), MsgBoxStyle.Critical)
                Exit Sub
            End If

            If TCodFor.Text = "" Then
                MsgBox(DevuelveEvento(CodEvento.SISTEMA_FALTACAMPO, " Código de fórmula"), MsgBoxStyle.Critical)
                Exit Sub
            End If

            If TNomFor.Text = "" Then
                MsgBox(DevuelveEvento(CodEvento.SISTEMA_FALTACAMPO, " Nombre de fórmula"), MsgBoxStyle.Critical)
                Exit Sub
            End If


            If Eval(TMeta.Text) = 0 Then
                MsgBox(DevuelveEvento(CodEvento.SISTEMA_VALORINCORRECTO, "Baches meta"), MsgBoxStyle.Critical)
                Exit Sub
            End If

            If Eval(TPorc.Text) = 0 Then
                MsgBox(DevuelveEvento(CodEvento.SISTEMA_VALORINCORRECTO, "Porcentaje de OP"), MsgBoxStyle.Critical)
                Exit Sub
            End If

            If TCodProd.Text = "" Then
                MsgBox(DevuelveEvento(CodEvento.SISTEMA_FALTACAMPO, " Código de producto"), MsgBoxStyle.Critical)
                Exit Sub
            End If


            If TCodCli.Text = "" Then
                MsgBox(DevuelveEvento(CodEvento.SISTEMA_FALTACAMPO, " código de cliente"), MsgBoxStyle.Critical)
                Exit Sub
            End If

            If TNomCli.Text = "" Then
                MsgBox(DevuelveEvento(CodEvento.SISTEMA_FALTACAMPO, " Nombre de cliente"), MsgBoxStyle.Critical)
                Exit Sub
            End If

            If Funcion_ManejaDestinoPLC Then
                If Val(TDestinoPLC.Text) = 0 Then
                    MsgBox(DevuelveEvento(CodEvento.SISTEMA_FALTACAMPO, " Destino PLC"), MsgBoxStyle.Critical)
                    Exit Sub
                End If
            End If


            If Funcion_DestinosPeletizado Then
                If CBLinea.Text = "" Then
                    MsgBox("Debe seleccionar una línea válida para la orden de producción", MsgBoxStyle.Critical)
                    Exit Sub
                End If

                If TPresText.Text.Contains("PELT") Or TPresText.Text.Contains("QUEB") Then
                    If Eval(CDestino1.Text) = 0 Then
                        If Eval(CDestino2.Text) = 0 Then
                            If Eval(CDestino3.Text) = 0 Then
                                MsgBox("Debe elegir al menos un destino", vbInformation)
                                Return
                            End If
                        End If
                    End If
                End If

                If CDestino1.Text = "X" And CDestino2.Text = "X" And CDestino1.Text = "X" Then
                    MsgBox("Debe elegir por lo menos un destino para enviar el bache", MsgBoxStyle.Information)
                    Return
                End If

                If Val(CDestino1.Text) > 0 And Val(TBachesDest1.Text) = 0 Then
                    MsgBox("Número de baches no válido para destino 1", MsgBoxStyle.Information)
                    Return
                End If

                If Val(CDestino2.Text) > 0 And Val(TBachesDest2.Text) = 0 Then
                    MsgBox("Número de baches no válido para destino 2", MsgBoxStyle.Information)
                    Return
                End If

                If Val(CDestino3.Text) > 0 And Val(TBachesDest3.Text) = 0 Then
                    MsgBox("Número de baches no válido para destino 3", MsgBoxStyle.Information)
                    Return
                End If
            End If


            'Validación baches tanda

            If Val(ConfigParametros("MaxKgTanda")) > 0 Then
                'If FValidaTandas(TCodFor.Text, TLP.Text, Eval(TBachesTanda.Text), Eval(TPorc.Text)) = False Then 'And Val(TBachesTanda.Text) > 1 Then
                If FValidaTandas(TCodFor.Text, TLP.Text, Eval(TMeta.Text), Eval(TPorc.Text)) = False And Val(TBachesTanda.Text) > 1 Then
                    MsgBox("El número de baches no supera " + ConfigParametros("MaxKgTanda") + " Kg para la premezcla debe hacer baches manuales en las estaciones de micros", MsgBoxStyle.Information)
                    TBachesTanda.Text = 1
                End If

                If FValidaCapacidadMezcMicros(TCodFor.Text, TLP.Text, Eval(TMeta.Text), Eval(TPorc.Text)) = False And Val(TBachesTanda.Text) > 1 Then
                    Resp = MsgBox("El número de baches excede la capacidad de mezcladora de micros, ¿desea continuar?", MsgBoxStyle.Information + vbYesNo)
                    If Resp = vbNo Then Return
                End If

            End If



            If Funcion_ManejaFunPremezcla Then
                If Len(CCodPrem.Text) > 2 And Eval(CLotePrem.Text) = 0 Then
                    MsgBox("Si la OP lleva fun.Premezcla debe ingresar un número de lote válido", MsgBoxStyle.Critical)
                    Exit Sub
                End If

                If Eval(CLotePrem.Text) = 0 Then CLotePrem.Text = 0
                If (CCodPrem.Text) = "" Then CCodPrem.Text = ""
            End If

            If Funcion_FuncionesPlantaPremezclas Then

                If Val(TBachesTanda.Text) <= 0 Or Eval(TBachesTanda.Text) > Eval(TMeta.Text) Then
                    MsgBox("El número de tandas a dosificar por premezcla no pueden ser cero o mayor al meta programado", MsgBoxStyle.Critical)
                    Exit Sub
                End If
                If (CLinea.Text = "") Then
                    MsgBox("Debe seleccionar la mezcladora", MsgBoxStyle.Critical)
                    Exit Sub
                End If

                If Val(TMHumeda.Text) <= 0 Or Eval(TMHumeda.Text) > 10000 Then
                    MsgBox("El Tiempo de Mezcla Húmeda es errado", MsgBoxStyle.Critical)
                    Exit Sub
                End If

                DVarios.Open("Select * from ARTICULOS where TIPO='PT' AND CODINT='" + TCodProd.Text + "'")

                If DVarios.Count Then

                    If DVarios.RecordSet("MANEJAEMP") Then
                        If TCodEmp.Text = "" Then
                            MsgBox("Debe ingresar un valor válido para el código del empaque", MsgBoxStyle.Critical)
                            Exit Sub
                        End If

                        If Eval(TPresKg.Text) = 0 Then
                            MsgBox("El producto no tiene presentación en Kg. Debe ir a la tabla de Productos para configurarlo", MsgBoxStyle.Critical)
                            Exit Sub
                        End If
                    End If

                    'If DVarios.RecordSet("MANEJAETIQ") Then
                    '    If TNomEmp.Text = "" Then
                    '        MsgBox("Debe ingresar un valor válido para el nombre de la etiqueta", MsgBoxStyle.Critical)
                    '        Exit Sub
                    '    End If
                    'End If
                End If
            Else
                If TCodPrem.Text = "" And ChManejaPx.Checked = True Then
                    MsgBox(DevuelveEvento(CodEvento.SISTEMA_FALTACAMPO, " Código de premezcla"), MsgBoxStyle.Critical)
                    Exit Sub
                End If

                If Eval(TBachesTanda.Text) <= 0 Or Eval(TBachesTanda.Text) > Eval(TMeta.Text) Then
                    MsgBox("El número de tandas a dosificar por premezcla no pueden ser cero o mayor al meta programado", MsgBoxStyle.Critical)
                    Exit Sub
                End If

                If TPresEmp.Text <> "GRAN" Then
                    If TCodEtiq.Text = "" Then
                        MsgBox(DevuelveEvento(CodEvento.SISTEMA_FALTACAMPO, " Código de etiqueta"), MsgBoxStyle.Critical)
                        Exit Sub
                    End If
                    If TNomEtiq.Text = "" Then
                        MsgBox(DevuelveEvento(CodEvento.SISTEMA_FALTACAMPO, " Nombre de etiqueta"), MsgBoxStyle.Critical)
                        Exit Sub
                    End If

                    If TCodEmp.Text = "" Then
                        MsgBox(DevuelveEvento(CodEvento.SISTEMA_FALTACAMPO, " Código de empaque"), MsgBoxStyle.Critical)
                        Exit Sub
                    End If

                    If TNomEmp.Text = "" Then
                        MsgBox(DevuelveEvento(CodEvento.SISTEMA_FALTACAMPO, " Nombre de empaque"), MsgBoxStyle.Critical)
                        Exit Sub
                    End If
                End If
            End If




            If Funcion_PlantasExternas Then
                DOPs.Open("Select * from OPS where OP='" + TOPs.Text.Trim + "' AND PLANTA='" + FiltroPlantaExt + "'") 'PlantaExt + "'")
            Else

                DOPs.Open("Select * from OPS where OP='" + TOPs.Text.Trim + "'")
            End If


            If DOPs.Count > 0 Then

                Resp = MsgBox("Va a modificar una OP existente, ¿desea continuar?", MsgBoxStyle.Information + MsgBoxStyle.YesNo)
                If Resp = vbNo Then Exit Sub

                If Funcion_DestinosPeletizado Then
                    Resp = MsgBox("Desea reiniciar los valores de los destinos de peletizado, ¿desea continuar?", MsgBoxStyle.Information + MsgBoxStyle.YesNo)
                    If Resp = vbYes Then
                        DOPs.RecordSet("REALDEST1") = 0
                        DOPs.RecordSet("REALDEST2") = 0
                        DOPs.RecordSet("REALDEST3") = 0
                    End If
                End If

                Evento("Modifica OP: " + TOPs.Text)
            Else
                Evento("Crea OP: " + TOPs.Text)
                DOPs.AddNew()

                If Funcion_PlantasExternas Then
                    DConfig.Open("UPDATE CONFIG SET ULTIMAOP" + FiltroPlantaExt + "='" + TOPs.Text + "'") 'PlantaExt + "='" + TOPs.Text + "'")
                    DOPs.RecordSet("PLANTA") = FiltroPlantaExt 'PlantaExt
                Else
                    DVarios.Open("Select * from CONFIG")
                    DVarios.RecordSet("ULTIMAOP") = CLeft(TOPs.Text, 15)
                    DVarios.Update()
                End If

                If Funcion_FuncionesPlantaPremezclas Then
                    DOPs.RecordSet("ESTADO") = 10
                End If

                DOPs.RecordSet("OP") = CLeft(TOPs.Text, 15)
                DOPs.RecordSet("FINALIZADO") = "N"
                DOPs.RecordSet("COMPLETO") = "N"
                DOPs.Update()

                'DOPs.Open("Select * from OPS where OP=" + TOPs.Text)
                DOPs.Refresh()

                'Actualiza la tabla config con ultima op

                'DVarios.Open("Select * from CONFIG")
                'DVarios.RecordSet("ULTIMAOP") = CLeft(TOPs.Text, 15)
                'DVarios.Update()

                DEmp.Open("select * from EMPAQUE where OP='1'")

                DEmp.AddNew()
                DEmp.RecordSet("OP") = CLeft(TOPs.Text, 15)
                DEmp.RecordSet("PRESKG") = Eval(TPresKg.Text)
                DEmp.RecordSet("FECHAINI") = Now.ToString("yyyy/MM/dd HH:mm:ss")
                DEmp.RecordSet("FECHAFIN") = Now.ToString("yyyy/MM/dd HH:mm:ss")
                DEmp.RecordSet("CODPROD") = TCodProd.Text
                DEmp.RecordSet("NOMPROD") = CLeft(TNomProd.Text, 30)
                DEmp.RecordSet("MAQUINA") = 100
                DEmp.Update()

            End If

            'Actualiza el codprod,codetiq y codemp den toda la tabla empaque

            DEmp.Open("Update EMPAQUE SET CODPROD='" + TCodProd.Text + "',NOMPROD='" +
                      CLeft(TNomProd.Text, 30) + "',CODETIQ='" + TCodEtiq.Text + "' WHERE OP='" + TOPs.Text + "'")

            'Actualiza el código del producto en la tabla baches

            DBaches.Open("Update BACHES SET PRODUCTO='" + TCodProd.Text + "' WHERE OP='" + TOPs.Text + "'")

            'DOPs.RecordSet("DESTINO") = Eval(TDestino.Text)
            DOPs.RecordSet("MEDICADO") = TMedicado.Text
            DOPs.RecordSet("BAHORA") = Val(TBAhora.Text)
            DOPs.RecordSet("BAHORABPISO") = Eval(TBAhoraBPiso.Text)
            DOPs.RecordSet("OBSERVOP") = CLeft(LimpiarCadena(TObservOP.Text.Trim), 250)
            DOPs.RecordSet("META") = Eval(TMeta.Text)
            DOPs.RecordSet("LINEA") = CLeft(CBLinea.Text, 15)
            DOPs.RecordSet("BACHESTANDA") = Eval(TBachesTanda.Text)
            DOPs.RecordSet("DESTINO") = Eval(TDestinoPLC.Text)

            'Si es una OP de ventas se marca de una vez que va sin control de sackoff
            If ChVentas.Checked Then
                DOPs.RecordSet("SINCONTROLSACKOFF") = 1
                DOPs.RecordSet("VENTAS") = 10
            End If

            'Se asignan datos de destinos if destino <> "X"

            If Funcion_DestinosPeletizado Then
                If Eval(CDestino1.Text) > 0 Then DOPs.RecordSet("DESTINO1") = Eval(CDestino1.Text)
                If Eval(CDestino2.Text) > 0 Then DOPs.RecordSet("DESTINO2") = Eval(CDestino2.Text)
                If Eval(CDestino3.Text) > 0 Then DOPs.RecordSet("DESTINO3") = Eval(CDestino3.Text)

                DOPs.RecordSet("METADEST1") = Eval(TBachesDest1.Text)
                DOPs.RecordSet("METADEST2") = Eval(TBachesDest2.Text)
                DOPs.RecordSet("METADEST3") = Eval(TBachesDest3.Text)

            End If

            If DOPs.RecordSet("REAL") = 0 And DOPs.RecordSet("REALMED") = 0 Then

                If Funcion_ManejaFunPremezcla Then
                    DOPs.RecordSet("CODPREM") = CLeft(CCodPrem.Text, 15)
                    DOPs.RecordSet("LOTEPREM") = CLeft(CLotePrem.Text, 25)
                End If
                DOPs.RecordSet("LINEA") = CLeft(CBLinea.Text, 15)
                If Funcion_FuncionesPlantaPremezclas Then
                    DOPs.RecordSet("TMHUMEDA") = Val(TMHumeda.Text)
                    DOPs.RecordSet("NUMPAQXOP") = Val(TNumPaq.Text)
                    DOPs.RecordSet("BODDESTINO") = CLeft(TBodDestino.Text, 15)
                    DOPs.RecordSet("LINEA") = CLeft(CLinea.Text, 15)
                    DOPs.RecordSet("PRESKG") = Val(TPresKg.Text)
                End If


                DOPs.RecordSet("CODPREMEZCLA") = CLeft(TCodPrem.Text, 15)
                DOPs.RecordSet("CODFOR") = CLeft(TCodFor.Text, 15)
                DOPs.RecordSet("NOMFOR") = CLeft(TNomFor.Text, 30)
                DOPs.RecordSet("PORC") = Eval(TPorc.Text)
                DOPs.RecordSet("LP") = CLeft(TLP.Text, 15)
                DOPs.RecordSet("CODPROD") = CLeft(TCodProd.Text, 15)
                DOPs.RecordSet("CODEMP") = CLeft(TCodEmp.Text, 15)
                DOPs.RecordSet("CODETIQ") = CLeft(TCodEtiq.Text, 15)
                DOPs.RecordSet("CODCLI") = CLeft(TCodCli.Text, 15)
                DOPs.RecordSet("NOMCLI") = CLeft(TNomCli.Text, 30)
                DOPs.RecordSet("FINALIZADO") = "N"
                DOPs.RecordSet("FINPLANILLA") = "-"
                DOPs.RecordSet("COMPLETO") = "N"

                DVarios.Open("Select * from OPS where FINALIZADO<>'S' order by secuencia")
                If DOPs.RecordSet("SECUENCIA") = 0 Then
                    DOPs.RecordSet("ENVIADA") = "X"
                    DOPs.RecordSet("SECUENCIA") = DVarios.Count
                End If

                'If Funcion_AdelantarEmpaquesyEtiquetas Then
                '    '    'Se llena la tabla de detalle empaques y etiquetas 
                '    '    FGuardaEmpEtiqDet()
                'End If

            Else
                    MsgBox("Algunos datos no se modificaron porque ya hay baches reportados de la OP", MsgBoxStyle.Information)
            End If

            'Se busca la línea Inventario en la tabla artículos para agregarlo en la tabla de OPs en el campo LINEAINVENT, este
            'campo sirve para visualización del sackoff en la aplicación ChrPantallas. 

            DVarios.Open("Select * from ARTICULOS where TIPO='PT' and CODINT='" + TCodProd.Text + "'")
            DOPs.RecordSet("NOMPROD") = "-"
            If DVarios.Count > 0 Then
                If Not IsDBNull(DVarios.RecordSet("LINEA")) Then DOPs.RecordSet("LINEAINVENT") = DVarios.RecordSet("LINEA")
                DOPs.RecordSet("NOMPROD") = DVarios.RecordSet("NOMBRE")
            End If

            'Se busca si la linea es linea externa para marcar la OP

            DVarios.Open("Select * from LINEASPROD where TIPO='PT' and LINEA='" + DOPs.RecordSet("LINEAINVENT") + "'")
            If DVarios.Count > 0 Then
                DOPs.RecordSet("LINEAEXTERNA") = DVarios.RecordSet("LINEAEXTERNA")
                DOPs.RecordSet("LINEAPRESENT") = DVarios.RecordSet("PRESENT")
            End If

            'Guarda empaques y etiquetas por adelantado
            If Funcion_FuncionesPlantaPremezclas Then
                EncontroEmp = False
                EncontroEtiq = False

                Call FValidaEmpEtiqDet()

                If EncontroEmp = False Or EncontroEtiq = False Then
                    Resp = MsgBox("Falta un código de empaque o etiqueta que está configurado en el producto pero no se encuentra en el detalle de empaques y etiquetas, ¿Desea continuar guardando el detalle de empaques y etiquetas?", vbYesNo + vbInformation)
                    If Resp = vbYes Then
                        FGuardaEmpEtiqDetDG()
                    End If
                Else
                    FGuardaEmpEtiqDetDG()
                End If

            End If


            DOPs.Update(Me)


            BCancelar_Click(Nothing, Nothing)

            ''NuevaOP_Load(Nothing, Nothing)
            BActualizar_Click(Nothing, Nothing)
            'Luego de finalizar la creación de una OP se habilita el grupo de plantas externas
            If GBPlantas.Visible = True Then GBPlantas.Enabled = True

        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub


    Private Sub TMedicado_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TMedicado.Click
        Try
            If TMedicado.Text = "X" Then
                TMedicado.Text = "-"
            Else
                TMedicado.Text = "X"
            End If
        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub


    Private Sub BEditar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BEditar.Click
        Try
            'If DRUsuario("OPsMod") Then
            If ValidaPermiso("OPs_Editar") Then
            Else
                MsgBox(DevuelveEvento(CodEvento.USUARIO_PERMISODENEGADO), MsgBoxStyle.Information)
                Exit Sub
            End If

            'PanelDatos.Enabled = True
            Limpiar_Habilitar_TextBox(Me.Controls, AccionTextBox.Habilitar)
            FReadOnly_Click(Nothing, Nothing)

            If Funcion_ManejaFunPremezcla Then
                CCodPrem.Enabled = True
                CLotePrem.Enabled = True
                CLotePrem.DropDownStyle = ComboBoxStyle.DropDown
                CCodPrem.DropDownStyle = ComboBoxStyle.DropDown
            End If

            If Funcion_DestinosPeletizado Then
                DGOPsPrem.Enabled = False
                CBLinea.Enabled = True
                CDestino1.Enabled = True
                CDestino2.Enabled = True
                CDestino3.Enabled = True
                TBachesDest1.ReadOnly = False
                TBachesDest2.ReadOnly = False
                TBachesDest3.ReadOnly = False
            End If

            'se deshabilita el grupo de plantas externas para evitar generar un consecutivo de OP y guardar para otra planta
            If GBPlantas.Visible = True Then GBPlantas.Enabled = False
            NuevaOP = False

            FBuscaProdEquivalentes()

        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub


    Private Sub BSubeOP_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BSubeOP.Click
        Try

            'If DRUsuario("OPsMod") Then
            If ValidaPermiso("OPs_Editar") Then
            Else
                MsgBox(DevuelveEvento(CodEvento.USUARIO_PERMISODENEGADO), MsgBoxStyle.Information)
                Exit Sub
            End If

            Dim SecActual, OPActual As String
            Dim SecDest, OPDest As String
            Dim FilaActualOP As Integer
            Dim Filadest As Integer

            DVarios.Open("select * from OPS where OP='" + Eval(TOPs.Text).ToString + "'")

            If DVarios.Count = 0 Then Return

            Select Case DVarios.RecordSet("ESTADO")
                Case 10
                    If DGOPsDos.Rows.Count = 0 Then Exit Sub
                    FilaActualOP = DGOPsDos.CurrentRow.Index

                    If FilaActualOP - 1 < 0 Then Return

                    OPActual = TOPs.Text
                    SecActual = DGOPsDos.CurrentRow.Cells("DGOPsDos_SECUENCIA").Value.ToString
                    OPDest = DGOPsDos.Rows(FilaActualOP - 1).Cells("DGOPsDos_OP").Value.ToString
                    SecDest = DGOPsDos.Rows(FilaActualOP - 1).Cells("DGOPsDos_SECUENCIA").Value.ToString

                    DOPs.Find("OP='" + OPActual + "'")

                    If Not DOPs.EOF Then
                        DOPs.RecordSet("SECUENCIA") = SecDest
                        DOPs.Update()
                    End If

                    DOPs.Refresh()

                    DOPs.Find("OP='" + OPDest + "'")

                    If Not DOPs.EOF Then
                        DOPs.RecordSet("SECUENCIA") = SecActual
                        DOPs.Update()
                    End If

                    Filadest = FilaActualOP - 1
                    DOPs.Refresh()
                    AsignaDataGrid(DGOPsDos, DOPs.DataTable, True)

                    DGOPsDos.Rows(Filadest).Selected = True
                    DGOPsDos.FirstDisplayedScrollingRowIndex = Filadest
                    DGOPsDos.CurrentCell = DGOPsDos(0, Filadest)
                    DGOPsDos_CellClick(Nothing, Nothing)

                Case Else
                    If DGOPsPrem.Rows.Count = 0 Then Exit Sub
                    FilaActualOP = DGOPsPrem.CurrentRow.Index

                    If FilaActualOP - 1 < 0 Then Return

                    OPActual = TOPs.Text
                    SecActual = DGOPsPrem.CurrentRow.Cells("DGOPsPrem_SECUENCIA").Value.ToString
                    OPDest = DGOPsPrem.Rows(FilaActualOP - 1).Cells("DGOPsPrem_OP").Value.ToString
                    SecDest = DGOPsPrem.Rows(FilaActualOP - 1).Cells("DGOPsPrem_SECUENCIA").Value.ToString

                    DOPsPrem.Find("OP='" + OPActual + "'")

                    If Not DOPsPrem.EOF Then
                        DOPsPrem.RecordSet("SECUENCIA") = SecDest
                        DOPsPrem.Update()
                    End If

                    DOPsPrem.Refresh()

                    DOPsPrem.Find("OP='" + OPDest + "'")

                    If Not DOPsPrem.EOF Then
                        DOPsPrem.RecordSet("SECUENCIA") = SecActual
                        DOPsPrem.Update()
                    End If

                    Filadest = FilaActualOP - 1
                    DOPsPrem.Refresh()
                    AsignaDataGrid(DGOPsPrem, DOPsPrem.DataTable, True)

                    DGOPsPrem.Rows(Filadest).Selected = True
                    DGOPsPrem.FirstDisplayedScrollingRowIndex = Filadest
                    DGOPsPrem.CurrentCell = DGOPsPrem(0, Filadest)
                    DGOPsPrem_CellClick(Nothing, Nothing)

            End Select

        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub BBajaOP_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BBajaOP.Click
        Try

            'If DRUsuario("OPsMod") Then
            If ValidaPermiso("OPs_Editar") Then
            Else
                MsgBox(DevuelveEvento(CodEvento.USUARIO_PERMISODENEGADO), MsgBoxStyle.Information)
                Exit Sub
            End If

            Dim SecActual, OPActual As String
            Dim SecDest, OPDest As String
            Dim FilaActualOP As Integer
            Dim indifila As Integer = 0
            Dim Filadest As Integer

            DVarios.Open("select * from OPS where OP='" + Eval(TOPs.Text).ToString + "'")

            If DVarios.Count = 0 Then Return

            Select Case DVarios.RecordSet("ESTADO")
                Case 10
                    If DGOPsDos.Rows.Count = 0 Then Exit Sub
                    FilaActualOP = DGOPsDos.CurrentRow.Index
                    indifila = DGOPsDos.RowCount - 1
                    If FilaActualOP + 1 > indifila Then Return

                    OPActual = TOPs.Text
                    SecActual = DGOPsDos.CurrentRow.Cells("DGOPsDos_SECUENCIA").Value.ToString
                    OPDest = DGOPsDos.Rows(FilaActualOP + 1).Cells("DGOPsDos_OP").Value.ToString
                    SecDest = DGOPsDos.Rows(FilaActualOP + 1).Cells("DGOPsDos_SECUENCIA").Value.ToString

                    DOPs.Find("OP='" + OPActual + "'")

                    If Not DOPs.EOF Then
                        DOPs.RecordSet("SECUENCIA") = SecDest
                        DOPs.Update()
                    End If

                    DOPs.Refresh()

                    DOPs.Find("OP='" + OPDest + "'")

                    If Not DOPs.EOF Then
                        DOPs.RecordSet("SECUENCIA") = SecActual
                        DOPs.Update()
                    End If

                    Filadest = FilaActualOP + 1
                    DOPs.Refresh()
                    AsignaDataGrid(DGOPsDos, DOPs.DataTable, True)

                    DGOPsDos.Rows(Filadest).Selected = True
                    DGOPsDos.FirstDisplayedScrollingRowIndex = Filadest
                    DGOPsDos.CurrentCell = DGOPsDos(0, Filadest)
                    DGOPsDos_CellClick(Nothing, Nothing)


                Case Else
                    If DGOPsPrem.Rows.Count = 0 Then Exit Sub
                    FilaActualOP = DGOPsPrem.CurrentRow.Index
                    indifila = DGOPsPrem.RowCount - 1
                    If FilaActualOP + 1 > indifila Then Return

                    OPActual = TOPs.Text
                    SecActual = DGOPsPrem.CurrentRow.Cells("DGOPsPrem_SECUENCIA").Value.ToString
                    OPDest = DGOPsPrem.Rows(FilaActualOP + 1).Cells("DGOPsPrem_OP").Value.ToString
                    SecDest = DGOPsPrem.Rows(FilaActualOP + 1).Cells("DGOPsPrem_SECUENCIA").Value.ToString

                    DOPsPrem.Find("OP='" + OPActual + "'")

                    If Not DOPsPrem.EOF Then
                        DOPsPrem.RecordSet("SECUENCIA") = SecDest
                        DOPsPrem.Update()
                    End If

                    DOPsPrem.Refresh()

                    DOPsPrem.Find("OP='" + OPDest + "'")

                    If Not DOPsPrem.EOF Then
                        DOPsPrem.RecordSet("SECUENCIA") = SecActual
                        DOPsPrem.Update()
                    End If

                    Filadest = FilaActualOP + 1
                    DOPsPrem.Refresh()
                    AsignaDataGrid(DGOPsPrem, DOPsPrem.DataTable, True)

                    DGOPsPrem.Rows(Filadest).Selected = True
                    DGOPsPrem.FirstDisplayedScrollingRowIndex = Filadest
                    DGOPsPrem.CurrentCell = DGOPsPrem(0, Filadest)
                    DGOPsPrem_CellClick(Nothing, Nothing)

            End Select

        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub


    Private Sub BModSec_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BModSec.Click
        Try

            'If DRUsuario("OPsMod") Then
            If ValidaPermiso("OPs_Editar") Then
            Else
                MsgBox(DevuelveEvento(CodEvento.USUARIO_PERMISODENEGADO), MsgBoxStyle.Information)
                Exit Sub
            End If


            Dim SecActual, OPActual As String
            Dim SecDest, OPDest As String
            Dim FilaActualOP As Integer
            Dim Filadest As Integer
            Dim IndFila As Integer

            DVarios.Open("select * from OPS where OP='" + Eval(TOPs.Text).ToString + "'")

            If DVarios.Count = 0 Then Return

            Select Case DVarios.RecordSet("ESTADO")
                Case 10
                    If DGOPsDos.Rows.Count = 0 Then Exit Sub
                    FilaActualOP = DGOPsDos.CurrentRow.Index

                    'If FilaActualOP - 1 < 0 Then Return

                    OPActual = TOPs.Text
                    SecActual = DGOPsDos.CurrentRow.Cells("DGOPsDos_SECUENCIA").Value.ToString
                    IndFila = 0
                    If InputBox.InputBox("Modificar secuencia OPs", "Digite el número de línea de la Grilla para la OP", IndFila) = DialogResult.Cancel Then Return
                    If IndFila = 0 OrElse Fila > DGOPsDos.RowCount Then Return

                    OPDest = DGOPsDos.Rows(IndFila - 1).Cells("DGOPsDos_OP").Value.ToString
                    SecDest = DGOPsDos.Rows(IndFila - 1).Cells("DGOPsDos_SECUENCIA").Value.ToString

                    DOPs.Find("OP='" + OPActual + "'")

                    If Not DOPs.EOF Then
                        DOPs.RecordSet("SECUENCIA") = SecDest
                        DOPs.Update()
                    End If

                    DOPs.Refresh()

                    DOPs.Find("OP='" + OPDest + "'")

                    If Not DOPs.EOF Then
                        DOPs.RecordSet("SECUENCIA") = SecActual
                        DOPs.Update()
                    End If

                    Filadest = IndFila - 1
                    DOPs.Refresh()
                    AsignaDataGrid(DGOPsDos, DOPs.DataTable, True)

                    DGOPsDos.Rows(Filadest).Selected = True
                    DGOPsDos.FirstDisplayedScrollingRowIndex = Filadest
                    DGOPsDos.CurrentCell = DGOPsDos(0, Filadest)
                    DGOPsDos_CellClick(Nothing, Nothing)

                Case Else
                    If DGOPsPrem.Rows.Count = 0 Then Exit Sub
                    FilaActualOP = DGOPsPrem.CurrentRow.Index

                    'If FilaActualOP - 1 < 0 Then Return

                    OPActual = TOPs.Text
                    SecActual = DGOPsPrem.CurrentRow.Cells("DGOPsPrem_SECUENCIA").Value.ToString

                    IndFila = 0
                    If InputBox.InputBox("Modificar secuencia OPs", "Digite el número de línea de la Grilla para la OP", IndFila) = DialogResult.Cancel Then Return
                    If IndFila = 0 OrElse Fila > DGOPsPrem.RowCount Then Return

                    OPDest = DGOPsPrem.Rows(IndFila - 1).Cells("DGOPsPrem_OP").Value.ToString
                    SecDest = DGOPsPrem.Rows(IndFila - 1).Cells("DGOPsPrem_SECUENCIA").Value.ToString

                    DOPsPrem.Find("OP='" + OPActual + "'")

                    If Not DOPsPrem.EOF Then
                        DOPsPrem.RecordSet("SECUENCIA") = SecDest
                        DOPsPrem.Update()
                    End If

                    DOPsPrem.Refresh()

                    DOPsPrem.Find("OP='" + OPDest + "'")

                    If Not DOPsPrem.EOF Then
                        DOPsPrem.RecordSet("SECUENCIA") = SecActual
                        DOPsPrem.Update()
                    End If

                    Filadest = IndFila - 1
                    DOPsPrem.Refresh()
                    AsignaDataGrid(DGOPsPrem, DOPsPrem.DataTable, True)

                    DGOPsPrem.Rows(Filadest).Selected = True
                    DGOPsPrem.FirstDisplayedScrollingRowIndex = Filadest
                    DGOPsPrem.CurrentCell = DGOPsPrem(0, Filadest)
                    DGOPsPrem_CellClick(Nothing, Nothing)

            End Select

        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub



    Private Sub BMarcarEnv_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BMarcarEnv.Click
        Try

            'If DRUsuario("OPsMod") Then
            If ValidaPermiso("OPs_Editar") Then
            Else
                MsgBox(DevuelveEvento(CodEvento.USUARIO_PERMISODENEGADO), MsgBoxStyle.Information)
                Exit Sub
            End If

            'Se valida si la fórmula esta activa, si no no se puede dejar enviar a dosificación

            DVarios.Open("Select ESTADO from FORMULAS where ESTADO='APROBADO' and CODFOR='" + TCodFor.Text + "' and LP='" + TLP.Text + "'")

            If DVarios.Count = 0 Then
                MsgBox(DevuelveEvento(CodEvento.FORMULA_NOAPROBADA), vbCritical)
                Return
            End If

            DVarios.Open("select * from OPS where OP='" + Eval(TOPs.Text).ToString + "'")

            If DVarios.Count = 0 OrElse DVarios.RecordSet("ESTADO") <> 10 Then Return

            'Si la OP es de ventas, no permite dosificarla

            If DVarios.RecordSet("VENTAS") = 10 Then
                MsgBox(DevuelveEvento(CodEvento.OP_VENTAS), vbCritical)
                Return
            End If

            If DVarios.RecordSet("ENVIADA") = "X" Then
                DVarios.RecordSet("ENVIADA") = "-"
            Else
                DVarios.RecordSet("ENVIADA") = "X"
            End If
            DVarios.Update()
            BActualizar_Click(Nothing, Nothing)

        Catch ex As Exception

        End Try
    End Sub


    Private Sub BFinalizar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BFinalizar.Click
        Try

            'If DRUsuario("OPsMod") Then
            If ValidaPermiso("OPs_Editar") Then
            Else
                MsgBox(DevuelveEvento(CodEvento.USUARIO_PERMISODENEGADO), MsgBoxStyle.Information)
                Exit Sub
            End If

            If Funcion_PlantasExternas Then
                If OPPlantaGir.Checked Then
                    FiltroPlantaExt = "GIR"
                    'PlantaExt = "GIR"
                ElseIf OPPlantaSantaRosa.Checked Then
                    FiltroPlantaExt = "STRO"
                    'PlantaExt = "STRO"
                ElseIf OPPlantaYar.Checked Then
                    FiltroPlantaExt = "YAR"
                    PlantaExt = "YAR"
                End If

                DVarios.Open("select * from OPS where OP='" + TOPs.Text + "' AND PLANTA='" + FiltroPlantaExt + "'")

            Else

                DVarios.Open("select * from OPS where OP='" + Eval(TOPs.Text).ToString + "'")
            End If

            If DVarios.Count = 0 Then Return

            Resp = MsgBox("¿Está seguro de finalizar la OP " + DVarios.RecordSet("OP").ToString, MsgBoxStyle.YesNo + MsgBoxStyle.Information)
            If Resp = vbNo Then Exit Sub


            If DVarios.Count > 0 Then

                RespInput = ""

                InputBox.InputBox("Finalizar OP", "Escriba por qué desea finalizar la OP", RespInput)

                Dim Coment As String
                Coment = DVarios.RecordSet("OBSERVOP") + RespInput
                DVarios.RecordSet("OBSERVOP") = CLeft(Coment, 250)
                DVarios.RecordSet("FINALIZADO") = "S"
                DVarios.RecordSet("FECHAFIN") = Now.ToString("yyyy/MM/dd HH:mm:ss")

                If Val(TReal.Text) = 0 Then
                    DVarios.RecordSet("FINPLANILLA") = "S"
                End If

                DVarios.Update(Me)

                Evento("Cierra OP " + TOPs.Text + " " + RespInput)

                ''NuevaOP_Load(Nothing, Nothing)
                BActualizar_Click(Nothing, Nothing)
            End If

        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub





    Private Sub BActualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BActualizar.Click
        Try
            If Funcion_PlantasExternas Then
                DOPs.Open("Select * from OPS where ESTADO=10 and FINALIZADO='N' AND PLANTA='" + FiltroPlantaExt + "' order by SECUENCIA")
                DOPsPrem.Open("Select * from OPS where ESTADO<=6 and FINALIZADO<>'S' AND PLANTA='" + FiltroPlantaExt + "' order by SECUENCIA")
            Else
                DOPs.Open("Select * from OPS where ESTADO=10 and FINALIZADO='N' order by SECUENCIA")
                If Not Funcion_FuncionesPlantaPremezclas Then DOPsPrem.Open("Select * from OPS where ESTADO<=6 and FINALIZADO<>'S' and LINEA<>'KILIADOS' order by SECUENCIA")
            End If

            'Se organiza la secuencia de la tabla OPs mayores
            Dim Sec As Long = 1
            For Each RecordSet In DOPs.Rows
                RecordSet("Secuencia") = Sec
                Sec += 1
                DOPs.Update()
            Next

            'Se organiza la secuencia de la tabla Ops micros

            Sec = 1

            If Not Funcion_FuncionesPlantaPremezclas Then
                For Each RecordSet In DOPsPrem.Rows
                    RecordSet("Secuencia") = Sec
                    Sec += 1
                    DOPsPrem.Update()
                Next

            End If


            AsignaDataGrid(DGOPsPrem, DOPsPrem.DataTable, True)
            AsignaDataGrid(DGOPsDos, DOPs.DataTable, True)

            DArt.Open("select * from ARTICULOS where TIPO='PT' ORDER BY NOMBRE")
            AsignaDataGrid(DGProd, DArt.DataTable)

            DFor.Open("select * from FORMULAS where ESTADO='APROBADO' ORDER BY NOMFOR")
            AsignaDataGrid(DGFor, DFor.DataTable, True)


            If Funcion_FuncionesPlantaPremezclas Then
                DClientes.Open("select * from CLIENTES where TIPO='CLIENTE' ORDER BY NOMCLI")
                LLenaComboBox(TBodDestino, DClientes.DataTable, "BODDEST")
            Else
                DClientes.Open("select * from CLIENTES ORDER BY NOMCLI")
            End If

            AsignaDataGrid(DGClientes, DClientes.DataTable)

            If Funcion_FuncionesPlantaPremezclas Then
                DCodEmpEtiq = New AdoSQL("ARTICULOS")
                DCodEmpEtiq.Open("select * from ARTICULOS where TIPO='EM' ORDER BY NOMBRE")
                AsignaDataGrid(DGEmpaques, DCodEmpEtiq.DataTable, True)
            End If

            If DOPs.Count > 0 Then DGOPsDos_CellClick(Nothing, Nothing)

        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub BImpOPs_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BImpOPs.Click
        Dim Rep As CrystalRep
        Try
            Rep = New CrystalRep

            With Rep
                .ServerName = ServidorSQL
                .DataBaseName = NomDB
                .UserId = UserDB
                .Password = PWD
                '.SelectionFormula = "{OPS.OP}=234"
                .Formulas(0) = "PLANTA='" + Planta + "'"
                .Formulas(1) = "FECHA='" + Format(Now, "yyyy/MM/dd HH:mm") + "'"
                .SelectionFormula = "{OPS.FINALIZADO}='N'"
                .Destination = CrystalRep.Destinacion.crToWindows
                .WindowState = FormWindowState.Maximized
                .ChoosePrint = True
                .MaximizeBox = True
                .MinimizeBox = True
            End With

            Rep.ReportFileName = RutaRep + "rpoppen.rpt"
            Rep.PrintReport()

        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub FReadOnly_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FReadOnly.Click
        Try
            'Pone readonly las cajas de texto que se necesitan asi en el formulario

            TOPs.ReadOnly = True
            TCodForB.ReadOnly = True
            TNomFor.ReadOnly = True
            'TNomForB.ReadOnly = True
            TReal.ReadOnly = True
            'TBachesTanda.ReadOnly = True
            'TLoteProd.ReadOnly = True
            'TTotalFor.ReadOnly = True
            'TCantProd.ReadOnly = True
            TLP.ReadOnly = True
            'TNombre.ReadOnly = True
            TPresText.ReadOnly = True
            TPresEmp.ReadOnly = True
            TPresKg.ReadOnly = True
            TNomEmp.ReadOnly = True
            TNomEtiq.ReadOnly = True
            TNomCli.ReadOnly = True
            TBachesDest1.ReadOnly = True
            TBachesDest2.ReadOnly = True
            TBachesDest3.ReadOnly = True

        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub TMeta_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TMeta.KeyUp
        If e.KeyCode = Keys.Enter Then
            If Funcion_FuncionesPlantaPremezclas Then

                If Val(TTotalFor.Text) > 0 And Val(TPresKg.Text) > 0 Then
                    TNumPaq.Text = Math.Round(Val(TTotalFor.Text) * Val(TMeta.Text) / TPresKg.Text, 1).ToString
                    If NuevaOP Then
                        FAdicEmpEtiq(TCodEmp.Text, TNomEmp.Text, "EM", Eval(TNumPaq.Text), TOPs.Text, Val(TNumPaqxBache.Text))
                        FAdicEmpEtiq(TCodEtiq.Text, TNomEtiq.Text, "ET", Eval(TNumPaq.Text), TOPs.Text, Val(TNumPaqxBache.Text))
                    End If

                End If

                CLinea.DroppedDown = True
                CLinea.SelectedIndex = 0
                'TCodCli.Focus()

            Else
                TBAhora.Focus()
            End If

        End If
    End Sub

    Private Sub TBAhora_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TBAhora.KeyUp
        If e.KeyCode = Keys.Enter Then TBAhoraBPiso.Focus()
    End Sub

    Private Sub TBAhoraBPiso_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TBAhoraBPiso.KeyUp
        If e.KeyCode = Keys.Enter Then TBachesTanda.Focus()
    End Sub

    Private Sub TDestino_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        CBLinea.Focus()
    End Sub

    Private Sub DGOPsPrem_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DGOPsPrem.KeyDown
        DGOPsPrem_CellClick(Nothing, Nothing)
    End Sub

    Private Sub DGOPs_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DGOPsPrem.KeyUp
        DGOPsPrem_CellClick(Nothing, Nothing)
    End Sub

    Private Sub DGOPsDos_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DGOPsDos.KeyDown
        DGOPsDos_CellClick(Nothing, Nothing)
    End Sub

    Private Sub DGOPsDos_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DGOPsDos.KeyUp
        DGOPsDos_CellClick(Nothing, Nothing)
    End Sub

    Private Sub BBajaOPPrem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BBajaOPDosif.Click
        Try
            If DOPs.Count = 0 Then Return

            DOPs.Find("OP='" + TOPs.Text.Trim + "'")
            If DOPs.EOF = False Then
                If DOPs.RecordSet("REALMED") >= DOPs.RecordSet("REAL") Then
                    DOPs.RecordSet("ESTADO") = 6
                Else
                    DOPs.RecordSet("ESTADO") = 5
                End If
                DOPs.RecordSet("ENVIADA") = "X"
                DOPs.RecordSet("BAHORA") = 0
                DOPs.Update()
            End If


            BActualizar_Click(Nothing, Nothing)

        Catch ex As Exception
            MsgError(ex)
        End Try

    End Sub

    Private Sub BSubeOPPrem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BSubeOPDosif.Click
        Try
            DOPsPrem.Refresh()
            If DOPsPrem.Count = 0 Then Return

            DOPsPrem.Find("OP='" + TOPs.Text.Trim + "'")
            If DOPsPrem.EOF = False Then
                DOPsPrem.RecordSet("ESTADO") = 10
                DOPsPrem.Update()
            End If

            BActualizar_Click(Nothing, Nothing)

        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub


    Private Sub BSubeOPDos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            If DOPsEmp.Count = 0 Then Return

            If Eval(TOPs.Text) = 0 Then Return

            DOPsEmp.Find("OP='" + TOPs.Text.Trim + "'")
            If DOPsEmp.EOF = False Then
                DOPsEmp.RecordSet("ESTADO") = 10
                DOPsEmp.Update()
            End If
            DOPsPrem.Refresh()
            DOPs.Refresh()


            AsignaDataGrid(DGOPsPrem, DOPsPrem.DataTable, True)
            AsignaDataGrid(DGOPsDos, DOPs.DataTable, True)
        Catch ex As Exception
            MsgError(ex)
        End Try

    End Sub

    Private Sub BBajaOPsEmp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            If DOPsEmp.Count = 0 Then Return

            DOPsEmp.Find("OP='" + TOPs.Text.Trim + "'")
            If DOPsEmp.EOF = False Then
                DOPsEmp.RecordSet("ESTADO") = 20
                DOPsEmp.Update()
            End If
            DOPsPrem.Refresh()
            DOPs.Refresh()


            AsignaDataGrid(DGOPsPrem, DOPsPrem.DataTable, True)
            AsignaDataGrid(DGOPsDos, DOPs.DataTable, True)

        Catch ex As Exception
            MsgError(ex)
        End Try

    End Sub

    Private Sub BBuscaOP_Click(ByVal sender As System.Object, ByVal e As System.EventArgs, Optional ByVal OPs As String = "") Handles BBuscaOP.Click
        Try

            'Buscamos los datos de la tabla OPs para llenar los campos necesarios

            Limpiar_Habilitar_TextBox(Me.Controls, VariablesGlobales.AccionTextBox.Limpiar)

            DVarios.Open("select * from OPS where OP='" + OPs + "'")
            If DVarios.Count = 0 Then Exit Sub

            TOPs.Text = DVarios.RecordSet("OP").ToString
            TLP.Text = DVarios.RecordSet("LP").ToString
            TMeta.Text = DVarios.RecordSet("META").ToString
            TReal.Text = DVarios.RecordSet("REAL").ToString
            TBachesTanda.Text = DVarios.RecordSet("REALMED").ToString
            TBAhora.Text = DVarios.RecordSet("BAHORA").ToString
            TBAhoraBPiso.Text = DVarios.RecordSet("BAHORABPISO").ToString
            TPorc.Text = DVarios.RecordSet("PORC").ToString
            TDestinoPLC.Text = DVarios.RecordSet("DESTINO").ToString
            TCodFor.Text = DVarios.RecordSet("CODFOR").ToString
            TCodCli.Text = DVarios.RecordSet("CODCLI").ToString
            TNomFor.Text = DVarios.RecordSet("NOMFOR").ToString
            TCodProd.Text = DVarios.RecordSet("CODPROD").ToString
            TMedicado.Text = DVarios.RecordSet("MEDICADO").ToString
            TObservOP.Text = DVarios.RecordSet("OBSERVOP").ToString
            TEstado.Text = DVarios.RecordSet("ESTADO").ToString
            TBachesTanda.Text = DVarios.RecordSet("BACHESTANDA").ToString
            CDestino1.Text = DVarios.RecordSet("DESTINO1").ToString
            CDestino2.Text = DVarios.RecordSet("DESTINO2").ToString
            CDestino3.Text = DVarios.RecordSet("DESTINO3").ToString
            TMetaKG.Text = DVarios.RecordSet("CANTPROD").ToString


            If DVarios.RecordSet("VENTAS") > 0 Then
                ChVentas.Checked = True
            Else
                ChVentas.Checked = False
            End If

            If Eval(CDestino1.Text) = 0 Then CDestino1.Text = "X"
            If Eval(CDestino2.Text) = 0 Then CDestino2.Text = "X"
            If Eval(CDestino3.Text) = 0 Then CDestino3.Text = "X"

            TBachesDest1.Text = DVarios.RecordSet("METADEST1").ToString
            TBachesDest2.Text = DVarios.RecordSet("METADEST2").ToString
            TBachesDest3.Text = DVarios.RecordSet("METADEST3").ToString

            If Funcion_ManejaFunPremezcla Then
                CLotePrem.DropDownStyle = ComboBoxStyle.DropDown
                CCodPrem.DropDownStyle = ComboBoxStyle.DropDown
                CLotePrem.Enabled = False
                CCodPrem.Enabled = False
                CLotePrem.Text = DVarios.RecordSet("LOTEPREM").ToString
                CCodPrem.Text = DVarios.RecordSet("CODPREM").ToString
            End If




            TCodEmp.Text = DVarios.RecordSet("CODEMP").ToString
            TCodEtiq.Text = DVarios.RecordSet("CODETIQ").ToString
            CBLinea.Text = DVarios.RecordSet("LINEA").ToString
            CLinea.Text = DVarios.RecordSet("LINEA").ToString

            'Traemos los datos del cliente

            DClientes.Find("CODCLI='" + TCodCli.Text.Trim + "'")

            If DClientes.EOF Then Exit Sub

            TNomCli.Text = DClientes.RecordSet("NOMCLI")

            'Buscamos los datos de la tabla FORMULAS para llenar los campos del GBFor

            DFor.Find("CODFOR='" + TCodFor.Text + "' AND LP='" + TLP.Text + "'")

            If DFor.EOF Then
                MsgBox("La Fórmula no está aprobada. Algunos datos no se cargarán", MsgBoxStyle.Information)
                Exit Sub
            End If

            TCodForB.Text = DFor.RecordSet("CODFORB").ToString
            TCodPrem.Text = DFor.RecordSet("CODPREMEZCLA").ToString
            TTotalFor.Text = DFor.RecordSet("TOTALFOR").ToString

            If Funcion_FuncionesPlantaPremezclas Then
                TNumPaqxBache.Text = DFor.RecordSet("NUMPAQXBACHE").ToString
                TPresKg.Text = DFor.RecordSet("PESOPAQ").ToString
                TBodDestino.Text = DVarios.RecordSet("BODDESTINO")
            End If
            'TNomForB.Text = DFor.RecordSet("NOMFORB").ToString
            'TTotalFor.Text = DFor.RecordSet("TOTALFOR").ToString

            'Buscamos los datos de la tabla PRODUCTOS para llenar los campos del GBProd
            DArt.Open("select * from ARTICULOS")
            If DArt.Count = 0 Then Return

            DArt.Find("CODINT='" + TCodProd.Text + "'")

            If DArt.EOF Then Exit Sub

            TNomProd.Text = DArt.RecordSet("NOMBRE").ToString
            TPresEmp.Text = DArt.RecordSet("PRESEMP").ToString
            TPresText.Text = DArt.RecordSet("PRESTEXT").ToString
            TPresKg.Text = DArt.RecordSet("PRESKG").ToString

            If Funcion_FuncionesPlantaPremezclas Then
                TMHumeda.Text = DVarios.RecordSet("TMHUMEDA").ToString
                TNumPaq.Text = DVarios.RecordSet("NUMPAQXOP")
                TPresKg.Text = DVarios.RecordSet("PRESKG").ToString
            End If

            'Traemos los datos del empaque 

            DArt.Find("CODINT='" + TCodEmp.Text + "'")

            If DArt.EOF Then Exit Sub

            TNomEmp.Text = DArt.RecordSet("NOMBRE")

            'Traemos los datos de Etiquetas

            DArt.Find("CODINT='" + TCodEtiq.Text + "'")

            If DArt.EOF Then Exit Sub

            TNomEtiq.Text = DArt.RecordSet("NOMBRE")



        Catch ex As Exception
            MsgError(ex)
        End Try


    End Sub

    Private Sub DGOPsDos_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGOPsDos.CellClick
        Try
            If e Is Nothing OrElse e.RowIndex < 0 Then Return 'Cuando dan click en el encabezado de alguna columna del datagrid

            If DGOPsDos.CurrentRow Is Nothing Then Return
            If DGOPsDos.Rows.Count = 0 Then Exit Sub
            Fila = DGOPsDos.CurrentRow.Index + 1
            BBuscaOP_Click(Nothing, Nothing, DGOPsDos.Rows(DGOPsDos.CurrentRow.Index).Cells("DGOPsDos_OP").Value.ToString)

            If Funcion_FuncionesPlantaPremezclas Then FTraeEmpEtiqDet()

        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub BPlanillla_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BPlanillla.Click
        Try
            'If DRUsuario("EmpMod") Or DRUsuario("OPsVer") Or DRUsuario("OPsMod") Then
            If ValidaPermiso("Empaque_Editar, OPs_Ver, OPs_Editar") Then
            Else
                MsgBox(DevuelveEvento(CodEvento.USUARIO_PERMISODENEGADO), MsgBoxStyle.Information)
                Exit Sub
            End If
            Planilla.ShowDialog()
        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub BTMuertos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTMuertos.Click
        Try
            TMuertos.ShowDialog()
        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub BIngAdiciones_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BIngAdiciones.Click
        Try
            If Eval(TOPs.Text) = 0 Then Return

            DVarios.Open("select * from BACHES where OP='" + TOPs.Text + "'")

            If DVarios.Count = 0 Then
                MsgBox("No hay baches reportados. No puede ingresar adiciones", MsgBoxStyle.Information)
                Exit Sub
            End If

            AdicReproc.TOPs.Text = TOPs.Text
            AdicReproc.ShowDialog()

        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub TCodEmp_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TCodEmp.TextChanged
        Try
            TNomEmp.Text = ""
            If TCodEmp.Text = "" Then Return

            DArt.Open("Select * from ARTICULOS where TIPO='EM' and CODINT='" + TCodEmp.Text + "'")

            If DArt.Count = 0 Then Return


            TNomEmp.Text = DArt.RecordSet("NOMBRE")


        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub TCodEtiq_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TCodEtiq.TextChanged
        Try
            TNomEtiq.Text = ""
            If TCodEtiq.Text = "" Then Return

            DArt.Open("Select * from ARTICULOS where TIPO='ET' and CODINT='" + TCodEtiq.Text + "'")

            If DArt.Count = 0 Then Return


            TNomEtiq.Text = DArt.RecordSet("NOMBRE")


        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub DGOPsDos_CellFormatting(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles DGOPsDos.CellFormatting
        Try
            If Funcion_MaterialesBandeja Then
                If DGOPsDos.Columns(e.ColumnIndex).Name = "DGOPsDos_RealMed" Or DGOPsDos.Columns(e.ColumnIndex).Name = "DGOPsDos_RealMan1" Or DGOPsDos.Columns(e.ColumnIndex).Name = "DGOPsDos_RealMan2" Then
                    If e.Value IsNot Nothing Then
                        Dim valor As String = CType(e.Value, Integer)
                        If (valor > 0) Then
                            e.CellStyle.BackColor = Color.LightGreen
                        End If
                    End If
                End If
            Else
                If DGOPsDos.Columns(e.ColumnIndex).Name = "DGOPsDos_RealMed" Or DGOPsDos.Columns(e.ColumnIndex).Name = "DGOPsDos_RealMan" Then
                    If e.Value IsNot Nothing Then
                        Dim valor As String = CType(e.Value, Integer)
                        If (valor > 0) Then
                            e.CellStyle.BackColor = Color.LightGreen
                        End If
                    End If
                End If

                If Planta.Contains("FUNZA") Then
                    If DGOPsDos.Columns(e.ColumnIndex).Name = "DGOPsDos_RealMan1" Or DGOPsDos.Columns(e.ColumnIndex).Name = "DGOPsDos_RealMan2" Then
                        If e.Value IsNot Nothing Then
                            Dim valor As String = CType(e.Value, Integer)
                            If (valor > 0) Then
                                e.CellStyle.BackColor = Color.LightGreen
                            End If
                        End If
                    End If
                End If

            End If


        Catch ex As Exception

        End Try
    End Sub

    Private Sub DGOPsPrem_CellFormatting(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles DGOPsPrem.CellFormatting
        Try
            If Funcion_MaterialesBandeja Then
                If DGOPsPrem.Columns(e.ColumnIndex).Name = "DGOPsPrem_RealMed" Or DGOPsPrem.Columns(e.ColumnIndex).Name = "DGOPsPrem_RealMan1" Or DGOPsPrem.Columns(e.ColumnIndex).Name = "DGOPsPrem_RealMan2" Then
                    If e.Value IsNot Nothing Then
                        Dim valor As String = CType(e.Value, Integer)
                        If (valor > 0) Then
                            e.CellStyle.BackColor = Color.LightGreen
                        End If
                    End If
                End If
            Else
                If DGOPsPrem.Columns(e.ColumnIndex).Name = "DGOPsPrem_RealMed" Or DGOPsPrem.Columns(e.ColumnIndex).Name = "DGOPsPrem_RealMan" Then
                    If e.Value IsNot Nothing Then
                        Dim valor As String = CType(e.Value, Integer)
                        If (valor > 0) Then
                            e.CellStyle.BackColor = Color.LightGreen
                        End If
                    End If
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub mnBuscaOPFin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnBuscaOPFin.Click
        Try
            InputBox.InputBox("OPs", "Ingrese el número de OP a buscar", RespInput)

            If RespInput = "" Or Eval(RespInput) = 0 Then Return

            DOPs.Open("Select * from OPS where OP='" + RespInput + "'")

            If DOPs.Count = 0 Then
                MsgBox(DevuelveEvento(CodEvento.BD_REGNOEXISTE), vbInformation)
                BActualizar_Click(Nothing, Nothing)
                Return
            End If

            AsignaDataGrid(DGOPsDos, DOPs.DataTable, True)

        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub TNomProd_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TNomProd.KeyUp
        Try
            Dim x As Integer
            Dim Hallado As Boolean

            x = CBBuscar.SelectedIndex
            BusquedaDGContains(DGProd, "NOMBRE", TNomProd.Text, Hallado)

            If Hallado = False Then
                'CBBuscar.Focus()
                'MsgBox("Registro no encontrado", MsgBoxStyle.Information)
                Exit Sub
            End If
        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub


    Private Sub CBLinea_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles CBLinea.SelectedIndexChanged
        Try
            'Asigna las tolvas de acuerdo a la linea seleccionad en los combobox de las tolvas
            Dim Maquina As String = ""

            Select Case CBLinea.Text.ToUpper
                Case "EMPACADORA1"
                    Maquina = "E1"
                Case "EMPACADORA2"
                    Maquina = "E2"
                Case "EMPACADORA3"
                    Maquina = "E3"
                Case "PELET1"
                    Maquina = "P1"
                Case "PELET2"
                    Maquina = "P2"
                Case "PELET3"
                    Maquina = "P3"
                Case "GRANEL"
                    Maquina = "GR"
            End Select

            Dtolvas.Open("Select * from TOLVAS where PROCESO<>'DOSIFICACION' and MAQUINA='" + Maquina + "'")
            LLenaComboBox(CDestino1, Dtolvas.DataTable, "TOLVA")
            LLenaComboBox(CDestino2, Dtolvas.DataTable, "TOLVA")
            LLenaComboBox(CDestino3, Dtolvas.DataTable, "TOLVA")

        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub TBachesTanda_KeyUp(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles TBachesTanda.KeyUp
        If e.KeyCode <> Keys.Enter Then Return
        If GBProd.Visible = True Then
            TCodProd.Focus()
        ElseIf GBCliente.Visible = True Then
            TCodCli.Focus()
        Else
            BAceptar.Focus()
        End If
    End Sub


    Private Sub CDestino1_TextChanged(sender As System.Object, e As System.EventArgs) Handles CDestino1.TextChanged
        Try
            If CDestino1.Text = "X" Then TBachesDest1.Text = ""
        Catch ex As Exception
            e.ToString()
        End Try
    End Sub


    Private Sub CDestino2_TextChanged(sender As System.Object, e As System.EventArgs) Handles CDestino2.TextChanged
        Try
            If CDestino2.Text = "X" Then TBachesDest2.Text = ""
        Catch ex As Exception
            e.ToString()
        End Try
    End Sub

    Private Sub CDestino3_TextChanged(sender As System.Object, e As System.EventArgs) Handles CDestino3.TextChanged
        Try
            If CDestino3.Text = "X" Then TBachesDest3.Text = ""
        Catch ex As Exception
            e.ToString()
        End Try
    End Sub

    Private Sub BCambiaOPMic_Click(sender As System.Object, e As System.EventArgs) Handles BCambiaOPMic.Click
        'If DRUsuario("OPsMod") Then
        If ValidaPermiso("OPs_Editar") Then
        Else
            MsgBox(DevuelveEvento(CodEvento.USUARIO_PERMISODENEGADO), MsgBoxStyle.Information)
            Exit Sub
        End If
        CambiaMicrosOP.ShowDialog()
    End Sub

    Private Sub DGOPsPrem_CellContentClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGOPsPrem.CellContentClick
        Try
            If e Is Nothing OrElse e.RowIndex < 0 Then Return 'Cuando dan click en el encabezado de alguna columna del datagrid

            Dim Campo As String = DGOPsPrem.Columns(e.ColumnIndex).Name
            Dim OP As String = DGOPsPrem.Rows(e.RowIndex).Cells("DGOPsPrem_OP").Value.ToString

            ' Abort validation if cell is not VALOR column.
            If Not Campo.Contains("DGOPsPrem_MicHab") Then Return
            If Convert.ToBoolean(DGOPsPrem.Rows(e.RowIndex).Cells("DGOPsPrem_MicHab").Value) Then
                DGOPsPrem.Rows(e.RowIndex).Cells("DGOPsPrem_MicHab").Value = False
                DVarios.Open("Update OPS set MICHAB=0 where OP='" + OP + "'")
            Else
                DGOPsPrem.Rows(e.RowIndex).Cells("DGOPsPrem_MicHab").Value = True
                DVarios.Open("Update OPS set MICHAB=1 where OP='" + OP + "'")
            End If

        Catch ex As Exception
            MsgError(ex)
        End Try

    End Sub

    Private Sub DGOPsDos_CellContentClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGOPsDos.CellContentClick
        Try
            If e Is Nothing OrElse e.RowIndex < 0 Then Return 'Cuando dan click en el encabezado de alguna columna del datagrid

            Dim Campo As String = DGOPsDos.Columns(e.ColumnIndex).Name
            Dim OP As String = DGOPsDos.Rows(e.RowIndex).Cells("DGOPsDos_OP").Value.ToString

            ' Abort validation if cell is not VALOR column.
            If Not Campo.Trim.Contains("DGOPsDos_MicHab") Then Return
            If Convert.ToBoolean(DGOPsDos.Rows(e.RowIndex).Cells("DGOPsDos_MicHab").Value) Then
                DGOPsDos.Rows(e.RowIndex).Cells("DGOPsDos_MicHab").Value = False
                DVarios.Open("Update OPS set MICHAB=0 where OP='" + OP + "'")
            Else
                DGOPsDos.Rows(e.RowIndex).Cells("DGOPsDos_MicHab").Value = True
                DVarios.Open("Update OPS set MICHAB=1 where OP='" + OP + "'")
            End If

        Catch ex As Exception
            MsgError(ex)
        End Try

    End Sub

    Private Sub BSolictudCargue_Click(sender As System.Object, e As System.EventArgs) Handles BSolictudCargue.Click
        Try
            'If DRUsuario("SolicVaceo") Then
            If ValidaPermiso("SolicitudVaceo") Then
            Else
                MsgBox(DevuelveEvento(CodEvento.USUARIO_PERMISODENEGADO), MsgBoxStyle.Information)
                Exit Sub
            End If
            SolictudCargue.ShowDialog()
        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub
    Private Sub FComboPrem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FComboPrem.Click
        Try
            If Eval(TCodFor.Text) = 0 Then Return

            DDatosFor.Open("select * from DATOSFOR where CODFOR='" + TCodFor.Text + "' and (A='F' or A='R')")

            CCodPrem.Items.Clear()
            For i As Integer = 0 To DDatosFor.Rows.Count - 1
                CCodPrem.Items.Add(DDatosFor.Rows(i).Item("CODMAT").ToString + " " + DDatosFor.Rows(i).Item("NOMMAT").ToString)
            Next

        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub
    Private Sub CCodPrem_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CCodPrem.KeyDown
        If e.KeyCode = Keys.Back OrElse e.KeyCode = Keys.Delete Then e.SuppressKeyPress = True
    End Sub
    Private Sub CLotePrem_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CLotePrem.KeyDown
        If e.KeyCode = Keys.Back OrElse e.KeyCode = Keys.Delete Then e.SuppressKeyPress = True
    End Sub


    Private Sub OPPlantaGir_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles OPPlantaGir.CheckedChanged
        If Not FormLoad Then Return
        If OPPlantaGir.Checked Then
            FiltroPlantaExt = "GIR"
            BActualizar_Click(Nothing, Nothing)
        End If

    End Sub

    Private Sub OPPlantaYar_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles OPPlantaYar.CheckedChanged
        If Not FormLoad Then Return
        If OPPlantaYar.Checked Then
            FiltroPlantaExt = "YAR"
            BActualizar_Click(Nothing, Nothing)
        End If

    End Sub

    Private Sub OPPlantaSantaRosa_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles OPPlantaSantaRosa.CheckedChanged
        If Not FormLoad Then Return
        If OPPlantaSantaRosa.Checked Then
            FiltroPlantaExt = "STRO"
            BActualizar_Click(Nothing, Nothing)
        End If

    End Sub

    Private Sub FGuardaEmpEtiqDet()
        Try
            'Recorre el DG del listado de empaques y etiquetas para almacenarlo en la tabla EmpEtiqDet

            Dim CodInt As String = ""
            Dim OP As String = ""
            Dim FechaIni As String = FechaC()
            Dim Cant As Integer = 0
            Dim Nombre As String = ""
            Dim Tipo As String = ""

            'Se calula la cantidad de empaques y etiquetas con el valor teorico

            If Eval(TTotalFor.Text) = 0 Then Return
            If Eval(TPresKg.Text) = 0 Then Return

            Cant = Eval(TTotalFor.Text) * Val(TMeta.Text) / Val(TPresKg.Text)

            'Se guarda la fecha de empaque por si se va a modificar una OP que ya se empaco
            DVarios.Open("Select * FROM EMPETIQDET WHERE OP='" + TOPs.Text + "'")

            If DVarios.Count Then FechaIni = DVarios.RecordSet("FECHAINI")

            DEmpEtiqDet.Open("Delete from EMPETIQDET WHERE OP='" + TOPs.Text + "'")

            For i = 1 To 2

                'Se guardan dos registros, uno para el empaque y otro para la etiqueta, con el terico

                If i = 1 Then
                    CodInt = TCodEmp.Text
                    Nombre = TNomEmp.Text
                    Tipo = "EM"
                End If

                If i = 2 Then
                    CodInt = TCodEtiq.Text
                    Nombre = TNomEtiq.Text
                    Tipo = "ET"
                End If

                If CodInt = "" Or Nombre = "" Then Continue For

                DEmpEtiqDet.Open("Select * from EMPETIQDET where OP='0'")

                DEmpEtiqDet.AddNew()

                DEmpEtiqDet.RecordSet("OP") = TOPs.Text
                DEmpEtiqDet.RecordSet("CODINT") = CodInt
                DEmpEtiqDet.RecordSet("NOMBRE") = Nombre
                DEmpEtiqDet.RecordSet("TIPO") = Tipo
                DEmpEtiqDet.RecordSet("CANTTOTAL") = Cant
                'DEmpEtiqDet.RecordSet("CANTBACHE") = Fila.Cells("DGListEmp_CantBache").Value
                DEmpEtiqDet.RecordSet("FECHAINI") = FechaIni

                DEmpEtiqDet.Update()

            Next

        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub FAdicEmpEtiq(ByVal CodInt As String, ByVal Nombre As String, ByVal Tipo As String, ByVal Cant As Single, ByVal OP As String, ByVal CantxBache As Single)
        Try
            If CodInt = "" Then Return
            If Nombre = "" Then Return
            If Tipo = "" Then Return
            If Cant = 0 Then
                MsgBox("Cantidad de paquetes x OP en cero, revisar configuración de fórmula", vbCritical)
                Return
            End If
            If OP = "" Then Return
            If CantxBache = 0 Then
                MsgBox("Cantidad de paquetes x bache en cero, revisar configuración de fórmula", vbCritical)
                Return
            End If

            Dim Fila As Int16 = 1
            DGListEmp.Rows.Add()
            Fila = DGListEmp.Rows.Count - 1


            DGListEmp.Rows(Fila).Cells("DGListEmp_OP").Value = OP
            DGListEmp.Rows(Fila).Cells("DGListEmp_CodInt").Value = CodInt
            DGListEmp.Rows(Fila).Cells("DGListEmp_Nombre").Value = Nombre
            DGListEmp.Rows(Fila).Cells("DGListEmp_Tipo").Value = Tipo
            DGListEmp.Rows(Fila).Cells("DGListEmp_CantTotal").Value = Cant
            DGListEmp.Rows(Fila).Cells("DGListEmp_CantBache").Value = CantxBache


        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub



    Private Sub TCodEmpEtiq_KeyUp(sender As Object, e As KeyEventArgs) Handles TCodEmpEtiq.KeyUp

        Try
            If e.KeyCode = Keys.Enter AndAlso DGEmpaques.Rows.Count = 1 Then
                DGEmpaques_CellClick(Nothing, Nothing)
                Exit Sub
            End If

            If e.KeyCode = Keys.Back Then
                TNomEmpEtiq.Text = ""
                'TNomForB.Text = ""
            End If

            If TCodEmpEtiq.Text = "" Then
                'Vuelve a asignar al datagrid todas las formulas de la tabla
                AsignaDataGrid(DGEmpaques, DCodEmpEtiq.DataTable, True)
                Exit Sub
            End If

            Dim Hallado As Boolean

            BusquedaDG(DGEmpaques, DCodEmpEtiq.DataTable, TCodEmpEtiq.Text, "CODINT", Hallado)

            If Hallado = False Then
                ''TCodForB.Focus()
                'MsgBox("Registro no encontrado", MsgBoxStyle.Information)
                Exit Sub
            End If

        Catch ex As Exception
            MsgError(ex)
        End Try

    End Sub

    Private Sub TCodEmpEtiq_Enter(sender As Object, e As EventArgs) Handles TCodEmpEtiq.Enter
        Try
            DGEmpaques.Location = New Point(109, 480)
            DGEmpaques.BringToFront()
            DGEmpaques.Visible = True
        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub FTraeEmpEtiqDet()
        Try
            If Val(TOPs.Text) = 0 Then Return

            DEmpEtiqDet.Open("Select * from EMPETIQDET where OP='" + TOPs.Text + "'")

            AsignaDataGrid(DGListEmp, DEmpEtiqDet.DataTable, True)

        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub FGuardaEmpEtiqDetDG()
        Try
            'Recorre el DG del listado de empaques y etiquetas para almacenarlo en la tabla EmpEtiqDet

            Dim CodInt As String = ""
            Dim OP As String = ""
            Dim FechaIni As String = ""



            'Se guarda la fecha de empaque por si se va a modificar una OP que ya se empaco
            DVarios.Open("Select * FROM EMPETIQDET WHERE OP='" + TOPs.Text + "'")

            If DVarios.Count Then FechaIni = DVarios.RecordSet("FECHAINI")

            DEmpEtiqDet.Open("Delete from EMPETIQDET WHERE OP='" + TOPs.Text + "'")

            For Each Fila As DataGridViewRow In DGListEmp.Rows
                CodInt = Fila.Cells("DGListEmp_CodInt").Value
                OP = Fila.Cells("DGListEmp_OP").Value 'DGListEmp_OP

                DEmpEtiqDet.Open("Select * from EMPETIQDET where OP='0'")

                DEmpEtiqDet.AddNew()

                DEmpEtiqDet.RecordSet("OP") = OP
                DEmpEtiqDet.RecordSet("CODINT") = CodInt
                DEmpEtiqDet.RecordSet("NOMBRE") = Fila.Cells("DGListEmp_Nombre").Value
                DEmpEtiqDet.RecordSet("TIPO") = Fila.Cells("DGListEmp_Tipo").Value
                DEmpEtiqDet.RecordSet("CANTTOTAL") = Fila.Cells("DGListEmp_CantTotal").Value
                DEmpEtiqDet.RecordSet("CANTBACHE") = Fila.Cells("DGListEmp_CantBache").Value
                DEmpEtiqDet.RecordSet("FECHAINI") = FechaIni

                DEmpEtiqDet.Update()

            Next



        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub FValidaEmpEtiqDet()
        Try
            'Recorre el DG del listado de empaques y etiquetas para validar si los empaques
            'y etiquetas a almacenar corresponden a los configurados en el producto


            Dim CodInt As String = ""
            For Each Fila As DataGridViewRow In DGListEmp.Rows
                CodInt = Fila.Cells("DGListEmp_CodInt").Value
                If CodInt = TCodEmp.Text Then EncontroEmp = True
                If CodInt = TCodEtiq.Text Then EncontroEtiq = True
            Next


        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub TNomCli_TextChanged(sender As System.Object, e As System.EventArgs) Handles TNomCli.TextChanged
        Try
            If TNomCli.Text = "" Then Return

            If Funcion_FuncionesPlantaPremezclas Then
                DClientes.Find("NOMCLI='" + TNomCli.Text + "'")
                If Not DClientes.EOF Then TBodDestino.Text = DClientes.RecordSet("BODDEST")
            End If

        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub DGEmpaques_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGEmpaques.CellClick
        Try
            If DGEmpaques.Rows.Count = 0 Then Exit Sub

            TCodEmpEtiq.Text = DGEmpaques.Rows(DGEmpaques.CurrentRow.Index).Cells("DGEMPAQUES_CODINT").Value.ToString
            TNomEmpEtiq.Text = DGEmpaques.Rows(DGEmpaques.CurrentRow.Index).Cells("DGEMPAQUES_NOMBRE").Value.ToString
            TTipo.Text = DGEmpaques.Rows(DGEmpaques.CurrentRow.Index).Cells("DGEMPAQUES_TIPO").Value.ToString
            DGEmpaques.Visible = False


        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub BCancelarEmps_Click(sender As Object, e As EventArgs) Handles BCancelarEmps.Click
        Try
            If DGListEmp.RowCount = 0 Then Return
            DGListEmp.Rows.RemoveAt(DGListEmp.CurrentRow.Index)
        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub BAdicionarEmps_Click(sender As Object, e As EventArgs) Handles BAdicionarEmps.Click
        Try

            FAdicEmpEtiq(TCodEmpEtiq.Text, TNomEmpEtiq.Text, TTipo.Text, Val(TNumPaq.Text), TOPs.Text, Val(TNumPaqxBache.Text))

            TCodEmpEtiq.Text = ""
            TNomEmpEtiq.Text = ""

        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub CCodPrem_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CCodPrem.SelectedIndexChanged
        Try
            Dim codprem2 As String = ""
            Dim pos1 As Integer
            If CCodPrem.Text = "" Then Return
            pos1 = InStr(CCodPrem.Text, " ")
            codprem2 = Mid(CCodPrem.Text, 1, pos1)

            DCortesMP.Open("Select * from CORTESLOTE where FINALIZADO<>'S' and CODMAT='" + codprem2 + "'")
            LLenaComboBox(CLotePrem, DCortesMP.DataTable, "LOTE")
            CLotePrem.Focus()

            If DCortesMP.Count = 0 Then
                CLotePrem.Items.Add("")
                CLotePrem.Text = ""
                CLotePrem.Items.Remove("")
            End If
        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub CLinea_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CLinea.SelectedIndexChanged
        Try
            If Not Funcion_FuncionesPlantaPremezclas Then Return

            DLineasProd.Open("select * from LINEASPROD where LINEA='" + CLinea.Text.ToUpper + "' and TIPO='LN'")
            If DLineasProd.Count Then
                TMHumeda.Text = DLineasProd.RecordSet("TMHUMEDA")
                Select Case CLinea.Text.ToUpper
                    Case "WASVELT", "TAMBOR"
                        'Se revisa la especie, porque dependiendo de la especie cambia el tiempo de mezcla
                        Dim CodEspecie As String = ""
                        If TCodFor.Text <> "" And TLP.Text <> "" Then
                            DFor.Find("CODFOR='" + TCodFor.Text + "' AND LP='" + TLP.Text + "'")
                            If Not DFor.EOF Then CodEspecie = DFor.RecordSet("CODESPECIE")
                            If CodEspecie <> "" Then
                                DEspecies.Open("Select * from ESPECIES where CODESPECIE='" + CodEspecie + "'")
                                If DEspecies.Count And Val(TMHumeda.Text) > 0 Then
                                    TMHumeda.Text = DEspecies.RecordSet("TMHUMEDA")
                                End If
                            End If
                        End If
                End Select
                TMHumeda.Focus()
            End If

        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub TMHumeda_KeyUp(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles TMHumeda.KeyUp
        If e.KeyCode = Keys.Enter Then
            TObservOP.Focus()
        End If
    End Sub

    Private Sub TMeta_TextChanged(sender As Object, e As EventArgs) Handles TMeta.TextChanged
        If Funcion_FuncionesPlantaPremezclas Then TBAhora.Text = TMeta.Text
    End Sub

    Private Sub FBuscaProdEquivalentes()
        'Se busca en la tabla de equivalencias de formulas y productos si hay un código de producto equivalente
        ' para la formula seleccionada

        Dim CodigosProdFiltrar As String = ""

        DEquivFormProd.Open("Select * from EQUIVFORMPROD where CODFOR='" + TCodFor.Text + "'")

        For Each Fila As DataRow In DEquivFormProd.Rows
            CodigosProdFiltrar += "'" + Fila("CODPROD") + "'" + ","
        Next

        If CodigosProdFiltrar.Length > 2 Then
            CodigosProdFiltrar = CLeft(CodigosProdFiltrar, InStrRev(CodigosProdFiltrar, ",") - 1)
            DArt.Open("select * from ARTICULOS where TIPO='PT' and CODINT IN(" + CodigosProdFiltrar + ") ORDER BY NOMBRE")
            AsignaDataGrid(DGProd, DArt.DataTable)
        End If
    End Sub

End Class