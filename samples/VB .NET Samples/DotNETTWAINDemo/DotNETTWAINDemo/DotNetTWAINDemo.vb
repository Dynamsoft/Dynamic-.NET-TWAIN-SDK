Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
Imports System.Runtime.InteropServices

Imports System.Threading
Imports Dynamsoft.Barcode
Imports Dynamsoft.TWAIN
Imports Dynamsoft.Core
Imports Dynamsoft.UVC
Imports Dynamsoft.OCR
Imports Dynamsoft.PDF
Imports Dynamsoft.Core.Annotation
Imports Dynamsoft.TWAIN.Interface
Imports Dynamsoft.Core.Enums
Imports System.IO
Imports Dynamsoft.Common


Partial Public Class DotNetTWAINDemo
    Inherits Form
    Implements IAcquireCallback
    Implements IConvertCallback
    Implements ISave
    ' For move the window
    Private mouse_offset As Point
    ' For move the annotation form
    Private mouse_offset2 As Point
    Private currentImageIndex As Integer = -1
    Private Delegate Sub CrossThreadOperationControl()
    Private isToCrop As Boolean = False
    Private infoLabel As Label

    Private roundedRectanglePanelSaveImage As RoundedRectanglePanel
    Private roundedRectanglePanelAcquireLoad As RoundedRectanglePanel
    Private roundedRectanglePanelBarcode As RoundedRectanglePanel
    Private roundedRectanglePanelOCR As RoundedRectanglePanel
    Private thSaveImage As TabHead
    Private thOCR As TabHead
    Private thAddBarcode As TabHead
    Private thReadBarcode As TabHead
    Private thLoadImage As TabHead
    Private thAcquireImage As TabHead

    ''' <summary>
    ''' Click to minimize the form
    ''' </summary>
    Protected Overrides ReadOnly Property CreateParams() As CreateParams
        Get
            Const WS_MINIMIZEBOX As Integer = &H20000
            Dim cp As CreateParams = MyBase.CreateParams
            cp.Style = cp.Style Or WS_MINIMIZEBOX
            Return cp
        End Get
    End Property
    Private m_StrProductKey As String
    Private m_TwainManager As TwainManager = Nothing
    Private m_ImageCore As ImageCore = Nothing
    Private m_CameraManager As CameraManager = Nothing
    Private m_PDFRasterizer As PDFRasterizer = Nothing
    Private m_PDFCreator As PDFCreator = Nothing
    Private m_Tesseract As Tesseract = Nothing
    Private m_BarcodeReader As BarcodeReader
    Private m_BarcodeGenerator As BarcodeGenerator = Nothing

    Private m_Camera As Camera = Nothing

    Private mBarcodeType As String() = {"All_DEFAULT", "OneD_DEFAULT", "QR_CODE_DEFAULT", "PDF417_DEFAULT", "DATAMATRIX_DEFAULT", "CODE_39_DEFAULT", "CODE_128_DEFAULT", "CODE_93_DEFAULT", "CODABAR_DEFAULT", "ITF_DEFAULT", "INDUSTRIAL_25_DEFAULT", "EAN_13_DEFAULT", "EAN_8_DEFAULT", "UPC_A_DEFAULT", "UPC_E_DEFAULT"}
    Private mBarcodeFormat As String = "All_DEFAULT"

    Public Sub New()
        InitializeComponent()
        InitializeComponentForCustomControl()
        m_StrProductKey = "t0068UwAAAEQABDxqjGfgEzhVYureL0kGxugcsvIqCDGTPTsR5nLaQsNupIc17Y5vpMZAWBDsd6Xw3NMYzdHlHwiKUrfe/cU="
        m_TwainManager = New TwainManager(m_StrProductKey)
        m_ImageCore = New ImageCore()
        m_CameraManager = New CameraManager(m_StrProductKey)
        m_PDFRasterizer = New PDFRasterizer(m_StrProductKey)
        m_PDFCreator = New PDFCreator(m_StrProductKey)
        m_Tesseract = New Tesseract(m_StrProductKey)
        m_BarcodeReader = New BarcodeReader(m_StrProductKey)
        m_BarcodeGenerator = New BarcodeGenerator(m_StrProductKey)

        dsViewer.Bind(m_ImageCore)

        ' Draw the background for the main form
        DrawBackground()

        Initialization()
    End Sub


    Private Sub InitializeComponentForCustomControl()

        Me.roundedRectanglePanelSaveImage = New RoundedRectanglePanel()
        Me.roundedRectanglePanelAcquireLoad = New RoundedRectanglePanel()
        Me.roundedRectanglePanelBarcode = New RoundedRectanglePanel()
        Me.roundedRectanglePanelOCR = New RoundedRectanglePanel()
        Me.thSaveImage = New TabHead()
        Me.thOCR = New TabHead()
        Me.thAddBarcode = New TabHead()
        Me.thReadBarcode = New TabHead()
        Me.thLoadImage = New TabHead()
        Me.thAcquireImage = New TabHead()

        Me.roundedRectanglePanelSaveImage.SuspendLayout()
        Me.roundedRectanglePanelAcquireLoad.SuspendLayout()
        Me.roundedRectanglePanelBarcode.SuspendLayout()
        Me.roundedRectanglePanelOCR.SuspendLayout()
        ' 
        ' roundedRectanglePanelSaveImage
        ' 
        Me.roundedRectanglePanelSaveImage.AutoSize = True
        Me.roundedRectanglePanelSaveImage.BackgroundImage = DirectCast(ResourceManager.GetObject("roundedRectanglePanelSaveImage.BackgroundImage"), System.Drawing.Image)
        Me.roundedRectanglePanelSaveImage.Controls.Add(Me.panelSaveImage)
        Me.roundedRectanglePanelSaveImage.Controls.Add(Me.thSaveImage)
        Me.roundedRectanglePanelSaveImage.Location = New System.Drawing.Point(12, 904)
        Me.roundedRectanglePanelSaveImage.Margin = New System.Windows.Forms.Padding(12, 12, 12, 0)
        Me.roundedRectanglePanelSaveImage.Name = "roundedRectanglePanelSaveImage"
        Me.roundedRectanglePanelSaveImage.Padding = New System.Windows.Forms.Padding(1)
        Me.roundedRectanglePanelSaveImage.Size = New System.Drawing.Size(250, 252)
        ' 
        ' roundedRectanglePanelAcquireLoad
        ' 
        Me.roundedRectanglePanelAcquireLoad.AutoSize = True
        Me.roundedRectanglePanelAcquireLoad.BackColor = System.Drawing.SystemColors.Control
        Me.roundedRectanglePanelAcquireLoad.BackgroundImage = DirectCast(ResourceManager.GetObject("roundedRectanglePanelAcquireLoad.BackgroundImage"), System.Drawing.Image)
        Me.roundedRectanglePanelAcquireLoad.Controls.Add(Me.panelLoad)
        Me.roundedRectanglePanelAcquireLoad.Controls.Add(Me.panelAcquire)
        Me.roundedRectanglePanelAcquireLoad.Controls.Add(Me.thLoadImage)
        Me.roundedRectanglePanelAcquireLoad.Controls.Add(Me.thAcquireImage)
        Me.roundedRectanglePanelAcquireLoad.Location = New System.Drawing.Point(12, 12)
        Me.roundedRectanglePanelAcquireLoad.Margin = New System.Windows.Forms.Padding(12, 12, 12, 0)
        Me.roundedRectanglePanelAcquireLoad.Name = "roundedRectanglePanelAcquireLoad"
        Me.roundedRectanglePanelAcquireLoad.Padding = New System.Windows.Forms.Padding(1)
        Me.roundedRectanglePanelAcquireLoad.Size = New System.Drawing.Size(250, 270)
        Me.roundedRectanglePanelAcquireLoad.TabIndex = 0
        ' 
        ' roundedRectanglePanelBarcode
        ' 
        Me.roundedRectanglePanelBarcode.AutoSize = True
        Me.roundedRectanglePanelBarcode.BackgroundImage = DirectCast(ResourceManager.GetObject("roundedRectanglePanelBarcode.BackgroundImage"), System.Drawing.Image)
        Me.roundedRectanglePanelBarcode.Controls.Add(Me.panelAddBarcode)
        Me.roundedRectanglePanelBarcode.Controls.Add(Me.panelReadBarcode)
        Me.roundedRectanglePanelBarcode.Controls.Add(Me.thAddBarcode)
        Me.roundedRectanglePanelBarcode.Controls.Add(Me.thReadBarcode)
        Me.roundedRectanglePanelBarcode.Location = New System.Drawing.Point(12, 294)
        Me.roundedRectanglePanelBarcode.Margin = New System.Windows.Forms.Padding(12, 12, 12, 0)
        Me.roundedRectanglePanelBarcode.Name = "roundedRectanglePanelBarcode"
        Me.roundedRectanglePanelBarcode.Padding = New System.Windows.Forms.Padding(1)
        Me.roundedRectanglePanelBarcode.Size = New System.Drawing.Size(250, 362)
        Me.roundedRectanglePanelBarcode.TabIndex = 1
        ' 
        ' roundedRectanglePanelOCR
        ' 
        Me.roundedRectanglePanelOCR.AutoSize = True
        Me.roundedRectanglePanelOCR.BackgroundImage = DirectCast(ResourceManager.GetObject("roundedRectanglePanelOCR.BackgroundImage"), System.Drawing.Image)
        Me.roundedRectanglePanelOCR.Controls.Add(Me.panelOCR)
        Me.roundedRectanglePanelOCR.Controls.Add(Me.thOCR)
        Me.roundedRectanglePanelOCR.Location = New System.Drawing.Point(12, 668)
        Me.roundedRectanglePanelOCR.Margin = New System.Windows.Forms.Padding(12, 12, 12, 0)
        Me.roundedRectanglePanelOCR.Name = "roundedRectanglePanelOCR"
        Me.roundedRectanglePanelOCR.Padding = New System.Windows.Forms.Padding(1)
        Me.roundedRectanglePanelOCR.Size = New System.Drawing.Size(250, 224)
        Me.roundedRectanglePanelOCR.TabIndex = 2
        ' 
        ' thSaveImage
        ' 
        Me.thSaveImage.Font = New System.Drawing.Font("Segoe UI", 10.0F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CByte(0))
        Me.thSaveImage.Image = DirectCast(ResourceManager.GetObject("thSaveImage.Image"), System.Drawing.Image)
        Me.thSaveImage.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.thSaveImage.Index = 5
        Me.thSaveImage.Location = New System.Drawing.Point(1, 1)
        Me.thSaveImage.Margin = New System.Windows.Forms.Padding(0)
        Me.thSaveImage.MultiTabHead = False
        Me.thSaveImage.Name = "thSaveImage"
        Me.thSaveImage.Size = New System.Drawing.Size(248, 40)
        Me.thSaveImage.State = TabHead.TabHeadState.ALLFOLDED
        Me.thSaveImage.TabIndex = 73
        Me.thSaveImage.Text = "Save Image"
        Me.thSaveImage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        AddHandler Me.thSaveImage.Click, New System.EventHandler(AddressOf Me.TabHead_Click)
        ' 
        ' thOCR
        ' 
        Me.thOCR.Font = New System.Drawing.Font("Segoe UI", 10.0F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CByte(0))
        Me.thOCR.Image = DirectCast(ResourceManager.GetObject("thOCR.Image"), System.Drawing.Image)
        Me.thOCR.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.thOCR.Index = 4
        Me.thOCR.Location = New System.Drawing.Point(1, 1)
        Me.thOCR.Margin = New System.Windows.Forms.Padding(0)
        Me.thOCR.MultiTabHead = False
        Me.thOCR.Name = "thOCR"
        Me.thOCR.Size = New System.Drawing.Size(248, 40)
        Me.thOCR.State = TabHead.TabHeadState.ALLFOLDED
        Me.thOCR.TabIndex = 0
        Me.thOCR.Text = "OCR"
        Me.thOCR.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        AddHandler Me.thOCR.Click, New System.EventHandler(AddressOf Me.TabHead_Click)
        ' 
        ' thAddBarcode
        ' 
        Me.thAddBarcode.BackColor = System.Drawing.Color.Transparent
        Me.thAddBarcode.Font = New System.Drawing.Font("Segoe UI", 10.0F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CByte(0))
        Me.thAddBarcode.Image = DirectCast(ResourceManager.GetObject("thAddBarcode.Image"), System.Drawing.Image)
        Me.thAddBarcode.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.thAddBarcode.Index = 3
        Me.thAddBarcode.Location = New System.Drawing.Point(125, 1)
        Me.thAddBarcode.Margin = New System.Windows.Forms.Padding(0)
        Me.thAddBarcode.MultiTabHead = True
        Me.thAddBarcode.Name = "thAddBarcode"
        Me.thAddBarcode.Size = New System.Drawing.Size(124, 40)
        Me.thAddBarcode.State = TabHead.TabHeadState.ALLFOLDED
        Me.thAddBarcode.TabIndex = 1
        Me.thAddBarcode.Text = "Add Barcode"
        Me.thAddBarcode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        AddHandler Me.thAddBarcode.Click, New System.EventHandler(AddressOf Me.TabHead_Click)
        ' 
        ' thReadBarcode
        ' 
        Me.thReadBarcode.BackColor = System.Drawing.Color.Transparent
        Me.thReadBarcode.Font = New System.Drawing.Font("Segoe UI", 10.0F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CByte(0))
        Me.thReadBarcode.Image = DirectCast(ResourceManager.GetObject("thReadBarcode.Image"), System.Drawing.Image)
        Me.thReadBarcode.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.thReadBarcode.Index = 2
        Me.thReadBarcode.Location = New System.Drawing.Point(1, 1)
        Me.thReadBarcode.Margin = New System.Windows.Forms.Padding(0)
        Me.thReadBarcode.MultiTabHead = True
        Me.thReadBarcode.Name = "thReadBarcode"
        Me.thReadBarcode.Size = New System.Drawing.Size(124, 40)
        Me.thReadBarcode.State = TabHead.TabHeadState.ALLFOLDED
        Me.thReadBarcode.TabIndex = 0
        Me.thReadBarcode.Text = "Read Barcode"
        Me.thReadBarcode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        AddHandler Me.thReadBarcode.Click, New System.EventHandler(AddressOf Me.TabHead_Click)
        ' 
        ' thLoadImage
        ' 
        Me.thLoadImage.BackColor = System.Drawing.Color.Transparent
        Me.thLoadImage.Font = New System.Drawing.Font("Segoe UI", 10.0F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CByte(0))
        Me.thLoadImage.Image = DirectCast(ResourceManager.GetObject("thLoadImage.Image"), System.Drawing.Image)
        Me.thLoadImage.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.thLoadImage.Index = 1
        Me.thLoadImage.Location = New System.Drawing.Point(125, 1)
        Me.thLoadImage.Margin = New System.Windows.Forms.Padding(0)
        Me.thLoadImage.MultiTabHead = True
        Me.thLoadImage.Name = "thLoadImage"
        Me.thLoadImage.Size = New System.Drawing.Size(124, 40)
        Me.thLoadImage.State = TabHead.TabHeadState.FOLDED
        Me.thLoadImage.TabIndex = 1
        Me.thLoadImage.Text = "Load Files"
        Me.thLoadImage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        AddHandler Me.thLoadImage.Click, New System.EventHandler(AddressOf Me.TabHead_Click)
        ' 
        ' thAcquireImage
        ' 
        Me.thAcquireImage.BackColor = System.Drawing.Color.Transparent
        Me.thAcquireImage.Font = New System.Drawing.Font("Segoe UI", 10.0F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CByte(0))
        Me.thAcquireImage.Image = DirectCast(ResourceManager.GetObject("thAcquireImage.Image"), System.Drawing.Image)
        Me.thAcquireImage.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.thAcquireImage.Index = 0
        Me.thAcquireImage.Location = New System.Drawing.Point(1, 1)
        Me.thAcquireImage.Margin = New System.Windows.Forms.Padding(0)
        Me.thAcquireImage.MultiTabHead = True
        Me.thAcquireImage.Name = "thAcquireImage"
        Me.thAcquireImage.Size = New System.Drawing.Size(124, 40)
        Me.thAcquireImage.State = TabHead.TabHeadState.SELECTED
        Me.thAcquireImage.TabIndex = 0
        Me.thAcquireImage.Text = "Acquire Image"
        Me.thAcquireImage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        AddHandler Me.thAcquireImage.Click, New System.EventHandler(AddressOf Me.TabHead_Click)

        Me.roundedRectanglePanelAcquireLoad.ResumeLayout(False)
        Me.roundedRectanglePanelSaveImage.ResumeLayout(False)
        Me.roundedRectanglePanelBarcode.ResumeLayout(False)
        Me.roundedRectanglePanelOCR.ResumeLayout(False)

        Me.roundedRectanglePanelSaveImage.TabIndex = 3
        Me.flowLayoutPanel2.Controls.Add(Me.roundedRectanglePanelAcquireLoad)
        Me.flowLayoutPanel2.Controls.Add(Me.roundedRectanglePanelBarcode)
        Me.flowLayoutPanel2.Controls.Add(Me.roundedRectanglePanelOCR)
        Me.flowLayoutPanel2.Controls.Add(Me.roundedRectanglePanelSaveImage)
    End Sub

    Protected Sub Initialization()
        Dim strOCRTessDataFolder As String = Nothing
        Dim mSettingPath As String = Nothing
        Dim strTempFolder As String = Application.ExecutablePath
        strTempFolder = strTempFolder.Replace("/", "\")
        If Not strTempFolder.EndsWith("\", False, System.Globalization.CultureInfo.CurrentCulture) Then
            strTempFolder += "\"
        End If
        Dim pos As Integer = strTempFolder.LastIndexOf("\Samples\")
        If pos <> -1 Then
            strTempFolder = strTempFolder.Substring(0, strTempFolder.IndexOf("\", pos))
            strOCRTessDataFolder = strTempFolder & "\Samples\Bin\tessdata"
            mSettingPath = strTempFolder & "\Samples\Bin\Templates\"
            strTempFolder = strTempFolder & "\Redistributable\Resources\"
        Else
            pos = strTempFolder.LastIndexOf("\")
            strTempFolder = strTempFolder.Substring(0, strTempFolder.IndexOf("\", pos)) & "\Bin\"
            strOCRTessDataFolder = strTempFolder & "tessdata"
            mSettingPath = strTempFolder & "Templates\"
        End If
        m_Tesseract.TessDataPath = strOCRTessDataFolder
        Try
            m_BarcodeReader.LoadSettingsFromFile(mSettingPath & "template_aggregation.json")
        Catch
            MessageBox.Show("Failed to load the settings file, please check the file path.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub DotNetTWAINDemo_Load(sender As Object, e As EventArgs)
        InitUI()
        InitDefaultValueForTWAIN()
    End Sub

    ''' <summary>
    ''' Init the UI for the demo
    ''' </summary>
    Private Sub InitUI()
        dsViewer.Visible = False
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
        infoLabel.Font = New System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CByte(0))
        infoLabel.BringToFront()
        Me.Controls.Add(infoLabel)

        ' For the load image button
        AddHandler Me.picboxLoadImage.MouseLeave, New System.EventHandler(AddressOf Me.picbox_MouseLeave)
        AddHandler Me.picboxLoadImage.Click, New System.EventHandler(AddressOf Me.picboxLoadImage_Click)
        AddHandler Me.picboxLoadImage.MouseDown, New System.Windows.Forms.MouseEventHandler(AddressOf Me.picbox_MouseDown)
        AddHandler Me.picboxLoadImage.MouseUp, New System.Windows.Forms.MouseEventHandler(AddressOf Me.picbox_MouseUp)
        AddHandler Me.picboxLoadImage.MouseEnter, New System.EventHandler(AddressOf Me.picbox_MouseEnter)

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
        For Each str As String In languages.Keys
            Me.cbxSupportedLanguage.Items.Add(str)
        Next
        Me.cbxSupportedLanguage.SelectedIndex = 0

        Me.cbxOCRResultFormat.Items.Clear()
        Me.cbxOCRResultFormat.Items.Add("Text File")
        Me.cbxOCRResultFormat.Items.Add("Adobe PDF Plain Text File")
        Me.cbxOCRResultFormat.Items.Add("Adobe PDF Image Over Text File")
        Me.cbxOCRResultFormat.SelectedIndex = 0

        DisableControls(picboxOCR)

        'Add Barcode
        Me.cbxGenBarcodeFormat.Items.Clear()
        Me.cbxGenBarcodeFormat.Items.Add("CODE_39")
        Me.cbxGenBarcodeFormat.Items.Add("CODE_128")
        Me.cbxGenBarcodeFormat.Items.Add("PDF417")
        Me.cbxGenBarcodeFormat.Items.Add("QR_CODE")
        Me.cbxGenBarcodeFormat.SelectedIndex = 0

        Me.tbxBarcodeContent.Text = "Dynamsoft"
        Me.tbxBarcodeLocationX.Text = "0"
        Me.tbxBarcodeLocationY.Text = "0"
        Me.tbxHumanReadableText.Text = "Dynamsoft"
        Me.tbxBarcodeScale.Text = "1"

        DisableControls(picboxAddBarcode)

        'Read Barcode
        cbxBarcodeFormat.Items.Add("All")
        cbxBarcodeFormat.Items.Add("OneD")
        cbxBarcodeFormat.Items.Add("QRCode")
        cbxBarcodeFormat.Items.Add("PDF417")
        cbxBarcodeFormat.Items.Add("Datamatrix")
        cbxBarcodeFormat.Items.Add("Code 39")
        cbxBarcodeFormat.Items.Add("Code 128")
        cbxBarcodeFormat.Items.Add("Code 93")
        cbxBarcodeFormat.Items.Add("Codabar")
        cbxBarcodeFormat.Items.Add("Interleaved 2 of 5")
        cbxBarcodeFormat.Items.Add("Industrial 2 of 5")
        cbxBarcodeFormat.Items.Add("EAN-13")
        cbxBarcodeFormat.Items.Add("EAN-8")
        cbxBarcodeFormat.Items.Add("UPC-A")
        cbxBarcodeFormat.Items.Add("UPC-E")
        cbxBarcodeFormat.SelectedIndex = 0

        DisableControls(picboxReadBarcode)

        'webcam
        DisableControls(picboxGrab)
        'always show ui for webcam
        chkShowUIForWebcam.Checked = True
        chkShowUIForWebcam.Visible = False
    End Sub

    ''' <summary>
    ''' Init the default value for TWAIN
    ''' </summary>
    Private Sub InitDefaultValueForTWAIN()
        Try

            dsViewer.IfFitWindow = True
            dsViewer.MouseShape = False
            dsViewer.SetViewMode(-1, -1)
            Me.cbxViewMode.SelectedIndex = 0

            ' Init the sources for TWAIN scanning and Webcam grab, show in the cbxSources controls
            If m_TwainManager.SourceCount > 0 Then
                Dim hasTwainSource As Boolean = False
                Dim hasWebcamSource As Boolean = False
                cbxSource.Items.Clear()
                For i As Integer = 0 To m_TwainManager.SourceCount - 1
                    cbxSource.Items.Add(m_TwainManager.SourceNameItems(CShort(i)))
                    hasTwainSource = True
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
            End If
            Dim iSourceCount As Integer = 0
            If m_CameraManager.GetCameraNames() IsNot Nothing Then
                iSourceCount = m_CameraManager.GetCameraNames().Count
            End If
            If iSourceCount > 0 Then
                Dim hasWebcamSource As Boolean = False
                For i As Integer = 0 To iSourceCount - 1
                    cbxSource.Items.Add(m_CameraManager.GetCameraNames()(i))
                    hasWebcamSource = True
                Next
                If hasWebcamSource Then
                    chkShowUIForWebcam.Enabled = True
                    cbxResolutionForWebcam.Enabled = True
                    EnableControls(Me.picboxGrab)
                End If
            End If

            If cbxSource.Items.Count > 0 Then
                cbxSource.SelectedIndex = 0

            End If
        Catch ex As System.Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub DrawBackground()
        ' Create a bitmap
        Dim img As Bitmap = main_bg
        ' Set the form properties
        Size = New Size(img.Width, img.Height)
        BackgroundImage = New Bitmap(Width, Height)

        ' Draw it
        Dim g As Graphics = Graphics.FromImage(BackgroundImage)
        g.DrawImage(img, 0, 0, img.Width, img.Height)
    End Sub

    ''' <summary>
    ''' Disable all the function buttons in the left and bottom panel
    ''' </summary>
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
    ''' Enable all the function buttons in the left and bottom panel
    ''' </summary>
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

        If m_ImageCore.ImageBuffer.HowManyImagesInBuffer > 1 Then
            EnableControls(Me.picboxFirst)
            EnableControls(Me.picboxPrevious)
            EnableControls(Me.picboxNext)
            EnableControls(Me.picboxLast)

            If m_ImageCore.ImageBuffer.CurrentImageIndexInBuffer = 0 Then
                DisableControls(picboxPrevious)
                DisableControls(picboxFirst)
            End If
            If m_ImageCore.ImageBuffer.CurrentImageIndexInBuffer + 1 = m_ImageCore.ImageBuffer.HowManyImagesInBuffer Then
                DisableControls(picboxNext)
                DisableControls(picboxLast)
            End If
        End If

        checkZoom()
    End Sub

