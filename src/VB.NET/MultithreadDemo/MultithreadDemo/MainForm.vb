Imports System.Threading
Imports System.Collections.Generic
Public Class MainForm

    Dim _scanControl As ScanForm
    Sub New()

        InitializeComponent()
        dynamicDotNetTwain1.MaxImagesInBuffer = 100
        dynamicDotNetTwain1.SetViewMode(2, 1)

        ' Create the scanning thread
        ThreadPool.QueueUserWorkItem(New WaitCallback(AddressOf acquireImageInThread), Me)
    End Sub


    Dim _imagesToLoad As List(Of String)
    Dim _syncObject As New Object
    Private Sub acquireImageInThread(ByVal obj As Object)
        Trace.WriteLine(String.Format("thread id {0}: acquireImageInThread", Thread.CurrentThread.ManagedThreadId))
        Dim fm1 As MainForm
        fm1 = obj

        Thread.CurrentThread.Name = "Scanning"
        If Not fm1 Is Nothing Then
            Dim fm2 As ScanForm
            fm2 = New ScanForm(fm1)

            fm1._scanControl = fm2

            fm2.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
            fm2.WindowState = FormWindowState.Minimized
            fm2.ShowInTaskbar = False
            fm2.Size = New Size(0, 0)
            fm2.ShowDialog()
        End If
    End Sub
    Delegate Sub LoadImageDelegate1(ByVal fileName As String)
    Delegate Sub LoadImageDelegate(ByVal fileName As String, ByVal reserved As Object)
    Public Sub LoadImage(ByVal fileName As String)
        Trace.WriteLine(String.Format("thread id {0}: LoadImage", Thread.CurrentThread.ManagedThreadId))

        'If this is uncommented, the while loop lin 66 must be uncommented
        ' and the code at line 125 must be commented
        'lock (_syncObject)
        '{
        '   _imagesToLoad.Add(fileName);

        '}

        If (Me.InvokeRequired = True) Then
            Dim iar As IAsyncResult
            iar = Me.BeginInvoke(New LoadImageDelegate(AddressOf LoadImage2), fileName, Nothing)
        Else
            'should never reach this code.
            LoadImage2(fileName, Nothing)
        End If

    End Sub

    Private Sub LoadImage2(ByVal fileName As String, ByVal reserved As Object)
        Trace.WriteLine(String.Format("thread id {0}: LoadImage", Thread.CurrentThread.ManagedThreadId))

        dynamicDotNetTwain1.LoadImage(fileName)
    End Sub

    Private Sub LoadImageBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LoadImageBtn.Click
        Dim dlg As New OpenFileDialog
        dlg.Filter = "All Support Files|*.JPG;*.JPEG;*.JPE;*.JFIF;*.BMP;*.PNG;*.TIF;*.TIFF;*.PDF|JPEG|*.JPG;*.JPEG;*.JPE;*.Jfif|BMP|*.BMP|PNG|*.PNG|TIFF|*.TIF;*.TIFF|PDF|*.PDF"
        Dim res As DialogResult
        res = dlg.ShowDialog()
        If (res = System.Windows.Forms.DialogResult.OK) Then
            dynamicDotNetTwain1.LoadImage(dlg.FileName)
        End If
    End Sub

    Private Sub ScanBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ScanBtn.Click
        Trace.WriteLine(String.Format("thread id {0}: ScanClick", Thread.CurrentThread.ManagedThreadId))


        If _imagesToLoad Is Nothing Then
            _imagesToLoad = New List(Of String)()
        ElseIf _imagesToLoad.Count <> 0 Then
            _imagesToLoad.Clear()
        End If


        If Not _scanControl Is Nothing Then
            _scanControl.StartScan()
        End If
    End Sub
End Class
