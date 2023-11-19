Imports System.Windows.Forms.VisualStyles.VisualStyleElement

Public Class FrmPrincipal
    ' Variable que obtendra la ruta o directorio del archivo abierto
    Public rutaArchivo As String
    ' Apuntador que nos dira si el archivo origen y destino están abiertos o cerrados
    Public abierto As Boolean = False

    'Evento para mantener el contenido del formulario ordenado al redimencionar la pantalla
    Private Sub FrmLexico_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize
        ' Calcula la posición centrada para el contenido
        Dim contentX As Integer = (Me.Width - PanelPrincipal.Width) \ 2
        Dim contentY As Integer = (Me.Height - PanelPrincipal.Height) \ 2

        ' Establece la posición del contenido en el formulario
        PanelPrincipal.Location = New Point(contentX, contentY)
    End Sub

    'Método para abrir el archivo usando el explorador de Windows, solo se acepta .TXT
    Private Sub AbrirArchivoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AbrirArchivoToolStripMenuItem.Click
        Try
            'Archivos admitos, solo txt
            Dim openFileDialog As New OpenFileDialog With {
                .Filter = "Archivos de texto (*.txt)|*.txt",
                .Title = "Seleccionar archivo de texto para analizar Léxico y Sintaxis"
}

            If openFileDialog.ShowDialog() = DialogResult.OK Then
                rutaArchivo = openFileDialog.FileName
                TxtOrigen.Text = My.Computer.FileSystem.ReadAllText(rutaArchivo)
                'Desbloquear boton de analizar documento y edicion
                BtnAnalizar.Enabled = True
                BtnEditar.Visible = True
                BtnEditar.Enabled = True
                'Cajas de texto
                TxtOrigen.Enabled = True
                DGVArchicoDestino.Enabled = True
                'Label
                LbAviso.Visible = False
            End If
        Catch ex As Exception
            MsgBox(ex.Message, vbCritical)
        End Try

    End Sub

    'Acción que se realiza al seleccionar Nuevo archivo, se abre el editor de texto Notepad
    Private Sub NuevoArchivoOrigenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NuevoArchivoOrigenToolStripMenuItem.Click
        System.Diagnostics.Process.Start("notepad.exe")
    End Sub

    'Validación correspondiente antes de salri del programa
    Private Sub SalirToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SalirToolStripMenuItem.Click
        Dim pregunta As DialogResult = MessageBox.Show("¿Estás seguro de salir del programa?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        If pregunta = DialogResult.Yes Then
            Environment.Exit(1)
        End If
    End Sub

    'Acción al presionar el menu de limpiar proceso
    Private Sub EditarArchivoOrigenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EditarArchivoOrigenToolStripMenuItem.Click
        TxtOrigen.Text = ""
        TxtOrigen.Enabled = False
        LimpiarDGV()
        BtnAnalizar.Enabled = False
        BtnEditar.Enabled = False
        BtnEditar.Visible = False
        LbAviso.Visible = False
        BtnGuardarArchOrigen.Visible = False
        BtnLimpiarCajaOrigen.Visible = False
        BtnRegresarArchOrigen.Visible = False
        LbResultadoSintaxis.Text = "Abre un documento y presiona el botón de Analizar para conocer el resultado."
        LbResultadoSintaxis.ForeColor = Color.Black
        LbResultadoSintaxis.BackColor = SystemColors.Control
        If abierto Then
            ' Cerrar los archivos
            AbrirCerrarArchivoOrigen("Cerrar")
            CrearCerrarNuevoArchivo("Cerrar")
        End If
    End Sub

    'Acción de liberar documento por bloqueo
    Private Sub LiberarDocumentoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LiberarDocumentoToolStripMenuItem.Click
        If abierto Then
            ' Cerrar los archivos
            AbrirCerrarArchivoOrigen("Cerrar")
            CrearCerrarNuevoArchivo("Cerrar")

            MsgBox("Archivo origen y destino cerrados", vbInformation)
        End If
    End Sub

    'Acceso al formulario de Acerca del programa
    Private Sub AcercaDelProyectoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AcercaDelProyectoToolStripMenuItem.Click
        FrmAcercaDe.Show()
        Me.Hide()
    End Sub

    'Método que permite abrir o cerrar el archivo origen para evitar errores de lectura y escritura
    Public Sub AbrirCerrarArchivoOrigen(ByVal abrirCerrar As String)
        If abrirCerrar = "Abrir" Then
            archivo = New System.IO.StreamReader(rutaArchivo)
        ElseIf abrirCerrar = "Cerrar" Then
            archivo.Close()
        End If
    End Sub

    'Método que permite abrir o cerrar el archivo destino para evitar errores de lectura y escritura
    Public Sub CrearCerrarNuevoArchivo(ByVal abrirCerrar As String)
        If abrirCerrar = "Abrir" Then
            ' Crear un nuevo archivo para guardar los tokens, este será guardado en el escritorio
            nuevoArchivo = New System.IO.StreamWriter(My.Computer.FileSystem.SpecialDirectories.Desktop + "\Tabla de tokens.txt")
        ElseIf abrirCerrar = "Cerrar" Then
            nuevoArchivo.Close()
        End If
    End Sub

    'Método para limpiar tabla DGV del formulario
    Private Sub LimpiarDGV()
        DGVArchicoDestino.Rows.Clear()
        DGVArchicoDestino.ColumnCount = 0
    End Sub

    'Acciones al presionar el boton de editar del contenedor del archivo origen
    Dim ocultar As Boolean = False
    Private Sub BtnEditar_Click(sender As Object, e As EventArgs) Handles BtnEditar.Click
        If ocultar Then
            ocultar = False
            BtnGuardarArchOrigen.Visible = False
            BtnGuardarArchOrigen.Enabled = False
            BtnLimpiarCajaOrigen.Visible = False
            BtnLimpiarCajaOrigen.Enabled = False
            BtnRegresarArchOrigen.Visible = False
            BtnRegresarArchOrigen.Enabled = False
        Else
            ocultar = True
            BtnGuardarArchOrigen.Visible = True
            BtnGuardarArchOrigen.Enabled = True
            BtnLimpiarCajaOrigen.Visible = True
            BtnLimpiarCajaOrigen.Enabled = True
            BtnRegresarArchOrigen.Visible = True
            BtnRegresarArchOrigen.Enabled = True
        End If
    End Sub

    'Acción al presionar el boton de guardar del contenedor del archivo origen
    Private Sub BtnGuardarArchOrigen_Click(sender As Object, e As EventArgs) Handles BtnGuardarArchOrigen.Click
        Try
            'Crear el archivo de texto y escribir el contenido del TextBox en él
            My.Computer.FileSystem.WriteAllText(rutaArchivo, TxtOrigen.Text, False)
        Catch ex As Exception
            MsgBox("Error al guardar archvio, " & ex.Message, vbCritical)
        End Try
    End Sub

    'Acción al presionar Limpiar
    Private Sub BtnLimpiarCajaOrigen_Click(sender As Object, e As EventArgs) Handles BtnLimpiarCajaOrigen.Click
        TxtOrigen.Text = ""
    End Sub

    'Accion para regresar el contenido original del archivo origen siempre y cuando no se hayan guardado los cambios
    Private Sub BtnRegresarArchOrigen_Click(sender As Object, e As EventArgs) Handles BtnRegresarArchOrigen.Click
        Try
            TxtOrigen.Text = My.Computer.FileSystem.ReadAllText(rutaArchivo)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    'Acción que se realiza al precionar botón de Analizar 
    Private Sub BtnAnalizar_Click(sender As Object, e As EventArgs) Handles BtnAnalizar.Click
        LimpiarDGV()
        Try
            AnalizarLexico()
            AnalizarSintaxis()
        Catch ex As Exception

        End Try


        'Boton de editar documento origen se muestra y se habilita
        BtnEditar.Visible = True
        BtnEditar.Enabled = True
        LbAviso.Visible = True
    End Sub

    'Método que permite representar el archivo TXT destino a formato de tabla en el Data Grid View del formulario
    Public Sub DatosATabla()
        ' Define las columnas del DataGridView
        DGVArchicoDestino.ColumnCount = 5
        DGVArchicoDestino.Columns(0).Name = "Lexema"
        DGVArchicoDestino.Columns(1).Name = "Token"
        DGVArchicoDestino.Columns(2).Name = "P. en T."
        DGVArchicoDestino.Columns(3).Name = "Número de línea"
        DGVArchicoDestino.Columns(4).Name = "Tipo de dato"

        ' Abre el archivo de texto y lee los datos
        Dim file As System.IO.StreamReader
        file = My.Computer.FileSystem.OpenTextFileReader(My.Computer.FileSystem.SpecialDirectories.Desktop + "\Tabla de tokens.txt")

        Dim line As String
        Dim lineNumber As Integer = 0

        'Analiza el documento
        Do While file.Peek() >= 0
            lineNumber += 1
            line = file.ReadLine()

            ' Separa los datos de la línea utilizando el caracter de espacio (5) como delimitador
            Dim data() As String = line.Split("     ", StringSplitOptions.RemoveEmptyEntries)

            ' Agrega los datos a una nueva fila en el DataGridView
            Dim newRow As String() = {data(0), data(1), data(2), data(3), data(4)}
            DGVArchicoDestino.Rows.Add(newRow)
        Loop

        'Cierra el archivo
        file.Close()

        'Oculta columna que no sirve
        DGVArchicoDestino.RowHeadersVisible = False

        ' Anchura de las columnas definidas manualmente
        'DGVArchicoDestino.Columns(0).Width = 100
        'DGVArchicoDestino.Columns(1).Width = 100
        'DGVArchicoDestino.Columns(2).Width = 100
        'DGVArchicoDestino.Columns(3).Width = 100

    End Sub

    Private shouldHandleTab As Boolean = False

    Private Sub TxtOrigen_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtOrigen.KeyDown
        ' Verificar si se debe manejar el evento
        If shouldHandleTab AndAlso e.KeyCode = Keys.Tab Then
            ' Cancelar el evento para evitar que se procese de forma predeterminada
            e.SuppressKeyPress = True
            e.Handled = True
        End If
    End Sub

    Private Sub TxtOrigen_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles TxtOrigen.PreviewKeyDown
        ' Verificar si se presionó la tecla Tab
        If e.KeyCode = Keys.Tab Then
            ' Cancelar el evento para evitar que cambie el foco al siguiente elemento
            e.IsInputKey = True

            ' Verificar si no hay texto seleccionado
            If TxtOrigen.SelectionLength = 0 Then
                ' Agregar una tabulación al texto en el TextBox
                TxtOrigen.SelectedText = vbTab

                ' Controlar el manejo del evento
                shouldHandleTab = True
            End If
        Else
            ' Restablecer el control del manejo del evento
            shouldHandleTab = False
        End If
    End Sub

    Private Sub FrmPrincipal_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class