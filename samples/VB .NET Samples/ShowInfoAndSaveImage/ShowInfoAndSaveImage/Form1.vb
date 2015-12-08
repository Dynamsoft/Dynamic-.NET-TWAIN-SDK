Option Strict Off
Option Explicit On
Friend Class Form1
    Inherits System.Windows.Forms.Form
    '/////////////////////////////////////////////////////////////////////////////////////
    ' Copyright (c)     :Dynamsoft Corporation
    ' File Name         :frmShowInfoAndSaveImage.frm
    ' Description       :Example of getting the acquired image's infomation.
    '///////////////////////////////////////////////////////////////////////////////////////////
    Dim sImageType As Short
#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()
        dynamicDotNetTwain.LicenseKeys = "BAF81AB5515958BF519F7AAE2A318B3B;BAF81AB5515958BF6DA4299CBA3CC11D;BAF81AB5515958BF9C195A4722534974;BAF81AB5515958BFE96B7433DD28E75B;BAF81AB5515958BF3DBAF9AB37059787;BAF81AB5515958BF5291EEE0B030BD82"
        'Add any initialization after the InitializeComponent() call
        dynamicDotNetTwain.ScanInNewProcess = True
    End Sub


    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    <System.Diagnostics.DebuggerStepThrough()> _
  Private Sub InitializeComponent()
        Me.cmdRemove = New System.Windows.Forms.Button
        Me.cmdSave = New System.Windows.Forms.Button
        Me.cmdScan = New System.Windows.Forms.Button
        Me.frmSaveImage = New System.Windows.Forms.GroupBox
        Me.optPDF = New System.Windows.Forms.RadioButton
        Me.optTIFF = New System.Windows.Forms.RadioButton
        Me.optPNG = New System.Windows.Forms.RadioButton
        Me.optJPEG = New System.Windows.Forms.RadioButton
        Me.optBMP = New System.Windows.Forms.RadioButton
        Me.chkMultiPageTIFF = New System.Windows.Forms.CheckBox
        Me.chkMultiPagePDF = New System.Windows.Forms.CheckBox
        Me.txtFileSize = New System.Windows.Forms.TextBox
        Me.lblFileSize = New System.Windows.Forms.Label
        Me.frmGetImagelayoutvalues = New System.Windows.Forms.GroupBox
        Me.txtImageLayoutFrameNumber = New System.Windows.Forms.TextBox
        Me.txtImageLayoutPageNumber = New System.Windows.Forms.TextBox
        Me.txtImageLayoutDocumentNumber = New System.Windows.Forms.TextBox
        Me.txtImageLayoutFrameBottom = New System.Windows.Forms.TextBox
        Me.txtImageLayoutFrameRight = New System.Windows.Forms.TextBox
        Me.txtImageLayoutFrameTop = New System.Windows.Forms.TextBox
        Me.txtImageLayoutFrameLeft = New System.Windows.Forms.TextBox
        Me.lblImageLayoutFrameNumber = New System.Windows.Forms.Label
        Me.lblImageLayoutDocumentNumber = New System.Windows.Forms.Label
        Me.lblImageLayoutFrameRight = New System.Windows.Forms.Label
        Me.lblImageLayoutFrameLeft = New System.Windows.Forms.Label
        Me.lblImageLayoutPageNumber = New System.Windows.Forms.Label
        Me.lblImageLayoutFrameBottom = New System.Windows.Forms.Label
        Me.lblImageLayoutFrameTop = New System.Windows.Forms.Label
        Me.frmGetImageValues = New System.Windows.Forms.GroupBox
        Me.txtImageXResolution = New System.Windows.Forms.TextBox
        Me.txtImageWidth = New System.Windows.Forms.TextBox
        Me.txtImageBitsPerPixel = New System.Windows.Forms.TextBox
        Me.txtImagePixelType = New System.Windows.Forms.TextBox
        Me.txtImageYResolution = New System.Windows.Forms.TextBox
        Me.txtImageLength = New System.Windows.Forms.TextBox
        Me.lblImageYResolution = New System.Windows.Forms.Label
        Me.lblImageLength = New System.Windows.Forms.Label
        Me.lblImageXResolution = New System.Windows.Forms.Label
        Me.lblImageWidth = New System.Windows.Forms.Label
        Me.lblImageBitsPerPixel = New System.Windows.Forms.Label
        Me.lblImagePixelType = New System.Windows.Forms.Label
        Me.frmView = New System.Windows.Forms.GroupBox
        Me.dynamicDotNetTwain = New Dynamsoft.DotNet.TWAIN.DynamicDotNetTwain
        Me.dlgFileSaveSave = New System.Windows.Forms.SaveFileDialog
        Me.frmSaveImage.SuspendLayout()
        Me.frmGetImagelayoutvalues.SuspendLayout()
        Me.frmGetImageValues.SuspendLayout()
        Me.frmView.SuspendLayout()
        Me.SuspendLayout()
        '
        'cmdRemove
        '
        Me.cmdRemove.BackColor = System.Drawing.SystemColors.Control
        Me.cmdRemove.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdRemove.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdRemove.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdRemove.Location = New System.Drawing.Point(544, 302)
        Me.cmdRemove.Name = "cmdRemove"
        Me.cmdRemove.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdRemove.Size = New System.Drawing.Size(65, 23)
        Me.cmdRemove.TabIndex = 49
        Me.cmdRemove.Text = "Remove"
        Me.cmdRemove.UseVisualStyleBackColor = False
        '
        'cmdSave
        '
        Me.cmdSave.BackColor = System.Drawing.SystemColors.Control
        Me.cmdSave.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdSave.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdSave.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdSave.Location = New System.Drawing.Point(544, 272)
        Me.cmdSave.Name = "cmdSave"
        Me.cmdSave.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdSave.Size = New System.Drawing.Size(65, 23)
        Me.cmdSave.TabIndex = 48
        Me.cmdSave.Text = "Save"
        Me.cmdSave.UseVisualStyleBackColor = False
        '
        'cmdScan
        '
        Me.cmdScan.BackColor = System.Drawing.SystemColors.Control
        Me.cmdScan.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdScan.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdScan.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdScan.Location = New System.Drawing.Point(544, 243)
        Me.cmdScan.Name = "cmdScan"
        Me.cmdScan.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdScan.Size = New System.Drawing.Size(65, 23)
        Me.cmdScan.TabIndex = 47
        Me.cmdScan.Text = "Scan"
        Me.cmdScan.UseVisualStyleBackColor = False
        '
        'frmSaveImage
        '
        Me.frmSaveImage.BackColor = System.Drawing.SystemColors.Control
        Me.frmSaveImage.Controls.Add(Me.optPDF)
        Me.frmSaveImage.Controls.Add(Me.optTIFF)
        Me.frmSaveImage.Controls.Add(Me.optPNG)
        Me.frmSaveImage.Controls.Add(Me.optJPEG)
        Me.frmSaveImage.Controls.Add(Me.optBMP)
        Me.frmSaveImage.Controls.Add(Me.chkMultiPageTIFF)
        Me.frmSaveImage.Controls.Add(Me.chkMultiPagePDF)
        Me.frmSaveImage.Controls.Add(Me.txtFileSize)
        Me.frmSaveImage.Controls.Add(Me.lblFileSize)
        Me.frmSaveImage.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.frmSaveImage.ForeColor = System.Drawing.SystemColors.ControlText
        Me.frmSaveImage.Location = New System.Drawing.Point(248, 235)
        Me.frmSaveImage.Name = "frmSaveImage"
        Me.frmSaveImage.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.frmSaveImage.Size = New System.Drawing.Size(273, 97)
        Me.frmSaveImage.TabIndex = 46
        Me.frmSaveImage.TabStop = False
        Me.frmSaveImage.Text = "Save Images"
        '
        'optPDF
        '
        Me.optPDF.BackColor = System.Drawing.SystemColors.Control
        Me.optPDF.Cursor = System.Windows.Forms.Cursors.Default
        Me.optPDF.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.optPDF.ForeColor = System.Drawing.SystemColors.ControlText
        Me.optPDF.Location = New System.Drawing.Point(216, 22)
        Me.optPDF.Name = "optPDF"
        Me.optPDF.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.optPDF.Size = New System.Drawing.Size(49, 17)
        Me.optPDF.TabIndex = 41
        Me.optPDF.TabStop = True
        Me.optPDF.Text = "PDF"
        Me.optPDF.UseVisualStyleBackColor = False
        '
        'optTIFF
        '
        Me.optTIFF.BackColor = System.Drawing.SystemColors.Control
        Me.optTIFF.Cursor = System.Windows.Forms.Cursors.Default
        Me.optTIFF.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.optTIFF.ForeColor = System.Drawing.SystemColors.ControlText
        Me.optTIFF.Location = New System.Drawing.Point(168, 22)
        Me.optTIFF.Name = "optTIFF"
        Me.optTIFF.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.optTIFF.Size = New System.Drawing.Size(49, 16)
        Me.optTIFF.TabIndex = 40
        Me.optTIFF.TabStop = True
        Me.optTIFF.Text = "TIFF"
        Me.optTIFF.UseVisualStyleBackColor = False
        '
        'optPNG
        '
        Me.optPNG.BackColor = System.Drawing.SystemColors.Control
        Me.optPNG.Cursor = System.Windows.Forms.Cursors.Default
        Me.optPNG.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.optPNG.ForeColor = System.Drawing.SystemColors.ControlText
        Me.optPNG.Location = New System.Drawing.Point(120, 22)
        Me.optPNG.Name = "optPNG"
        Me.optPNG.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.optPNG.Size = New System.Drawing.Size(49, 16)
        Me.optPNG.TabIndex = 39
        Me.optPNG.TabStop = True
        Me.optPNG.Text = "PNG"
        Me.optPNG.UseVisualStyleBackColor = False
        '
        'optJPEG
        '
        Me.optJPEG.BackColor = System.Drawing.SystemColors.Control
        Me.optJPEG.Cursor = System.Windows.Forms.Cursors.Default
        Me.optJPEG.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.optJPEG.ForeColor = System.Drawing.SystemColors.ControlText
        Me.optJPEG.Location = New System.Drawing.Point(72, 22)
        Me.optJPEG.Name = "optJPEG"
        Me.optJPEG.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.optJPEG.Size = New System.Drawing.Size(57, 16)
        Me.optJPEG.TabIndex = 38
        Me.optJPEG.TabStop = True
        Me.optJPEG.Text = "JPEG"
        Me.optJPEG.UseVisualStyleBackColor = False
        '
        'optBMP
        '
        Me.optBMP.BackColor = System.Drawing.SystemColors.Control
        Me.optBMP.Cursor = System.Windows.Forms.Cursors.Default
        Me.optBMP.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.optBMP.ForeColor = System.Drawing.SystemColors.ControlText
        Me.optBMP.Location = New System.Drawing.Point(24, 22)
        Me.optBMP.Name = "optBMP"
        Me.optBMP.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.optBMP.Size = New System.Drawing.Size(49, 16)
        Me.optBMP.TabIndex = 37
        Me.optBMP.TabStop = True
        Me.optBMP.Text = "BMP"
        Me.optBMP.UseVisualStyleBackColor = False
        '
        'chkMultiPageTIFF
        '
        Me.chkMultiPageTIFF.BackColor = System.Drawing.SystemColors.Control
        Me.chkMultiPageTIFF.Cursor = System.Windows.Forms.Cursors.Default
        Me.chkMultiPageTIFF.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkMultiPageTIFF.ForeColor = System.Drawing.SystemColors.ControlText
        Me.chkMultiPageTIFF.Location = New System.Drawing.Point(24, 44)
        Me.chkMultiPageTIFF.Name = "chkMultiPageTIFF"
        Me.chkMultiPageTIFF.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.chkMultiPageTIFF.Size = New System.Drawing.Size(105, 16)
        Me.chkMultiPageTIFF.TabIndex = 35
        Me.chkMultiPageTIFF.Text = "Multi-Page TIFF"
        Me.chkMultiPageTIFF.UseVisualStyleBackColor = False
        '
        'chkMultiPagePDF
        '
        Me.chkMultiPagePDF.BackColor = System.Drawing.SystemColors.Control
        Me.chkMultiPagePDF.Cursor = System.Windows.Forms.Cursors.Default
        Me.chkMultiPagePDF.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkMultiPagePDF.ForeColor = System.Drawing.SystemColors.ControlText
        Me.chkMultiPagePDF.Location = New System.Drawing.Point(144, 44)
        Me.chkMultiPagePDF.Name = "chkMultiPagePDF"
        Me.chkMultiPagePDF.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.chkMultiPagePDF.Size = New System.Drawing.Size(97, 16)
        Me.chkMultiPagePDF.TabIndex = 34
        Me.chkMultiPagePDF.Text = "Multi-Page PDF"
        Me.chkMultiPagePDF.UseVisualStyleBackColor = False
        '
        'txtFileSize
        '
        Me.txtFileSize.AcceptsReturn = True
        Me.txtFileSize.BackColor = System.Drawing.SystemColors.Window
        Me.txtFileSize.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtFileSize.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFileSize.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtFileSize.Location = New System.Drawing.Point(144, 66)
        Me.txtFileSize.MaxLength = 0
        Me.txtFileSize.Name = "txtFileSize"
        Me.txtFileSize.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtFileSize.Size = New System.Drawing.Size(105, 20)
        Me.txtFileSize.TabIndex = 32
        '
        'lblFileSize
        '
        Me.lblFileSize.BackColor = System.Drawing.SystemColors.Control
        Me.lblFileSize.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblFileSize.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFileSize.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblFileSize.Location = New System.Drawing.Point(88, 68)
        Me.lblFileSize.Name = "lblFileSize"
        Me.lblFileSize.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblFileSize.Size = New System.Drawing.Size(50, 16)
        Me.lblFileSize.TabIndex = 31
        Me.lblFileSize.Text = "File Size:"
        '
        'frmGetImagelayoutvalues
        '
        Me.frmGetImagelayoutvalues.BackColor = System.Drawing.SystemColors.Control
        Me.frmGetImagelayoutvalues.Controls.Add(Me.txtImageLayoutFrameNumber)
        Me.frmGetImagelayoutvalues.Controls.Add(Me.txtImageLayoutPageNumber)
        Me.frmGetImagelayoutvalues.Controls.Add(Me.txtImageLayoutDocumentNumber)
        Me.frmGetImagelayoutvalues.Controls.Add(Me.txtImageLayoutFrameBottom)
        Me.frmGetImagelayoutvalues.Controls.Add(Me.txtImageLayoutFrameRight)
        Me.frmGetImagelayoutvalues.Controls.Add(Me.txtImageLayoutFrameTop)
        Me.frmGetImagelayoutvalues.Controls.Add(Me.txtImageLayoutFrameLeft)
        Me.frmGetImagelayoutvalues.Controls.Add(Me.lblImageLayoutFrameNumber)
        Me.frmGetImagelayoutvalues.Controls.Add(Me.lblImageLayoutDocumentNumber)
        Me.frmGetImagelayoutvalues.Controls.Add(Me.lblImageLayoutFrameRight)
        Me.frmGetImagelayoutvalues.Controls.Add(Me.lblImageLayoutFrameLeft)
        Me.frmGetImagelayoutvalues.Controls.Add(Me.lblImageLayoutPageNumber)
        Me.frmGetImagelayoutvalues.Controls.Add(Me.lblImageLayoutFrameBottom)
        Me.frmGetImagelayoutvalues.Controls.Add(Me.lblImageLayoutFrameTop)
        Me.frmGetImagelayoutvalues.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.frmGetImagelayoutvalues.ForeColor = System.Drawing.SystemColors.ControlText
        Me.frmGetImagelayoutvalues.Location = New System.Drawing.Point(248, 110)
        Me.frmGetImagelayoutvalues.Name = "frmGetImagelayoutvalues"
        Me.frmGetImagelayoutvalues.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.frmGetImagelayoutvalues.Size = New System.Drawing.Size(377, 119)
        Me.frmGetImagelayoutvalues.TabIndex = 44
        Me.frmGetImagelayoutvalues.TabStop = False
        Me.frmGetImagelayoutvalues.Text = "Image layout information"
        '
        'txtImageLayoutFrameNumber
        '
        Me.txtImageLayoutFrameNumber.AcceptsReturn = True
        Me.txtImageLayoutFrameNumber.BackColor = System.Drawing.SystemColors.Window
        Me.txtImageLayoutFrameNumber.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtImageLayoutFrameNumber.Enabled = False
        Me.txtImageLayoutFrameNumber.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtImageLayoutFrameNumber.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtImageLayoutFrameNumber.Location = New System.Drawing.Point(112, 89)
        Me.txtImageLayoutFrameNumber.MaxLength = 0
        Me.txtImageLayoutFrameNumber.Name = "txtImageLayoutFrameNumber"
        Me.txtImageLayoutFrameNumber.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtImageLayoutFrameNumber.Size = New System.Drawing.Size(81, 20)
        Me.txtImageLayoutFrameNumber.TabIndex = 20
        '
        'txtImageLayoutPageNumber
        '
        Me.txtImageLayoutPageNumber.AcceptsReturn = True
        Me.txtImageLayoutPageNumber.BackColor = System.Drawing.SystemColors.Window
        Me.txtImageLayoutPageNumber.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtImageLayoutPageNumber.Enabled = False
        Me.txtImageLayoutPageNumber.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtImageLayoutPageNumber.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtImageLayoutPageNumber.Location = New System.Drawing.Point(280, 66)
        Me.txtImageLayoutPageNumber.MaxLength = 0
        Me.txtImageLayoutPageNumber.Name = "txtImageLayoutPageNumber"
        Me.txtImageLayoutPageNumber.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtImageLayoutPageNumber.Size = New System.Drawing.Size(81, 20)
        Me.txtImageLayoutPageNumber.TabIndex = 19
        '
        'txtImageLayoutDocumentNumber
        '
        Me.txtImageLayoutDocumentNumber.AcceptsReturn = True
        Me.txtImageLayoutDocumentNumber.BackColor = System.Drawing.SystemColors.Window
        Me.txtImageLayoutDocumentNumber.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtImageLayoutDocumentNumber.Enabled = False
        Me.txtImageLayoutDocumentNumber.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtImageLayoutDocumentNumber.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtImageLayoutDocumentNumber.Location = New System.Drawing.Point(112, 66)
        Me.txtImageLayoutDocumentNumber.MaxLength = 0
        Me.txtImageLayoutDocumentNumber.Name = "txtImageLayoutDocumentNumber"
        Me.txtImageLayoutDocumentNumber.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtImageLayoutDocumentNumber.Size = New System.Drawing.Size(81, 20)
        Me.txtImageLayoutDocumentNumber.TabIndex = 18
        '
        'txtImageLayoutFrameBottom
        '
        Me.txtImageLayoutFrameBottom.AcceptsReturn = True
        Me.txtImageLayoutFrameBottom.BackColor = System.Drawing.SystemColors.Window
        Me.txtImageLayoutFrameBottom.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtImageLayoutFrameBottom.Enabled = False
        Me.txtImageLayoutFrameBottom.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtImageLayoutFrameBottom.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtImageLayoutFrameBottom.Location = New System.Drawing.Point(280, 44)
        Me.txtImageLayoutFrameBottom.MaxLength = 0
        Me.txtImageLayoutFrameBottom.Name = "txtImageLayoutFrameBottom"
        Me.txtImageLayoutFrameBottom.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtImageLayoutFrameBottom.Size = New System.Drawing.Size(81, 20)
        Me.txtImageLayoutFrameBottom.TabIndex = 17
        '
        'txtImageLayoutFrameRight
        '
        Me.txtImageLayoutFrameRight.AcceptsReturn = True
        Me.txtImageLayoutFrameRight.BackColor = System.Drawing.SystemColors.Window
        Me.txtImageLayoutFrameRight.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtImageLayoutFrameRight.Enabled = False
        Me.txtImageLayoutFrameRight.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtImageLayoutFrameRight.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtImageLayoutFrameRight.Location = New System.Drawing.Point(112, 44)
        Me.txtImageLayoutFrameRight.MaxLength = 0
        Me.txtImageLayoutFrameRight.Name = "txtImageLayoutFrameRight"
        Me.txtImageLayoutFrameRight.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtImageLayoutFrameRight.Size = New System.Drawing.Size(81, 20)
        Me.txtImageLayoutFrameRight.TabIndex = 16
        '
        'txtImageLayoutFrameTop
        '
        Me.txtImageLayoutFrameTop.AcceptsReturn = True
        Me.txtImageLayoutFrameTop.BackColor = System.Drawing.SystemColors.Window
        Me.txtImageLayoutFrameTop.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtImageLayoutFrameTop.Enabled = False
        Me.txtImageLayoutFrameTop.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtImageLayoutFrameTop.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtImageLayoutFrameTop.Location = New System.Drawing.Point(280, 22)
        Me.txtImageLayoutFrameTop.MaxLength = 0
        Me.txtImageLayoutFrameTop.Name = "txtImageLayoutFrameTop"
        Me.txtImageLayoutFrameTop.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtImageLayoutFrameTop.Size = New System.Drawing.Size(81, 20)
        Me.txtImageLayoutFrameTop.TabIndex = 15
        '
        'txtImageLayoutFrameLeft
        '
        Me.txtImageLayoutFrameLeft.AcceptsReturn = True
        Me.txtImageLayoutFrameLeft.BackColor = System.Drawing.SystemColors.Window
        Me.txtImageLayoutFrameLeft.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtImageLayoutFrameLeft.Enabled = False
        Me.txtImageLayoutFrameLeft.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtImageLayoutFrameLeft.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtImageLayoutFrameLeft.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txtImageLayoutFrameLeft.Location = New System.Drawing.Point(112, 22)
        Me.txtImageLayoutFrameLeft.MaxLength = 0
        Me.txtImageLayoutFrameLeft.Name = "txtImageLayoutFrameLeft"
        Me.txtImageLayoutFrameLeft.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtImageLayoutFrameLeft.Size = New System.Drawing.Size(81, 20)
        Me.txtImageLayoutFrameLeft.TabIndex = 14
        '
        'lblImageLayoutFrameNumber
        '
        Me.lblImageLayoutFrameNumber.BackColor = System.Drawing.SystemColors.Control
        Me.lblImageLayoutFrameNumber.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblImageLayoutFrameNumber.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblImageLayoutFrameNumber.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblImageLayoutFrameNumber.Location = New System.Drawing.Point(24, 89)
        Me.lblImageLayoutFrameNumber.Name = "lblImageLayoutFrameNumber"
        Me.lblImageLayoutFrameNumber.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblImageLayoutFrameNumber.Size = New System.Drawing.Size(81, 16)
        Me.lblImageLayoutFrameNumber.TabIndex = 27
        Me.lblImageLayoutFrameNumber.Text = "Frame Number:"
        Me.lblImageLayoutFrameNumber.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblImageLayoutDocumentNumber
        '
        Me.lblImageLayoutDocumentNumber.BackColor = System.Drawing.SystemColors.Control
        Me.lblImageLayoutDocumentNumber.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblImageLayoutDocumentNumber.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblImageLayoutDocumentNumber.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblImageLayoutDocumentNumber.Location = New System.Drawing.Point(-1, 66)
        Me.lblImageLayoutDocumentNumber.Name = "lblImageLayoutDocumentNumber"
        Me.lblImageLayoutDocumentNumber.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblImageLayoutDocumentNumber.Size = New System.Drawing.Size(106, 16)
        Me.lblImageLayoutDocumentNumber.TabIndex = 26
        Me.lblImageLayoutDocumentNumber.Text = "Document Number:"
        Me.lblImageLayoutDocumentNumber.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblImageLayoutFrameRight
        '
        Me.lblImageLayoutFrameRight.BackColor = System.Drawing.SystemColors.Control
        Me.lblImageLayoutFrameRight.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblImageLayoutFrameRight.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblImageLayoutFrameRight.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblImageLayoutFrameRight.Location = New System.Drawing.Point(8, 44)
        Me.lblImageLayoutFrameRight.Name = "lblImageLayoutFrameRight"
        Me.lblImageLayoutFrameRight.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblImageLayoutFrameRight.Size = New System.Drawing.Size(97, 16)
        Me.lblImageLayoutFrameRight.TabIndex = 25
        Me.lblImageLayoutFrameRight.Text = "Frame Right:"
        Me.lblImageLayoutFrameRight.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblImageLayoutFrameLeft
        '
        Me.lblImageLayoutFrameLeft.BackColor = System.Drawing.SystemColors.Control
        Me.lblImageLayoutFrameLeft.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblImageLayoutFrameLeft.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblImageLayoutFrameLeft.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblImageLayoutFrameLeft.Location = New System.Drawing.Point(8, 22)
        Me.lblImageLayoutFrameLeft.Name = "lblImageLayoutFrameLeft"
        Me.lblImageLayoutFrameLeft.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblImageLayoutFrameLeft.Size = New System.Drawing.Size(97, 16)
        Me.lblImageLayoutFrameLeft.TabIndex = 24
        Me.lblImageLayoutFrameLeft.Text = "Frame Left:"
        Me.lblImageLayoutFrameLeft.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblImageLayoutPageNumber
        '
        Me.lblImageLayoutPageNumber.BackColor = System.Drawing.SystemColors.Control
        Me.lblImageLayoutPageNumber.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblImageLayoutPageNumber.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblImageLayoutPageNumber.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblImageLayoutPageNumber.Location = New System.Drawing.Point(192, 66)
        Me.lblImageLayoutPageNumber.Name = "lblImageLayoutPageNumber"
        Me.lblImageLayoutPageNumber.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblImageLayoutPageNumber.Size = New System.Drawing.Size(82, 16)
        Me.lblImageLayoutPageNumber.TabIndex = 23
        Me.lblImageLayoutPageNumber.Text = "Page Number:"
        Me.lblImageLayoutPageNumber.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblImageLayoutFrameBottom
        '
        Me.lblImageLayoutFrameBottom.BackColor = System.Drawing.SystemColors.Control
        Me.lblImageLayoutFrameBottom.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblImageLayoutFrameBottom.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblImageLayoutFrameBottom.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblImageLayoutFrameBottom.Location = New System.Drawing.Point(191, 44)
        Me.lblImageLayoutFrameBottom.Name = "lblImageLayoutFrameBottom"
        Me.lblImageLayoutFrameBottom.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblImageLayoutFrameBottom.Size = New System.Drawing.Size(82, 16)
        Me.lblImageLayoutFrameBottom.TabIndex = 22
        Me.lblImageLayoutFrameBottom.Text = "Frame Bottom:"
        Me.lblImageLayoutFrameBottom.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblImageLayoutFrameTop
        '
        Me.lblImageLayoutFrameTop.BackColor = System.Drawing.SystemColors.Control
        Me.lblImageLayoutFrameTop.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblImageLayoutFrameTop.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblImageLayoutFrameTop.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblImageLayoutFrameTop.Location = New System.Drawing.Point(200, 22)
        Me.lblImageLayoutFrameTop.Name = "lblImageLayoutFrameTop"
        Me.lblImageLayoutFrameTop.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblImageLayoutFrameTop.Size = New System.Drawing.Size(73, 16)
        Me.lblImageLayoutFrameTop.TabIndex = 21
        Me.lblImageLayoutFrameTop.Text = "Frame Top:"
        Me.lblImageLayoutFrameTop.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'frmGetImageValues
        '
        Me.frmGetImageValues.BackColor = System.Drawing.SystemColors.Control
        Me.frmGetImageValues.Controls.Add(Me.txtImageXResolution)
        Me.frmGetImageValues.Controls.Add(Me.txtImageWidth)
        Me.frmGetImageValues.Controls.Add(Me.txtImageBitsPerPixel)
        Me.frmGetImageValues.Controls.Add(Me.txtImagePixelType)
        Me.frmGetImageValues.Controls.Add(Me.txtImageYResolution)
        Me.frmGetImageValues.Controls.Add(Me.txtImageLength)
        Me.frmGetImageValues.Controls.Add(Me.lblImageYResolution)
        Me.frmGetImageValues.Controls.Add(Me.lblImageLength)
        Me.frmGetImageValues.Controls.Add(Me.lblImageXResolution)
        Me.frmGetImageValues.Controls.Add(Me.lblImageWidth)
        Me.frmGetImageValues.Controls.Add(Me.lblImageBitsPerPixel)
        Me.frmGetImageValues.Controls.Add(Me.lblImagePixelType)
        Me.frmGetImageValues.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.frmGetImageValues.ForeColor = System.Drawing.SystemColors.ControlText
        Me.frmGetImageValues.Location = New System.Drawing.Point(248, 6)
        Me.frmGetImageValues.Name = "frmGetImageValues"
        Me.frmGetImageValues.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.frmGetImageValues.Size = New System.Drawing.Size(377, 97)
        Me.frmGetImageValues.TabIndex = 43
        Me.frmGetImageValues.TabStop = False
        Me.frmGetImageValues.Text = "Image information"
        '
        'txtImageXResolution
        '
        Me.txtImageXResolution.AcceptsReturn = True
        Me.txtImageXResolution.BackColor = System.Drawing.SystemColors.Window
        Me.txtImageXResolution.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtImageXResolution.Enabled = False
        Me.txtImageXResolution.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtImageXResolution.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtImageXResolution.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txtImageXResolution.Location = New System.Drawing.Point(91, 22)
        Me.txtImageXResolution.MaxLength = 0
        Me.txtImageXResolution.Name = "txtImageXResolution"
        Me.txtImageXResolution.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtImageXResolution.Size = New System.Drawing.Size(81, 20)
        Me.txtImageXResolution.TabIndex = 7
        '
        'txtImageWidth
        '
        Me.txtImageWidth.AcceptsReturn = True
        Me.txtImageWidth.BackColor = System.Drawing.SystemColors.Window
        Me.txtImageWidth.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtImageWidth.Enabled = False
        Me.txtImageWidth.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtImageWidth.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtImageWidth.Location = New System.Drawing.Point(91, 44)
        Me.txtImageWidth.MaxLength = 0
        Me.txtImageWidth.Name = "txtImageWidth"
        Me.txtImageWidth.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtImageWidth.Size = New System.Drawing.Size(81, 20)
        Me.txtImageWidth.TabIndex = 6
        '
        'txtImageBitsPerPixel
        '
        Me.txtImageBitsPerPixel.AcceptsReturn = True
        Me.txtImageBitsPerPixel.BackColor = System.Drawing.SystemColors.Window
        Me.txtImageBitsPerPixel.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtImageBitsPerPixel.Enabled = False
        Me.txtImageBitsPerPixel.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtImageBitsPerPixel.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtImageBitsPerPixel.Location = New System.Drawing.Point(91, 66)
        Me.txtImageBitsPerPixel.MaxLength = 0
        Me.txtImageBitsPerPixel.Name = "txtImageBitsPerPixel"
        Me.txtImageBitsPerPixel.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtImageBitsPerPixel.Size = New System.Drawing.Size(81, 20)
        Me.txtImageBitsPerPixel.TabIndex = 5
        '
        'txtImagePixelType
        '
        Me.txtImagePixelType.AcceptsReturn = True
        Me.txtImagePixelType.BackColor = System.Drawing.SystemColors.Window
        Me.txtImagePixelType.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtImagePixelType.Enabled = False
        Me.txtImagePixelType.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtImagePixelType.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtImagePixelType.Location = New System.Drawing.Point(272, 66)
        Me.txtImagePixelType.MaxLength = 0
        Me.txtImagePixelType.Name = "txtImagePixelType"
        Me.txtImagePixelType.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtImagePixelType.Size = New System.Drawing.Size(81, 20)
        Me.txtImagePixelType.TabIndex = 4
        '
        'txtImageYResolution
        '
        Me.txtImageYResolution.AcceptsReturn = True
        Me.txtImageYResolution.BackColor = System.Drawing.SystemColors.Window
        Me.txtImageYResolution.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtImageYResolution.Enabled = False
        Me.txtImageYResolution.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtImageYResolution.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtImageYResolution.Location = New System.Drawing.Point(272, 22)
        Me.txtImageYResolution.MaxLength = 0
        Me.txtImageYResolution.Name = "txtImageYResolution"
        Me.txtImageYResolution.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtImageYResolution.Size = New System.Drawing.Size(81, 20)
        Me.txtImageYResolution.TabIndex = 3
        '
        'txtImageLength
        '
        Me.txtImageLength.AcceptsReturn = True
        Me.txtImageLength.BackColor = System.Drawing.SystemColors.Window
        Me.txtImageLength.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtImageLength.Enabled = False
        Me.txtImageLength.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtImageLength.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtImageLength.Location = New System.Drawing.Point(272, 44)
        Me.txtImageLength.MaxLength = 0
        Me.txtImageLength.Name = "txtImageLength"
        Me.txtImageLength.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtImageLength.Size = New System.Drawing.Size(81, 20)
        Me.txtImageLength.TabIndex = 2
        '
        'lblImageYResolution
        '
        Me.lblImageYResolution.BackColor = System.Drawing.SystemColors.Control
        Me.lblImageYResolution.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblImageYResolution.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblImageYResolution.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblImageYResolution.Location = New System.Drawing.Point(192, 22)
        Me.lblImageYResolution.Name = "lblImageYResolution"
        Me.lblImageYResolution.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblImageYResolution.Size = New System.Drawing.Size(73, 16)
        Me.lblImageYResolution.TabIndex = 0
        Me.lblImageYResolution.Text = "Y Resolution:"
        Me.lblImageYResolution.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblImageLength
        '
        Me.lblImageLength.BackColor = System.Drawing.SystemColors.Control
        Me.lblImageLength.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblImageLength.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblImageLength.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblImageLength.Location = New System.Drawing.Point(216, 44)
        Me.lblImageLength.Name = "lblImageLength"
        Me.lblImageLength.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblImageLength.Size = New System.Drawing.Size(49, 16)
        Me.lblImageLength.TabIndex = 12
        Me.lblImageLength.Text = "Length:"
        Me.lblImageLength.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblImageXResolution
        '
        Me.lblImageXResolution.BackColor = System.Drawing.SystemColors.Control
        Me.lblImageXResolution.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblImageXResolution.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblImageXResolution.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblImageXResolution.Location = New System.Drawing.Point(6, 22)
        Me.lblImageXResolution.Name = "lblImageXResolution"
        Me.lblImageXResolution.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblImageXResolution.Size = New System.Drawing.Size(79, 16)
        Me.lblImageXResolution.TabIndex = 11
        Me.lblImageXResolution.Text = "X Resolution:"
        Me.lblImageXResolution.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblImageWidth
        '
        Me.lblImageWidth.BackColor = System.Drawing.SystemColors.Control
        Me.lblImageWidth.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblImageWidth.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblImageWidth.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblImageWidth.Location = New System.Drawing.Point(20, 44)
        Me.lblImageWidth.Name = "lblImageWidth"
        Me.lblImageWidth.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblImageWidth.Size = New System.Drawing.Size(65, 16)
        Me.lblImageWidth.TabIndex = 10
        Me.lblImageWidth.Text = "Width:"
        Me.lblImageWidth.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblImageBitsPerPixel
        '
        Me.lblImageBitsPerPixel.BackColor = System.Drawing.SystemColors.Control
        Me.lblImageBitsPerPixel.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblImageBitsPerPixel.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblImageBitsPerPixel.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblImageBitsPerPixel.Location = New System.Drawing.Point(12, 66)
        Me.lblImageBitsPerPixel.Name = "lblImageBitsPerPixel"
        Me.lblImageBitsPerPixel.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblImageBitsPerPixel.Size = New System.Drawing.Size(73, 16)
        Me.lblImageBitsPerPixel.TabIndex = 9
        Me.lblImageBitsPerPixel.Text = "Bits Per Pixel:"
        Me.lblImageBitsPerPixel.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblImagePixelType
        '
        Me.lblImagePixelType.BackColor = System.Drawing.SystemColors.Control
        Me.lblImagePixelType.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblImagePixelType.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblImagePixelType.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblImagePixelType.Location = New System.Drawing.Point(208, 66)
        Me.lblImagePixelType.Name = "lblImagePixelType"
        Me.lblImagePixelType.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblImagePixelType.Size = New System.Drawing.Size(57, 16)
        Me.lblImagePixelType.TabIndex = 8
        Me.lblImagePixelType.Text = "Pixel:"
        Me.lblImagePixelType.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'frmView
        '
        Me.frmView.BackColor = System.Drawing.SystemColors.Control
        Me.frmView.Controls.Add(Me.dynamicDotNetTwain)
        Me.frmView.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.frmView.ForeColor = System.Drawing.SystemColors.ControlText
        Me.frmView.Location = New System.Drawing.Point(8, 6)
        Me.frmView.Name = "frmView"
        Me.frmView.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.frmView.Size = New System.Drawing.Size(233, 326)
        Me.frmView.TabIndex = 45
        Me.frmView.TabStop = False
        Me.frmView.Text = "View"
        '
        'dynamicDotNetTwain
        '
        Me.dynamicDotNetTwain.AnnotationFillColor = System.Drawing.Color.White
        Me.dynamicDotNetTwain.AnnotationPen = Nothing
        Me.dynamicDotNetTwain.AnnotationTextColor = System.Drawing.Color.Black
        Me.dynamicDotNetTwain.AnnotationTextFont = Nothing
        Me.dynamicDotNetTwain.IfShowPrintUI = False
        Me.dynamicDotNetTwain.IfThrowException = False
        Me.dynamicDotNetTwain.Location = New System.Drawing.Point(6, 18)
        Me.dynamicDotNetTwain.LogLevel = CType(0, Short)
        Me.dynamicDotNetTwain.Name = "dynamicDotNetTwain"
        Me.dynamicDotNetTwain.PDFMarginBottom = CType(0UI, UInteger)
        Me.dynamicDotNetTwain.PDFMarginLeft = CType(0UI, UInteger)
        Me.dynamicDotNetTwain.PDFMarginRight = CType(0UI, UInteger)
        Me.dynamicDotNetTwain.PDFMarginTop = CType(0UI, UInteger)
        Me.dynamicDotNetTwain.PDFXConformance = CType(0UI, UInteger)
        Me.dynamicDotNetTwain.Size = New System.Drawing.Size(221, 295)
        Me.dynamicDotNetTwain.TabIndex = 0
        '
        'Form1
        '
        Me.ClientSize = New System.Drawing.Size(632, 339)
        Me.Controls.Add(Me.cmdRemove)
        Me.Controls.Add(Me.cmdSave)
        Me.Controls.Add(Me.cmdScan)
        Me.Controls.Add(Me.frmSaveImage)
        Me.Controls.Add(Me.frmGetImagelayoutvalues)
        Me.Controls.Add(Me.frmGetImageValues)
        Me.Controls.Add(Me.frmView)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "Form1"
        Me.Text = "Show Image Info and Save Scanned Images"
        Me.frmSaveImage.ResumeLayout(False)
        Me.frmSaveImage.PerformLayout()
        Me.frmGetImagelayoutvalues.ResumeLayout(False)
        Me.frmGetImagelayoutvalues.PerformLayout()
        Me.frmGetImageValues.ResumeLayout(False)
        Me.frmGetImageValues.PerformLayout()
        Me.frmView.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Public WithEvents cmdRemove As System.Windows.Forms.Button
    Public WithEvents cmdSave As System.Windows.Forms.Button
    Public WithEvents cmdScan As System.Windows.Forms.Button
    Public WithEvents frmSaveImage As System.Windows.Forms.GroupBox
    Public WithEvents optPDF As System.Windows.Forms.RadioButton
    Public WithEvents optTIFF As System.Windows.Forms.RadioButton
    Public WithEvents optPNG As System.Windows.Forms.RadioButton
    Public WithEvents optJPEG As System.Windows.Forms.RadioButton
    Public WithEvents optBMP As System.Windows.Forms.RadioButton
    Public WithEvents chkMultiPageTIFF As System.Windows.Forms.CheckBox
    Public WithEvents chkMultiPagePDF As System.Windows.Forms.CheckBox
    Public WithEvents txtFileSize As System.Windows.Forms.TextBox
    Public WithEvents lblFileSize As System.Windows.Forms.Label
    Public WithEvents frmGetImagelayoutvalues As System.Windows.Forms.GroupBox
    Public WithEvents txtImageLayoutFrameNumber As System.Windows.Forms.TextBox
    Public WithEvents txtImageLayoutPageNumber As System.Windows.Forms.TextBox
    Public WithEvents txtImageLayoutDocumentNumber As System.Windows.Forms.TextBox
    Public WithEvents txtImageLayoutFrameBottom As System.Windows.Forms.TextBox
    Public WithEvents txtImageLayoutFrameRight As System.Windows.Forms.TextBox
    Public WithEvents txtImageLayoutFrameTop As System.Windows.Forms.TextBox
    Public WithEvents txtImageLayoutFrameLeft As System.Windows.Forms.TextBox
    Public WithEvents lblImageLayoutFrameNumber As System.Windows.Forms.Label
    Public WithEvents lblImageLayoutDocumentNumber As System.Windows.Forms.Label
    Public WithEvents lblImageLayoutFrameRight As System.Windows.Forms.Label
    Public WithEvents lblImageLayoutFrameLeft As System.Windows.Forms.Label
    Public WithEvents lblImageLayoutPageNumber As System.Windows.Forms.Label
    Public WithEvents lblImageLayoutFrameBottom As System.Windows.Forms.Label
    Public WithEvents lblImageLayoutFrameTop As System.Windows.Forms.Label
    Public WithEvents frmGetImageValues As System.Windows.Forms.GroupBox
    Public WithEvents txtImageXResolution As System.Windows.Forms.TextBox
    Public WithEvents txtImageWidth As System.Windows.Forms.TextBox
    Public WithEvents txtImageBitsPerPixel As System.Windows.Forms.TextBox
    Public WithEvents txtImagePixelType As System.Windows.Forms.TextBox
    Public WithEvents txtImageYResolution As System.Windows.Forms.TextBox
    Public WithEvents txtImageLength As System.Windows.Forms.TextBox
    Public WithEvents lblImageYResolution As System.Windows.Forms.Label
    Public WithEvents lblImageLength As System.Windows.Forms.Label
    Public WithEvents lblImageXResolution As System.Windows.Forms.Label
    Public WithEvents lblImageWidth As System.Windows.Forms.Label
    Public WithEvents lblImageBitsPerPixel As System.Windows.Forms.Label
    Public WithEvents lblImagePixelType As System.Windows.Forms.Label
    Public WithEvents frmView As System.Windows.Forms.GroupBox
    Public WithEvents dlgFileSaveSave As System.Windows.Forms.SaveFileDialog
    Friend WithEvents dynamicDotNetTwain As Dynamsoft.DotNet.TWAIN.DynamicDotNetTwain

