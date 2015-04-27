<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.AddFileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.SaveAsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.DeleteSelectedImageToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.SwitchImagesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.dynamicDotNetTwain1 = New Dynamsoft.DotNet.TWAIN.DynamicDotNetTwain
        Me.fileList = New System.Windows.Forms.ListBox
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(503, 24)
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AddFileToolStripMenuItem, Me.SaveAsToolStripMenuItem, Me.DeleteSelectedImageToolStripMenuItem, Me.SwitchImagesToolStripMenuItem, Me.ToolStripSeparator1, Me.ExitToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(35, 20)
        Me.FileToolStripMenuItem.Text = "&File"
        '
        'AddFileToolStripMenuItem
        '
        Me.AddFileToolStripMenuItem.Name = "AddFileToolStripMenuItem"
        Me.AddFileToolStripMenuItem.Size = New System.Drawing.Size(182, 22)
        Me.AddFileToolStripMenuItem.Text = "&Add File..."
        '
        'SaveAsToolStripMenuItem
        '
        Me.SaveAsToolStripMenuItem.Name = "SaveAsToolStripMenuItem"
        Me.SaveAsToolStripMenuItem.Size = New System.Drawing.Size(182, 22)
        Me.SaveAsToolStripMenuItem.Text = "&Save As..."
        '
        'DeleteSelectedImageToolStripMenuItem
        '
        Me.DeleteSelectedImageToolStripMenuItem.Name = "DeleteSelectedImageToolStripMenuItem"
        Me.DeleteSelectedImageToolStripMenuItem.Size = New System.Drawing.Size(182, 22)
        Me.DeleteSelectedImageToolStripMenuItem.Text = "&Delete Selected Image"
        '
        'SwitchImagesToolStripMenuItem
        '
        Me.SwitchImagesToolStripMenuItem.Name = "SwitchImagesToolStripMenuItem"
        Me.SwitchImagesToolStripMenuItem.Size = New System.Drawing.Size(182, 22)
        Me.SwitchImagesToolStripMenuItem.Text = "S&witch Images"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(179, 6)
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(182, 22)
        Me.ExitToolStripMenuItem.Text = "&Exit"
        '
        'dynamicDotNetTwain1
        '
        Me.dynamicDotNetTwain1.AnnotationFillColor = System.Drawing.Color.White
        Me.dynamicDotNetTwain1.AnnotationPen = Nothing
        Me.dynamicDotNetTwain1.AnnotationTextColor = System.Drawing.Color.Black
        Me.dynamicDotNetTwain1.AnnotationTextFont = Nothing
        Me.dynamicDotNetTwain1.HookMessage = True
        Me.dynamicDotNetTwain1.Location = New System.Drawing.Point(12, 27)
        Me.dynamicDotNetTwain1.LogLevel = CType(0, Short)
        Me.dynamicDotNetTwain1.Name = "dynamicDotNetTwain1"
        Me.dynamicDotNetTwain1.PDFMarginBottom = CType(0UI, UInteger)
        Me.dynamicDotNetTwain1.PDFMarginLeft = CType(0UI, UInteger)
        Me.dynamicDotNetTwain1.PDFMarginRight = CType(0UI, UInteger)
        Me.dynamicDotNetTwain1.PDFMarginTop = CType(0UI, UInteger)
        Me.dynamicDotNetTwain1.Size = New System.Drawing.Size(331, 410)
        Me.dynamicDotNetTwain1.TabIndex = 1
        '
        'fileList
        '
        Me.fileList.FormattingEnabled = True
        Me.fileList.Location = New System.Drawing.Point(350, 28)
        Me.fileList.Name = "fileList"
        Me.fileList.Size = New System.Drawing.Size(141, 407)
        Me.fileList.TabIndex = 2
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(503, 449)
        Me.Controls.Add(Me.fileList)
        Me.Controls.Add(Me.dynamicDotNetTwain1)
        Me.Controls.Add(Me.MenuStrip1)
	Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
	Me.MaximizeBox = False
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "Form1"
        Me.Text = "Tiff Manipulator"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents dynamicDotNetTwain1 As Dynamsoft.DotNet.TWAIN.DynamicDotNetTwain
    Friend WithEvents fileList As System.Windows.Forms.ListBox
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AddFileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SaveAsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DeleteSelectedImageToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SwitchImagesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem

End Class
