Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
Imports System.Runtime.InteropServices
Imports System.Threading
Imports Dynamsoft.DotNet.TWAIN

    Public Class DotNetTWAINDemo

        ' For move the window
        Dim mouse_offset As System.Drawing.Point
        ' For move the annotation form
        Dim mouse_offset2 As System.Drawing.Point
    Dim currentImageIndex As Integer
    Public Delegate Sub CrossThreadOperationControl()
        Dim isToCrop As Boolean
    Dim infoLabel As Label

    Friend WithEvents RoundedRectanglePanel1 As DotNET_TWAIN_Demo.RoundedRectanglePanel
    Friend WithEvents RoundedRectanglePanel3 As DotNET_TWAIN_Demo.RoundedRectanglePanel
    Friend WithEvents RoundedRectanglePanel2 As DotNET_TWAIN_Demo.RoundedRectanglePanel
    Friend WithEvents RoundedRectanglePanel4 As DotNET_TWAIN_Demo.RoundedRectanglePanel
    Friend WithEvents thLoadImage As DotNET_TWAIN_Demo.TabHead
    Friend WithEvents thAcquireImage As DotNET_TWAIN_Demo.TabHead
    Friend WithEvents thReadBarcode As DotNET_TWAIN_Demo.TabHead
    Friend WithEvents thAddBarcode As DotNET_TWAIN_Demo.TabHead
    Friend WithEvents thOCR As DotNET_TWAIN_Demo.TabHead
    Friend WithEvents thSaveImage As DotNET_TWAIN_Demo.TabHead
    Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        InitializeComponentForCustomControl()
    End Sub

    Private Sub InitializeComponentForCustomControl()
        Me.RoundedRectanglePanel1 = New DotNET_TWAIN_Demo.RoundedRectanglePanel
        Me.RoundedRectanglePanel2 = New DotNET_TWAIN_Demo.RoundedRectanglePanel
        Me.RoundedRectanglePanel3 = New DotNET_TWAIN_Demo.RoundedRectanglePanel
        Me.RoundedRectanglePanel4 = New DotNET_TWAIN_Demo.RoundedRectanglePanel
        Me.thLoadImage = New DotNET_TWAIN_Demo.TabHead
        Me.thAcquireImage = New DotNET_TWAIN_Demo.TabHead
        Me.thReadBarcode = New DotNET_TWAIN_Demo.TabHead
        Me.thAddBarcode = New DotNET_TWAIN_Demo.TabHead
        Me.thOCR = New DotNET_TWAIN_Demo.TabHead
        Me.thSaveImage = New DotNET_TWAIN_Demo.TabHead

        Me.RoundedRectanglePanel1.SuspendLayout()
        Me.RoundedRectanglePanel2.SuspendLayout()
        Me.RoundedRectanglePanel3.SuspendLayout()
        Me.RoundedRectanglePanel4.SuspendLayout()

        '
        'RoundedRectanglePanel1
        '
        Me.RoundedRectanglePanel1.AutoSize = True
        Me.RoundedRectanglePanel1.BackgroundImage = CType(My.Resources.Resources.ResourceManager.GetObject("RoundedRectanglePanel1.BackgroundImage"), System.Drawing.Image)
        Me.RoundedRectanglePanel1.Controls.Add(Me.panelLoad)
        Me.RoundedRectanglePanel1.Controls.Add(Me.panelAcquire)
        Me.RoundedRectanglePanel1.Controls.Add(Me.thLoadImage)
        Me.RoundedRectanglePanel1.Controls.Add(Me.thAcquireImage)
        Me.RoundedRectanglePanel1.Location = New System.Drawing.Point(12, 12)
        Me.RoundedRectanglePanel1.Margin = New System.Windows.Forms.Padding(12, 12, 12, 0)
        Me.RoundedRectanglePanel1.Name = "RoundedRectanglePanel1"
        Me.RoundedRectanglePanel1.Padding = New System.Windows.Forms.Padding(1)
        Me.RoundedRectanglePanel1.Size = New System.Drawing.Size(250, 270)
        Me.RoundedRectanglePanel1.TabIndex = 0
        '
        'RoundedRectanglePanel2
        '
        Me.RoundedRectanglePanel2.AutoSize = True
        Me.RoundedRectanglePanel2.BackgroundImage = CType(My.Resources.Resources.ResourceManager.GetObject("RoundedRectanglePanel2.BackgroundImage"), System.Drawing.Image)
        Me.RoundedRectanglePanel2.Controls.Add(Me.panelAddBarcode)
        Me.RoundedRectanglePanel2.Controls.Add(Me.panelReadBarcode)
        Me.RoundedRectanglePanel2.Controls.Add(Me.thAddBarcode)
        Me.RoundedRectanglePanel2.Controls.Add(Me.thReadBarcode)
        Me.RoundedRectanglePanel2.Location = New System.Drawing.Point(286, 12)
        Me.RoundedRectanglePanel2.Margin = New System.Windows.Forms.Padding(12, 12, 12, 0)
        Me.RoundedRectanglePanel2.Name = "RoundedRectanglePanel2"
        Me.RoundedRectanglePanel2.Padding = New System.Windows.Forms.Padding(1)
        Me.RoundedRectanglePanel2.Size = New System.Drawing.Size(250, 362)
        Me.RoundedRectanglePanel2.TabIndex = 3
        '
        'RoundedRectanglePanel3
        '
        Me.RoundedRectanglePanel3.AutoSize = True
        Me.RoundedRectanglePanel3.BackgroundImage = CType(My.Resources.Resources.ResourceManager.GetObject("RoundedRectanglePanel3.BackgroundImage"), System.Drawing.Image)
        Me.RoundedRectanglePanel3.Controls.Add(Me.panelOCR)
        Me.RoundedRectanglePanel3.Controls.Add(Me.thOCR)
        Me.RoundedRectanglePanel3.Location = New System.Drawing.Point(286, 386)
        Me.RoundedRectanglePanel3.Margin = New System.Windows.Forms.Padding(12, 12, 12, 0)
        Me.RoundedRectanglePanel3.Name = "RoundedRectanglePanel3"
        Me.RoundedRectanglePanel3.Padding = New System.Windows.Forms.Padding(1)
        Me.RoundedRectanglePanel3.Size = New System.Drawing.Size(250, 224)
        Me.RoundedRectanglePanel3.TabIndex = 2
        '
        'RoundedRectanglePanel4
        '
        Me.RoundedRectanglePanel4.AutoSize = True
        Me.RoundedRectanglePanel4.BackgroundImage = CType(My.Resources.Resources.ResourceManager.GetObject("RoundedRectanglePanel4.BackgroundImage"), System.Drawing.Image)
        Me.RoundedRectanglePanel4.Controls.Add(Me.panelSaveImage)
        Me.RoundedRectanglePanel4.Controls.Add(Me.thSaveImage)
        Me.RoundedRectanglePanel4.Location = New System.Drawing.Point(560, 12)
        Me.RoundedRectanglePanel4.Margin = New System.Windows.Forms.Padding(12)
        Me.RoundedRectanglePanel4.Name = "RoundedRectanglePanel4"
        Me.RoundedRectanglePanel4.Padding = New System.Windows.Forms.Padding(1)
        Me.RoundedRectanglePanel4.Size = New System.Drawing.Size(253, 252)
        Me.RoundedRectanglePanel4.TabIndex = 4
        '
        'thLoadImage
        '
        Me.thLoadImage.BackColor = System.Drawing.Color.Transparent
        Me.thLoadImage.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.thLoadImage.Image = CType(My.Resources.Resources.ResourceManager.GetObject("thLoadImage.Image"), System.Drawing.Image)
        Me.thLoadImage.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.thLoadImage.Index = 1
        Me.thLoadImage.Location = New System.Drawing.Point(125, 1)
        Me.thLoadImage.Margin = New System.Windows.Forms.Padding(0)
        Me.thLoadImage.MultiTabHead = True
        Me.thLoadImage.Name = "thLoadImage"
        Me.thLoadImage.Size = New System.Drawing.Size(124, 40)
        Me.thLoadImage.State = DotNET_TWAIN_Demo.TabHead.TabHeadState.FOLDED
        Me.thLoadImage.TabIndex = 1
        Me.thLoadImage.Text = "Load Files"
        Me.thLoadImage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'thAcquireImage
        '
        Me.thAcquireImage.BackColor = System.Drawing.Color.Transparent
        Me.thAcquireImage.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.thAcquireImage.Image = CType(My.Resources.Resources.ResourceManager.GetObject("thAcquireImage.Image"), System.Drawing.Image)
        Me.thAcquireImage.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.thAcquireImage.Index = 0
        Me.thAcquireImage.Location = New System.Drawing.Point(1, 1)
        Me.thAcquireImage.Margin = New System.Windows.Forms.Padding(0)
        Me.thAcquireImage.MultiTabHead = True
        Me.thAcquireImage.Name = "thAcquireImage"
        Me.thAcquireImage.Size = New System.Drawing.Size(124, 40)
        Me.thAcquireImage.State = DotNET_TWAIN_Demo.TabHead.TabHeadState.SELECTED
        Me.thAcquireImage.TabIndex = 0
        Me.thAcquireImage.Text = "Acquire Image"
        Me.thAcquireImage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'thAddBarcode
        '
        Me.thAddBarcode.BackColor = System.Drawing.Color.Transparent
        Me.thAddBarcode.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.thAddBarcode.Image = CType(My.Resources.Resources.ResourceManager.GetObject("thAddBarcode.Image"), System.Drawing.Image)
        Me.thAddBarcode.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.thAddBarcode.Index = 3
        Me.thAddBarcode.Location = New System.Drawing.Point(125, 1)
        Me.thAddBarcode.Margin = New System.Windows.Forms.Padding(0)
        Me.thAddBarcode.MultiTabHead = True
        Me.thAddBarcode.Name = "thAddBarcode"
        Me.thAddBarcode.Size = New System.Drawing.Size(124, 40)
        Me.thAddBarcode.State = DotNET_TWAIN_Demo.TabHead.TabHeadState.ALLFOLDED
        Me.thAddBarcode.TabIndex = 1
        Me.thAddBarcode.Text = "Add Barcode"
        Me.thAddBarcode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'thReadBarcode
        '
        Me.thReadBarcode.BackColor = System.Drawing.Color.Transparent
        Me.thReadBarcode.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.thReadBarcode.Image = CType(My.Resources.Resources.ResourceManager.GetObject("thReadBarcode.Image"), System.Drawing.Image)
        Me.thReadBarcode.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.thReadBarcode.Index = 2
        Me.thReadBarcode.Location = New System.Drawing.Point(1, 1)
        Me.thReadBarcode.Margin = New System.Windows.Forms.Padding(0)
        Me.thReadBarcode.MultiTabHead = True
        Me.thReadBarcode.Name = "thReadBarcode"
        Me.thReadBarcode.Size = New System.Drawing.Size(124, 40)
        Me.thReadBarcode.State = DotNET_TWAIN_Demo.TabHead.TabHeadState.ALLFOLDED
        Me.thReadBarcode.TabIndex = 0
        Me.thReadBarcode.Text = "Read Barcode"
        Me.thReadBarcode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'thOCR
        '
        Me.thOCR.BackColor = System.Drawing.Color.Transparent
        Me.thOCR.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.thOCR.Image = CType(My.Resources.Resources.ResourceManager.GetObject("thOCR.Image"), System.Drawing.Image)
        Me.thOCR.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.thOCR.Index = 4
        Me.thOCR.Location = New System.Drawing.Point(1, 1)
        Me.thOCR.Margin = New System.Windows.Forms.Padding(0)
        Me.thOCR.MultiTabHead = False
        Me.thOCR.Name = "thOCR"
        Me.thOCR.Size = New System.Drawing.Size(248, 40)
        Me.thOCR.State = DotNET_TWAIN_Demo.TabHead.TabHeadState.ALLFOLDED
        Me.thOCR.TabIndex = 0
        Me.thOCR.Text = "OCR"
        Me.thOCR.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'thSaveImage
        '
        Me.thSaveImage.BackColor = System.Drawing.Color.Transparent
        Me.thSaveImage.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.thSaveImage.Image = CType(My.Resources.Resources.ResourceManager.GetObject("thSaveImage.Image"), System.Drawing.Image)
        Me.thSaveImage.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.thSaveImage.Index = 5
        Me.thSaveImage.Location = New System.Drawing.Point(1, 1)
        Me.thSaveImage.MultiTabHead = False
        Me.thSaveImage.Name = "thSaveImage"
        Me.thSaveImage.Size = New System.Drawing.Size(248, 40)
        Me.thSaveImage.State = DotNET_TWAIN_Demo.TabHead.TabHeadState.ALLFOLDED
        Me.thSaveImage.TabIndex = 0
        Me.thSaveImage.Text = "Save Image"
        Me.thSaveImage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter

        Me.RoundedRectanglePanel1.ResumeLayout(False)
        Me.RoundedRectanglePanel2.ResumeLayout(False)
        Me.RoundedRectanglePanel3.ResumeLayout(False)
        Me.RoundedRectanglePanel4.ResumeLayout(False)

        Me.flowLayoutPanel1.Controls.Add(Me.RoundedRectanglePanel1)
        Me.flowLayoutPanel1.Controls.Add(Me.RoundedRectanglePanel2)
        Me.flowLayoutPanel1.Controls.Add(Me.RoundedRectanglePanel3)
        Me.flowLayoutPanel1.Controls.Add(Me.RoundedRectanglePanel4)
    End Sub

    Private Sub DotNetTWAINDemo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        currentImageIndex = -1
        isToCrop = False

        InitUI()
        Initialization()
        InitDefaultValueForTWAIN()
    End Sub

    Private Sub Initialization()
        Dim strPDFDllFolder As String : strPDFDllFolder = Nothing
        Dim strBarcodeDllFolder As String : strBarcodeDllFolder = Nothing
        Dim strOCRDllFolder As String : strOCRDllFolder = Nothing
        Dim strOCRTessDataFolder As String : strOCRTessDataFolder = Nothing
        Dim strAddOnDllFolder As String : strAddOnDllFolder = Application.ExecutablePath
        strAddOnDllFolder = strAddOnDllFolder.Replace("/", "\")
        If Not strAddOnDllFolder.EndsWith("\", False, System.Globalization.CultureInfo.CurrentCulture) Then
            strAddOnDllFolder += "\"
        End If
        Dim pos As Integer = strAddOnDllFolder.LastIndexOf("\Samples\")
        If Not pos = -1 Then
            strAddOnDllFolder = strAddOnDllFolder.Substring(0, strAddOnDllFolder.IndexOf("\", pos))
            strOCRTessDataFolder = strAddOnDllFolder + "\Samples\Bin\"
            strAddOnDllFolder = strAddOnDllFolder + "\Redistributable\Resources\"
            strPDFDllFolder = strAddOnDllFolder + "PDF\"
            strBarcodeDllFolder = strAddOnDllFolder + "Barcode Generator\"
            strOCRDllFolder = strAddOnDllFolder + "OCR\"
        Else
            pos = strAddOnDllFolder.LastIndexOf("\\")
            strAddOnDllFolder = strAddOnDllFolder.Substring(0, strAddOnDllFolder.IndexOf("\", pos)) + "\"
            strPDFDllFolder = strAddOnDllFolder
            strBarcodeDllFolder = strAddOnDllFolder
            strOCRDllFolder = strAddOnDllFolder
            strOCRTessDataFolder = strAddOnDllFolder
        End If
        Me.dynamicDotNetTwain.LicenseKeys = "83C721A603BF5301ABCF850504F7B744;83C721A603BF5301AC7A3AA0DF1D92E6;83C721A603BF5301E22CBEC2DD20B511;83C721A603BF5301977D72EA5256A044;83C721A603BF53014332D52C75036F9E;83C721A603BF53010090AB799ED7E55E"
        Me.dynamicDotNetTwain.PDFRasterizerDllPath = strPDFDllFolder
        Me.dynamicDotNetTwain.BarcodeDllPath = strBarcodeDllFolder
        Me.dynamicDotNetTwain.OCRDllPath = strOCRDllFolder
        Me.dynamicDotNetTwain.OCRTessDataPath = strOCRTessDataFolder
        Me.dynamicDotNetTwain.IfShowCancelDialogWhenBarcodeOrOCR = True
        Me.dynamicDotNetTwain.MaxImagesInBuffer = 64
    End Sub


    Private Sub InitUI()
        Me.dynamicDotNetTwain.Visible = False
        panelAnnotations.Visible = False

        DisableAllFunctionButtons()

        ' Init the View mode
        Me.cbxViewMode.Items.Clear()
        Me.cbxViewMode.Items.Insert(0, "1 x 1")
        Me.cbxViewMode.Items.Insert(1, "2 x 2")
        Me.cbxViewMode.Items.Insert(2, "3 x 3")
        Me.cbxViewMode.Items.Insert(3, "4 x 4")
        Me.cbxViewMode.Items.Insert(4, "5 x 5")

        ' Init the cbxResolution
        Me.cbxResolution.Items.Clear()
        Me.cbxResolution.Items.Insert(0, "100")
        Me.cbxResolution.Items.Insert(1, "150")
        Me.cbxResolution.Items.Insert(2, "200")
        Me.cbxResolution.Items.Insert(3, "300")

        ' Init the Scan Button
        DisableControls(Me.picboxScan)

        ' Init the save image type
        Me.rdbtnJPG.Checked = True

        ' Init the Save Image Button
        DisableControls(Me.picboxSave)

        ' For the popup tip label
        infoLabel = New Label()
        infoLabel.Text = ""
        infoLabel.Visible = False
        infoLabel.AutoSize = True
        infoLabel.Name = "Info"
        infoLabel.BackColor = System.Drawing.Color.White
        infoLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        infoLabel.Font = New System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0)
        infoLabel.BringToFront()
        Me.Controls.Add(infoLabel)

        'Tab Heads
        m_tabHeads(0) = thAcquireImage
        m_tabHeads(1) = thLoadImage
        m_tabHeads(2) = thReadBarcode
        m_tabHeads(3) = thAddBarcode
        m_tabHeads(4) = thOCR
        m_tabHeads(5) = thSaveImage
        m_panels(0) = panelAcquire
        m_panels(1) = panelLoad
        m_panels(2) = panelReadBarcode
        m_panels(3) = panelAddBarcode
        m_panels(4) = panelOCR
        m_panels(5) = panelSaveImage
        thAcquireImage.State = TabHead.TabHeadState.SELECTED
        m_thSelectedTabHead = thAcquireImage

        'OCR
        languages.Add("English", "eng")
        Me.cbxSupportedLanguage.Items.Clear()
        Dim i As Integer = 0
        For Each str As String In languages.Keys
            Me.cbxSupportedLanguage.Items.Insert(i, str)
            i = i + 1
        Next str
        Me.cbxSupportedLanguage.SelectedIndex = 0

        Me.cbxOCRResultFormat.Items.Clear()
        Me.cbxOCRResultFormat.Items.Insert(0, "Text File")
        Me.cbxOCRResultFormat.Items.Insert(1, "Adobe PDF Plain Text File")
        Me.cbxOCRResultFormat.Items.Insert(2, "Adobe PDF Image Over Text File")
        Me.cbxOCRResultFormat.SelectedIndex = 0

        DisableControls(picboxOCR)

        'Add Barcode
        Me.cbxGenBarcodeFormat.Items.Clear()
        Me.cbxGenBarcodeFormat.Items.Insert(0, "CODE_39")
        Me.cbxGenBarcodeFormat.Items.Insert(1, "CODE_128")
        Me.cbxGenBarcodeFormat.Items.Insert(2, "PDF417")
        Me.cbxGenBarcodeFormat.Items.Insert(3, "QR_CODE")
        Me.cbxGenBarcodeFormat.SelectedIndex = 0

        Me.tbxBarcodeContent.Text = "Dynamsoft"
        Me.tbxBarcodeLocationX.Text = "0"
        Me.tbxBarcodeLocationY.Text = "0"
        Me.tbxHumanReadableText.Text = "Dynamsoft"
        Me.tbxBarcodeScale.Text = "1"

        DisableControls(picboxAddBarcode)

        'Read Barcode
        'Me.cbxBarcodeFormat.DataSource = [Enum].GetValues(Dynamsoft.DotNet.TWAIN.Enums.Barcode.BarcodeFormat.All.GetType())
        cbxBarcodeFormat.Items.Add("All")
        cbxBarcodeFormat.Items.Add("OneD")
        cbxBarcodeFormat.Items.Add("Code 39")
        cbxBarcodeFormat.Items.Add("Code 128")
        cbxBarcodeFormat.Items.Add("Code 93")
        cbxBarcodeFormat.Items.Add("Codabar")
        cbxBarcodeFormat.Items.Add("Interleaved 2 of 5")
        cbxBarcodeFormat.Items.Add("EAN-13")
        cbxBarcodeFormat.Items.Add("EAN-8")
        cbxBarcodeFormat.Items.Add("UPC-A")
        cbxBarcodeFormat.Items.Add("UPC-E")
        cbxBarcodeFormat.Items.Add("PDF417")
        cbxBarcodeFormat.Items.Add("QRCode")
        cbxBarcodeFormat.Items.Add("Datamatrix")
        cbxBarcodeFormat.Items.Add("Industrial 2 of 5")
        cbxBarcodeFormat.SelectedIndex = 0
        Me.tbxMaxBarcodeReads.Text = "10"
        Me.tbxLeft.Text = "0"
        Me.tbxRight.Text = "0"
        Me.tbxTop.Text = "0"
        Me.tbxBottom.Text = "0"

        DisableControls(picboxReadBarcode)

        'webcam
        DisableControls(picboxGrab)
        'always show ui for webcam
        chkShowUIForWebcam.Checked = True
        chkShowUIForWebcam.Visible = False
    End Sub

    Private Sub InitDefaultValueForTWAIN()
        Try
            ' dynamicDotNetTwain.IfThrowException = true
            dynamicDotNetTwain.ScanInNewProcess = True
            dynamicDotNetTwain.SupportedDeviceType = Enums.EnumSupportedDeviceType.SDT_ALL
            dynamicDotNetTwain.IfFitWindow = True
            dynamicDotNetTwain.MouseShape = False
            dynamicDotNetTwain.SetViewMode(-1, -1)
            Me.cbxViewMode.SelectedIndex = 0

            ' Init the sources for TWAIN scanning, show in the cbxSources controls
            If dynamicDotNetTwain.SourceCount > 0 Then
                Dim hasTwainSource As Boolean : hasTwainSource = False
                Dim hasWebcamSource As Boolean : hasWebcamSource = False
                Dim i As Integer
                cbxSource.Items.Clear()
                For i = 0 To dynamicDotNetTwain.SourceCount - 1
                    cbxSource.Items.Add(dynamicDotNetTwain.SourceNameItems(Convert.ToInt16(i)))
                    Dim enumDeviceType As Dynamsoft.DotNet.TWAIN.Enums.EnumDeviceType : enumDeviceType = dynamicDotNetTwain.GetSourceType(Convert.ToInt16(i))
                    If (enumDeviceType = Dynamsoft.DotNet.TWAIN.Enums.EnumDeviceType.SDT_TWAIN) Then
                        hasTwainSource = True
                    ElseIf (enumDeviceType = Dynamsoft.DotNet.TWAIN.Enums.EnumDeviceType.SDT_WEBCAM) Then
                        hasWebcamSource = True
                    End If
                Next

                If hasTwainSource Then
                    cbxSource.Enabled = True
                    chkShowUI.Enabled = True
                    chkADF.Enabled = True
                    chkDuplex.Enabled = True
                    cbxResolution.Enabled = True
                    rdbtnGray.Checked = True
                    cbxResolution.SelectedIndex = 0
                    EnableControls(Me.picboxScan)
                End If

                If hasWebcamSource Then
                    chkShowUIForWebcam.Enabled = True
                    cbxMediaType.Enabled = True
                    cbxResolutionForWebcam.Enabled = True
                    EnableControls(Me.picboxGrab)
                End If

                cbxSource.SelectedIndex = 0
                'dynamicDotNetTwain.SelectSourceByIndex(cbxSource.SelectedIndex)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub DrawBackground()
        ' Create a bitmap
        Dim img As Bitmap
        img = My.Resources.Resources.main_bg
        ' Set the form properties
        'Size AS New Size(img.Width, img.Height)
        Dim BackgroundImage As Bitmap
        BackgroundImage = New Bitmap(Width, Height)

        ' Draw it
        Dim g As Graphics
        g = Graphics.FromImage(BackgroundImage)
        g.DrawImage(img, 0, 0, img.Width, img.Height)

    End Sub

    Private Sub DisableAllFunctionButtons()
        DisableControls(Me.picboxHand)
        DisableControls(Me.picboxPoint)
        DisableControls(Me.picboxCrop)
        DisableControls(Me.picboxCut)

        DisableControls(Me.picboxRotateRight)
        DisableControls(Me.picboxRotateLeft)
        DisableControls(Me.picboxMirror)
        DisableControls(Me.picboxFlip)

        DisableControls(Me.picboxLine)
        DisableControls(Me.picboxEllipse)
        DisableControls(Me.picboxRectangle)
        DisableControls(Me.picboxText)

        DisableControls(Me.picboxZoom)
        DisableControls(Me.picboxResample)
        DisableControls(Me.picboxZoomIn)
        DisableControls(Me.picboxZoomOut)

        DisableControls(Me.picboxDelete)
        DisableControls(Me.picboxDeleteAll)

        DisableControls(Me.picboxFirst)
        DisableControls(Me.picboxPrevious)
        DisableControls(Me.picboxNext)
        DisableControls(Me.picboxLast)

        DisableControls(Me.picboxFit)
        DisableControls(Me.picboxOriginalSize)
    End Sub


    ''' <summary>
    '''  Enable all the function buttons in the left and bottom panel
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub EnableAllFunctionButtons()
        EnableControls(Me.picboxHand)
        EnableControls(Me.picboxPoint)
        EnableControls(Me.picboxCrop)
        EnableControls(Me.picboxCut)

        EnableControls(Me.picboxRotateRight)
        EnableControls(Me.picboxRotateLeft)
        EnableControls(Me.picboxMirror)
        EnableControls(Me.picboxFlip)

        EnableControls(Me.picboxLine)
        EnableControls(Me.picboxEllipse)
        EnableControls(Me.picboxRectangle)
        EnableControls(Me.picboxText)

        EnableControls(Me.picboxZoom)
        EnableControls(Me.picboxResample)
        EnableControls(Me.picboxZoomIn)
        EnableControls(Me.picboxZoomOut)

        EnableControls(Me.picboxDelete)
        EnableControls(Me.picboxDeleteAll)

        EnableControls(Me.picboxFit)
        EnableControls(Me.picboxOriginalSize)

        If dynamicDotNetTwain.HowManyImagesInBuffer > 1 Then
            EnableControls(Me.picboxFirst)
            EnableControls(Me.picboxPrevious)
            EnableControls(Me.picboxNext)
            EnableControls(Me.picboxLast)

            If (dynamicDotNetTwain.CurrentImageIndexInBuffer = 0) Then
                DisableControls(picboxPrevious)
                DisableControls(picboxFirst)
            End If

            If (dynamicDotNetTwain.CurrentImageIndexInBuffer + 1 = dynamicDotNetTwain.HowManyImagesInBuffer) Then
                DisableControls(picboxNext)
                DisableControls(picboxLast)
            End If
        End If

        checkZoom()
    End Sub

#Region "regist Event For All PictureBox Buttons"

    Private Sub picbox_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles _
 _
 _
 _
                 picboxLoadImage.MouseDown, _
                picboxFirst.MouseDown, picboxLast.MouseDown, picboxNext.MouseDown, picboxPrevious.MouseDown, _
                 picboxMin.MouseDown, picboxClose.MouseDown, picboxPoint.MouseDown, picboxHand.MouseDown, picboxRotateRight.MouseDown, picboxRotateLeft.MouseDown, picboxMirror.MouseDown, picboxFlip.MouseDown, picboxZoomOut.MouseDown, picboxZoomIn.MouseDown, picboxZoom.MouseDown, picboxText.MouseDown, picboxResample.MouseDown, picboxRectangle.MouseDown, picboxOriginalSize.MouseDown, picboxLine.MouseDown, picboxFit.MouseDown, picboxEllipse.MouseDown, picboxDeleteAll.MouseDown, picboxDelete.MouseDown, picboxCut.MouseDown, picboxCrop.MouseDown, picboxLineA.MouseDown, picboxEllipseA.MouseDown, picboxRectangleA.MouseDown, picboxTextA.MouseDown, picboxScan.MouseDown, picboxSave.MouseDown, picboxReadBarcode.MouseDown, picboxGrab.MouseDown, picboxAddBarcode.MouseDown, picboxOCR.MouseDown, picboxDeleteAnnotationA.MouseDown
        Dim picBox As PictureBox
        Try
            picBox = CType(sender, PictureBox)
            If picBox.Enabled Then
                picBox.Image = CType(My.Resources.Resources.ResourceManager.GetObject(picBox.Name + "_Down"), System.Drawing.Image)
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub picbox_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _
 _
 _
 _
                 picboxLoadImage.MouseEnter, _
                picboxFirst.MouseEnter, picboxLast.MouseEnter, picboxNext.MouseEnter, picboxPrevious.MouseEnter, _
                 picboxMin.MouseEnter, picboxClose.MouseEnter, picboxPoint.MouseEnter, picboxHand.MouseEnter, picboxRotateRight.MouseEnter, picboxRotateLeft.MouseEnter, picboxMirror.MouseEnter, picboxFlip.MouseEnter, picboxZoomOut.MouseEnter, picboxZoomIn.MouseEnter, picboxZoom.MouseEnter, picboxText.MouseEnter, picboxResample.MouseEnter, picboxRectangle.MouseEnter, picboxOriginalSize.MouseEnter, picboxLine.MouseEnter, picboxFit.MouseEnter, picboxEllipse.MouseEnter, picboxDeleteAll.MouseEnter, picboxDelete.MouseEnter, picboxCut.MouseEnter, picboxCrop.MouseEnter, picboxLineA.MouseEnter, picboxEllipseA.MouseEnter, picboxRectangleA.MouseEnter, picboxTextA.MouseEnter, picboxScan.MouseEnter, picboxSave.MouseEnter, picboxReadBarcode.MouseEnter, picboxGrab.MouseEnter, picboxAddBarcode.MouseEnter, picboxOCR.MouseEnter, picboxDeleteAnnotationA.MouseEnter
        Dim picBox As PictureBox
        Try
            picBox = CType(sender, PictureBox)
            If picBox.Enabled Then
                picBox.Image = CType(My.Resources.Resources.ResourceManager.GetObject(picBox.Name + "_Enter"), System.Drawing.Image)
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub picbox_MouseHover(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _
 _
 _
 _
 _
                picboxFirst.MouseHover, picboxLast.MouseHover, picboxNext.MouseHover, picboxPrevious.MouseHover, picboxZoomOut.MouseHover, picboxZoomIn.MouseHover, picboxZoom.MouseHover, picboxText.MouseHover, picboxRotateRight.MouseHover, picboxRotateLeft.MouseHover, picboxResample.MouseHover, picboxRectangle.MouseHover, picboxPoint.MouseHover, picboxOriginalSize.MouseHover, picboxMirror.MouseHover, picboxLine.MouseHover, picboxHand.MouseHover, picboxFlip.MouseHover, picboxFit.MouseHover, picboxEllipse.MouseHover, picboxDeleteAll.MouseHover, picboxDelete.MouseHover, picboxCut.MouseHover, picboxCrop.MouseHover, picboxLineA.MouseHover, picboxEllipseA.MouseHover, picboxRectangleA.MouseHover, picboxTextA.MouseHover, picboxDeleteAnnotationA.MouseHover
        Dim picBox As PictureBox
        Try
            picBox = CType(sender, PictureBox)
            infoLabel.Text = picBox.Tag.ToString()
            infoLabel.Location = New Point(Me.PointToClient(MousePosition).X, Me.PointToClient(MousePosition).Y + 20)
            infoLabel.Visible = True
            infoLabel.BringToFront()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub picbox_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _
 _
 _
 _
                 picboxLoadImage.MouseLeave, _
                picboxFirst.MouseLeave, picboxLast.MouseLeave, picboxNext.MouseLeave, picboxPrevious.MouseLeave, _
                 picboxMin.MouseLeave, picboxClose.MouseLeave, picboxPoint.MouseLeave, picboxHand.MouseLeave, picboxRotateRight.MouseLeave, picboxRotateLeft.MouseLeave, picboxMirror.MouseLeave, picboxFlip.MouseLeave, picboxZoomOut.MouseLeave, picboxZoomIn.MouseLeave, picboxZoom.MouseLeave, picboxText.MouseLeave, picboxResample.MouseLeave, picboxRectangle.MouseLeave, picboxOriginalSize.MouseLeave, picboxLine.MouseLeave, picboxFit.MouseLeave, picboxEllipse.MouseLeave, picboxDeleteAll.MouseLeave, picboxDelete.MouseLeave, picboxCut.MouseLeave, picboxCrop.MouseLeave, picboxLineA.MouseLeave, picboxEllipseA.MouseLeave, picboxRectangleA.MouseLeave, picboxTextA.MouseLeave, picboxScan.MouseLeave, picboxSave.MouseLeave, picboxReadBarcode.MouseLeave, picboxGrab.MouseLeave, picboxAddBarcode.MouseLeave, picboxOCR.MouseLeave, picboxDeleteAnnotationA.MouseLeave
        Dim picBox As PictureBox
        Try
            picBox = CType(sender, PictureBox)
            If picBox.Enabled Then
                picBox.Image = CType(My.Resources.Resources.ResourceManager.GetObject(picBox.Name + "_Leave"), System.Drawing.Image)
                infoLabel.Text = ""
                infoLabel.Visible = False
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub picbox_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles _
 _
 _
 _
                 picboxLoadImage.MouseUp, _
                picboxFirst.MouseUp, picboxLast.MouseUp, picboxNext.MouseUp, picboxPrevious.MouseUp, _
                 picboxMin.MouseUp, picboxClose.MouseUp, picboxPoint.MouseUp, picboxHand.MouseUp, picboxRotateRight.MouseUp, picboxRotateLeft.MouseUp, picboxMirror.MouseUp, picboxZoomOut.MouseUp, picboxZoomIn.MouseUp, picboxZoom.MouseUp, picboxText.MouseUp, picboxResample.MouseUp, picboxRectangle.MouseUp, picboxOriginalSize.MouseUp, picboxLine.MouseUp, picboxFlip.MouseUp, picboxFit.MouseUp, picboxEllipse.MouseUp, picboxDeleteAll.MouseUp, picboxDelete.MouseUp, picboxCut.MouseUp, picboxCrop.MouseUp, picboxLineA.MouseUp, picboxEllipseA.MouseUp, picboxRectangleA.MouseUp, picboxTextA.MouseUp, picboxScan.MouseUp, picboxSave.MouseUp, picboxReadBarcode.MouseUp, picboxGrab.MouseUp, picboxAddBarcode.MouseUp, picboxOCR.MouseUp, picboxDeleteAnnotationA.MouseUp
        Dim picBox As PictureBox
        Try
            picBox = CType(sender, PictureBox)
            If picBox.Enabled Then
                picBox.Image = CType(My.Resources.Resources.ResourceManager.GetObject(picBox.Name + "_Enter"), System.Drawing.Image)
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub DisableControls(ByVal sender As System.Object)
        Dim picBox As PictureBox
        Try
            picBox = CType(sender, PictureBox)
            picBox.Image = CType(My.Resources.Resources.ResourceManager.GetObject(picBox.Name + "_Disabled"), System.Drawing.Image)
            picBox.Enabled = False
        Catch ex As Exception
            picBox = CType(sender, Control)
            picBox.Enabled = False
        End Try
    End Sub

    Private Sub EnableControls(ByVal sender As System.Object)
        Dim picBox As PictureBox
        Try
            picBox = CType(sender, PictureBox)
            picBox.Image = CType(My.Resources.Resources.ResourceManager.GetObject(picBox.Name + "_Leave"), System.Drawing.Image)
            picBox.Enabled = True
        Catch ex As Exception
            picBox = CType(sender, Control)
            picBox.Enabled = True
        End Try
    End Sub
#End Region

#Region "functions for the form, ignore them please"
    Private Sub lbMoveBar_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lbMoveBar.MouseDown
        mouse_offset = New Point(-e.X, -e.Y)
    End Sub

    Private Sub lbMoveBar_MouseMove(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lbMoveBar.MouseMove
        If (e.Button = MouseButtons.Left) Then
            Dim mousePos As Point
            mousePos = Control.MousePosition
            mousePos.Offset(mouse_offset.X, mouse_offset.Y)
            Me.Location = mousePos
        End If
    End Sub

    Private Sub picboxClose_MouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles picboxClose.MouseClick
        Application.Exit()
    End Sub

    Private Sub picboxMin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles picboxMin.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

#End Region

    Private Sub picboxLoadImage_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles picboxLoadImage.Click
        openFileDialog.Filter = "All Support Files|*.JPG;*.JPEG;*.JPE;*.JFIF;*.BMP;*.PNG;*.TIF;*.TIFF;*.PDF;*.GIF|JPEG|*.JPG;*.JPEG;*.JPE;*.Jfif|BMP|*.BMP|PNG|*.PNG|TIFF|*.TIF;*.TIFF|PDF|*.PDF|GIF|*.GIF"
        openFileDialog.FilterIndex = 0
        openFileDialog.Multiselect = True
        dynamicDotNetTwain.IfAppendImage = True
        If (openFileDialog.ShowDialog() = DialogResult.OK) Then
            For Each strFileName As String In openFileDialog.FileNames
                Dim pos As Integer
                pos = strFileName.LastIndexOf(".")
                If (pos <> -1) Then
                    Dim strSuffix As String
                    strSuffix = strFileName.Substring(pos, strFileName.Length - pos).ToLower()
                    If (strSuffix.CompareTo(".pdf") = 0) Then
                        dynamicDotNetTwain.PDFConvertMode = Dynamsoft.DotNet.TWAIN.Enums.EnumPDFConvertMode.enumCM_RENDERALL
                        dynamicDotNetTwain.SetPDFResolution(200)
                        dynamicDotNetTwain.LoadImage(strFileName)
                        'dynamicDotNetTwain.ConvertPDFToImage(strFileName, 200)
                        If (Not dynamicDotNetTwain.ErrorCode = Dynamsoft.DotNet.TWAIN.Enums.ErrorCode.Succeed) Then
                            MessageBox.Show(dynamicDotNetTwain.ErrorString, "Loading image error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End If
                    Else
                        dynamicDotNetTwain.LoadImage(strFileName)
                    End If
                Else
                    dynamicDotNetTwain.LoadImage(strFileName)
                End If
            Next strFileName
            dynamicDotNetTwain.Visible = True
        End If
        checkImageCount()
    End Sub

    ''' <summary>
    ''' If the image count changed, some features should changed.
    ''' </summary>
    ''' <remarks></remarks>

    Private Sub picboxScan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles picboxScan.Click
        If picboxScan.Enabled Then
            If (Me.cbxSource.SelectedIndex < 0) Then
                MessageBox.Show(Me, "There is no scanner detected! " & Constants.vbCrLf & "Please ensure that at least one (virtual) scanner is installed.", "Information")
            Else
                DisableControls(picboxScan)
                Me.AcquireImage()
            End If
        End If
    End Sub


    ''' <summary>
    ''' Acquire image from the selected source
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub AcquireImage()
        Try
            ' Select the source for TWAIN
            dynamicDotNetTwain.SelectSourceByIndex(cbxSource.SelectedIndex)
            dynamicDotNetTwain.OpenSource()
            ' Set the image fit the size of window
            'dynamicDotNetTwain.IfFitWindow = true;
            'dynamicDotNetTwain.MouseShape = false;

            dynamicDotNetTwain.IfShowUI = chkShowUI.Checked

            ' if (chkADF.Enabled)
            ' dynamicDotNetTwain.IfAutoFeed = dynamicDotNetTwain.IfFeederEnabled = chkADF.Checked;
            dynamicDotNetTwain.IfFeederEnabled = chkADF.Checked
            'dynamicDotNetTwain.IfAutoFeed = chkADF.Checked
            ' if (chkDuplex.Enabled)
            dynamicDotNetTwain.IfDuplexEnabled = chkDuplex.Checked

            ' Need to open source first
            ' dynamicDotNetTwain.OpenSource();
            dynamicDotNetTwain.IfDisableSourceAfterAcquire = True


            If (rdbtnBW.Checked) Then
                dynamicDotNetTwain.PixelType = Dynamsoft.DotNet.TWAIN.Enums.TWICapPixelType.TWPT_BW
                dynamicDotNetTwain.BitDepth = 1
            ElseIf (rdbtnGray.Checked) Then
                dynamicDotNetTwain.PixelType = Dynamsoft.DotNet.TWAIN.Enums.TWICapPixelType.TWPT_GRAY
                dynamicDotNetTwain.BitDepth = 8
            Else
                dynamicDotNetTwain.PixelType = Dynamsoft.DotNet.TWAIN.Enums.TWICapPixelType.TWPT_RGB
                dynamicDotNetTwain.BitDepth = 24
            End If

            dynamicDotNetTwain.Resolution = Integer.Parse(cbxResolution.Text)
            ' Acquire image from the source
            dynamicDotNetTwain.AcquireImage()
        Catch ex As Exception
            MessageBox.Show("An exception occurs: " + ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If Not dynamicDotNetTwain.ErrorCode = Enums.ErrorCode.Succeed Then
                EnableControls(picboxScan)
            End If
        End Try
    End Sub

    ''' <summary>
    '''  multi-page are allowed for tiff and pdf
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub rdbtnMultiPage_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdbtnTIFF.CheckedChanged, rdbtnPDF.CheckedChanged
        Dim radioButton As RadioButton
        Try
            radioButton = CType(sender, RadioButton)
            If radioButton.Checked = True Then
                Me.chkMultiPage.Enabled = True
                Me.chkMultiPage.Checked = True
            End If
        Catch ex As Exception
        End Try
    End Sub

    ''' <summary>
    ''' When other image formats are selected, multi-page are not allowed
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub rdbtnSinglePage_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdbtnPNG.CheckedChanged, rdbtnJPG.CheckedChanged, rdbtnBMP.CheckedChanged
        Dim radioButton As RadioButton
        Try
            radioButton = CType(sender, RadioButton)
            If radioButton.Checked = True Then
                Me.chkMultiPage.Enabled = False
                Me.chkMultiPage.Checked = False
            End If
        Catch ex As Exception
        End Try
    End Sub

    ''' <summary>
    ''' Verified the file name. If the file name is ok, return true, else return false.
    ''' </summary>
    ''' <param name="fileName">file name</param>
    ''' <remarks></remarks>
    Private Function VerifyFileName(ByVal fileName As String) As Boolean
        Try

            If fileName.LastIndexOfAny(System.IO.Path.GetInvalidFileNameChars()) = -1 Then
                Return True
            End If

        Catch ex As Exception

        End Try
        MessageBox.Show("The file name contains invalid chars!", "Save Image To File", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Return False
    End Function

    Private Sub picboxSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles picboxSave.Click
        Dim fileName As String
        fileName = tbxSaveFileName.Text.Trim()
        If (VerifyFileName(fileName)) Then
            saveFileDialog.FileName = Me.tbxSaveFileName.Text
            If (rdbtnJPG.Checked) Then
                saveFileDialog.Filter = "JPEG|*.JPG;*.JPEG;*.JPE;*.JFIF"
                saveFileDialog.DefaultExt = "jpg"
                If (saveFileDialog.ShowDialog() = DialogResult.OK) Then
                    dynamicDotNetTwain.SaveAsJPEG(saveFileDialog.FileName, dynamicDotNetTwain.CurrentImageIndexInBuffer)
                End If
            End If
            If (rdbtnBMP.Checked) Then
                saveFileDialog.Filter = "BMP|*.BMP"
                saveFileDialog.DefaultExt = "bmp"
                If (saveFileDialog.ShowDialog() = DialogResult.OK) Then
                    dynamicDotNetTwain.SaveAsBMP(saveFileDialog.FileName, dynamicDotNetTwain.CurrentImageIndexInBuffer)
                End If
            End If

            If (rdbtnPNG.Checked) Then
                saveFileDialog.Filter = "PNG|*.PNG"
                saveFileDialog.DefaultExt = "png"
                If (saveFileDialog.ShowDialog() = DialogResult.OK) Then
                    dynamicDotNetTwain.SaveAsPNG(saveFileDialog.FileName, dynamicDotNetTwain.CurrentImageIndexInBuffer)
                End If
            End If

            If (rdbtnTIFF.Checked) Then
                saveFileDialog.Filter = "TIFF|*.TIF;*.TIFF"
                saveFileDialog.DefaultExt = "tiff"
                If (saveFileDialog.ShowDialog() = DialogResult.OK) Then
                    ' Multi page TIFF
                    If (chkMultiPage.Checked = True) Then
                        dynamicDotNetTwain.SaveAllAsMultiPageTIFF(saveFileDialog.FileName)
                    Else
                        dynamicDotNetTwain.SaveAsTIFF(saveFileDialog.FileName, dynamicDotNetTwain.CurrentImageIndexInBuffer)
                    End If
                End If
            End If

            If (rdbtnPDF.Checked) Then
                saveFileDialog.Filter = "PDF|*.PDF"
                saveFileDialog.DefaultExt = "pdf"
                If (saveFileDialog.ShowDialog() = DialogResult.OK) Then
                    ' Multi page PDF
                    dynamicDotNetTwain.IfSaveAnnotations = True
                    If (chkMultiPage.Checked = True) Then
                        dynamicDotNetTwain.SaveAllAsPDF(saveFileDialog.FileName)
                    Else
                        dynamicDotNetTwain.SaveAsPDF(saveFileDialog.FileName, dynamicDotNetTwain.CurrentImageIndexInBuffer)
                    End If
                End If
            End If
        Else
            Me.tbxSaveFileName.Focus()
        End If
    End Sub

    Private Sub picboxPoint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles picboxPoint.Click
        dynamicDotNetTwain.MouseShape = False
        dynamicDotNetTwain.AnnotationType = Dynamsoft.DotNet.TWAIN.Enums.DWTAnnotationType.enumNone
    End Sub

    Private Sub picboxHand_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles picboxHand.Click
        dynamicDotNetTwain.MouseShape = True
        dynamicDotNetTwain.AnnotationType = Dynamsoft.DotNet.TWAIN.Enums.DWTAnnotationType.enumNone
    End Sub


    Private Sub picboxRotate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim angle As Double
        Dim interPolation As Dynamsoft.DotNet.TWAIN.Enums.DWTInterpolationMethod
        interPolation = Dynamsoft.DotNet.TWAIN.Enums.DWTInterpolationMethod.Bilinear
        Dim keepSize As Boolean
        Dim r, g, b As Integer
        Dim fillColor As Color
        Dim rotateForm As RotateForm
        rotateForm = New RotateForm()
        rotateForm.ShowDialog()

        If (rotateForm.DialogResult = System.Windows.Forms.DialogResult.OK) Then
            If (rotateForm.cbxInterPolation.SelectedIndex = 0) Then
                interPolation = Dynamsoft.DotNet.TWAIN.Enums.DWTInterpolationMethod.Bicubic
            End If
            If (rotateForm.cbxInterPolation.SelectedIndex = 1) Then
                interPolation = Dynamsoft.DotNet.TWAIN.Enums.DWTInterpolationMethod.Bilinear
            End If

            If (rotateForm.cbxInterPolation.SelectedIndex = 2) Then
                interPolation = Dynamsoft.DotNet.TWAIN.Enums.DWTInterpolationMethod.NearestNeighbour
            End If

            keepSize = rotateForm.cbxKeepSize.Checked

            Dim dAngle, iR, iG, iB As Boolean
            dAngle = Double.TryParse(rotateForm.tbxAngle.Text, angle)
            iR = Integer.TryParse(rotateForm.tbxR.Text, r)
            iG = Integer.TryParse(rotateForm.tbxG.Text, g)
            iB = Integer.TryParse(rotateForm.tbxB.Text, b)

            If (dAngle And iR And iG And iB) Then
                If (r >= 0 And r <= 255 And g >= 0 And g <= 255 And b >= 0 And b <= 255) Then
                    fillColor = Color.FromArgb(r, g, b)
                    dynamicDotNetTwain.BackgroundFillColor = fillColor.ToArgb()
                End If
                dynamicDotNetTwain.Rotate(dynamicDotNetTwain.CurrentImageIndexInBuffer, angle, keepSize, interPolation)
            End If
        End If
    End Sub

    Private Sub picboxFit_Click(ByVal sender As Object, ByVal e As EventArgs) Handles picboxFit.Click
        dynamicDotNetTwain.IfFitWindow = True
        checkZoom()
    End Sub

    Private Sub picboxOriginalSize_Click(ByVal sender As Object, ByVal e As EventArgs) Handles picboxOriginalSize.Click
        dynamicDotNetTwain.IfFitWindow = False
        dynamicDotNetTwain.Zoom = 1
        checkZoom()
    End Sub

    Private Sub picboxCut_Click(ByVal sender As Object, ByVal e As EventArgs) Handles picboxCut.Click
        picboxPoint_Click(sender, Nothing)
        Dim rc As Rectangle : rc = dynamicDotNetTwain.GetSelectionRect(dynamicDotNetTwain.CurrentImageIndexInBuffer)
        If (rc.IsEmpty) Then
            MessageBox.Show("Please select the rectangle area first!", "Warning Info", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Else
            dynamicDotNetTwain.CutFrameToClipboard(dynamicDotNetTwain.CurrentImageIndexInBuffer, rc.Left, rc.Top, rc.Right, rc.Bottom)
        End If
    End Sub

    Private Sub picboxCrop_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles picboxCrop.Click
        'if (dynamicDotNetTwain.AnnotationType != Dynamsoft.DotNet.TWAIN.Enums.DWTAnnotationType.enumNone)
        '{
        picboxPoint_Click(sender, Nothing)
        '}    //what does this mean?
        Dim rc As Rectangle
        rc = dynamicDotNetTwain.GetSelectionRect(dynamicDotNetTwain.CurrentImageIndexInBuffer)
        If (rc.IsEmpty) Then
            'isToCrop = true;
            'dynamicDotNetTwain.MouseShape = false;
            'DisableAllFunctionButtons();//why this?
            MessageBox.Show("Please select the rectangle area first!", "Warning Info", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Else
            cropPicture(dynamicDotNetTwain.CurrentImageIndexInBuffer, rc)
        End If
    End Sub

    Private Sub cropPicture(ByVal imageIndex As Integer, ByVal rc As Rectangle)
        dynamicDotNetTwain.Crop(imageIndex, rc.X, rc.Y, rc.X + rc.Width, rc.Y + rc.Height)
    End Sub

    Private Sub picboxRotateLeft_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles picboxRotateLeft.Click
        dynamicDotNetTwain.RotateLeft(dynamicDotNetTwain.CurrentImageIndexInBuffer)
    End Sub

    Private Sub picboxRotateRight_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles picboxRotateRight.Click
        dynamicDotNetTwain.RotateRight(dynamicDotNetTwain.CurrentImageIndexInBuffer)
    End Sub

    Private Sub picboxMirror_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles picboxMirror.Click
        dynamicDotNetTwain.Mirror(dynamicDotNetTwain.CurrentImageIndexInBuffer)
    End Sub

    Private Sub picboxFlip_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles picboxFlip.Click
        dynamicDotNetTwain.Flip(dynamicDotNetTwain.CurrentImageIndexInBuffer)
    End Sub

    Private Sub picboxLine_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles picboxLine.Click, picboxLineA.Click
        dynamicDotNetTwain.MouseShape = False
        dynamicDotNetTwain.AnnotationPen = New Pen(Color.Blue, 5)
        dynamicDotNetTwain.AnnotationType = Dynamsoft.DotNet.TWAIN.Enums.DWTAnnotationType.enumLine
        If (panelAnnotations.Visible = False) Then
            panelAnnotations.Visible = True
        End If
    End Sub

    Private Sub picboxEllipse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles picboxEllipse.Click, picboxEllipseA.Click
        dynamicDotNetTwain.MouseShape = False
        dynamicDotNetTwain.AnnotationPen = New Pen(Color.Black, 2)
        dynamicDotNetTwain.AnnotationFillColor = Color.Blue
        dynamicDotNetTwain.AnnotationType = Dynamsoft.DotNet.TWAIN.Enums.DWTAnnotationType.enumEllipse
        If (panelAnnotations.Visible = False) Then
            panelAnnotations.Visible = True
        End If
    End Sub

    Private Sub picboxRectangle_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles picboxRectangle.Click, picboxRectangleA.Click
        dynamicDotNetTwain.MouseShape = False
        dynamicDotNetTwain.AnnotationPen = New Pen(Color.Black, 2)
        dynamicDotNetTwain.AnnotationFillColor = Color.ForestGreen
        dynamicDotNetTwain.AnnotationType = Dynamsoft.DotNet.TWAIN.Enums.DWTAnnotationType.enumRectangle
        If (panelAnnotations.Visible = False) Then
            panelAnnotations.Visible = True
        End If
    End Sub

    Private Sub picboxText_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles picboxText.Click, picboxTextA.Click
        dynamicDotNetTwain.MouseShape = False
        dynamicDotNetTwain.AnnotationTextColor = Color.Black
        dynamicDotNetTwain.AnnotationTextFont = New Font("", 32)
        dynamicDotNetTwain.AnnotationType = Dynamsoft.DotNet.TWAIN.Enums.DWTAnnotationType.enumText
        If (panelAnnotations.Visible = False) Then
            panelAnnotations.Visible = True
        End If
    End Sub

    Private Sub picboxZoom_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles picboxZoom.Click
        Dim zoomForm As New ZoomForm
        zoomForm.SetZoomRatio(dynamicDotNetTwain.Zoom)
        zoomForm.ShowDialog()
        If (zoomForm.DialogResult = DialogResult.OK) Then
            dynamicDotNetTwain.IfFitWindow = False
            dynamicDotNetTwain.Zoom = zoomForm.GetZoomRatio()
            checkZoom()
        End If
    End Sub

    Private Sub picboxResample_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles picboxResample.Click
        Dim width, height As Integer
        width = dynamicDotNetTwain.GetImage(dynamicDotNetTwain.CurrentImageIndexInBuffer).Width
        height = dynamicDotNetTwain.GetImage(dynamicDotNetTwain.CurrentImageIndexInBuffer).Height

        Dim resampleForm As New ResampleForm
        resampleForm.InitResampleForm(width, height)
        resampleForm.ShowDialog()
        If (resampleForm.DialogResult = DialogResult.OK) Then
            dynamicDotNetTwain.ChangeImageSize(dynamicDotNetTwain.CurrentImageIndexInBuffer, resampleForm.GetNewWidth(), resampleForm.GetNewHeight(), resampleForm.GetInterpolation())
            dynamicDotNetTwain.IfFitWindow = False
        End If
    End Sub

    Private Sub picboxZoomIn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles picboxZoomIn.Click
        Dim zoom As Decimal
        zoom = dynamicDotNetTwain.Zoom + 0.1F
        dynamicDotNetTwain.IfFitWindow = False
        dynamicDotNetTwain.Zoom = zoom
        checkZoom()
    End Sub

    Private Sub picboxZoomOut_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles picboxZoomOut.Click
        Dim zoom As Decimal
        zoom = dynamicDotNetTwain.Zoom - 0.1F
        dynamicDotNetTwain.IfFitWindow = False
        dynamicDotNetTwain.Zoom = zoom
        checkZoom()
    End Sub

    Private Sub checkZoom()
        If (cbxViewMode.SelectedIndex <> 0 Or dynamicDotNetTwain.HowManyImagesInBuffer = 0) Then
            DisableControls(picboxZoomIn)
            DisableControls(picboxZoomOut)
            DisableControls(picboxZoom)
            DisableControls(picboxFit)
            DisableControls(picboxOriginalSize)
            Return
        End If
        If (picboxFit.Enabled = False) Then
            EnableControls(picboxFit)
        End If
        If (picboxOriginalSize.Enabled = False) Then
            EnableControls(picboxOriginalSize)
        End If
        If (picboxZoom.Enabled = False) Then
            EnableControls(picboxZoom)
        End If

        '  the valid range of zoom is between 0.02 to 65.0,

        If (dynamicDotNetTwain.Zoom <= 0.02F) Then
            DisableControls(picboxZoomOut)
        Else
            EnableControls(picboxZoomOut)
        End If

        If (dynamicDotNetTwain.Zoom >= 65.0F) Then
            DisableControls(picboxZoomIn)
        Else
            EnableControls(picboxZoomIn)
        End If
    End Sub

    Private Sub picboxDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles picboxDelete.Click
        dynamicDotNetTwain.RemoveImage(dynamicDotNetTwain.CurrentImageIndexInBuffer)
        checkImageCount()
    End Sub

    Private Sub picboxDeleteAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles picboxDeleteAll.Click
        dynamicDotNetTwain.RemoveAllImages()
        checkImageCount()
    End Sub

    Private Sub checkImageCount()
        currentImageIndex = dynamicDotNetTwain.CurrentImageIndexInBuffer
        Dim currentIndex As Integer
        Dim imageCount As Integer

        currentIndex = currentImageIndex + 1
        imageCount = dynamicDotNetTwain.HowManyImagesInBuffer
        If (imageCount = 0) Then
            currentIndex = 0
        End If

        tbxCurrentImageIndex.Text = currentIndex.ToString()
        tbxTotalImageNum.Text = imageCount.ToString()

        If (imageCount > 0) Then
            EnableControls(picboxSave)
            EnableAllFunctionButtons()
            EnableControls(picboxReadBarcode)
            EnableControls(picboxAddBarcode)
            EnableControls(picboxOCR)
        Else
            DisableControls(picboxSave)
            DisableAllFunctionButtons()
            dynamicDotNetTwain.Visible = False
            panelAnnotations.Visible = False
            DisableControls(picboxReadBarcode)
            DisableControls(picboxAddBarcode)
            DisableControls(picboxOCR)
        End If
        If (imageCount > 1) Then

            EnableControls(picboxFirst)
            EnableControls(picboxLast)
            EnableControls(picboxPrevious)
            EnableControls(picboxNext)

            If (currentIndex = 1) Then
                DisableControls(picboxPrevious)
                DisableControls(picboxFirst)
            End If

            If (currentIndex = imageCount) Then
                DisableControls(picboxNext)
                DisableControls(picboxLast)
            End If
        Else
            DisableControls(picboxFirst)
            DisableControls(picboxLast)
            DisableControls(picboxPrevious)
            DisableControls(picboxNext)
        End If

        ShowSelectedImageArea()
    End Sub

    Private Sub cbxViewMode_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbxViewMode.SelectedIndexChanged
        Select Case Me.cbxViewMode.SelectedIndex
            Case 0
                dynamicDotNetTwain.SetViewMode(-1, -1)
            Case 1
                dynamicDotNetTwain.SetViewMode(2, 2)
            Case 2
                dynamicDotNetTwain.SetViewMode(3, 3)
            Case 3
                dynamicDotNetTwain.SetViewMode(4, 4)
            Case 4
                dynamicDotNetTwain.SetViewMode(5, 5)
            Case Else
                dynamicDotNetTwain.SetViewMode(-1, -1)
        End Select
        checkZoom()
    End Sub

    Private Sub picboxFirst_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles picboxFirst.Click
        If (dynamicDotNetTwain.HowManyImagesInBuffer > 0) Then
            dynamicDotNetTwain.CurrentImageIndexInBuffer = 0
            checkImageCount()
        End If
    End Sub

    Private Sub picboxLast_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles picboxLast.Click
        If (dynamicDotNetTwain.HowManyImagesInBuffer > 0) Then
            dynamicDotNetTwain.CurrentImageIndexInBuffer = (dynamicDotNetTwain.HowManyImagesInBuffer - 1)
            checkImageCount()
        End If
    End Sub

    Private Sub picboxPrevious_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles picboxPrevious.Click
        If (dynamicDotNetTwain.HowManyImagesInBuffer > 0 And dynamicDotNetTwain.CurrentImageIndexInBuffer > 0) Then
            dynamicDotNetTwain.CurrentImageIndexInBuffer = dynamicDotNetTwain.CurrentImageIndexInBuffer - 1
            checkImageCount()
        End If

    End Sub

    Private Sub picboxNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles picboxNext.Click
        If (dynamicDotNetTwain.HowManyImagesInBuffer > 0 And dynamicDotNetTwain.CurrentImageIndexInBuffer < dynamicDotNetTwain.HowManyImagesInBuffer - 1) Then
            dynamicDotNetTwain.CurrentImageIndexInBuffer = dynamicDotNetTwain.CurrentImageIndexInBuffer + 1
            checkImageCount()
        End If

    End Sub

    Private Sub dynamicDotNetTwain_OnMouseClick(ByVal sImageIndex As System.Int16) Handles dynamicDotNetTwain.OnMouseClick
        If (dynamicDotNetTwain.CurrentImageIndexInBuffer <> currentImageIndex) Then
            checkImageCount()
        End If
    End Sub

    Public Sub CallMe()
        dynamicDotNetTwain.Visible = True
        checkImageCount()
        EnableControls(picboxScan)
    End Sub
    Private Sub dynamicDotNetTwain_OnPostAllTransfer() Handles dynamicDotNetTwain.OnPostAllTransfers

        Me.Invoke(New CrossThreadOperationControl(AddressOf CallMe))
    End Sub

    Private Sub dynamicDotNetTwain_OnMouseDoubleClick(ByVal sImageIndex As System.Int16) Handles dynamicDotNetTwain.OnMouseDoubleClick
        Try
            Dim rc As Rectangle
            rc = dynamicDotNetTwain.GetSelectionRect(sImageIndex)

            If (isToCrop And rc.IsEmpty = False) Then
                cropPicture(sImageIndex, rc)
            End If
            isToCrop = False
        Catch ex As Exception

        End Try
        EnableAllFunctionButtons()
    End Sub

    Private Sub dynamicDotNetTwain_OnMouseRightClick(ByVal sImageIndex As System.Int16) Handles dynamicDotNetTwain.OnMouseRightClick
        If (isToCrop) Then
            isToCrop = False
        End If
        dynamicDotNetTwain.ClearSelectionRect(sImageIndex)
        EnableAllFunctionButtons()
    End Sub

    Private Sub dynamicDotNetTwain_OnImageAreaDeselected(ByVal sImageIndex As System.Int16) Handles dynamicDotNetTwain.OnImageAreaDeselected
        If (isToCrop) Then
            isToCrop = False
        End If
        EnableAllFunctionButtons()
        ShowSelectedImageArea()
    End Sub

    Private Sub cbxSource_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbxSource.SelectedIndexChanged
        Dim sIndex As Short : sIndex = Convert.ToInt16((DirectCast(sender, ComboBox)).SelectedIndex)
        Select Case (dynamicDotNetTwain.GetSourceType(sIndex))
            Case Dynamsoft.DotNet.TWAIN.Enums.EnumDeviceType.SDT_TWAIN
                panelScan.Visible = True
                panelGrab.Visible = False
                lbUnknowSource.Visible = False
                dynamicDotNetTwain.CloseSource() 'when switching from webcam source to twain source, need to close webcam source
            Case Dynamsoft.DotNet.TWAIN.Enums.EnumDeviceType.SDT_WEBCAM
                panelScan.Visible = False
                panelGrab.Visible = True
                lbUnknowSource.Visible = False
                'Initial media type list and webcam resolution list
                cbxMediaType.Items.Clear()
                cbxResolutionForWebcam.Items.Clear()
                dynamicDotNetTwain.IfDisableSourceAfterAcquire = False 'don't close video after grabbing an image.
                dynamicDotNetTwain.SelectSourceByIndex(sIndex)
                dynamicDotNetTwain.OpenSource()    'Open webcam source before getting the value of MediaTypeList and ResolutionForCamList
                Dim lstMediaTypes As List(Of String) : lstMediaTypes = dynamicDotNetTwain.MediaTypeList
                Dim lstWebcamResolutions As List(Of Dynamsoft.DotNet.TWAIN.WebCamera.CamResolution) : lstWebcamResolutions = dynamicDotNetTwain.ResolutionForCamList
                If Not lstMediaTypes Is Nothing Then
                    For Each strMediaType As String In lstMediaTypes
                        cbxMediaType.Items.Add(strMediaType)
                    Next strMediaType
                End If
                If Not lstWebcamResolutions Is Nothing Then
                    For Each camResolution As Dynamsoft.DotNet.TWAIN.WebCamera.CamResolution In lstWebcamResolutions
                        cbxResolutionForWebcam.Items.Add(camResolution.Width.ToString() + " X " + camResolution.Height.ToString())
                    Next camResolution
                End If
                If cbxMediaType.Items.Count > 0 Then
                    cbxMediaType.SelectedIndex = 0
                End If
                If cbxResolutionForWebcam.Items.Count > 0 Then
                    cbxResolutionForWebcam.SelectedIndex = 0
                End If
                'show error information
                If Not dynamicDotNetTwain.ErrorCode = Dynamsoft.DotNet.TWAIN.Enums.ErrorCode.Succeed Then
                    MessageBox.Show(dynamicDotNetTwain.ErrorString, "Webcam error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            Case Else
                panelScan.Visible = False
                panelGrab.Visible = False
                lbUnknowSource.Visible = True
        End Select
    End Sub

    Private Sub picboxTitle_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles picboxTitle.MouseDown
        mouse_offset2 = New Point(-e.X, -e.Y)
    End Sub

    Private Sub picboxTitle_MouseMove(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles picboxTitle.MouseMove
        If (e.Button = MouseButtons.Left) Then
            Dim mousePos As Point
            mousePos = Control.MousePosition
            mousePos.Offset(mouse_offset2.X, mouse_offset2.Y)
            If (IsInForm(panelAnnotations.Parent.PointToClient(mousePos))) Then
                panelAnnotations.Location = panelAnnotations.Parent.PointToClient(mousePos)
            End If
        End If
    End Sub

    Private Function IsInForm(ByVal point As Point) As Boolean
        If (point.X > 0 And point.X < 693 And point.Y > 35 And point.Y < 635) Then
            Return True
        End If
        Return False
    End Function

    Private Sub picboxDeleteAnnotationA_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles picboxDeleteAnnotationA.Click
        Dim aryAnnotation As List(Of Dynamsoft.DotNet.TWAIN.Annotation.AnnotationData)
        If (dynamicDotNetTwain.GetSelectedAnnotationList(dynamicDotNetTwain.CurrentImageIndexInBuffer, aryAnnotation)) Then
            dynamicDotNetTwain.DeleteAnnotations(dynamicDotNetTwain.CurrentImageIndexInBuffer, aryAnnotation)
        End If
    End Sub

    Private Sub lbCloseAnnotations_MouseHover(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbCloseAnnotations.MouseHover
        Me.lbCloseAnnotations.ForeColor = System.Drawing.Color.Red
    End Sub

    Private Sub lbCloseAnnotations_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbCloseAnnotations.MouseLeave
        Me.lbCloseAnnotations.ForeColor = System.Drawing.Color.Black
    End Sub

    Private Sub lbCloseAnnotations_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbCloseAnnotations.Click
        Me.panelAnnotations.Visible = False
    End Sub

    Private m_thSelectedTabHead As TabHead = Nothing
    Dim m_tabHeads(5) As TabHead
    Dim m_panels(5) As Panel
    Dim languages As New Dictionary(Of String, String)

    Private Sub TabHead_Click(ByVal sender As Object, ByVal e As EventArgs) Handles thSaveImage.Click, thReadBarcode.Click, thOCR.Click, thLoadImage.Click, thAddBarcode.Click, thAcquireImage.Click
        Dim thHead As TabHead : thHead = DirectCast(sender, TabHead)
        Dim iNeighborIndex As Integer : iNeighborIndex = GetNeighborIndex(thHead)
        If Not m_thSelectedTabHead Is Nothing Then
            If Not m_thSelectedTabHead.Index = iNeighborIndex And Not m_thSelectedTabHead.Index = thHead.Index Then
                m_thSelectedTabHead.State = TabHead.TabHeadState.ALLFOLDED
                m_panels(m_thSelectedTabHead.Index).Visible = False
                Dim iSelectHeadNeighborIndex As Integer : iSelectHeadNeighborIndex = GetNeighborIndex(m_thSelectedTabHead)
                If (iSelectHeadNeighborIndex >= 0) Then
                    m_tabHeads(iSelectHeadNeighborIndex).State = TabHead.TabHeadState.ALLFOLDED
                End If
            End If
        End If

        If thHead.State = TabHead.TabHeadState.SELECTED Then
            thHead.State = TabHead.TabHeadState.ALLFOLDED
            m_panels(thHead.Index).Visible = False
            If (iNeighborIndex >= 0) Then
                m_tabHeads(iNeighborIndex).State = TabHead.TabHeadState.ALLFOLDED
                m_panels(iNeighborIndex).Visible = False
            End If
            m_thSelectedTabHead = Nothing
        Else
            thHead.State = TabHead.TabHeadState.SELECTED
            m_panels(thHead.Index).Visible = True
            If (iNeighborIndex >= 0) Then
                m_tabHeads(iNeighborIndex).State = TabHead.TabHeadState.FOLDED
                m_panels(iNeighborIndex).Visible = False
            End If
            m_thSelectedTabHead = thHead
        End If
    End Sub

    Private Function GetNeighborIndex(ByVal thHead As TabHead) As Integer
        If (Not thHead Is Nothing) And thHead.MultiTabHead Then
            If thHead.Index Mod 2 = 0 Then
                Return thHead.Index + 1
            Else
                Return thHead.Index - 1
            End If
        Else
            Return -1
        End If
    End Function

#Region "Read Barcode"

    Private Sub picboxReadBarcode_Click(ByVal sender As Object, ByVal e As EventArgs) Handles picboxReadBarcode.Click
        ShowSelectedImageArea()
        Dim iMaxBarcodesToRead As Integer = 0
        Try
            iMaxBarcodesToRead = Integer.Parse(tbxMaxBarcodeReads.Text)
        Catch exp As Exception
            MessageBox.Show(exp.Message, "Invalid input of MaxBarcodeReads", MessageBoxButtons.OK, MessageBoxIcon.Error)
            tbxMaxBarcodeReads.Focus()
        End Try

        If dynamicDotNetTwain.CurrentImageIndexInBuffer < 0 Then
            MessageBox.Show("Please load an image before reading barcode!", "Index out of bounds", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Try
            Dim reader As New Dynamsoft.Barcode.BarcodeReader
            reader.LicenseKeys = "91392547848AAF240620ADFEFDB2EDEB"
            reader.ReaderOptions.MaxBarcodesToReadPerPage = iMaxBarcodesToRead
            If cbxBarcodeFormat.SelectedValue >= 0 Then
                Select Case cbxBarcodeFormat.SelectedIndex
                    Case 0

                    Case 1
                        reader.ReaderOptions.BarcodeFormats = Dynamsoft.Barcode.BarcodeFormat.OneD
                    Case 2
                        reader.ReaderOptions.BarcodeFormats = Dynamsoft.Barcode.BarcodeFormat.CODE_39
                    Case 3
                        reader.ReaderOptions.BarcodeFormats = Dynamsoft.Barcode.BarcodeFormat.CODE_128
                    Case 4
                        reader.ReaderOptions.BarcodeFormats = Dynamsoft.Barcode.BarcodeFormat.CODE_93
                    Case 5
                        reader.ReaderOptions.BarcodeFormats = Dynamsoft.Barcode.BarcodeFormat.CODABAR
                    Case 6
                        reader.ReaderOptions.BarcodeFormats = Dynamsoft.Barcode.BarcodeFormat.ITF
                    Case 7
                        reader.ReaderOptions.BarcodeFormats = Dynamsoft.Barcode.BarcodeFormat.EAN_13
                    Case 8
                        reader.ReaderOptions.BarcodeFormats = Dynamsoft.Barcode.BarcodeFormat.EAN_8
                    Case 9
                        reader.ReaderOptions.BarcodeFormats = Dynamsoft.Barcode.BarcodeFormat.UPC_A
                    Case 10
                        reader.ReaderOptions.BarcodeFormats = Dynamsoft.Barcode.BarcodeFormat.UPC_E
                    Case 11
                        reader.ReaderOptions.BarcodeFormats = Dynamsoft.Barcode.BarcodeFormat.PDF417
                    Case 12
                        reader.ReaderOptions.BarcodeFormats = Dynamsoft.Barcode.BarcodeFormat.QR_CODE
                    Case 13
                        reader.ReaderOptions.BarcodeFormats = Dynamsoft.Barcode.BarcodeFormat.DATAMATRIX
                    Case 14
                        reader.ReaderOptions.BarcodeFormats = Dynamsoft.Barcode.BarcodeFormat.INDUSTRIAL_25
                End Select
            Else
            End If

            Dim aryResult() As Dynamsoft.Barcode.BarcodeResult
            Dim rect As Rectangle = dynamicDotNetTwain.GetSelectionRect(dynamicDotNetTwain.CurrentImageIndexInBuffer)
            If rect = Rectangle.Empty Then
                Dim iWidth As Integer = dynamicDotNetTwain.GetImage(dynamicDotNetTwain.CurrentImageIndexInBuffer).Width
                Dim iHeight As Integer = dynamicDotNetTwain.GetImage(dynamicDotNetTwain.CurrentImageIndexInBuffer).Height
                rect = New Rectangle(0, 0, iWidth, iHeight)
            End If
            aryResult = reader.DecodeBitmapRect(dynamicDotNetTwain.GetImage(dynamicDotNetTwain.CurrentImageIndexInBuffer), rect)
            Dim strResult As String
            If aryResult Is Nothing Then
                strResult = "The barcode for selected format is not found."
                MessageBox.Show(strResult, "Barcodes Results")
            Else
                strResult = aryResult.Length & "total barcode is found." & Constants.vbCrLf
                For i As Integer = 0 To aryResult.Length - 1
                    Dim objResult As Dynamsoft.Barcode.BarcodeResult
                    objResult = aryResult(i)
                    'strResult += "Result " & (i + 1).ToString() + Constants.vbCrLf & "  Barcode Format: " & aryResult(i).BarcodeFormat.ToString() & "    Barcode Text: " & aryResult(i).BarcodeText & Constants.vbCrLf
                    strResult += String.Format("Result {0}" & Constants.vbCrLf & "  Barcode Format: {1}" & "    Barcode Text: {2}" & Constants.vbCrLf, (i + 1).ToString(), aryResult(i).BarcodeFormat.ToString(), aryResult(i).BarcodeText)
                Next i
                MessageBox.Show(strResult, "Barcodes Results")
            End If
        Catch exp As Exception
            MessageBox.Show(exp.Message, "Decoding error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ShowSelectedImageArea()
        If dynamicDotNetTwain.CurrentImageIndexInBuffer >= 0 Then
            Dim recSelArea As Rectangle : recSelArea = dynamicDotNetTwain.GetSelectionRect(dynamicDotNetTwain.CurrentImageIndexInBuffer)
            Dim imgCurrent As Image : imgCurrent = dynamicDotNetTwain.GetImage(dynamicDotNetTwain.CurrentImageIndexInBuffer)
            If recSelArea.IsEmpty Then
                tbxLeft.Text = "0"
                tbxRight.Text = imgCurrent.Width.ToString()
                tbxTop.Text = "0"
                tbxBottom.Text = imgCurrent.Height.ToString()
            Else
                If recSelArea.Left < 0 Then
                    tbxLeft.Text = "0"
                ElseIf recSelArea.Left > imgCurrent.Width Then
                    tbxLeft.Text = imgCurrent.Width.ToString()
                Else
                    tbxLeft.Text = recSelArea.Left.ToString()
                End If

                If recSelArea.Right < 0 Then
                    tbxRight.Text = "0"
                ElseIf recSelArea.Right > imgCurrent.Width Then
                    tbxRight.Text = imgCurrent.Width.ToString()
                Else
                    tbxRight.Text = recSelArea.Right.ToString()
                End If

                If recSelArea.Top < 0 Then
                    tbxTop.Text = "0"
                ElseIf recSelArea.Top > imgCurrent.Height Then
                    tbxTop.Text = imgCurrent.Height.ToString()
                Else
                    tbxTop.Text = recSelArea.Top.ToString()
                End If

                If recSelArea.Bottom < 0 Then
                    tbxBottom.Text = "0"
                ElseIf recSelArea.Bottom > imgCurrent.Height Then
                    tbxBottom.Text = imgCurrent.Height.ToString()
                Else
                    tbxBottom.Text = recSelArea.Bottom.ToString()
                End If
            End If
        Else
            tbxLeft.Text = "0"
            tbxRight.Text = "0"
            tbxTop.Text = "0"
            tbxBottom.Text = "0"
        End If
    End Sub

#End Region

#Region "Add Barcode"

    Private Sub picboxAddBarcode_Click(ByVal sender As Object, ByVal e As EventArgs) Handles picboxAddBarcode.Click
        If (picboxAddBarcode.Enabled) Then
            If (dynamicDotNetTwain.CurrentImageIndexInBuffer >= 0) Then
                If (Not tbxBarcodeContent.Text = "") And (Not tbxBarcodeLocationX.Text = "") And (Not tbxBarcodeLocationY.Text = "") And (Not tbxBarcodeScale.Text = "") Then
                    Dim barcodeformat As Dynamsoft.DotNet.TWAIN.Enums.Barcode.BarcodeFormat : barcodeformat = Dynamsoft.DotNet.TWAIN.Enums.Barcode.BarcodeFormat.CODE_39
                    Select Case cbxGenBarcodeFormat.SelectedIndex
                        Case 0
                            barcodeformat = Dynamsoft.DotNet.TWAIN.Enums.Barcode.BarcodeFormat.CODE_39
                        Case 1
                            barcodeformat = Dynamsoft.DotNet.TWAIN.Enums.Barcode.BarcodeFormat.CODE_128
                        Case 2
                            barcodeformat = Dynamsoft.DotNet.TWAIN.Enums.Barcode.BarcodeFormat.PDF417
                        Case 3
                            barcodeformat = Dynamsoft.DotNet.TWAIN.Enums.Barcode.BarcodeFormat.QR_CODE
                    End Select

                    If (Not dynamicDotNetTwain.AddBarcode(dynamicDotNetTwain.CurrentImageIndexInBuffer, barcodeformat, tbxBarcodeContent.Text, _
tbxHumanReadableText.Text, Integer.Parse(tbxBarcodeLocationX.Text), Integer.Parse(tbxBarcodeLocationY.Text), Single.Parse(tbxBarcodeScale.Text))) Then
                        MessageBox.Show(dynamicDotNetTwain.ErrorString, "Adding barcode error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                Else
                    If tbxBarcodeContent.Text = "" Then
                        MessageBox.Show("The content of the barcode can not be empty", "Empty Object", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        tbxBarcodeContent.Focus()
                    ElseIf tbxBarcodeLocationX.Text = "" Then
                        MessageBox.Show("The location of the barcode can not be empty", "Empty Object", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        tbxBarcodeLocationX.Focus()
                    ElseIf tbxBarcodeLocationY.Text = "" Then
                        MessageBox.Show("The location of the barcode can not be empty", "Empty Object", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        tbxBarcodeLocationY.Focus()
                    ElseIf tbxBarcodeScale.Text = "" Then
                        MessageBox.Show("The scale of the barcode can not be empty", "Empty Object", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        tbxBarcodeScale.Focus()
                    End If
                End If
            Else
                MessageBox.Show("Please load an image before adding barcodes!", "Index out of bounds", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        End If
    End Sub

    Private Sub tbxBarcodeLocation_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs) Handles tbxMaxBarcodeReads.KeyPress, tbxBarcodeLocationY.KeyPress, tbxBarcodeLocationX.KeyPress
        Dim array As Byte() : array = System.Text.Encoding.Default.GetBytes(e.KeyChar.ToString())
        If Not Char.IsDigit(e.KeyChar) Or array.LongLength = 2 Then
            e.Handled = True
        End If
        If (e.KeyChar = Chr(8)) Then
            e.Handled = False
        End If
    End Sub

    Private Sub tbxBarcodeScale_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs) Handles tbxBarcodeScale.KeyPress
        Dim array As Byte() : array = System.Text.Encoding.Default.GetBytes(e.KeyChar.ToString())
        If Not Char.IsDigit(e.KeyChar) Or array.LongLength = 2 Then
            e.Handled = True
        End If
        If (e.KeyChar = Chr(8) Or (Not tbxBarcodeScale.Text.Contains(".") And e.KeyChar = Chr(46))) Then
            e.Handled = False
        End If
    End Sub

#End Region

#Region "Perform OCR"

    Private Sub picboxOCR_Click(ByVal sender As Object, ByVal e As EventArgs) Handles picboxOCR.Click
        If (picboxOCR.Enabled) Then
            If (dynamicDotNetTwain.CurrentImageIndexInBuffer >= 0) Then
                dynamicDotNetTwain.OCRLanguage = languages(cbxSupportedLanguage.Text)
                dynamicDotNetTwain.OCRResultFormat = DirectCast(cbxOCRResultFormat.SelectedIndex, Dynamsoft.DotNet.TWAIN.OCR.ResultFormat)
                Dim sbytes As Byte() : sbytes = Nothing
                sbytes = dynamicDotNetTwain.OCR(dynamicDotNetTwain.CurrentSelectedImageIndicesInBuffer)

                If Not sbytes Is Nothing And sbytes.Length > 0 Then
                    Dim filedlg As SaveFileDialog : filedlg = New SaveFileDialog()
                    If Not cbxOCRResultFormat.SelectedIndex = 0 Then
                        filedlg.Filter = "PDF File(*.pdf)| *.pdf"
                    Else
                        filedlg.Filter = "Text File(*.txt)| *.txt"
                    End If

                    If filedlg.ShowDialog() = DialogResult.OK Then
                        System.IO.File.WriteAllBytes(filedlg.FileName, sbytes)
                    End If
                Else
                    If Not dynamicDotNetTwain.ErrorCode = 0 Then
                        MessageBox.Show(dynamicDotNetTwain.ErrorString, "Performing OCR error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                End If
            Else
                MessageBox.Show("Please load an image before doing OCR!", "Index out of bounds", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        End If
    End Sub

#End Region

    Private Sub dynamicDotNetTwain_OnImageAreaSelected(ByVal sImageIndex As Short, ByVal left As Integer, ByVal top As Integer, ByVal right As Integer, ByVal bottom As Integer) Handles dynamicDotNetTwain.OnImageAreaSelected
        ShowSelectedImageArea()
    End Sub

    Private Sub picboxGrab_Click(ByVal sender As Object, ByVal e As EventArgs) Handles picboxGrab.Click
        dynamicDotNetTwain.IfShowUI = chkShowUIForWebcam.Checked
        dynamicDotNetTwain.MediaType = cbxMediaType.Text
        If Not cbxResolutionForWebcam.Text = Nothing Then
            Dim strWXH As String() : strWXH = cbxResolutionForWebcam.Text.Split(New Char() {Chr(32)})
            If strWXH.Length = 3 Then
                Try
                    dynamicDotNetTwain.ResolutionForCam = New Dynamsoft.DotNet.TWAIN.WebCamera.CamResolution( _
                        Integer.Parse(strWXH(0)), Integer.Parse(strWXH(2)))
                Catch exp As Exception
                End Try
            End If
        End If
        If Not dynamicDotNetTwain.AcquireImage() Then
            MessageBox.Show(dynamicDotNetTwain.ErrorString, "Grab error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub dynamicDotNetTwain_OnSourceUIClose() Handles dynamicDotNetTwain.OnSourceUIClose
        EnableControls(picboxScan)
    End Sub

    Private Sub cbxMediaType_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)
        If cbxMediaType.SelectedIndex >= 0 Then
            dynamicDotNetTwain.MediaType = cbxMediaType.Text
        End If
    End Sub
    Private Sub cbxResolutionForWebcam_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)
        If Not cbxResolutionForWebcam.Text = Nothing Then
            Dim strWXH As String() : strWXH = cbxResolutionForWebcam.Text.Split(New Char() {Chr(32)})
            If strWXH.Length = 3 Then
                Try
                    dynamicDotNetTwain.ResolutionForCam = New Dynamsoft.DotNet.TWAIN.WebCamera.CamResolution( _
                        Integer.Parse(strWXH(0)), Integer.Parse(strWXH(2)))
                Catch exp As Exception
                End Try
            End If
        End If
    End Sub
End Class