#End Region
    '======================================================
    ' Sub Name: GetImageSize()
    ' Sub Description: Get image size with specified type
    ' Input Parameters: NULL
    ' Return: Current image size
    ' Steps: NULL
    ' Comment: NULL
    '======================================================
    Function GetImageSize() As String

        If (dynamicDotNetTwain.HowManyImagesInBuffer <> 0) Then
            GetImageSize = CStr(dynamicDotNetTwain.GetImageSizeWithSpecifiedType(dynamicDotNetTwain.CurrentImageIndexInBuffer, sImageType))
        End If

    End Function

    '======================================================
    ' Sub Name: frmShowInfoAndSaveImage_Load()
    ' Sub Description: Initizlize when form is loaded
    ' Input Parameters: NULL
    ' Return: NULL
    ' Steps: NULL
    ' Comment: NULL
    '======================================================
    Private Sub frmShowInfoAndSaveImage_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        optBMP.Checked = True
        sImageType = Dynamsoft.DotNet.TWAIN.Enums.DWTImageFileFormat.WEBTW_BMP
        chkMultiPageTIFF.Enabled = False
        chkMultiPagePDF.Enabled = False

    End Sub

    Private Sub txtImageXResolution_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtImageXResolution.TextChanged

    End Sub

    Private Sub txtFileSize_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFileSize.TextChanged

    End Sub

    '======================================================
    ' Sub Name: cmdScan_Click()
    ' Sub Description: Acquire images
    ' Input Parameters: NULL
    ' Return: NULL
    ' Steps: NULL
    ' Comment: NULL
    '======================================================
    Private Sub cmdScan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdScan.Click
        dynamicDotNetTwain.IfDisableSourceAfterAcquire = True
        If dynamicDotNetTwain.SelectSource() Then
            dynamicDotNetTwain.AcquireImage()
        End If
    End Sub

    '======================================================
    ' Sub Name: cmdRemove_Click()
    ' Sub Description: Remove current image
    ' Input Parameters: NULL
    ' Return: NULL
    ' Steps: NULL
    ' Comment: NULL
    '======================================================
    Private Sub cmdRemove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRemove.Click

        dynamicDotNetTwain.RemoveImage(dynamicDotNetTwain.CurrentImageIndexInBuffer)
        cmdScan.Enabled = True

    End Sub

    '======================================================
    ' Sub Name: cmdSave_Click()
    ' Sub Description: Save image(s)
    ' Input Parameters: NULL
    ' Return: NULL
    ' Steps: NULL
    ' Comment: NULL
    '======================================================
    Private Sub cmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSave.Click

        If Me.dynamicDotNetTwain.HowManyImagesInBuffer > 0 Then
            Dim strFile As String 'The file name use to save the acquired image

            If (optBMP.Checked = True) Then
                dlgFileSaveSave.Filter = "BMP File (*.bmp)|*.bmp"
            ElseIf (optJPEG.Checked = True) Then
                dlgFileSaveSave.Filter = "JPEG File (*.jpg)|*.jpg"
            ElseIf (optPNG.Checked = True) Then
                dlgFileSaveSave.Filter = "PNG File (*.png)|*.png"
            ElseIf (optTIFF.Checked = True) Then
                dlgFileSaveSave.Filter = "TIFF File (*.tif)|*.tif"
            Else
                dlgFileSaveSave.Filter = "PDF File (*.pdf)|*.pdf"
            End If

            dlgFileSaveSave.InitialDirectory = CurDir()
            dlgFileSaveSave.FileName = ""
            If (dlgFileSaveSave.ShowDialog() = DialogResult.OK) Then
                strFile = dlgFileSaveSave.FileName
                If (optBMP.Checked = True) Then
                    dynamicDotNetTwain.SaveAsBMP(strFile, dynamicDotNetTwain.CurrentImageIndexInBuffer)

                ElseIf (optJPEG.Checked = True) Then
                    dynamicDotNetTwain.SaveAsJPEG(strFile, dynamicDotNetTwain.CurrentImageIndexInBuffer)

                ElseIf (optPNG.Checked = True) Then
                    dynamicDotNetTwain.SaveAsPNG(strFile, dynamicDotNetTwain.CurrentImageIndexInBuffer)

                ElseIf (optTIFF.Checked = True) Then
                    If (chkMultiPageTIFF.CheckState = 1) Then
                        dynamicDotNetTwain.SaveAllAsMultiPageTIFF(strFile)
                    Else
                        dynamicDotNetTwain.SaveAsTIFF(strFile, dynamicDotNetTwain.CurrentImageIndexInBuffer)
                    End If
                Else
                    dynamicDotNetTwain.IfSaveAnnotations = True
                    If (chkMultiPagePDF.CheckState = 1) Then
                        dynamicDotNetTwain.SaveAllAsPDF(strFile)
                    Else
                        dynamicDotNetTwain.SaveAsPDF(strFile, dynamicDotNetTwain.CurrentImageIndexInBuffer)
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub frmGetImagelayoutvalues_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles frmGetImagelayoutvalues.Enter

    End Sub

    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    '''''''''''''''''dynamicDotNetTwain Event Group''''''''''''''''''''''
    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    Private Sub dynamicDotNetTwain_OnPostTransfer() Handles dynamicDotNetTwain.OnPostTransfer
        'The image information is valid only in OnPreTransfer and OnPostTransfer event
        If (dynamicDotNetTwain.HowManyImagesInBuffer >= dynamicDotNetTwain.MaxImagesInBuffer) Then
            cmdScan.Enabled = False
        End If
    End Sub

    Private Sub ShowImageInfo()
        txtImageXResolution.Text = CStr(dynamicDotNetTwain.ImageXResolution)
        txtImageYResolution.Text = CStr(dynamicDotNetTwain.ImageYResolution)
        txtImageWidth.Text = CStr(dynamicDotNetTwain.ImageWidth)
        txtImageLength.Text = CStr(dynamicDotNetTwain.ImageLength)
        txtImageBitsPerPixel.Text = CStr(dynamicDotNetTwain.ImageBitsPerPixel)
        txtImagePixelType.Text = CStr(dynamicDotNetTwain.ImagePixelType)

        txtImageLayoutFrameLeft.Text = CStr(dynamicDotNetTwain.ImageLayoutFrameLeft)
        txtImageLayoutFrameTop.Text = CStr(dynamicDotNetTwain.ImageLayoutFrameTop)
        txtImageLayoutFrameRight.Text = CStr(dynamicDotNetTwain.ImageLayoutFrameRight)
        txtImageLayoutFrameBottom.Text = CStr(dynamicDotNetTwain.ImageLayoutFrameBottom)
        txtImageLayoutDocumentNumber.Text = CStr(dynamicDotNetTwain.ImageLayoutDocumentNumber)
        txtImageLayoutPageNumber.Text = CStr(dynamicDotNetTwain.ImageLayoutPageNumber)
        txtImageLayoutFrameNumber.Text = CStr(dynamicDotNetTwain.ImageLayoutFrameNumber)

        txtFileSize.Text = GetImageSize()

    End Sub


    Private Sub dynamicDotNetTwain_OnMouseClick(ByVal sImageIndex As System.Int16) Handles dynamicDotNetTwain.OnMouseClick
        dynamicDotNetTwain.CurrentImageIndexInBuffer = sImageIndex

        'The image information is valid only in OnPreTransfer and OnPostTransfer event
        txtImageXResolution.Text = ""
        txtImageYResolution.Text = ""
        txtImageWidth.Text = ""
        txtImageLength.Text = ""
        txtImageBitsPerPixel.Text = ""
        txtImagePixelType.Text = ""

        txtImageLayoutFrameLeft.Text = ""
        txtImageLayoutFrameTop.Text = ""
        txtImageLayoutFrameRight.Text = ""
        txtImageLayoutFrameBottom.Text = ""
        txtImageLayoutDocumentNumber.Text = ""
        txtImageLayoutPageNumber.Text = ""
        txtImageLayoutFrameNumber.Text = ""
        'The image information is valid only in OnPreTransfer and OnPostTransfer event

        txtFileSize.Text = GetImageSize()
    End Sub


    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    '''''''''''''''Image Format Select Group'''''''''''''''''''
    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    'UPGRADE_WARNING: Event optBMP.CheckedChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
    Private Sub optBMP_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optBMP.CheckedChanged
        If sender.Checked Then

            chkMultiPagePDF.Enabled = False
            chkMultiPagePDF.CheckState = False
            chkMultiPageTIFF.Enabled = False
            chkMultiPageTIFF.CheckState = False
            sImageType = Dynamsoft.DotNet.TWAIN.Enums.DWTImageFileFormat.WEBTW_BMP
            txtFileSize.Text = GetImageSize()

        End If
    End Sub

    'UPGRADE_WARNING: Event optJPEG.CheckedChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
    Private Sub optJPEG_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optJPEG.CheckedChanged
        If sender.Checked Then

            chkMultiPagePDF.Enabled = False
            chkMultiPagePDF.CheckState = False
            chkMultiPageTIFF.Enabled = False
            chkMultiPageTIFF.CheckState = False
            sImageType = Dynamsoft.DotNet.TWAIN.Enums.DWTImageFileFormat.WEBTW_JPG
            txtFileSize.Text = GetImageSize()

        End If
    End Sub

    'UPGRADE_WARNING: Event optPNG.CheckedChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
    Private Sub optPNG_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optPNG.CheckedChanged
        If sender.Checked Then

            chkMultiPagePDF.Enabled = False
            chkMultiPagePDF.CheckState = False
            chkMultiPageTIFF.Enabled = False
            chkMultiPageTIFF.CheckState = False
            sImageType = Dynamsoft.DotNet.TWAIN.Enums.DWTImageFileFormat.WEBTW_PNG
            txtFileSize.Text = GetImageSize()

        End If
    End Sub

    'UPGRADE_WARNING: Event optPDF.CheckedChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
    Private Sub optPDF_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optPDF.CheckedChanged
        If sender.Checked Then

            chkMultiPagePDF.Enabled = True
            chkMultiPageTIFF.Enabled = False
            chkMultiPageTIFF.CheckState = False
            sImageType = Dynamsoft.DotNet.TWAIN.Enums.DWTImageFileFormat.WEBTW_PDF
            txtFileSize.Text = GetImageSize()

        End If
    End Sub

    'UPGRADE_WARNING: Event optTIFF.CheckedChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
    Private Sub optTIFF_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optTIFF.CheckedChanged
        If sender.Checked Then

            chkMultiPageTIFF.Enabled = True
            chkMultiPagePDF.Enabled = False
            chkMultiPagePDF.CheckState = False
            sImageType = Dynamsoft.DotNet.TWAIN.Enums.DWTImageFileFormat.WEBTW_TIF
            txtFileSize.Text = GetImageSize()

        End If
    End Sub



    Private Sub dynamicDotNetTwain_OnPostAllTransfers() Handles dynamicDotNetTwain.OnPostAllTransfers
        ShowImageInfo()
    End Sub

    Private Sub dynamicDotNetTwain_OnTopImageInTheViewChanged(ByVal sImageIndex As System.Int16) Handles dynamicDotNetTwain.OnTopImageInTheViewChanged
        ShowImageInfo()
    End Sub
End Class