#Region "regist Event For All PictureBox Buttons"
    Private Sub picbox_MouseEnter(sender As Object, e As EventArgs)
        If TypeOf sender Is PictureBox Then
            If TryCast(sender, PictureBox).Enabled = True Then
                TryCast(sender, PictureBox).Image = DirectCast(ResourceManager.GetObject(TryCast(sender, PictureBox).Name & "_Enter"), Image)
            End If
        End If
    End Sub

    Private Sub picbox_MouseDown(sender As Object, e As MouseEventArgs)
        If TypeOf sender Is PictureBox Then
            If TryCast(sender, PictureBox).Enabled = True Then
                TryCast(sender, PictureBox).Image = DirectCast(ResourceManager.GetObject(TryCast(sender, PictureBox).Name & "_Down"), Image)
            End If
        End If
    End Sub

    Private Sub picbox_MouseLeave(sender As Object, e As EventArgs)
        If TypeOf sender Is PictureBox Then
            If TryCast(sender, PictureBox).Enabled = True Then
                TryCast(sender, PictureBox).Image = DirectCast(ResourceManager.GetObject(TryCast(sender, PictureBox).Name & "_Leave"), Image)
                infoLabel.Text = ""
                infoLabel.Visible = False
            End If
        End If
    End Sub

    Private Sub picbox_MouseUp(sender As Object, e As MouseEventArgs)
        If TypeOf sender Is PictureBox Then
            If TryCast(sender, PictureBox).Enabled = True Then
                TryCast(sender, PictureBox).Image = DirectCast(ResourceManager.GetObject(TryCast(sender, PictureBox).Name & "_Enter"), Image)
            End If
        End If

    End Sub

    Private Sub picbox_MouseHover(sender As Object, e As EventArgs)
        infoLabel.Text = TryCast(sender, PictureBox).Tag.ToString()
        infoLabel.Location = New Point(Me.PointToClient(MousePosition).X, Me.PointToClient(MousePosition).Y + 20)
        infoLabel.Visible = True
        infoLabel.BringToFront()
    End Sub

    Private Sub DisableControls(sender As Object)
        If TypeOf sender Is PictureBox Then
            TryCast(sender, PictureBox).Image = DirectCast(ResourceManager.GetObject(TryCast(sender, PictureBox).Name & "_Disabled"), Image)
            TryCast(sender, PictureBox).Enabled = False
        Else
            TryCast(sender, Control).Enabled = False
        End If
    End Sub

    Private Sub EnableControls(sender As Object)
        If TypeOf sender Is PictureBox Then
            TryCast(sender, PictureBox).Image = DirectCast(ResourceManager.GetObject(TryCast(sender, PictureBox).Name & "_Leave"), Image)
            TryCast(sender, PictureBox).Enabled = True
        Else
            TryCast(sender, Control).Enabled = True
        End If
    End Sub

