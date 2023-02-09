Option Explicit On
Imports System.Data
Imports System.Data.Common
Imports System.IO

Public Class Alarmas

    Private DAlarmas As AdoNet
    Private Cont As Long

    Private Sub Alarmas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            If Process.GetProcessesByName(Process.GetCurrentProcess.ProcessName).Length > 1 Then
                End
            End If
            Ruta = Application.StartupPath
            If Ruta.Last.ToString <> "\" Then Ruta = Ruta + "\"

            If InStr(Ruta, "Fuentes") > 0 Then
                Ruta = Ruta.Substring(0, InStr(Ruta, "Fuentes") - 1)
                Fuentes = True
            End If

            If File.Exists(Ruta + "a") = True Then
                Evento(" Se cierra ChronoSoft por archivo a " + Me.Name)
                End
            End If


            If File.Exists(Ruta + "Ruta.txt") = False Then
                MsgBox("No existe el archivo ruta el cual contiene el nombre del Motor de Base de Datos", MsgBoxStyle.Information)
                End
            Else
                Dim rd As StreamReader = New StreamReader(Ruta + "\Ruta.txt", True)
                ServidorSQL = rd.ReadLine.Trim
                NomDB = "CHRITAP1GIR"
                UserDB = "Admin"
                PWD = "NEP"
                rd.Close()
            End If




            RutaRep = Ruta + "DB\"
            Planta = "AGRINSA"


            RutaDB = "Data Source=" + ServidorSQL + "; Initial Catalog=" + NomDB + "; User Id=" + UserDB + "; Password=" + PWD
            DbProvedor = DbProviderFactories.GetFactory("System.Data.SqlClient")


            'Toma los parametros del Provedor segun el caso
            CONN = DbProvedor.CreateConnection
            CONN.ConnectionString = RutaDB

            NombrePC = My.Computer.Name
            DAlarmas = New AdoNet("Alarmas", CONN, DbProvedor)

            DAlarmas.Delete("delete from ALARMAS where FECHA<'" + Format(DateAdd("d", -2, Now), "yyyy/MM/dd HH:mm:ss") + "'")

            DAlarmas.Open("select * from ALARMAS order by ID desc")
            If DAlarmas.RecordCount = 0 Then End

            AsignaDataGrid(DGAlarmas, DAlarmas.DataTable)
            DGAlarmas_CellClick(Nothing, Nothing)


        Catch ex As Exception
            MsgError(ex.ToString)
        End Try
    End Sub

    Private Sub DGAlarmas_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGAlarmas.CellClick
        Try
            If DGAlarmas.RowCount = 0 Then Return

            TMensaje.Text = DGAlarmas.Rows(DGAlarmas.CurrentRow.Index).Cells("ALARMA").Value.ToString.Trim

        Catch ex As Exception
            MsgError(ex.ToString)
        End Try
    End Sub

    Private Sub BReconoceAlarm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BReconoceAlarm.Click
        Try
            Dim Id As String = DGAlarmas.Rows(DGAlarmas.CurrentRow.Index).Cells("ID").Value.ToString.Trim

            DAlarmas.Delete("delete from ALARMAS where ID=" + Id)

            Alarmas_Load(Nothing, Nothing)

        Catch ex As Exception
            MsgError(ex.ToString)
        End Try
    End Sub

    Private Sub TimUnload_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TimUnload.Tick
        Try
            Cont += 1
            If TMensaje.Text.Length > 1 Then
                If Cont Mod 2 = 0 Then
                    TMensaje.BackColor = Color.OrangeRed
                Else
                    TMensaje.BackColor = Color.Yellow
                End If
            End If

            If Cont = 30 Then End

        Catch ex As Exception
            MsgError(ex.ToString)
        End Try
    End Sub
End Class
