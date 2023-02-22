Option Explicit On

Imports System
Imports System.Data
Imports ClassLibrary


Public Class CargueMan
    Private DTolvas As AdoSQL
    Private DProcEnLinea As AdoSQL
    Private DRet As AdoSQL
    Private DVarios As AdoSQL
    Private DUsuarios As AdoSQL
    Private Fila As Int32
    Private DCortes As AdoSQL
    Private Campos() As String
    Private DConfig As AdoSQL
    Private Linea As Int16 = 10
    Private FormLoad As Boolean
    Private LeerEtiquetaVaceo As Boolean 'Variable para mostrar el GroupBox "FramEtiq" si la planta maneja etiqueta

    Private Sub CargueMan_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try

            If FormLoad Then Return
            DRet = New AdoSQL("RETAQUE")
            DTolvas = New AdoSQL("TOLVAS")
            DUsuarios = New AdoSQL("USUARIOS")
            DCortes = New AdoSQL("CORTES")
            DProcEnLinea = New AdoSQL("PROCESOENLINEA")
            DVarios = New AdoSQL("VARIOS")
            DConfig = New AdoSQL("CONFIG")

            DRet.Open("select * from RETAQUE where STATUS=0 and HABILITADO=1 order by Prioridad")
            DConfig.Open("Select * from CONFIG")
            DTolvas.Open("select * from TOLVAS where PROCESO='DOSIFICACION' order by TOLVA")
            DUsuarios.Open("select * from USUARIOS where ACTIVO=0")

            AsignaDataGrid(DGSoliCargue, DRet.DataTable)

            If DRet.Count > 0 Then DGSoliCargue_CellClick(Nothing, Nothing)

            TextNum(TTolva)
            TTolva.ReadOnly = True
            TLote.ReadOnly = True
            TCantidad.ReadOnly = True
            BAceptar.Enabled = False
            TextNum(TBultos)
            TextNum(TPromedio, True)
            FramEtiq.Visible = False

            Campos = {"CodMat@Cód.Int.", "NomMat@Nombre"}
            Campos = AsignaItemsCB(Campos, CBBuscar.ComboBox, DRet.DataTable)

            TOperario.Text = UsuarioPrincipal

            'ASignamos linea de vaceo, de acuerdo a tabla configvar
            If Planta.Contains("Barranquilla") Then
                If NombrePC = ConfigParametros("PcVaceoL1") Then
                    Linea = 1
                End If

                If NombrePC = ConfigParametros("PcVaceoL2") Then
                    Linea = 2
                End If
            Else
                Linea = 10
            End If

            LeerEtiquetaVaceo = ValidaFuncionalidad("Leer.EtiquetaVaceo")
            FormLoad = True

        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub DGSoliCargue_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGSoliCargue.CellClick
        Try
            If DGSoliCargue.RowCount = 0 Then Return

            Dim Cont As String

            Cont = DGSoliCargue.Rows(DGSoliCargue.CurrentRow.Index).Cells("CONT").Value.ToString

            DRet.Find("CONT=" + Cont)
            If DRet.EOF = True Then Return

            TTolva.Text = DRet.RecordSet("TOLVA")
            TCodMat.Text = DRet.RecordSet("CODMAT")
            TNomMat.Text = DRet.RecordSet("NOMMAT")
            TLote.Text = DRet.RecordSet("LOTE")
            TCantidad.Text = DRet.RecordSet("PESOMETA")
            TPromedio.Text = DRet.RecordSet("PROMBULTOS")
            TObservaciones.Text = DRet.RecordSet("OBSERVACION")
            TBultos.Text = ""
            'TOperario.Text = ""
            TLoteVaceo.Text = ""

            Fila = DGSoliCargue.CurrentRow.Index

            BInicarVaceo.Visible = True
            If DRet.RecordSet("FECHAINI") <> "-" Then
                BInicarVaceo.Visible = False
                TLoteVaceo.Text = TLote.Text
                BAceptar.Enabled = True
            End If


        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub


    Private Sub TTolva_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TTolva.TextChanged
        Try
            If Eval(TTolva.Text) = 0 Then Return

            DTolvas.Find("TOLVA=" + TTolva.Text)

            If DTolvas.EOF = True Then Return

            TCodMat.Text = DTolvas.RecordSet("CODINT")
            TNomMat.Text = DTolvas.RecordSet("NOMBRE")
        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub BAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BAceptar.Click
        Try
            Dim Cont As String
            Dim FechaRetAnt As String
            'Dim Minutos As Single


            DVarios.Open("Select top 1 * from RETAQUE order by fechafin desc")

            FechaRetAnt = DVarios.RecordSet("FECHAFIN")

            Cont = DGSoliCargue.Rows(DGSoliCargue.CurrentRow.Index).Cells("CONT").Value.ToString



            DRet.Find("CONT=" + Cont)
            If DRet.EOF = True Then Return



            If Eval(TCodMat.Text) = 0 Then
                MsgBox(DevuelveEvento(CodEvento.SISTEMA_FALTACAMPO, " código de material"), MsgBoxStyle.Information)
                Exit Sub
            End If

            If Trim(TNomMat.Text) = "" Then
                MsgBox(DevuelveEvento(CodEvento.SISTEMA_FALTACAMPO, " nombre de material"), MsgBoxStyle.Information)
                Exit Sub
            End If

            If Trim(TLote.Text) = "" Then
                MsgBox(DevuelveEvento(CodEvento.SISTEMA_FALTACAMPO, " lote"), MsgBoxStyle.Information)
                Exit Sub
            End If

            If Eval(TCantidad.Text) = 0 Then
                MsgBox(DevuelveEvento(CodEvento.SISTEMA_FALTACAMPO, " cantidad"), MsgBoxStyle.Information)
                Exit Sub
            End If

            If Eval(TCantidad.Text) > 32000 Then
                MsgBox(DevuelveEvento(CodEvento.SISTEMA_VALORINCORRECTO, " cantidad debe ser menor a 32000"), MsgBoxStyle.Information)
                Exit Sub
            End If
            If TLote.Text = "-" Then
                If TLoteVaceo.Text.Trim <> TLote.Text.Trim Then
                    RespInput = MsgBox("El Lote inicial es diferente del ingresado en el vaceo, esta seguro de cambiarlo?", MsgBoxStyle.YesNo + MsgBoxStyle.Information)
                    If RespInput = vbYes Then
                        Evento("Cambia lote en Vaceo Inical " + TLote.Text + " Final " + TLoteVaceo.Text)
                        TLote.Text = TLoteVaceo.Text
                    End If
                End If
            Else
                If TLoteVaceo.Text.Trim <> TLote.Text.Trim Then
                    MsgBox("El lote leído no coincide con el lote solicitado", MsgBoxStyle.Information)
                    Exit Sub
                End If

            End If



            'Calculo de tiempo muerto en retaque

            'If FechaRetAnt.Contains(" ") = True Then
            '    Minutos = DateDiff("n", CDate(FechaRetAnt), CDate(DRet.RecordSet("FECHAINI")))
            '    If Minutos < 0 Then Minutos *= -1
            '    If Minutos > DConfig.RecordSet("TMPOMXMOMTO") Then Minutos = ReadConfigVar("TMPOVACEO")
            'Else
            '    Minutos = ReadConfigVar("TMPOVACEO")
            'End If


            'If Minutos > (ReadConfigVar("TMPOVACEO")) Then DRet.RecordSet("TMPOMTO") = Minutos - ReadConfigVar("TMPOVACEO")

            'If Minutos > (DConfig.RecordSet("TMPOBACHE") + 10) Then

            '    DTMuertos.Open("select * from TMUERTOS WHERE CONT=" + Contador)

            '    If DTMuertos.Count = 0 Then
            '        DTMuertos.AddNew()

            '        DTMuertos.RecordSet("CONT") = Contador
            '        DTMuertos.RecordSet("Fecha") = DBaches.RecordSet("Fecha")
            '        DTMuertos.RecordSet("PROCESO") = "DOSIF"
            '        DTMuertos.RecordSet("TIEMPO") = Minutos - DConfig.RecordSet("TMPOBACHE")
            '        DTMuertos.RecordSet("Usuario") = CLeft(DRUsuario("USUARIO"), 10)
            '        Evento("Tiempo MUERTO : " + DTMuertos.RecordSet("TIEMPO").ToString + " minutos")
            '        DTMuertos.Update()

            '    End If

            'End If
            ''DRet.RecordSet("LINEA") = 10
            DRet.RecordSet("LINEA") = Linea
            DRet.RecordSet("LOTE") = CLeft(TLote.Text, 15)
            DRet.RecordSet("BULTOS") = Eval(TBultos.Text)
            DRet.RecordSet("PROMBULTOS") = Eval(TPromedio.Text)
            DRet.RecordSet("PESOREAL") = Format(Eval(TBultos.Text) * Eval(TPromedio.Text), ".00")
            DRet.RecordSet("FECHAFIN") = Now.ToString("yyyy/MM/dd HH:mm:ss")
            If Eval(DRet.RecordSet("FECHAINI")) = 0 Then DRet.RecordSet("FECHAINI") = Now.ToString("yyyy/MM/dd HH:mm:ss")
            DRet.RecordSet("STATUS") = 1
            DRet.RecordSet("OPERARIO") = TOperario.Text
            DRet.RecordSet("MINUTOS") = DateDiff(DateInterval.Minute, CDate(DRet.RecordSet("FECHAINI")), CDate(DRet.RecordSet("FECHAFIN")))
            DRet.RecordSet("OBSERVACION") = CLeft(TObservaciones.Text, 50)
            DTolvas.Refresh()
            DTolvas.Find("TOLVA=" + DRet.RecordSet("TOLVA").ToString)

            If DTolvas.EOF = False Then
                DTolvas.RecordSet("TOTAL") = DTolvas.RecordSet("TOTAL") + DRet.RecordSet("PESOREAL")
                DTolvas.Update()
            Else
                Evento("No se encontró la TOLVA:" + DRet.RecordSet("TOLVA").ToString + " para agregar el cargue")
            End If

            DRet.Update()

            Evento("Realiza Cargue Manual 'Vaceo', a tolva " + TTolva.Text + " cantidad KG " + (Eval(TBultos.Text) * Eval(TPromedio.Text)).ToString)

            BActualizar_Click(Nothing, Nothing)

        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub BBorrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BBorrar.Click
        Try
            If DGSoliCargue.RowCount = 0 Then Return

            Dim Cont As String

            Cont = DGSoliCargue.Rows(DGSoliCargue.CurrentRow.Index).Cells("CONT").Value.ToString

            RespInput = MsgBox(DevuelveEvento(CodEvento.BD_REGFINALIZAR), MsgBoxStyle.Information + vbYesNo)
            If RespInput = vbNo Then Exit Sub


            DRet.Find("CONT=" + Cont)
            If DRet.EOF = True Then Return

            DRet.RecordSet("STATUS") = 2
            DRet.Update()

            BActualizar_Click(Nothing, Nothing)

        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub BActualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BActualizar.Click
        Try
            DRet.Open("select * from RETAQUE where STATUS=0 and HABILITADO=1 order by Prioridad")
            AsignaDataGrid(DGSoliCargue, DRet.DataTable)
            If DRet.Count > 0 Then DGSoliCargue_CellClick(Nothing, Nothing)
        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub


    Private Sub BSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BSalir.Click
        Try
            Me.Hide()
        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub


    Private Sub BInicarVaceo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BInicarVaceo.Click
        Try
            Dim ContCorte As Int64
            Dim Cont As Int32


            For Each Fila As DataGridViewRow In DGSoliCargue.Rows

                If Fila.Cells("FechaIni").Value = "-" Then Continue For
                Cont += 1
            Next

            If Cont >= 2 Then
                MsgBox("No puede iniciar mas de dos cargues al tiempo", vbCritical)
                Return
            End If

            If TLote.Text = "-" OrElse LeerEtiquetaVaceo = False Then

                ContCorte = DGSoliCargue.Rows(DGSoliCargue.CurrentRow.Index).Cells("CONT").Value.ToString

                DRet.Open(" Select * from RETAQUE WHERE CONT=" + ContCorte.ToString)
                If DRet.Count = 0 Then Return

                DRet.RecordSet("FECHAINI") = Now.ToString("yyyy/MM/dd HH:mm:ss")


                'Se llena el dato en linea del vaceo

                DProcEnLinea.Open("Select * from PROCESOENLINEA where PROCESO='VACEO'")

                If DProcEnLinea.Count > 0 Then
                    DProcEnLinea.RecordSet("NOMMAT") = DRet.RecordSet("NOMMAT")
                    DProcEnLinea.RecordSet("PESOMETA") = DRet.RecordSet("PESOMETA")
                    DProcEnLinea.Update()
                End If


                DRet.Update()

                BActualizar_Click(Nothing, Nothing)

            Else
                FramEtiq.Visible = LeerEtiquetaVaceo
                TTrama.Focus()
            End If


        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub DGSoliCargue_CellFormatting(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles DGSoliCargue.CellFormatting
        Try
            If DGSoliCargue.Columns(e.ColumnIndex).Name = "FechaIni" Then
                If e.Value IsNot Nothing Then
                    Dim valor As String = CType(e.Value, String)
                    If (valor <> "-") Then
                        DGSoliCargue.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.Yellow
                        ' DGSoliCargue.RowsDefaultCellStyle.BackColor = Color.Yellow
                        ' e.CellStyle.BackColor = Color.Yellow
                    End If
                End If
            End If

            DGSoliCargue.Rows(e.RowIndex).Cells("PESOMETA").Value = Format(Convert.ToDecimal(DGSoliCargue.Rows(e.RowIndex).Cells("PESOMETA").Value), "#,###.00")

        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub BEditar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BEditar.Click
        BAceptar.Enabled = True
    End Sub

    Private Sub TTrama_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TTrama.KeyUp
        Dim Cadena, Tipo, Ubicacion, Corte, PesoPromSac, Datos() As String
        Try

            If e.KeyCode <> Keys.Enter Then Return

            If TTrama.Text = "" Then Return

            'If TTrama.Text.Length <> 24 Then
            '    TTrama.Text = ""
            '    BCancelar_Click(Nothing, Nothing)
            '    Return
            'End If

            If TTrama.Text.Contains("INI") = False OrElse TTrama.Text.Contains("FIN") = False Then
                TTrama.Text = ""
                Return
            End If

            Ubicacion = ""

            If TTrama.Text.Contains("INIXXXX") Then
                Cadena = Mid(TTrama.Text, 8)
            ElseIf TTrama.Text.Contains("INI") Then
                Cadena = Mid(TTrama.Text, 4)
            Else
                TTrama.Text = ""
                Return
            End If

            Datos = Cadena.Split("K")

            Tipo = Datos(0)
            Select Case Tipo
                Case "MP"
                    Corte = Datos(3)
                    ' Condicion = Datos(2)
                    Ubicacion = Datos(1)
                    Select Case Mid(Ubicacion, 2, 1)
                        Case "!" '1
                            Ubicacion = CLeft(Ubicacion, 1) + "1"
                        Case "@" '2
                            Ubicacion = CLeft(Ubicacion, 1) + "2"
                        Case "#" '3
                            Ubicacion = CLeft(Ubicacion, 1) + "3"
                        Case "$" '4
                            Ubicacion = CLeft(Ubicacion, 1) + "4"
                        Case "%" '5
                            Ubicacion = CLeft(Ubicacion, 1) + "5"
                    End Select
                    PesoPromSac = Datos(2)
                    DCortes.Open("select * from CORTESLOTE where CONT=" + Corte + " and FINALIZADO<>'S'")
                    If DCortes.Count = 0 Then
                        TTrama.Text = ""
                        MsgBox("No existe el Lote Leido", MsgBoxStyle.Information)
                        Return
                    End If
                    If DCortes.RecordSet("VIGENTE") <> "APROBADO" Then
                        TTrama.Text = ""
                        MsgBox("El Lote Leido no esta aprobado por calidad", MsgBoxStyle.Information)
                        'Return
                    End If
            End Select

            TTrama.Text = ""

            Dim Cont As String

            Cont = DGSoliCargue.Rows(DGSoliCargue.CurrentRow.Index).Cells("CONT").Value.ToString

            DRet.Find("CONT=" + Cont)
            If DRet.EOF = True Then Return

            DRet.RecordSet("FECHAINI") = Now.ToString("yyyy/MM/dd HH:mm:ss")
            DRet.RecordSet("LOTE") = DCortes.RecordSet("LOTE")
            TLoteVaceo.Text = DCortes.RecordSet("LOTE")
            DRet.RecordSet("CORTE") = DCortes.RecordSet("CONT")
            DRet.RecordSet("PROMBULTOS") = DCortes.RecordSet("PesoProm")
            DRet.RecordSet("ORIGEN") = Ubicacion

            'Se llena el dato en linea del vaceo

            DProcEnLinea.Open("Select * from PROCESOENLINEA where PROCESO='VACEO'")

            If DProcEnLinea.Count > 0 Then
                DProcEnLinea.RecordSet("NOMMAT") = DRet.RecordSet("NOMMAT")
                DProcEnLinea.RecordSet("PESOMETA") = DRet.RecordSet("PESOMETA")
                DProcEnLinea.Update()
            End If


            DRet.Update()

        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub BCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BCancelar.Click
        FramEtiq.Visible = False
    End Sub
    Private Sub TBuscar_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TBuscar.KeyUp, CBBuscar.KeyUp
        Try
            If CBBuscar.Text = "" Then
                CBBuscar.Focus()
                MsgBox("Debe seleccionar el campo a buscar", MsgBoxStyle.Exclamation)
                TBuscar.Text = ""
                Exit Sub
            End If

            If TBuscar.Text = "" Then
                CargueMan_Load(Nothing, Nothing)
                Exit Sub
            End If

            Dim x As Integer
            Dim Hallado As Boolean

            x = CBBuscar.SelectedIndex

            'If TipoCampo(Campos(x), DTMat) <> "String" AndAlso e.KeyCode <> Keys.Enter Then Exit Sub

            BusquedaDG(DGSoliCargue, DRet.DataTable, TBuscar.Text, Campos(x), Hallado)

            If Hallado = False Then
                'CBBuscar.Focus()
                'MsgBox("Registro no encontrado", MsgBoxStyle.Information)
                Exit Sub
            End If

            DGSoliCargue_CellClick(Nothing, Nothing)


        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub
    
End Class