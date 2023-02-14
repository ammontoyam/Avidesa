Option Explicit On

Imports System.Windows.Forms
Imports System.IO
Imports System.Data.Common
Imports System.Data
Imports ClassLibrary

Public Class ImportFor

    Private DFor As AdoSQL
    Private DDatosFor As AdoSQL
    Private DArt As AdoSQL
    Private DTolvas As AdoSQL
    Private DVarios As AdoSQL
    Private DBaches As AdoSQL
    Private DEquivFormProd As AdoSQL


    Private Filas() As String, Campos() As String


    Private RutaArchivo As String = vbNullString
    Private Renglon, CodFormula, NomFormula, Lp, FechaFor, TolSup, TolInf,
        CodMat, PesoMeta, Bascula, CodMatB, NomMat, Especie, Grupo, Cantidad, Fecha, TipoMat, A, CodForB, TiempoMSeca, TiempoMHumeda As String
    Private CodEstablecimiento As String
    Private TiempoMSecaDef As String
    Private TiempoMHumedaDef As String
    Private DR As DataRow
    Private DFila() As DataRow 
    Private LEnc As StreamReader
    Private Contenido As String
    Private Posi As Int64 = 0, Posi2 As Int64 = 0
    Private CodFylax As String
    Private CodPaquetePrem As Boolean
    Private ManejaPx As Boolean

    Private SpHumedad As Single
    Private HabCorreccionHum As Int16
    Private NumReceta As Int16
    Private TipoAlimento As Int16
    Private PorcAgua As Single



    Private Sub BBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BBuscar.Click
        Try

            If TRuta.Text = "" Then
                OpenFile.InitialDirectory = "C:\"
            Else
                OpenFile.InitialDirectory = CLeft(TRuta.Text, InStrRev(TRuta.Text, "\"))
            End If

            OpenFile.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*"
            OpenFile.FilterIndex = 0
            OpenFile.RestoreDirectory = True

            If (OpenFile.ShowDialog() = DialogResult.OK) Then
                TRuta.Text = OpenFile.FileName
                BTraerFor_Click(0, Nothing)
            End If

        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub BTraerFor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTraerFor.Click
        Try
            Dim CodForAux As String = ""
            Dim PrefijoPlanta As String = ""

            If TRuta.Text.Trim = vbNullString Then
                MessageBox.Show("Debe seleccionar primero el archivo donde se encuentran las fórmulas", "ChronoSoft", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If

            DGFor.Rows.Clear()
            If File.Exists(RutaArchivo = Ruta + "form.txt") Then File.Delete(RutaArchivo = Ruta + "form.txt")
            RutaArchivo = Ruta + "form.txt"
            FileCopy(TRuta.Text.Trim, RutaArchivo)
            LEnc = File.OpenText(RutaArchivo)
            Contenido = LEnc.ReadToEnd
            LEnc.Close()


            Posi = 0

            Do
                'Se busca codigo del estableciemiento
                Posi = Contenido.IndexOf(Chr(124) + "04" + Chr(124), Convert.ToInt32(Posi) + 1)
                If Posi > 0 Then
                    Posi2 = Contenido.IndexOf(Chr(13) + Chr(10), Convert.ToInt32(Posi) + 1)
                    CodEstablecimiento = Eval(Mid(Contenido, Posi + 5, Posi2 - Posi - 4))
                Else
                    Exit Do
                End If

                'Se busca el prefijo planta
                Posi = Contenido.IndexOf(Chr(124) + "05" + Chr(124), Convert.ToInt32(Posi) + 1)
                If Posi > 0 Then PrefijoPlanta = Replace(Contenido.Substring(Posi + 4, 3), vbCr, "")

                Posi = Contenido.IndexOf(Chr(124) + "06" + Chr(124), Convert.ToInt32(Posi) + 1)
                If Posi > 0 Then

                    Renglon = Contenido.Substring(Convert.ToInt32(Posi) + 4, Contenido.IndexOf(vbNewLine, Convert.ToInt32(Posi) + 4) - Posi - 4)
                    Posi = Contenido.IndexOf(Chr(124) + "07" + Chr(124), Convert.ToInt32(Posi) + 1)
                    If Posi > 0 Then

                        CodFormula = Renglon.Trim
                        'If Funcion_ManejaEstablecimiento And InStr(CodFormula, CodEstablecimiento) = 0 Then CodFormula = CodEstablecimiento + Renglon.Trim
                        If Funcion_ManejaEstablecimiento Then
                            CodFormula = CodEstablecimiento + Renglon.Trim
                            'Se hace esto xq hay archivos que ya traen el codestablecimiento en el codigo de la formula
                            If CodFormula.Length > 7 Then CodFormula = Renglon.Trim
                        End If

                        Posi2 = Contenido.IndexOf(vbNewLine, Convert.ToInt32(Posi) + 1)
                        Renglon = Contenido.Substring(Posi + 4, Posi2 - Posi - 4)
                        NomFormula = Trim(Renglon)
                        If Funcion_FuncionesPlantaPremezclas Then NomFormula = PrefijoPlanta + " " + Trim(Renglon)
                        Posi = Contenido.IndexOf(Chr(124) + "11" + Chr(124), Convert.ToInt32(Posi) + 1)
                            If Posi > 0 Then
                                Renglon = Contenido.Substring(Posi + 4, 10)
                                FechaFor = Trim(Renglon)
                                Posi = Contenido.IndexOf(Chr(124) + "13" + Chr(124), Convert.ToInt32(Posi) + 1)
                                If Posi > 0 Then
                                    Posi2 = Contenido.IndexOf(vbNewLine, Convert.ToInt32(Posi) + 1)
                                    Renglon = Contenido.Substring(Posi + 4, Posi2 - Posi - 4)
                                    Lp = Eval(Renglon)
                                    DGFor.Rows.Add()
                                    DGFor.Rows(DGFor.Rows.Count - 1).Cells("CodFor").Value = CodFormula
                                    DGFor.Rows(DGFor.Rows.Count - 1).Cells("NomFor").Value = NomFormula
                                    DGFor.Rows(DGFor.Rows.Count - 1).Cells("Version").Value = Lp
                                    DGFor.Rows(DGFor.Rows.Count - 1).Cells("Establecimiento").Value = CodEstablecimiento
                                End If
                            End If
                        End If
                    End If
            Loop While Posi > 0

            If DGFor.RowCount > 0 Then TMensaje.Text = "El Archivo Contiene " + DGFor.RowCount.ToString + " Fórmulas "

        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub BSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BSalir.Click, mnSalir.Click
        Try
            DGFor.Rows.Clear()
            Me.Hide()
        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub BImportar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BImportar.Click
        Try

            Dim CodForSinEstb As String = ""
            Dim Paso As Integer = 1
            If DGFor.RowCount = 0 Then Exit Sub
            Dim NumIngred As Integer = 0
            Dim CodPrem As String = ""
            Dim HumedadFor As Double = 0
            Dim MezcExt As Boolean = False
            Dim GrasaFor As Single = 0
            Dim TamBache As Single = 0
            Dim PorcAdicFilax As Single = 0
            Dim PosNomMat As Short

            PosNomMat = Contenido.IndexOf(Chr(124) + "LIBMP", Convert.ToInt32(Posi) + 1) - Contenido.IndexOf(Chr(124) + "27" + Chr(124), Convert.ToInt32(Posi) + 1) + 1

            Posi = 0

            For j As Integer = DGFor.SelectedRows.Count - 1 To 0 Step -1

                CodFormula = DGFor.SelectedRows(j).Cells("CodFor").Value.ToString
                NomFormula = DGFor.SelectedRows(j).Cells("NomFor").Value.ToString
                Lp = DGFor.SelectedRows(j).Cells("Version").Value.ToString
                CodEstablecimiento = DGFor.SelectedRows(j).Cells("Establecimiento").Value.ToString

                If Planta.Contains("GIRARDOTA PREMEZCLAS") And CodFormula.Length >= 6 Then
                    CodForSinEstb = Val(CRight(CodFormula, CodFormula.Length - CodEstablecimiento.Length))
                Else
                    CodForSinEstb = Val(CodFormula)
                End If

                'Validaciones para dejar importar la formula

                'Se revisa si ya hay premezclas exportadas con esta formula, si es asi no se deja importar
                DVarios.Open("select * from CONSUMOSMED WHERE ESTADO<10 and CODFOR='" + CodFormula + "' AND LP='" + Lp + "'")

                If DVarios.Count Then
                    Resp = MsgBox("No debe alterar ni agregar códigos de materia prima a esta fórmula " +
                                " debido a que la premezcla ya fue procesada por el departamento de costos", MsgBoxStyle.Critical)
                    Return
                End If


                'Revisa que los ultimos baches no sean de la fórmula a editar
                DBaches.Open("select TOP 5 * from BACHES WHERE ESTADO=0 and LINEAINVENT<>'SALES' AND ESTADO<10 ORDER by FECHA desc")

                For Each RSBaches As DataRow In DBaches.Rows
                    If (RSBaches("CODFOR") = CodForSinEstb AndAlso RSBaches("LP") = Lp) Then
                        Resp = MsgBox("No debe alterar ni agregar códigos de materia prima a esta fórmula ya que se " +
                            " encuentra en proceso de dosificación y alteraría los Reportes", MsgBoxStyle.Critical)
                        MsgBox("Fórmula: " + CodForSinEstb + " Nombre: " + NomFormula + " No.Orden: " + Lp)
                        Continue For
                    End If
                Next



                'Se ubica en el codigo de la formula del archivo plano
                Posi = Contenido.IndexOf(Chr(124) + "06" + Chr(124) + CodFormula, Convert.ToInt32(Posi) + 1)
                If Posi < 126 Then
                    MessageBox.Show(DevuelveEvento(CodEvento.SISTEMA_ERROR) + "Error en Archivo " + NomFormula, "Error en Archivo", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Exit Sub
                End If

                'Se ubica en la FECHA de la formula del archivo plano
                Posi = Contenido.IndexOf(Chr(124) + "11" + Chr(124), Convert.ToInt32(Posi) + 1)
                If Posi <= 0 Then
                    MessageBox.Show(DevuelveEvento(CodEvento.SISTEMA_ERROR) + "Error en Archivo " + NomFormula, "Error en Archivo", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Exit Sub
                End If
                FechaFor = Contenido.Substring(Posi + 4, 10)

                'Se ubica en el tamaño del bache 
                Posi = Contenido.IndexOf(Chr(124) + "31" + Chr(124), Convert.ToInt32(Posi) + 1)
                If Posi <= 0 Then
                    MessageBox.Show("Error en el archivo de la fórmula " + NomFormula, "Error en Archivo", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Exit Sub
                End If

                TamBache = Val(Contenido.Substring(Posi + 4, 4))

                'Se ubica en el numero de ingredientes de la formula en el archivo plano
                Posi = Contenido.IndexOf(Chr(124) + "14" + Chr(124), Convert.ToInt32(Posi) + 1)
                If Posi <= 0 Then
                    MessageBox.Show(DevuelveEvento(CodEvento.SISTEMA_ERROR) + "Error en Archivo " + NomFormula, "Error en Archivo", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Exit Sub
                End If

                NumIngred = Eval(Contenido.Substring(Posi + 4, 3))



                'Formula Nueva

                If Lp = "-" Then
                    If InputBox.InputBox("Importar Fórmula", "Ingrese la versión de la fórmula seleccionada", RespInput) = DialogResult.Cancel Then
                        Continue For
                    End If
                    Lp = RespInput
                End If

                'El código de fórmula en el archivo plano viene con el codigo de establecimiento (solo planta de premezclas girardota)
                'En ChronoSoft debe guardarse sin el código de establecimiento
                If Planta.Contains("GIRARDOTA PREMEZCLAS") And CodFormula.Length >= 6 Then
                    CodFormula = CRight(CodFormula, CodFormula.Length - CodEstablecimiento.Length)
                End If
                'En todas las plantas menos en premezclas se maneja el valor numerico del codigo de formula
                If Not Funcion_FuncionesPlantaPremezclas Then CodFormula = Eval(CodFormula).ToString

                If Funcion_ManejaTablaProcDosif Then
                    'Si se está produciendo una formula en cualquier bascula de la tabla ProcesoDosif
                    DVarios.Open("select * from PROCDOSIF WHERE CODFOR='" + CodFormula + "' AND LP='" + Lp + "'")
                    If DVarios.Count Then
                        Resp = MsgBox("No debe alterar ni agregar códigos de materia prima a esta fórmula ya que se " +
                            " encuentra en proceso de dosificación y alteraría los Reportes", MsgBoxStyle.Critical)
                        MsgBox("Fórmula: " + CodFormula + " Nombre: " + NomFormula + " No.Orden: " + Lp)
                        Continue For
                    End If
                End If



                Especie = 0
                Grupo = 0
                'Por Defecto estos valores
                TiempoMSeca = TiempoMSecaDef
                TiempoMHumeda = TiempoMHumedaDef


                If Planta.Contains("Palermo") Then
                    'Aplica solo para planta palermo porque se comunica con un PLC
                    If Val(CodFormula) > 9999 Then            'Limitación por el PLC de Palermo
                        CodFormula = ""
                        If InputBox.InputBox("Importar Fórmula", "Ingrese el Código Interno de la fórmula seleccionada", CodFormula) = DialogResult.Cancel Then
                            Continue For
                        End If
                        CodFormula = Val(CodFormula).ToString
                    End If
                End If



                'Recuperamos el codigo de la premezcla para una formula con el mismo codigo interno

                'Se revisa si la fórmula existe, por cambio de establecimiento, se sebe tambien hacer otra consulta para revisar 
                'si esa formula existe sin establecimiento

                DVarios.Open("Select * from FORMULAS where CODFOR='" + CodFormula + "' and CODESTABLECIMIENTO='" + CodEstablecimiento + "'")

                If DVarios.Count = 0 Then
                    DVarios.Open("Select * from FORMULAS where Substring(CODFOR," + (CodEstablecimiento.Length + 1).ToString + ",10)='" + CodFormula + "'")
                End If

                CodPrem = "0"
                CodForB = ""
                Especie = "0"
                Grupo = "0"
                ManejaPx = False

                'Valores por defecto para los parametros del fylax
                TipoAlimento = 1
                HabCorreccionHum = 1
                NumReceta = 2
                SpHumedad = 12.5

                If DVarios.Count > 0 Then
                    Especie = DVarios.RecordSet("CODESPECIE")
                    Grupo = DVarios.RecordSet("CODGRPFOR")
                    CodPrem = DVarios.RecordSet("CODPREMEZCLA")
                    CodForB = DVarios.RecordSet("CODFORB")
                    TiempoMSeca = DVarios.RecordSet("TMSECA")
                    TiempoMHumeda = DVarios.RecordSet("TMHUMEDA")
                    MezcExt = DVarios.RecordSet("MEZCEXT")
                    ManejaPx = DVarios.RecordSet("MANEJAPX")

                    If Funcion_ManejaFylax Then
                        TipoAlimento = DVarios.RecordSet("TIPOALIMENTO")
                        HabCorreccionHum = DVarios.RecordSet("HABCORRHUM")
                        NumReceta = DVarios.RecordSet("NUMRECETA")
                        SpHumedad = DVarios.RecordSet("SPHUMEDAD")
                        PorcAgua = DVarios.RecordSet("PORCADICAGUA")
                    End If

                End If

                DFor.Open("select * from FORMULAS where CODFOR='" + CodFormula.Trim + "' and LP='" + Lp + "'")


                If DFor.Count > 0 Then
                    Resp = MessageBox.Show(" La Fórmula " + CodFormula.Trim + " " + NomFormula.ToString + " ya existe, desea reemplazarla ", "ChronoSoft Net", MessageBoxButtons.YesNo, MessageBoxIcon.Information)
                    If Resp = vbNo Then
                        Continue For
                    End If
                    DFor.Delete("select * from FORMULAS where CODFOR='" + CodFormula.Trim + "' and LP='" + Lp + "'", Me)
                    DDatosFor.Delete("delete from DATOSFOR where CODFOR='" + CodFormula.Trim + "' and LP='" + Lp + "'", Me)
                End If

                RespInput = ""

                If Funcion_FuncionesPlantaPremezclas Then
                    If CodForB = "" Then
                        'Se busca el codigo de premezcla en la tabla de equivalencias
                        'DEquivFormProd.Open("Select * from EQUIVFORMPROD where CODFOR='" + CodFormula + "'")
                        'If DEquivFormProd.Count Then
                        '    CodPrem = DEquivFormProd.RecordSet("CODPREM")
                        'Else
                        '    Resp = MsgBox("No se encontró el código de la premezcla para esta fórmula, debe crearlo para poder continuar", vbYesNo + vbInformation)
                        '    If Resp = vbNo Then Continue For
                        '    EquivFormProd.EquivFormProd_Load(Nothing, Nothing)
                        '    EquivFormProd.BNuevo_Click(Nothing, Nothing)
                        '    EquivFormProd.TCodFor.Text = CodFormula
                        '    EquivFormProd.TNomFor.Text = CLeft(NomFormula.ToUpper, 30)
                        '    EquivFormProd.ShowDialog()

                        '    DEquivFormProd.Open("Select * from EQUIVCODPREM where CODFOR='" + CodFormula + "'")
                        '    If DEquivFormProd.Count Then
                        '        CodPrem = DEquivFormProd.RecordSet("CODPROD")
                        '    End If
                        'End If

                        If InputBox.InputBox("Importar Fórmula", "Ingrese el Código Externo de la fórmula seleccionada", RespInput) = DialogResult.Cancel Then
                            Continue For
                        End If
                        CodForB = RespInput
                    End If
                Else
                    If Funcion_PreguntaPorCodForB Then
                        If InputBox.InputBox("Importar Fórmula", "Ingrese el Código Externo de la fórmula seleccionada", RespInput) = DialogResult.Cancel Then
                            Continue For
                        End If
                        CodForB = RespInput
                    Else
                        'Se revisa que valor se almacena en el CodForB de la fórmula
                        Select Case ConfigParametros("ImportForCodForB")
                            Case "Establecimiento"   'Plantas Girardota, Girardota Premezclas, Yarumal, Santa Rosa
                                CodForB = CodEstablecimiento
                            Case "LP" 'Funza, Cota
                                CodForB = Lp
                            Case "CodFor" 'Plantas Barranquilla
                                CodForB = CodFormula
                        End Select
                    End If
                End If

                RespInput = ""

                DFor.AddNew()

                DFor.RecordSet("CODFORB") = CodForB
                DFor.RecordSet("NOMFOR") = CLeft(NomFormula.ToUpper, 30)
                DFor.RecordSet("CODFOR") = CodFormula
                DFor.RecordSet("TMSECA") = TiempoMSeca
                DFor.RecordSet("TMHUMEDA") = TiempoMHumeda
                DFor.RecordSet("CODESPECIE") = Especie
                DFor.RecordSet("CODGRPFOR") = Grupo
                DFor.RecordSet("LP") = Lp
                DFor.RecordSet("FECHAFOR") = FechaFor
                DFor.RecordSet("FECHAIMPFOR") = FechaC()
                DFor.RecordSet("CODPREMEZCLA") = CodPrem
                DFor.RecordSet("MEZCEXT") = MezcExt
                DFor.RecordSet("USUARIOIMPFOR") = CLeft(UsuarioPrincipal, 20)
                DFor.RecordSet("MANEJAPX") = ManejaPx
                DFor.RecordSet("CODESTABLECIMIENTO") = CodEstablecimiento
                DFor.RecordSet("TOTALFOR") = TamBache

                If Funcion_ManejaFylax Then
                    DFor.RecordSet("TIPOALIMENTO") = TipoAlimento
                    DFor.RecordSet("HABCORRHUM") = HabCorreccionHum
                    DFor.RecordSet("NUMRECETA") = NumReceta
                    DFor.RecordSet("SPHUMEDAD") = SpHumedad
                    DFor.RecordSet("PORCADICAGUA") = PorcAgua
                End If

                DFor.Update(Me)

                If Funcion_AprobarFormulaImportada Then
                    'Quitamos el aprobado a todas las formulas del mismo código menos a la versión que acabamos 
                    'de importar
                    DVarios.Open("Update FORMULAS set ESTADO='-' where CODESTABLECIMIENTO='" + CodEstablecimiento + "' and CODFOR='" + CodFormula + "' AND LP<>'" + Lp + "'")
                End If

                Paso = 1

                '---------------------------------------------LLENA LA TABLA DATOSFOR------------------------------------------------------------------------------------------

                For i As Integer = 1 To NumIngred

                    CodPaquetePrem = False

                    Posi = Contenido.IndexOf(Chr(124) + "15" + Chr(124), Convert.ToInt32(Posi) + 1)
                    If Posi = 0 Then
                        MessageBox.Show(DevuelveEvento(CodEvento.SISTEMA_ERROR) + "Error en Archivo " + NomFormula, "Error en Archivo", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Exit Sub
                    End If

                    Posi2 = Contenido.IndexOf(vbCrLf, Convert.ToInt32(Posi))
                    If Posi2 = 0 Then
                        MessageBox.Show(DevuelveEvento(CodEvento.SISTEMA_ERROR) + "Error en Archivo " + NomFormula, "Error en Archivo", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Exit Sub
                    End If
                    Renglon = Contenido.Substring(Posi, Posi2 - Posi)
                    Posi2 = Renglon.IndexOf(Chr(124), 3)
                    CodMat = Eval(Renglon.Substring(Posi2 + 1, 8))
                    NomMat = Renglon.Substring(PosNomMat, 30).Trim
                    Posi2 = Renglon.IndexOf(NomMat)
                    If NomMat.IndexOf("-PREM-", 1) > 0 Then
                        PesoMeta = Eval(Renglon.Substring(Renglon.IndexOf(Chr(124), Convert.ToInt32(Posi2) + NomMat.Length) + 1, 6))
                        If Funcion_ArchivoTraePaquetePrem Then
                            'Si viene así es porque es el material es el paquete de premezcla , entonces se cambia el codigo de la materia prima por el codpremezcla
                            CodPaquetePrem = True
                            CodMat = CodPrem
                            If CodMat = "0" Then Continue For
                        End If
                    Else
                        PesoMeta = Eval(Renglon.Substring(Renglon.IndexOf(Chr(124), Convert.ToInt32(Posi2) + NomMat.Length) + 1, 8))
                    End If

                    DArt.Open("select * from ARTICULOS where CODINT='" + CodMat + "'")
                    CodMatB = CodMat
                    TolSup = 0
                    TolInf = 0
                    If DArt.Count > 0 Then
                        CodMatB = DArt.RecordSet("CODEXT")
                        NomMat = DArt.RecordSet("NOMBRE")
                        TipoMat = DArt.RecordSet("TIPOMAT")
                        Bascula = DArt.RecordSet("BASCULA")
                        A = DArt.RecordSet("A")
                        TolSup = DArt.RecordSet("TOLMAXKG")
                        TolInf = DArt.RecordSet("TOLMINKG")
                    Else
                        DArt.AddNew()
                        DArt.RecordSet("CodInt") = CodMat
                        DArt.RecordSet("CodExt") = CodMat
                        DArt.RecordSet("NOMBRE") = CLeft(NomMat, 30)
                        DArt.RecordSet("TOLMINKG") = 0
                        DArt.RecordSet("TOLINFPORC") = 0
                        DArt.RecordSet("TOLMAXKG") = 0
                        DArt.RecordSet("TOLSUPPORC") = 0
                        DArt.RecordSet("CODGRPMAT") = 0
                        DArt.RecordSet("TIPO") = "MP"
                        DArt.RecordSet("BASCULA") = 0
                        DArt.RecordSet("TIPOMAT") = 0
                        DArt.RecordSet("A") = "-"
                        DArt.Update(Me)

                        CodMatB = CodMat
                        TipoMat = 0
                        Bascula = 0
                        A = "-"

                    End If

                    'Si se maneja filax se calcula el porcentaje de filax para guardarlo en la formula
                    If Funcion_ManejaFylax Then
                        If Val(CodMat) = CodFylax Then
                            'Se calcula el porcentaje de filax para guardarlo en la formula
                            PorcAdicFilax = (PesoMeta / TamBache) * 100
                        End If
                    End If


                    DDatosFor.AddNew()

                    DDatosFor.RecordSet("CodFor") = CodFormula
                    DDatosFor.RecordSet("CodForB") = CLeft(CodForB, 15)
                    DDatosFor.RecordSet("CodMatB") = CodMatB.Trim
                    DDatosFor.RecordSet("CodMat") = CodMat.Trim
                    DDatosFor.RecordSet("NomMat") = CLeft(NomMat, 30)
                    DDatosFor.RecordSet("PESOMETA") = Eval(PesoMeta)
                    DDatosFor.RecordSet("PESOMETAB") = Eval(PesoMeta)
                    DDatosFor.RecordSet("Paso") = Paso
                    DDatosFor.RecordSet("LP") = Lp
                    DDatosFor.RecordSet("TIPOMAT") = TipoMat
                    DDatosFor.RecordSet("BASCULA") = Bascula
                    DDatosFor.RecordSet("A") = A
                    DDatosFor.RecordSet("TOLSUP") = Eval(TolSup)
                    DDatosFor.RecordSet("TOLINF") = Eval(TolInf)

                    If Funcion_ArchivoTraePaquetePrem Then
                        'Si se va a adicionar la premezcla, se cambia el tipomat para que ChronoSoft lo reporte automaticamente, ya no se manejaria paquetde tradicional de premezclas
                        If CodPaquetePrem Then
                            DDatosFor.RecordSet("A") = "PR"
                            DDatosFor.RecordSet("TIPOMAT") = 7
                        End If
                    End If


                    'Buscamos el material en la matriz de tolvas para actualizarle la tolva

                    DTolvas.Refresh()
                    DTolvas.Find("CODINT='" + CodMat + "'")
                    If Not DTolvas.EOF Then
                        DDatosFor.RecordSet("TOLVA") = DTolvas.RecordSet("TOLVA")
                        DDatosFor.RecordSet("BASCULA") = DTolvas.RecordSet("BASCULA")
                    End If

                    If Funcion_FuncionesPlantaPremezclas Then
                        If TamBache > 0 Then
                            DDatosFor.RecordSet("PESOMETAB") = PesoMeta / TamBache * 100
                        End If
                    End If

                    DDatosFor.Update(Me)

                    'Se actualiza el porcentaje de cada ingrediente de la formula en el campo pesometab



                    Paso += 1

                Next

                'Se ubica en el item humedad  de la formula del archivo plano

                If Funcion_HumedadFormulada Then
                    Posi = Contenido.IndexOf(Chr(124) + "17" + Chr(124) + "0002", Convert.ToInt32(Posi) + 1)
                    If Posi <= 0 Then
                        MessageBox.Show(DevuelveEvento(CodEvento.SISTEMA_ERROR) + " Campo humedad no encontrado " + NomFormula, "Error en Archivo", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Continue For
                    End If
                    HumedadFor = Val(Contenido.Substring(Posi + 64, 7))

                    DFor.Open("Select * from FORMULAS WHERE CODFOR='" + CodFormula + "' AND LP='" + Lp + "'")
                    If DFor.Count Then
                        DFor.RecordSet("HUMEDADFOR") = HumedadFor
                        'DFor.RecordSet("GrasaFor") = GrasaFor
                        If Funcion_ManejaFylax Then
                            DFor.RecordSet("PORCADICFILAX") = PorcAdicFilax
                            'DFor.RecordSet("SPHUMEDAD") = HumedadFor
                        End If
                        DFor.Update(Me)
                    End If
                End If

            Next

            MessageBox.Show(DevuelveEvento(CodEvento.SISTEMA_PROCESOFINALIZADO), "Importación de Fórmulas ChronoSoft", MessageBoxButtons.OK, MessageBoxIcon.Information)

            Formulacion.BActualizar_Click(Nothing, Nothing)
            Formulacion.BBuscaForm_Click(Nothing, Nothing, CodFormula, Lp)

        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub ImportFor_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            DFor = New AdoSQL("Formulas")
            DDatosFor = New AdoSQL("DatosFor")
            DArt = New AdoSQL("Materiales")
            DTolvas = New AdoSQL("TOLVAS")
            DVarios = New AdoSQL("VARIOS")
            DBaches = New AdoSQL("BACHES")
            DEquivFormProd = New AdoSQL("EQUIVFORMPROD")

            DArt.Open("select * from ARTICULOS where TIPO='MP' order by CODINT")
            DFor.Open("Select * from FORMULAS where CODFOR='0'")
            DDatosFor.Open("Select * from DATOSFOR where CODFOR='0'")
            DTolvas.Open("Select * from TOLVAS")

            'Traemos los tiempos de mezcla por defecto configurados en la base de datos
            TiempoMSecaDef = ConfigParametros("TiempoMezclaSeca")
            TiempoMHumedaDef = ConfigParametros("TiempoMezclaHumeda")

            'Si hay dosificacion de Fylax en la planta, se trae el codigo del Fylax

            If Funcion_ManejaFylax Then CodFylax = ConfigParametros("CodigoFylax")


            'A partir del 8 de junio de 2021 por cambio en códigos de establecimiento, todas las plantas no van a anteponer el
            'codestablecimiento al principio de la fórmula, para evitar que vuelva a pasar que por cambio de codestablecimiento la
            'formula sea nueva en el sistema.
            If Funcion_ManejaEstablecimiento Then
                DVarios.Open("Update CONFIGFUNCIONALIDADES SET ACTIVA=0 where FUNCION='Maneja.Establecimiento'")
                Funcion_ManejaEstablecimiento = False
            End If
            'Volvemos a cargar la funcionalidad


        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub


End Class