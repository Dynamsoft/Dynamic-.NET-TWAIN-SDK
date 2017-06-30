Partial Class Form1
	''' <summary>
	''' Required designer variable.
	''' </summary>
	Private components As System.ComponentModel.IContainer = Nothing

	''' <summary>
	''' Clean up any resources being used.
	''' </summary>
	''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
	Protected Overrides Sub Dispose(disposing As Boolean)
		If disposing AndAlso (components IsNot Nothing) Then
			components.Dispose()
		End If
		MyBase.Dispose(disposing)
	End Sub

	#Region "Windows Form Designer generated code"

	''' <summary>
	''' Required method for Designer support - do not modify
	''' the contents of this method with the code editor.
	''' </summary>
	Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.menuStrip = New System.Windows.Forms.MenuStrip()
        Me.fileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.openToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.saveToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.saveAllToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.printToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.closeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.annotationToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.createToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.lineToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ellipseToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.rectangleToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.textToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.delToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.deleteAllToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.copySelectedToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.pasteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.toolStrip = New System.Windows.Forms.ToolStrip()
        Me.toolStripBtnLannotation = New System.Windows.Forms.ToolStripButton()
        Me.toolStripBtnEannotation = New System.Windows.Forms.ToolStripButton()
        Me.toolStripBtnRannotation = New System.Windows.Forms.ToolStripButton()
        Me.toolStripBtnTannotation = New System.Windows.Forms.ToolStripButton()
        Me.toolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.toolStripFill = New System.Windows.Forms.ToolStripLabel()
        Me.toolStripBtnFill = New System.Windows.Forms.ToolStripButton()
        Me.toolStripPen = New System.Windows.Forms.ToolStripLabel()
        Me.toolStripBtnPen = New System.Windows.Forms.ToolStripButton()
        Me.toolStripCbxPen = New System.Windows.Forms.ToolStripComboBox()
        Me.toolStripFont = New System.Windows.Forms.ToolStripLabel()
        Me.toolStripBtnFont = New System.Windows.Forms.ToolStripButton()
        Me.toolStripCbxFont = New System.Windows.Forms.ToolStripComboBox()
        Me.toolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.toolStripBtnDelete = New System.Windows.Forms.ToolStripButton()
        Me.toolStripBtnDeleteAll = New System.Windows.Forms.ToolStripButton()
        Me.toolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.toolStripBtnBringToBack = New System.Windows.Forms.ToolStripButton()
        Me.toolStripBtnBringToFront = New System.Windows.Forms.ToolStripButton()
        Me.dlgColor = New System.Windows.Forms.ColorDialog()
        Me.splitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.dsViewer1 = New Dynamsoft.Forms.DSViewer()
        Me.propertyGrid1 = New System.Windows.Forms.PropertyGrid()
        Me.menuStrip.SuspendLayout()
        Me.toolStrip.SuspendLayout()
        Me.splitContainer1.Panel1.SuspendLayout()
        Me.splitContainer1.Panel2.SuspendLayout()
        Me.splitContainer1.SuspendLayout()
        Me.SuspendLayout()
        '
        'menuStrip
        '
        Me.menuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.fileToolStripMenuItem, Me.annotationToolStripMenuItem})
        Me.menuStrip.Location = New System.Drawing.Point(0, 0)
        Me.menuStrip.Name = "menuStrip"
        Me.menuStrip.Size = New System.Drawing.Size(714, 24)
        Me.menuStrip.TabIndex = 1
        Me.menuStrip.Text = "menuStrip1"
        '
        'fileToolStripMenuItem
        '
        Me.fileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.openToolStripMenuItem, Me.saveToolStripMenuItem, Me.saveAllToolStripMenuItem, Me.printToolStripMenuItem, Me.closeToolStripMenuItem})
        Me.fileToolStripMenuItem.Name = "fileToolStripMenuItem"
        Me.fileToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
        Me.fileToolStripMenuItem.Text = "&File"
        '
        'openToolStripMenuItem
        '
        Me.openToolStripMenuItem.Name = "openToolStripMenuItem"
        Me.openToolStripMenuItem.Size = New System.Drawing.Size(124, 22)
        Me.openToolStripMenuItem.Text = "&Open..."
        '
        'saveToolStripMenuItem
        '
        Me.saveToolStripMenuItem.Name = "saveToolStripMenuItem"
        Me.saveToolStripMenuItem.Size = New System.Drawing.Size(124, 22)
        Me.saveToolStripMenuItem.Text = "&Save..."
        '
        'saveAllToolStripMenuItem
        '
        Me.saveAllToolStripMenuItem.Name = "saveAllToolStripMenuItem"
        Me.saveAllToolStripMenuItem.Size = New System.Drawing.Size(124, 22)
        Me.saveAllToolStripMenuItem.Text = "&Save All..."
        '
        'printToolStripMenuItem
        '
        Me.printToolStripMenuItem.Name = "printToolStripMenuItem"
        Me.printToolStripMenuItem.Size = New System.Drawing.Size(124, 22)
        Me.printToolStripMenuItem.Text = "&Print..."
        '
        'closeToolStripMenuItem
        '
        Me.closeToolStripMenuItem.Name = "closeToolStripMenuItem"
        Me.closeToolStripMenuItem.Size = New System.Drawing.Size(124, 22)
        Me.closeToolStripMenuItem.Text = "&Exit"
        '
        'annotationToolStripMenuItem
        '
        Me.annotationToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.createToolStripMenuItem, Me.delToolStripMenuItem, Me.deleteAllToolStripMenuItem, Me.copySelectedToolStripMenuItem, Me.pasteToolStripMenuItem})
        Me.annotationToolStripMenuItem.Name = "annotationToolStripMenuItem"
        Me.annotationToolStripMenuItem.Size = New System.Drawing.Size(79, 20)
        Me.annotationToolStripMenuItem.Text = "&Annotation"
        '
        'createToolStripMenuItem
        '
        Me.createToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lineToolStripMenuItem, Me.ellipseToolStripMenuItem, Me.rectangleToolStripMenuItem, Me.textToolStripMenuItem})
        Me.createToolStripMenuItem.Name = "createToolStripMenuItem"
        Me.createToolStripMenuItem.Size = New System.Drawing.Size(154, 22)
        Me.createToolStripMenuItem.Text = "&Create"
        '
        'lineToolStripMenuItem
        '
        Me.lineToolStripMenuItem.Name = "lineToolStripMenuItem"
        Me.lineToolStripMenuItem.Size = New System.Drawing.Size(126, 22)
        Me.lineToolStripMenuItem.Text = "&Line"
        '
        'ellipseToolStripMenuItem
        '
        Me.ellipseToolStripMenuItem.Name = "ellipseToolStripMenuItem"
        Me.ellipseToolStripMenuItem.Size = New System.Drawing.Size(126, 22)
        Me.ellipseToolStripMenuItem.Text = "&Ellipse"
        '
        'rectangleToolStripMenuItem
        '
        Me.rectangleToolStripMenuItem.Name = "rectangleToolStripMenuItem"
        Me.rectangleToolStripMenuItem.Size = New System.Drawing.Size(126, 22)
        Me.rectangleToolStripMenuItem.Text = "&Rectangle"
        '
        'textToolStripMenuItem
        '
        Me.textToolStripMenuItem.Name = "textToolStripMenuItem"
        Me.textToolStripMenuItem.Size = New System.Drawing.Size(126, 22)
        Me.textToolStripMenuItem.Text = "&Text"
        '
        'delToolStripMenuItem
        '
        Me.delToolStripMenuItem.Name = "delToolStripMenuItem"
        Me.delToolStripMenuItem.Size = New System.Drawing.Size(154, 22)
        Me.delToolStripMenuItem.Text = "&Delete Selected"
        '
        'deleteAllToolStripMenuItem
        '
        Me.deleteAllToolStripMenuItem.Name = "deleteAllToolStripMenuItem"
        Me.deleteAllToolStripMenuItem.Size = New System.Drawing.Size(154, 22)
        Me.deleteAllToolStripMenuItem.Text = "Delete &All"
        '
        'copySelectedToolStripMenuItem
        '
        Me.copySelectedToolStripMenuItem.Name = "copySelectedToolStripMenuItem"
        Me.copySelectedToolStripMenuItem.Size = New System.Drawing.Size(154, 22)
        Me.copySelectedToolStripMenuItem.Text = "C&opy Selected"
        '
        'pasteToolStripMenuItem
        '
        Me.pasteToolStripMenuItem.Name = "pasteToolStripMenuItem"
        Me.pasteToolStripMenuItem.Size = New System.Drawing.Size(154, 22)
        Me.pasteToolStripMenuItem.Text = "&Paste"
        '
        'toolStrip
        '
        Me.toolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.toolStripBtnLannotation, Me.toolStripBtnEannotation, Me.toolStripBtnRannotation, Me.toolStripBtnTannotation, Me.toolStripSeparator1, Me.toolStripFill, Me.toolStripBtnFill, Me.toolStripPen, Me.toolStripBtnPen, Me.toolStripCbxPen, Me.toolStripFont, Me.toolStripBtnFont, Me.toolStripCbxFont, Me.toolStripSeparator2, Me.toolStripBtnDelete, Me.toolStripBtnDeleteAll, Me.toolStripSeparator3, Me.toolStripBtnBringToBack, Me.toolStripBtnBringToFront})
        Me.toolStrip.Location = New System.Drawing.Point(0, 24)
        Me.toolStrip.Name = "toolStrip"
        Me.toolStrip.Size = New System.Drawing.Size(714, 25)
        Me.toolStrip.TabIndex = 2
        Me.toolStrip.Text = "toolStrip1"
        '
        'toolStripBtnLannotation
        '
        Me.toolStripBtnLannotation.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolStripBtnLannotation.Image = CType(resources.GetObject("toolStripBtnLannotation.Image"), System.Drawing.Image)
        Me.toolStripBtnLannotation.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolStripBtnLannotation.Name = "toolStripBtnLannotation"
        Me.toolStripBtnLannotation.Size = New System.Drawing.Size(23, 22)
        Me.toolStripBtnLannotation.Text = "toolStripButton1"
        Me.toolStripBtnLannotation.ToolTipText = "Line"
        '
        'toolStripBtnEannotation
        '
        Me.toolStripBtnEannotation.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolStripBtnEannotation.Image = CType(resources.GetObject("toolStripBtnEannotation.Image"), System.Drawing.Image)
        Me.toolStripBtnEannotation.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolStripBtnEannotation.Name = "toolStripBtnEannotation"
        Me.toolStripBtnEannotation.Size = New System.Drawing.Size(23, 22)
        Me.toolStripBtnEannotation.Text = "toolStripButton2"
        Me.toolStripBtnEannotation.ToolTipText = "Ellipse"
        '
        'toolStripBtnRannotation
        '
        Me.toolStripBtnRannotation.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolStripBtnRannotation.Image = CType(resources.GetObject("toolStripBtnRannotation.Image"), System.Drawing.Image)
        Me.toolStripBtnRannotation.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolStripBtnRannotation.Name = "toolStripBtnRannotation"
        Me.toolStripBtnRannotation.Size = New System.Drawing.Size(23, 22)
        Me.toolStripBtnRannotation.Text = "toolStripButton3"
        Me.toolStripBtnRannotation.ToolTipText = "Rectangle"
        '
        'toolStripBtnTannotation
        '
        Me.toolStripBtnTannotation.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolStripBtnTannotation.Image = CType(resources.GetObject("toolStripBtnTannotation.Image"), System.Drawing.Image)
        Me.toolStripBtnTannotation.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolStripBtnTannotation.Name = "toolStripBtnTannotation"
        Me.toolStripBtnTannotation.Size = New System.Drawing.Size(23, 22)
        Me.toolStripBtnTannotation.Text = "toolStripButton4"
        Me.toolStripBtnTannotation.ToolTipText = "Text"
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
        Me.toolStripBtnBringToBack.Text = "Push To Back"
        '
        'toolStripBtnBringToFront
        '
        Me.toolStripBtnBringToFront.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolStripBtnBringToFront.Image = CType(resources.GetObject("toolStripBtnBringToFront.Image"), System.Drawing.Image)
        Me.toolStripBtnBringToFront.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolStripBtnBringToFront.Name = "toolStripBtnBringToFront"
        Me.toolStripBtnBringToFront.Size = New System.Drawing.Size(23, 22)
        Me.toolStripBtnBringToFront.Text = "Bring To Font"
        '
        'splitContainer1
        '
        Me.splitContainer1.Location = New System.Drawing.Point(0, 49)
        Me.splitContainer1.Name = "splitContainer1"
        '
        'splitContainer1.Panel1
        '
        Me.splitContainer1.Panel1.Controls.Add(Me.dsViewer1)
        '
        'splitContainer1.Panel2
        '
        Me.splitContainer1.Panel2.Controls.Add(Me.propertyGrid1)
        Me.splitContainer1.Size = New System.Drawing.Size(714, 385)
        Me.splitContainer1.SplitterDistance = 546
        Me.splitContainer1.TabIndex = 3
        '
        'dsViewer1
        '
        Me.dsViewer1.Location = New System.Drawing.Point(0, 0)
        Me.dsViewer1.Name = "dsViewer1"
        Me.dsViewer1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.dsViewer1.SelectionRectAspectRatio = 0.0R
        Me.dsViewer1.Size = New System.Drawing.Size(543, 382)
        Me.dsViewer1.TabIndex = 0
        '
        'propertyGrid1
        '
        Me.propertyGrid1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.propertyGrid1.Location = New System.Drawing.Point(0, 0)
        Me.propertyGrid1.Name = "propertyGrid1"
        Me.propertyGrid1.Size = New System.Drawing.Size(164, 385)
        Me.propertyGrid1.TabIndex = 0
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(714, 436)
        Me.Controls.Add(Me.splitContainer1)
        Me.Controls.Add(Me.toolStrip)
        Me.Controls.Add(Me.menuStrip)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "Form1"
        Me.Text = "Annotation Sample"
        Me.menuStrip.ResumeLayout(False)
        Me.menuStrip.PerformLayout()
        Me.toolStrip.ResumeLayout(False)
        Me.toolStrip.PerformLayout()
        Me.splitContainer1.Panel1.ResumeLayout(False)
        Me.splitContainer1.Panel2.ResumeLayout(False)
        Me.splitContainer1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

	#End Region

	Private menuStrip As System.Windows.Forms.MenuStrip
	Private fileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
	Private annotationToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents openToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents saveToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents printToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents closeToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
	Private WithEvents createToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents lineToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents ellipseToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents rectangleToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents textToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents delToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents deleteAllToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents copySelectedToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents pasteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents toolStrip As System.Windows.Forms.ToolStrip
    Private WithEvents toolStripBtnEannotation As System.Windows.Forms.ToolStripButton
    Private WithEvents toolStripBtnRannotation As System.Windows.Forms.ToolStripButton
    Private WithEvents toolStripBtnTannotation As System.Windows.Forms.ToolStripButton
    Private WithEvents toolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Private WithEvents toolStripCbxPen As System.Windows.Forms.ToolStripComboBox
    Private WithEvents toolStripFill As System.Windows.Forms.ToolStripLabel
    Private WithEvents toolStripPen As System.Windows.Forms.ToolStripLabel
    Private WithEvents toolStripFont As System.Windows.Forms.ToolStripLabel
    Private WithEvents toolStripCbxFont As System.Windows.Forms.ToolStripComboBox
    Private WithEvents toolStripBtnFill As System.Windows.Forms.ToolStripButton
    Private WithEvents toolStripBtnPen As System.Windows.Forms.ToolStripButton
    Private WithEvents toolStripBtnFont As System.Windows.Forms.ToolStripButton
	Private dlgColor As System.Windows.Forms.ColorDialog
	Private toolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Private WithEvents toolStripBtnDelete As System.Windows.Forms.ToolStripButton
    Private WithEvents toolStripBtnDeleteAll As System.Windows.Forms.ToolStripButton
	Private toolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Private splitContainer1 As System.Windows.Forms.SplitContainer
	Private propertyGrid1 As System.Windows.Forms.PropertyGrid
    Private WithEvents saveAllToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents toolStripBtnLannotation As System.Windows.Forms.ToolStripButton
    Private dsViewer1 As Dynamsoft.Forms.DSViewer
    Friend WithEvents toolStripBtnBringToBack As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolStripBtnBringToFront As System.Windows.Forms.ToolStripButton
End Class

