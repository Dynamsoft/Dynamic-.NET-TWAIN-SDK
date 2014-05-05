<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DotNetTWAINDemo
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(DotNetTWAINDemo))
        Me.rdbtnPNG = New System.Windows.Forms.RadioButton()
        Me.picboxTitle = New System.Windows.Forms.PictureBox()
        Me.picboxDeleteAnnotationA = New System.Windows.Forms.PictureBox()
        Me.rdbtnGray = New System.Windows.Forms.RadioButton()
        Me.rdbtnBW = New System.Windows.Forms.RadioButton()
        Me.lbCloseAnnotations = New System.Windows.Forms.Label()
        Me.lbMoveBar = New System.Windows.Forms.Label()
        Me.picboxEllipseA = New System.Windows.Forms.PictureBox()
        Me.panelAnnotations = New System.Windows.Forms.Panel()
        Me.picboxRectangleA = New System.Windows.Forms.PictureBox()
        Me.picboxTextA = New System.Windows.Forms.PictureBox()
        Me.picboxLineA = New System.Windows.Forms.PictureBox()
        Me.tbxCurrentImageIndex = New System.Windows.Forms.TextBox()
        Me.tbxTotalImageNum = New System.Windows.Forms.TextBox()
        Me.saveFileDialog = New System.Windows.Forms.SaveFileDialog()
        Me.lbPixelType = New System.Windows.Forms.Label()
        Me.lbSaveImageType = New System.Windows.Forms.Label()
        Me.rdbtnJPG = New System.Windows.Forms.RadioButton()
        Me.rdbtnPDF = New System.Windows.Forms.RadioButton()
        Me.lbLoadImageBar = New System.Windows.Forms.Label()
        Me.rdbtnTIFF = New System.Windows.Forms.RadioButton()
        Me.rdbtnColor = New System.Windows.Forms.RadioButton()
        Me.cbxSource = New System.Windows.Forms.ComboBox()
        Me.picboxScan = New System.Windows.Forms.PictureBox()
        Me.lbDiv = New System.Windows.Forms.Label()
        Me.lbTWAINSourceBar = New System.Windows.Forms.Label()
        Me.cbxResolution = New System.Windows.Forms.ComboBox()
        Me.lbSelectSource = New System.Windows.Forms.Label()
        Me.lbResolution = New System.Windows.Forms.Label()
        Me.chkShowUI = New System.Windows.Forms.CheckBox()
        Me.chkDuplex = New System.Windows.Forms.CheckBox()
        Me.openFileDialog = New System.Windows.Forms.OpenFileDialog()
        Me.tbxSaveFileName = New System.Windows.Forms.TextBox()
        Me.picboxClose = New System.Windows.Forms.PictureBox()
        Me.rdbtnBMP = New System.Windows.Forms.RadioButton()
        Me.picboxMin = New System.Windows.Forms.PictureBox()
        Me.lbFileName = New System.Windows.Forms.Label()
        Me.chkMultiPage = New System.Windows.Forms.CheckBox()
        Me.cbxViewMode = New System.Windows.Forms.ComboBox()
        Me.picboxSave = New System.Windows.Forms.PictureBox()
        Me.picboxPrevious = New System.Windows.Forms.PictureBox()
        Me.picboxNext = New System.Windows.Forms.PictureBox()
        Me.picboxLast = New System.Windows.Forms.PictureBox()
        Me.picboxFirst = New System.Windows.Forms.PictureBox()
        Me.label4 = New System.Windows.Forms.Label()
        Me.label3 = New System.Windows.Forms.Label()
        Me.lbAnnotate = New System.Windows.Forms.Label()
        Me.lbReshape = New System.Windows.Forms.Label()
        Me.lbGeneral = New System.Windows.Forms.Label()
        Me.picboxDeleteAll = New System.Windows.Forms.PictureBox()
        Me.picboxDelete = New System.Windows.Forms.PictureBox()
        Me.picboxZoomOut = New System.Windows.Forms.PictureBox()
        Me.chkADF = New System.Windows.Forms.CheckBox()
        Me.picboxResample = New System.Windows.Forms.PictureBox()
        Me.picboxZoomIn = New System.Windows.Forms.PictureBox()
        Me.picboxZoom = New System.Windows.Forms.PictureBox()
        Me.picboxText = New System.Windows.Forms.PictureBox()
        Me.picboxEllipse = New System.Windows.Forms.PictureBox()
        Me.picboxRectangle = New System.Windows.Forms.PictureBox()
        Me.picboxLine = New System.Windows.Forms.PictureBox()
        Me.picboxFlip = New System.Windows.Forms.PictureBox()
        Me.picboxRotateLeft = New System.Windows.Forms.PictureBox()
        Me.picboxMirror = New System.Windows.Forms.PictureBox()
        Me.picboxRotateRight = New System.Windows.Forms.PictureBox()
        Me.picboxRotate = New System.Windows.Forms.PictureBox()
        Me.picboxPoint = New System.Windows.Forms.PictureBox()
        Me.picboxCrop = New System.Windows.Forms.PictureBox()
        Me.picboxHand = New System.Windows.Forms.PictureBox()
        Me.panelSource = New System.Windows.Forms.Panel()
        Me.dynamicDotNetTwain = New Dynamsoft.DotNet.TWAIN.DynamicDotNetTwain()
        CType(Me.picboxTitle, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picboxDeleteAnnotationA, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picboxEllipseA, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.panelAnnotations.SuspendLayout()
        CType(Me.picboxRectangleA, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picboxTextA, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picboxLineA, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picboxScan, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picboxClose, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picboxMin, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picboxSave, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picboxPrevious, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picboxNext, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picboxLast, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picboxFirst, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picboxDeleteAll, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picboxDelete, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picboxZoomOut, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picboxResample, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picboxZoomIn, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picboxZoom, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picboxText, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picboxEllipse, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picboxRectangle, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picboxLine, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picboxFlip, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picboxRotateLeft, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picboxMirror, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picboxRotateRight, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picboxRotate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picboxPoint, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picboxCrop, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picboxHand, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.panelSource.SuspendLayout()
        Me.SuspendLayout()
        '
        'rdbtnPNG
        '
        Me.rdbtnPNG.AutoSize = True
        Me.rdbtnPNG.BackColor = System.Drawing.Color.Transparent
        Me.rdbtnPNG.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdbtnPNG.Location = New System.Drawing.Point(818, 457)
        Me.rdbtnPNG.Name = "rdbtnPNG"
        Me.rdbtnPNG.Size = New System.Drawing.Size(51, 19)
        Me.rdbtnPNG.TabIndex = 117
        Me.rdbtnPNG.Text = "PNG"
        Me.rdbtnPNG.UseVisualStyleBackColor = False
        '
        'picboxTitle
        '
        Me.picboxTitle.BackgroundImage = Global.DotNET_TWAIN_Demo.My.Resources.Resources.picboxAnnotationBar
        Me.picboxTitle.Location = New System.Drawing.Point(0, 0)
        Me.picboxTitle.Name = "picboxTitle"
        Me.picboxTitle.Size = New System.Drawing.Size(206, 18)
        Me.picboxTitle.TabIndex = 4
        Me.picboxTitle.TabStop = False
        '
        'picboxDeleteAnnotationA
        '
        Me.picboxDeleteAnnotationA.Image = CType(resources.GetObject("picboxDeleteAnnotationA.Image"), System.Drawing.Image)
        Me.picboxDeleteAnnotationA.Location = New System.Drawing.Point(164, 18)
        Me.picboxDeleteAnnotationA.Name = "picboxDeleteAnnotationA"
        Me.picboxDeleteAnnotationA.Size = New System.Drawing.Size(43, 27)
        Me.picboxDeleteAnnotationA.TabIndex = 5
        Me.picboxDeleteAnnotationA.TabStop = False
        Me.picboxDeleteAnnotationA.Tag = "Delete Annotation"
        '
        'rdbtnGray
        '
        Me.rdbtnGray.AutoSize = True
        Me.rdbtnGray.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdbtnGray.Location = New System.Drawing.Point(101, 161)
        Me.rdbtnGray.Name = "rdbtnGray"
        Me.rdbtnGray.Size = New System.Drawing.Size(50, 19)
        Me.rdbtnGray.TabIndex = 88
        Me.rdbtnGray.TabStop = True
        Me.rdbtnGray.Text = "Gray"
        Me.rdbtnGray.UseVisualStyleBackColor = True
        '
        'rdbtnBW
        '
        Me.rdbtnBW.AutoSize = True
        Me.rdbtnBW.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdbtnBW.Location = New System.Drawing.Point(20, 161)
        Me.rdbtnBW.Name = "rdbtnBW"
        Me.rdbtnBW.Size = New System.Drawing.Size(58, 19)
        Me.rdbtnBW.TabIndex = 88
        Me.rdbtnBW.TabStop = True
        Me.rdbtnBW.Text = "B && W"
        Me.rdbtnBW.UseVisualStyleBackColor = True
        '
        'lbCloseAnnotations
        '
        Me.lbCloseAnnotations.AutoSize = True
        Me.lbCloseAnnotations.BackColor = System.Drawing.Color.Snow
        Me.lbCloseAnnotations.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbCloseAnnotations.ForeColor = System.Drawing.Color.Black
        Me.lbCloseAnnotations.Location = New System.Drawing.Point(161, 3)
        Me.lbCloseAnnotations.Margin = New System.Windows.Forms.Padding(0)
        Me.lbCloseAnnotations.Name = "lbCloseAnnotations"
        Me.lbCloseAnnotations.Size = New System.Drawing.Size(42, 13)
        Me.lbCloseAnnotations.TabIndex = 89
        Me.lbCloseAnnotations.Text = "CLOSE"
        '
        'lbMoveBar
        '
        Me.lbMoveBar.BackColor = System.Drawing.Color.Transparent
        Me.lbMoveBar.Location = New System.Drawing.Point(0, 1)
        Me.lbMoveBar.Name = "lbMoveBar"
        Me.lbMoveBar.Size = New System.Drawing.Size(897, 32)
        Me.lbMoveBar.TabIndex = 18
        '
        'picboxEllipseA
        '
        Me.picboxEllipseA.Image = CType(resources.GetObject("picboxEllipseA.Image"), System.Drawing.Image)
        Me.picboxEllipseA.Location = New System.Drawing.Point(41, 18)
        Me.picboxEllipseA.Name = "picboxEllipseA"
        Me.picboxEllipseA.Size = New System.Drawing.Size(42, 27)
        Me.picboxEllipseA.TabIndex = 3
        Me.picboxEllipseA.TabStop = False
        Me.picboxEllipseA.Tag = "Draw Ellipse"
        '
        'panelAnnotations
        '
        Me.panelAnnotations.BackColor = System.Drawing.Color.Black
        Me.panelAnnotations.Controls.Add(Me.lbCloseAnnotations)
        Me.panelAnnotations.Controls.Add(Me.picboxTitle)
        Me.panelAnnotations.Controls.Add(Me.picboxDeleteAnnotationA)
        Me.panelAnnotations.Controls.Add(Me.picboxEllipseA)
        Me.panelAnnotations.Controls.Add(Me.picboxRectangleA)
        Me.panelAnnotations.Controls.Add(Me.picboxTextA)
        Me.panelAnnotations.Controls.Add(Me.picboxLineA)
        Me.panelAnnotations.Location = New System.Drawing.Point(163, 69)
        Me.panelAnnotations.Name = "panelAnnotations"
        Me.panelAnnotations.Size = New System.Drawing.Size(206, 45)
        Me.panelAnnotations.TabIndex = 127
        '
        'picboxRectangleA
        '
        Me.picboxRectangleA.Image = CType(resources.GetObject("picboxRectangleA.Image"), System.Drawing.Image)
        Me.picboxRectangleA.Location = New System.Drawing.Point(82, 18)
        Me.picboxRectangleA.Name = "picboxRectangleA"
        Me.picboxRectangleA.Size = New System.Drawing.Size(42, 27)
        Me.picboxRectangleA.TabIndex = 2
        Me.picboxRectangleA.TabStop = False
        Me.picboxRectangleA.Tag = "Draw Rectangle"
        '
        'picboxTextA
        '
        Me.picboxTextA.Image = CType(resources.GetObject("picboxTextA.Image"), System.Drawing.Image)
        Me.picboxTextA.Location = New System.Drawing.Point(123, 18)
        Me.picboxTextA.Name = "picboxTextA"
        Me.picboxTextA.Size = New System.Drawing.Size(42, 27)
        Me.picboxTextA.TabIndex = 1
        Me.picboxTextA.TabStop = False
        Me.picboxTextA.Tag = "Draw Text"
        '
        'picboxLineA
        '
        Me.picboxLineA.Image = CType(resources.GetObject("picboxLineA.Image"), System.Drawing.Image)
        Me.picboxLineA.Location = New System.Drawing.Point(-1, 18)
        Me.picboxLineA.Name = "picboxLineA"
        Me.picboxLineA.Size = New System.Drawing.Size(43, 27)
        Me.picboxLineA.TabIndex = 0
        Me.picboxLineA.TabStop = False
        Me.picboxLineA.Tag = "Draw Line"
        '
        'tbxCurrentImageIndex
        '
        Me.tbxCurrentImageIndex.Enabled = False
        Me.tbxCurrentImageIndex.Location = New System.Drawing.Point(271, 647)
        Me.tbxCurrentImageIndex.Name = "tbxCurrentImageIndex"
        Me.tbxCurrentImageIndex.ReadOnly = True
        Me.tbxCurrentImageIndex.Size = New System.Drawing.Size(61, 22)
        Me.tbxCurrentImageIndex.TabIndex = 76
        Me.tbxCurrentImageIndex.Text = "0"
        Me.tbxCurrentImageIndex.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'tbxTotalImageNum
        '
        Me.tbxTotalImageNum.Enabled = False
        Me.tbxTotalImageNum.Location = New System.Drawing.Point(355, 647)
        Me.tbxTotalImageNum.Name = "tbxTotalImageNum"
        Me.tbxTotalImageNum.ReadOnly = True
        Me.tbxTotalImageNum.Size = New System.Drawing.Size(61, 22)
        Me.tbxTotalImageNum.TabIndex = 77
        Me.tbxTotalImageNum.Text = "0"
        '
        'lbPixelType
        '
        Me.lbPixelType.AutoSize = True
        Me.lbPixelType.BackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(243, Byte), Integer), CType(CType(243, Byte), Integer))
        Me.lbPixelType.Location = New System.Drawing.Point(17, 136)
        Me.lbPixelType.Name = "lbPixelType"
        Me.lbPixelType.Size = New System.Drawing.Size(72, 16)
        Me.lbPixelType.TabIndex = 87
        Me.lbPixelType.Text = "Pixel Type"
        '
        'lbSaveImageType
        '
        Me.lbSaveImageType.AutoSize = True
        Me.lbSaveImageType.BackColor = System.Drawing.Color.Transparent
        Me.lbSaveImageType.Location = New System.Drawing.Point(654, 436)
        Me.lbSaveImageType.Name = "lbSaveImageType"
        Me.lbSaveImageType.Size = New System.Drawing.Size(75, 16)
        Me.lbSaveImageType.TabIndex = 120
        Me.lbSaveImageType.Text = "Save Type"
        '
        'rdbtnJPG
        '
        Me.rdbtnJPG.AutoSize = True
        Me.rdbtnJPG.BackColor = System.Drawing.Color.Transparent
        Me.rdbtnJPG.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdbtnJPG.Location = New System.Drawing.Point(660, 457)
        Me.rdbtnJPG.Name = "rdbtnJPG"
        Me.rdbtnJPG.Size = New System.Drawing.Size(48, 19)
        Me.rdbtnJPG.TabIndex = 114
        Me.rdbtnJPG.Text = "JPG"
        Me.rdbtnJPG.UseVisualStyleBackColor = False
        '
        'rdbtnPDF
        '
        Me.rdbtnPDF.AutoSize = True
        Me.rdbtnPDF.BackColor = System.Drawing.Color.Transparent
        Me.rdbtnPDF.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdbtnPDF.Location = New System.Drawing.Point(746, 482)
        Me.rdbtnPDF.Name = "rdbtnPDF"
        Me.rdbtnPDF.Size = New System.Drawing.Size(49, 19)
        Me.rdbtnPDF.TabIndex = 115
        Me.rdbtnPDF.Text = "PDF"
        Me.rdbtnPDF.UseVisualStyleBackColor = False
        '
        'lbLoadImageBar
        '
        Me.lbLoadImageBar.BackColor = System.Drawing.Color.Transparent
        Me.lbLoadImageBar.Location = New System.Drawing.Point(126, 2)
        Me.lbLoadImageBar.Name = "lbLoadImageBar"
        Me.lbLoadImageBar.Size = New System.Drawing.Size(121, 31)
        Me.lbLoadImageBar.TabIndex = 86
        '
        'rdbtnTIFF
        '
        Me.rdbtnTIFF.AutoSize = True
        Me.rdbtnTIFF.BackColor = System.Drawing.Color.Transparent
        Me.rdbtnTIFF.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdbtnTIFF.Location = New System.Drawing.Point(660, 482)
        Me.rdbtnTIFF.Name = "rdbtnTIFF"
        Me.rdbtnTIFF.Size = New System.Drawing.Size(49, 19)
        Me.rdbtnTIFF.TabIndex = 116
        Me.rdbtnTIFF.Text = "TIFF"
        Me.rdbtnTIFF.UseVisualStyleBackColor = False
        '
        'rdbtnColor
        '
        Me.rdbtnColor.AutoSize = True
        Me.rdbtnColor.BackColor = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.rdbtnColor.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdbtnColor.Location = New System.Drawing.Point(170, 161)
        Me.rdbtnColor.Name = "rdbtnColor"
        Me.rdbtnColor.Size = New System.Drawing.Size(54, 19)
        Me.rdbtnColor.TabIndex = 54
        Me.rdbtnColor.Text = "Color"
        Me.rdbtnColor.UseVisualStyleBackColor = False
        '
        'cbxSource
        '
        Me.cbxSource.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxSource.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbxSource.FormattingEnabled = True
        Me.cbxSource.Location = New System.Drawing.Point(15, 70)
        Me.cbxSource.Name = "cbxSource"
        Me.cbxSource.Size = New System.Drawing.Size(216, 22)
        Me.cbxSource.TabIndex = 84
        '
        'picboxScan
        '
        Me.picboxScan.Enabled = False
        Me.picboxScan.ErrorImage = Nothing
        Me.picboxScan.Image = CType(resources.GetObject("picboxScan.Image"), System.Drawing.Image)
        Me.picboxScan.Location = New System.Drawing.Point(40, 217)
        Me.picboxScan.Name = "picboxScan"
        Me.picboxScan.Size = New System.Drawing.Size(180, 38)
        Me.picboxScan.TabIndex = 85
        Me.picboxScan.TabStop = False
        Me.picboxScan.Tag = "Scan Image"
        '
        'lbDiv
        '
        Me.lbDiv.AutoSize = True
        Me.lbDiv.BackColor = System.Drawing.Color.Transparent
        Me.lbDiv.Location = New System.Drawing.Point(339, 650)
        Me.lbDiv.Name = "lbDiv"
        Me.lbDiv.Size = New System.Drawing.Size(12, 16)
        Me.lbDiv.TabIndex = 75
        Me.lbDiv.Text = "/"
        '
        'lbTWAINSourceBar
        '
        Me.lbTWAINSourceBar.BackColor = System.Drawing.Color.Transparent
        Me.lbTWAINSourceBar.Location = New System.Drawing.Point(3, 2)
        Me.lbTWAINSourceBar.Name = "lbTWAINSourceBar"
        Me.lbTWAINSourceBar.Size = New System.Drawing.Size(121, 31)
        Me.lbTWAINSourceBar.TabIndex = 84
        '
        'cbxResolution
        '
        Me.cbxResolution.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxResolution.Enabled = False
        Me.cbxResolution.FormattingEnabled = True
        Me.cbxResolution.Location = New System.Drawing.Point(88, 187)
        Me.cbxResolution.Name = "cbxResolution"
        Me.cbxResolution.Size = New System.Drawing.Size(98, 24)
        Me.cbxResolution.TabIndex = 84
        '
        'lbSelectSource
        '
        Me.lbSelectSource.AutoSize = True
        Me.lbSelectSource.BackColor = System.Drawing.Color.FromArgb(CType(CType(251, Byte), Integer), CType(CType(251, Byte), Integer), CType(CType(251, Byte), Integer))
        Me.lbSelectSource.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbSelectSource.Location = New System.Drawing.Point(13, 46)
        Me.lbSelectSource.Name = "lbSelectSource"
        Me.lbSelectSource.Size = New System.Drawing.Size(92, 16)
        Me.lbSelectSource.TabIndex = 84
        Me.lbSelectSource.Text = "Select Source"
        '
        'lbResolution
        '
        Me.lbResolution.AutoSize = True
        Me.lbResolution.BackColor = System.Drawing.Color.FromArgb(CType(CType(238, Byte), Integer), CType(CType(238, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.lbResolution.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbResolution.Location = New System.Drawing.Point(20, 190)
        Me.lbResolution.Name = "lbResolution"
        Me.lbResolution.Size = New System.Drawing.Size(66, 15)
        Me.lbResolution.TabIndex = 83
        Me.lbResolution.Text = "Resolution"
        '
        'chkShowUI
        '
        Me.chkShowUI.AutoSize = True
        Me.chkShowUI.BackColor = System.Drawing.Color.FromArgb(CType(CType(246, Byte), Integer), CType(CType(246, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.chkShowUI.Enabled = False
        Me.chkShowUI.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkShowUI.Location = New System.Drawing.Point(20, 105)
        Me.chkShowUI.Name = "chkShowUI"
        Me.chkShowUI.Size = New System.Drawing.Size(72, 19)
        Me.chkShowUI.TabIndex = 83
        Me.chkShowUI.Text = "Show UI"
        Me.chkShowUI.UseVisualStyleBackColor = False
        '
        'chkDuplex
        '
        Me.chkDuplex.AutoSize = True
        Me.chkDuplex.BackColor = System.Drawing.Color.FromArgb(CType(CType(246, Byte), Integer), CType(CType(246, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.chkDuplex.Enabled = False
        Me.chkDuplex.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkDuplex.Location = New System.Drawing.Point(170, 105)
        Me.chkDuplex.Name = "chkDuplex"
        Me.chkDuplex.Size = New System.Drawing.Size(65, 19)
        Me.chkDuplex.TabIndex = 83
        Me.chkDuplex.Text = "Duplex"
        Me.chkDuplex.UseVisualStyleBackColor = False
        '
        'openFileDialog
        '
        Me.openFileDialog.FileName = "openFileDialog1"
        '
        'tbxSaveFileName
        '
        Me.tbxSaveFileName.Location = New System.Drawing.Point(724, 404)
        Me.tbxSaveFileName.Name = "tbxSaveFileName"
        Me.tbxSaveFileName.Size = New System.Drawing.Size(149, 22)
        Me.tbxSaveFileName.TabIndex = 83
        Me.tbxSaveFileName.Text = "DotNet TWAIN Demo"
        '
        'picboxClose
        '
        Me.picboxClose.Image = CType(resources.GetObject("picboxClose.Image"), System.Drawing.Image)
        Me.picboxClose.Location = New System.Drawing.Point(867, 10)
        Me.picboxClose.Name = "picboxClose"
        Me.picboxClose.Size = New System.Drawing.Size(20, 20)
        Me.picboxClose.TabIndex = 122
        Me.picboxClose.TabStop = False
        '
        'rdbtnBMP
        '
        Me.rdbtnBMP.AutoSize = True
        Me.rdbtnBMP.BackColor = System.Drawing.Color.Transparent
        Me.rdbtnBMP.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdbtnBMP.Location = New System.Drawing.Point(746, 457)
        Me.rdbtnBMP.Name = "rdbtnBMP"
        Me.rdbtnBMP.Size = New System.Drawing.Size(52, 19)
        Me.rdbtnBMP.TabIndex = 118
        Me.rdbtnBMP.Text = "BMP"
        Me.rdbtnBMP.UseVisualStyleBackColor = False
        '
        'picboxMin
        '
        Me.picboxMin.Image = CType(resources.GetObject("picboxMin.Image"), System.Drawing.Image)
        Me.picboxMin.Location = New System.Drawing.Point(843, 10)
        Me.picboxMin.Name = "picboxMin"
        Me.picboxMin.Size = New System.Drawing.Size(20, 20)
        Me.picboxMin.TabIndex = 121
        Me.picboxMin.TabStop = False
        '
        'lbFileName
        '
        Me.lbFileName.AutoSize = True
        Me.lbFileName.BackColor = System.Drawing.Color.Transparent
        Me.lbFileName.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbFileName.Location = New System.Drawing.Point(654, 407)
        Me.lbFileName.Name = "lbFileName"
        Me.lbFileName.Size = New System.Drawing.Size(64, 15)
        Me.lbFileName.TabIndex = 113
        Me.lbFileName.Text = "File Name"
        '
        'chkMultiPage
        '
        Me.chkMultiPage.AutoSize = True
        Me.chkMultiPage.BackColor = System.Drawing.Color.Transparent
        Me.chkMultiPage.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkMultiPage.Location = New System.Drawing.Point(659, 507)
        Me.chkMultiPage.Name = "chkMultiPage"
        Me.chkMultiPage.Size = New System.Drawing.Size(86, 19)
        Me.chkMultiPage.TabIndex = 119
        Me.chkMultiPage.Text = "Multi-Page"
        Me.chkMultiPage.UseVisualStyleBackColor = False
        '
        'cbxViewMode
        '
        Me.cbxViewMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxViewMode.FormattingEnabled = True
        Me.cbxViewMode.Location = New System.Drawing.Point(534, 645)
        Me.cbxViewMode.Name = "cbxViewMode"
        Me.cbxViewMode.Size = New System.Drawing.Size(75, 24)
        Me.cbxViewMode.TabIndex = 48
        '
        'picboxSave
        '
        Me.picboxSave.Image = CType(resources.GetObject("picboxSave.Image"), System.Drawing.Image)
        Me.picboxSave.Location = New System.Drawing.Point(675, 533)
        Me.picboxSave.Name = "picboxSave"
        Me.picboxSave.Size = New System.Drawing.Size(180, 32)
        Me.picboxSave.TabIndex = 112
        Me.picboxSave.TabStop = False
        Me.picboxSave.Tag = "Save Image"
        '
        'picboxPrevious
        '
        Me.picboxPrevious.Image = CType(resources.GetObject("picboxPrevious.Image"), System.Drawing.Image)
        Me.picboxPrevious.Location = New System.Drawing.Point(215, 645)
        Me.picboxPrevious.Name = "picboxPrevious"
        Me.picboxPrevious.Size = New System.Drawing.Size(50, 25)
        Me.picboxPrevious.TabIndex = 110
        Me.picboxPrevious.TabStop = False
        Me.picboxPrevious.Tag = "Previous Image"
        '
        'picboxNext
        '
        Me.picboxNext.Image = CType(resources.GetObject("picboxNext.Image"), System.Drawing.Image)
        Me.picboxNext.Location = New System.Drawing.Point(422, 645)
        Me.picboxNext.Name = "picboxNext"
        Me.picboxNext.Size = New System.Drawing.Size(50, 25)
        Me.picboxNext.TabIndex = 109
        Me.picboxNext.TabStop = False
        Me.picboxNext.Tag = "Next Image"
        '
        'picboxLast
        '
        Me.picboxLast.Image = CType(resources.GetObject("picboxLast.Image"), System.Drawing.Image)
        Me.picboxLast.Location = New System.Drawing.Point(478, 645)
        Me.picboxLast.Name = "picboxLast"
        Me.picboxLast.Size = New System.Drawing.Size(50, 25)
        Me.picboxLast.TabIndex = 108
        Me.picboxLast.TabStop = False
        Me.picboxLast.Tag = "Last Image"
        '
        'picboxFirst
        '
        Me.picboxFirst.Image = CType(resources.GetObject("picboxFirst.Image"), System.Drawing.Image)
        Me.picboxFirst.Location = New System.Drawing.Point(159, 645)
        Me.picboxFirst.Name = "picboxFirst"
        Me.picboxFirst.Size = New System.Drawing.Size(50, 25)
        Me.picboxFirst.TabIndex = 107
        Me.picboxFirst.TabStop = False
        Me.picboxFirst.Tag = "First Image"
        '
        'label4
        '
        Me.label4.AutoSize = True
        Me.label4.BackColor = System.Drawing.Color.White
        Me.label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label4.Location = New System.Drawing.Point(10, 525)
        Me.label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.label4.Name = "label4"
        Me.label4.Size = New System.Drawing.Size(109, 15)
        Me.label4.TabIndex = 35
        Me.label4.Text = "Delete && Delete All"
        '
        'label3
        '
        Me.label3.AutoSize = True
        Me.label3.BackColor = System.Drawing.Color.White
        Me.label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label3.Location = New System.Drawing.Point(10, 407)
        Me.label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.label3.Name = "label3"
        Me.label3.Size = New System.Drawing.Size(84, 15)
        Me.label3.TabIndex = 30
        Me.label3.Text = "Zoom && Scale"
        '
        'lbAnnotate
        '
        Me.lbAnnotate.AutoSize = True
        Me.lbAnnotate.BackColor = System.Drawing.Color.White
        Me.lbAnnotate.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbAnnotate.Location = New System.Drawing.Point(10, 292)
        Me.lbAnnotate.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbAnnotate.Name = "lbAnnotate"
        Me.lbAnnotate.Size = New System.Drawing.Size(65, 15)
        Me.lbAnnotate.TabIndex = 25
        Me.lbAnnotate.Text = "Annotation"
        '
        'lbReshape
        '
        Me.lbReshape.AutoSize = True
        Me.lbReshape.BackColor = System.Drawing.Color.White
        Me.lbReshape.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbReshape.Location = New System.Drawing.Point(10, 176)
        Me.lbReshape.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbReshape.Name = "lbReshape"
        Me.lbReshape.Size = New System.Drawing.Size(90, 15)
        Me.lbReshape.TabIndex = 20
        Me.lbReshape.Text = "Rotate && Mirror"
        '
        'lbGeneral
        '
        Me.lbGeneral.AutoSize = True
        Me.lbGeneral.BackColor = System.Drawing.Color.White
        Me.lbGeneral.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbGeneral.Location = New System.Drawing.Point(9, 62)
        Me.lbGeneral.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbGeneral.Name = "lbGeneral"
        Me.lbGeneral.Size = New System.Drawing.Size(51, 15)
        Me.lbGeneral.TabIndex = 84
        Me.lbGeneral.Text = "General"
        '
        'picboxDeleteAll
        '
        Me.picboxDeleteAll.Image = CType(resources.GetObject("picboxDeleteAll.Image"), System.Drawing.Image)
        Me.picboxDeleteAll.Location = New System.Drawing.Point(71, 550)
        Me.picboxDeleteAll.Name = "picboxDeleteAll"
        Me.picboxDeleteAll.Size = New System.Drawing.Size(61, 36)
        Me.picboxDeleteAll.TabIndex = 106
        Me.picboxDeleteAll.TabStop = False
        Me.picboxDeleteAll.Tag = "Delete All"
        '
        'picboxDelete
        '
        Me.picboxDelete.Image = CType(resources.GetObject("picboxDelete.Image"), System.Drawing.Image)
        Me.picboxDelete.Location = New System.Drawing.Point(12, 550)
        Me.picboxDelete.Name = "picboxDelete"
        Me.picboxDelete.Size = New System.Drawing.Size(60, 36)
        Me.picboxDelete.TabIndex = 105
        Me.picboxDelete.TabStop = False
        Me.picboxDelete.Tag = "Delete Current Image"
        '
        'picboxZoomOut
        '
        Me.picboxZoomOut.Image = CType(resources.GetObject("picboxZoomOut.Image"), System.Drawing.Image)
        Me.picboxZoomOut.Location = New System.Drawing.Point(71, 476)
        Me.picboxZoomOut.Name = "picboxZoomOut"
        Me.picboxZoomOut.Size = New System.Drawing.Size(61, 36)
        Me.picboxZoomOut.TabIndex = 103
        Me.picboxZoomOut.TabStop = False
        Me.picboxZoomOut.Tag = "Zoom Out"
        '
        'chkADF
        '
        Me.chkADF.AutoSize = True
        Me.chkADF.BackColor = System.Drawing.Color.FromArgb(CType(CType(246, Byte), Integer), CType(CType(246, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.chkADF.Enabled = False
        Me.chkADF.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkADF.Location = New System.Drawing.Point(101, 105)
        Me.chkADF.Name = "chkADF"
        Me.chkADF.Size = New System.Drawing.Size(49, 19)
        Me.chkADF.TabIndex = 51
        Me.chkADF.Text = "ADF"
        Me.chkADF.UseVisualStyleBackColor = False
        '
        'picboxResample
        '
        Me.picboxResample.Image = CType(resources.GetObject("picboxResample.Image"), System.Drawing.Image)
        Me.picboxResample.Location = New System.Drawing.Point(71, 432)
        Me.picboxResample.Name = "picboxResample"
        Me.picboxResample.Size = New System.Drawing.Size(61, 36)
        Me.picboxResample.TabIndex = 102
        Me.picboxResample.TabStop = False
        Me.picboxResample.Tag = "Resample Image"
        '
        'picboxZoomIn
        '
        Me.picboxZoomIn.Image = CType(resources.GetObject("picboxZoomIn.Image"), System.Drawing.Image)
        Me.picboxZoomIn.Location = New System.Drawing.Point(12, 476)
        Me.picboxZoomIn.Name = "picboxZoomIn"
        Me.picboxZoomIn.Size = New System.Drawing.Size(60, 36)
        Me.picboxZoomIn.TabIndex = 101
        Me.picboxZoomIn.TabStop = False
        Me.picboxZoomIn.Tag = "Zoom In"
        '
        'picboxZoom
        '
        Me.picboxZoom.Image = CType(resources.GetObject("picboxZoom.Image"), System.Drawing.Image)
        Me.picboxZoom.Location = New System.Drawing.Point(12, 432)
        Me.picboxZoom.Name = "picboxZoom"
        Me.picboxZoom.Size = New System.Drawing.Size(60, 36)
        Me.picboxZoom.TabIndex = 100
        Me.picboxZoom.TabStop = False
        Me.picboxZoom.Tag = "Zoom Detail"
        '
        'picboxText
        '
        Me.picboxText.Image = CType(resources.GetObject("picboxText.Image"), System.Drawing.Image)
        Me.picboxText.Location = New System.Drawing.Point(71, 361)
        Me.picboxText.Name = "picboxText"
        Me.picboxText.Size = New System.Drawing.Size(61, 36)
        Me.picboxText.TabIndex = 98
        Me.picboxText.TabStop = False
        Me.picboxText.Tag = "Draw Text"
        '
        'picboxEllipse
        '
        Me.picboxEllipse.Image = CType(resources.GetObject("picboxEllipse.Image"), System.Drawing.Image)
        Me.picboxEllipse.Location = New System.Drawing.Point(71, 317)
        Me.picboxEllipse.Name = "picboxEllipse"
        Me.picboxEllipse.Size = New System.Drawing.Size(61, 36)
        Me.picboxEllipse.TabIndex = 97
        Me.picboxEllipse.TabStop = False
        Me.picboxEllipse.Tag = "Draw Ellipse"
        '
        'picboxRectangle
        '
        Me.picboxRectangle.Image = CType(resources.GetObject("picboxRectangle.Image"), System.Drawing.Image)
        Me.picboxRectangle.Location = New System.Drawing.Point(12, 361)
        Me.picboxRectangle.Name = "picboxRectangle"
        Me.picboxRectangle.Size = New System.Drawing.Size(60, 36)
        Me.picboxRectangle.TabIndex = 96
        Me.picboxRectangle.TabStop = False
        Me.picboxRectangle.Tag = "Draw Rectangle"
        '
        'picboxLine
        '
        Me.picboxLine.Image = CType(resources.GetObject("picboxLine.Image"), System.Drawing.Image)
        Me.picboxLine.Location = New System.Drawing.Point(12, 317)
        Me.picboxLine.Name = "picboxLine"
        Me.picboxLine.Size = New System.Drawing.Size(60, 36)
        Me.picboxLine.TabIndex = 95
        Me.picboxLine.TabStop = False
        Me.picboxLine.Tag = "Draw Line"
        '
        'picboxFlip
        '
        Me.picboxFlip.Image = CType(resources.GetObject("picboxFlip.Image"), System.Drawing.Image)
        Me.picboxFlip.Location = New System.Drawing.Point(71, 245)
        Me.picboxFlip.Name = "picboxFlip"
        Me.picboxFlip.Size = New System.Drawing.Size(61, 36)
        Me.picboxFlip.TabIndex = 93
        Me.picboxFlip.TabStop = False
        Me.picboxFlip.Tag = "Flip"
        '
        'picboxRotateLeft
        '
        Me.picboxRotateLeft.Image = CType(resources.GetObject("picboxRotateLeft.Image"), System.Drawing.Image)
        Me.picboxRotateLeft.Location = New System.Drawing.Point(71, 201)
        Me.picboxRotateLeft.Name = "picboxRotateLeft"
        Me.picboxRotateLeft.Size = New System.Drawing.Size(61, 36)
        Me.picboxRotateLeft.TabIndex = 92
        Me.picboxRotateLeft.TabStop = False
        Me.picboxRotateLeft.Tag = "Rotate Left"
        '
        'picboxMirror
        '
        Me.picboxMirror.Image = CType(resources.GetObject("picboxMirror.Image"), System.Drawing.Image)
        Me.picboxMirror.Location = New System.Drawing.Point(12, 245)
        Me.picboxMirror.Name = "picboxMirror"
        Me.picboxMirror.Size = New System.Drawing.Size(60, 36)
        Me.picboxMirror.TabIndex = 91
        Me.picboxMirror.TabStop = False
        Me.picboxMirror.Tag = "Mirror"
        '
        'picboxRotateRight
        '
        Me.picboxRotateRight.Image = CType(resources.GetObject("picboxRotateRight.Image"), System.Drawing.Image)
        Me.picboxRotateRight.Location = New System.Drawing.Point(12, 201)
        Me.picboxRotateRight.Name = "picboxRotateRight"
        Me.picboxRotateRight.Size = New System.Drawing.Size(60, 36)
        Me.picboxRotateRight.TabIndex = 90
        Me.picboxRotateRight.TabStop = False
        Me.picboxRotateRight.Tag = "Rotate Right"
        '
        'picboxRotate
        '
        Me.picboxRotate.Image = CType(resources.GetObject("picboxRotate.Image"), System.Drawing.Image)
        Me.picboxRotate.Location = New System.Drawing.Point(70, 131)
        Me.picboxRotate.Name = "picboxRotate"
        Me.picboxRotate.Size = New System.Drawing.Size(61, 36)
        Me.picboxRotate.TabIndex = 88
        Me.picboxRotate.TabStop = False
        Me.picboxRotate.Tag = "Rotate"
        '
        'picboxPoint
        '
        Me.picboxPoint.Image = CType(resources.GetObject("picboxPoint.Image"), System.Drawing.Image)
        Me.picboxPoint.Location = New System.Drawing.Point(70, 87)
        Me.picboxPoint.Name = "picboxPoint"
        Me.picboxPoint.Size = New System.Drawing.Size(61, 36)
        Me.picboxPoint.TabIndex = 87
        Me.picboxPoint.TabStop = False
        Me.picboxPoint.Tag = "Select"
        '
        'picboxCrop
        '
        Me.picboxCrop.Image = CType(resources.GetObject("picboxCrop.Image"), System.Drawing.Image)
        Me.picboxCrop.Location = New System.Drawing.Point(11, 131)
        Me.picboxCrop.Name = "picboxCrop"
        Me.picboxCrop.Size = New System.Drawing.Size(60, 36)
        Me.picboxCrop.TabIndex = 86
        Me.picboxCrop.TabStop = False
        Me.picboxCrop.Tag = "Crop"
        '
        'picboxHand
        '
        Me.picboxHand.Image = CType(resources.GetObject("picboxHand.Image"), System.Drawing.Image)
        Me.picboxHand.Location = New System.Drawing.Point(11, 87)
        Me.picboxHand.Name = "picboxHand"
        Me.picboxHand.Size = New System.Drawing.Size(60, 36)
        Me.picboxHand.TabIndex = 85
        Me.picboxHand.TabStop = False
        Me.picboxHand.Tag = "Move"
        '
        'panelSource
        '
        Me.panelSource.BackColor = System.Drawing.Color.Transparent
        Me.panelSource.BackgroundImage = Global.DotNET_TWAIN_Demo.My.Resources.Resources.TWAIN_Source
        Me.panelSource.Controls.Add(Me.rdbtnGray)
        Me.panelSource.Controls.Add(Me.rdbtnBW)
        Me.panelSource.Controls.Add(Me.lbPixelType)
        Me.panelSource.Controls.Add(Me.lbLoadImageBar)
        Me.panelSource.Controls.Add(Me.rdbtnColor)
        Me.panelSource.Controls.Add(Me.lbTWAINSourceBar)
        Me.panelSource.Controls.Add(Me.cbxSource)
        Me.panelSource.Controls.Add(Me.cbxResolution)
        Me.panelSource.Controls.Add(Me.picboxScan)
        Me.panelSource.Controls.Add(Me.lbSelectSource)
        Me.panelSource.Controls.Add(Me.lbResolution)
        Me.panelSource.Controls.Add(Me.chkShowUI)
        Me.panelSource.Controls.Add(Me.chkDuplex)
        Me.panelSource.Controls.Add(Me.chkADF)
        Me.panelSource.Location = New System.Drawing.Point(634, 61)
        Me.panelSource.Name = "panelSource"
        Me.panelSource.Size = New System.Drawing.Size(250, 265)
        Me.panelSource.TabIndex = 82
        '
        'dynamicDotNetTwain
        '
        Me.dynamicDotNetTwain.AnnotationFillColor = System.Drawing.Color.White
        Me.dynamicDotNetTwain.AnnotationPen = Nothing
        Me.dynamicDotNetTwain.AnnotationTextColor = System.Drawing.Color.Black
        Me.dynamicDotNetTwain.AnnotationTextFont = Nothing
        Me.dynamicDotNetTwain.IfShowPrintUI = False
        Me.dynamicDotNetTwain.IfThrowException = False
        Me.dynamicDotNetTwain.Location = New System.Drawing.Point(144, 48)
        Me.dynamicDotNetTwain.LogLevel = CType(0, Short)
        Me.dynamicDotNetTwain.Name = "dynamicDotNetTwain"
        Me.dynamicDotNetTwain.PDFMarginBottom = CType(0UI, UInteger)
        Me.dynamicDotNetTwain.PDFMarginLeft = CType(0UI, UInteger)
        Me.dynamicDotNetTwain.PDFMarginRight = CType(0UI, UInteger)
        Me.dynamicDotNetTwain.PDFMarginTop = CType(0UI, UInteger)
        Me.dynamicDotNetTwain.PDFXConformance = CType(0UI, UInteger)
        Me.dynamicDotNetTwain.Size = New System.Drawing.Size(478, 590)
        Me.dynamicDotNetTwain.TabIndex = 126
        Me.dynamicDotNetTwain.Visible = False
        '
        'DotNetTWAINDemo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.DotNET_TWAIN_Demo.My.Resources.Resources.main_bg
        Me.ClientSize = New System.Drawing.Size(898, 698)
        Me.Controls.Add(Me.rdbtnPNG)
        Me.Controls.Add(Me.panelAnnotations)
        Me.Controls.Add(Me.tbxCurrentImageIndex)
        Me.Controls.Add(Me.tbxTotalImageNum)
        Me.Controls.Add(Me.lbSaveImageType)
        Me.Controls.Add(Me.rdbtnJPG)
        Me.Controls.Add(Me.rdbtnPDF)
        Me.Controls.Add(Me.rdbtnTIFF)
        Me.Controls.Add(Me.lbDiv)
        Me.Controls.Add(Me.tbxSaveFileName)
        Me.Controls.Add(Me.picboxClose)
        Me.Controls.Add(Me.rdbtnBMP)
        Me.Controls.Add(Me.picboxMin)
        Me.Controls.Add(Me.lbFileName)
        Me.Controls.Add(Me.chkMultiPage)
        Me.Controls.Add(Me.cbxViewMode)
        Me.Controls.Add(Me.picboxSave)
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
        Me.Controls.Add(Me.picboxRotate)
        Me.Controls.Add(Me.picboxPoint)
        Me.Controls.Add(Me.picboxCrop)
        Me.Controls.Add(Me.picboxHand)
        Me.Controls.Add(Me.panelSource)
        Me.Controls.Add(Me.dynamicDotNetTwain)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "DotNetTWAINDemo"
        Me.Text = "Dynamsoft .Net TWAIN Demo"
        CType(Me.picboxTitle, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picboxDeleteAnnotationA, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picboxEllipseA, System.ComponentModel.ISupportInitialize).EndInit()
        Me.panelAnnotations.ResumeLayout(False)
        Me.panelAnnotations.PerformLayout()
        CType(Me.picboxRectangleA, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picboxTextA, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picboxLineA, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picboxScan, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picboxClose, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picboxMin, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picboxSave, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picboxPrevious, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picboxNext, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picboxLast, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picboxFirst, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picboxDeleteAll, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picboxDelete, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picboxZoomOut, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picboxResample, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picboxZoomIn, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picboxZoom, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picboxText, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picboxEllipse, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picboxRectangle, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picboxLine, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picboxFlip, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picboxRotateLeft, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picboxMirror, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picboxRotateRight, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picboxRotate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picboxPoint, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picboxCrop, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picboxHand, System.ComponentModel.ISupportInitialize).EndInit()
        Me.panelSource.ResumeLayout(False)
        Me.panelSource.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents rdbtnPNG As System.Windows.Forms.RadioButton
    Private WithEvents picboxTitle As System.Windows.Forms.PictureBox
    Private WithEvents picboxDeleteAnnotationA As System.Windows.Forms.PictureBox
    Private WithEvents rdbtnGray As System.Windows.Forms.RadioButton
    Private WithEvents rdbtnBW As System.Windows.Forms.RadioButton
    Private WithEvents lbCloseAnnotations As System.Windows.Forms.Label
    Private WithEvents lbMoveBar As System.Windows.Forms.Label
    Private WithEvents picboxEllipseA As System.Windows.Forms.PictureBox
    Private WithEvents panelAnnotations As System.Windows.Forms.Panel
    Private WithEvents picboxRectangleA As System.Windows.Forms.PictureBox
    Private WithEvents picboxTextA As System.Windows.Forms.PictureBox
    Private WithEvents picboxLineA As System.Windows.Forms.PictureBox
    Private WithEvents tbxCurrentImageIndex As System.Windows.Forms.TextBox
    Private WithEvents tbxTotalImageNum As System.Windows.Forms.TextBox
    Private WithEvents saveFileDialog As System.Windows.Forms.SaveFileDialog
    Private WithEvents lbPixelType As System.Windows.Forms.Label
    Private WithEvents lbSaveImageType As System.Windows.Forms.Label
    Private WithEvents rdbtnJPG As System.Windows.Forms.RadioButton
    Private WithEvents rdbtnPDF As System.Windows.Forms.RadioButton
    Private WithEvents lbLoadImageBar As System.Windows.Forms.Label
    Private WithEvents rdbtnTIFF As System.Windows.Forms.RadioButton
    Private WithEvents rdbtnColor As System.Windows.Forms.RadioButton
    Private WithEvents cbxSource As System.Windows.Forms.ComboBox
    Private WithEvents picboxScan As System.Windows.Forms.PictureBox
    Private WithEvents lbDiv As System.Windows.Forms.Label
    Private WithEvents lbTWAINSourceBar As System.Windows.Forms.Label
    Private WithEvents cbxResolution As System.Windows.Forms.ComboBox
    Private WithEvents lbSelectSource As System.Windows.Forms.Label
    Private WithEvents lbResolution As System.Windows.Forms.Label
    Private WithEvents chkShowUI As System.Windows.Forms.CheckBox
    Private WithEvents chkDuplex As System.Windows.Forms.CheckBox
    Private WithEvents openFileDialog As System.Windows.Forms.OpenFileDialog
    Private WithEvents tbxSaveFileName As System.Windows.Forms.TextBox
    Private WithEvents picboxClose As System.Windows.Forms.PictureBox
    Private WithEvents rdbtnBMP As System.Windows.Forms.RadioButton
    Private WithEvents picboxMin As System.Windows.Forms.PictureBox
    Private WithEvents lbFileName As System.Windows.Forms.Label
    Private WithEvents chkMultiPage As System.Windows.Forms.CheckBox
    Private WithEvents cbxViewMode As System.Windows.Forms.ComboBox
    Private WithEvents picboxSave As System.Windows.Forms.PictureBox
    Private WithEvents picboxPrevious As System.Windows.Forms.PictureBox
    Private WithEvents picboxNext As System.Windows.Forms.PictureBox
    Private WithEvents picboxLast As System.Windows.Forms.PictureBox
    Private WithEvents picboxFirst As System.Windows.Forms.PictureBox
    Private WithEvents label4 As System.Windows.Forms.Label
    Private WithEvents label3 As System.Windows.Forms.Label
    Private WithEvents lbAnnotate As System.Windows.Forms.Label
    Private WithEvents lbReshape As System.Windows.Forms.Label
    Private WithEvents lbGeneral As System.Windows.Forms.Label
    Private WithEvents picboxDeleteAll As System.Windows.Forms.PictureBox
    Private WithEvents picboxDelete As System.Windows.Forms.PictureBox
    Private WithEvents picboxZoomOut As System.Windows.Forms.PictureBox
    Private WithEvents chkADF As System.Windows.Forms.CheckBox
    Private WithEvents picboxResample As System.Windows.Forms.PictureBox
    Private WithEvents picboxZoomIn As System.Windows.Forms.PictureBox
    Private WithEvents picboxZoom As System.Windows.Forms.PictureBox
    Private WithEvents picboxText As System.Windows.Forms.PictureBox
    Private WithEvents picboxEllipse As System.Windows.Forms.PictureBox
    Private WithEvents picboxRectangle As System.Windows.Forms.PictureBox
    Private WithEvents picboxLine As System.Windows.Forms.PictureBox
    Private WithEvents picboxFlip As System.Windows.Forms.PictureBox
    Private WithEvents picboxRotateLeft As System.Windows.Forms.PictureBox
    Private WithEvents picboxMirror As System.Windows.Forms.PictureBox
    Private WithEvents picboxRotateRight As System.Windows.Forms.PictureBox
    Private WithEvents picboxRotate As System.Windows.Forms.PictureBox
    Private WithEvents picboxPoint As System.Windows.Forms.PictureBox
    Private WithEvents picboxCrop As System.Windows.Forms.PictureBox
    Private WithEvents picboxHand As System.Windows.Forms.PictureBox
    Private WithEvents panelSource As System.Windows.Forms.Panel
    Private WithEvents dynamicDotNetTwain As Dynamsoft.DotNet.TWAIN.DynamicDotNetTwain

End Class
