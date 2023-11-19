Module ModuloGlobal
    'Declaración de las matrices (array) de las diferentes palabras reservadas, operadores y caracteres,
    'a su vez las matrices correspondientes para asignar el token que le pertenece a cada uno de ellos.

    ' Definir las palabras reservadas, operadores y caracteres especiales del lenguaje
    Public palabrasReservadas() As String = {"programa", "inicio", "fin", "leer", "escribir", "si", "sino", "mientras", "repetir", "hasta", "limpiar", "ejecutar", "prosxy", "proc", "var", "encaso", "valor"}
    Public operadoresAritmeticos() As String = {"+", "-", "*", "/", "%", "="}
    Public operadoresRelacionales() As String = {"<", "<=", ">", ">=", "==", "!="}
    Public operadoresLogicos() As String = {"!", "&&", "||"}
    Public caracteres() As String = {";", "[", "]", ",", ":", "(", ")", "{", "}"}

    ' Tokens correspondientes a cada palabra reservada, operador, caracter y constante
    Public tokensPalabrasReservadas() As Integer = {-1, -2, -3, -4, -5, -6, -7, -8, -9, -10, -11, -12, -13, -14, -15, -16, -17}
    Public tokensOperadoresAritmeticos() As Integer = {-31, -32, -33, -34, -35, -36}
    Public tokensOperadoresRelacionales() As Integer = {-41, -42, -43, -44, -45, -46}
    Public tokensOperadoresLogicos() As Integer = {-51, -52, -53}
    Public tokensIdentificadores() As Integer = {-61, -62, -63, -64, -65}
    Public tokensConstantes() As Integer = {-71, -72, -73}
    Public tokensCaracteres() As Integer = {-81, -82, -83, -84, -85, -86, -87, -88, -89}

End Module
