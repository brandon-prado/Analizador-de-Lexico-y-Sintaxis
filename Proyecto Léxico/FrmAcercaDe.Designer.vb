<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmAcercaDe
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmAcercaDe))
        PictureBox1 = New PictureBox()
        Label1 = New Label()
        Label2 = New Label()
        Label3 = New Label()
        Label4 = New Label()
        PictureBox2 = New PictureBox()
        CType(PictureBox1, ComponentModel.ISupportInitialize).BeginInit()
        CType(PictureBox2, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' PictureBox1
        ' 
        PictureBox1.Image = My.Resources.Resources.tecnm_its
        PictureBox1.Location = New Point(0, 2)
        PictureBox1.Name = "PictureBox1"
        PictureBox1.Size = New Size(490, 61)
        PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage
        PictureBox1.TabIndex = 0
        PictureBox1.TabStop = False
        ' 
        ' Label1
        ' 
        Label1.Font = New Font("Century Gothic", 21.75F, FontStyle.Bold, GraphicsUnit.Point)
        Label1.ForeColor = Color.OrangeRed
        Label1.Location = New Point(0, 193)
        Label1.Name = "Label1"
        Label1.Size = New Size(490, 37)
        Label1.TabIndex = 5
        Label1.Text = "Lenguajes y Autómatas I" & vbCrLf & vbCrLf
        Label1.TextAlign = ContentAlignment.TopCenter
        ' 
        ' Label2
        ' 
        Label2.Font = New Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point)
        Label2.ForeColor = Color.Black
        Label2.Location = New Point(0, 254)
        Label2.Name = "Label2"
        Label2.Size = New Size(490, 87)
        Label2.TabIndex = 6
        Label2.Text = "Impartida por:" & vbCrLf & vbCrLf & "MC. Juan Fraustro de la O." & vbCrLf
        Label2.TextAlign = ContentAlignment.TopCenter
        ' 
        ' Label3
        ' 
        Label3.Font = New Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point)
        Label3.ForeColor = Color.Black
        Label3.Location = New Point(0, 342)
        Label3.Name = "Label3"
        Label3.Size = New Size(490, 116)
        Label3.TabIndex = 7
        Label3.Text = "Alumno:" & vbCrLf & vbCrLf & "- Brandon Alexis Prado Castro, 19051178."
        Label3.TextAlign = ContentAlignment.TopCenter
        ' 
        ' Label4
        ' 
        Label4.Font = New Font("Century Gothic", 9.75F, FontStyle.Bold, GraphicsUnit.Point)
        Label4.ForeColor = Color.Black
        Label4.Location = New Point(0, 487)
        Label4.Name = "Label4"
        Label4.Size = New Size(490, 22)
        Label4.TabIndex = 8
        Label4.Text = "© 2.0 mayo de 2023"
        Label4.TextAlign = ContentAlignment.TopCenter
        ' 
        ' PictureBox2
        ' 
        PictureBox2.Image = My.Resources.Resources.tecSaltillo
        PictureBox2.Location = New Point(140, 59)
        PictureBox2.Name = "PictureBox2"
        PictureBox2.Size = New Size(207, 191)
        PictureBox2.SizeMode = PictureBoxSizeMode.StretchImage
        PictureBox2.TabIndex = 9
        PictureBox2.TabStop = False
        ' 
        ' FrmAcercaDe
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.White
        ClientSize = New Size(491, 507)
        Controls.Add(Label1)
        Controls.Add(PictureBox2)
        Controls.Add(Label4)
        Controls.Add(Label3)
        Controls.Add(Label2)
        Controls.Add(PictureBox1)
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        MaximizeBox = False
        Name = "FrmAcercaDe"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Acerca del programa"
        TopMost = True
        CType(PictureBox1, ComponentModel.ISupportInitialize).EndInit()
        CType(PictureBox2, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
    End Sub

    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents PictureBox2 As PictureBox
End Class
