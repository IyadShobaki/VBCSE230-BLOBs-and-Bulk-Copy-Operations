<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CreateToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CreateDocumentStorageTableToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SaveToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SaveBLOBToDatabseToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.FetchToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.FetchBLOBFromDatabaseToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BLOBList = New System.Windows.Forms.ComboBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.MenuStrip1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.CreateToolStripMenuItem, Me.SaveToolStripMenuItem, Me.FetchToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1643, 28)
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ExitToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(44, 24)
        Me.FileToolStripMenuItem.Text = "File"
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(108, 26)
        Me.ExitToolStripMenuItem.Text = "Exit"
        '
        'CreateToolStripMenuItem
        '
        Me.CreateToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CreateDocumentStorageTableToolStripMenuItem})
        Me.CreateToolStripMenuItem.Name = "CreateToolStripMenuItem"
        Me.CreateToolStripMenuItem.Size = New System.Drawing.Size(64, 24)
        Me.CreateToolStripMenuItem.Text = "Create"
        '
        'CreateDocumentStorageTableToolStripMenuItem
        '
        Me.CreateDocumentStorageTableToolStripMenuItem.Name = "CreateDocumentStorageTableToolStripMenuItem"
        Me.CreateDocumentStorageTableToolStripMenuItem.Size = New System.Drawing.Size(295, 26)
        Me.CreateDocumentStorageTableToolStripMenuItem.Text = "Create Document Storage Table"
        '
        'SaveToolStripMenuItem
        '
        Me.SaveToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SaveBLOBToDatabseToolStripMenuItem})
        Me.SaveToolStripMenuItem.Name = "SaveToolStripMenuItem"
        Me.SaveToolStripMenuItem.Size = New System.Drawing.Size(52, 24)
        Me.SaveToolStripMenuItem.Text = "Save"
        '
        'SaveBLOBToDatabseToolStripMenuItem
        '
        Me.SaveBLOBToDatabseToolStripMenuItem.Name = "SaveBLOBToDatabseToolStripMenuItem"
        Me.SaveBLOBToDatabseToolStripMenuItem.Size = New System.Drawing.Size(239, 26)
        Me.SaveBLOBToDatabseToolStripMenuItem.Text = "Save BLOB to Database"
        '
        'FetchToolStripMenuItem
        '
        Me.FetchToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FetchBLOBFromDatabaseToolStripMenuItem})
        Me.FetchToolStripMenuItem.Name = "FetchToolStripMenuItem"
        Me.FetchToolStripMenuItem.Size = New System.Drawing.Size(56, 24)
        Me.FetchToolStripMenuItem.Text = "Fetch"
        '
        'FetchBLOBFromDatabaseToolStripMenuItem
        '
        Me.FetchBLOBFromDatabaseToolStripMenuItem.Name = "FetchBLOBFromDatabaseToolStripMenuItem"
        Me.FetchBLOBFromDatabaseToolStripMenuItem.Size = New System.Drawing.Size(261, 26)
        Me.FetchBLOBFromDatabaseToolStripMenuItem.Text = "Fetch BLOB from Database"
        '
        'BLOBList
        '
        Me.BLOBList.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BLOBList.FormattingEnabled = True
        Me.BLOBList.Location = New System.Drawing.Point(31, 44)
        Me.BLOBList.Name = "BLOBList"
        Me.BLOBList.Size = New System.Drawing.Size(331, 33)
        Me.BLOBList.TabIndex = 1
        '
        'PictureBox1
        '
        Me.PictureBox1.Location = New System.Drawing.Point(31, 105)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(1549, 632)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 2
        Me.PictureBox1.TabStop = False
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1643, 793)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.BLOBList)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "Form1"
        Me.Text = "Shobaki-BLOBLab"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents FileToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CreateToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CreateDocumentStorageTableToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SaveToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SaveBLOBToDatabseToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents FetchToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents FetchBLOBFromDatabaseToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents BLOBList As ComboBox
    Friend WithEvents PictureBox1 As PictureBox
End Class
