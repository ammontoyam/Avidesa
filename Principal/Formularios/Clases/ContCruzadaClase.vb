Public Class ContCruzadaClase

    Private OPValor As String
    Private OPValorAnt As String
    Private MaquinaValor As Int16
    Private DOPs As AdoSQL
    Private DConfig As AdoSQL
    Private DFor As AdoSQL
    Private DDatosFor As AdoSQL
    Private DArt As AdoSQL
    Private DVarios As AdoSQL


    Public Sub New()
        MyBase.New()
        DOPs = New AdoSQL("OPS")
        DConfig = New AdoSQL("CONFIG")
        DFor = New AdoSQL("FORMULAS")
        DDatosFor = New AdoSQL("DATOSFOR")
        DVarios = New AdoSQL("VARIOS")
        DArt = New AdoSQL("ARTICULOS")
    End Sub

    Public Property OP As String
        Get
            OP = OPValor
        End Get
        Set(ByVal value As String)
            OPValor = value
        End Set
    End Property

    Public Property OPAnt As String
        Get
            OPAnt = OPValorAnt
        End Get
        Set(ByVal value As String)
            OPValorAnt = value
        End Set
    End Property

    Public Property Maquina As Int16
        Get
            Maquina = MaquinaValor
        End Get
        Set(ByVal value As Int16)
            MaquinaValor = value
        End Set
    End Property


    Public Function ContCruzada() As String



        Dim CodForAct, LPAct As String
        Dim CodForAnt, LPAnt As String
        Dim CodEspecieAnt, CodGrpForAnt As String
        Dim CodEspecieAct, CodGrpForAct As String
        Dim DForContCruz As New AdoSQL("FORCONTCRUZ")
        Dim DDatosForContCruz As New AdoSQL("DATOSFORCONTCRUZ")
        Dim DContCruz As New AdoSQL("ContCruz")


        'OP = TContCruzada.Text
        If Eval(OP) = 0 Then
            ContCruzada = "S"
            Exit Function
        End If

        If Eval(OPAnt) = 0 Then
            ContCruzada = "S"
            Exit Function
        End If

        'If Eval(Maquina) = 0 Then
        '    ContCruzada = "S"
        '    Exit Function
        'End If

        DOPs.Open("select * from OPS where OP='" + OP + "'")

        CodForAct = DOPs.RecordSet("CodFor").ToString
        LPAct = DOPs.RecordSet("LP").ToString

        DOPs.Open("select * from OPS where OP='" + OPAnt + "'")


        CodForAnt = DOPs.RecordSet("CodFor").ToString
        LPAnt = DOPs.RecordSet("LP").ToString

        DFor.Open("select * from FORMULAS where CODFOR='" + CodForAnt.Trim + "' and LP='" + LPAnt.Trim + "'")

        If DFor.Count = 0 Then
            ContCruzada = "N"
            'Alarma("La Fórmula Act " + CodForAnt + "-" + LPAnt + " no Existe en la tabla Formulas")
            Exit Function
        End If

        CodEspecieAnt = DFor.RecordSet("CodEspecie").ToString
        CodGrpForAnt = DFor.RecordSet("CODGRPFOR").ToString

        DForContCruz.Open("select * from FORMULAS where CODFOR='" + CodForAct.Trim + "' and LP='" + LPAct.Trim + "'")

        If DForContCruz.Count = 0 Then
            ContCruzada = "S"
            Alarma("La Fórmula Act " + CodForAct + "-" + LPAct + " no Existe en la tabla Formulas")
            Exit Function
        End If

        CodEspecieAct = DForContCruz.RecordSet("CodEspecie")
        CodGrpForAct = DForContCruz.RecordSet("CODGRPFOR")

        If CodEspecieAct = "0" Or CodGrpForAct = "0" Then
            Alarma("Secuencia Mezcla Empaque. Fórmula sin Especie o sin Grupo " + Trim(CodForAct) + "-" + Trim(LPAct), AppWinStyle.NormalFocus)
            ContCruzada = "S"
            Exit Function
        End If

        ''''' ESPECIE RESTRINGE ESPECIE ''''''''''
        DContCruz.Open("select * from CONTCRUZADA where CODESPECIE='" + CodEspecieAnt + "' and CODESPECIERESTRINGIDA='" + CodEspecieAct + "'")

        If DContCruz.Count > 0 Then
            ContCruzada = "S"
            Alarma("Secuencia Mezcla Empaque. Especie de For: " + Trim(CodForAct) + "-" + Trim(LPAct) + " RESTRINGIDA por especie de ForAnt:" + Trim(CodForAct) + "-" + Trim(LPAnt), AppWinStyle.NormalFocus)
            Exit Function
        End If

        '''' GRUPO DE FORMULAS QUE RESTRINGE A GRUPO DE FORMULAS '''''''''
        DContCruz.Open("select * from CONTCRUZADA where CODGRPFOR='" + CodGrpForAnt + "' and CODGRPFORRESTRINGIDA='" + CodGrpForAct + "'")

        If DContCruz.Count > 0 Then
            ContCruzada = "S"
            Alarma("Secuencia Mezcla Empaque. Grupo de For: " + Trim(CodForAct) + "-" + Trim(LPAct) + " RESTRINGIDA por Grupo de ForAnt:" + Trim(CodForAct) + "-" + Trim(LPAnt), AppWinStyle.NormalFocus)
            Exit Function
        End If

        ''''''''''ENTRAMOS A ANALIZAR CADA UNO DE LOS INGREDIENTES DE LA ÚLTIMA FÓRMULA PRODUCIDA

        DDatosFor.Open("select * from DATOSFOR where CODFOR='" + CodForAnt + "' and LP='" + LPAnt + "'")

        For Each RecordSet As DataRow In DDatosFor.Rows

            DArt.Open("select * from ARTICULOS where CODINT='" + RecordSet("CodMat").ToString + "' AND TIPO='MP'")

            If DArt.Count = 0 Then
                Evento("Ingrediente de la Fórmula anterior no existe en la tabla ARTICULOS " + RecordSet("CodMat").ToString)
                Continue For
            End If

            If Eval(DArt.RecordSet("CODGRPMAT").ToString) = 0 Then Continue For

            ''''' ESPECIE RESTRINGIDA POR GRUPO DE MATERIAL ''''''''''''
            DContCruz.Open("select * from CONTCRUZADA where CODGRPMAT='" + DArt.RecordSet("CODGRPMAT").ToString + "' and CODESPECIERESTRINGIDA='" + CodEspecieAct.Trim + "'")

            If DContCruz.Count > 0 Then
                ContCruzada = "S"
                Alarma("Secuencia Mezcla Empaque. El Grupo del Mat " + DArt.RecordSet("CODINT").ToString + " RESTRINGE Especie de la For:" + Trim(CodForAct) + "-" + Trim(LPAct), AppWinStyle.NormalFocus)
                Exit Function
            End If


            '''''GRUPO DE FORMULA RESTRINGIDA POR GRUPO DE MATERIAL ''''''''''''

            DContCruz.Open("select * from CONTCRUZADA where CODGRPMAT='" + DArt.RecordSet("CODGRPMAT").ToString + "' and CODGRPFORRESTRINGIDA='" + CodGrpForAct.Trim + "'")

            If DContCruz.Count > 0 Then
                ContCruzada = "S"
                Alarma("Secuencia Mezcla Empaque. El Grupo del Mat " + DArt.RecordSet("CODINT").ToString + " RESTRINGE el Grupo de la For:" + Trim(CodForAct) + "-" + Trim(LPAct), AppWinStyle.NormalFocus)
                Exit Function
            End If

            '''''GRUPO DE MATERIAL RESTRINGIDO POR GRUPO DE MATERIAL ''''''''''''
            DDatosForContCruz.Open("select * from DATOSFOR where CODFOR='" + CodForAct.Trim + "' and LP='" + LPAct.Trim + "' order by paso")

            For Each RecordDatosFor As DataRow In DDatosForContCruz.Rows

                DVarios.Open("select * from ARTICULOS where CODINT='" + RecordDatosFor("CodMat").ToString + "' and TIPO='MP'")

                If DVarios.Count = 0 Then
                    Evento("El ingrediente de la Formula Actual no existe en la Tabla ARTICULOS " + RecordDatosFor("CodMat").ToString)
                    Continue For
                End If

                If Eval(DArt.RecordSet("CODGRPMAT").ToString) = 0 OrElse Eval(DVarios.RecordSet("CODGRPMAT").ToString) = 0 Then
                    Continue For
                End If

                DContCruz.Open("select * from CONTCRUZADA where CODGRPMAT='" + DArt.RecordSet("CODGRPMAT").ToString + "' and CODGRPMATRESTRINGIDO='" + DVarios.RecordSet("CODGRPMAT").ToString + "'")

                If DContCruz.Count > 0 Then
                    ContCruzada = "S"
                    Alarma("Secuencia Mezcla Empaque. El Grupo del Mat  " + DArt.RecordSet("CODINT").ToString + " RESTRINGE al Grupo del Mat " + DVarios.RecordSet("CODINT").ToString, AppWinStyle.NormalFocus)
                    Exit Function
                End If

            Next

        Next

        ContCruzada = "N"

    End Function

End Class
