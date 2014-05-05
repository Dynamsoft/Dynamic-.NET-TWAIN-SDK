Imports System.IO
Imports System.Threading
Public Class ScanForm
    Dim _tranferedFileName As String
    Dim _isScanning As Boolean

    Public Property IsScanning()
        Get
            Return _isScanning
        End Get
        Set(ByVal value)
            _isScanning = value
        End Set
    End Property


    Dim _viewer As MainForm
    Public ReadOnly Property Viewer()
        Get
            Return _viewer
        End Get
    End Property


    Sub New(ByVal viewer As MainForm)
        'Store pointer to the main app 
        If Not viewer Is Nothing Then
            _viewer = viewer
        End If

        'Don't want this window showing.
        Me.Visible = False

        InitializeComponent()
    End Sub


    Delegate Sub ScanDelegate()
    Public Sub StartScan()
        Trace.WriteLine(String.Format("thread id {0}: StartScan", Thread.CurrentThread.ManagedThreadId))
        _isScanning = True
        If (Me.InvokeRequired = True) Then
            Dim iar As IAsyncResult
            iar = Me.BeginInvoke(New ScanDelegate(AddressOf Scan))
        Else
            Scan()
        End If
    End Sub

    Private Sub Scan()
        Trace.WriteLine(String.Format("thread id {0}: Scan", Thread.CurrentThread.ManagedThreadId))
        dynamicDotNetTwain1.SetViewMode(1, 1)

        If (dynamicDotNetTwain1.SelectSource() = True) Then
            dynamicDotNetTwain1.TransferMode = Dynamsoft.DotNet.TWAIN.Enums.TWICapSetupXFer.TWSX_FILE

            dynamicDotNetTwain1.OpenSource()

            Dim scanPath As String
            scanPath = Path.GetFullPath(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "..\\Temp"))
            If (Directory.Exists(scanPath) = False) Then
                Directory.CreateDirectory(scanPath)
            End If

            Dim fileName As String
            fileName = Path.Combine(scanPath, String.Format("{0}.bmp", DateTime.UtcNow.Ticks))
            If (dynamicDotNetTwain1.SetFileXFERInfo(fileName, Dynamsoft.DotNet.TWAIN.Enums.TWICapFileFormat.TWFF_BMP) = True) Then
                _tranferedFileName = fileName
            Else
                _tranferedFileName = Nothing
            End If

            dynamicDotNetTwain1.JPEGQuality = 60
            dynamicDotNetTwain1.XferCount = -1
            dynamicDotNetTwain1.IfAutoFeed = True
            dynamicDotNetTwain1.IfAutoScan = True
            dynamicDotNetTwain1.IfDuplexEnabled = True
            'dynamicDotNetTwain1.IfFeederEnabled = true
            dynamicDotNetTwain1.IfDisableSourceAfterAcquire = True
            dynamicDotNetTwain1.IfShowIndicator = False
            dynamicDotNetTwain1.IfShowCancelDialogWhenImageTransfer = False
            dynamicDotNetTwain1.IfShowUI = True

            If (dynamicDotNetTwain1.EnableSource() = False) Then
                Trace.WriteLine(String.Format("Failed to start scanning: ({0}) {1}", dynamicDotNetTwain1.ErrorCode, dynamicDotNetTwain1.ErrorString))
                _isScanning = False
            Else
                _isScanning = True
            End If
        End If
    End Sub

    Private Sub StopScan()

    End Sub


    Private Sub dynamicDotNetTwain1_OnPostAllTransfers() Handles dynamicDotNetTwain1.OnPostAllTransfers
        _isScanning = False
    End Sub

    Private Sub dynamicDotNetTwain1_OnPreTransfer() Handles dynamicDotNetTwain1.OnPreTransfer

    End Sub

    Private Sub dynamicDotNetTwain1_OnPostTransfer() Handles dynamicDotNetTwain1.OnPostTransfer
        'if (String.IsNullOrWhiteSpace(_tranferedFileName) == false &&
        If ((Not _tranferedFileName Is Nothing) And (_tranferedFileName.Length <> 0) And (File.Exists(_tranferedFileName))) Then
            _viewer.LoadImage(_tranferedFileName)
        End If
    End Sub

    Private Sub dynamicDotNetTwain1_OnTransferCancelled() Handles dynamicDotNetTwain1.OnTransferCancelled
        Me.IsScanning = False
    End Sub

    Private Sub dynamicDotNetTwain1_OnTransferError() Handles dynamicDotNetTwain1.OnTransferError
        Dim msg As String
        msg = String.Format("Error Code ({0}): {1}", dynamicDotNetTwain1.ErrorCode, dynamicDotNetTwain1.ErrorString)
    End Sub
End Class