Option Explicit On

Imports System.Windows.Forms
Imports System.Data.Common
Imports System.Data
Imports System.IO
Imports ClassLibrary


Public Class DatosMuestras


    Dim DCortesMP As AdoSQL
    Dim DDatosMuestras As AdoSQL
    Dim DOPs As AdoSQL
    Dim ArchivoDatos As StreamReader
    Dim Contenido As String
    Dim CadenaContenido() As String
    Dim Renglon() As String
    Dim RutaArchivoDatos As String
    Dim RutaOrigen As String
    Dim RutaDestinoOK As String
    Dim RutaDestinoError As String
    Dim CadenaAux() As String
    Dim Tipo As String
    Dim ArrayNomArchivo() As String
    Dim NomArchivo As String
    Dim ProcesadoOk As Boolean = False




    Public Sub DatosMuestras_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try

            DCortesMP = New AdoSQL("CORTESLOTE")
            DDatosMuestras = New AdoSQL("DATOSMUESTRAS")
            DOPs = New AdoSQL("OPS")

            RutaOrigen = ReadConfigVar("RUTADATOSMUESTRAS")
            RutaDestinoOK = ReadConfigVar("RUTADESTMUESTRAS")
            RutaDestinoError = ReadConfigVar("RUTADESTERRMUEST")

            If RutaOrigen.Last.ToString <> "\" Then RutaOrigen = RutaOrigen + "\"
            If RutaDestinoOK.Last.ToString <> "\" Then RutaDestinoOK = RutaDestinoOK + "\"
            If RutaDestinoError.Last.ToString <> "\" Then RutaDestinoError = RutaDestinoError + "\"


            If Not Directory.Exists(RutaDestinoOK) Or Not Directory.Exists(RutaDestinoError) Or Not Directory.Exists(RutaOrigen) Then
                TimSeg.Enabled = False
                Alarma("Fallo conexión con ruta de muestras laboratorio")
                Evento("Ruta: " + RutaOrigen)
                Me.Close()
                Me.Dispose()
                Return
                ' MsgBox("No existe la carpeta para copiar el archivo", vbCritical)
            End If

            TimSeg_Tick(Nothing, Nothing)

        Catch ex As Exception
            MsgError(ex)
        End Try

    End Sub

    Private Sub TimSeg_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TimSeg.Tick
        Try

            ArrayNomArchivo = Directory.GetFiles(RutaOrigen)
            NomArchivo = ""

            If ArrayNomArchivo.Length = 0 Then Return

            For Each S As String In ArrayNomArchivo
                If InStr(1, Path.GetFileName(S), ".TXT") Then
                    NomArchivo = Path.GetFileName(S)
                End If
            Next

            If NomArchivo = "" Then Return

            RutaArchivoDatos = Path.Combine(RutaOrigen + NomArchivo)

            BLeerArchivo_Click(Nothing, Nothing)

        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub BLeerArchivo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BLeerArchivo.Click
        Try

            ArchivoDatos = File.OpenText(RutaArchivoDatos)
            Contenido = ArchivoDatos.ReadToEnd

            ArchivoDatos.Close()

            Contenido = Replace(Contenido, Chr(34), "")

            CadenaContenido = Split(Contenido, vbNewLine)

            If CadenaContenido.Length < 5 Then
                ProcesadoOk = False
                GoTo MoverArchivo
            End If


            'Partimos cada renglon para procesar los datos de la muestras ceniza,grasa,humedad

            Dim i As Long

            For i = 0 To UBound(CadenaContenido) - 1
                Renglon = Split(CadenaContenido(i), vbTab)
                If Renglon.Length <> 30 Then Continue For

                'Capturamos los datos del primer renglon Fecha Muestra, Codigo de OP o MP,Ceniza
                If i = 0 Then
                    'TFecha.Text = CDate(Renglon(3)).ToString("yyyy/MM/dd HH:mm:ss")

                    If InStr(1, Renglon(7), "Producto Terminado") > 0 Then
                        Tipo = "PT"
                    Else
                        Tipo = "MP"
                    End If
                    'Extraemos el código de MP o de la OP, y el lote para el caso de MP

                    CadenaAux = Split(Renglon(15), "_")

                    If CadenaAux.Length = 1 Then
                        ProcesadoOk = False
                        GoTo MoverArchivo
                    End If

                    If Eval(CadenaAux(0)) <> 0 Then TCodigo.Text = CadenaAux(0)

                    If Tipo = "MP" Then
                        If CadenaAux(1) <> "" Then TLote.Text = CadenaAux(1)
                    End If

                    'Determinamos si es codigo de PT=Producto Terminado o MP=Materia Prima

                    If InStr(1, Renglon(24), "ASH") > 0 Then
                        TCeniza.Text = Eval(Renglon(25))
                        Continue For
                    End If

                End If


                'Buscamos el dato de la grasa, puede estar en el registro 1 o 2
                If i = 1 Or i = 2 Then

                    'Si llega un registro con datos de fibra no se toma
                    If InStr(1, Renglon(24), "CF") > 0 Then Continue For

                    If InStr(1, Renglon(24), "FAT") > 0 Then
                        TGrasa.Text = Eval(Renglon(25))
                        Continue For
                    End If

                End If

                'Buscamos el dato de la humedad, puede estar en el registro 2 o 3
                If i = 2 Or i = 3 Then

                    If InStr(1, Renglon(24), "MOISTURE") > 0 Then
                        THumedad.Text = Eval(Renglon(25))
                        Continue For
                    End If

                End If


                'Buscamos el dato de la proteina, puede estar en el registro 3 o 4
                If i = 3 Or i = 4 Then

                    If InStr(1, Renglon(24), "PROTEIN") > 0 Then
                        TProteina.Text = Eval(Renglon(25))
                        Continue For
                    End If

                End If

            Next

            ProcesadoOk = False


            If Tipo = "MP" Then

                'Si el TIPO de dato registrado es MP se busca el codigo y el corte de Lote en la tabla CortesLOte para asignar 
                'los datos muestreados


                DCortesMP.Open("Select * from CORTESLOTE where CODMAT='" + TCodigo.Text + "' and LOTE='" + TLote.Text + "'")

                If DCortesMP.Count > 0 Then

                    DCortesMP.RecordSet("HUMEDAD") = Eval(THumedad.Text)
                    DCortesMP.RecordSet("GRASA") = Eval(TGrasa.Text)
                    DCortesMP.RecordSet("PROTEINA") = Eval(TProteina.Text)
                    DCortesMP.RecordSet("CENIZA") = Eval(TCeniza.Text)
                    DCortesMP.Update()

                    Evento("Actualiza corte de lote: " + DCortesMP.RecordSet("CONT").ToString + " CodMat: " + TCodigo.Text + _
                        " Lote: " + TLote.Text + " Hum: " + THumedad.Text + " Grasa: " + TGrasa.Text + " Proteina: " + TProteina.Text + " Ceniza: " + TCeniza.Text)

                    ProcesadoOk = True

                End If
            Else


                DOPs.Open("Select * from OPS where OP='" + TCodigo.Text + "'")

                If DOPs.Count = 0 Then
                    ProcesadoOk = False
                    GoTo MoverArchivo
                End If

                DDatosMuestras.Open("Select * from DATOSMUESTRAS where ID=0")

                DDatosMuestras.AddNew()
                DDatosMuestras.RecordSet("OP") = TCodigo.Text
                DDatosMuestras.RecordSet("CENIZA") = TCeniza.Text
                DDatosMuestras.RecordSet("HUMEDAD") = THumedad.Text
                DDatosMuestras.RecordSet("GRASA") = TGrasa.Text
                DDatosMuestras.RecordSet("PROTEINA") = TProteina.Text

                Evento("Crea registro en tabla DatosMuestras: " + "OP: " + TCodigo.Text + _
                        " Lote: " + TLote.Text + " Hum: " + THumedad.Text + " Grasa: " + TGrasa.Text + " Proteina: " + TProteina.Text + " Ceniza: " + TCeniza.Text)


                DDatosMuestras.Update()

                ProcesadoOk = True

            End If

            Limpiar_Habilitar_TextBox(Me.Controls, AccionTextBox.Limpiar)

MoverArchivo:

            If ProcesadoOk Then
                File.Move(RutaArchivoDatos, RutaDestinoOK + NomArchivo)
            Else
                File.Move(RutaArchivoDatos, RutaDestinoError + NomArchivo)
            End If


        Catch ex As IndexOutOfRangeException
            ProcesadoOk = False
            GoTo MoverArchivo
        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub
End Class