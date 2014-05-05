Public Class Form1
    Inherits System.Windows.Forms.Form


#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

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

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
   Private Sub InitializeComponent()
        Me.frmCustomScan = New System.Windows.Forms.GroupBox
        Me.chkDuplex = New System.Windows.Forms.CheckBox
        Me.chkIfUseADF = New System.Windows.Forms.CheckBox
        Me.chkIfShowUI = New System.Windows.Forms.CheckBox
        Me.cmbResolution = New System.Windows.Forms.ComboBox
        Me.cmbSource = New System.Windows.Forms.ComboBox
        Me.frmPixelType = New System.Windows.Forms.GroupBox
        Me.optRGB = New System.Windows.Forms.RadioButton
        Me.optGray = New System.Windows.Forms.RadioButton
        Me.optBW = New System.Windows.Forms.RadioButton
        Me.lblResolution = New System.Windows.Forms.Label
        Me.lblSelectSource = New System.Windows.Forms.Label
        Me.cmdScan = New System.Windows.Forms.Button
        Me.cmdInsert = New System.Windows.Forms.Button
        Me.frmErrorString = New System.Windows.Forms.GroupBox
        Me.txtErrorString = New System.Windows.Forms.TextBox
        Me.frmView = New System.Windows.Forms.GroupBox
        Me.dynamicDotNetTwain = New Dynamsoft.DotNet.TWAIN.DynamicDotNetTwain
        Me.frmCustomScan.SuspendLayout()
        Me.frmPixelType.SuspendLayout()
        Me.frmErrorString.SuspendLayout()
        Me.frmView.SuspendLayout()
        Me.SuspendLayout()
        '
        'frmCustomScan
        '
        Me.frmCustomScan.BackColor = System.Drawing.SystemColors.Control
        Me.frmCustomScan.Controls.Add(Me.chkDuplex)
        Me.frmCustomScan.Controls.Add(Me.chkIfUseADF)
        Me.frmCustomScan.Controls.Add(Me.chkIfShowUI)
        Me.frmCustomScan.Controls.Add(Me.cmbResolution)
        Me.frmCustomScan.Controls.Add(Me.cmbSource)
        Me.frmCustomScan.Controls.Add(Me.frmPixelType)
        Me.frmCustomScan.Controls.Add(Me.lblResolution)
        Me.frmCustomScan.Controls.Add(Me.lblSelectSource)
        Me.frmCustomScan.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.frmCustomScan.ForeColor = System.Drawing.SystemColors.ControlText
        Me.frmCustomScan.Location = New System.Drawing.Point(323, 6)
        Me.frmCustomScan.Name = "frmCustomScan"
        Me.frmCustomScan.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.frmCustomScan.Size = New System.Drawing.Size(273, 171)
        Me.frmCustomScan.TabIndex = 4
        Me.frmCustomScan.TabStop = False
        Me.frmCustomScan.Text = "Custom Scan"
        '
        'chkDuplex
        '
        Me.chkDuplex.BackColor = System.Drawing.SystemColors.Control
        Me.chkDuplex.Cursor = System.Windows.Forms.Cursors.Default
        Me.chkDuplex.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkDuplex.ForeColor = System.Drawing.SystemColors.ControlText
        Me.chkDuplex.Location = New System.Drawing.Point(176, 140)
        Me.chkDuplex.Name = "chkDuplex"
        Me.chkDuplex.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.chkDuplex.Size = New System.Drawing.Size(89, 16)
        Me.chkDuplex.TabIndex = 13
        Me.chkDuplex.Text = "Duplex Scan"
        Me.chkDuplex.UseVisualStyleBackColor = False
        '
        'chkIfUseADF
        '
        Me.chkIfUseADF.BackColor = System.Drawing.SystemColors.Control
        Me.chkIfUseADF.Cursor = System.Windows.Forms.Cursors.Default
        Me.chkIfUseADF.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkIfUseADF.ForeColor = System.Drawing.SystemColors.ControlText
        Me.chkIfUseADF.Location = New System.Drawing.Point(96, 140)
        Me.chkIfUseADF.Name = "chkIfUseADF"
        Me.chkIfUseADF.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.chkIfUseADF.Size = New System.Drawing.Size(73, 16)
        Me.chkIfUseADF.TabIndex = 12
        Me.chkIfUseADF.Text = "Use ADF"
        Me.chkIfUseADF.UseVisualStyleBackColor = False
        '
        'chkIfShowUI
        '
        Me.chkIfShowUI.BackColor = System.Drawing.SystemColors.Control
        Me.chkIfShowUI.Cursor = System.Windows.Forms.Cursors.Default
        Me.chkIfShowUI.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkIfShowUI.ForeColor = System.Drawing.SystemColors.ControlText
        Me.chkIfShowUI.Location = New System.Drawing.Point(16, 140)
        Me.chkIfShowUI.Name = "chkIfShowUI"
        Me.chkIfShowUI.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.chkIfShowUI.Size = New System.Drawing.Size(81, 16)
        Me.chkIfShowUI.TabIndex = 11
        Me.chkIfShowUI.Text = "Show UI"
        Me.chkIfShowUI.UseVisualStyleBackColor = False
        '
        'cmbResolution
        '
        Me.cmbResolution.BackColor = System.Drawing.SystemColors.Window
        Me.cmbResolution.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmbResolution.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbResolution.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbResolution.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cmbResolution.Location = New System.Drawing.Point(96, 111)
        Me.cmbResolution.Name = "cmbResolution"
        Me.cmbResolution.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmbResolution.Size = New System.Drawing.Size(161, 22)
        Me.cmbResolution.TabIndex = 10
        '
        'cmbSource
        '
        Me.cmbSource.BackColor = System.Drawing.SystemColors.Window
        Me.cmbSource.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmbSource.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbSource.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbSource.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cmbSource.Location = New System.Drawing.Point(96, 22)
        Me.cmbSource.Name = "cmbSource"
        Me.cmbSource.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmbSource.Size = New System.Drawing.Size(161, 22)
        Me.cmbSource.TabIndex = 9
        '
        'frmPixelType
        '
        Me.frmPixelType.BackColor = System.Drawing.SystemColors.Control
        Me.frmPixelType.Controls.Add(Me.optRGB)
        Me.frmPixelType.Controls.Add(Me.optGray)
        Me.frmPixelType.Controls.Add(Me.optBW)
        Me.frmPixelType.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.frmPixelType.ForeColor = System.Drawing.SystemColors.ControlText
        Me.frmPixelType.Location = New System.Drawing.Point(16, 52)
        Me.frmPixelType.Name = "frmPixelType"
        Me.frmPixelType.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.frmPixelType.Size = New System.Drawing.Size(241, 45)
        Me.frmPixelType.TabIndex = 8
        Me.frmPixelType.TabStop = False
        Me.frmPixelType.Text = "Pixel Type && Bit Depth"
        '
        'optRGB
        '
        Me.optRGB.BackColor = System.Drawing.SystemColors.Control
        Me.optRGB.Cursor = System.Windows.Forms.Cursors.Default
        Me.optRGB.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.optRGB.ForeColor = System.Drawing.SystemColors.ControlText
        Me.optRGB.Location = New System.Drawing.Point(162, 22)
        Me.optRGB.Name = "optRGB"
        Me.optRGB.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.optRGB.Size = New System.Drawing.Size(77, 16)
        Me.optRGB.TabIndex = 16
        Me.optRGB.TabStop = True
        Me.optRGB.Text = "24-bit RGB"
        Me.optRGB.UseVisualStyleBackColor = False
        '
        'optGray
        '
        Me.optGray.BackColor = System.Drawing.SystemColors.Control
        Me.optGray.Cursor = System.Windows.Forms.Cursors.Default
        Me.optGray.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.optGray.ForeColor = System.Drawing.SystemColors.ControlText
        Me.optGray.Location = New System.Drawing.Point(78, 22)
        Me.optGray.Name = "optGray"
        Me.optGray.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.optGray.Size = New System.Drawing.Size(74, 16)
        Me.optGray.TabIndex = 15
        Me.optGray.TabStop = True
        Me.optGray.Text = "8-bit Gray"
        Me.optGray.UseVisualStyleBackColor = False
        '
        'optBW
        '
        Me.optBW.BackColor = System.Drawing.SystemColors.Control
        Me.optBW.Cursor = System.Windows.Forms.Cursors.Default
        Me.optBW.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.optBW.ForeColor = System.Drawing.SystemColors.ControlText
        Me.optBW.Location = New System.Drawing.Point(2, 22)
        Me.optBW.Name = "optBW"
        Me.optBW.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.optBW.Size = New System.Drawing.Size(70, 16)
        Me.optBW.TabIndex = 14
        Me.optBW.TabStop = True
        Me.optBW.Text = "1-bit BW"
        Me.optBW.UseVisualStyleBackColor = False
        '
        'lblResolution
        '
        Me.lblResolution.BackColor = System.Drawing.SystemColors.Control
        Me.lblResolution.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblResolution.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblResolution.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblResolution.Location = New System.Drawing.Point(16, 113)
        Me.lblResolution.Name = "lblResolution"
        Me.lblResolution.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblResolution.Size = New System.Drawing.Size(65, 16)
        Me.lblResolution.TabIndex = 5
        Me.lblResolution.Text = "Resolution"
        '
        'lblSelectSource
        '
        Me.lblSelectSource.BackColor = System.Drawing.SystemColors.Control
        Me.lblSelectSource.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblSelectSource.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSelectSource.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblSelectSource.Location = New System.Drawing.Point(16, 26)
        Me.lblSelectSource.Name = "lblSelectSource"
        Me.lblSelectSource.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblSelectSource.Size = New System.Drawing.Size(81, 12)
        Me.lblSelectSource.TabIndex = 4
        Me.lblSelectSource.Text = "Select Source"
        '
        'cmdScan
        '
        Me.cmdScan.BackColor = System.Drawing.SystemColors.Control
        Me.cmdScan.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdScan.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdScan.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdScan.Location = New System.Drawing.Point(371, 184)
        Me.cmdScan.Name = "cmdScan"
        Me.cmdScan.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdScan.Size = New System.Drawing.Size(81, 23)
        Me.cmdScan.TabIndex = 7
        Me.cmdScan.Text = "Scan"
        Me.cmdScan.UseVisualStyleBackColor = False
        '
        'cmdInsert
        '
        Me.cmdInsert.BackColor = System.Drawing.SystemColors.Control
        Me.cmdInsert.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdInsert.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdInsert.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdInsert.Location = New System.Drawing.Point(471, 184)
        Me.cmdInsert.Name = "cmdInsert"
        Me.cmdInsert.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdInsert.Size = New System.Drawing.Size(89, 23)
        Me.cmdInsert.TabIndex = 8
        Me.cmdInsert.Text = "Insert"
        Me.cmdInsert.UseVisualStyleBackColor = False
        '
        'frmErrorString
        '
        Me.frmErrorString.BackColor = System.Drawing.SystemColors.Control
        Me.frmErrorString.Controls.Add(Me.txtErrorString)
        Me.frmErrorString.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.frmErrorString.ForeColor = System.Drawing.SystemColors.ControlText
        Me.frmErrorString.Location = New System.Drawing.Point(323, 212)
        Me.frmErrorString.Name = "frmErrorString"
        Me.frmErrorString.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.frmErrorString.Size = New System.Drawing.Size(273, 126)
        Me.frmErrorString.TabIndex = 9
        Me.frmErrorString.TabStop = False
        Me.frmErrorString.Text = "Error String"
        '
        'txtErrorString
        '
        Me.txtErrorString.AcceptsReturn = True
        Me.txtErrorString.BackColor = System.Drawing.SystemColors.Window
        Me.txtErrorString.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtErrorString.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtErrorString.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtErrorString.Location = New System.Drawing.Point(10, 17)
        Me.txtErrorString.MaxLength = 0
        Me.txtErrorString.Multiline = True
        Me.txtErrorString.Name = "txtErrorString"
        Me.txtErrorString.ReadOnly = True
        Me.txtErrorString.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtErrorString.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtErrorString.Size = New System.Drawing.Size(257, 105)
        Me.txtErrorString.TabIndex = 1
        '
        'frmView
        '
        Me.frmView.BackColor = System.Drawing.SystemColors.Control
        Me.frmView.Controls.Add(Me.dynamicDotNetTwain)
        Me.frmView.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.frmView.ForeColor = System.Drawing.SystemColors.ControlText
        Me.frmView.Location = New System.Drawing.Point(12, 6)
        Me.frmView.Name = "frmView"
        Me.frmView.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.frmView.Size = New System.Drawing.Size(305, 333)
        Me.frmView.TabIndex = 10
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
        Me.dynamicDotNetTwain.Location = New System.Drawing.Point(6, 13)
        Me.dynamicDotNetTwain.LogLevel = CType(0, Short)
        Me.dynamicDotNetTwain.Name = "dynamicDotNetTwain"
        Me.dynamicDotNetTwain.PDFMarginBottom = CType(0UI, UInteger)
        Me.dynamicDotNetTwain.PDFMarginLeft = CType(0UI, UInteger)
        Me.dynamicDotNetTwain.PDFMarginRight = CType(0UI, UInteger)
        Me.dynamicDotNetTwain.PDFMarginTop = CType(0UI, UInteger)
        Me.dynamicDotNetTwain.Size = New System.Drawing.Size(293, 315)
        Me.dynamicDotNetTwain.TabIndex = 0
        '
        'Form1
        '
        Me.ClientSize = New System.Drawing.Size(600, 346)
        Me.Controls.Add(Me.frmView)
        Me.Controls.Add(Me.frmErrorString)
        Me.Controls.Add(Me.cmdInsert)
        Me.Controls.Add(Me.cmdScan)
        Me.Controls.Add(Me.frmCustomScan)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "Form1"
        Me.Text = "Customize Scan"
        Me.frmCustomScan.ResumeLayout(False)
        Me.frmPixelType.ResumeLayout(False)
        Me.frmErrorString.ResumeLayout(False)
        Me.frmErrorString.PerformLayout()
        Me.frmView.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Public WithEvents frmCustomScan As System.Windows.Forms.GroupBox
    Public WithEvents chkDuplex As System.Windows.Forms.CheckBox
    Public WithEvents chkIfUseADF As System.Windows.Forms.CheckBox
    Public WithEvents chkIfShowUI As System.Windows.Forms.CheckBox
    Public WithEvents cmbResolution As System.Windows.Forms.ComboBox
    Public WithEvents cmbSource As System.Windows.Forms.ComboBox
    Public WithEvents frmPixelType As System.Windows.Forms.GroupBox
    Public WithEvents optRGB As System.Windows.Forms.RadioButton
    Public WithEvents optGray As System.Windows.Forms.RadioButton
    Public WithEvents optBW As System.Windows.Forms.RadioButton
    Public WithEvents lblResolution As System.Windows.Forms.Label
    Public WithEvents lblSelectSource As System.Windows.Forms.Label
    Public WithEvents cmdScan As System.Windows.Forms.Button
    Public WithEvents cmdInsert As System.Windows.Forms.Button
    Public WithEvents frmErrorString As System.Windows.Forms.GroupBox
    Public WithEvents txtErrorString As System.Windows.Forms.TextBox
    Public WithEvents frmView As System.Windows.Forms.GroupBox
    Friend WithEvents dynamicDotNetTwain As Dynamsoft.DotNet.TWAIN.DynamicDotNetTwain
