Module ModuloSintaxis
    'Se crea una estructura de datos FIFO o cola para guardar todos los terminos (Léxemas, número de línea y tipo)
    'de la Tabla de tokens resultante en el Análisis de Léxico
    Public colaDeTerminos As New Queue(Of String)()
    Public numeroLinea As New Queue(Of String)()
    Public tipo As New Queue(Of String)()

    'Método que permite obtener los datos de Lexico en forma de cola
    Public Sub AnalizarSintaxis()
        'Se limpia el resultado anterior
        colaDeTerminos.Clear()
        numeroLinea.Clear()
        tipo.Clear()

        'Ciclo FOR que obtiene todos los términos (Léxema, número de línea y tipo) de cada fila del DGV de Tabla de Tokens
        For Each fila As DataGridViewRow In FrmPrincipal.DGVArchicoDestino.Rows
            Dim lexema As String = fila.Cells(0).Value.ToString()
            Dim linea As String = fila.Cells(3).Value.ToString()
            Dim tipoL As String = fila.Cells(4).Value.ToString()
            colaDeTerminos.Enqueue(lexema)
            numeroLinea.Enqueue(linea)
            tipo.Enqueue(tipoL)
        Next

        'Se ejectua el método principal de Sintaxis
        'Try
        PROG()
        'Catch ex As Exception
        '    MsgBox(ex.Message)
        'End Try

    End Sub

    'Método que analisa la correcta estrutura de un identificador
    Public Function ID() As Boolean
        'Se analiza si el término es un indentificador entero, real o string
        If colaDeTerminos.Count > 0 Then
            If tipo.Peek().Equals("IDENTIFICADOR ENTERO") Or tipo.Peek().Equals("IDENTIFICADOR REAL") Or tipo.Peek().Equals("IDENTIFICADOR STRING") Then
                'Si se encuentra la palabra reservada se quita de la cola (Se quita el término, su número de línea y tipo)
                colaDeTerminos.Dequeue()
                numeroLinea.Dequeue()
                tipo.Dequeue()

                ID = True
            Else
                ERROR_SINTAXIS(numeroLinea.Peek(), colaDeTerminos.Peek(), "Identificador entero, real o string")
            End If
        End If

        Return ID
    End Function

    'Método que analisa la correcta estrutura de la declaración de variable(s)
    Public Function VARIABLES() As Boolean
        'Se analiza si el primer término es 'var'
        If colaDeTerminos.Count > 0 And colaDeTerminos.Peek().Equals("var") Then
            'Si se encuentra la palabra reservada se quita de la cola (Se quita el término, su número de línea y tipo)
            colaDeTerminos.Dequeue()
            numeroLinea.Dequeue()
            tipo.Dequeue()

            'Se ejecuta la funcion de ID, esta retornará True o False para poder avanzar o no
            If ID() Then
                If colaDeTerminos.Peek().Equals("[") Then
                    colaDeTerminos.Dequeue()
                    numeroLinea.Dequeue()
                    tipo.Dequeue()

                    If tipo.Peek().Equals("CONSTANTE ENTERA") Then
                        colaDeTerminos.Dequeue()
                        numeroLinea.Dequeue()
                        tipo.Dequeue()

                        If colaDeTerminos.Peek().Equals(",") Then
                            colaDeTerminos.Dequeue()
                            numeroLinea.Dequeue()
                            tipo.Dequeue()


                        ElseIf colaDeTerminos.Peek().Equals("]") Then
                            colaDeTerminos.Dequeue()
                            numeroLinea.Dequeue()
                            tipo.Dequeue()

                            If colaDeTerminos.Peek().Equals(";") Then
                                colaDeTerminos.Dequeue()
                                numeroLinea.Dequeue()
                                tipo.Dequeue()
                                If colaDeTerminos.Peek().Equals("var") Then
                                    ' Llamada recursiva a VARIABLES
                                    If VARIABLES() Then
                                        VARIABLES = True
                                    Else
                                        ' Manejo del error o condición de finalización de la recursión
                                        VARIABLES = False
                                    End If
                                Else
                                    VARIABLES = True
                                End If

                            Else
                                ERROR_SINTAXIS(numeroLinea.Peek(), colaDeTerminos.Peek(), ";")
                            End If

                        Else
                            ERROR_SINTAXIS(numeroLinea.Peek(), colaDeTerminos.Peek(), ", ó ]")
                        End If
                    Else
                        ERROR_SINTAXIS(numeroLinea.Peek(), colaDeTerminos.Peek(), "Constante entera")
                    End If
                ElseIf colaDeTerminos.Peek().Equals(";") Then
                    colaDeTerminos.Dequeue()
                    numeroLinea.Dequeue()
                    tipo.Dequeue()
                    VARIABLES = True
                Else
                    ERROR_SINTAXIS(numeroLinea.Peek(), colaDeTerminos.Peek(), "[ ó ;")
                End If
            End If
        Else
            'Si no viene nada, esta bien
            VARIABLES = True
        End If

        Return VARIABLES
    End Function

    Public Function PROC() As Boolean
        Return True

    End Function

    Public Function ESTATUTOS() As Boolean
        Return True

    End Function

    Public Sub ERROR_SINTAXIS(ByVal numeroLineaD As String, ByVal datoError As String, ByVal datoEsperado As String)
        FrmPrincipal.LbResultadoSintaxis.Text = "Error de sintaxis en la línea: " + numeroLineaD + " '" + datoError + "', se esperaba: '" + datoEsperado + "'"
        FrmPrincipal.LbResultadoSintaxis.BackColor = Color.OrangeRed
        FrmPrincipal.LbResultadoSintaxis.ForeColor = Color.White
        FrmPrincipal.LbResultadoSintaxis.Size = New Size(465, 65)
    End Sub

    Public Sub SINTAXIS_CORRECTO()
        FrmPrincipal.LbResultadoSintaxis.Text = "Sin errores de sintaxis."
        FrmPrincipal.LbResultadoSintaxis.BackColor = Color.LightGreen
        FrmPrincipal.LbResultadoSintaxis.ForeColor = Color.Black
        FrmPrincipal.LbResultadoSintaxis.Size = New Size(185, 25)
    End Sub

    'Método principal de Sintaxis en donde se evalua la correcta estructura del programa
    Public Sub PROG()
        'Se analiza si el primer término es 'programa'
        If colaDeTerminos.Count > 0 And colaDeTerminos.Peek().Equals("programa") Then
            'Si se encuentra la palabra reservada se quita de la cola (Se quita el término, su número de línea y tipo)
            colaDeTerminos.Dequeue()
            numeroLinea.Dequeue()
            tipo.Dequeue()

            'Se analiza si el siguiente termino es el identificador de rutina
            If colaDeTerminos.Count > 0 And tipo.Peek().Equals("IDENTIFICADOR RUTINA") Then
                'Si se encuentra la palabra reservada se quita de la cola (Se quita el término, su número de línea y tipo)
                colaDeTerminos.Dequeue()
                numeroLinea.Dequeue()
                tipo.Dequeue()

                'Se ejecuta la funcion de VARIABLES, esta retornará True o False para poder avanzar o no
                If VARIABLES() Then 'Sí VARIABLES RETORNA TRUE, continua
                    If PROC() Then 'Sí PROC RETORNA TRUE, continua
                        If colaDeTerminos.Count > 0 And colaDeTerminos.Peek().Equals("inicio") Then
                            'Si se encuentra la palabra reservada se quita de la cola (Se quita el término, su número de línea y tipo)
                            colaDeTerminos.Dequeue()
                            numeroLinea.Dequeue()
                            tipo.Dequeue()
                            ESTATUTOS()
                            Try
                                If colaDeTerminos.Peek().Equals("fin") Then
                                    'Si se encuentra la palabra reservada se quita de la cola (Se quita el término, su número de línea y tipo)
                                    colaDeTerminos.Dequeue()
                                    numeroLinea.Dequeue()
                                    tipo.Dequeue()
                                    SINTAXIS_CORRECTO()
                                Else
                                    ERROR_SINTAXIS(numeroLinea.Peek(), colaDeTerminos.Peek(), "fin")
                                End If
                            Catch ex As Exception
                                ERROR_SINTAXIS("Última", "", "fin")
                            End Try

                        Else
                            ERROR_SINTAXIS(numeroLinea.Peek(), colaDeTerminos.Peek(), "inicio")
                        End If
                    End If
                End If
            Else
                ERROR_SINTAXIS(numeroLinea.Peek(), colaDeTerminos.Peek(), "Identificador de rutina")
            End If
        Else
            ERROR_SINTAXIS(numeroLinea.Peek(), colaDeTerminos.Peek(), "programa")
        End If
    End Sub



End Module
