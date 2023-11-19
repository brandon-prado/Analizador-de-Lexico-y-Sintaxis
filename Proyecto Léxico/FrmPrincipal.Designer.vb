<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmPrincipal
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        components = New ComponentModel.Container()
        Dim DataGridViewCellStyle1 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim resources As ComponentModel.ComponentResourceManager = New ComponentModel.ComponentResourceManager(GetType(FrmPrincipal))
        MenuStrip1 = New MenuStrip()
        MenúToolStripMenuItem = New ToolStripMenuItem()
        AbrirArchivoToolStripMenuItem = New ToolStripMenuItem()
        NuevoArchivoOrigenToolStripMenuItem = New ToolStripMenuItem()
        SalirToolStripMenuItem = New ToolStripMenuItem()
        EditarToolStripMenuItem = New ToolStripMenuItem()
        EditarArchivoOrigenToolStripMenuItem = New ToolStripMenuItem()
        LiberarDocumentoToolStripMenuItem = New ToolStripMenuItem()
        AyudaToolStripMenuItem = New ToolStripMenuItem()
        AcercaDelProyectoToolStripMenuItem = New ToolStripMenuItem()
        PanelPrincipal = New Panel()
        LbResultadoSintaxis = New Label()
        Label5 = New Label()
        Label1 = New Label()
        DGVArchicoDestino = New DataGridView()
        LbAviso = New Label()
        Label4 = New Label()
        BtnEditar = New Button()
        BtnRegresarArchOrigen = New Button()
        BtnLimpiarCajaOrigen = New Button()
        BtnGuardarArchOrigen = New Button()
        Label3 = New Label()
        Label2 = New Label()
        BtnAnalizar = New Button()
        TxtOrigen = New TextBox()
        ToolTip1 = New ToolTip(components)
        MenuStrip1.SuspendLayout()
        PanelPrincipal.SuspendLayout()
        CType(DGVArchicoDestino, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' MenuStrip1
        ' 
        MenuStrip1.Items.AddRange(New ToolStripItem() {MenúToolStripMenuItem, EditarToolStripMenuItem, AyudaToolStripMenuItem})
        MenuStrip1.Location = New Point(0, 0)
        MenuStrip1.Name = "MenuStrip1"
        MenuStrip1.RenderMode = ToolStripRenderMode.Professional
        MenuStrip1.Size = New Size(1350, 24)
        MenuStrip1.TabIndex = 0
        MenuStrip1.Text = "MenuStrip1"
        ' 
        ' MenúToolStripMenuItem
        ' 
        MenúToolStripMenuItem.DropDownItems.AddRange(New ToolStripItem() {AbrirArchivoToolStripMenuItem, NuevoArchivoOrigenToolStripMenuItem, SalirToolStripMenuItem})
        MenúToolStripMenuItem.Name = "MenúToolStripMenuItem"
        MenúToolStripMenuItem.Size = New Size(60, 20)
        MenúToolStripMenuItem.Text = "Archivo"
        ' 
        ' AbrirArchivoToolStripMenuItem
        ' 
        AbrirArchivoToolStripMenuItem.Image = My.Resources.Resources.abrir
        AbrirArchivoToolStripMenuItem.Name = "AbrirArchivoToolStripMenuItem"
        AbrirArchivoToolStripMenuItem.Size = New Size(151, 22)
        AbrirArchivoToolStripMenuItem.Text = "Abrir archivo"
        ' 
        ' NuevoArchivoOrigenToolStripMenuItem
        ' 
        NuevoArchivoOrigenToolStripMenuItem.Image = My.Resources.Resources.archivo
        NuevoArchivoOrigenToolStripMenuItem.Name = "NuevoArchivoOrigenToolStripMenuItem"
        NuevoArchivoOrigenToolStripMenuItem.Size = New Size(151, 22)
        NuevoArchivoOrigenToolStripMenuItem.Text = "Nuevo archivo"
        ' 
        ' SalirToolStripMenuItem
        ' 
        SalirToolStripMenuItem.Image = My.Resources.Resources.salir
        SalirToolStripMenuItem.Name = "SalirToolStripMenuItem"
        SalirToolStripMenuItem.Size = New Size(151, 22)
        SalirToolStripMenuItem.Text = "Salir"
        ' 
        ' EditarToolStripMenuItem
        ' 
        EditarToolStripMenuItem.DropDownItems.AddRange(New ToolStripItem() {EditarArchivoOrigenToolStripMenuItem, LiberarDocumentoToolStripMenuItem})
        EditarToolStripMenuItem.Name = "EditarToolStripMenuItem"
        EditarToolStripMenuItem.Size = New Size(49, 20)
        EditarToolStripMenuItem.Text = "Editar"
        ' 
        ' EditarArchivoOrigenToolStripMenuItem
        ' 
        EditarArchivoOrigenToolStripMenuItem.Image = My.Resources.Resources.escoba
        EditarArchivoOrigenToolStripMenuItem.Name = "EditarArchivoOrigenToolStripMenuItem"
        EditarArchivoOrigenToolStripMenuItem.Size = New Size(175, 22)
        EditarArchivoOrigenToolStripMenuItem.Text = "Limpiar proceso"
        ' 
        ' LiberarDocumentoToolStripMenuItem
        ' 
        LiberarDocumentoToolStripMenuItem.Image = My.Resources.Resources.desbloquear
        LiberarDocumentoToolStripMenuItem.Name = "LiberarDocumentoToolStripMenuItem"
        LiberarDocumentoToolStripMenuItem.Size = New Size(175, 22)
        LiberarDocumentoToolStripMenuItem.Text = "Liberar documento"
        ' 
        ' AyudaToolStripMenuItem
        ' 
        AyudaToolStripMenuItem.DropDownItems.AddRange(New ToolStripItem() {AcercaDelProyectoToolStripMenuItem})
        AyudaToolStripMenuItem.Name = "AyudaToolStripMenuItem"
        AyudaToolStripMenuItem.Size = New Size(53, 20)
        AyudaToolStripMenuItem.Text = "Ayuda"
        ' 
        ' AcercaDelProyectoToolStripMenuItem
        ' 
        AcercaDelProyectoToolStripMenuItem.Image = My.Resources.Resources.info
        AcercaDelProyectoToolStripMenuItem.Name = "AcercaDelProyectoToolStripMenuItem"
        AcercaDelProyectoToolStripMenuItem.Size = New Size(184, 22)
        AcercaDelProyectoToolStripMenuItem.Text = "Acerca del programa"
        ' 
        ' PanelPrincipal
        ' 
        PanelPrincipal.Controls.Add(LbResultadoSintaxis)
        PanelPrincipal.Controls.Add(Label5)
        PanelPrincipal.Controls.Add(Label1)
        PanelPrincipal.Controls.Add(DGVArchicoDestino)
        PanelPrincipal.Controls.Add(LbAviso)
        PanelPrincipal.Controls.Add(Label4)
        PanelPrincipal.Controls.Add(BtnEditar)
        PanelPrincipal.Controls.Add(BtnRegresarArchOrigen)
        PanelPrincipal.Controls.Add(BtnLimpiarCajaOrigen)
        PanelPrincipal.Controls.Add(BtnGuardarArchOrigen)
        PanelPrincipal.Controls.Add(Label3)
        PanelPrincipal.Controls.Add(Label2)
        PanelPrincipal.Controls.Add(BtnAnalizar)
        PanelPrincipal.Controls.Add(TxtOrigen)
        PanelPrincipal.Location = New Point(0, 27)
        PanelPrincipal.Name = "PanelPrincipal"
        PanelPrincipal.Size = New Size(1350, 662)
        PanelPrincipal.TabIndex = 14
        ' 
        ' LbResultadoSintaxis
        ' 
        LbResultadoSintaxis.Font = New Font("Century Gothic", 11.25F, FontStyle.Bold, GraphicsUnit.Point)
        LbResultadoSintaxis.Location = New Point(58, 555)
        LbResultadoSintaxis.Name = "LbResultadoSintaxis"
        LbResultadoSintaxis.Size = New Size(465, 65)
        LbResultadoSintaxis.TabIndex = 27
        LbResultadoSintaxis.Text = "Abre un documento y presiona el botón de Analizar para conocer el resultado."
        ' 
        ' Label5
        ' 
        Label5.Font = New Font("Century Gothic", 15.75F, FontStyle.Bold, GraphicsUnit.Point)
        Label5.Location = New Point(57, 518)
        Label5.Name = "Label5"
        Label5.Size = New Size(465, 37)
        Label5.TabIndex = 26
        Label5.Text = "Sintaxis:"
        ' 
        ' Label1
        ' 
        Label1.Font = New Font("Century Gothic", 21.75F, FontStyle.Bold, GraphicsUnit.Point)
        Label1.Location = New Point(0, 0)
        Label1.Name = "Label1"
        Label1.Size = New Size(1350, 37)
        Label1.TabIndex = 17
        Label1.Text = "Analizador de Léxico y Sintaxis"
        Label1.TextAlign = ContentAlignment.TopCenter
        ' 
        ' DGVArchicoDestino
        ' 
        DGVArchicoDestino.AllowUserToAddRows = False
        DGVArchicoDestino.AllowUserToDeleteRows = False
        DGVArchicoDestino.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        DGVArchicoDestino.BackgroundColor = SystemColors.ControlLight
        DGVArchicoDestino.BorderStyle = BorderStyle.Fixed3D
        DGVArchicoDestino.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = SystemColors.Window
        DataGridViewCellStyle1.Font = New Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point)
        DataGridViewCellStyle1.ForeColor = SystemColors.ControlText
        DataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = DataGridViewTriState.False
        DGVArchicoDestino.DefaultCellStyle = DataGridViewCellStyle1
        DGVArchicoDestino.Location = New Point(683, 97)
        DGVArchicoDestino.Name = "DGVArchicoDestino"
        DGVArchicoDestino.ReadOnly = True
        DGVArchicoDestino.RowTemplate.Height = 25
        DGVArchicoDestino.Size = New Size(607, 472)
        DGVArchicoDestino.TabIndex = 25
        ' 
        ' LbAviso
        ' 
        LbAviso.Location = New Point(978, 586)
        LbAviso.Name = "LbAviso"
        LbAviso.Size = New Size(312, 34)
        LbAviso.TabIndex = 24
        LbAviso.Text = "El archivo generado ha sido guardado en el escritorio como archivo ""Tabla de tokens"" con extensión TXT."
        LbAviso.TextAlign = ContentAlignment.TopRight
        LbAviso.Visible = False
        ' 
        ' Label4
        ' 
        Label4.Location = New Point(541, 266)
        Label4.Name = "Label4"
        Label4.Size = New Size(120, 34)
        Label4.TabIndex = 23
        Label4.Text = "Analizar " & vbCrLf & "documento"
        Label4.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' BtnEditar
        ' 
        BtnEditar.BackgroundImage = My.Resources.Resources.documentediting_editdocuments_text_documentedi_2820
        BtnEditar.BackgroundImageLayout = ImageLayout.Stretch
        BtnEditar.Location = New Point(528, 446)
        BtnEditar.Name = "BtnEditar"
        BtnEditar.Size = New Size(30, 32)
        BtnEditar.TabIndex = 22
        BtnEditar.UseVisualStyleBackColor = True
        BtnEditar.Visible = False
        ' 
        ' BtnRegresarArchOrigen
        ' 
        BtnRegresarArchOrigen.BackgroundImage = My.Resources.Resources.atras
        BtnRegresarArchOrigen.BackgroundImageLayout = ImageLayout.Stretch
        BtnRegresarArchOrigen.Location = New Point(528, 408)
        BtnRegresarArchOrigen.Name = "BtnRegresarArchOrigen"
        BtnRegresarArchOrigen.Size = New Size(30, 32)
        BtnRegresarArchOrigen.TabIndex = 21
        BtnRegresarArchOrigen.UseVisualStyleBackColor = True
        BtnRegresarArchOrigen.Visible = False
        ' 
        ' BtnLimpiarCajaOrigen
        ' 
        BtnLimpiarCajaOrigen.BackgroundImage = My.Resources.Resources.escoba
        BtnLimpiarCajaOrigen.BackgroundImageLayout = ImageLayout.Stretch
        BtnLimpiarCajaOrigen.Location = New Point(528, 370)
        BtnLimpiarCajaOrigen.Name = "BtnLimpiarCajaOrigen"
        BtnLimpiarCajaOrigen.Size = New Size(30, 32)
        BtnLimpiarCajaOrigen.TabIndex = 20
        ToolTip1.SetToolTip(BtnLimpiarCajaOrigen, "Haz clic para limpiar el cuadro de texto de origen.")
        BtnLimpiarCajaOrigen.UseVisualStyleBackColor = True
        BtnLimpiarCajaOrigen.Visible = False
        ' 
        ' BtnGuardarArchOrigen
        ' 
        BtnGuardarArchOrigen.BackgroundImage = My.Resources.Resources.guardar
        BtnGuardarArchOrigen.BackgroundImageLayout = ImageLayout.Stretch
        BtnGuardarArchOrigen.Location = New Point(528, 332)
        BtnGuardarArchOrigen.Name = "BtnGuardarArchOrigen"
        BtnGuardarArchOrigen.Size = New Size(30, 32)
        BtnGuardarArchOrigen.TabIndex = 19
        ToolTip1.SetToolTip(BtnGuardarArchOrigen, "Haz clic para guardar las modificaciones en el archivo de origen.")
        BtnGuardarArchOrigen.UseVisualStyleBackColor = True
        BtnGuardarArchOrigen.Visible = False
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Location = New Point(683, 76)
        Label3.Name = "Label3"
        Label3.Size = New Size(95, 15)
        Label3.TabIndex = 18
        Label3.Text = "Tabla de Token's:"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Location = New Point(57, 76)
        Label2.Name = "Label2"
        Label2.Size = New Size(104, 15)
        Label2.TabIndex = 17
        Label2.Text = "Archivo de origen:"
        ' 
        ' BtnAnalizar
        ' 
        BtnAnalizar.BackgroundImage = My.Resources.Resources.analizar
        BtnAnalizar.BackgroundImageLayout = ImageLayout.Stretch
        BtnAnalizar.Enabled = False
        BtnAnalizar.Location = New Point(563, 188)
        BtnAnalizar.Name = "BtnAnalizar"
        BtnAnalizar.Size = New Size(75, 75)
        BtnAnalizar.TabIndex = 15
        BtnAnalizar.UseVisualStyleBackColor = True
        ' 
        ' TxtOrigen
        ' 
        TxtOrigen.Enabled = False
        TxtOrigen.Location = New Point(58, 97)
        TxtOrigen.Multiline = True
        TxtOrigen.Name = "TxtOrigen"
        TxtOrigen.ScrollBars = ScrollBars.Both
        TxtOrigen.Size = New Size(464, 381)
        TxtOrigen.TabIndex = 14
        ' 
        ' FrmPrincipal
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1350, 681)
        Controls.Add(PanelPrincipal)
        Controls.Add(MenuStrip1)
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        MainMenuStrip = MenuStrip1
        Name = "FrmPrincipal"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Proyecto de Léxico y Sintaxis"
        MenuStrip1.ResumeLayout(False)
        MenuStrip1.PerformLayout()
        PanelPrincipal.ResumeLayout(False)
        PanelPrincipal.PerformLayout()
        CType(DGVArchicoDestino, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents MenúToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AbrirArchivoToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents NuevoArchivoOrigenToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SalirToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents EditarToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents EditarArchivoOrigenToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents LiberarDocumentoToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AyudaToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AcercaDelProyectoToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents PanelPrincipal As Panel
    Friend WithEvents DGVArchicoDestino As DataGridView
    Friend WithEvents LbAviso As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents BtnEditar As Button
    Friend WithEvents BtnRegresarArchOrigen As Button
    Friend WithEvents BtnLimpiarCajaOrigen As Button
    Friend WithEvents ToolTip1 As ToolTip
    Friend WithEvents BtnGuardarArchOrigen As Button
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents BtnAnalizar As Button
    Friend WithEvents TxtOrigen As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents LbResultadoSintaxis As Label
    Friend WithEvents Label5 As Label
End Class
