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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.menuStrip = New System.Windows.Forms.MenuStrip
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.OpenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.SaveToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.PrintToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.AnnotationToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.CreateToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.LineToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.EllipseToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.RectangleToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.TextToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.DeleteSelectedToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.DeleteAllToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.CopySelectedToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.PasteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ChangePositionToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.BringToFrontToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.SendToBackToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.toolStrip = New System.Windows.Forms.ToolStrip
        Me.ToolStripBtnLAnnotation = New System.Windows.Forms.ToolStripButton
        Me.ToolStripBtnEAnnotation = New System.Windows.Forms.ToolStripButton
        Me.ToolStripBtnRAnnotation = New System.Windows.Forms.ToolStripButton
        Me.ToolStripBtnTAnnotation = New System.Windows.Forms.ToolStripButton
        Me.toolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.toolStripFill = New System.Windows.Forms.ToolStripLabel
        Me.toolStripBtnFill = New System.Windows.Forms.ToolStripButton
        Me.toolStripPen = New System.Windows.Forms.ToolStripLabel
        Me.toolStripBtnPen = New System.Windows.Forms.ToolStripButton
        Me.toolStripCbxPen = New System.Windows.Forms.ToolStripComboBox
        Me.toolStripFont = New System.Windows.Forms.ToolStripLabel
        Me.toolStripBtnFont = New System.Windows.Forms.ToolStripButton
        Me.toolStripCbxFont = New System.Windows.Forms.ToolStripComboBox
        Me.toolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.toolStripBtnDelete = New System.Windows.Forms.ToolStripButton
        Me.toolStripBtnDeleteAll = New System.Windows.Forms.ToolStripButton
        Me.toolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator
        Me.toolStripBtnBringToBack = New System.Windows.Forms.ToolStripButton
        Me.toolStripBtnBringToFront = New System.Windows.Forms.ToolStripButton
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer
        Me.DynamicDotNetTwain1 = New Dynamsoft.DotNet.TWAIN.DynamicDotNetTwain
        Me.PropertyGrid1 = New System.Windows.Forms.PropertyGrid
        Me.dlgColor = New System.Windows.Forms.ColorDialog
        Me.menuStrip.SuspendLayout()
        Me.toolStrip.SuspendLayout()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.SuspendLayout()
        '
        'menuStrip
        '
        Me.menuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.AnnotationToolStripMenuItem})
        Me.menuStrip.Location = New System.Drawing.Point(0, 0)
        Me.menuStrip.Name = "menuStrip"
        Me.menuStrip.Size = New System.Drawing.Size(925, 24)
        Me.menuStrip.TabIndex = 0
        Me.menuStrip.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.OpenToolStripMenuItem, Me.SaveToolStripMenuItem, Me.PrintToolStripMenuItem, Me.ExitToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
        Me.FileToolStripMenuItem.Text = "&File"
        '
        'OpenToolStripMenuItem
        '
        Me.OpenToolStripMenuItem.Name = "OpenToolStripMenuItem"
        Me.OpenToolStripMenuItem.Size = New System.Drawing.Size(112, 22)
        Me.OpenToolStripMenuItem.Text = "&Open..."
        '
        'SaveToolStripMenuItem
        '
        Me.SaveToolStripMenuItem.Name = "SaveToolStripMenuItem"
        Me.SaveToolStripMenuItem.Size = New System.Drawing.Size(112, 22)
        Me.SaveToolStripMenuItem.Text = "&Save..."
        '
        'PrintToolStripMenuItem
        '
        Me.PrintToolStripMenuItem.Name = "PrintToolStripMenuItem"
        Me.PrintToolStripMenuItem.Size = New System.Drawing.Size(112, 22)
        Me.PrintToolStripMenuItem.Text = "&Print..."
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(112, 22)
        Me.ExitToolStripMenuItem.Text = "&Exit"
        '
        'AnnotationToolStripMenuItem
        '
        Me.AnnotationToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CreateToolStripMenuItem, Me.DeleteSelectedToolStripMenuItem, Me.DeleteAllToolStripMenuItem, Me.CopySelectedToolStripMenuItem, Me.PasteToolStripMenuItem, Me.ChangePositionToolStripMenuItem})
        Me.AnnotationToolStripMenuItem.Name = "AnnotationToolStripMenuItem"
        Me.AnnotationToolStripMenuItem.Size = New System.Drawing.Size(79, 20)
        Me.AnnotationToolStripMenuItem.Text = "&Annotation"
        '
        'CreateToolStripMenuItem
        '
        Me.CreateToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.LineToolStripMenuItem, Me.EllipseToolStripMenuItem, Me.RectangleToolStripMenuItem, Me.TextToolStripMenuItem})
        Me.CreateToolStripMenuItem.Name = "CreateToolStripMenuItem"
        Me.CreateToolStripMenuItem.Size = New System.Drawing.Size(161, 22)
        Me.CreateToolStripMenuItem.Text = "&Create"
        '
        'LineToolStripMenuItem
        '
        Me.LineToolStripMenuItem.Name = "LineToolStripMenuItem"
        Me.LineToolStripMenuItem.Size = New System.Drawing.Size(126, 22)
        Me.LineToolStripMenuItem.Text = "&Line"
        '
        'EllipseToolStripMenuItem
        '
        Me.EllipseToolStripMenuItem.Name = "EllipseToolStripMenuItem"
        Me.EllipseToolStripMenuItem.Size = New System.Drawing.Size(126, 22)
        Me.EllipseToolStripMenuItem.Text = "&Ellipse"
        '
        'RectangleToolStripMenuItem
        '
        Me.RectangleToolStripMenuItem.Name = "RectangleToolStripMenuItem"
        Me.RectangleToolStripMenuItem.Size = New System.Drawing.Size(126, 22)
        Me.RectangleToolStripMenuItem.Text = "&Rectangle"
        '
        'TextToolStripMenuItem
        '
        Me.TextToolStripMenuItem.Name = "TextToolStripMenuItem"
        Me.TextToolStripMenuItem.Size = New System.Drawing.Size(126, 22)
        Me.TextToolStripMenuItem.Text = "&Text"
        '
        'DeleteSelectedToolStripMenuItem
        '
        Me.DeleteSelectedToolStripMenuItem.Name = "DeleteSelectedToolStripMenuItem"
        Me.DeleteSelectedToolStripMenuItem.Size = New System.Drawing.Size(161, 22)
        Me.DeleteSelectedToolStripMenuItem.Text = "&Delete Selected"
        '
        'DeleteAllToolStripMenuItem
        '
        Me.DeleteAllToolStripMenuItem.Name = "DeleteAllToolStripMenuItem"
        Me.DeleteAllToolStripMenuItem.Size = New System.Drawing.Size(161, 22)
        Me.DeleteAllToolStripMenuItem.Text = "Delete &All"
        '
        'CopySelectedToolStripMenuItem
        '
        Me.CopySelectedToolStripMenuItem.Name = "CopySelectedToolStripMenuItem"
        Me.CopySelectedToolStripMenuItem.Size = New System.Drawing.Size(161, 22)
        Me.CopySelectedToolStripMenuItem.Text = "C&opy Selected"
        '
        'PasteToolStripMenuItem
        '
        Me.PasteToolStripMenuItem.Name = "PasteToolStripMenuItem"
        Me.PasteToolStripMenuItem.Size = New System.Drawing.Size(161, 22)
        Me.PasteToolStripMenuItem.Text = "&Paste"
        '
        'ChangePositionToolStripMenuItem
        '
        Me.ChangePositionToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BringToFrontToolStripMenuItem, Me.SendToBackToolStripMenuItem})
        Me.ChangePositionToolStripMenuItem.Name = "ChangePositionToolStripMenuItem"
        Me.ChangePositionToolStripMenuItem.Size = New System.Drawing.Size(161, 22)
        Me.ChangePositionToolStripMenuItem.Text = "C&hange Position"
        '
        'BringToFrontToolStripMenuItem
        '
        Me.BringToFrontToolStripMenuItem.Name = "BringToFrontToolStripMenuItem"
        Me.BringToFrontToolStripMenuItem.Size = New System.Drawing.Size(147, 22)
        Me.BringToFrontToolStripMenuItem.Text = "Bring to &Front"
        '
        'SendToBackToolStripMenuItem
        '
        Me.SendToBackToolStripMenuItem.Name = "SendToBackToolStripMenuItem"
        Me.SendToBackToolStripMenuItem.Size = New System.Drawing.Size(147, 22)
        Me.SendToBackToolStripMenuItem.Text = "Send to &Back"
        '
        'toolStrip
        '
        Me.toolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripBtnLAnnotation, Me.ToolStripBtnEAnnotation, Me.ToolStripBtnRAnnotation, Me.ToolStripBtnTAnnotation, Me.toolStripSeparator1, Me.toolStripFill, Me.toolStripBtnFill, Me.toolStripPen, Me.toolStripBtnPen, Me.toolStripCbxPen, Me.toolStripFont, Me.toolStripBtnFont, Me.toolStripCbxFont, Me.toolStripSeparator2, Me.toolStripBtnDelete, Me.toolStripBtnDeleteAll, Me.toolStripSeparator3, Me.toolStripBtnBringToBack, Me.toolStripBtnBringToFront})
        Me.toolStrip.Location = New System.Drawing.Point(0, 24)
        Me.toolStrip.Name = "toolStrip"
        Me.toolStrip.Size = New System.Drawing.Size(925, 25)
        Me.toolStrip.TabIndex = 1
        Me.toolStrip.Text = "ToolStrip1"
        '
        'ToolStripBtnLAnnotation
        '
        Me.ToolStripBtnLAnnotation.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripBtnLAnnotation.Image = CType(resources.GetObject("ToolStripBtnLAnnotation.Image"), System.Drawing.Image)
        Me.ToolStripBtnLAnnotation.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripBtnLAnnotation.Name = "ToolStripBtnLAnnotation"
        Me.ToolStripBtnLAnnotation.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripBtnLAnnotation.Text = "ToolStripButton1"
        Me.ToolStripBtnLAnnotation.ToolTipText = "Line"
        '
        'ToolStripBtnEAnnotation
        '
        Me.ToolStripBtnEAnnotation.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripBtnEAnnotation.Image = CType(resources.GetObject("ToolStripBtnEAnnotation.Image"), System.Drawing.Image)
        Me.ToolStripBtnEAnnotation.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripBtnEAnnotation.Name = "ToolStripBtnEAnnotation"
        Me.ToolStripBtnEAnnotation.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripBtnEAnnotation.Text = "ToolStripButton2"
        Me.ToolStripBtnEAnnotation.ToolTipText = "Ellipse"
        '
        'ToolStripBtnRAnnotation
        '
        Me.ToolStripBtnRAnnotation.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripBtnRAnnotation.Image = CType(resources.GetObject("ToolStripBtnRAnnotation.Image"), System.Drawing.Image)
        Me.ToolStripBtnRAnnotation.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripBtnRAnnotation.Name = "ToolStripBtnRAnnotation"
        Me.ToolStripBtnRAnnotation.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripBtnRAnnotation.Text = "ToolStripButton3"
        Me.ToolStripBtnRAnnotation.ToolTipText = "Rectangle"
        '
        'ToolStripBtnTAnnotation
        '
        Me.ToolStripBtnTAnnotation.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripBtnTAnnotation.Image = CType(resources.GetObject("ToolStripBtnTAnnotation.Image"), System.Drawing.Image)
        Me.ToolStripBtnTAnnotation.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripBtnTAnnotation.Name = "ToolStripBtnTAnnotation"
        Me.ToolStripBtnTAnnotation.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripBtnTAnnotation.Text = "ToolStripButton4"
        Me.ToolStripBtnTAnnotation.ToolTipText = "Text"
        '
        'toolStripSeparator1
        '
        Me.toolStripSeparator1.Name = "toolStripSeparator1"
        Me.toolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'toolStripFill
        '
        Me.toolStripFill.Name = "toolStripFill"
        Me.toolStripFill.Size = New System.Drawing.Size(22, 22)
        Me.toolStripFill.Text = "Fill"
        '
        'toolStripBtnFill
        '
        Me.toolStripBtnFill.AutoSize = False
        Me.toolStripBtnFill.BackColor = System.Drawing.Color.Yellow
        Me.toolStripBtnFill.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolStripBtnFill.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolStripBtnFill.Name = "toolStripBtnFill"
        Me.toolStripBtnFill.Size = New System.Drawing.Size(23, 22)
        Me.toolStripBtnFill.Text = "toolStripButton1"
        Me.toolStripBtnFill.ToolTipText = "Fill Color"
        '
        'toolStripPen
        '
        Me.toolStripPen.Name = "toolStripPen"
        Me.toolStripPen.Size = New System.Drawing.Size(27, 22)
        Me.toolStripPen.Text = "Pen"
        '
        'toolStripBtnPen
        '
        Me.toolStripBtnPen.BackColor = System.Drawing.Color.Blue
        Me.toolStripBtnPen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolStripBtnPen.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolStripBtnPen.Name = "toolStripBtnPen"
        Me.toolStripBtnPen.Size = New System.Drawing.Size(23, 22)
        Me.toolStripBtnPen.Text = "toolStripButton1"
        Me.toolStripBtnPen.ToolTipText = "Pen Color"
        '
        'toolStripCbxPen
        '
        Me.toolStripCbxPen.AutoSize = False
        Me.toolStripCbxPen.Items.AddRange(New Object() {"1", "2", "3", "4", "5", "6", "7", "8", "9"})
        Me.toolStripCbxPen.Name = "toolStripCbxPen"
        Me.toolStripCbxPen.Size = New System.Drawing.Size(60, 23)
        Me.toolStripCbxPen.ToolTipText = "Pen Width"
        '
        'toolStripFont
        '
        Me.toolStripFont.Name = "toolStripFont"
        Me.toolStripFont.Size = New System.Drawing.Size(31, 22)
        Me.toolStripFont.Text = "Font"
        '
        'toolStripBtnFont
        '
        Me.toolStripBtnFont.BackColor = System.Drawing.Color.Black
        Me.toolStripBtnFont.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolStripBtnFont.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolStripBtnFont.Name = "toolStripBtnFont"
        Me.toolStripBtnFont.Size = New System.Drawing.Size(23, 22)
        Me.toolStripBtnFont.Text = "toolStripButton1"
        Me.toolStripBtnFont.ToolTipText = "Font Color"
        '
        'toolStripCbxFont
        '
        Me.toolStripCbxFont.AutoSize = False
        Me.toolStripCbxFont.Items.AddRange(New Object() {"20", "22", "24", "26", "28", "30", "32", "34", "36"})
        Me.toolStripCbxFont.Name = "toolStripCbxFont"
        Me.toolStripCbxFont.Size = New System.Drawing.Size(60, 23)
        Me.toolStripCbxFont.ToolTipText = "Font Size"
        '
        'toolStripSeparator2
        '
        Me.toolStripSeparator2.Name = "toolStripSeparator2"
        Me.toolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'toolStripBtnDelete
        '
        Me.toolStripBtnDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolStripBtnDelete.Image = CType(resources.GetObject("toolStripBtnDelete.Image"), System.Drawing.Image)
        Me.toolStripBtnDelete.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolStripBtnDelete.Name = "toolStripBtnDelete"
        Me.toolStripBtnDelete.Size = New System.Drawing.Size(23, 22)
        Me.toolStripBtnDelete.Text = "toolStripButton1"
        Me.toolStripBtnDelete.ToolTipText = "Delete Selected"
        '
        'toolStripBtnDeleteAll
        '
        Me.toolStripBtnDeleteAll.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolStripBtnDeleteAll.Image = CType(resources.GetObject("toolStripBtnDeleteAll.Image"), System.Drawing.Image)
        Me.toolStripBtnDeleteAll.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolStripBtnDeleteAll.Name = "toolStripBtnDeleteAll"
        Me.toolStripBtnDeleteAll.Size = New System.Drawing.Size(23, 22)
        Me.toolStripBtnDeleteAll.Text = "toolStripButton2"
        Me.toolStripBtnDeleteAll.ToolTipText = "Delete All"
        '
        'toolStripSeparator3
        '
        Me.toolStripSeparator3.Name = "toolStripSeparator3"
        Me.toolStripSeparator3.Size = New System.Drawing.Size(6, 25)
        '
        'toolStripBtnBringToBack
        '
        Me.toolStripBtnBringToBack.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolStripBtnBringToBack.Image = CType(resources.GetObject("toolStripBtnBringToBack.Image"), System.Drawing.Image)
        Me.toolStripBtnBringToBack.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolStripBtnBringToBack.Name = "toolStripBtnBringToBack"
        Me.toolStripBtnBringToBack.Size = New System.Drawing.Size(23, 22)
        Me.toolStripBtnBringToBack.Text = "toolStripButton1"
        Me.toolStripBtnBringToBack.ToolTipText = "Push To Back"
        '
        'toolStripBtnBringToFront
        '
        Me.toolStripBtnBringToFront.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolStripBtnBringToFront.Image = CType(resources.GetObject("toolStripBtnBringToFront.Image"), System.Drawing.Image)
        Me.toolStripBtnBringToFront.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolStripBtnBringToFront.Name = "toolStripBtnBringToFront"
        Me.toolStripBtnBringToFront.Size = New System.Drawing.Size(23, 22)
        Me.toolStripBtnBringToFront.Text = "toolStripButton2"
        Me.toolStripBtnBringToFront.ToolTipText = "Bring To Front"
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 49)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.DynamicDotNetTwain1)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.PropertyGrid1)
        Me.SplitContainer1.Size = New System.Drawing.Size(925, 382)
        Me.SplitContainer1.SplitterDistance = 709
        Me.SplitContainer1.TabIndex = 2
        '
        'DynamicDotNetTwain1
        '
        Me.DynamicDotNetTwain1.AnnotationFillColor = System.Drawing.Color.White
        Me.DynamicDotNetTwain1.AnnotationPen = Nothing
        Me.DynamicDotNetTwain1.AnnotationTextColor = System.Drawing.Color.Black
        Me.DynamicDotNetTwain1.AnnotationTextFont = Nothing
        Me.DynamicDotNetTwain1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DynamicDotNetTwain1.IfShowPrintUI = False
        Me.DynamicDotNetTwain1.IfThrowException = False
        Me.DynamicDotNetTwain1.Location = New System.Drawing.Point(0, 0)
        Me.DynamicDotNetTwain1.LogLevel = CType(0, Short)
        Me.DynamicDotNetTwain1.Name = "DynamicDotNetTwain1"
        Me.DynamicDotNetTwain1.PDFMarginBottom = CType(0UI, UInteger)
        Me.DynamicDotNetTwain1.PDFMarginLeft = CType(0UI, UInteger)
        Me.DynamicDotNetTwain1.PDFMarginRight = CType(0UI, UInteger)
        Me.DynamicDotNetTwain1.PDFMarginTop = CType(0UI, UInteger)
        Me.DynamicDotNetTwain1.PDFXConformance = CType(0UI, UInteger)
        Me.DynamicDotNetTwain1.Size = New System.Drawing.Size(709, 382)
        Me.DynamicDotNetTwain1.TabIndex = 0
        '
        'PropertyGrid1
        '
        Me.PropertyGrid1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PropertyGrid1.Location = New System.Drawing.Point(0, 0)
        Me.PropertyGrid1.Name = "PropertyGrid1"
        Me.PropertyGrid1.Size = New System.Drawing.Size(212, 382)
        Me.PropertyGrid1.TabIndex = 0
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(925, 431)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.toolStrip)
        Me.Controls.Add(Me.menuStrip)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MainMenuStrip = Me.menuStrip
        Me.MaximizeBox = False
        Me.Name = "Form1"
        Me.Text = "Annotation Sample"
        Me.menuStrip.ResumeLayout(False)
        Me.menuStrip.PerformLayout()
        Me.toolStrip.ResumeLayout(False)
        Me.toolStrip.PerformLayout()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents menuStrip As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OpenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SaveToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PrintToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AnnotationToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CreateToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents LineToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DeleteSelectedToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DeleteAllToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CopySelectedToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PasteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ChangePositionToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BringToFrontToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SendToBackToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EllipseToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RectangleToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TextToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents toolStrip As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripBtnLAnnotation As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripBtnEAnnotation As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripBtnRAnnotation As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripBtnTAnnotation As System.Windows.Forms.ToolStripButton
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents DynamicDotNetTwain1 As Dynamsoft.DotNet.TWAIN.DynamicDotNetTwain
    Friend WithEvents PropertyGrid1 As System.Windows.Forms.PropertyGrid
    Private WithEvents toolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Private WithEvents toolStripFill As System.Windows.Forms.ToolStripLabel
    Private WithEvents toolStripBtnFill As System.Windows.Forms.ToolStripButton
    Private WithEvents toolStripPen As System.Windows.Forms.ToolStripLabel
    Private WithEvents toolStripBtnPen As System.Windows.Forms.ToolStripButton
    Private WithEvents toolStripCbxPen As System.Windows.Forms.ToolStripComboBox
    Private WithEvents toolStripFont As System.Windows.Forms.ToolStripLabel
    Private WithEvents toolStripBtnFont As System.Windows.Forms.ToolStripButton
    Private WithEvents toolStripCbxFont As System.Windows.Forms.ToolStripComboBox
    Private WithEvents toolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Private WithEvents toolStripBtnDelete As System.Windows.Forms.ToolStripButton
    Private WithEvents toolStripBtnDeleteAll As System.Windows.Forms.ToolStripButton
    Private WithEvents toolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Private WithEvents toolStripBtnBringToBack As System.Windows.Forms.ToolStripButton
    Private WithEvents toolStripBtnBringToFront As System.Windows.Forms.ToolStripButton
    Friend WithEvents dlgColor As System.Windows.Forms.ColorDialog

End Class