#End Region

#Region "functions for the form, ignore them please"
    ''' <summary>
    ''' Mouse down when move the form
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub lbMoveBar_MouseDown(sender As Object, e As MouseEventArgs)
        mouse_offset = New Point(-e.X, -e.Y)
    End Sub

    ''' <summary>
    ''' Mouse move when move the form
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub lbMoveBar_MouseMove(sender As Object, e As MouseEventArgs)
        If e.Button = MouseButtons.Left Then
            Dim mousePos As Point = Control.MousePosition
            mousePos.Offset(mouse_offset.X, mouse_offset.Y)
            Me.Location = mousePos
        End If
    End Sub

    ''' <summary>
    ''' Close the application
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub picboxClose_MouseClick(sender As Object, e As MouseEventArgs)
        Application.[Exit]()
    End Sub

    ''' <summary>
    ''' Minimize the form
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub picboxMin_Click(sender As Object, e As EventArgs)
        Me.WindowState = FormWindowState.Minimized
    End Sub
#End Region

    Private Sub picboxScan_Click(sender As Object, e As EventArgs)
        If picboxScan.Enabled Then
            picboxScan.Focus()
            If Me.cbxSource.SelectedIndex < 0 Then
                MessageBox.Show(Me, "There is no scanner detected!" & vbLf & " " & "Please ensure that at least one (virtual) scanner is installed.", "Information")
            Else
                DisableControls(picboxScan)
                Me.AcquireImage()
            End If
        End If
    End Sub

    Private m_CameraUI As CameraUI = Nothing
    ''' <summary>
    ''' Acquire image from the selected source
    ''' </summary>
    Private Sub AcquireImage()
        Try

            Dim sSourceIndex As Short = 0
            sSourceIndex = CShort(cbxSource.SelectedIndex)
            Dim sTwainSourceCount As Short = m_TwainManager.SourceCount
            Dim sCameraSourceCount As Short = 0
            If m_CameraManager.GetCameraNames() IsNot Nothing Then
                sCameraSourceCount = CShort(m_CameraManager.GetCameraNames().Count)
            End If

            If sSourceIndex < sTwainSourceCount Then
                m_TwainManager.SelectSourceByIndex(sSourceIndex)
                m_TwainManager.OpenSource()
                m_TwainManager.IfShowUI = chkShowUI.Checked
                m_TwainManager.IfFeederEnabled = chkADF.Checked
                m_TwainManager.IfDuplexEnabled = chkDuplex.Checked
                m_TwainManager.IfDisableSourceAfterAcquire = True



                If rdbtnBW.Checked Then
                    m_TwainManager.PixelType = Dynamsoft.TWAIN.Enums.TWICapPixelType.TWPT_BW
                    m_TwainManager.BitDepth = 1
                ElseIf rdbtnGray.Checked Then
                    m_TwainManager.PixelType = Dynamsoft.TWAIN.Enums.TWICapPixelType.TWPT_GRAY
                    m_TwainManager.BitDepth = 8
                Else
                    m_TwainManager.PixelType = Dynamsoft.TWAIN.Enums.TWICapPixelType.TWPT_RGB
                    m_TwainManager.BitDepth = 24
                End If
                m_TwainManager.Resolution = Integer.Parse(cbxResolution.Text)
                m_TwainManager.AcquireImage(TryCast(Me, IAcquireCallback))
            Else
                Dim sCameraIndex As Short = CShort(sSourceIndex - sTwainSourceCount)
                m_Camera = m_CameraManager.SelectCamera(sCameraIndex)
                If m_CameraUI.IsDisposed OrElse m_CameraUI Is Nothing Then
                    m_CameraUI = New CameraUI()
                End If
                m_CameraUI.Camera = m_Camera
                m_Camera.Open()
                m_CameraUI.ClientSize = New Size(m_Camera.CurrentResolution.Width, m_Camera.CurrentResolution.Height)
                m_CameraUI.Show()

            End If
        Catch exp As Exception
            Throw exp
        Finally
            EnableControls(picboxScan)
            dsViewer.Visible = True
            checkImageCount()
        End Try
    End Sub

    ''' <summary>
    ''' multi-page are allowed for tiff and pdf
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub rdbtnMultiPage_CheckedChanged(sender As Object, e As EventArgs)
        If TryCast(sender, RadioButton).Checked = True Then
            Me.chkMultiPage.Enabled = True
            Me.chkMultiPage.Checked = True
        End If
    End Sub

    ''' <summary>
    ''' When other image formats are selected, multi-page are not allowed
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub rdbtnSinglePage_CheckedChanged(sender As Object, e As EventArgs)
        If TryCast(sender, RadioButton).Checked = True Then
            Me.chkMultiPage.Enabled = False
            Me.chkMultiPage.Checked = False
        End If
    End Sub

    ''' <summary>
    ''' Verified the file name. If the file name is ok, return true, else return false.
    ''' </summary>
    ''' <param name="fileName">file name</param>
    ''' <returns></returns>
    Private Function VerifyFileName(fileName As String) As Boolean
        Try
            If fileName.LastIndexOfAny(System.IO.Path.GetInvalidFileNameChars()) = -1 Then
                Return True
            End If
        Catch e As Exception
        End Try
        MessageBox.Show("The file name contains invalid chars!", "Save Image To File", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Return False
    End Function

    ''' <summary>
    ''' Save the image as the selected format and name
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub picboxSave_Click(sender As Object, e As EventArgs)
        Try
            Dim fileName As String = tbxSaveFileName.Text.Trim()
            If VerifyFileName(fileName) Then
                saveFileDialog.FileName = Me.tbxSaveFileName.Text

                If rdbtnJPG.Checked Then
                    saveFileDialog.Filter = "JPEG|*.JPG;*.JPEG;*.JPE;*.JFIF"
                    saveFileDialog.DefaultExt = "jpg"
                    If saveFileDialog.ShowDialog() = DialogResult.OK Then
                        m_ImageCore.IO.SaveAsJPEG(saveFileDialog.FileName, m_ImageCore.ImageBuffer.CurrentImageIndexInBuffer)
                    End If
                End If
                If rdbtnBMP.Checked Then
                    saveFileDialog.Filter = "BMP|*.BMP"
                    saveFileDialog.DefaultExt = "bmp"
                    If saveFileDialog.ShowDialog() = DialogResult.OK Then
                        m_ImageCore.IO.SaveAsBMP(saveFileDialog.FileName, m_ImageCore.ImageBuffer.CurrentImageIndexInBuffer)
                    End If
                End If
                If rdbtnPNG.Checked Then
                    saveFileDialog.Filter = "PNG|*.PNG"
                    saveFileDialog.DefaultExt = "png"
                    If saveFileDialog.ShowDialog() = DialogResult.OK Then
                        m_ImageCore.IO.SaveAsPNG(saveFileDialog.FileName, m_ImageCore.ImageBuffer.CurrentImageIndexInBuffer)
                    End If
                End If
                If rdbtnTIFF.Checked Then
                    saveFileDialog.Filter = "TIFF|*.TIF;*.TIFF"
                    saveFileDialog.DefaultExt = "tiff"
                    If saveFileDialog.ShowDialog() = DialogResult.OK Then
                        ' Multi page TIFF
                        Dim tempListIndex As New List(Of Short)()
                        If chkMultiPage.Checked = True Then

                            For sIndex As Short = 0 To m_ImageCore.ImageBuffer.HowManyImagesInBuffer - 1
                                tempListIndex.Add(sIndex)
                            Next
                        Else
                            tempListIndex.Add(m_ImageCore.ImageBuffer.CurrentImageIndexInBuffer)
                        End If
                        m_ImageCore.IO.SaveAsTIFF(saveFileDialog.FileName, tempListIndex)
                    End If
                End If
                If rdbtnPDF.Checked Then
                    saveFileDialog.Filter = "PDF|*.PDF"
                    saveFileDialog.DefaultExt = "pdf"
                    If saveFileDialog.ShowDialog() = DialogResult.OK Then
                        ' Multi page PDF

                        m_PDFCreator.Save(TryCast(Me, ISave), saveFileDialog.FileName)
                    End If
                End If
            Else
                Me.tbxSaveFileName.Focus()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub picboxPoint_Click(sender As Object, e As EventArgs)

        dsViewer.MouseShape = False
        dsViewer.Annotation.Type = Dynamsoft.Forms.Enums.EnumAnnotationType.enumNone
    End Sub

    ' Change mouse shape to hand, for move image
    Private Sub picboxHand_Click(sender As Object, e As EventArgs)
        dsViewer.MouseShape = True
        dsViewer.Annotation.Type = Dynamsoft.Forms.Enums.EnumAnnotationType.enumNone
    End Sub

    Private Sub picboxFit_Click(sender As Object, e As EventArgs)
        dsViewer.IfFitWindow = True
        checkZoom()
    End Sub

    Private Sub picboxOriginalSize_Click(sender As Object, e As EventArgs)
        dsViewer.IfFitWindow = False
        dsViewer.Zoom = 1
        checkZoom()
    End Sub

    Private Sub picboxCut_Click(sender As Object, e As EventArgs)
        picboxPoint_Click(sender, Nothing)
        Dim rc As Rectangle = dsViewer.GetSelectionRect(m_ImageCore.ImageBuffer.CurrentImageIndexInBuffer)
        If rc.IsEmpty Then
            MessageBox.Show("Please select the rectangle area first!", "Warning Info", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Else
            m_ImageCore.ImageProcesser.CutFrameToClipborad(m_ImageCore.ImageBuffer.CurrentImageIndexInBuffer, rc.Left, rc.Top, rc.Right, rc.Bottom)
        End If
    End Sub

    Private Sub picboxCrop_Click(sender As Object, e As EventArgs)
        picboxPoint_Click(sender, Nothing)
        Dim rc As Rectangle = dsViewer.GetSelectionRect(m_ImageCore.ImageBuffer.CurrentImageIndexInBuffer)
        If rc.IsEmpty Then
            MessageBox.Show("Please select the rectangle area first!", "Warning Info", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Else
            cropPicture(m_ImageCore.ImageBuffer.CurrentImageIndexInBuffer, rc)
        End If
    End Sub

    Private Sub cropPicture(imageIndex As Integer, rc As Rectangle)
        m_ImageCore.ImageProcesser.Crop(CShort(imageIndex), rc.X, rc.Y, rc.X + rc.Width, rc.Y + rc.Height)
    End Sub

    Private Sub picboxRotateLeft_Click(sender As Object, e As EventArgs)

        Dim iImageWidth As Integer = m_ImageCore.ImageBuffer.GetBitmap(m_ImageCore.ImageBuffer.CurrentImageIndexInBuffer).Width
        Dim iImageHeight As Integer = m_ImageCore.ImageBuffer.GetBitmap(m_ImageCore.ImageBuffer.CurrentImageIndexInBuffer).Height
        Dim tempListAnnotation As List(Of AnnotationData) = DirectCast(m_ImageCore.ImageBuffer.GetMetaData(m_ImageCore.ImageBuffer.CurrentImageIndexInBuffer, EnumMetaDataType.enumAnnotation), List(Of AnnotationData))
        If tempListAnnotation IsNot Nothing AndAlso tempListAnnotation.Count <> 0 Then
            For Each tempAnnotation As AnnotationData In tempListAnnotation
                Dim x As Integer = tempAnnotation.Location.Y
                Dim y As Integer = iImageWidth - (tempAnnotation.EndPoint.X)
                Dim iWidth As Integer = (tempAnnotation.EndPoint.Y - tempAnnotation.StartPoint.Y)
                Dim iHeight As Integer = (tempAnnotation.EndPoint.X - tempAnnotation.StartPoint.X)
                Select Case tempAnnotation.AnnotationType
                    'case AnnotationType.enumLine:
                    Case AnnotationType.enumEllipse, AnnotationType.enumRectangle, AnnotationType.enumText
                        tempAnnotation.StartPoint = New Point(x, y)
                        'tempAnnotation.Size = new Size(iWidth, iHeight);
                        tempAnnotation.EndPoint = New Point((tempAnnotation.StartPoint.X + iWidth), (tempAnnotation.StartPoint.Y + iHeight))
                        Exit Select
                    Case AnnotationType.enumLine
                        Dim startPoint As Point = tempAnnotation.StartPoint
                        x = startPoint.Y
                        y = iImageWidth - startPoint.X
                        tempAnnotation.StartPoint = New Point(x, y)
                        Dim endPoint As Point = tempAnnotation.EndPoint
                        x = endPoint.Y
                        y = iImageWidth - endPoint.X
                        tempAnnotation.EndPoint = New Point(x, y)
                        Exit Select
                End Select
            Next
        End If
        m_ImageCore.ImageBuffer.SetMetaData(m_ImageCore.ImageBuffer.CurrentImageIndexInBuffer, EnumMetaDataType.enumAnnotation, tempListAnnotation, True)
        m_ImageCore.ImageProcesser.RotateLeft(m_ImageCore.ImageBuffer.CurrentImageIndexInBuffer)
    End Sub

    Private Sub picboxRotateRight_Click(sender As Object, e As EventArgs)
        Dim iImageWidth As Integer = m_ImageCore.ImageBuffer.GetBitmap(m_ImageCore.ImageBuffer.CurrentImageIndexInBuffer).Width
        Dim iImageHeight As Integer = m_ImageCore.ImageBuffer.GetBitmap(m_ImageCore.ImageBuffer.CurrentImageIndexInBuffer).Height
        Dim tempListAnnotation As List(Of AnnotationData) = DirectCast(m_ImageCore.ImageBuffer.GetMetaData(m_ImageCore.ImageBuffer.CurrentImageIndexInBuffer, EnumMetaDataType.enumAnnotation), List(Of AnnotationData))
        For Each tempAnnotation As AnnotationData In tempListAnnotation
            Dim x As Integer = iImageHeight - (tempAnnotation.Location.Y + tempAnnotation.Size.Height)
            Dim y As Integer = tempAnnotation.Location.X
            Dim iWidth As Integer = tempAnnotation.Size.Height
            Dim iHeight As Integer = tempAnnotation.Size.Width
            Select Case tempAnnotation.AnnotationType
                Case AnnotationType.enumEllipse, AnnotationType.enumRectangle, AnnotationType.enumText
                    tempAnnotation.StartPoint = New Point(x, y)
                    tempAnnotation.EndPoint = New Point((tempAnnotation.StartPoint.X + iWidth), (tempAnnotation.StartPoint.Y + iHeight))
                    Exit Select
                Case AnnotationType.enumLine
                    Dim startPoint As Point = tempAnnotation.StartPoint
                    x = iImageHeight - startPoint.Y
                    y = startPoint.X
                    tempAnnotation.StartPoint = New Point(x, y)
                    Dim endPoint As Point = tempAnnotation.EndPoint
                    x = iImageHeight - endPoint.Y
                    y = endPoint.X
                    tempAnnotation.EndPoint = New Point(x, y)
                    Exit Select
            End Select
        Next
        m_ImageCore.ImageProcesser.RotateRight(m_ImageCore.ImageBuffer.CurrentImageIndexInBuffer)
    End Sub

    Private Sub picboxFlip_Click(sender As Object, e As EventArgs)
        Dim iImageWidth As Integer = m_ImageCore.ImageBuffer.GetBitmap(m_ImageCore.ImageBuffer.CurrentImageIndexInBuffer).Width
        Dim iImageHeight As Integer = m_ImageCore.ImageBuffer.GetBitmap(m_ImageCore.ImageBuffer.CurrentImageIndexInBuffer).Height
        Dim tempListAnnotation As List(Of AnnotationData) = DirectCast(m_ImageCore.ImageBuffer.GetMetaData(m_ImageCore.ImageBuffer.CurrentImageIndexInBuffer, EnumMetaDataType.enumAnnotation), List(Of AnnotationData))
        If tempListAnnotation IsNot Nothing AndAlso tempListAnnotation.Count <> 0 Then
            For Each tempAnnotation As AnnotationData In tempListAnnotation
                Dim y As Integer = 0
                Select Case tempAnnotation.AnnotationType
                    Case AnnotationType.enumRectangle, AnnotationType.enumEllipse, AnnotationType.enumText
                        y = iImageHeight - (tempAnnotation.StartPoint.Y + tempAnnotation.Size.Height)
                        tempAnnotation.StartPoint = New Point(tempAnnotation.StartPoint.X, y)
                        tempAnnotation.EndPoint = New Point((tempAnnotation.StartPoint.X + tempAnnotation.Size.Width), (tempAnnotation.StartPoint.Y + tempAnnotation.Size.Height))
                        Exit Select
                    Case AnnotationType.enumLine
                        y = iImageHeight - tempAnnotation.Location.Y - tempAnnotation.Size.Height

                        Dim startPoint As Point = tempAnnotation.StartPoint
                        y = iImageHeight - startPoint.Y
                        tempAnnotation.StartPoint = New Point(startPoint.X, y)
                        Dim endPoint As Point = tempAnnotation.EndPoint
                        y = iImageHeight - endPoint.Y
                        tempAnnotation.EndPoint = New Point(endPoint.X, y)
                        Exit Select
                End Select
            Next
        End If
        m_ImageCore.ImageProcesser.Flip(m_ImageCore.ImageBuffer.CurrentImageIndexInBuffer)
    End Sub

    Private Sub picboxMirror_Click(sender As Object, e As EventArgs)
        Dim iImageWidth As Integer = m_ImageCore.ImageBuffer.GetBitmap(m_ImageCore.ImageBuffer.CurrentImageIndexInBuffer).Width
        Dim iImageHeight As Integer = m_ImageCore.ImageBuffer.GetBitmap(m_ImageCore.ImageBuffer.CurrentImageIndexInBuffer).Height
        Dim tempListAnnotation As List(Of AnnotationData) = DirectCast(m_ImageCore.ImageBuffer.GetMetaData(m_ImageCore.ImageBuffer.CurrentImageIndexInBuffer, EnumMetaDataType.enumAnnotation), List(Of AnnotationData))
        For Each tempAnnotation As AnnotationData In tempListAnnotation
            Dim x As Integer = 0
            Dim startPoint As Point, endPoint As Point
            Select Case tempAnnotation.AnnotationType
                Case AnnotationType.enumRectangle, AnnotationType.enumEllipse, AnnotationType.enumText
                    x = iImageWidth - tempAnnotation.Location.X - tempAnnotation.Size.Width
                    startPoint = New Point(x, tempAnnotation.StartPoint.Y)
                    endPoint = New Point((startPoint.X + tempAnnotation.Size.Width), (startPoint.Y + tempAnnotation.Size.Height))
                    tempAnnotation.StartPoint = startPoint
                    tempAnnotation.EndPoint = endPoint
                    Exit Select
                Case AnnotationType.enumLine
                    x = iImageWidth - tempAnnotation.Location.X - tempAnnotation.Size.Width
                    startPoint = tempAnnotation.StartPoint
                    x = iImageWidth - startPoint.X
                    tempAnnotation.StartPoint = New Point(x, startPoint.Y)
                    endPoint = tempAnnotation.EndPoint
                    x = iImageWidth - endPoint.X
                    tempAnnotation.EndPoint = New Point(x, endPoint.Y)
                    Exit Select

            End Select
        Next

        m_ImageCore.ImageProcesser.Mirror(m_ImageCore.ImageBuffer.CurrentImageIndexInBuffer)
    End Sub

    Private Sub picboxLine_Click(sender As Object, e As EventArgs)
        dsViewer.MouseShape = False
        dsViewer.Annotation.Pen = New Pen(Color.Blue, 5)
        dsViewer.Annotation.Type = Dynamsoft.Forms.Enums.EnumAnnotationType.enumLine
        If panelAnnotations.Visible = False Then
            panelAnnotations.Visible = True
        End If
    End Sub

    Private Sub picboxEllipse_Click(sender As Object, e As EventArgs)
        dsViewer.MouseShape = False
        dsViewer.Annotation.Pen = New Pen(Color.Black, 2)
        dsViewer.Annotation.FillColor = Color.Blue
        dsViewer.Annotation.Type = Dynamsoft.Forms.Enums.EnumAnnotationType.enumEllipse
        If panelAnnotations.Visible = False Then
            panelAnnotations.Visible = True
        End If
    End Sub

    Private Sub picboxRectangle_Click(sender As Object, e As EventArgs)
        dsViewer.MouseShape = False
        dsViewer.Annotation.Pen = New Pen(Color.Black, 2)
        dsViewer.Annotation.FillColor = Color.ForestGreen
        dsViewer.Annotation.Type = Dynamsoft.Forms.Enums.EnumAnnotationType.enumRectangle
        If panelAnnotations.Visible = False Then
            panelAnnotations.Visible = True
        End If
    End Sub

    Private Sub picboxText_Click(sender As Object, e As EventArgs)
        dsViewer.MouseShape = False
        dsViewer.Annotation.TextColor = Color.Black
        dsViewer.Annotation.Type = Dynamsoft.Forms.Enums.EnumAnnotationType.enumText
        If panelAnnotations.Visible = False Then
            panelAnnotations.Visible = True
        End If
    End Sub

    Private Sub picboxZoom_Click(sender As Object, e As EventArgs)
        Dim zoomForm As New ZoomForm(dsViewer.Zoom)
        zoomForm.ShowDialog()
        If zoomForm.DialogResult = DialogResult.OK Then
            dsViewer.IfFitWindow = False
            dsViewer.Zoom = zoomForm.ZoomRatio
            checkZoom()
        End If
    End Sub

    Private Sub picboxResample_Click(sender As Object, e As EventArgs)
        Dim width As Integer = m_ImageCore.ImageBuffer.GetBitmap(m_ImageCore.ImageBuffer.CurrentImageIndexInBuffer).Width
        Dim height As Integer = m_ImageCore.ImageBuffer.GetBitmap(m_ImageCore.ImageBuffer.CurrentImageIndexInBuffer).Height

        Dim resampleForm As New ResampleForm(width, height)
        resampleForm.ShowDialog()
        If resampleForm.DialogResult = DialogResult.OK Then
            m_ImageCore.ImageProcesser.ChangeImageSize(m_ImageCore.ImageBuffer.CurrentImageIndexInBuffer, resampleForm.NewWidth, resampleForm.NewHeight, resampleForm.Interpolation)
            dsViewer.IfFitWindow = False
        End If
    End Sub

    Private Sub picboxZoomIn_Click(sender As Object, e As EventArgs)
        Dim zoom As Single = dsViewer.Zoom + 0.1F
        dsViewer.IfFitWindow = False
        dsViewer.Zoom = zoom
        checkZoom()
    End Sub

    Private Sub picboxZoomOut_Click(sender As Object, e As EventArgs)
        Dim zoom As Single = dsViewer.Zoom - 0.1F
        dsViewer.IfFitWindow = False
        dsViewer.Zoom = zoom
        checkZoom()
    End Sub

    Private Sub checkZoom()
        If cbxViewMode.SelectedIndex <> 0 OrElse m_ImageCore.ImageBuffer.HowManyImagesInBuffer = 0 Then
            DisableControls(picboxZoomIn)
            DisableControls(picboxZoomOut)
            DisableControls(picboxZoom)
            DisableControls(picboxFit)
            DisableControls(picboxOriginalSize)
            Return
        End If
        If picboxFit.Enabled = False Then
            EnableControls(picboxFit)
        End If
        If picboxOriginalSize.Enabled = False Then
            EnableControls(picboxOriginalSize)
        End If
        If picboxZoom.Enabled = False Then
            EnableControls(picboxZoom)
        End If

        '  the valid range of zoom is between 0.02 to 65.0,

        If dsViewer.Zoom <= 0.02F Then
            DisableControls(picboxZoomOut)
        Else
            EnableControls(picboxZoomOut)
        End If

        If dsViewer.Zoom >= 65.0F Then
            DisableControls(picboxZoomIn)
        Else
            EnableControls(picboxZoomIn)
        End If
    End Sub

    Private Sub picboxDelete_Click(sender As Object, e As EventArgs)
        m_ImageCore.ImageBuffer.RemoveImage(m_ImageCore.ImageBuffer.CurrentImageIndexInBuffer)
        checkImageCount()
    End Sub

    Private Sub picboxDeleteAll_Click(sender As Object, e As EventArgs)
        m_ImageCore.ImageBuffer.RemoveAllImages()
        checkImageCount()
    End Sub

    ''' <summary>
    ''' If the image count changed, some features should changed.
    ''' </summary>
    Private Sub checkImageCount()
        currentImageIndex = m_ImageCore.ImageBuffer.CurrentImageIndexInBuffer
        Dim currentIndex As Integer = currentImageIndex + 1
        Dim imageCount As Integer = m_ImageCore.ImageBuffer.HowManyImagesInBuffer
        If imageCount = 0 Then
            currentIndex = 0
        End If

        tbxCurrentImageIndex.Text = currentIndex.ToString()
        tbxTotalImageNum.Text = imageCount.ToString()

        If imageCount > 0 Then
            EnableControls(picboxSave)
            EnableAllFunctionButtons()
            EnableControls(picboxReadBarcode)
            EnableControls(picboxAddBarcode)
            EnableControls(picboxOCR)
        Else
            DisableControls(picboxSave)
            DisableAllFunctionButtons()
            dsViewer.Visible = False
            panelAnnotations.Visible = False
            DisableControls(picboxReadBarcode)
            DisableControls(picboxAddBarcode)
            DisableControls(picboxOCR)
        End If

        If imageCount > 1 Then
            EnableControls(picboxFirst)
            EnableControls(picboxLast)
            EnableControls(picboxPrevious)
            EnableControls(picboxNext)

            If currentIndex = 1 Then
                DisableControls(picboxPrevious)
                DisableControls(picboxFirst)
            End If
            If currentIndex = imageCount Then
                DisableControls(picboxNext)
                DisableControls(picboxLast)
            End If
        Else
            DisableControls(picboxFirst)
            DisableControls(picboxLast)
            DisableControls(picboxPrevious)
            DisableControls(picboxNext)
        End If
    End Sub

    Private Sub cbxLayout_SelectedIndexChanged(sender As Object, e As EventArgs)
        Select Case Me.cbxViewMode.SelectedIndex
            Case 0
                dsViewer.SetViewMode(-1, -1)
                Exit Select
            Case 1
                dsViewer.SetViewMode(2, 2)
                Exit Select
            Case 2
                dsViewer.SetViewMode(3, 3)
                Exit Select
            Case 3
                dsViewer.SetViewMode(4, 4)
                Exit Select
            Case 4
                dsViewer.SetViewMode(5, 5)
                Exit Select
            Case Else
                dsViewer.SetViewMode(-1, -1)
                Exit Select
        End Select
        checkZoom()
    End Sub

    Private Sub picboxFirst_Click(sender As Object, e As EventArgs)
        If m_ImageCore.ImageBuffer.HowManyImagesInBuffer > 0 Then
            m_ImageCore.ImageBuffer.CurrentImageIndexInBuffer = CShort(0)
        End If
        checkImageCount()
    End Sub

    Private Sub picboxLast_Click(sender As Object, e As EventArgs)
        If m_ImageCore.ImageBuffer.HowManyImagesInBuffer > 0 Then
            m_ImageCore.ImageBuffer.CurrentImageIndexInBuffer = CShort(m_ImageCore.ImageBuffer.HowManyImagesInBuffer - 1)
        End If
        checkImageCount()
    End Sub

    Private Sub picboxPrevious_Click(sender As Object, e As EventArgs)
        If m_ImageCore.ImageBuffer.HowManyImagesInBuffer > 0 AndAlso m_ImageCore.ImageBuffer.CurrentImageIndexInBuffer > 0 Then
            m_ImageCore.ImageBuffer.CurrentImageIndexInBuffer -= 1
        End If
        checkImageCount()
    End Sub

    Private Sub picboxNext_Click(sender As Object, e As EventArgs)
        If m_ImageCore.ImageBuffer.HowManyImagesInBuffer > 0 AndAlso m_ImageCore.ImageBuffer.CurrentImageIndexInBuffer < m_ImageCore.ImageBuffer.HowManyImagesInBuffer - 1 Then
            m_ImageCore.ImageBuffer.CurrentImageIndexInBuffer += 1
        End If
        checkImageCount()
    End Sub

    Private Sub cbxSource_SelectedIndexChanged(sender As Object, e As EventArgs)
        Dim sIndex As Short = CShort(DirectCast(sender, ComboBox).SelectedIndex)

        If sIndex < m_TwainManager.SourceCount Then
            panelScan.Visible = True
            panelGrab.Visible = False
            lbUnknowSource.Visible = False
            m_TwainManager.CloseSource()
            If m_Camera IsNot Nothing Then
                m_Camera.Close()
            End If
        Else
            m_Camera = m_CameraManager.SelectCamera(CShort(sIndex - m_TwainManager.SourceCount))
            If m_CameraUI Is Nothing OrElse m_CameraUI.IsDisposed Then
                m_CameraUI = New CameraUI()
                If m_CameraUI.Camera Is m_Camera Then
                    Return
                Else
                    If m_Camera IsNot Nothing Then
                        m_Camera.Close()
                    End If
                End If
            End If
            m_CameraUI.Camera = m_Camera
            m_Camera.Open()
            m_CameraUI.ClientSize = New Size(m_Camera.CurrentResolution.Width, m_Camera.CurrentResolution.Height)
            If m_CameraUI IsNot Nothing Then
                m_CameraUI.Show()
            End If
            panelScan.Visible = False
            panelGrab.Visible = True
            lbUnknowSource.Visible = False
            'Initial media type list and webcam resolution list
            cbxResolutionForWebcam.Items.Clear()
            Dim lstWebcamResolutions As List(Of CamResolution) = m_Camera.SupportedResolutions
            If lstWebcamResolutions IsNot Nothing Then
                For Each camResolution As CamResolution In lstWebcamResolutions
                    cbxResolutionForWebcam.Items.Add(camResolution.Width & " X " & camResolution.Height)
                Next
            End If
            If cbxResolutionForWebcam.Items.Count > 0 Then
                cbxResolutionForWebcam.SelectedIndex = 0
            End If
        End If
    End Sub

    Private Sub picboxTitle_MouseDown(sender As Object, e As MouseEventArgs)
        mouse_offset2 = New Point(-e.X, -e.Y)
    End Sub

    Private Sub picboxTitle_MouseMove(sender As Object, e As MouseEventArgs)
        If e.Button = MouseButtons.Left Then
            Dim mousePos As Point = Control.MousePosition
            mousePos.Offset(mouse_offset2.X, mouse_offset2.Y)
            If IsInForm(panelAnnotations.Parent.PointToClient(mousePos)) Then
                panelAnnotations.Location = panelAnnotations.Parent.PointToClient(mousePos)
            End If
        End If
    End Sub

    Private Function IsInForm(point As Point) As Boolean
        If point.X > 0 AndAlso point.X < 693 AndAlso point.Y > 35 AndAlso point.Y < 635 Then
            Return True
        End If
        Return False
    End Function

    Private Sub picboxDeleteAnnotationA_Click(sender As Object, e As EventArgs)
        Dim tempListAnnotationData As List(Of AnnotationData) = DirectCast(m_ImageCore.ImageBuffer.GetMetaData(m_ImageCore.ImageBuffer.CurrentImageIndexInBuffer, EnumMetaDataType.enumAnnotation), List(Of AnnotationData))
        If tempListAnnotationData IsNot Nothing Then
            Dim tempSelectedAnnotationData As New List(Of AnnotationData)()
            tempSelectedAnnotationData = DirectCast(m_ImageCore.ImageBuffer.GetMetaData(m_ImageCore.ImageBuffer.CurrentImageIndexInBuffer, EnumMetaDataType.enumAnnotation), List(Of AnnotationData))
            For i As Integer = tempSelectedAnnotationData.Count - 1 To 0 Step -1
                If tempSelectedAnnotationData(i).Selected = True Then
                    tempSelectedAnnotationData.RemoveAt(i)
                End If
            Next
        End If
        m_ImageCore.ImageBuffer.SetMetaData(m_ImageCore.ImageBuffer.CurrentImageIndexInBuffer, EnumMetaDataType.enumAnnotation, tempListAnnotationData, True)
    End Sub

    Private Sub picboxLoadImage_Click(sender As Object, e As EventArgs)
        openFileDialog.Filter = "All Support Files|*.JPG;*.JPEG;*.JPE;*.JFIF;*.BMP;*.PNG;*.TIF;*.TIFF;*GIF;*.PDF|JPEG|*.JPG;*.JPEG;*.JPE;*.Jfif|BMP|*.BMP|PNG|*.PNG|TIFF|*.TIF;*.TIFF|GIF|*.GIF|PDF|*.PDF"
        openFileDialog.FilterIndex = 0
        openFileDialog.Multiselect = True
        openFileDialog.FileName = ""
        If openFileDialog.ShowDialog() = DialogResult.OK Then
            For Each strFileName As String In openFileDialog.FileNames

                Dim pos As Integer = strFileName.LastIndexOf(".")
                If pos <> -1 Then
                    Dim strSuffix As String = strFileName.Substring(pos, strFileName.Length - pos).ToLower()
                    If strSuffix.CompareTo(".pdf") = 0 Then
                        m_PDFRasterizer.ConvertMode = Dynamsoft.PDF.Enums.EnumConvertMode.enumCM_RENDERALL
                        m_PDFRasterizer.ConvertToImage(strFileName, "", 200, TryCast(Me, IConvertCallback))
                    Else
                        m_ImageCore.IO.LoadImage(strFileName)
                    End If
                Else
                    m_ImageCore.IO.LoadImage(strFileName)
                End If
            Next
            dsViewer.Visible = True
        End If
        checkImageCount()
    End Sub

    Private Sub ChangeSource_MouseHover(sender As Object, e As EventArgs)
        If TypeOf sender Is Label Then
            TryCast(sender, Label).ForeColor = System.Drawing.Color.Purple
        End If
    End Sub

    Private Sub ChangeSource_MouseLeave(sender As Object, e As EventArgs)
        If TypeOf sender Is Label Then
            TryCast(sender, Label).ForeColor = System.Drawing.Color.Black
        End If
    End Sub

    Private Sub lbCloseAnnotations_MouseHover(sender As Object, e As EventArgs)
        Me.lbCloseAnnotations.ForeColor = System.Drawing.Color.Red
    End Sub

    Private Sub lbCloseAnnotations_MouseLeave(sender As Object, e As EventArgs)
        Me.lbCloseAnnotations.ForeColor = System.Drawing.Color.Black
    End Sub

    Private Sub lbCloseAnnotations_Click(sender As Object, e As EventArgs)
        Me.panelAnnotations.Visible = False
    End Sub

    Private m_thSelectedTabHead As TabHead = Nothing
    Private m_tabHeads As TabHead() = New TabHead(5) {}
    Private m_panels As Panel() = New Panel(5) {}
    Private languages As New Dictionary(Of String, String)()

    Private Sub TabHead_Click(sender As Object, e As EventArgs)
        Dim thHead As TabHead = DirectCast(sender, TabHead)
        Dim iNeighborIndex As Integer = GetNeighborIndex(thHead)
        If m_thSelectedTabHead IsNot Nothing AndAlso m_thSelectedTabHead.Index <> iNeighborIndex AndAlso m_thSelectedTabHead.Index <> thHead.Index Then
            m_thSelectedTabHead.State = TabHead.TabHeadState.ALLFOLDED
            m_panels(m_thSelectedTabHead.Index).Visible = False
            Dim iSelectHeadNeighborIndex As Integer = GetNeighborIndex(m_thSelectedTabHead)
            If iSelectHeadNeighborIndex >= 0 Then
                m_tabHeads(iSelectHeadNeighborIndex).State = TabHead.TabHeadState.ALLFOLDED

            End If
        End If

        If thHead.State = TabHead.TabHeadState.SELECTED Then
            thHead.State = TabHead.TabHeadState.ALLFOLDED
            m_panels(thHead.Index).Visible = False
            If iNeighborIndex >= 0 Then
                m_tabHeads(iNeighborIndex).State = TabHead.TabHeadState.ALLFOLDED
                m_panels(iNeighborIndex).Visible = False
            End If
            m_thSelectedTabHead = Nothing
        Else
            thHead.State = TabHead.TabHeadState.SELECTED
            m_panels(thHead.Index).Visible = True
            If iNeighborIndex >= 0 Then
                m_tabHeads(iNeighborIndex).State = TabHead.TabHeadState.FOLDED
                m_panels(iNeighborIndex).Visible = False
            End If
            m_thSelectedTabHead = thHead
        End If
    End Sub

    Private Function GetNeighborIndex(thHead As TabHead) As Integer
        If thHead IsNot Nothing AndAlso thHead.MultiTabHead Then
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

    Private Sub picboxReadBarcode_Click(sender As Object, e As EventArgs)
        If m_ImageCore.ImageBuffer.CurrentImageIndexInBuffer < 0 Then
            MessageBox.Show("Please load an image before reading barcode!", "Index out of bounds", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Try
            Dim bmp As Bitmap = CType((m_ImageCore.ImageBuffer.GetBitmap(m_ImageCore.ImageBuffer.CurrentImageIndexInBuffer)), Bitmap)
            Dim beforeRead As DateTime = DateTime.Now
            Dim Templates As String() = m_BarcodeReader.GetAllParameterTemplateNames()
            Dim bifcontian As Boolean = False

            For i As Integer = 0 To Templates.Length - 1

                If mBarcodeFormat = Templates(i) Then
                    bifcontian = True
                End If
            Next

            If Not bifcontian Then
                MessageBox.Show(("Failed to find the template named " & mBarcodeFormat & "."), "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
                Return
            End If

            Dim aryResult As TextResult() = m_BarcodeReader.DecodeBitmap(bmp, mBarcodeFormat)
            Dim afterRead As DateTime = DateTime.Now
            Dim timeElapsed As Integer = CInt((afterRead - beforeRead).TotalMilliseconds)
            m_ImageCore.ImageBuffer.SetMetaData(m_ImageCore.ImageBuffer.CurrentImageIndexInBuffer, EnumMetaDataType.enumAnnotation, Nothing, True)

            If aryResult IsNot Nothing Then
                Dim tempListAnnotation As List(Of AnnotationData) = New List(Of AnnotationData)()
                Dim i As Integer
                For i = 0 To aryResult.Length - 1
                    Dim penColor As Color = Color.Red
                    Dim rectAnnotation As AnnotationData = New AnnotationData()
                    rectAnnotation.AnnotationType = AnnotationType.enumRectangle
                    Dim boundingrect As Rectangle = ConvertLocationPointToRect(aryResult(i).LocalizationResult.ResultPoints)
                    rectAnnotation.StartPoint = New Point(boundingrect.Left, boundingrect.Top)
                    rectAnnotation.EndPoint = New Point((boundingrect.Left + boundingrect.Size.Width), (boundingrect.Top + boundingrect.Size.Height))
                    rectAnnotation.FillColor = Color.Transparent.ToArgb()
                    rectAnnotation.PenColor = penColor.ToArgb()
                    rectAnnotation.PenWidth = 3
                    rectAnnotation.GUID = Guid.NewGuid()
                    Dim fsize As Single = bmp.Width / 48.0F
                    If fsize < 25 Then fsize = 25
                    Dim textFont As Font = New Font("Times New Roman", fsize, FontStyle.Bold)
                    Dim strNo As String = "[" & (i + 1) & "]"
                    Dim textSize As SizeF = Graphics.FromHwnd(IntPtr.Zero).MeasureString(strNo, textFont)
                    Dim textAnnotation As AnnotationData = New AnnotationData()
                    textAnnotation.AnnotationType = AnnotationType.enumText
                    textAnnotation.StartPoint = New Point(boundingrect.Left, CInt((boundingrect.Top - textSize.Height * 1.25F)))
                    textAnnotation.EndPoint = New Point((textAnnotation.StartPoint.X + CInt(textSize.Width) * 2), CInt((textAnnotation.StartPoint.Y + textSize.Height * 1.25F)))

                    If textAnnotation.StartPoint.X < 0 Then
                        textAnnotation.EndPoint = New Point((textAnnotation.EndPoint.X + textAnnotation.StartPoint.X), textAnnotation.EndPoint.Y)
                        textAnnotation.StartPoint = New Point(0, textAnnotation.StartPoint.Y)
                    End If

                    If textAnnotation.StartPoint.Y < 0 Then
                        textAnnotation.EndPoint = New Point(textAnnotation.EndPoint.X, (textAnnotation.EndPoint.Y - textAnnotation.StartPoint.Y))
                        textAnnotation.StartPoint = New Point(textAnnotation.StartPoint.X, 0)
                    End If

                    textAnnotation.TextContent = strNo
                    Dim tempFont As AnnoTextFont = New AnnoTextFont()
                    tempFont.TextColor = Color.Blue.ToArgb()
                    tempFont.Size = CInt(fsize)
                    tempFont.Name = "Times New Roman"
                    textAnnotation.FontType = tempFont
                    textAnnotation.GUID = Guid.NewGuid()
                    tempListAnnotation.Add(rectAnnotation)
                    tempListAnnotation.Add(textAnnotation)
                Next

                m_ImageCore.ImageBuffer.SetMetaData(m_ImageCore.ImageBuffer.CurrentImageIndexInBuffer, EnumMetaDataType.enumAnnotation, tempListAnnotation, True)
            End If

            Me.ShowResult(aryResult, timeElapsed)
        Catch exp As Exception
            MessageBox.Show(exp.Message, "Decoding error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try
    End Sub
    Private Sub cbxBarcodeFormat_SelectedIndexChanged(sender As Object, e As EventArgs)
        Dim index As Integer = cbxBarcodeFormat.SelectedIndex
        mBarcodeFormat = mBarcodeType(index)
    End Sub
    Private Sub ShowResult(ByVal aryResult As TextResult(), ByVal timeElapsed As Integer)
        Dim strResult As String

        If aryResult Is Nothing Then
            strResult = "No barcode found. Total time spent: " & timeElapsed & " ms" & vbCrLf
        Else
            strResult = "Total barcode(s) found: " & aryResult.Length & ". Total time spent: " & timeElapsed & " ms" & vbCrLf
            Dim i As Integer
            For i = 0 To aryResult.Length - 1
                strResult += String.Format("  Barcode: {0}" & vbCrLf, (i + 1))
                strResult += String.Format("    Type: {0}" & vbCrLf, aryResult(i).BarcodeFormat.ToString())
                strResult = AddBarcodeText(strResult, aryResult(i).BarcodeText)
                strResult += vbCrLf
            Next
        End If

        MessageBox.Show(strResult, "Barcodes Results")
    End Sub
	Private Function AddBarcodeText(ByVal result As String, ByVal barcodetext As String) As String
        Dim temp As String = ""
        Dim temp1 As String = barcodetext

        For j As Integer = 0 To temp1.Length - 1

            If temp1(j) = vbNullChar Then
                temp += "\"
                temp += "0"
            Else
                temp += temp1(j).ToString()
            End If
        Next

        result += String.Format("    Value: {0}" & vbCrLf, temp)
        Return result
    End Function
    Private Function ConvertLocationPointToRect(ByVal points As Point()) As Rectangle
        Dim left As Integer = points(0).X, top As Integer = points(0).Y, right As Integer = points(1).X, bottom As Integer = points(1).Y

        For i As Integer = 0 To points.Length - 1

            If points(i).X < left Then
                left = points(i).X
            End If

            If points(i).X > right Then
                right = points(i).X
            End If

            If points(i).Y < top Then
                top = points(i).Y
            End If

            If points(i).Y > bottom Then
                bottom = points(i).Y
            End If
        Next

        Dim temp As Rectangle = New Rectangle(left, top, (right - left), (bottom - top))
        Return temp
    End Function

#End Region

#Region "Add Barcode"

    Private Sub picboxAddBarcode_Click(sender As Object, e As EventArgs)
        If picboxAddBarcode.Enabled Then
            If m_ImageCore.ImageBuffer.CurrentImageIndexInBuffer >= 0 Then
                If tbxBarcodeContent.Text <> "" AndAlso tbxBarcodeLocationX.Text <> "" AndAlso tbxBarcodeLocationY.Text <> "" AndAlso tbxBarcodeScale.Text <> "" Then
                    Dim barcodeformat As Dynamsoft.Barcode.Enums.EnumBarcodeFormat = Dynamsoft.Barcode.Enums.EnumBarcodeFormat.CODE_39
                    Select Case cbxGenBarcodeFormat.SelectedIndex
                        Case 0
                            barcodeformat = Dynamsoft.Barcode.Enums.EnumBarcodeFormat.CODE_39
                            Exit Select
                        Case 1
                            barcodeformat = Dynamsoft.Barcode.Enums.EnumBarcodeFormat.CODE_128
                            Exit Select
                        Case 2
                            barcodeformat = Dynamsoft.Barcode.Enums.EnumBarcodeFormat.PDF417
                            Exit Select
                        Case 3
                            barcodeformat = Dynamsoft.Barcode.Enums.EnumBarcodeFormat.QR_CODE
                            Exit Select
                    End Select
                    Dim bit As Bitmap
                    bit = m_BarcodeGenerator.AddBarcode(m_ImageCore.ImageBuffer.GetBitmap(m_ImageCore.ImageBuffer.CurrentImageIndexInBuffer), barcodeformat, tbxBarcodeContent.Text, tbxHumanReadableText.Text, Integer.Parse(tbxBarcodeLocationX.Text), Integer.Parse(tbxBarcodeLocationY.Text), _
                        Single.Parse(tbxBarcodeScale.Text))
                    m_ImageCore.ImageBuffer.SetBitmap(m_ImageCore.ImageBuffer.CurrentImageIndexInBuffer, bit)
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

    Private Sub tbxBarcodeLocation_KeyPress(sender As Object, e As KeyPressEventArgs)
        Dim array As Byte() = System.Text.Encoding.[Default].GetBytes(e.KeyChar.ToString())
        If Not Char.IsDigit(e.KeyChar) OrElse array.LongLength = 2 Then
            e.Handled = True
        End If
        If e.KeyChar = ControlChars.Back Then
            e.Handled = False
        End If
    End Sub

    Private Sub tbxBarcodeScale_KeyPress(sender As Object, e As KeyPressEventArgs)
        Dim array As Byte() = System.Text.Encoding.[Default].GetBytes(e.KeyChar.ToString())
        If Not Char.IsDigit(e.KeyChar) OrElse array.LongLength = 2 Then
            e.Handled = True
        End If
        If e.KeyChar = ControlChars.Back OrElse (Not tbxBarcodeScale.Text.Contains(".") AndAlso e.KeyChar = "."c) Then
            e.Handled = False
        End If
    End Sub

#End Region

#Region "Perform OCR"

    Private Sub picboxOCR_Click(sender As Object, e As EventArgs)
        If picboxOCR.Enabled Then
            If m_ImageCore.ImageBuffer.CurrentImageIndexInBuffer >= 0 Then
                m_Tesseract.Language = languages(cbxSupportedLanguage.Text)
                m_Tesseract.ResultFormat = CType(cbxOCRResultFormat.SelectedIndex, Dynamsoft.OCR.Enums.ResultFormat)
                Dim sbytes As Byte() = Nothing
                Dim templistBitmap As New List(Of Bitmap)()
                For sCount As Short = 0 To dsViewer.CurrentSelectedImageIndicesInBuffer.Count - 1
                    templistBitmap.Add(m_ImageCore.ImageBuffer.GetBitmap(dsViewer.CurrentSelectedImageIndicesInBuffer(sCount)))
                Next
                sbytes = m_Tesseract.Recognize(templistBitmap)

                If sbytes IsNot Nothing AndAlso sbytes.Length > 0 Then
                    Dim filedlg As New SaveFileDialog()
                    If cbxOCRResultFormat.SelectedIndex <> 0 Then
                        filedlg.Filter = "PDF File(*.pdf)| *.pdf"
                    Else
                        filedlg.Filter = "Text File(*.txt)| *.txt"
                    End If
                    If filedlg.ShowDialog() = DialogResult.OK Then
                        System.IO.File.WriteAllBytes(filedlg.FileName, sbytes)
                    End If
                End If
            Else
                MessageBox.Show("Please load an image before doing OCR!", "Index out of bounds", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        End If
    End Sub

#End Region

    Private Sub picboxGrab_Click(sender As Object, e As EventArgs)
        dsViewer.Visible = True
        If cbxResolutionForWebcam.Text IsNot Nothing Then
            Dim strWXH As String() = cbxResolutionForWebcam.Text.Split(New Char() {" "c})
            If strWXH.Length = 3 Then
                Try
                    m_Camera.CurrentResolution = New CamResolution(Integer.Parse(strWXH(0)), Integer.Parse(strWXH(2)))
                    If m_CameraUI IsNot Nothing AndAlso (Not m_CameraUI.IsDisposed) Then
                        m_CameraUI.ClientSize = New Size(Integer.Parse(strWXH(0)), Integer.Parse(strWXH(2)))
                    End If
                Catch
                End Try
            End If
        End If
        Dim tempbmp As Bitmap = m_Camera.GrabImage()
        m_ImageCore.IO.LoadImage(tempbmp)
        checkImageCount()
    End Sub


    Private Sub cbxResolutionForWebcam_SelectedIndexChanged(sender As Object, e As EventArgs)
        If cbxResolutionForWebcam.Text IsNot Nothing Then
            Dim strWXH As String() = cbxResolutionForWebcam.Text.Split(New Char() {" "c})
            If strWXH.Length = 3 Then
                Try
                    m_Camera.CurrentResolution = New CamResolution(Integer.Parse(strWXH(0)), Integer.Parse(strWXH(2)))
                    If m_CameraUI IsNot Nothing AndAlso (Not m_CameraUI.IsDisposed) Then
                        m_CameraUI.ClientSize = New Size(Integer.Parse(strWXH(0)), Integer.Parse(strWXH(2)))
                    End If
                Catch
                End Try
            End If
        End If
    End Sub


    Public Sub OnPostAllTransfers() Implements IAcquireCallback.OnPostAllTransfers
        Me.Invoke(New CrossThreadOperationControl(AddressOf CallMe))
    End Sub

    Public Sub CallMe()
        dsViewer.Visible = True
        checkImageCount()
        EnableControls(picboxScan)
    End Sub

    Public Function OnPostTransfer(bit As Bitmap) As Boolean Implements IAcquireCallback.OnPostTransfer
        m_ImageCore.IO.LoadImage(bit)
        Return True
    End Function

    Public Sub OnPreAllTransfers() Implements IAcquireCallback.OnPreAllTransfers
    End Sub

    Public Function OnPreTransfer() As Boolean Implements IAcquireCallback.OnPreTransfer
        Return True
    End Function

    Public Sub OnSourceUIClose() Implements IAcquireCallback.OnSourceUIClose
        EnableControls(picboxScan)
    End Sub

    Public Sub OnTransferCancelled() Implements IAcquireCallback.OnTransferCancelled
    End Sub

    Public Sub OnTransferError() Implements IAcquireCallback.OnTransferError
    End Sub

    Private Sub picboxClose_Click(sender As Object, e As EventArgs)
        If m_TwainManager IsNot Nothing Then
            m_TwainManager.Dispose()
        End If
        If m_Camera IsNot Nothing Then
            m_Camera.Close()
        End If

    End Sub

    Public Sub LoadConvertResult(result As ConvertResult) Implements IConvertCallback.LoadConvertResult
        m_ImageCore.IO.LoadImage(result.Image)
        m_ImageCore.ImageBuffer.SetMetaData(m_ImageCore.ImageBuffer.CurrentImageIndexInBuffer, EnumMetaDataType.enumAnnotation, result.Annotations, True)
    End Sub

    Public Function GetAnnotations(iPageNumber As Integer) As Object Implements ISave.GetAnnotations
        If chkMultiPage.Checked = True Then
            Return m_ImageCore.ImageBuffer.GetMetaData(CShort(iPageNumber), EnumMetaDataType.enumAnnotation)
        Else
            Return m_ImageCore.ImageBuffer.GetMetaData(m_ImageCore.ImageBuffer.CurrentImageIndexInBuffer, EnumMetaDataType.enumAnnotation)
        End If
    End Function

    Public Function GetImage(iPageNumber As Integer) As Bitmap Implements ISave.GetImage
        If chkMultiPage.Checked = True Then
            Return m_ImageCore.ImageBuffer.GetBitmap(CShort(iPageNumber))
        Else
            Return m_ImageCore.ImageBuffer.GetBitmap(m_ImageCore.ImageBuffer.CurrentImageIndexInBuffer)
        End If
    End Function

    Public Function GetPageCount() As Integer Implements ISave.GetPageCount
        If chkMultiPage.Checked = True Then
            Return m_ImageCore.ImageBuffer.HowManyImagesInBuffer
        Else
            Return 1
        End If
    End Function

    Private Sub dsViewer_OnImageAreaDeselected(sImageIndex As Short)
        If isToCrop Then
            isToCrop = False
        End If
        EnableAllFunctionButtons()
    End Sub

    Private Sub dsViewer_OnImageAreaSelected(sImageIndex As Short, left As Integer, top As Integer, right As Integer, bottom As Integer)
    End Sub

    Private Sub dsViewer_OnMouseClick(sImageIndex As Short)
        If m_ImageCore.ImageBuffer.CurrentImageIndexInBuffer <> currentImageIndex Then
            checkImageCount()
        End If
    End Sub

    Private Sub dsViewer_OnMouseDoubleClick(sImageIndex As Short)
        Try
            Dim rc As Rectangle = dsViewer.GetSelectionRect(sImageIndex)

            If isToCrop AndAlso Not rc.IsEmpty Then
                cropPicture(sImageIndex, rc)
            End If
            isToCrop = False
        Catch
        End Try
        EnableAllFunctionButtons()
    End Sub

    Private Sub dsViewer_OnMouseRightClick(sImageIndex As Short)
        If isToCrop Then
            isToCrop = False
        End If
        dsViewer.ClearSelectionRect(sImageIndex)
        EnableAllFunctionButtons()
    End Sub

End Class

