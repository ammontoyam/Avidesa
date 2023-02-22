Imports ClassLibrary


Public Class DatosHora
    Private DCons As AdoSQL
    Private DOPs As AdoSQL
    Private DEmp As AdoSQL
    Private DBaches As AdoSQL
    Private DVarios As AdoSQL
    Private DDatosHora As AdoSQL
    Private DTurnos As AdoSQL

    Private Turnos(4) As String
    Private ActualizaTurno(4) As Boolean
    Private HoraAnt As Int16


    Public Sub DatosHora_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try

            DCons = New AdoSQL("-")
            DOPs = New AdoSQL("-")
            DEmp = New AdoSQL("-")
            DBaches = New AdoSQL("-")
            DVarios = New AdoSQL("-")
            DDatosHora = New AdoSQL("-")
            DTurnos = New AdoSQL("-")

            DTurnos.Open("Select * from TURNOS")

            For Each RDTurnos As DataRow In DTurnos.Rows
                Turnos(RDTurnos("TURNO")) = RDTurnos("HORAINI")
            Next

            DGDosif.AutoGenerateColumns = False
            DGEmp.AutoGenerateColumns = False
            DGErrTolvas.AutoGenerateColumns = False

            DDatosHora.Open("Delete from DATOSHORA where FECHA<'" + Format(DateAdd(DateInterval.Month, -1, Now), "yyyy/MM/dd") + "'")

        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub BDosif_Click(sender As Object, e As EventArgs) Handles BDosif.Click
        Try
            Dim Hora As Int16 = Now.Hour
            'Se guarda en la tabla datosHora los datos devuelvtos en la función
            'Se guardan los de la hora actual y la hora anterior



            DatosDosificadoHoraHora(Hora, "PELETIZADO")
            'Se realiza la consulta para linea EXTRUIDOS
            DatosDosificadoHoraHora(Hora, "EXTRUIDO")

            'Se realiza la consulta de verificación de la hora anterior
            Hora = Hora - 1
            If Hora < 0 Then
                Hora = 23
                'Se realiza vwerificación de la hora y se hace cambio de día
                DatosDosificadoHoraHora(Hora, "PELETIZADO", True)
                'Se realiza la consulta para linea EXTRUIDOS
                DatosDosificadoHoraHora(Hora, "EXTRUIDO", True)
            Else
                DatosDosificadoHoraHora(Hora, "PELETIZADO")
                'Se realiza la consulta para linea EXTRUIDOS
                DatosDosificadoHoraHora(Hora, "EXTRUIDO")
            End If



        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub DatosDosificadoHoraHora(ByVal Hora As Int16, ByVal LineaPresent As String, Optional ByVal CambioFecha As Boolean = False)
        Try

            Application.DoEvents()

            Dim FechaA As String
            Dim FechaB As String
            Dim FechaIni As String = CLeft(FechaC(), 10) + " " + Hora.ToString("00") + ":00"
            Dim Baches As Int16 = 0
            Dim TonHora As Single = 0
            Dim TiempoMuerto As Single = 0
            Dim CodTMuerto As Int16 = 0


            FechaB = Format(Now, "yyyy/MM/dd") + " " + Hora.ToString("00") + ":59"
            If CambioFecha Then
                FechaA = Format(DateAdd(DateInterval.Day, -1, Now), "yyyy/MM/dd") + " " + Hora.ToString("00") + ":00"
                FechaB = Format(DateAdd(DateInterval.Day, -1, Now), "yyyy/MM/dd") + " " + Hora.ToString("00") + ":59"
            Else
                FechaA = Format(Now.Date, "yyyy/MM/dd") + " " + Hora.ToString("00") + ":00"
            End If


            'Calculo de baches
            DVarios.Open("Select CONT from BACHES where BACHEAUTOMATICO=1 AND FECHA>='" + FechaA + "' and FECHA<='" + FechaB + "' and LINEAPRESENT='" + LineaPresent + "'")
            If DVarios.Count > 0 Then
                Baches = DVarios.Count
            End If
            'Calculo de toneladas
            DVarios.Open("Select sum(PESOREAL) as PESOREAL,sum(TmpoMto) as TIEMPOMUERTO from BACHES where BACHEAUTOMATICO=1 AND  FECHA>='" + FechaA + "' and FECHA<='" + FechaB + "' and LINEAPRESENT='" + LineaPresent + "'")
            If DVarios.Count And Not IsDBNull(DVarios.RecordSet("PESOREAL")) Then
                TonHora = Math.Round(DVarios.RecordSet("PESOREAL") / 1000, 1)
                TiempoMuerto = Math.Round(DVarios.RecordSet("TIEMPOMUERTO"), 2)
            End If

            'Revisión del código que mas tiempo muerto generó dentro de la hora
            DVarios.Open("Select top 1 * from TMUERTOS where CODMOTIVO>0 AND PROCESO='DOSIF' AND FECHA>='" + FechaA + "' and FECHA<='" + FechaB + "' ORDER BY TIEMPO DESC")
            If DVarios.Count Then
                CodTMuerto = DVarios.RecordSet("CODMOTIVO")
            End If

            DDatosHora.Open("Select * from DATOSHORA where PROCESO='DOSIFICACION' AND LINEA='" + LineaPresent + "' AND FECHA='" + FechaA + "' AND HORA=" + Hora.ToString)
            If DDatosHora.Count = 0 Then
                DDatosHora.AddNew()
                DDatosHora.RecordSet("HORA") = Hora
                DDatosHora.RecordSet("FECHA") = FechaIni
                DDatosHora.RecordSet("LINEA") = LineaPresent
                DDatosHora.RecordSet("PROCESO") = "DOSIFICACION"
                DDatosHora.RecordSet("BACHES") = Baches
                DDatosHora.RecordSet("TONHORA") = TonHora
                DDatosHora.RecordSet("TMPOMTO") = TiempoMuerto
                DDatosHora.RecordSet("CODTMUERTO") = CodTMuerto
                DDatosHora.Update()
            Else
                If Baches <> DDatosHora.RecordSet("BACHES") Or TonHora <> DDatosHora.RecordSet("TONHORA") Then
                    DDatosHora.RecordSet("BACHES") = Baches
                    DDatosHora.RecordSet("TONHORA") = TonHora
                    DDatosHora.RecordSet("TMPOMTO") = TiempoMuerto
                    DDatosHora.RecordSet("CODTMUERTO") = CodTMuerto
                    DDatosHora.Update()
                End If
            End If

        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub TimSeg_Tick(sender As Object, e As EventArgs) Handles TimSeg.Tick
        Try
            TSeg.Text = Val(TSeg.Text) + 1
            If Val(TSeg.Text) > 10000 Then TSeg.Text = 1

            If Val(TSeg.Text) Mod 50 = 0 Then
                BEmp_Click(Nothing, Nothing)
            End If

            If Val(TSeg.Text) Mod 180 = 0 Then
                BDosif_Click(Nothing, Nothing)
                BErrorTolvas_Click(Nothing, Nothing)
            End If

            'Actualizamos la fecha para que se muestren registros en la consulta CSCP_DATOSHORA (SigCoPro) de 24 horas antes
            If Val(TSeg.Text) Mod 3600 = 0 Or Now.Second Mod 30 = 0 Or TSeg.Text = 1 Then
                DVarios.Open("Select * from CONSULTAS")
                If DVarios.Count Then
                    If DVarios.RecordSet("T9") <> DateAdd(DateInterval.Hour, -5, Now).ToString("yyyy/MM/dd HH:00") Then
                        DVarios.RecordSet("T9") = DateAdd(DateInterval.Hour, -5, Now).ToString("yyyy/MM/dd HH:00")
                        DVarios.Update()
                    End If
                End If
            End If

            'Actualizamos la información de las tablas
            If Val(TSeg.Text) Mod 30 = 0 Then
                DDatosHora.Open("Select * from CSCP_DATOSHORA WHERE PROCESO='DOSIFICACION'")
                DGDosif.DataSource = DDatosHora.DataTable

                DDatosHora.Open("Select * from CSCP_DATOSHORA WHERE PROCESO='EMPAQUE' OR PROCESO='GRANEL'")
                DGEmp.DataSource = DDatosHora.DataTable

                DDatosHora.Open("Select * from CSCP_DATOSHORA WHERE PROCESO='ERRORTOLVAS'")
                DGErrTolvas.DataSource = DDatosHora.DataTable

                'Se actualiza la fecha de inicio de turno para visualizar consulta se fin planilla o sackoff
                For i = 1 To 3
                    If Now.Hour = Val(Turnos(i)) And ActualizaTurno(i) = False Then
                        DVarios.Open("Select * from CONSULTAS")
                        If DVarios.Count Then
                            If DVarios.RecordSet("FINITURNO") <> Now.ToString("yyyy/MM/dd") + " " + Turnos(i) Then
                                DVarios.RecordSet("FINITURNO") = Now.ToString("yyyy/MM/dd") + " " + Turnos(i)
                                ActualizaTurno(i) = True
                                DVarios.Update()
                            End If
                        End If
                    ElseIf Now.Hour <> Val(Turnos(i)) Then
                        ActualizaTurno(i) = False
                    End If
                Next

                'Actualizamos el campo inicio de hora

                If Now.Hour <> HoraAnt Then
                    DVarios.Open("Select * from CONSULTAS")
                    If Now.ToString("yyyy/MM/dd HH:00") <> DVarios.RecordSet("FINIHORA") Then
                        DVarios.RecordSet("FINIHORA") = Now.ToString("yyyy/MM/dd HH:00")
                        'Actualizamos el campo FIniProdProceso
                        DVarios.RecordSet("FINIPRODPROCESO") = DateAdd(DateInterval.Day, -10, Now).ToString("yyyy/MM/dd HH:00")
                        DVarios.Update()
                        HoraAnt = Now.Hour
                    End If
                End If
            End If

        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub BEmp_Click(sender As Object, e As EventArgs) Handles BEmp.Click
        Try
            Dim Hora As Int16 = Now.Hour
            'Datos empacadoras 
            DatosEmpacadoHoraHora(Hora)
            'Datos Granel
            DatosEmpacadoHoraHora(Hora, True)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub DatosEmpacadoHoraHora(ByVal Hora As Int16, Optional ByVal Granel As Boolean = False)
        Try

            Application.DoEvents()


            Dim FechaA As String
            Dim FechaB As String
            Dim FechaIni As String = CLeft(FechaC(), 10) + " " + Hora.ToString("00") + ":00"
            Dim Baches As Int16 = 0
            Dim TonHora As Single = 0
            Dim Maquina As Int16 = 0
            Dim Proceso As String = "EMPAQUE"


            FechaB = FechaC()
            FechaA = Format(Now.Date, "yyyy/MM/dd") + " " + Hora.ToString("00") + ":00"

            If Granel Then
                Proceso = "GRANEL"
                'Calculo EMPAQUE a GRANEL
                DVarios.Open("Select sum(PESO) as PESOREAL,min(maquina) as maquina from EMPAQUE where MAQUINA=10 and TIPO='GRANEL' AND FECHAINI>='" + FechaA + "' and FECHAINI<='" + FechaB + "' group by maquina")

            Else
                'Calculo de toneladas empacadas empacadoras automaticas
                DVarios.Open("Select sum(PESO) as PESOREAL,min(maquina) as maquina from EMPAQUE where MAQUINA<7 AND FECHAINI>='" + FechaA + "' and FECHAINI<='" + FechaB + "' group by maquina")
            End If


            For Each FEmp As DataRow In DVarios.Rows
                TonHora = 0
                If Not IsDBNull(FEmp("PESOREAL")) Then
                    TonHora = Math.Round(FEmp("PESOREAL") / 1000, 1)
                    Maquina = FEmp("MAQUINA")
                Else
                    Continue For
                End If

                DDatosHora.Open("Select * from DATOSHORA where PROCESO='" + Proceso + "' AND MAQUINA='" + Maquina.ToString + "' AND FECHA='" + FechaIni + "' AND HORA=" + Hora.ToString)
                If DDatosHora.Count = 0 Then
                    DDatosHora.AddNew()
                    DDatosHora.RecordSet("HORA") = Hora
                    DDatosHora.RecordSet("FECHA") = FechaIni
                    DDatosHora.RecordSet("PROCESO") = Proceso
                    DDatosHora.RecordSet("MAQUINA") = Maquina
                    DDatosHora.RecordSet("TONHORA") = TonHora
                    DDatosHora.Update()
                Else
                    If TonHora <> DDatosHora.RecordSet("TONHORA") Then
                        DDatosHora.RecordSet("TONHORA") = TonHora
                        DDatosHora.Update()
                    End If
                End If
            Next

        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub BErrorTolvas_Click(sender As Object, e As EventArgs) Handles BErrorTolvas.Click
        Try

            Application.DoEvents()

            Dim Hora As Int16 = Now.Hour
            Dim FechaA As String
            Dim FechaB As String
            Dim FechaIni As String = CLeft(FechaC(), 10) + " " + Hora.ToString("00") + ":00"
            Dim NumPesajes As Int32 = 0
            Dim NumPesajesError As Int32 = 0
            Dim PorcError As Single = 0

            FechaB = FechaC()
            FechaA = Format(Now.Date, "yyyy/MM/dd") + " " + Hora.ToString("00") + ":00"

            '
            'Calculo de número de pesajes por tolvas
            DVarios.Open("SELECT        (dbo.Consumos.PesoReal - dbo.Consumos.PesoMeta) * 100 / dbo.Consumos.PesoMeta AS Error, dbo.Consumos.Tolva as tolva " +
                            " FROM  dbo.Consumos INNER JOIN dbo.Tolvas ON dbo.Consumos.Tolva = dbo.Tolvas.Tolva  WHERE  (dbo.Consumos.Fecha>='" + FechaA + "') " +
                            " And (dbo.Consumos.Fecha<='" + FechaB + "') AND (dbo.Consumos.TipoMat = 1) " +
                            " and  (dbo.Consumos.PesoMeta > 0)  AND (dbo.Tolvas.EsTolvaLiquidos = 0) AND (dbo.Tolvas.Proceso = N'DOSIFICACION')")
            If DVarios.Count Then NumPesajes = DVarios.Count

            'Calculo de número de pesajes por tolva con error
            DVarios.Open("SELECT        (dbo.Consumos.PesoReal - dbo.Consumos.PesoMeta) * 100 / dbo.Consumos.PesoMeta AS Error, dbo.Consumos.Tolva as tolva " +
                            "FROM  dbo.Consumos INNER JOIN dbo.Tolvas ON dbo.Consumos.Tolva = dbo.Tolvas.Tolva  WHERE  (dbo.Consumos.Fecha>='" + FechaA + "') AND (dbo.Consumos.Fecha<='" + FechaB + "') AND (dbo.Consumos.TipoMat = 1) " +
                            " and  (dbo.Consumos.PesoMeta > 0) AND (dbo.Tolvas.EsTolvaLiquidos = 0) AND (dbo.Tolvas.Proceso = N'DOSIFICACION') " +
                            " and abs((dbo.Consumos.PesoReal - dbo.Consumos.PesoMeta) * 100 / dbo.Consumos.PesoMeta)>=2")
            If DVarios.Count Then NumPesajesError = DVarios.Count

            'Calculo porcentaje de pesajes con error

            If NumPesajes > 0 Then
                PorcError = (NumPesajesError / NumPesajes) * 100
            End If

            'If PorcError > 0 Then
            DDatosHora.Open("Select * from DATOSHORA where PROCESO='ERRORTOLVAS' AND FECHA='" + FechaIni + "' AND HORA=" + Hora.ToString)
            If DDatosHora.Count = 0 Then
                DDatosHora.AddNew()
                DDatosHora.RecordSet("HORA") = Hora
                DDatosHora.RecordSet("FECHA") = FechaIni
                DDatosHora.RecordSet("PROCESO") = "ERRORTOLVAS"
                DDatosHora.RecordSet("PORC") = PorcError
                DDatosHora.RecordSet("NUMPESAJES") = NumPesajes
                DDatosHora.RecordSet("NUMPESAJESERROR") = NumPesajesError
                DDatosHora.Update()
            Else
                If NumPesajes <> DDatosHora.RecordSet("NUMPESAJES") Then
                    DDatosHora.RecordSet("PORC") = PorcError
                    DDatosHora.RecordSet("NUMPESAJES") = NumPesajes
                    DDatosHora.RecordSet("NUMPESAJESERROR") = NumPesajesError
                    DDatosHora.Update()
                End If
            End If
            'End If
        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub BSalir_Click(sender As Object, e As EventArgs) Handles BSalir.Click
        Me.Hide()
    End Sub
End Class