Partial Class DotNetTWAINDemo
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
		Dim resources As New System.ComponentModel.ComponentResourceManager(GetType(DotNetTWAINDemo))
		Me.lbGeneral = New System.Windows.Forms.Label()
		Me.picboxHand = New System.Windows.Forms.PictureBox()
		Me.picboxCrop = New System.Windows.Forms.PictureBox()
		Me.picboxPoint = New System.Windows.Forms.PictureBox()
		Me.picboxCut = New System.Windows.Forms.PictureBox()
		Me.lbMoveBar = New System.Windows.Forms.Label()
		Me.picboxFlip = New System.Windows.Forms.PictureBox()
		Me.picboxRotateLeft = New System.Windows.Forms.PictureBox()
		Me.picboxMirror = New System.Windows.Forms.PictureBox()
		Me.picboxRotateRight = New System.Windows.Forms.PictureBox()
		Me.lbReshape = New System.Windows.Forms.Label()
		Me.picboxText = New System.Windows.Forms.PictureBox()
		Me.picboxEllipse = New System.Windows.Forms.PictureBox()
		Me.picboxRectangle = New System.Windows.Forms.PictureBox()
		Me.picboxLine = New System.Windows.Forms.PictureBox()
		Me.lbAnnotate = New System.Windows.Forms.Label()
		Me.picboxZoomOut = New System.Windows.Forms.PictureBox()
		Me.picboxResample = New System.Windows.Forms.PictureBox()
		Me.picboxZoomIn = New System.Windows.Forms.PictureBox()
		Me.picboxZoom = New System.Windows.Forms.PictureBox()
		Me.label3 = New System.Windows.Forms.Label()
		Me.picboxDeleteAll = New System.Windows.Forms.PictureBox()
		Me.picboxDelete = New System.Windows.Forms.PictureBox()
		Me.label4 = New System.Windows.Forms.Label()
		Me.picboxFirst = New System.Windows.Forms.PictureBox()
		Me.picboxLast = New System.Windows.Forms.PictureBox()
		Me.picboxNext = New System.Windows.Forms.PictureBox()
		Me.picboxPrevious = New System.Windows.Forms.PictureBox()
		Me.cbxViewMode = New System.Windows.Forms.ComboBox()
		Me.picboxMin = New System.Windows.Forms.PictureBox()
		Me.picboxClose = New System.Windows.Forms.PictureBox()
		Me.lbDiv = New System.Windows.Forms.Label()
		Me.tbxCurrentImageIndex = New System.Windows.Forms.TextBox()
		Me.tbxTotalImageNum = New System.Windows.Forms.TextBox()
		Me.saveFileDialog = New System.Windows.Forms.SaveFileDialog()
		Me.openFileDialog = New System.Windows.Forms.OpenFileDialog()
		Me.flowLayoutPanel2 = New System.Windows.Forms.FlowLayoutPanel()
		Me.panelLoad = New System.Windows.Forms.Panel()
		Me.panel1 = New System.Windows.Forms.Panel()
		Me.label24 = New System.Windows.Forms.Label()
		Me.picboxLoadImage = New System.Windows.Forms.PictureBox()
		Me.label1 = New System.Windows.Forms.Label()
		Me.panelAcquire = New System.Windows.Forms.Panel()
		Me.lbUnknowSource = New System.Windows.Forms.Label()
		Me.panelGrab = New System.Windows.Forms.Panel()
		Me.picboxGrab = New System.Windows.Forms.PictureBox()
		Me.cbxResolutionForWebcam = New System.Windows.Forms.ComboBox()
		Me.label21 = New System.Windows.Forms.Label()
		Me.label20 = New System.Windows.Forms.Label()
		Me.chkShowUIForWebcam = New System.Windows.Forms.CheckBox()
		Me.panelScan = New System.Windows.Forms.Panel()
		Me.rdbtnGray = New System.Windows.Forms.RadioButton()
		Me.chkShowUI = New System.Windows.Forms.CheckBox()
		Me.cbxResolution = New System.Windows.Forms.ComboBox()
		Me.picboxScan = New System.Windows.Forms.PictureBox()
		Me.rdbtnBW = New System.Windows.Forms.RadioButton()
		Me.lbResolution = New System.Windows.Forms.Label()
		Me.rdbtnColor = New System.Windows.Forms.RadioButton()
		Me.chkADF = New System.Windows.Forms.CheckBox()
		Me.chkDuplex = New System.Windows.Forms.CheckBox()
		Me.lbPixelType = New System.Windows.Forms.Label()
		Me.lbSelectSource = New System.Windows.Forms.Label()
		Me.cbxSource = New System.Windows.Forms.ComboBox()
		Me.panelAddBarcode = New System.Windows.Forms.Panel()
		Me.picboxAddBarcode = New System.Windows.Forms.PictureBox()
		Me.tbxBarcodeScale = New System.Windows.Forms.TextBox()
		Me.tbxHumanReadableText = New System.Windows.Forms.TextBox()
		Me.tbxBarcodeLocationY = New System.Windows.Forms.TextBox()
		Me.tbxBarcodeLocationX = New System.Windows.Forms.TextBox()
		Me.tbxBarcodeContent = New System.Windows.Forms.TextBox()
		Me.cbxGenBarcodeFormat = New System.Windows.Forms.ComboBox()
		Me.label19 = New System.Windows.Forms.Label()
		Me.label18 = New System.Windows.Forms.Label()
		Me.label17 = New System.Windows.Forms.Label()
		Me.label16 = New System.Windows.Forms.Label()
		Me.label15 = New System.Windows.Forms.Label()
		Me.label14 = New System.Windows.Forms.Label()
		Me.label13 = New System.Windows.Forms.Label()
		Me.panelReadBarcode = New System.Windows.Forms.Panel()
		Me.picboxReadBarcode = New System.Windows.Forms.PictureBox()
		Me.label6 = New System.Windows.Forms.Label()
		Me.label7 = New System.Windows.Forms.Label()
		Me.tbxBottom = New System.Windows.Forms.TextBox()
		Me.tbxMaxBarcodeReads = New System.Windows.Forms.TextBox()
		Me.cbxBarcodeFormat = New System.Windows.Forms.ComboBox()
		Me.tbxTop = New System.Windows.Forms.TextBox()
		Me.label8 = New System.Windows.Forms.Label()
		Me.label9 = New System.Windows.Forms.Label()
		Me.tbxRight = New System.Windows.Forms.TextBox()
		Me.label10 = New System.Windows.Forms.Label()
		Me.label11 = New System.Windows.Forms.Label()
		Me.tbxLeft = New System.Windows.Forms.TextBox()
		Me.label12 = New System.Windows.Forms.Label()
		Me.panelOCR = New System.Windows.Forms.Panel()
		Me.picboxOCR = New System.Windows.Forms.PictureBox()
		Me.label2 = New System.Windows.Forms.Label()
		Me.cbxSupportedLanguage = New System.Windows.Forms.ComboBox()
		Me.cbxOCRResultFormat = New System.Windows.Forms.ComboBox()
		Me.label5 = New System.Windows.Forms.Label()
		Me.panelSaveImage = New System.Windows.Forms.Panel()
		Me.lbFileName = New System.Windows.Forms.Label()
		Me.rdbtnPDF = New System.Windows.Forms.RadioButton()
		Me.tbxSaveFileName = New System.Windows.Forms.TextBox()
		Me.rdbtnJPG = New System.Windows.Forms.RadioButton()
		Me.rdbtnTIFF = New System.Windows.Forms.RadioButton()
		Me.picboxSave = New System.Windows.Forms.PictureBox()
		Me.rdbtnPNG = New System.Windows.Forms.RadioButton()
		Me.lbSaveImageType = New System.Windows.Forms.Label()
		Me.chkMultiPage = New System.Windows.Forms.CheckBox()
		Me.rdbtnBMP = New System.Windows.Forms.RadioButton()
		Me.label22 = New System.Windows.Forms.Label()
		Me.label23 = New System.Windows.Forms.Label()
		Me.picboxFit = New System.Windows.Forms.PictureBox()
		Me.picboxOriginalSize = New System.Windows.Forms.PictureBox()
		Me.label25 = New System.Windows.Forms.Label()
		Me.lbCloseAnnotations = New System.Windows.Forms.Label()
		Me.panelAnnotations = New System.Windows.Forms.Panel()
		Me.picboxTitle = New System.Windows.Forms.PictureBox()
		Me.picboxDeleteAnnotationA = New System.Windows.Forms.PictureBox()
		Me.picboxEllipseA = New System.Windows.Forms.PictureBox()
		Me.picboxRectangleA = New System.Windows.Forms.PictureBox()
		Me.picboxTextA = New System.Windows.Forms.PictureBox()
		Me.picboxLineA = New System.Windows.Forms.PictureBox()
		Me.dsViewer = New Dynamsoft.Forms.DSViewer()
		DirectCast(Me.picboxHand, System.ComponentModel.ISupportInitialize).BeginInit()
		DirectCast(Me.picboxCrop, System.ComponentModel.ISupportInitialize).BeginInit()
		DirectCast(Me.picboxPoint, System.ComponentModel.ISupportInitialize).BeginInit()
		DirectCast(Me.picboxCut, System.ComponentModel.ISupportInitialize).BeginInit()
		DirectCast(Me.picboxFlip, System.ComponentModel.ISupportInitialize).BeginInit()
		DirectCast(Me.picboxRotateLeft, System.ComponentModel.ISupportInitialize).BeginInit()
		DirectCast(Me.picboxMirror, System.ComponentModel.ISupportInitialize).BeginInit()
		DirectCast(Me.picboxRotateRight, System.ComponentModel.ISupportInitialize).BeginInit()
		DirectCast(Me.picboxText, System.ComponentModel.ISupportInitialize).BeginInit()
		DirectCast(Me.picboxEllipse, System.ComponentModel.ISupportInitialize).BeginInit()
		DirectCast(Me.picboxRectangle, System.ComponentModel.ISupportInitialize).BeginInit()
		DirectCast(Me.picboxLine, System.ComponentModel.ISupportInitialize).BeginInit()
		DirectCast(Me.picboxZoomOut, System.ComponentModel.ISupportInitialize).BeginInit()
		DirectCast(Me.picboxResample, System.ComponentModel.ISupportInitialize).BeginInit()
		DirectCast(Me.picboxZoomIn, System.ComponentModel.ISupportInitialize).BeginInit()
		DirectCast(Me.picboxZoom, System.ComponentModel.ISupportInitialize).BeginInit()
		DirectCast(Me.picboxDeleteAll, System.ComponentModel.ISupportInitialize).BeginInit()
		DirectCast(Me.picboxDelete, System.ComponentModel.ISupportInitialize).BeginInit()
		DirectCast(Me.picboxFirst, System.ComponentModel.ISupportInitialize).BeginInit()
		DirectCast(Me.picboxLast, System.ComponentModel.ISupportInitialize).BeginInit()
		DirectCast(Me.picboxNext, System.ComponentModel.ISupportInitialize).BeginInit()
		DirectCast(Me.picboxPrevious, System.ComponentModel.ISupportInitialize).BeginInit()
		DirectCast(Me.picboxMin, System.ComponentModel.ISupportInitialize).BeginInit()
		DirectCast(Me.picboxClose, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.panelLoad.SuspendLayout()
		Me.panel1.SuspendLayout()
		DirectCast(Me.picboxLoadImage, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.panelAcquire.SuspendLayout()
		Me.panelGrab.SuspendLayout()
		DirectCast(Me.picboxGrab, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.panelScan.SuspendLayout()
		DirectCast(Me.picboxScan, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.panelAddBarcode.SuspendLayout()
		DirectCast(Me.picboxAddBarcode, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.panelReadBarcode.SuspendLayout()
		DirectCast(Me.picboxReadBarcode, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.panelOCR.SuspendLayout()
		DirectCast(Me.picboxOCR, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.panelSaveImage.SuspendLayout()
		DirectCast(Me.picboxSave, System.ComponentModel.ISupportInitialize).BeginInit()
		DirectCast(Me.picboxFit, System.ComponentModel.ISupportInitialize).BeginInit()
		DirectCast(Me.picboxOriginalSize, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.panelAnnotations.SuspendLayout()
		DirectCast(Me.picboxTitle, System.ComponentModel.ISupportInitialize).BeginInit()
		DirectCast(Me.picboxDeleteAnnotationA, System.ComponentModel.ISupportInitialize).BeginInit()
		DirectCast(Me.picboxEllipseA, System.ComponentModel.ISupportInitialize).BeginInit()
		DirectCast(Me.picboxRectangleA, System.ComponentModel.ISupportInitialize).BeginInit()
		DirectCast(Me.picboxTextA, System.ComponentModel.ISupportInitialize).BeginInit()
		DirectCast(Me.picboxLineA, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.SuspendLayout()
		' 
		' lbGeneral
		' 
		Me.lbGeneral.AutoSize = True
		Me.lbGeneral.BackColor = System.Drawing.Color.White
		Me.lbGeneral.Font = New System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CByte(0))
		Me.lbGeneral.Location = New System.Drawing.Point(9, 58)
		Me.lbGeneral.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
		Me.lbGeneral.Name = "lbGeneral"
		Me.lbGeneral.Size = New System.Drawing.Size(47, 15)
		Me.lbGeneral.TabIndex = 1
		Me.lbGeneral.Text = "General"
		' 
		' picboxHand
		' 
        Me.picboxHand.Image = Global.DotNet_TWAIN_Demo.My.Resources.picboxHand_Leave
        Me.picboxHand.Location = New System.Drawing.Point(11, 81)
        Me.picboxHand.Name = "picboxHand"
        Me.picboxHand.Size = New System.Drawing.Size(60, 36)
        Me.picboxHand.TabIndex = 2
        Me.picboxHand.TabStop = False
        Me.picboxHand.Tag = "Move"
        AddHandler Me.picboxHand.MouseLeave, New System.EventHandler(AddressOf Me.picbox_MouseLeave)
        AddHandler Me.picboxHand.Click, New System.EventHandler(AddressOf Me.picboxHand_Click)
        AddHandler Me.picboxHand.MouseDown, New System.Windows.Forms.MouseEventHandler(AddressOf Me.picbox_MouseDown)
        AddHandler Me.picboxHand.MouseHover, New System.EventHandler(AddressOf Me.picbox_MouseHover)
        AddHandler Me.picboxHand.MouseUp, New System.Windows.Forms.MouseEventHandler(AddressOf Me.picbox_MouseUp)
        AddHandler Me.picboxHand.MouseEnter, New System.EventHandler(AddressOf Me.picbox_MouseEnter)
        ' 
        ' picboxCrop
        ' 
        Me.picboxCrop.Image = Global.DotNet_TWAIN_Demo.My.Resources.picboxCrop_Leave
        Me.picboxCrop.Location = New System.Drawing.Point(70, 265)
        Me.picboxCrop.Name = "picboxCrop"
        Me.picboxCrop.Size = New System.Drawing.Size(60, 36)
        Me.picboxCrop.TabIndex = 3
        Me.picboxCrop.TabStop = False
        Me.picboxCrop.Tag = "Crop"
        AddHandler Me.picboxCrop.MouseLeave, New System.EventHandler(AddressOf Me.picbox_MouseLeave)
        AddHandler Me.picboxCrop.Click, New System.EventHandler(AddressOf Me.picboxCrop_Click)
        AddHandler Me.picboxCrop.MouseDown, New System.Windows.Forms.MouseEventHandler(AddressOf Me.picbox_MouseDown)
        AddHandler Me.picboxCrop.MouseHover, New System.EventHandler(AddressOf Me.picbox_MouseHover)
        AddHandler Me.picboxCrop.MouseUp, New System.Windows.Forms.MouseEventHandler(AddressOf Me.picbox_MouseUp)
        AddHandler Me.picboxCrop.MouseEnter, New System.EventHandler(AddressOf Me.picbox_MouseEnter)
        ' 
        ' picboxPoint
        ' 
        Me.picboxPoint.Image = Global.DotNet_TWAIN_Demo.My.Resources.picboxPoint_Leave
        Me.picboxPoint.Location = New System.Drawing.Point(70, 81)
        Me.picboxPoint.Name = "picboxPoint"
        Me.picboxPoint.Size = New System.Drawing.Size(61, 36)
        Me.picboxPoint.TabIndex = 4
        Me.picboxPoint.TabStop = False
        Me.picboxPoint.Tag = "Select"
        AddHandler Me.picboxPoint.MouseLeave, New System.EventHandler(AddressOf Me.picbox_MouseLeave)
        AddHandler Me.picboxPoint.Click, New System.EventHandler(AddressOf Me.picboxPoint_Click)
        AddHandler Me.picboxPoint.MouseDown, New System.Windows.Forms.MouseEventHandler(AddressOf Me.picbox_MouseDown)
        AddHandler Me.picboxPoint.MouseHover, New System.EventHandler(AddressOf Me.picbox_MouseHover)
        AddHandler Me.picboxPoint.MouseUp, New System.Windows.Forms.MouseEventHandler(AddressOf Me.picbox_MouseUp)
        AddHandler Me.picboxPoint.MouseEnter, New System.EventHandler(AddressOf Me.picbox_MouseEnter)
        ' 
        ' picboxCut
        ' 
        Me.picboxCut.Image = Global.DotNet_TWAIN_Demo.My.Resources.picboxCut_Leave
        Me.picboxCut.Location = New System.Drawing.Point(11, 265)
        Me.picboxCut.Name = "picboxCut"
        Me.picboxCut.Size = New System.Drawing.Size(61, 36)
        Me.picboxCut.TabIndex = 17
        Me.picboxCut.TabStop = False
        Me.picboxCut.Tag = "Cut"
        AddHandler Me.picboxCut.MouseLeave, New System.EventHandler(AddressOf Me.picbox_MouseLeave)
        AddHandler Me.picboxCut.Click, New System.EventHandler(AddressOf Me.picboxCut_Click)
        AddHandler Me.picboxCut.MouseDown, New System.Windows.Forms.MouseEventHandler(AddressOf Me.picbox_MouseDown)
        AddHandler Me.picboxCut.MouseHover, New System.EventHandler(AddressOf Me.picbox_MouseHover)
        AddHandler Me.picboxCut.MouseUp, New System.Windows.Forms.MouseEventHandler(AddressOf Me.picbox_MouseUp)
        AddHandler Me.picboxCut.MouseEnter, New System.EventHandler(AddressOf Me.picbox_MouseEnter)
        ' 
        ' lbMoveBar
        ' 
        Me.lbMoveBar.BackColor = System.Drawing.Color.Transparent
        Me.lbMoveBar.Location = New System.Drawing.Point(0, 1)
        Me.lbMoveBar.Name = "lbMoveBar"
        Me.lbMoveBar.Size = New System.Drawing.Size(897, 32)
        Me.lbMoveBar.TabIndex = 18
        AddHandler Me.lbMoveBar.MouseMove, New System.Windows.Forms.MouseEventHandler(AddressOf Me.lbMoveBar_MouseMove)
        AddHandler Me.lbMoveBar.MouseDown, New System.Windows.Forms.MouseEventHandler(AddressOf Me.lbMoveBar_MouseDown)
        ' 
        ' picboxFlip
        ' 
        Me.picboxFlip.Image = Global.DotNet_TWAIN_Demo.My.Resources.picboxFlip_Leave
        Me.picboxFlip.Location = New System.Drawing.Point(70, 195)
        Me.picboxFlip.Name = "picboxFlip"
        Me.picboxFlip.Size = New System.Drawing.Size(61, 36)
        Me.picboxFlip.TabIndex = 24
        Me.picboxFlip.TabStop = False
        Me.picboxFlip.Tag = "Flip"
        AddHandler Me.picboxFlip.MouseLeave, New System.EventHandler(AddressOf Me.picbox_MouseLeave)
        AddHandler Me.picboxFlip.Click, New System.EventHandler(AddressOf Me.picboxFlip_Click)
        AddHandler Me.picboxFlip.MouseDown, New System.Windows.Forms.MouseEventHandler(AddressOf Me.picbox_MouseDown)
        AddHandler Me.picboxFlip.MouseHover, New System.EventHandler(AddressOf Me.picbox_MouseHover)
        AddHandler Me.picboxFlip.MouseUp, New System.Windows.Forms.MouseEventHandler(AddressOf Me.picbox_MouseUp)
        AddHandler Me.picboxFlip.MouseEnter, New System.EventHandler(AddressOf Me.picbox_MouseEnter)
        ' 
        ' picboxRotateLeft
        ' 
        Me.picboxRotateLeft.Image = Global.DotNet_TWAIN_Demo.My.Resources.picboxRotateLeft_Leave
        Me.picboxRotateLeft.Location = New System.Drawing.Point(70, 152)
        Me.picboxRotateLeft.Name = "picboxRotateLeft"
        Me.picboxRotateLeft.Size = New System.Drawing.Size(61, 36)
        Me.picboxRotateLeft.TabIndex = 23
        Me.picboxRotateLeft.TabStop = False
        Me.picboxRotateLeft.Tag = "Rotate Left"
        AddHandler Me.picboxRotateLeft.MouseLeave, New System.EventHandler(AddressOf Me.picbox_MouseLeave)
        AddHandler Me.picboxRotateLeft.Click, New System.EventHandler(AddressOf Me.picboxRotateLeft_Click)
        AddHandler Me.picboxRotateLeft.MouseDown, New System.Windows.Forms.MouseEventHandler(AddressOf Me.picbox_MouseDown)
        AddHandler Me.picboxRotateLeft.MouseHover, New System.EventHandler(AddressOf Me.picbox_MouseHover)
        AddHandler Me.picboxRotateLeft.MouseUp, New System.Windows.Forms.MouseEventHandler(AddressOf Me.picbox_MouseUp)
        AddHandler Me.picboxRotateLeft.MouseEnter, New System.EventHandler(AddressOf Me.picbox_MouseEnter)
        ' 
        ' picboxMirror
        ' 
        Me.picboxMirror.Image = Global.DotNet_TWAIN_Demo.My.Resources.picboxMirror_Leave
        Me.picboxMirror.Location = New System.Drawing.Point(11, 195)
        Me.picboxMirror.Name = "picboxMirror"
        Me.picboxMirror.Size = New System.Drawing.Size(60, 36)
        Me.picboxMirror.TabIndex = 22
        Me.picboxMirror.TabStop = False
        Me.picboxMirror.Tag = "Mirror"
        AddHandler Me.picboxMirror.MouseLeave, New System.EventHandler(AddressOf Me.picbox_MouseLeave)
        AddHandler Me.picboxMirror.Click, New System.EventHandler(AddressOf Me.picboxMirror_Click)
        AddHandler Me.picboxMirror.MouseDown, New System.Windows.Forms.MouseEventHandler(AddressOf Me.picbox_MouseDown)
        AddHandler Me.picboxMirror.MouseHover, New System.EventHandler(AddressOf Me.picbox_MouseHover)
        AddHandler Me.picboxMirror.MouseUp, New System.Windows.Forms.MouseEventHandler(AddressOf Me.picbox_MouseUp)
        AddHandler Me.picboxMirror.MouseEnter, New System.EventHandler(AddressOf Me.picbox_MouseEnter)
        ' 
        ' picboxRotateRight
        ' 
        Me.picboxRotateRight.Image = Global.DotNet_TWAIN_Demo.My.Resources.picboxRotateRight_Leave
        Me.picboxRotateRight.Location = New System.Drawing.Point(11, 152)
        Me.picboxRotateRight.Name = "picboxRotateRight"
        Me.picboxRotateRight.Size = New System.Drawing.Size(60, 36)
        Me.picboxRotateRight.TabIndex = 21
        Me.picboxRotateRight.TabStop = False
        Me.picboxRotateRight.Tag = "Rotate Right"
        AddHandler Me.picboxRotateRight.MouseLeave, New System.EventHandler(AddressOf Me.picbox_MouseLeave)
        AddHandler Me.picboxRotateRight.Click, New System.EventHandler(AddressOf Me.picboxRotateRight_Click)
        AddHandler Me.picboxRotateRight.MouseDown, New System.Windows.Forms.MouseEventHandler(AddressOf Me.picbox_MouseDown)
        AddHandler Me.picboxRotateRight.MouseHover, New System.EventHandler(AddressOf Me.picbox_MouseHover)
        AddHandler Me.picboxRotateRight.MouseUp, New System.Windows.Forms.MouseEventHandler(AddressOf Me.picbox_MouseUp)
        AddHandler Me.picboxRotateRight.MouseEnter, New System.EventHandler(AddressOf Me.picbox_MouseEnter)
        ' 
        ' lbReshape
        ' 
        Me.lbReshape.AutoSize = True
        Me.lbReshape.BackColor = System.Drawing.Color.White
        Me.lbReshape.Font = New System.Drawing.Font("Segoe UI", 9.0F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CByte(0))
        Me.lbReshape.Location = New System.Drawing.Point(9, 127)
        Me.lbReshape.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbReshape.Name = "lbReshape"
        Me.lbReshape.Size = New System.Drawing.Size(90, 15)
        Me.lbReshape.TabIndex = 20
        Me.lbReshape.Text = "Rotate && Mirror"
        ' 
        ' picboxText
        ' 
        Me.picboxText.Image = Global.DotNet_TWAIN_Demo.My.Resources.picboxText_Leave
        Me.picboxText.Location = New System.Drawing.Point(70, 378)
        Me.picboxText.Name = "picboxText"
        Me.picboxText.Size = New System.Drawing.Size(61, 36)
        Me.picboxText.TabIndex = 29
        Me.picboxText.TabStop = False
        Me.picboxText.Tag = "Draw Text"
        AddHandler Me.picboxText.MouseLeave, New System.EventHandler(AddressOf Me.picbox_MouseLeave)
        AddHandler Me.picboxText.Click, New System.EventHandler(AddressOf Me.picboxText_Click)
        AddHandler Me.picboxText.MouseDown, New System.Windows.Forms.MouseEventHandler(AddressOf Me.picbox_MouseDown)
        AddHandler Me.picboxText.MouseHover, New System.EventHandler(AddressOf Me.picbox_MouseHover)
        AddHandler Me.picboxText.MouseUp, New System.Windows.Forms.MouseEventHandler(AddressOf Me.picbox_MouseUp)
        AddHandler Me.picboxText.MouseEnter, New System.EventHandler(AddressOf Me.picbox_MouseEnter)
        ' 
        ' picboxEllipse
        ' 
        Me.picboxEllipse.Image = Global.DotNet_TWAIN_Demo.My.Resources.picboxEllipse_Leave
        Me.picboxEllipse.Location = New System.Drawing.Point(70, 335)
        Me.picboxEllipse.Name = "picboxEllipse"
        Me.picboxEllipse.Size = New System.Drawing.Size(61, 36)
        Me.picboxEllipse.TabIndex = 28
        Me.picboxEllipse.TabStop = False
        Me.picboxEllipse.Tag = "Draw Ellipse"
        AddHandler Me.picboxEllipse.MouseLeave, New System.EventHandler(AddressOf Me.picbox_MouseLeave)
        AddHandler Me.picboxEllipse.Click, New System.EventHandler(AddressOf Me.picboxEllipse_Click)
        AddHandler Me.picboxEllipse.MouseDown, New System.Windows.Forms.MouseEventHandler(AddressOf Me.picbox_MouseDown)
        AddHandler Me.picboxEllipse.MouseHover, New System.EventHandler(AddressOf Me.picbox_MouseHover)
        AddHandler Me.picboxEllipse.MouseUp, New System.Windows.Forms.MouseEventHandler(AddressOf Me.picbox_MouseUp)
        AddHandler Me.picboxEllipse.MouseEnter, New System.EventHandler(AddressOf Me.picbox_MouseEnter)
        ' 
        ' picboxRectangle
        ' 
        Me.picboxRectangle.Image = Global.DotNet_TWAIN_Demo.My.Resources.picboxRectangle_Leave
        Me.picboxRectangle.Location = New System.Drawing.Point(11, 378)
        Me.picboxRectangle.Name = "picboxRectangle"
        Me.picboxRectangle.Size = New System.Drawing.Size(60, 36)
        Me.picboxRectangle.TabIndex = 27
        Me.picboxRectangle.TabStop = False
        Me.picboxRectangle.Tag = "Draw Rectangle"
        AddHandler Me.picboxRectangle.MouseLeave, New System.EventHandler(AddressOf Me.picbox_MouseLeave)
        AddHandler Me.picboxRectangle.Click, New System.EventHandler(AddressOf Me.picboxRectangle_Click)
        AddHandler Me.picboxRectangle.MouseDown, New System.Windows.Forms.MouseEventHandler(AddressOf Me.picbox_MouseDown)
        AddHandler Me.picboxRectangle.MouseHover, New System.EventHandler(AddressOf Me.picbox_MouseHover)
        AddHandler Me.picboxRectangle.MouseUp, New System.Windows.Forms.MouseEventHandler(AddressOf Me.picbox_MouseUp)
        AddHandler Me.picboxRectangle.MouseEnter, New System.EventHandler(AddressOf Me.picbox_MouseEnter)
        ' 
        ' picboxLine
        ' 
        Me.picboxLine.Image = Global.DotNet_TWAIN_Demo.My.Resources.picboxLine_Leave
        Me.picboxLine.Location = New System.Drawing.Point(11, 335)
        Me.picboxLine.Name = "picboxLine"
        Me.picboxLine.Size = New System.Drawing.Size(60, 36)
        Me.picboxLine.TabIndex = 26
        Me.picboxLine.TabStop = False
        Me.picboxLine.Tag = "Draw Line"
        AddHandler Me.picboxLine.MouseLeave, New System.EventHandler(AddressOf Me.picbox_MouseLeave)
        AddHandler Me.picboxLine.Click, New System.EventHandler(AddressOf Me.picboxLine_Click)
        AddHandler Me.picboxLine.MouseDown, New System.Windows.Forms.MouseEventHandler(AddressOf Me.picbox_MouseDown)
        AddHandler Me.picboxLine.MouseHover, New System.EventHandler(AddressOf Me.picbox_MouseHover)
        AddHandler Me.picboxLine.MouseUp, New System.Windows.Forms.MouseEventHandler(AddressOf Me.picbox_MouseUp)
        AddHandler Me.picboxLine.MouseEnter, New System.EventHandler(AddressOf Me.picbox_MouseEnter)
        ' 
        ' lbAnnotate
        ' 
        Me.lbAnnotate.AutoSize = True
        Me.lbAnnotate.BackColor = System.Drawing.Color.White
        Me.lbAnnotate.Font = New System.Drawing.Font("Segoe UI", 9.0F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CByte(0))
        Me.lbAnnotate.Location = New System.Drawing.Point(9, 311)
        Me.lbAnnotate.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbAnnotate.Name = "lbAnnotate"
        Me.lbAnnotate.Size = New System.Drawing.Size(67, 15)
        Me.lbAnnotate.TabIndex = 25
        Me.lbAnnotate.Text = "Annotation"
        ' 
        ' picboxZoomOut
        ' 
        Me.picboxZoomOut.Image = Global.DotNet_TWAIN_Demo.My.Resources.picboxZoomOut_Leave
        Me.picboxZoomOut.Location = New System.Drawing.Point(70, 561)
        Me.picboxZoomOut.Name = "picboxZoomOut"
        Me.picboxZoomOut.Size = New System.Drawing.Size(61, 36)
        Me.picboxZoomOut.TabIndex = 34
        Me.picboxZoomOut.TabStop = False
        Me.picboxZoomOut.Tag = "Zoom Out"
        AddHandler Me.picboxZoomOut.MouseLeave, New System.EventHandler(AddressOf Me.picbox_MouseLeave)
        AddHandler Me.picboxZoomOut.Click, New System.EventHandler(AddressOf Me.picboxZoomOut_Click)
        AddHandler Me.picboxZoomOut.MouseDown, New System.Windows.Forms.MouseEventHandler(AddressOf Me.picbox_MouseDown)
        AddHandler Me.picboxZoomOut.MouseHover, New System.EventHandler(AddressOf Me.picbox_MouseHover)
        AddHandler Me.picboxZoomOut.MouseUp, New System.Windows.Forms.MouseEventHandler(AddressOf Me.picbox_MouseUp)
        AddHandler Me.picboxZoomOut.MouseEnter, New System.EventHandler(AddressOf Me.picbox_MouseEnter)
        ' 
        ' picboxResample
        ' 
        Me.picboxResample.Image = Global.DotNet_TWAIN_Demo.My.Resources.picboxResample_Leave
        Me.picboxResample.InitialImage = DirectCast(resources.GetObject("picboxResample.InitialImage"), System.Drawing.Image)
        Me.picboxResample.Location = New System.Drawing.Point(70, 518)
        Me.picboxResample.Name = "picboxResample"
        Me.picboxResample.Size = New System.Drawing.Size(61, 36)
        Me.picboxResample.TabIndex = 33
        Me.picboxResample.TabStop = False
        Me.picboxResample.Tag = "Resample Image"
        AddHandler Me.picboxResample.MouseLeave, New System.EventHandler(AddressOf Me.picbox_MouseLeave)
        AddHandler Me.picboxResample.Click, New System.EventHandler(AddressOf Me.picboxResample_Click)
        AddHandler Me.picboxResample.MouseDown, New System.Windows.Forms.MouseEventHandler(AddressOf Me.picbox_MouseDown)
        AddHandler Me.picboxResample.MouseHover, New System.EventHandler(AddressOf Me.picbox_MouseHover)
        AddHandler Me.picboxResample.MouseUp, New System.Windows.Forms.MouseEventHandler(AddressOf Me.picbox_MouseUp)
        AddHandler Me.picboxResample.MouseEnter, New System.EventHandler(AddressOf Me.picbox_MouseEnter)
        ' 
        ' picboxZoomIn
        ' 
        Me.picboxZoomIn.Image = Global.DotNet_TWAIN_Demo.My.Resources.picboxZoomIn_Leave
        Me.picboxZoomIn.Location = New System.Drawing.Point(11, 561)
        Me.picboxZoomIn.Name = "picboxZoomIn"
        Me.picboxZoomIn.Size = New System.Drawing.Size(60, 36)
        Me.picboxZoomIn.TabIndex = 32
        Me.picboxZoomIn.TabStop = False
        Me.picboxZoomIn.Tag = "Zoom In"
        AddHandler Me.picboxZoomIn.MouseLeave, New System.EventHandler(AddressOf Me.picbox_MouseLeave)
        AddHandler Me.picboxZoomIn.Click, New System.EventHandler(AddressOf Me.picboxZoomIn_Click)
        AddHandler Me.picboxZoomIn.MouseDown, New System.Windows.Forms.MouseEventHandler(AddressOf Me.picbox_MouseDown)
        AddHandler Me.picboxZoomIn.MouseHover, New System.EventHandler(AddressOf Me.picbox_MouseHover)
        AddHandler Me.picboxZoomIn.MouseUp, New System.Windows.Forms.MouseEventHandler(AddressOf Me.picbox_MouseUp)
        AddHandler Me.picboxZoomIn.MouseEnter, New System.EventHandler(AddressOf Me.picbox_MouseEnter)
        ' 
        ' picboxZoom
        ' 
        Me.picboxZoom.Image = Global.DotNet_TWAIN_Demo.My.Resources.picboxZoom_Leave
        Me.picboxZoom.Location = New System.Drawing.Point(11, 518)
        Me.picboxZoom.Name = "picboxZoom"
        Me.picboxZoom.Size = New System.Drawing.Size(60, 36)
        Me.picboxZoom.TabIndex = 31
        Me.picboxZoom.TabStop = False
        Me.picboxZoom.Tag = "Zoom Detail"
        AddHandler Me.picboxZoom.MouseLeave, New System.EventHandler(AddressOf Me.picbox_MouseLeave)
        AddHandler Me.picboxZoom.Click, New System.EventHandler(AddressOf Me.picboxZoom_Click)
        AddHandler Me.picboxZoom.MouseDown, New System.Windows.Forms.MouseEventHandler(AddressOf Me.picbox_MouseDown)
        AddHandler Me.picboxZoom.MouseHover, New System.EventHandler(AddressOf Me.picbox_MouseHover)
        AddHandler Me.picboxZoom.MouseUp, New System.Windows.Forms.MouseEventHandler(AddressOf Me.picbox_MouseUp)
        AddHandler Me.picboxZoom.MouseEnter, New System.EventHandler(AddressOf Me.picbox_MouseEnter)
        ' 
        ' label3
        ' 
        Me.label3.AutoSize = True
        Me.label3.BackColor = System.Drawing.Color.White
        Me.label3.Font = New System.Drawing.Font("Segoe UI", 9.0F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CByte(0))
        Me.label3.Location = New System.Drawing.Point(9, 494)
        Me.label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.label3.Name = "label3"
        Me.label3.Size = New System.Drawing.Size(87, 15)
        Me.label3.TabIndex = 30
        Me.label3.Text = "Zoom && Resize"
        ' 
        ' picboxDeleteAll
        ' 
        Me.picboxDeleteAll.Image = Global.DotNet_TWAIN_Demo.My.Resources.picboxDeleteAll_Leave
        Me.picboxDeleteAll.Location = New System.Drawing.Point(70, 631)
        Me.picboxDeleteAll.Name = "picboxDeleteAll"
        Me.picboxDeleteAll.Size = New System.Drawing.Size(61, 36)
        Me.picboxDeleteAll.TabIndex = 38
        Me.picboxDeleteAll.TabStop = False
        Me.picboxDeleteAll.Tag = "Delete All"
        AddHandler Me.picboxDeleteAll.MouseLeave, New System.EventHandler(AddressOf Me.picbox_MouseLeave)
        AddHandler Me.picboxDeleteAll.Click, New System.EventHandler(AddressOf Me.picboxDeleteAll_Click)
        AddHandler Me.picboxDeleteAll.MouseDown, New System.Windows.Forms.MouseEventHandler(AddressOf Me.picbox_MouseDown)
        AddHandler Me.picboxDeleteAll.MouseHover, New System.EventHandler(AddressOf Me.picbox_MouseHover)
        AddHandler Me.picboxDeleteAll.MouseUp, New System.Windows.Forms.MouseEventHandler(AddressOf Me.picbox_MouseUp)
        AddHandler Me.picboxDeleteAll.MouseEnter, New System.EventHandler(AddressOf Me.picbox_MouseEnter)
        ' 
        ' picboxDelete
        ' 
        Me.picboxDelete.Image = Global.DotNet_TWAIN_Demo.My.Resources.picboxDelete_Leave
        Me.picboxDelete.Location = New System.Drawing.Point(11, 631)
        Me.picboxDelete.Name = "picboxDelete"
        Me.picboxDelete.Size = New System.Drawing.Size(60, 36)
        Me.picboxDelete.TabIndex = 36
        Me.picboxDelete.TabStop = False
        Me.picboxDelete.Tag = "Delete Current Image"
        AddHandler Me.picboxDelete.MouseLeave, New System.EventHandler(AddressOf Me.picbox_MouseLeave)
        AddHandler Me.picboxDelete.Click, New System.EventHandler(AddressOf Me.picboxDelete_Click)
        AddHandler Me.picboxDelete.MouseDown, New System.Windows.Forms.MouseEventHandler(AddressOf Me.picbox_MouseDown)
        AddHandler Me.picboxDelete.MouseHover, New System.EventHandler(AddressOf Me.picbox_MouseHover)
        AddHandler Me.picboxDelete.MouseUp, New System.Windows.Forms.MouseEventHandler(AddressOf Me.picbox_MouseUp)
        AddHandler Me.picboxDelete.MouseEnter, New System.EventHandler(AddressOf Me.picbox_MouseEnter)
        ' 
        ' label4
        ' 
        Me.label4.AutoSize = True
        Me.label4.BackColor = System.Drawing.Color.White
        Me.label4.Font = New System.Drawing.Font("Segoe UI", 9.0F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CByte(0))
        Me.label4.Location = New System.Drawing.Point(9, 607)
        Me.label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.label4.Name = "label4"
        Me.label4.Size = New System.Drawing.Size(106, 15)
        Me.label4.TabIndex = 35
        Me.label4.Text = "Delete && Delete All"
        ' 
        ' picboxFirst
        ' 
        Me.picboxFirst.Image = Global.DotNet_TWAIN_Demo.My.Resources.picboxFirst_Leave
        Me.picboxFirst.Location = New System.Drawing.Point(159, 645)
        Me.picboxFirst.Name = "picboxFirst"
        Me.picboxFirst.Size = New System.Drawing.Size(50, 25)
        Me.picboxFirst.TabIndex = 42
        Me.picboxFirst.TabStop = False
        Me.picboxFirst.Tag = "First Image"
        AddHandler Me.picboxFirst.MouseLeave, New System.EventHandler(AddressOf Me.picbox_MouseLeave)
        AddHandler Me.picboxFirst.Click, New System.EventHandler(AddressOf Me.picboxFirst_Click)
        AddHandler Me.picboxFirst.MouseDown, New System.Windows.Forms.MouseEventHandler(AddressOf Me.picbox_MouseDown)
        AddHandler Me.picboxFirst.MouseHover, New System.EventHandler(AddressOf Me.picbox_MouseHover)
        AddHandler Me.picboxFirst.MouseUp, New System.Windows.Forms.MouseEventHandler(AddressOf Me.picbox_MouseUp)
        AddHandler Me.picboxFirst.MouseEnter, New System.EventHandler(AddressOf Me.picbox_MouseEnter)
        ' 
        ' picboxLast
        ' 
        Me.picboxLast.Image = Global.DotNet_TWAIN_Demo.My.Resources.picboxLast_Leave
        Me.picboxLast.Location = New System.Drawing.Point(478, 645)
        Me.picboxLast.Name = "picboxLast"
        Me.picboxLast.Size = New System.Drawing.Size(50, 25)
        Me.picboxLast.TabIndex = 43
        Me.picboxLast.TabStop = False
        Me.picboxLast.Tag = "Last Image"
        AddHandler Me.picboxLast.MouseLeave, New System.EventHandler(AddressOf Me.picbox_MouseLeave)
        AddHandler Me.picboxLast.Click, New System.EventHandler(AddressOf Me.picboxLast_Click)
        AddHandler Me.picboxLast.MouseDown, New System.Windows.Forms.MouseEventHandler(AddressOf Me.picbox_MouseDown)
        AddHandler Me.picboxLast.MouseHover, New System.EventHandler(AddressOf Me.picbox_MouseHover)
        AddHandler Me.picboxLast.MouseUp, New System.Windows.Forms.MouseEventHandler(AddressOf Me.picbox_MouseUp)
        AddHandler Me.picboxLast.MouseEnter, New System.EventHandler(AddressOf Me.picbox_MouseEnter)
        ' 
        ' picboxNext
        ' 
        Me.picboxNext.Image = Global.DotNet_TWAIN_Demo.My.Resources.picboxNext_Leave
        Me.picboxNext.Location = New System.Drawing.Point(422, 645)
        Me.picboxNext.Name = "picboxNext"
        Me.picboxNext.Size = New System.Drawing.Size(50, 25)
        Me.picboxNext.TabIndex = 44
        Me.picboxNext.TabStop = False
        Me.picboxNext.Tag = "Next Image"
        AddHandler Me.picboxNext.MouseLeave, New System.EventHandler(AddressOf Me.picbox_MouseLeave)
        AddHandler Me.picboxNext.Click, New System.EventHandler(AddressOf Me.picboxNext_Click)
        AddHandler Me.picboxNext.MouseDown, New System.Windows.Forms.MouseEventHandler(AddressOf Me.picbox_MouseDown)
        AddHandler Me.picboxNext.MouseHover, New System.EventHandler(AddressOf Me.picbox_MouseHover)
        AddHandler Me.picboxNext.MouseUp, New System.Windows.Forms.MouseEventHandler(AddressOf Me.picbox_MouseUp)
        AddHandler Me.picboxNext.MouseEnter, New System.EventHandler(AddressOf Me.picbox_MouseEnter)
        ' 
        ' picboxPrevious
        ' 
        Me.picboxPrevious.Image = Global.DotNet_TWAIN_Demo.My.Resources.picboxPrevious_Leave
        Me.picboxPrevious.Location = New System.Drawing.Point(215, 645)
        Me.picboxPrevious.Name = "picboxPrevious"
        Me.picboxPrevious.Size = New System.Drawing.Size(50, 25)
        Me.picboxPrevious.TabIndex = 47
        Me.picboxPrevious.TabStop = False
        Me.picboxPrevious.Tag = "Previous Image"
        AddHandler Me.picboxPrevious.MouseLeave, New System.EventHandler(AddressOf Me.picbox_MouseLeave)
        AddHandler Me.picboxPrevious.Click, New System.EventHandler(AddressOf Me.picboxPrevious_Click)
        AddHandler Me.picboxPrevious.MouseDown, New System.Windows.Forms.MouseEventHandler(AddressOf Me.picbox_MouseDown)
        AddHandler Me.picboxPrevious.MouseHover, New System.EventHandler(AddressOf Me.picbox_MouseHover)
        AddHandler Me.picboxPrevious.MouseUp, New System.Windows.Forms.MouseEventHandler(AddressOf Me.picbox_MouseUp)
        AddHandler Me.picboxPrevious.MouseEnter, New System.EventHandler(AddressOf Me.picbox_MouseEnter)
        ' 
        ' cbxViewMode
        ' 
        Me.cbxViewMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxViewMode.FormattingEnabled = True
        Me.cbxViewMode.Items.AddRange(New Object() {"1 x 1", "2 x 2", "3 x 3", "4 x 4", "5 x 5"})
        Me.cbxViewMode.Location = New System.Drawing.Point(534, 645)
        Me.cbxViewMode.Name = "cbxViewMode"
        Me.cbxViewMode.Size = New System.Drawing.Size(75, 23)
        Me.cbxViewMode.TabIndex = 48
        AddHandler Me.cbxViewMode.SelectedIndexChanged, New System.EventHandler(AddressOf Me.cbxLayout_SelectedIndexChanged)
        ' 
        ' picboxMin
        ' 
        Me.picboxMin.Image = Global.DotNet_TWAIN_Demo.My.Resources.picboxMin_Leave
        Me.picboxMin.Location = New System.Drawing.Point(840, 10)
        Me.picboxMin.Name = "picboxMin"
        Me.picboxMin.Size = New System.Drawing.Size(20, 20)
        Me.picboxMin.TabIndex = 73
        Me.picboxMin.TabStop = False
        AddHandler Me.picboxMin.MouseLeave, New System.EventHandler(AddressOf Me.picbox_MouseLeave)
        AddHandler Me.picboxMin.Click, New System.EventHandler(AddressOf Me.picboxMin_Click)
        AddHandler Me.picboxMin.MouseDown, New System.Windows.Forms.MouseEventHandler(AddressOf Me.picbox_MouseDown)
        AddHandler Me.picboxMin.MouseUp, New System.Windows.Forms.MouseEventHandler(AddressOf Me.picbox_MouseUp)
        AddHandler Me.picboxMin.MouseEnter, New System.EventHandler(AddressOf Me.picbox_MouseEnter)
        ' 
        ' picboxClose
        ' 
        Me.picboxClose.Image = Global.DotNet_TWAIN_Demo.My.Resources.picboxClose_Leave
        Me.picboxClose.Location = New System.Drawing.Point(864, 10)
        Me.picboxClose.Name = "picboxClose"
        Me.picboxClose.Size = New System.Drawing.Size(20, 20)
        Me.picboxClose.TabIndex = 74
        Me.picboxClose.TabStop = False
        AddHandler Me.picboxClose.MouseLeave, New System.EventHandler(AddressOf Me.picbox_MouseLeave)
        AddHandler Me.picboxClose.Click, New System.EventHandler(AddressOf Me.picboxClose_Click)
        AddHandler Me.picboxClose.MouseClick, New System.Windows.Forms.MouseEventHandler(AddressOf Me.picboxClose_MouseClick)
        AddHandler Me.picboxClose.MouseDown, New System.Windows.Forms.MouseEventHandler(AddressOf Me.picbox_MouseDown)
        AddHandler Me.picboxClose.MouseUp, New System.Windows.Forms.MouseEventHandler(AddressOf Me.picbox_MouseUp)
        AddHandler Me.picboxClose.MouseEnter, New System.EventHandler(AddressOf Me.picbox_MouseEnter)
        ' 
        ' lbDiv
        ' 
        Me.lbDiv.AutoSize = True
        Me.lbDiv.BackColor = System.Drawing.Color.Transparent
        Me.lbDiv.Location = New System.Drawing.Point(339, 650)
        Me.lbDiv.Name = "lbDiv"
        Me.lbDiv.Size = New System.Drawing.Size(12, 15)
        Me.lbDiv.TabIndex = 75
        Me.lbDiv.Text = "/"
        ' 
        ' tbxCurrentImageIndex
        ' 
        Me.tbxCurrentImageIndex.Enabled = False
        Me.tbxCurrentImageIndex.Location = New System.Drawing.Point(271, 647)
        Me.tbxCurrentImageIndex.Name = "tbxCurrentImageIndex"
        Me.tbxCurrentImageIndex.[ReadOnly] = True
        Me.tbxCurrentImageIndex.Size = New System.Drawing.Size(61, 23)
        Me.tbxCurrentImageIndex.TabIndex = 76
        Me.tbxCurrentImageIndex.Text = "0"
        Me.tbxCurrentImageIndex.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        ' 
        ' tbxTotalImageNum
        ' 
        Me.tbxTotalImageNum.Enabled = False
        Me.tbxTotalImageNum.Location = New System.Drawing.Point(355, 647)
        Me.tbxTotalImageNum.Name = "tbxTotalImageNum"
        Me.tbxTotalImageNum.[ReadOnly] = True
        Me.tbxTotalImageNum.Size = New System.Drawing.Size(61, 23)
        Me.tbxTotalImageNum.TabIndex = 77
        Me.tbxTotalImageNum.Text = "0"
        ' 
        ' openFileDialog
        ' 
        Me.openFileDialog.FileName = "openFileDialog1"
        ' 
        ' flowLayoutPanel2
        ' 
        Me.flowLayoutPanel2.BackColor = System.Drawing.Color.White
        Me.flowLayoutPanel2.Location = New System.Drawing.Point(623, 48)
        Me.flowLayoutPanel2.Margin = New System.Windows.Forms.Padding(0)
        Me.flowLayoutPanel2.Name = "flowLayoutPanel2"
        Me.flowLayoutPanel2.Size = New System.Drawing.Size(274, 628)
        Me.flowLayoutPanel2.TabIndex = 84
        ' 
        ' panelLoad
        ' 
        Me.panelLoad.BackColor = System.Drawing.Color.Transparent
        Me.panelLoad.Controls.Add(Me.panel1)
        Me.panelLoad.Controls.Add(Me.picboxLoadImage)
        Me.panelLoad.Controls.Add(Me.label1)
        Me.panelLoad.Location = New System.Drawing.Point(1, 41)
        Me.panelLoad.Margin = New System.Windows.Forms.Padding(0)
        Me.panelLoad.Name = "panelLoad"
        Me.panelLoad.Size = New System.Drawing.Size(248, 140)
        Me.panelLoad.TabIndex = 3
        Me.panelLoad.Visible = False
        ' 
        ' panel1
        ' 
        Me.panel1.Controls.Add(Me.label24)
        Me.panel1.Location = New System.Drawing.Point(10, 95)
        Me.panel1.Name = "panel1"
        Me.panel1.Size = New System.Drawing.Size(228, 30)
        Me.panel1.TabIndex = 3
        ' 
        ' label24
        ' 
        Me.label24.Dock = System.Windows.Forms.DockStyle.Fill
        Me.label24.Location = New System.Drawing.Point(0, 0)
        Me.label24.Name = "label24"
        Me.label24.Size = New System.Drawing.Size(228, 30)
        Me.label24.TabIndex = 0
        Me.label24.Text = "Note: PDF library is used when loading PDF files."
        ' 
        ' picboxLoadImage
        ' 
        Me.picboxLoadImage.Image = Global.DotNet_TWAIN_Demo.My.Resources.picboxLoadImage_Leave
        Me.picboxLoadImage.InitialImage = Nothing
        Me.picboxLoadImage.Location = New System.Drawing.Point(38, 42)
        Me.picboxLoadImage.Name = "picboxLoadImage"
        Me.picboxLoadImage.Size = New System.Drawing.Size(180, 38)
        Me.picboxLoadImage.TabIndex = 1
        Me.picboxLoadImage.TabStop = False
        ' 
        ' label1
        ' 
        Me.label1.AutoSize = True
        Me.label1.Font = New System.Drawing.Font("Segoe UI", 9.0F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CByte(0))
        Me.label1.Location = New System.Drawing.Point(19, 10)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(164, 15)
        Me.label1.TabIndex = 0
        Me.label1.Text = "Load local images or PDF files"
        ' 
        ' panelAcquire
        ' 
        Me.panelAcquire.BackColor = System.Drawing.Color.Transparent
        Me.panelAcquire.Controls.Add(Me.lbUnknowSource)
        Me.panelAcquire.Controls.Add(Me.panelGrab)
        Me.panelAcquire.Controls.Add(Me.panelScan)
        Me.panelAcquire.Controls.Add(Me.lbSelectSource)
        Me.panelAcquire.Controls.Add(Me.cbxSource)
        Me.panelAcquire.Location = New System.Drawing.Point(1, 41)
        Me.panelAcquire.Margin = New System.Windows.Forms.Padding(0)
        Me.panelAcquire.Name = "panelAcquire"
        Me.panelAcquire.Size = New System.Drawing.Size(248, 228)
        Me.panelAcquire.TabIndex = 2
        ' 
        ' lbUnknowSource
        ' 
        Me.lbUnknowSource.AutoSize = True
        Me.lbUnknowSource.ForeColor = System.Drawing.Color.Red
        Me.lbUnknowSource.Location = New System.Drawing.Point(75, 80)
        Me.lbUnknowSource.Name = "lbUnknowSource"
        Me.lbUnknowSource.Size = New System.Drawing.Size(111, 13)
        Me.lbUnknowSource.TabIndex = 87
        Me.lbUnknowSource.Text = "It's an unknow source"
        Me.lbUnknowSource.Visible = False
        ' 
        ' panelGrab
        ' 
        Me.panelGrab.Controls.Add(Me.picboxGrab)
        Me.panelGrab.Controls.Add(Me.cbxResolutionForWebcam)
        Me.panelGrab.Controls.Add(Me.label21)
        Me.panelGrab.Controls.Add(Me.label20)
        Me.panelGrab.Controls.Add(Me.chkShowUIForWebcam)
        Me.panelGrab.Location = New System.Drawing.Point(0, 50)
        Me.panelGrab.Name = "panelGrab"
        Me.panelGrab.Size = New System.Drawing.Size(248, 175)
        Me.panelGrab.TabIndex = 86
        ' 
        ' picboxGrab
        ' 
        Me.picboxGrab.Enabled = False
        Me.picboxGrab.Image = Global.DotNet_TWAIN_Demo.My.Resources.picboxGrab_Disabled
        Me.picboxGrab.Location = New System.Drawing.Point(38, 80)
        Me.picboxGrab.Name = "picboxGrab"
        Me.picboxGrab.Size = New System.Drawing.Size(180, 38)
        Me.picboxGrab.TabIndex = 91
        Me.picboxGrab.TabStop = False
        AddHandler Me.picboxGrab.MouseLeave, New System.EventHandler(AddressOf Me.picbox_MouseLeave)
        AddHandler Me.picboxGrab.Click, New System.EventHandler(AddressOf Me.picboxGrab_Click)
        AddHandler Me.picboxGrab.MouseDown, New System.Windows.Forms.MouseEventHandler(AddressOf Me.picbox_MouseDown)
        AddHandler Me.picboxGrab.MouseUp, New System.Windows.Forms.MouseEventHandler(AddressOf Me.picbox_MouseUp)
        AddHandler Me.picboxGrab.MouseEnter, New System.EventHandler(AddressOf Me.picbox_MouseEnter)
        ' 
        ' cbxResolutionForWebcam
        ' 
        Me.cbxResolutionForWebcam.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxResolutionForWebcam.Enabled = False
        Me.cbxResolutionForWebcam.Font = New System.Drawing.Font("Segoe UI", 9.0F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CByte(0))
        Me.cbxResolutionForWebcam.FormattingEnabled = True
        Me.cbxResolutionForWebcam.Location = New System.Drawing.Point(99, 30)
        Me.cbxResolutionForWebcam.Name = "cbxResolutionForWebcam"
        Me.cbxResolutionForWebcam.Size = New System.Drawing.Size(130, 23)
        Me.cbxResolutionForWebcam.TabIndex = 90
        ' 
        ' label21
        ' 
        Me.label21.AutoSize = True
        Me.label21.BackColor = System.Drawing.Color.Transparent
        Me.label21.Font = New System.Drawing.Font("Segoe UI", 9.0F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CByte(0))
        Me.label21.Location = New System.Drawing.Point(17, 35)
        Me.label21.Name = "label21"
        Me.label21.Size = New System.Drawing.Size(69, 15)
        Me.label21.TabIndex = 89
        Me.label21.Text = "Resolution :"
        ' 
        ' label20
        ' 
        Me.label20.Location = New System.Drawing.Point(0, 0)
        Me.label20.Name = "label20"
        Me.label20.Size = New System.Drawing.Size(100, 23)
        Me.label20.TabIndex = 92
        ' 
        ' chkShowUIForWebcam
        ' 
        Me.chkShowUIForWebcam.AutoSize = True
        Me.chkShowUIForWebcam.BackColor = System.Drawing.Color.Transparent
        Me.chkShowUIForWebcam.Enabled = False
        Me.chkShowUIForWebcam.Font = New System.Drawing.Font("Segoe UI", 9.0F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CByte(0))
        Me.chkShowUIForWebcam.Location = New System.Drawing.Point(20, 11)
        Me.chkShowUIForWebcam.Name = "chkShowUIForWebcam"
        Me.chkShowUIForWebcam.Size = New System.Drawing.Size(69, 19)
        Me.chkShowUIForWebcam.TabIndex = 84
        Me.chkShowUIForWebcam.Text = "Show UI"
        Me.chkShowUIForWebcam.UseVisualStyleBackColor = False
        ' 
        ' panelScan
        ' 
        Me.panelScan.Controls.Add(Me.rdbtnGray)
        Me.panelScan.Controls.Add(Me.chkShowUI)
        Me.panelScan.Controls.Add(Me.cbxResolution)
        Me.panelScan.Controls.Add(Me.picboxScan)
        Me.panelScan.Controls.Add(Me.rdbtnBW)
        Me.panelScan.Controls.Add(Me.lbResolution)
        Me.panelScan.Controls.Add(Me.rdbtnColor)
        Me.panelScan.Controls.Add(Me.chkADF)
        Me.panelScan.Controls.Add(Me.chkDuplex)
        Me.panelScan.Controls.Add(Me.lbPixelType)
        Me.panelScan.Location = New System.Drawing.Point(0, 50)
        Me.panelScan.Name = "panelScan"
        Me.panelScan.Size = New System.Drawing.Size(248, 175)
        Me.panelScan.TabIndex = 85
        ' 
        ' rdbtnGray
        ' 
        Me.rdbtnGray.AutoSize = True
        Me.rdbtnGray.Font = New System.Drawing.Font("Segoe UI", 9.0F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CByte(0))
        Me.rdbtnGray.Location = New System.Drawing.Point(101, 67)
        Me.rdbtnGray.Name = "rdbtnGray"
        Me.rdbtnGray.Size = New System.Drawing.Size(49, 19)
        Me.rdbtnGray.TabIndex = 88
        Me.rdbtnGray.TabStop = True
        Me.rdbtnGray.Text = "Gray"
        Me.rdbtnGray.UseVisualStyleBackColor = True
        ' 
        ' chkShowUI
        ' 
        Me.chkShowUI.AutoSize = True
        Me.chkShowUI.BackColor = System.Drawing.Color.Transparent
        Me.chkShowUI.Enabled = False
        Me.chkShowUI.Font = New System.Drawing.Font("Segoe UI", 9.0F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CByte(0))
        Me.chkShowUI.Location = New System.Drawing.Point(20, 11)
        Me.chkShowUI.Name = "chkShowUI"
        Me.chkShowUI.Size = New System.Drawing.Size(69, 19)
        Me.chkShowUI.TabIndex = 83
        Me.chkShowUI.Text = "Show UI"
        Me.chkShowUI.UseVisualStyleBackColor = False
        ' 
        ' cbxResolution
        ' 
        Me.cbxResolution.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxResolution.Enabled = False
        Me.cbxResolution.Font = New System.Drawing.Font("Segoe UI", 9.0F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CByte(0))
        Me.cbxResolution.FormattingEnabled = True
        Me.cbxResolution.Location = New System.Drawing.Point(99, 93)
        Me.cbxResolution.Name = "cbxResolution"
        Me.cbxResolution.Size = New System.Drawing.Size(130, 23)
        Me.cbxResolution.TabIndex = 84
        ' 
        ' picboxScan
        ' 
        Me.picboxScan.Enabled = False
        Me.picboxScan.Image = Global.DotNet_TWAIN_Demo.My.Resources.picboxScan_Disabled
        Me.picboxScan.Location = New System.Drawing.Point(37, 125)
        Me.picboxScan.Name = "picboxScan"
        Me.picboxScan.Size = New System.Drawing.Size(180, 38)
        Me.picboxScan.TabIndex = 85
        Me.picboxScan.TabStop = False
        Me.picboxScan.Tag = "Scan Image"
        AddHandler Me.picboxScan.MouseLeave, New System.EventHandler(AddressOf Me.picbox_MouseLeave)
        AddHandler Me.picboxScan.Click, New System.EventHandler(AddressOf Me.picboxScan_Click)
        AddHandler Me.picboxScan.MouseDown, New System.Windows.Forms.MouseEventHandler(AddressOf Me.picbox_MouseDown)
        AddHandler Me.picboxScan.MouseUp, New System.Windows.Forms.MouseEventHandler(AddressOf Me.picbox_MouseUp)
        AddHandler Me.picboxScan.MouseEnter, New System.EventHandler(AddressOf Me.picbox_MouseEnter)
        ' 
        ' rdbtnBW
        ' 
        Me.rdbtnBW.AutoSize = True
        Me.rdbtnBW.Font = New System.Drawing.Font("Segoe UI", 9.0F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CByte(0))
        Me.rdbtnBW.Location = New System.Drawing.Point(20, 67)
        Me.rdbtnBW.Name = "rdbtnBW"
        Me.rdbtnBW.Size = New System.Drawing.Size(59, 19)
        Me.rdbtnBW.TabIndex = 88
        Me.rdbtnBW.TabStop = True
        Me.rdbtnBW.Text = "B && W"
        Me.rdbtnBW.UseVisualStyleBackColor = True
        ' 
        ' lbResolution
        ' 
        Me.lbResolution.AutoSize = True
        Me.lbResolution.BackColor = System.Drawing.Color.Transparent
        Me.lbResolution.Font = New System.Drawing.Font("Segoe UI", 9.0F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CByte(0))
        Me.lbResolution.Location = New System.Drawing.Point(20, 96)
        Me.lbResolution.Name = "lbResolution"
        Me.lbResolution.Size = New System.Drawing.Size(69, 15)
        Me.lbResolution.TabIndex = 83
        Me.lbResolution.Text = "Resolution :"
        ' 
        ' rdbtnColor
        ' 
        Me.rdbtnColor.AutoSize = True
        Me.rdbtnColor.BackColor = System.Drawing.Color.Transparent
        Me.rdbtnColor.Font = New System.Drawing.Font("Segoe UI", 9.0F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CByte(0))
        Me.rdbtnColor.Location = New System.Drawing.Point(170, 67)
        Me.rdbtnColor.Name = "rdbtnColor"
        Me.rdbtnColor.Size = New System.Drawing.Size(54, 19)
        Me.rdbtnColor.TabIndex = 54
        Me.rdbtnColor.Text = "Color"
        Me.rdbtnColor.UseVisualStyleBackColor = False
        ' 
        ' chkADF
        ' 
        Me.chkADF.AutoSize = True
        Me.chkADF.BackColor = System.Drawing.Color.Transparent
        Me.chkADF.Enabled = False
        Me.chkADF.Font = New System.Drawing.Font("Segoe UI", 9.0F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CByte(0))
        Me.chkADF.Location = New System.Drawing.Point(101, 11)
        Me.chkADF.Name = "chkADF"
        Me.chkADF.Size = New System.Drawing.Size(48, 19)
        Me.chkADF.TabIndex = 51
        Me.chkADF.Text = "ADF"
        Me.chkADF.UseVisualStyleBackColor = False
        ' 
        ' chkDuplex
        ' 
        Me.chkDuplex.AutoSize = True
        Me.chkDuplex.BackColor = System.Drawing.Color.Transparent
        Me.chkDuplex.Enabled = False
        Me.chkDuplex.Font = New System.Drawing.Font("Segoe UI", 9.0F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CByte(0))
        Me.chkDuplex.Location = New System.Drawing.Point(170, 11)
        Me.chkDuplex.Name = "chkDuplex"
        Me.chkDuplex.Size = New System.Drawing.Size(62, 19)
        Me.chkDuplex.TabIndex = 83
        Me.chkDuplex.Text = "Duplex"
        Me.chkDuplex.UseVisualStyleBackColor = False
        ' 
        ' lbPixelType
        ' 
        Me.lbPixelType.AutoSize = True
        Me.lbPixelType.BackColor = System.Drawing.Color.Transparent
        Me.lbPixelType.Font = New System.Drawing.Font("Segoe UI", 9.0F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CByte(0))
        Me.lbPixelType.Location = New System.Drawing.Point(17, 42)
        Me.lbPixelType.Name = "lbPixelType"
        Me.lbPixelType.Size = New System.Drawing.Size(66, 15)
        Me.lbPixelType.TabIndex = 87
        Me.lbPixelType.Text = "Pixel Type :"
        ' 
        ' lbSelectSource
        ' 
        Me.lbSelectSource.AutoSize = True
        Me.lbSelectSource.BackColor = System.Drawing.Color.Transparent
        Me.lbSelectSource.Font = New System.Drawing.Font("Segoe UI", 9.0F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CByte(0))
        Me.lbSelectSource.Location = New System.Drawing.Point(14, 3)
        Me.lbSelectSource.Name = "lbSelectSource"
        Me.lbSelectSource.Size = New System.Drawing.Size(83, 15)
        Me.lbSelectSource.TabIndex = 84
        Me.lbSelectSource.Text = "Select Source :"
        ' 
        ' cbxSource
        ' 
        Me.cbxSource.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxSource.Font = New System.Drawing.Font("Calibri", 9.0F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CByte(0))
        Me.cbxSource.FormattingEnabled = True
        Me.cbxSource.Location = New System.Drawing.Point(16, 27)
        Me.cbxSource.Name = "cbxSource"
        Me.cbxSource.Size = New System.Drawing.Size(216, 22)
        Me.cbxSource.TabIndex = 84
        AddHandler Me.cbxSource.SelectedIndexChanged, New System.EventHandler(AddressOf Me.cbxSource_SelectedIndexChanged)
        ' 
        ' panelAddBarcode
        ' 
        Me.panelAddBarcode.BackColor = System.Drawing.Color.Transparent
        Me.panelAddBarcode.Controls.Add(Me.picboxAddBarcode)
        Me.panelAddBarcode.Controls.Add(Me.tbxBarcodeScale)
        Me.panelAddBarcode.Controls.Add(Me.tbxHumanReadableText)
        Me.panelAddBarcode.Controls.Add(Me.tbxBarcodeLocationY)
        Me.panelAddBarcode.Controls.Add(Me.tbxBarcodeLocationX)
        Me.panelAddBarcode.Controls.Add(Me.tbxBarcodeContent)
        Me.panelAddBarcode.Controls.Add(Me.cbxGenBarcodeFormat)
        Me.panelAddBarcode.Controls.Add(Me.label19)
        Me.panelAddBarcode.Controls.Add(Me.label18)
        Me.panelAddBarcode.Controls.Add(Me.label17)
        Me.panelAddBarcode.Controls.Add(Me.label16)
        Me.panelAddBarcode.Controls.Add(Me.label15)
        Me.panelAddBarcode.Controls.Add(Me.label14)
        Me.panelAddBarcode.Controls.Add(Me.label13)
        Me.panelAddBarcode.Location = New System.Drawing.Point(1, 41)
        Me.panelAddBarcode.Margin = New System.Windows.Forms.Padding(0)
        Me.panelAddBarcode.Name = "panelAddBarcode"
        Me.panelAddBarcode.Size = New System.Drawing.Size(248, 320)
        Me.panelAddBarcode.TabIndex = 3
        Me.panelAddBarcode.Visible = False
        ' 
        ' picboxAddBarcode
        ' 
        Me.picboxAddBarcode.Image = Global.DotNet_TWAIN_Demo.My.Resources.picboxAddBarcode_Disabled
        Me.picboxAddBarcode.Location = New System.Drawing.Point(38, 273)
        Me.picboxAddBarcode.Name = "picboxAddBarcode"
        Me.picboxAddBarcode.Size = New System.Drawing.Size(180, 38)
        Me.picboxAddBarcode.TabIndex = 21
        Me.picboxAddBarcode.TabStop = False
        AddHandler Me.picboxAddBarcode.MouseLeave, New System.EventHandler(AddressOf Me.picbox_MouseLeave)
        AddHandler Me.picboxAddBarcode.Click, New System.EventHandler(AddressOf Me.picboxAddBarcode_Click)
        AddHandler Me.picboxAddBarcode.MouseDown, New System.Windows.Forms.MouseEventHandler(AddressOf Me.picbox_MouseDown)
        AddHandler Me.picboxAddBarcode.MouseUp, New System.Windows.Forms.MouseEventHandler(AddressOf Me.picbox_MouseUp)
        AddHandler Me.picboxAddBarcode.MouseEnter, New System.EventHandler(AddressOf Me.picbox_MouseEnter)
        ' 
        ' tbxBarcodeScale
        ' 
        Me.tbxBarcodeScale.Location = New System.Drawing.Point(21, 242)
        Me.tbxBarcodeScale.Name = "tbxBarcodeScale"
        Me.tbxBarcodeScale.Size = New System.Drawing.Size(208, 20)
        Me.tbxBarcodeScale.TabIndex = 20
        AddHandler Me.tbxBarcodeScale.KeyPress, New System.Windows.Forms.KeyPressEventHandler(AddressOf Me.tbxBarcodeScale_KeyPress)
        ' 
        ' tbxHumanReadableText
        ' 
        Me.tbxHumanReadableText.Location = New System.Drawing.Point(22, 191)
        Me.tbxHumanReadableText.Name = "tbxHumanReadableText"
        Me.tbxHumanReadableText.Size = New System.Drawing.Size(207, 20)
        Me.tbxHumanReadableText.TabIndex = 19
        ' 
        ' tbxBarcodeLocationY
        ' 
        Me.tbxBarcodeLocationY.Location = New System.Drawing.Point(151, 135)
        Me.tbxBarcodeLocationY.Name = "tbxBarcodeLocationY"
        Me.tbxBarcodeLocationY.Size = New System.Drawing.Size(60, 20)
        Me.tbxBarcodeLocationY.TabIndex = 18
        AddHandler Me.tbxBarcodeLocationY.KeyPress, New System.Windows.Forms.KeyPressEventHandler(AddressOf Me.tbxBarcodeLocation_KeyPress)
        ' 
        ' tbxBarcodeLocationX
        ' 
        Me.tbxBarcodeLocationX.Location = New System.Drawing.Point(45, 136)
        Me.tbxBarcodeLocationX.Name = "tbxBarcodeLocationX"
        Me.tbxBarcodeLocationX.Size = New System.Drawing.Size(60, 20)
        Me.tbxBarcodeLocationX.TabIndex = 17
        AddHandler Me.tbxBarcodeLocationX.KeyPress, New System.Windows.Forms.KeyPressEventHandler(AddressOf Me.tbxBarcodeLocation_KeyPress)
        ' 
        ' tbxBarcodeContent
        ' 
        Me.tbxBarcodeContent.Location = New System.Drawing.Point(22, 83)
        Me.tbxBarcodeContent.Name = "tbxBarcodeContent"
        Me.tbxBarcodeContent.Size = New System.Drawing.Size(206, 20)
        Me.tbxBarcodeContent.TabIndex = 16
        ' 
        ' cbxGenBarcodeFormat
        ' 
        Me.cbxGenBarcodeFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxGenBarcodeFormat.FormattingEnabled = True
        Me.cbxGenBarcodeFormat.Location = New System.Drawing.Point(21, 29)
        Me.cbxGenBarcodeFormat.Name = "cbxGenBarcodeFormat"
        Me.cbxGenBarcodeFormat.Size = New System.Drawing.Size(208, 21)
        Me.cbxGenBarcodeFormat.TabIndex = 15
        ' 
        ' label19
        ' 
        Me.label19.AutoSize = True
        Me.label19.BackColor = System.Drawing.Color.Transparent
        Me.label19.Font = New System.Drawing.Font("Segoe UI", 9.0F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CByte(0))
        Me.label19.Location = New System.Drawing.Point(19, 219)
        Me.label19.Name = "label19"
        Me.label19.Size = New System.Drawing.Size(40, 15)
        Me.label19.TabIndex = 14
        Me.label19.Text = "Scale :"
        ' 
        ' label18
        ' 
        Me.label18.AutoSize = True
        Me.label18.BackColor = System.Drawing.Color.Transparent
        Me.label18.Font = New System.Drawing.Font("Segoe UI", 9.0F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CByte(0))
        Me.label18.Location = New System.Drawing.Point(19, 168)
        Me.label18.Name = "label18"
        Me.label18.Size = New System.Drawing.Size(129, 15)
        Me.label18.TabIndex = 13
        Me.label18.Text = "Human Readable Text :"
        ' 
        ' label17
        ' 
        Me.label17.AutoSize = True
        Me.label17.BackColor = System.Drawing.Color.Transparent
        Me.label17.Font = New System.Drawing.Font("Segoe UI", 9.0F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CByte(0))
        Me.label17.Location = New System.Drawing.Point(125, 138)
        Me.label17.Name = "label17"
        Me.label17.Size = New System.Drawing.Size(20, 15)
        Me.label17.TabIndex = 12
        Me.label17.Text = "Y :"
        ' 
        ' label16
        ' 
        Me.label16.AutoSize = True
        Me.label16.BackColor = System.Drawing.Color.Transparent
        Me.label16.Font = New System.Drawing.Font("Segoe UI", 9.0F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CByte(0))
        Me.label16.Location = New System.Drawing.Point(19, 138)
        Me.label16.Name = "label16"
        Me.label16.Size = New System.Drawing.Size(20, 15)
        Me.label16.TabIndex = 11
        Me.label16.Text = "X :"
        ' 
        ' label15
        ' 
        Me.label15.AutoSize = True
        Me.label15.BackColor = System.Drawing.Color.Transparent
        Me.label15.Font = New System.Drawing.Font("Segoe UI", 9.0F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CByte(0))
        Me.label15.Location = New System.Drawing.Point(19, 113)
        Me.label15.Name = "label15"
        Me.label15.Size = New System.Drawing.Size(151, 15)
        Me.label15.TabIndex = 10
        Me.label15.Text = "Barcode Content Location :"
        ' 
        ' label14
        ' 
        Me.label14.AutoSize = True
        Me.label14.BackColor = System.Drawing.Color.Transparent
        Me.label14.Font = New System.Drawing.Font("Segoe UI", 9.0F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CByte(0))
        Me.label14.Location = New System.Drawing.Point(18, 61)
        Me.label14.Name = "label14"
        Me.label14.Size = New System.Drawing.Size(102, 15)
        Me.label14.TabIndex = 9
        Me.label14.Text = "Barcode Content :"
        ' 
        ' label13
        ' 
        Me.label13.AutoSize = True
        Me.label13.BackColor = System.Drawing.Color.Transparent
        Me.label13.Font = New System.Drawing.Font("Segoe UI", 9.0F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CByte(0))
        Me.label13.Location = New System.Drawing.Point(18, 8)
        Me.label13.Name = "label13"
        Me.label13.Size = New System.Drawing.Size(97, 15)
        Me.label13.TabIndex = 8
        Me.label13.Text = "Barcode Format :"
        ' 
        ' panelReadBarcode
        ' 
        Me.panelReadBarcode.BackColor = System.Drawing.Color.Transparent
        Me.panelReadBarcode.Controls.Add(Me.picboxReadBarcode)
        Me.panelReadBarcode.Controls.Add(Me.label6)
        Me.panelReadBarcode.Controls.Add(Me.label7)
        Me.panelReadBarcode.Controls.Add(Me.tbxBottom)
        Me.panelReadBarcode.Controls.Add(Me.tbxMaxBarcodeReads)
        Me.panelReadBarcode.Controls.Add(Me.cbxBarcodeFormat)
        Me.panelReadBarcode.Controls.Add(Me.tbxTop)
        Me.panelReadBarcode.Controls.Add(Me.label8)
        Me.panelReadBarcode.Controls.Add(Me.label9)
        Me.panelReadBarcode.Controls.Add(Me.tbxRight)
        Me.panelReadBarcode.Controls.Add(Me.label10)
        Me.panelReadBarcode.Controls.Add(Me.label11)
        Me.panelReadBarcode.Controls.Add(Me.tbxLeft)
        Me.panelReadBarcode.Controls.Add(Me.label12)
        Me.panelReadBarcode.Location = New System.Drawing.Point(1, 41)
        Me.panelReadBarcode.Margin = New System.Windows.Forms.Padding(0)
        Me.panelReadBarcode.Name = "panelReadBarcode"
        Me.panelReadBarcode.Size = New System.Drawing.Size(248, 225)
        Me.panelReadBarcode.TabIndex = 2
        Me.panelReadBarcode.Visible = False
        ' 
        ' picboxReadBarcode
        ' 
        Me.picboxReadBarcode.Image = Global.DotNet_TWAIN_Demo.My.Resources.picboxReadBarcode_Disabled
        Me.picboxReadBarcode.Location = New System.Drawing.Point(38, 176)
        Me.picboxReadBarcode.Name = "picboxReadBarcode"
        Me.picboxReadBarcode.Size = New System.Drawing.Size(180, 38)
        Me.picboxReadBarcode.TabIndex = 15
        Me.picboxReadBarcode.TabStop = False
        AddHandler Me.picboxReadBarcode.MouseLeave, New System.EventHandler(AddressOf Me.picbox_MouseLeave)
        AddHandler Me.picboxReadBarcode.Click, New System.EventHandler(AddressOf Me.picboxReadBarcode_Click)
        AddHandler Me.picboxReadBarcode.MouseDown, New System.Windows.Forms.MouseEventHandler(AddressOf Me.picbox_MouseDown)
        AddHandler Me.picboxReadBarcode.MouseUp, New System.Windows.Forms.MouseEventHandler(AddressOf Me.picbox_MouseUp)
        AddHandler Me.picboxReadBarcode.MouseEnter, New System.EventHandler(AddressOf Me.picbox_MouseEnter)
        ' 
        ' label6
        ' 
        Me.label6.AutoSize = True
        Me.label6.BackColor = System.Drawing.Color.Transparent
        Me.label6.Font = New System.Drawing.Font("Segoe UI", 9.0F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CByte(0))
        Me.label6.Location = New System.Drawing.Point(18, 15)
        Me.label6.Name = "label6"
        Me.label6.Size = New System.Drawing.Size(97, 15)
        Me.label6.TabIndex = 2
        Me.label6.Text = "Barcode Format :"
        ' 
        ' label7
        ' 
        Me.label7.AutoSize = True
        Me.label7.BackColor = System.Drawing.Color.Transparent
        Me.label7.Font = New System.Drawing.Font("Segoe UI", 9.0F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CByte(0))
        Me.label7.Location = New System.Drawing.Point(18, 49)
        Me.label7.Name = "label7"
        Me.label7.Size = New System.Drawing.Size(147, 15)
        Me.label7.TabIndex = 3
        Me.label7.Text = "Maximum Barcode Reads :"
        ' 
        ' tbxBottom
        ' 
        Me.tbxBottom.Location = New System.Drawing.Point(169, 141)
        Me.tbxBottom.Name = "tbxBottom"
        Me.tbxBottom.[ReadOnly] = True
        Me.tbxBottom.Size = New System.Drawing.Size(60, 20)
        Me.tbxBottom.TabIndex = 14
        ' 
        ' tbxMaxBarcodeReads
        ' 
        Me.tbxMaxBarcodeReads.Location = New System.Drawing.Point(177, 47)
        Me.tbxMaxBarcodeReads.Name = "tbxMaxBarcodeReads"
        Me.tbxMaxBarcodeReads.Size = New System.Drawing.Size(50, 20)
        Me.tbxMaxBarcodeReads.TabIndex = 4
        AddHandler Me.tbxMaxBarcodeReads.KeyPress, New System.Windows.Forms.KeyPressEventHandler(AddressOf Me.tbxBarcodeLocation_KeyPress)
        ' 
        ' cbxBarcodeFormat
        ' 
        Me.cbxBarcodeFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxBarcodeFormat.FormattingEnabled = True
        Me.cbxBarcodeFormat.ItemHeight = 13
        Me.cbxBarcodeFormat.Location = New System.Drawing.Point(120, 11)
        Me.cbxBarcodeFormat.Name = "cbxBarcodeFormat"
        Me.cbxBarcodeFormat.Size = New System.Drawing.Size(106, 21)
        Me.cbxBarcodeFormat.TabIndex = 5
        ' 
        ' tbxTop
        ' 
        Me.tbxTop.Location = New System.Drawing.Point(55, 141)
        Me.tbxTop.Name = "tbxTop"
        Me.tbxTop.[ReadOnly] = True
        Me.tbxTop.Size = New System.Drawing.Size(60, 20)
        Me.tbxTop.TabIndex = 13
        ' 
        ' label8
        ' 
        Me.label8.AutoSize = True
        Me.label8.BackColor = System.Drawing.Color.Transparent
        Me.label8.Font = New System.Drawing.Font("Segoe UI", 9.0F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CByte(0))
        Me.label8.Location = New System.Drawing.Point(18, 77)
        Me.label8.Name = "label8"
        Me.label8.Size = New System.Drawing.Size(211, 15)
        Me.label8.TabIndex = 6
        Me.label8.Text = "Selected Rectangle Area Of the Image :"
        ' 
        ' label9
        ' 
        Me.label9.AutoSize = True
        Me.label9.BackColor = System.Drawing.Color.Transparent
        Me.label9.Font = New System.Drawing.Font("Segoe UI", 9.0F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CByte(0))
        Me.label9.Location = New System.Drawing.Point(19, 109)
        Me.label9.Name = "label9"
        Me.label9.Size = New System.Drawing.Size(33, 15)
        Me.label9.TabIndex = 7
        Me.label9.Text = "Left :"
        ' 
        ' tbxRight
        ' 
        Me.tbxRight.Location = New System.Drawing.Point(169, 106)
        Me.tbxRight.Name = "tbxRight"
        Me.tbxRight.[ReadOnly] = True
        Me.tbxRight.Size = New System.Drawing.Size(60, 20)
        Me.tbxRight.TabIndex = 12
        ' 
        ' label10
        ' 
        Me.label10.AutoSize = True
        Me.label10.BackColor = System.Drawing.Color.Transparent
        Me.label10.Font = New System.Drawing.Font("Segoe UI", 9.0F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CByte(0))
        Me.label10.Location = New System.Drawing.Point(127, 109)
        Me.label10.Name = "label10"
        Me.label10.Size = New System.Drawing.Size(41, 15)
        Me.label10.TabIndex = 8
        Me.label10.Text = "Right :"
        ' 
        ' label11
        ' 
        Me.label11.AutoSize = True
        Me.label11.BackColor = System.Drawing.Color.Transparent
        Me.label11.Font = New System.Drawing.Font("Segoe UI", 9.0F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CByte(0))
        Me.label11.Location = New System.Drawing.Point(18, 143)
        Me.label11.Name = "label11"
        Me.label11.Size = New System.Drawing.Size(34, 15)
        Me.label11.TabIndex = 9
        Me.label11.Text = "Top :"
        ' 
        ' tbxLeft
        ' 
        Me.tbxLeft.Location = New System.Drawing.Point(55, 107)
        Me.tbxLeft.Name = "tbxLeft"
        Me.tbxLeft.[ReadOnly] = True
        Me.tbxLeft.Size = New System.Drawing.Size(60, 20)
        Me.tbxLeft.TabIndex = 11
        ' 
        ' label12
        ' 
        Me.label12.AutoSize = True
        Me.label12.BackColor = System.Drawing.Color.Transparent
        Me.label12.Font = New System.Drawing.Font("Segoe UI", 9.0F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CByte(0))
        Me.label12.Location = New System.Drawing.Point(115, 143)
        Me.label12.Name = "label12"
        Me.label12.Size = New System.Drawing.Size(53, 15)
        Me.label12.TabIndex = 10
        Me.label12.Text = "Bottom :"
        ' 
        ' panelOCR
        ' 
        Me.panelOCR.BackColor = System.Drawing.Color.Transparent
        Me.panelOCR.Controls.Add(Me.picboxOCR)
        Me.panelOCR.Controls.Add(Me.label2)
        Me.panelOCR.Controls.Add(Me.cbxSupportedLanguage)
        Me.panelOCR.Controls.Add(Me.cbxOCRResultFormat)
        Me.panelOCR.Controls.Add(Me.label5)
        Me.panelOCR.Location = New System.Drawing.Point(1, 41)
        Me.panelOCR.Margin = New System.Windows.Forms.Padding(0)
        Me.panelOCR.Name = "panelOCR"
        Me.panelOCR.Size = New System.Drawing.Size(248, 182)
        Me.panelOCR.TabIndex = 1
        Me.panelOCR.Visible = False
        ' 
        ' picboxOCR
        ' 
        Me.picboxOCR.Image = Global.DotNet_TWAIN_Demo.My.Resources.picboxOCR_Disabled
        Me.picboxOCR.Location = New System.Drawing.Point(40, 132)
        Me.picboxOCR.Name = "picboxOCR"
        Me.picboxOCR.Size = New System.Drawing.Size(180, 38)
        Me.picboxOCR.TabIndex = 5
        Me.picboxOCR.TabStop = False
        AddHandler Me.picboxOCR.MouseLeave, New System.EventHandler(AddressOf Me.picbox_MouseLeave)
        AddHandler Me.picboxOCR.Click, New System.EventHandler(AddressOf Me.picboxOCR_Click)
        AddHandler Me.picboxOCR.MouseDown, New System.Windows.Forms.MouseEventHandler(AddressOf Me.picbox_MouseDown)
        AddHandler Me.picboxOCR.MouseUp, New System.Windows.Forms.MouseEventHandler(AddressOf Me.picbox_MouseUp)
        AddHandler Me.picboxOCR.MouseEnter, New System.EventHandler(AddressOf Me.picbox_MouseEnter)
        ' 
        ' label2
        ' 
        Me.label2.AutoSize = True
        Me.label2.BackColor = System.Drawing.Color.Transparent
        Me.label2.Font = New System.Drawing.Font("Segoe UI", 9.0F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CByte(0))
        Me.label2.Location = New System.Drawing.Point(21, 7)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(123, 15)
        Me.label2.TabIndex = 1
        Me.label2.Text = "Supported Language :"
        ' 
        ' cbxSupportedLanguage
        ' 
        Me.cbxSupportedLanguage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxSupportedLanguage.FormattingEnabled = True
        Me.cbxSupportedLanguage.Location = New System.Drawing.Point(24, 32)
        Me.cbxSupportedLanguage.Name = "cbxSupportedLanguage"
        Me.cbxSupportedLanguage.Size = New System.Drawing.Size(204, 21)
        Me.cbxSupportedLanguage.TabIndex = 2
        ' 
        ' cbxOCRResultFormat
        ' 
        Me.cbxOCRResultFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxOCRResultFormat.FormattingEnabled = True
        Me.cbxOCRResultFormat.Location = New System.Drawing.Point(24, 91)
        Me.cbxOCRResultFormat.Name = "cbxOCRResultFormat"
        Me.cbxOCRResultFormat.Size = New System.Drawing.Size(203, 21)
        Me.cbxOCRResultFormat.TabIndex = 4
        ' 
        ' label5
        ' 
        Me.label5.AutoSize = True
        Me.label5.BackColor = System.Drawing.Color.Transparent
        Me.label5.Font = New System.Drawing.Font("Segoe UI", 9.0F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CByte(0))
        Me.label5.Location = New System.Drawing.Point(22, 66)
        Me.label5.Name = "label5"
        Me.label5.Size = New System.Drawing.Size(134, 15)
        Me.label5.TabIndex = 3
        Me.label5.Text = "OCR Result File Format :"
        ' 
        ' panelSaveImage
        ' 
        Me.panelSaveImage.BackColor = System.Drawing.Color.Transparent
        Me.panelSaveImage.Controls.Add(Me.lbFileName)
        Me.panelSaveImage.Controls.Add(Me.rdbtnPDF)
        Me.panelSaveImage.Controls.Add(Me.tbxSaveFileName)
        Me.panelSaveImage.Controls.Add(Me.rdbtnJPG)
        Me.panelSaveImage.Controls.Add(Me.rdbtnTIFF)
        Me.panelSaveImage.Controls.Add(Me.picboxSave)
        Me.panelSaveImage.Controls.Add(Me.rdbtnPNG)
        Me.panelSaveImage.Controls.Add(Me.lbSaveImageType)
        Me.panelSaveImage.Controls.Add(Me.chkMultiPage)
        Me.panelSaveImage.Controls.Add(Me.rdbtnBMP)
        Me.panelSaveImage.Location = New System.Drawing.Point(1, 41)
        Me.panelSaveImage.Margin = New System.Windows.Forms.Padding(0)
        Me.panelSaveImage.Name = "panelSaveImage"
        Me.panelSaveImage.Size = New System.Drawing.Size(248, 210)
        Me.panelSaveImage.TabIndex = 74
        Me.panelSaveImage.Visible = False
        ' 
        ' lbFileName
        ' 
        Me.lbFileName.AutoSize = True
        Me.lbFileName.BackColor = System.Drawing.Color.Transparent
        Me.lbFileName.Font = New System.Drawing.Font("Segoe UI", 9.0F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CByte(0))
        Me.lbFileName.Location = New System.Drawing.Point(16, 16)
        Me.lbFileName.Name = "lbFileName"
        Me.lbFileName.Size = New System.Drawing.Size(60, 15)
        Me.lbFileName.TabIndex = 62
        Me.lbFileName.Text = "File Name"
        ' 
        ' rdbtnPDF
        ' 
        Me.rdbtnPDF.AutoSize = True
        Me.rdbtnPDF.BackColor = System.Drawing.Color.Transparent
        Me.rdbtnPDF.Font = New System.Drawing.Font("Segoe UI", 9.0F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CByte(0))
        Me.rdbtnPDF.Location = New System.Drawing.Point(108, 92)
        Me.rdbtnPDF.Name = "rdbtnPDF"
        Me.rdbtnPDF.Size = New System.Drawing.Size(46, 19)
        Me.rdbtnPDF.TabIndex = 67
        Me.rdbtnPDF.Text = "PDF"
        Me.rdbtnPDF.UseVisualStyleBackColor = False
        AddHandler Me.rdbtnPDF.CheckedChanged, New System.EventHandler(AddressOf Me.rdbtnMultiPage_CheckedChanged)
        ' 
        ' tbxSaveFileName
        ' 
        Me.tbxSaveFileName.Location = New System.Drawing.Point(85, 14)
        Me.tbxSaveFileName.Name = "tbxSaveFileName"
        Me.tbxSaveFileName.Size = New System.Drawing.Size(149, 20)
        Me.tbxSaveFileName.TabIndex = 0
        Me.tbxSaveFileName.Text = "DotNet TWAIN Demo"
        ' 
        ' rdbtnJPG
        ' 
        Me.rdbtnJPG.AutoSize = True
        Me.rdbtnJPG.BackColor = System.Drawing.Color.Transparent
        Me.rdbtnJPG.Font = New System.Drawing.Font("Segoe UI", 9.0F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CByte(0))
        Me.rdbtnJPG.Location = New System.Drawing.Point(22, 67)
        Me.rdbtnJPG.Name = "rdbtnJPG"
        Me.rdbtnJPG.Size = New System.Drawing.Size(44, 19)
        Me.rdbtnJPG.TabIndex = 65
        Me.rdbtnJPG.Text = "JPG"
        Me.rdbtnJPG.UseVisualStyleBackColor = False
        AddHandler Me.rdbtnJPG.CheckedChanged, New System.EventHandler(AddressOf Me.rdbtnSinglePage_CheckedChanged)
        ' 
        ' rdbtnTIFF
        ' 
        Me.rdbtnTIFF.AutoSize = True
        Me.rdbtnTIFF.BackColor = System.Drawing.Color.Transparent
        Me.rdbtnTIFF.Font = New System.Drawing.Font("Segoe UI", 9.0F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CByte(0))
        Me.rdbtnTIFF.Location = New System.Drawing.Point(22, 92)
        Me.rdbtnTIFF.Name = "rdbtnTIFF"
        Me.rdbtnTIFF.Size = New System.Drawing.Size(47, 19)
        Me.rdbtnTIFF.TabIndex = 68
        Me.rdbtnTIFF.Text = "TIFF"
        Me.rdbtnTIFF.UseVisualStyleBackColor = False
        AddHandler Me.rdbtnTIFF.CheckedChanged, New System.EventHandler(AddressOf Me.rdbtnMultiPage_CheckedChanged)
        ' 
        ' picboxSave
        ' 
        Me.picboxSave.Image = Global.DotNet_TWAIN_Demo.My.Resources.picboxSave_Disabled
        Me.picboxSave.Location = New System.Drawing.Point(38, 152)
        Me.picboxSave.Name = "picboxSave"
        Me.picboxSave.Size = New System.Drawing.Size(180, 38)
        Me.picboxSave.TabIndex = 60
        Me.picboxSave.TabStop = False
        Me.picboxSave.Tag = "Save Image"
        AddHandler Me.picboxSave.MouseLeave, New System.EventHandler(AddressOf Me.picbox_MouseLeave)
        AddHandler Me.picboxSave.Click, New System.EventHandler(AddressOf Me.picboxSave_Click)
        AddHandler Me.picboxSave.MouseDown, New System.Windows.Forms.MouseEventHandler(AddressOf Me.picbox_MouseDown)
        AddHandler Me.picboxSave.MouseUp, New System.Windows.Forms.MouseEventHandler(AddressOf Me.picbox_MouseUp)
        AddHandler Me.picboxSave.MouseEnter, New System.EventHandler(AddressOf Me.picbox_MouseEnter)
        ' 
        ' rdbtnPNG
        ' 
        Me.rdbtnPNG.AutoSize = True
        Me.rdbtnPNG.BackColor = System.Drawing.Color.Transparent
        Me.rdbtnPNG.Font = New System.Drawing.Font("Segoe UI", 9.0F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CByte(0))
        Me.rdbtnPNG.Location = New System.Drawing.Point(180, 67)
        Me.rdbtnPNG.Name = "rdbtnPNG"
        Me.rdbtnPNG.Size = New System.Drawing.Size(49, 19)
        Me.rdbtnPNG.TabIndex = 69
        Me.rdbtnPNG.Text = "PNG"
        Me.rdbtnPNG.UseVisualStyleBackColor = False
        AddHandler Me.rdbtnPNG.CheckedChanged, New System.EventHandler(AddressOf Me.rdbtnSinglePage_CheckedChanged)
        ' 
        ' lbSaveImageType
        ' 
        Me.lbSaveImageType.AutoSize = True
        Me.lbSaveImageType.BackColor = System.Drawing.Color.Transparent
        Me.lbSaveImageType.Location = New System.Drawing.Point(16, 46)
        Me.lbSaveImageType.Name = "lbSaveImageType"
        Me.lbSaveImageType.Size = New System.Drawing.Size(59, 13)
        Me.lbSaveImageType.TabIndex = 72
        Me.lbSaveImageType.Text = "Save Type"
        ' 
        ' chkMultiPage
        ' 
        Me.chkMultiPage.AutoSize = True
        Me.chkMultiPage.BackColor = System.Drawing.Color.Transparent
        Me.chkMultiPage.Font = New System.Drawing.Font("Segoe UI", 9.0F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CByte(0))
        Me.chkMultiPage.Location = New System.Drawing.Point(21, 117)
        Me.chkMultiPage.Name = "chkMultiPage"
        Me.chkMultiPage.Size = New System.Drawing.Size(85, 19)
        Me.chkMultiPage.TabIndex = 71
        Me.chkMultiPage.Text = "Multi-Page"
        Me.chkMultiPage.UseVisualStyleBackColor = False
        ' 
        ' rdbtnBMP
        ' 
        Me.rdbtnBMP.AutoSize = True
        Me.rdbtnBMP.BackColor = System.Drawing.Color.Transparent
        Me.rdbtnBMP.Font = New System.Drawing.Font("Segoe UI", 9.0F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CByte(0))
        Me.rdbtnBMP.Location = New System.Drawing.Point(108, 67)
        Me.rdbtnBMP.Name = "rdbtnBMP"
        Me.rdbtnBMP.Size = New System.Drawing.Size(50, 19)
        Me.rdbtnBMP.TabIndex = 70
        Me.rdbtnBMP.Text = "BMP"
        Me.rdbtnBMP.UseVisualStyleBackColor = False
        AddHandler Me.rdbtnBMP.CheckedChanged, New System.EventHandler(AddressOf Me.rdbtnSinglePage_CheckedChanged)
        ' 
        ' label22
        ' 
        Me.label22.AutoSize = True
        Me.label22.BackColor = System.Drawing.Color.White
        Me.label22.Location = New System.Drawing.Point(9, 241)
        Me.label22.Name = "label22"
        Me.label22.Size = New System.Drawing.Size(71, 15)
        Me.label22.TabIndex = 85
        Me.label22.Text = "Cut && Crop "
        ' 
        ' label23
        ' 
        Me.label23.AutoSize = True
        Me.label23.BackColor = System.Drawing.Color.White
        Me.label23.Location = New System.Drawing.Point(9, 424)
        Me.label23.Name = "label23"
        Me.label23.Size = New System.Drawing.Size(63, 15)
        Me.label23.TabIndex = 86
        Me.label23.Text = "Fit && Scale"
        ' 
        ' picboxFit
        ' 
        Me.picboxFit.Image = Global.DotNet_TWAIN_Demo.My.Resources.picboxFit_Leave
        Me.picboxFit.Location = New System.Drawing.Point(11, 448)
        Me.picboxFit.Name = "picboxFit"
        Me.picboxFit.Size = New System.Drawing.Size(61, 36)
        Me.picboxFit.TabIndex = 88
        Me.picboxFit.TabStop = False
        Me.picboxFit.Tag = "Fit Window Size"
        AddHandler Me.picboxFit.MouseLeave, New System.EventHandler(AddressOf Me.picbox_MouseLeave)
        AddHandler Me.picboxFit.Click, New System.EventHandler(AddressOf Me.picboxFit_Click)
        AddHandler Me.picboxFit.MouseDown, New System.Windows.Forms.MouseEventHandler(AddressOf Me.picbox_MouseDown)
        AddHandler Me.picboxFit.MouseHover, New System.EventHandler(AddressOf Me.picbox_MouseHover)
        AddHandler Me.picboxFit.MouseUp, New System.Windows.Forms.MouseEventHandler(AddressOf Me.picbox_MouseUp)
        AddHandler Me.picboxFit.MouseEnter, New System.EventHandler(AddressOf Me.picbox_MouseEnter)
        ' 
        ' picboxOriginalSize
        ' 
        Me.picboxOriginalSize.Image = Global.DotNet_TWAIN_Demo.My.Resources.picboxOriginalSize_Leave
        Me.picboxOriginalSize.Location = New System.Drawing.Point(70, 448)
        Me.picboxOriginalSize.Name = "picboxOriginalSize"
        Me.picboxOriginalSize.Size = New System.Drawing.Size(61, 36)
        Me.picboxOriginalSize.TabIndex = 87
        Me.picboxOriginalSize.TabStop = False
        Me.picboxOriginalSize.Tag = "Original Size"
        AddHandler Me.picboxOriginalSize.MouseLeave, New System.EventHandler(AddressOf Me.picbox_MouseLeave)
        AddHandler Me.picboxOriginalSize.Click, New System.EventHandler(AddressOf Me.picboxOriginalSize_Click)
        AddHandler Me.picboxOriginalSize.MouseDown, New System.Windows.Forms.MouseEventHandler(AddressOf Me.picbox_MouseDown)
        AddHandler Me.picboxOriginalSize.MouseHover, New System.EventHandler(AddressOf Me.picbox_MouseHover)
        AddHandler Me.picboxOriginalSize.MouseUp, New System.Windows.Forms.MouseEventHandler(AddressOf Me.picbox_MouseUp)
        AddHandler Me.picboxOriginalSize.MouseEnter, New System.EventHandler(AddressOf Me.picbox_MouseEnter)
        ' 
        ' label25
        ' 
        Me.label25.Location = New System.Drawing.Point(2, 677)
        Me.label25.Name = "label25"
        Me.label25.Size = New System.Drawing.Size(894, 18)
        Me.label25.TabIndex = 89
        Me.label25.Text = "Note: PDF library is used when loading PDF files.          @2017 Dynams" & "oft Corporation. All rights reserved."
        Me.label25.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        ' 
        ' lbCloseAnnotations
        ' 
        Me.lbCloseAnnotations.AutoSize = True
        Me.lbCloseAnnotations.BackColor = System.Drawing.Color.Snow
        Me.lbCloseAnnotations.Font = New System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CByte(0))
        Me.lbCloseAnnotations.ForeColor = System.Drawing.Color.Black
        Me.lbCloseAnnotations.Location = New System.Drawing.Point(161, 3)
        Me.lbCloseAnnotations.Margin = New System.Windows.Forms.Padding(0)
        Me.lbCloseAnnotations.Name = "lbCloseAnnotations"
        Me.lbCloseAnnotations.Size = New System.Drawing.Size(40, 13)
        Me.lbCloseAnnotations.TabIndex = 89
        Me.lbCloseAnnotations.Text = "CLOSE"
        AddHandler Me.lbCloseAnnotations.MouseLeave, New System.EventHandler(AddressOf Me.lbCloseAnnotations_MouseLeave)
        AddHandler Me.lbCloseAnnotations.Click, New System.EventHandler(AddressOf Me.lbCloseAnnotations_Click)
        AddHandler Me.lbCloseAnnotations.MouseHover, New System.EventHandler(AddressOf Me.lbCloseAnnotations_MouseHover)
        ' 
        ' panelAnnotations
        ' 
        Me.panelAnnotations.BackColor = System.Drawing.Color.Black
        Me.panelAnnotations.Controls.Add(Me.lbCloseAnnotations)
        Me.panelAnnotations.Controls.Add(Me.picboxTitle)
        Me.panelAnnotations.Controls.Add(Me.picboxDeleteAnnotationA)
        Me.panelAnnotations.Controls.Add(Me.picboxEllipseA)
        Me.panelAnnotations.Controls.Add(Me.picboxRectangleA)
        Me.panelAnnotations.Controls.Add(Me.picboxTextA)
        Me.panelAnnotations.Controls.Add(Me.picboxLineA)
        Me.panelAnnotations.Location = New System.Drawing.Point(160, 60)
        Me.panelAnnotations.Name = "panelAnnotations"
        Me.panelAnnotations.Size = New System.Drawing.Size(206, 45)
        Me.panelAnnotations.TabIndex = 81
        ' 
        ' picboxTitle
        ' 
        Me.picboxTitle.BackgroundImage = Global.DotNet_TWAIN_Demo.My.Resources.picboxAnnotationBar
        Me.picboxTitle.Location = New System.Drawing.Point(0, 0)
        Me.picboxTitle.Name = "picboxTitle"
        Me.picboxTitle.Size = New System.Drawing.Size(206, 18)
        Me.picboxTitle.TabIndex = 4
        Me.picboxTitle.TabStop = False
        AddHandler Me.picboxTitle.MouseMove, New System.Windows.Forms.MouseEventHandler(AddressOf Me.picboxTitle_MouseMove)
        AddHandler Me.picboxTitle.MouseDown, New System.Windows.Forms.MouseEventHandler(AddressOf Me.picboxTitle_MouseDown)
        ' 
        ' picboxDeleteAnnotationA
        ' 
        Me.picboxDeleteAnnotationA.Image = Global.DotNet_TWAIN_Demo.My.Resources.picboxDeleteAnnotationA_Leave
        Me.picboxDeleteAnnotationA.Location = New System.Drawing.Point(164, 18)
        Me.picboxDeleteAnnotationA.Name = "picboxDeleteAnnotationA"
        Me.picboxDeleteAnnotationA.Size = New System.Drawing.Size(43, 27)
        Me.picboxDeleteAnnotationA.TabIndex = 5
        Me.picboxDeleteAnnotationA.TabStop = False
        Me.picboxDeleteAnnotationA.Tag = "Delete Annotation"
        AddHandler Me.picboxDeleteAnnotationA.MouseLeave, New System.EventHandler(AddressOf Me.picbox_MouseLeave)
        AddHandler Me.picboxDeleteAnnotationA.Click, New System.EventHandler(AddressOf Me.picboxDeleteAnnotationA_Click)
        AddHandler Me.picboxDeleteAnnotationA.MouseDown, New System.Windows.Forms.MouseEventHandler(AddressOf Me.picbox_MouseDown)
        AddHandler Me.picboxDeleteAnnotationA.MouseHover, New System.EventHandler(AddressOf Me.picbox_MouseHover)
        AddHandler Me.picboxDeleteAnnotationA.MouseUp, New System.Windows.Forms.MouseEventHandler(AddressOf Me.picbox_MouseUp)
        AddHandler Me.picboxDeleteAnnotationA.MouseEnter, New System.EventHandler(AddressOf Me.picbox_MouseEnter)
        ' 
        ' picboxEllipseA
        ' 
        Me.picboxEllipseA.Image = Global.DotNet_TWAIN_Demo.My.Resources.picboxEllipseA_Leave
        Me.picboxEllipseA.Location = New System.Drawing.Point(41, 18)
        Me.picboxEllipseA.Name = "picboxEllipseA"
        Me.picboxEllipseA.Size = New System.Drawing.Size(42, 27)
        Me.picboxEllipseA.TabIndex = 3
        Me.picboxEllipseA.TabStop = False
        Me.picboxEllipseA.Tag = "Draw Ellipse"
        AddHandler Me.picboxEllipseA.MouseLeave, New System.EventHandler(AddressOf Me.picbox_MouseLeave)
        AddHandler Me.picboxEllipseA.Click, New System.EventHandler(AddressOf Me.picboxEllipse_Click)
        AddHandler Me.picboxEllipseA.MouseDown, New System.Windows.Forms.MouseEventHandler(AddressOf Me.picbox_MouseDown)
        AddHandler Me.picboxEllipseA.MouseHover, New System.EventHandler(AddressOf Me.picbox_MouseHover)
        AddHandler Me.picboxEllipseA.MouseUp, New System.Windows.Forms.MouseEventHandler(AddressOf Me.picbox_MouseUp)
        AddHandler Me.picboxEllipseA.MouseEnter, New System.EventHandler(AddressOf Me.picbox_MouseEnter)
        ' 
        ' picboxRectangleA
        ' 
        Me.picboxRectangleA.Image = Global.DotNet_TWAIN_Demo.My.Resources.picboxRectangleA_Leave
        Me.picboxRectangleA.Location = New System.Drawing.Point(82, 18)
        Me.picboxRectangleA.Name = "picboxRectangleA"
        Me.picboxRectangleA.Size = New System.Drawing.Size(42, 27)
        Me.picboxRectangleA.TabIndex = 2
        Me.picboxRectangleA.TabStop = False
        Me.picboxRectangleA.Tag = "Draw Rectangle"
        AddHandler Me.picboxRectangleA.MouseLeave, New System.EventHandler(AddressOf Me.picbox_MouseLeave)
        AddHandler Me.picboxRectangleA.Click, New System.EventHandler(AddressOf Me.picboxRectangle_Click)
        AddHandler Me.picboxRectangleA.MouseDown, New System.Windows.Forms.MouseEventHandler(AddressOf Me.picbox_MouseDown)
        AddHandler Me.picboxRectangleA.MouseHover, New System.EventHandler(AddressOf Me.picbox_MouseHover)
        AddHandler Me.picboxRectangleA.MouseUp, New System.Windows.Forms.MouseEventHandler(AddressOf Me.picbox_MouseUp)
        AddHandler Me.picboxRectangleA.MouseEnter, New System.EventHandler(AddressOf Me.picbox_MouseEnter)
        ' 
        ' picboxTextA
        ' 
        Me.picboxTextA.Image = Global.DotNet_TWAIN_Demo.My.Resources.picboxTextA_Leave
        Me.picboxTextA.Location = New System.Drawing.Point(123, 18)
        Me.picboxTextA.Name = "picboxTextA"
        Me.picboxTextA.Size = New System.Drawing.Size(42, 27)
        Me.picboxTextA.TabIndex = 1
        Me.picboxTextA.TabStop = False
        Me.picboxTextA.Tag = "Draw Text"
        AddHandler Me.picboxTextA.MouseLeave, New System.EventHandler(AddressOf Me.picbox_MouseLeave)
        AddHandler Me.picboxTextA.Click, New System.EventHandler(AddressOf Me.picboxText_Click)
        AddHandler Me.picboxTextA.MouseDown, New System.Windows.Forms.MouseEventHandler(AddressOf Me.picbox_MouseDown)
        AddHandler Me.picboxTextA.MouseHover, New System.EventHandler(AddressOf Me.picbox_MouseHover)
        AddHandler Me.picboxTextA.MouseUp, New System.Windows.Forms.MouseEventHandler(AddressOf Me.picbox_MouseUp)
        AddHandler Me.picboxTextA.MouseEnter, New System.EventHandler(AddressOf Me.picbox_MouseEnter)
        ' 
        ' picboxLineA
        ' 
        Me.picboxLineA.Image = Global.DotNet_TWAIN_Demo.My.Resources.picboxLineA_Leave
        Me.picboxLineA.Location = New System.Drawing.Point(-1, 18)
        Me.picboxLineA.Name = "picboxLineA"
        Me.picboxLineA.Size = New System.Drawing.Size(43, 27)
        Me.picboxLineA.TabIndex = 0
        Me.picboxLineA.TabStop = False
        Me.picboxLineA.Tag = "Draw Line"
        AddHandler Me.picboxLineA.MouseLeave, New System.EventHandler(AddressOf Me.picbox_MouseLeave)
        AddHandler Me.picboxLineA.Click, New System.EventHandler(AddressOf Me.picboxLine_Click)
        AddHandler Me.picboxLineA.MouseDown, New System.Windows.Forms.MouseEventHandler(AddressOf Me.picbox_MouseDown)
        AddHandler Me.picboxLineA.MouseHover, New System.EventHandler(AddressOf Me.picbox_MouseHover)
        AddHandler Me.picboxLineA.MouseUp, New System.Windows.Forms.MouseEventHandler(AddressOf Me.picbox_MouseUp)
        AddHandler Me.picboxLineA.MouseEnter, New System.EventHandler(AddressOf Me.picbox_MouseEnter)
        ' 
        ' dsViewer
        ' 
        Me.dsViewer.Location = New System.Drawing.Point(144, 50)
        Me.dsViewer.Name = "dsViewer"
        Me.dsViewer.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.dsViewer.SelectionRectAspectRatio = 0
        Me.dsViewer.Size = New System.Drawing.Size(478, 590)
        Me.dsViewer.TabIndex = 80
        Me.dsViewer.Visible = False
        AddHandler Me.dsViewer.OnMouseClick, New Dynamsoft.Forms.Delegate.OnMouseClickHandler(AddressOf Me.dsViewer_OnMouseClick)
        AddHandler Me.dsViewer.OnImageAreaDeselected, New Dynamsoft.Forms.Delegate.OnImageAreaDeselectedHandler(AddressOf Me.dsViewer_OnImageAreaDeselected)
        AddHandler Me.dsViewer.OnMouseDoubleClick, New Dynamsoft.Forms.Delegate.OnMouseDoubleClickHandler(AddressOf Me.dsViewer_OnMouseDoubleClick)
        AddHandler Me.dsViewer.OnImageAreaSelected, New Dynamsoft.Forms.Delegate.OnImageAreaSelectedHandler(AddressOf Me.dsViewer_OnImageAreaSelected)
        AddHandler Me.dsViewer.OnMouseRightClick, New Dynamsoft.Forms.Delegate.OnMouseRightClickHandler(AddressOf Me.dsViewer_OnMouseRightClick)
        ' 
        ' DotNetTWAINDemo
        ' 
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0F, 15.0F)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.BackgroundImage = Global.DotNet_TWAIN_Demo.My.Resources.main_bg
		Me.ClientSize = New System.Drawing.Size(898, 698)
		Me.Controls.Add(Me.picboxFit)
		Me.Controls.Add(Me.picboxOriginalSize)
		Me.Controls.Add(Me.label23)
		Me.Controls.Add(Me.label22)
		Me.Controls.Add(Me.label25)
		Me.Controls.Add(Me.flowLayoutPanel2)
		Me.Controls.Add(Me.panelAnnotations)
		Me.Controls.Add(Me.tbxTotalImageNum)
		Me.Controls.Add(Me.tbxCurrentImageIndex)
		Me.Controls.Add(Me.lbDiv)
		Me.Controls.Add(Me.picboxClose)
		Me.Controls.Add(Me.picboxMin)
		Me.Controls.Add(Me.cbxViewMode)
		Me.Controls.Add(Me.picboxPrevious)
		Me.Controls.Add(Me.picboxNext)
		Me.Controls.Add(Me.picboxLast)
		Me.Controls.Add(Me.picboxFirst)
		Me.Controls.Add(Me.label4)
		Me.Controls.Add(Me.label3)
		Me.Controls.Add(Me.lbAnnotate)
		Me.Controls.Add(Me.lbReshape)
		Me.Controls.Add(Me.lbMoveBar)
		Me.Controls.Add(Me.lbGeneral)
		Me.Controls.Add(Me.picboxDeleteAll)
		Me.Controls.Add(Me.picboxDelete)
		Me.Controls.Add(Me.picboxZoomOut)
		Me.Controls.Add(Me.picboxResample)
		Me.Controls.Add(Me.picboxZoomIn)
		Me.Controls.Add(Me.picboxZoom)
		Me.Controls.Add(Me.picboxText)
		Me.Controls.Add(Me.picboxEllipse)
		Me.Controls.Add(Me.picboxRectangle)
		Me.Controls.Add(Me.picboxLine)
		Me.Controls.Add(Me.picboxFlip)
		Me.Controls.Add(Me.picboxRotateLeft)
		Me.Controls.Add(Me.picboxMirror)
		Me.Controls.Add(Me.picboxRotateRight)
		Me.Controls.Add(Me.picboxCut)
		Me.Controls.Add(Me.picboxPoint)
		Me.Controls.Add(Me.picboxCrop)
		Me.Controls.Add(Me.picboxHand)
		Me.Controls.Add(Me.dsViewer)
		Me.DoubleBuffered = True
		Me.Font = New System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CByte(0))
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
		Me.Icon = DirectCast(resources.GetObject("$this.Icon"), System.Drawing.Icon)
		Me.Margin = New System.Windows.Forms.Padding(4)
		Me.Name = "DotNetTWAINDemo"
		Me.Text = "Dynamsoft .Net TWAIN Demo"
		AddHandler Me.Load, New System.EventHandler(AddressOf Me.DotNetTWAINDemo_Load)
		DirectCast(Me.picboxHand, System.ComponentModel.ISupportInitialize).EndInit()
		DirectCast(Me.picboxCrop, System.ComponentModel.ISupportInitialize).EndInit()
		DirectCast(Me.picboxPoint, System.ComponentModel.ISupportInitialize).EndInit()
		DirectCast(Me.picboxCut, System.ComponentModel.ISupportInitialize).EndInit()
		DirectCast(Me.picboxFlip, System.ComponentModel.ISupportInitialize).EndInit()
		DirectCast(Me.picboxRotateLeft, System.ComponentModel.ISupportInitialize).EndInit()
		DirectCast(Me.picboxMirror, System.ComponentModel.ISupportInitialize).EndInit()
		DirectCast(Me.picboxRotateRight, System.ComponentModel.ISupportInitialize).EndInit()
		DirectCast(Me.picboxText, System.ComponentModel.ISupportInitialize).EndInit()
		DirectCast(Me.picboxEllipse, System.ComponentModel.ISupportInitialize).EndInit()
		DirectCast(Me.picboxRectangle, System.ComponentModel.ISupportInitialize).EndInit()
		DirectCast(Me.picboxLine, System.ComponentModel.ISupportInitialize).EndInit()
		DirectCast(Me.picboxZoomOut, System.ComponentModel.ISupportInitialize).EndInit()
		DirectCast(Me.picboxResample, System.ComponentModel.ISupportInitialize).EndInit()
		DirectCast(Me.picboxZoomIn, System.ComponentModel.ISupportInitialize).EndInit()
		DirectCast(Me.picboxZoom, System.ComponentModel.ISupportInitialize).EndInit()
		DirectCast(Me.picboxDeleteAll, System.ComponentModel.ISupportInitialize).EndInit()
		DirectCast(Me.picboxDelete, System.ComponentModel.ISupportInitialize).EndInit()
		DirectCast(Me.picboxFirst, System.ComponentModel.ISupportInitialize).EndInit()
		DirectCast(Me.picboxLast, System.ComponentModel.ISupportInitialize).EndInit()
		DirectCast(Me.picboxNext, System.ComponentModel.ISupportInitialize).EndInit()
		DirectCast(Me.picboxPrevious, System.ComponentModel.ISupportInitialize).EndInit()
		DirectCast(Me.picboxMin, System.ComponentModel.ISupportInitialize).EndInit()
		DirectCast(Me.picboxClose, System.ComponentModel.ISupportInitialize).EndInit()
		Me.panelLoad.ResumeLayout(False)
		Me.panelLoad.PerformLayout()
		Me.panel1.ResumeLayout(False)
		DirectCast(Me.picboxLoadImage, System.ComponentModel.ISupportInitialize).EndInit()
		Me.panelAcquire.ResumeLayout(False)
		Me.panelAcquire.PerformLayout()
		Me.panelGrab.ResumeLayout(False)
		Me.panelGrab.PerformLayout()
		DirectCast(Me.picboxGrab, System.ComponentModel.ISupportInitialize).EndInit()
		Me.panelScan.ResumeLayout(False)
		Me.panelScan.PerformLayout()
		DirectCast(Me.picboxScan, System.ComponentModel.ISupportInitialize).EndInit()
		Me.panelAddBarcode.ResumeLayout(False)
		Me.panelAddBarcode.PerformLayout()
		DirectCast(Me.picboxAddBarcode, System.ComponentModel.ISupportInitialize).EndInit()
		Me.panelReadBarcode.ResumeLayout(False)
		Me.panelReadBarcode.PerformLayout()
		DirectCast(Me.picboxReadBarcode, System.ComponentModel.ISupportInitialize).EndInit()
		Me.panelOCR.ResumeLayout(False)
		Me.panelOCR.PerformLayout()
		DirectCast(Me.picboxOCR, System.ComponentModel.ISupportInitialize).EndInit()
		Me.panelSaveImage.ResumeLayout(False)
		Me.panelSaveImage.PerformLayout()
		DirectCast(Me.picboxSave, System.ComponentModel.ISupportInitialize).EndInit()
		DirectCast(Me.picboxFit, System.ComponentModel.ISupportInitialize).EndInit()
		DirectCast(Me.picboxOriginalSize, System.ComponentModel.ISupportInitialize).EndInit()
		Me.panelAnnotations.ResumeLayout(False)
		Me.panelAnnotations.PerformLayout()
		DirectCast(Me.picboxTitle, System.ComponentModel.ISupportInitialize).EndInit()
		DirectCast(Me.picboxDeleteAnnotationA, System.ComponentModel.ISupportInitialize).EndInit()
		DirectCast(Me.picboxEllipseA, System.ComponentModel.ISupportInitialize).EndInit()
		DirectCast(Me.picboxRectangleA, System.ComponentModel.ISupportInitialize).EndInit()
		DirectCast(Me.picboxTextA, System.ComponentModel.ISupportInitialize).EndInit()
		DirectCast(Me.picboxLineA, System.ComponentModel.ISupportInitialize).EndInit()
		Me.ResumeLayout(False)
		Me.PerformLayout()

	End Sub

	#End Region

	Private lbGeneral As System.Windows.Forms.Label
	Private picboxHand As System.Windows.Forms.PictureBox
	Private picboxCrop As System.Windows.Forms.PictureBox
	Private picboxPoint As System.Windows.Forms.PictureBox
	Private picboxCut As System.Windows.Forms.PictureBox
	Private lbMoveBar As System.Windows.Forms.Label
	Private picboxFlip As System.Windows.Forms.PictureBox
	Private picboxRotateLeft As System.Windows.Forms.PictureBox
	Private picboxMirror As System.Windows.Forms.PictureBox
	Private picboxRotateRight As System.Windows.Forms.PictureBox
	Private lbReshape As System.Windows.Forms.Label
	Private picboxText As System.Windows.Forms.PictureBox
	Private picboxEllipse As System.Windows.Forms.PictureBox
	Private picboxRectangle As System.Windows.Forms.PictureBox
	Private picboxLine As System.Windows.Forms.PictureBox
	Private lbAnnotate As System.Windows.Forms.Label
	Private picboxZoomOut As System.Windows.Forms.PictureBox
	Private picboxResample As System.Windows.Forms.PictureBox
	Private picboxZoomIn As System.Windows.Forms.PictureBox
	Private picboxZoom As System.Windows.Forms.PictureBox
	Private label3 As System.Windows.Forms.Label
	Private picboxDeleteAll As System.Windows.Forms.PictureBox
	Private picboxDelete As System.Windows.Forms.PictureBox
	Private label4 As System.Windows.Forms.Label
	Private picboxFirst As System.Windows.Forms.PictureBox
	Private picboxLast As System.Windows.Forms.PictureBox
	Private picboxNext As System.Windows.Forms.PictureBox
	Private picboxPrevious As System.Windows.Forms.PictureBox
	Private cbxViewMode As System.Windows.Forms.ComboBox
	Private picboxSave As System.Windows.Forms.PictureBox
	Private picboxMin As System.Windows.Forms.PictureBox
	Private picboxClose As System.Windows.Forms.PictureBox
	Private lbDiv As System.Windows.Forms.Label
	Private tbxCurrentImageIndex As System.Windows.Forms.TextBox
	Private tbxTotalImageNum As System.Windows.Forms.TextBox
	Private saveFileDialog As System.Windows.Forms.SaveFileDialog
	Private openFileDialog As System.Windows.Forms.OpenFileDialog
	Private rdbtnJPG As System.Windows.Forms.RadioButton
	Private rdbtnPDF As System.Windows.Forms.RadioButton
	Private rdbtnTIFF As System.Windows.Forms.RadioButton
	Private rdbtnPNG As System.Windows.Forms.RadioButton
	Private rdbtnBMP As System.Windows.Forms.RadioButton
	Private chkMultiPage As System.Windows.Forms.CheckBox
	Private lbSaveImageType As System.Windows.Forms.Label
	Private flowLayoutPanel2 As System.Windows.Forms.FlowLayoutPanel
	Private lbFileName As System.Windows.Forms.Label
	Private tbxSaveFileName As System.Windows.Forms.TextBox
	Private rdbtnGray As System.Windows.Forms.RadioButton
	Private rdbtnBW As System.Windows.Forms.RadioButton
	Private lbPixelType As System.Windows.Forms.Label
	Private rdbtnColor As System.Windows.Forms.RadioButton
	Private cbxSource As System.Windows.Forms.ComboBox
	Private cbxResolution As System.Windows.Forms.ComboBox
	Private picboxScan As System.Windows.Forms.PictureBox
	Private lbSelectSource As System.Windows.Forms.Label
	Private lbResolution As System.Windows.Forms.Label
	Private chkShowUI As System.Windows.Forms.CheckBox
	Private chkDuplex As System.Windows.Forms.CheckBox
	Private chkADF As System.Windows.Forms.CheckBox
	Private panelAcquire As System.Windows.Forms.Panel
	Private panelSaveImage As System.Windows.Forms.Panel
	Private panelLoad As System.Windows.Forms.Panel
	Private label1 As System.Windows.Forms.Label
	Private picboxLoadImage As System.Windows.Forms.PictureBox
	Private label2 As System.Windows.Forms.Label
	Private cbxOCRResultFormat As System.Windows.Forms.ComboBox
	Private label5 As System.Windows.Forms.Label
	Private cbxSupportedLanguage As System.Windows.Forms.ComboBox
	Private picboxOCR As System.Windows.Forms.PictureBox
	Private panelOCR As System.Windows.Forms.Panel
	Private label6 As System.Windows.Forms.Label
	Private label7 As System.Windows.Forms.Label
	Private tbxMaxBarcodeReads As System.Windows.Forms.TextBox
	Private label12 As System.Windows.Forms.Label
	Private label11 As System.Windows.Forms.Label
	Private label10 As System.Windows.Forms.Label
	Private label9 As System.Windows.Forms.Label
	Private label8 As System.Windows.Forms.Label
	Private cbxBarcodeFormat As System.Windows.Forms.ComboBox
	Private tbxBottom As System.Windows.Forms.TextBox
	Private tbxTop As System.Windows.Forms.TextBox
	Private tbxRight As System.Windows.Forms.TextBox
	Private tbxLeft As System.Windows.Forms.TextBox
	Private picboxReadBarcode As System.Windows.Forms.PictureBox
	Private panelReadBarcode As System.Windows.Forms.Panel
	Private panelAddBarcode As System.Windows.Forms.Panel
	Private label15 As System.Windows.Forms.Label
	Private label14 As System.Windows.Forms.Label
	Private label13 As System.Windows.Forms.Label
	Private label19 As System.Windows.Forms.Label
	Private label18 As System.Windows.Forms.Label
	Private label17 As System.Windows.Forms.Label
	Private label16 As System.Windows.Forms.Label
	Private picboxAddBarcode As System.Windows.Forms.PictureBox
	Private tbxBarcodeScale As System.Windows.Forms.TextBox
	Private tbxHumanReadableText As System.Windows.Forms.TextBox
	Private tbxBarcodeLocationY As System.Windows.Forms.TextBox
	Private tbxBarcodeLocationX As System.Windows.Forms.TextBox
	Private tbxBarcodeContent As System.Windows.Forms.TextBox
	Private cbxGenBarcodeFormat As System.Windows.Forms.ComboBox
	Private panelScan As System.Windows.Forms.Panel
	Private panelGrab As System.Windows.Forms.Panel
	Private label20 As System.Windows.Forms.Label
	Private chkShowUIForWebcam As System.Windows.Forms.CheckBox
	'private System.Windows.Forms.ComboBox cbxMediaType;
	Private picboxGrab As System.Windows.Forms.PictureBox
	Private cbxResolutionForWebcam As System.Windows.Forms.ComboBox
	Private label21 As System.Windows.Forms.Label
	Private lbUnknowSource As System.Windows.Forms.Label
	Private label22 As System.Windows.Forms.Label
	Private label23 As System.Windows.Forms.Label
	Private picboxFit As System.Windows.Forms.PictureBox
	Private picboxOriginalSize As System.Windows.Forms.PictureBox
	Private panel1 As System.Windows.Forms.Panel
	Private label24 As System.Windows.Forms.Label
	Private label25 As System.Windows.Forms.Label
	Private lbCloseAnnotations As System.Windows.Forms.Label
	Private panelAnnotations As System.Windows.Forms.Panel
	Private picboxTitle As System.Windows.Forms.PictureBox
	Private picboxDeleteAnnotationA As System.Windows.Forms.PictureBox
	Private picboxEllipseA As System.Windows.Forms.PictureBox
	Private picboxRectangleA As System.Windows.Forms.PictureBox
	Private picboxTextA As System.Windows.Forms.PictureBox
	Private picboxLineA As System.Windows.Forms.PictureBox
	Private dsViewer As Dynamsoft.Forms.DSViewer
End Class

