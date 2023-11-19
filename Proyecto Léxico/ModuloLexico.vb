'Libreria que nos va a permitir trabajar con expresiones regulares y poder manipular y validar cadenas
'de texto que sean permitidas por el lenguaje
Imports System.Text.RegularExpressions

Module ModuloLexico
    ' Variable que obtendra todo el contenido del txt de origen
    Public archivo
    ' Variable que obtendra todo el contenido del txt destino
    Public nuevoArchivo

    'Método principal para analizar el Léxico de un archivo de texto
    Sub AnalizarLexico()
        Dim numeroLinea As Integer = 1 ' Variable para contar el número de línea
        Dim datoError As String = "No aplica"
        Try
            ' Abrir el archivo de texto
            FrmPrincipal.AbrirCerrarArchivoOrigen("Abrir")

            ' Crear un nuevo archivo para guardar los tokens, este será guardado en el escritorio
            FrmPrincipal.CrearCerrarNuevoArchivo("Abrir")

            'Apuntador que indica que los archivos estan abiertos
            FrmPrincipal.abierto = True

            ' Leer el archivo de texto línea por línea
            Dim linea As String

            Do
                'Leer la linea completa del archivo
                linea = archivo.ReadLine()

                'Si la linea tiene contendido
                If linea IsNot Nothing Then

                    ' Separar la línea en dos partes, antes y después del comentario
                    Dim partes() As String = linea.Split("//")

                    ' Trabajar solo con la primera parte de la línea, que no contiene el comentario
                    Dim lineaSinComentario As String = partes(0).Trim()

                    ' Separar la línea sin comentario en palabras y caracteres
                    Dim palabras() As String = lineaSinComentario.Split({" ", vbTab}, StringSplitOptions.RemoveEmptyEntries)
                    'Dim chars() As Char = lineaSinComentario.ToCharArray()

                    Dim dentroCadena As Boolean = False 'Variable que indica si estamos dentro de una cadena

                    'Esta variable guradara el carcter que se encuentre al inicio o final de la palabra para generar su token cuando este pegada a ella
                    Dim caracterInicio As String
                    Dim caracterFin As String
                    Dim baderaCaracterFin As String = "" ' HAY AL FIN
                    Dim entroEnAlgunCaso As Boolean = False

                    For Each palabra In palabras
                        Dim palabraAux As String = palabra

                        entroEnAlgunCaso = False

                        'Por si se necesita especificar el error
                        datoError = palabra

                        'Esto quita los caracteres al final de una palabra reservada o identificador string o numerico
                        ' Crear un arreglo vacío para almacenar las palabras eliminadas, que posterimente de analizar la palabra se agregaran
                        'a la tabla de tokens
                        Dim palabrasEliminadas As New List(Of String)()

                        '  If Not palabra.StartsWith("""") Then
                        'Esto es para identificar los caracteres que este antes de una palabra reservada o identificador string o numerico
                        While ";[],:(){}".IndexOf(palabra.Chars(0)) >= 0 And palabra.Length > 1
                            caracterInicio = palabra.Chars(0)
                            ' Obtener el token correspondiente 
                            nuevoArchivo.WriteLine(caracterInicio & "     " & tokensCaracteres(Array.IndexOf(caracteres, caracterInicio)) & "     -1     " & numeroLinea & "     CARÁCTER ESPECIAL")
                            palabra = palabra.Substring(1)
                        End While

                        ' Iniciar el ciclo
                        While ";[],:(){}".IndexOf(palabra.Chars(palabra.Length - 1)) >= 0 And palabra.Length > 1
                            ' Agregar la palabra eliminada al arreglo
                            palabrasEliminadas.Add(palabra.Substring(palabra.Length - 1))

                            ' Eliminar el último carácter de la palabra y actualizar la bandera y la palabra
                            caracterFin = palabra.Chars(palabra.Length - 1)
                            baderaCaracterFin = "HAY AL FINAL"
                            palabra = palabra.Substring(0, palabra.Length - 1)
                        End While
                        '   End If

                        If palabra.StartsWith("""") Then ' Verificar si la palabra es una cadena string, cuando inicia con " y termina "
                            dentroCadena = True 'Cambiar el valor de la variable cada vez que encontramos una cadena
                            Dim cadena As String = ""
                            Try

                                Dim i As Integer = Array.IndexOf(palabras, palabra)

                                ' Obtener la cadena completa
                                While i < palabras.Length AndAlso Not palabras(i).EndsWith("""")
                                    cadena += palabras(i) + " "
                                    i += 1
                                End While

                                ' Agregar la última palabra de la cadena
                                If i < palabras.Length Then
                                    cadena += palabras(i)
                                End If

                                If cadena.EndsWith("""") Then
                                    entroEnAlgunCaso = True
                                    'Se escribe en el nuevo archivo la cadena, el token, P en T y número de línea
                                    nuevoArchivo.WriteLine(cadena & "     " & tokensConstantes(2).ToString & "     -1     " & numeroLinea & "     CONSTANTE STRING")
                                ElseIf Not cadena.EndsWith("""") Then ' Se valida si una cadena no esta cerrada
                                    nuevoArchivo.WriteLine(palabra & "     -1000     -1     " & numeroLinea & "     NO RECONOCIDO")
                                    Continue For
                                End If
                            Catch ex As Exception
                                'MsgBox("Error en la línea: " & numeroLinea & " → " & datoError + vbCr + vbCr & "Intenta separar la cadena del (operador/carácter/símbolo) por medio de un espacio para que pueda ser reconocido." + vbCr + vbCr & "Lamentablemente se omitio de la tabla de tokens o se pudo haber agregado pero con error -1000", vbCritical)
                                nuevoArchivo.WriteLine(palabra & "     " & tokensConstantes(2).ToString & "     -1     " & numeroLinea & "     CONSTANTE STRING")

                                'Al terminar de analizar la palabra, se asignan los caracteres con su token que pudieron estar pegados al final de esta misma
                                'siempre y cuando se hayan identificado y la bandera lo confirme
                                If baderaCaracterFin = "HAY AL FINAL" Then
                                    ' Recorrer el arreglo de palabras eliminadas en orden inverso
                                    For i As Integer = palabrasEliminadas.Count - 1 To 0 Step -1
                                        nuevoArchivo.WriteLine(palabrasEliminadas(i) & "     " & tokensCaracteres(Array.IndexOf(caracteres, palabrasEliminadas(i))) & "     -1     " & numeroLinea & "     CARÁCTER ESPECIAL")
                                    Next
                                End If

                            End Try

                        End If

                        If palabra.EndsWith("""") Then
                            If dentroCadena = True Then
                                dentroCadena = False 'Cambiar el valor de la variable cada vez que se termino de analizar la cadena
                                Continue For
                                'Si ya no esta dentro de la cadena
                            ElseIf Not dentroCadena Then ' Esto es por si nunca se inicio una cadena pero la palabra si termina en "
                                nuevoArchivo.WriteLine(palabra & "     -1000     -1     " & numeroLinea & "     NO RECONOCIDO")
                                Continue For
                            End If

                        ElseIf palabra.EndsWith("&") Then
                            entroEnAlgunCaso = True
                            'Se escribe en el nuevo archivo la cadena, el token, P en T y número de línea
                            nuevoArchivo.WriteLine(palabra & "     " & tokensIdentificadores(0).ToString & "     -2     " & numeroLinea & "     IDENTIFICADOR ENTERO")

                        ElseIf palabra.EndsWith("%") Then
                            entroEnAlgunCaso = True
                            'Se escribe en el nuevo archivo la cadena, el token, P en T y número de línea
                            nuevoArchivo.WriteLine(palabra & "     " & tokensIdentificadores(1).ToString & "     -2     " & numeroLinea & "     IDENTIFICADOR REAL")

                        ElseIf palabra.EndsWith("$") Then
                            entroEnAlgunCaso = True
                            'Se escribe en el nuevo archivo la cadena, el token, P en T y número de línea
                            nuevoArchivo.WriteLine(palabra & "     " & tokensIdentificadores(2).ToString & "     -2     " & numeroLinea & "     IDENTIFICADOR STRING")

                        ElseIf palabra.EndsWith("@") Then
                            entroEnAlgunCaso = True
                            'Se escribe en el nuevo archivo la cadena, el token, P en T y número de línea
                            nuevoArchivo.WriteLine(palabra & "     " & tokensIdentificadores(4).ToString & "     -2     " & numeroLinea & "     IDENTIFICADOR RUTINA")

                        ElseIf dentroCadena = False Then
                            ' Verificar si la palabra es una palabra reservada
                            If palabrasReservadas.Contains(palabra) Then
                                entroEnAlgunCaso = True
                                ' Obtener el índice de la palabra reservada
                                Dim indice As Integer = Array.IndexOf(palabrasReservadas, palabra)
                                ' Obtener el token correspondiente a la palabra reservada
                                Dim token As Integer = tokensPalabrasReservadas(indice)
                                nuevoArchivo.WriteLine(palabra & "     " & token.ToString & "     -1     " & numeroLinea & "     PALABRA RESERVADA")
                                'Identificador
                            ElseIf Char.IsLetter(palabra.Chars(0)) AndAlso palabra.All(Function(c) Char.IsLetterOrDigit(c)) Then
                                entroEnAlgunCaso = True
                                'Se escribe en el nuevo archivo la cadena, el token, P en T y número de línea
                                nuevoArchivo.WriteLine(palabra & "     " & tokensIdentificadores(3).ToString & "     -2     " & numeroLinea & "     IDENTIFICADOR GENERAL")
                            Else

                                ' Esta validación es para comprobar si la palabra que empiece por +, - o numero,en verdad sea valida
                                If palabra.StartsWith("+") And palabra.Length > 1 Or palabra.StartsWith("-") And palabra.Length > 1 Or Char.IsDigit(palabra(0)) Then
                                    ' Definir expresión regular para analizar si es un numero válido
                                    Dim regexNumeroValido As New Regex("^[+-]?(\d+(\.\d*)?|\.\d+)$")

                                    If Not regexNumeroValido.IsMatch(palabra) Or palabra.EndsWith(".") Then
                                        nuevoArchivo.WriteLine(palabra & "     -1000     -1     " & numeroLinea & "     NO RECONOCIDO")

                                        'Al terminar de analizar la palabra, se asignan los caracteres con su token que pudieron estar pegados al final de esta misma
                                        'siempre y cuando se hayan identificado y la bandera lo confirme
                                        If baderaCaracterFin = "HAY AL FINAL" Then
                                            ' Recorrer el arreglo de palabras eliminadas en orden inverso
                                            For i As Integer = palabrasEliminadas.Count - 1 To 0 Step -1
                                                nuevoArchivo.WriteLine(palabrasEliminadas(i) & "     " & tokensCaracteres(Array.IndexOf(caracteres, palabrasEliminadas(i))) & "     -1     " & numeroLinea & "     CARÁCTER ESPECIAL")
                                            Next
                                        End If
                                        Continue For
                                    End If
                                End If

                                ' Unir las palabras del código en una sola cadena
                                Dim codigo As String = String.Join(" ", palabra)

                                ' Separar la cadena en tokens utilizando la expresión regular
                                Dim cadenaSeparada() As String = Regex.Split(codigo, "(\d+\.?\d*|\.\d+|[+\-*/()<>!=]=?|==|!=)")

                                ' Definir expresión regular para buscar operadores relacionales
                                Dim regexOperadoresRelacionales As New Regex("([<>]=?|==|!=)")

                                ' Definir expresión regular para buscar caracteres especiales
                                Dim regexCaracteresEspeciales As New Regex("([;,\[\]:\(\)\{\}])")

                                ' Definir expresión regular para buscar operadores aritméticos
                                Dim regexOperadoresAritmeticos As New Regex("([+\-*/=%])")

                                ' Definir expresión regular para buscar operadores lógicos
                                Dim regexOperadoresLogicos As New Regex("(!|&&|\|\|)")

                                ' Iterar sobre los tokens y verificar el tipo de cada uno
                                For Each lexema In cadenaSeparada
                                    If lexema.Trim() = "" Then
                                        Continue For
                                    End If

                                    If IsNumeric(lexema) Then ' Constante numérica
                                        Dim valor As Double = CDbl(lexema)

                                        If valor >= -32768 And valor <= 32767 And valor = CLng(valor) Then ' Constante entera
                                            entroEnAlgunCaso = True
                                            nuevoArchivo.WriteLine(lexema & "     " & tokensConstantes(0).ToString & "     -1     " & numeroLinea & "     CONSTANTE ENTERA")
                                        ElseIf valor <> Math.Truncate(valor) And Not lexema.EndsWith(".") Or valor < -32768 Or valor > 32767 Then ' Constante real
                                            entroEnAlgunCaso = True
                                            nuevoArchivo.WriteLine(lexema & "     " & tokensConstantes(1).ToString & "     -1     " & numeroLinea & "     CONSTANTE REAL")
                                        End If

                                    ElseIf regexOperadoresRelacionales.IsMatch(lexema) Then 'Operador relacional
                                        entroEnAlgunCaso = True
                                        Dim indice As Integer = Array.IndexOf(operadoresRelacionales, lexema)
                                        Dim tokenOperadorRelacional As Integer = tokensOperadoresRelacionales(indice)
                                        nuevoArchivo.WriteLine(lexema & "     " & tokenOperadorRelacional.ToString & "     -1     " & numeroLinea & "     OPERADOR RELACIONAL")

                                    ElseIf regexCaracteresEspeciales.IsMatch(lexema) Then ' Caracter especial
                                        entroEnAlgunCaso = True
                                        Dim indice As Integer = Array.IndexOf(caracteres, lexema)
                                        Dim tokenCaracter As Integer = tokensCaracteres(indice)
                                        nuevoArchivo.WriteLine(lexema & "     " & tokenCaracter.ToString & "     -1     " & numeroLinea & "     CARÁCTER ESPECIAL")

                                    ElseIf regexOperadoresAritmeticos.IsMatch(lexema) Then ' Operador aritmético
                                        entroEnAlgunCaso = True
                                        Dim indice As Integer = Array.IndexOf(operadoresAritmeticos, lexema)
                                        Dim tokenOperadorAritmetico As Integer = tokensOperadoresAritmeticos(indice)
                                        nuevoArchivo.WriteLine(lexema & "     " & tokenOperadorAritmetico.ToString & "     -1     " & numeroLinea & "     OPERADOR ARITMÉTICO")

                                    ElseIf regexOperadoresLogicos.IsMatch(lexema) Then 'Operador lógico
                                        entroEnAlgunCaso = True
                                        Dim tokenOperadorLogico As Integer = tokensOperadoresLogicos(Array.IndexOf(operadoresLogicos, lexema))
                                        nuevoArchivo.WriteLine(lexema & "     " & tokenOperadorLogico.ToString & "     -1     " & numeroLinea & "     OPERADOR LÓGICO")

                                    End If
                                Next
                            End If
                        End If

                        'Caso de error, NO RECONOCIDO, esto es cuando no hace match con ninguno de los casos anteriores
                        If Not entroEnAlgunCaso And Not dentroCadena Then
                            nuevoArchivo.WriteLine(palabra & "     -1000     -1     " & numeroLinea & "     NO RECONOCIDO")
                        End If

                        'Al terminar de analizar la palabra, se asignan los caracteres con su token que pudieron estar pegados al final de esta misma
                        'siempre y cuando se hayan identificado y la bandera lo confirme
                        If baderaCaracterFin = "HAY AL FINAL" Then
                            ' Recorrer el arreglo de palabras eliminadas en orden inverso
                            For i As Integer = palabrasEliminadas.Count - 1 To 0 Step -1
                                nuevoArchivo.WriteLine(palabrasEliminadas(i) & "     " & tokensCaracteres(Array.IndexOf(caracteres, palabrasEliminadas(i))) & "     -1     " & numeroLinea & "     CARÁCTER ESPECIAL")
                            Next
                        End If

                    Next
                    ' Incrementar el número de línea
                    numeroLinea += 1
                End If

            Loop Until linea Is Nothing

            ' Cerrar los archivos
            archivo.Close()
            nuevoArchivo.Close()

            'Apuntador que nos indica que los archivos estan cerrados
            FrmPrincipal.abierto = False

            ' Ver datos generados en la tabla
            FrmPrincipal.DatosATabla()

        Catch ex As Exception
            MsgBox("Error en la línea: " & numeroLinea & " → " & datoError + vbCr + vbCr & "Intenta separar la cadena/operador/carácter/símbolo por medio de un espacio para que pueda ser reconocido: " & ex.Message, vbCritical)
            ' Cerrar los archivos
            FrmPrincipal.AbrirCerrarArchivoOrigen("Cerrar")
            FrmPrincipal.CrearCerrarNuevoArchivo("Cerrar")
        End Try
    End Sub
End Module