#End Region

    '/////////////////////////////////////////////////////////////////////////////////////
    ' Copyright (c)     :Dynamsoft Corporation
    ' File Name         :frmCustomizeScan.frm
    ' Description       :Example of customizing scan
    '///////////////////////////////////////////////////////////////////////////////////////////
    Dim bNotSupportDuplex As Boolean

    Private Sub IfInsertEnable()

        If (dynamicDotNetTwain.HowManyImagesInBuffer = 0) Then
            cmdInsert.Enabled = False
        Else
            cmdInsert.Enabled = True
        End If

    End Sub
    'Private Sub GroupBox1_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox1.Enter

    'End Sub
    'Private Sub AxDynamicdynamicDotNetTwain1_OnPostTransfer(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AxDynamicdynamicDotNetTwain1.OnPostTransfer

    'End Sub
    '======================================================
    ' Sub Name: Form1_Load()
    ' Sub Description: Initizlize when form is loaded
    ' Input Parameters: NULL
    ' Return: NULL
    ' Steps: NULL
    ' Comment: NULL
    '======================================================
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        bNotSupportDuplex = False

        Dim lngNum As Integer 'For loop

        dynamicDotNetTwain.OpenSourceManager()

        'Initizlize the cmbSource control.
        For lngNum = 0 To dynamicDotNetTwain.SourceCount - 1
            cmbSource.Items.Insert(lngNum, dynamicDotNetTwain.SourceNameItems(lngNum))

            'if there is Current Source, highlight it, else hightlight the default source
            If (dynamicDotNetTwain.SourceNameItems(lngNum) = dynamicDotNetTwain.CurrentSourceName) Or (dynamicDotNetTwain.CurrentSourceName = "" And dynamicDotNetTwain.SourceNameItems(lngNum) = dynamicDotNetTwain.DefaultSourceName) Then
                cmbSource.SelectedIndex = lngNum
            End If
        Next

        'Initizlize the cmbResolution control
        cmbResolution.Items.Insert(0, "100")
        cmbResolution.Items.Insert(1, "150")
        cmbResolution.Items.Insert(2, "200")
        cmbResolution.Items.Insert(3, "300")

        cmbResolution.SelectedIndex = 0

        'Initizlize Pixel Type
        optGray.Checked = True

        dynamicDotNetTwain.IfThrowException = True

        IfInsertEnable()

        CreateContextMenu()

    End Sub
    '======================================================
    ' Sub Name: AcquireImage()
    ' Sub Description: Acquire images
    ' Input Parameters: NULL
    ' Return: NULL
    ' Steps: NULL
    ' Comment: NULL
    '======================================================
    Private Sub AcquireImage()
        Try
            dynamicDotNetTwain.SelectSourceByIndex(cmbSource.SelectedIndex)
            dynamicDotNetTwain.IfShowUI = chkIfShowUI.CheckState
            dynamicDotNetTwain.OpenSource()
            dynamicDotNetTwain.IfDisableSourceAfterAcquire = True

            'Set Pixel Type and Bit Depth
            If (optBW.Checked = True) Then
                dynamicDotNetTwain.PixelType = 0
                dynamicDotNetTwain.BitDepth = 1
            ElseIf (optGray.Checked = True) Then
                dynamicDotNetTwain.PixelType = 1
                dynamicDotNetTwain.BitDepth = 8
            Else
                dynamicDotNetTwain.PixelType = 2
                dynamicDotNetTwain.BitDepth = 24
            End If

            'Set Resolution
            If (cmbResolution.SelectedIndex = 0) Then
                dynamicDotNetTwain.Resolution = 100
            ElseIf (cmbResolution.SelectedIndex = 1) Then
                dynamicDotNetTwain.Resolution = 150
            ElseIf (cmbResolution.SelectedIndex = 2) Then
                dynamicDotNetTwain.Resolution = 200
            Else
                dynamicDotNetTwain.Resolution = 300
            End If

            'Check if resolution is set successfully
            If (dynamicDotNetTwain.Resolution <> CInt(cmbResolution.Text)) Then
                txtErrorString.Text = "Fail to set resolution." & vbCrLf & "Current source does not support the resolution you set." & vbCrLf & txtErrorString.Text
                Exit Sub
            End If

            'Check if show user interface
            dynamicDotNetTwain.IfShowUI = chkIfShowUI.CheckState

            'Check if use ADF
            dynamicDotNetTwain.IfFeederEnabled = chkIfUseADF.CheckState
            dynamicDotNetTwain.IfAutoFeed = chkIfUseADF.CheckState

            If (bNotSupportDuplex = False) Then
                dynamicDotNetTwain.IfDuplexEnabled = chkDuplex.CheckState
                'Check if the current source supports duplex scan
                If (dynamicDotNetTwain.Duplex = 0 And chkDuplex.CheckState = 1) Then
                    txtErrorString.Text = "Current source does not support duplex scan." & vbCrLf & txtErrorString.Text
                    chkDuplex.CheckState = False
                    Exit Sub
                End If
            End If

            dynamicDotNetTwain.AcquireImage()
        Catch exp As Dynamsoft.DotNet.TWAIN.TwainException
            Dim errorstr As String
            errorstr = ""
            errorstr += "Error " + exp.Code.ToString() & vbCrLf + "Description: " + exp.Message.ToString() & vbCrLf + "Position: " + exp.TargetSite.ToString() & vbCrLf
            txtErrorString.Text = errorstr + txtErrorString.Text
        End Try
    End Sub
    Private Sub cmdScan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdScan.Click
        dynamicDotNetTwain.IfAppendImage = True
        AcquireImage()
    End Sub
    '======================================================
    ' Sub Name: cmdInsert_Click()
    ' Sub Description: Insert new images before current image
    ' Input Parameters: NULL
    ' Return: NULL
    ' Steps: NULL
    ' Comment: NULL
    '======================================================
    Private Sub cmdInsert_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdInsert.Click

        dynamicDotNetTwain.IfAppendImage = False
        AcquireImage()

    End Sub
    '======================================================
    ' Sub Name: dynamicDotNetTwain_OnMouseClick()
    ' Sub Description: Set the image that the mouse click on as the current image
    ' Input Parameters: sImageIndex
    ' Return: NULL
    ' Steps: NULL
    ' Comment: NULL
    '======================================================
    Private Sub dynamicDotNetTwain_OnMouseClick(ByVal sImageIndex As System.Int16) Handles dynamicDotNetTwain.OnMouseClick
        dynamicDotNetTwain.CurrentImageIndexInBuffer = sImageIndex
        IfInsertEnable()
    End Sub

    '======================================================
    ' Sub Name: dynamicDotNetTwain_OnPostAllTransfers()
    ' Sub Description: Fired after a session of scans end
    ' Input Parameters: NULL
    ' Return: NULL
    ' Steps: NULL
    ' Comment: NULL
    '======================================================

    Private Sub dynamicDotNetTwain_OnPostAllTransfers() Handles dynamicDotNetTwain.OnPostAllTransfers
        IfInsertEnable()
    End Sub

    Private Sub CreateContextMenu()
        Dim menu As New ContextMenuStrip()
        Dim menuItemCopy As New ToolStripMenuItem("Copy", Nothing, AddressOf MenuItemClick, Keys.Control Or Keys.C)
        Dim menuItemSelect As New ToolStripMenuItem("Select All", Nothing, AddressOf MenuItemClick, Keys.Control Or Keys.A)
        Dim menuItemClear As New ToolStripMenuItem("Clear", Nothing, AddressOf MenuItemClick, Keys.Control Or Keys.X)
        menu.Items.Add(menuItemCopy)
        menu.Items.Add(menuItemClear)
        menu.Items.Add(New ToolStripSeparator())
        menu.Items.Add(menuItemSelect)
        txtErrorString.ContextMenuStrip = menu
        txtErrorString.ReadOnly = True
    End Sub

    Private Sub MenuItemClick(ByVal sender As Object, ByVal e As EventArgs)
        Dim menuItem As ToolStripMenuItem : menuItem = DirectCast(sender, ToolStripMenuItem)
        If menuItem.Text = "Clear" Then
            txtErrorString.Clear()
        End If
        If menuItem.Text = "Copy" Then
            txtErrorString.Copy()
        End If
        If menuItem.Text = "Select All" Then
            txtErrorString.SelectAll()
        End If
    End Sub

    Private Sub cmbSource_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cmbSource.SelectedIndexChanged
        bNotSupportDuplex = False
        Try
            dynamicDotNetTwain.SelectSourceByIndex(Convert.ToInt16(cmbSource.SelectedIndex))
            dynamicDotNetTwain.OpenSource()
            If dynamicDotNetTwain.Duplex = Dynamsoft.DotNet.TWAIN.Enums.TWICapDuplex.TWDX_NONE Then
                chkDuplex.Checked = False
                chkDuplex.Enabled = False
                bNotSupportDuplex = True
            Else
                chkDuplex.Enabled = True
                bNotSupportDuplex = False
            End If
            dynamicDotNetTwain.CloseSource()
        Catch ex As Exception

        End Try
    End Sub
End Class
