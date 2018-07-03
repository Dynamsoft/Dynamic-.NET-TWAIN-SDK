Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Data
Imports System.Windows.Documents
Imports System.Windows.Input
Imports System.Windows.Media
Imports System.Windows.Media.Imaging
Imports System.Windows.Navigation
Imports System.Windows.Shapes
Imports Microsoft.Win32
Imports Dynamsoft.Barcode
Imports System.Runtime.InteropServices
Imports System.IO
Imports Dynamsoft.Core
Imports Dynamsoft.WPF.Delegate
Imports Dynamsoft.TWAIN
Imports Dynamsoft.PDF
Imports Dynamsoft.Core.Enums
Imports Dynamsoft.OCR
Imports System.Drawing

''' <summary>
''' Interaction logic for Window1.xaml
''' </summary>

Namespace WpfControlsDemo

    Partial Public Class Window1
        Inherits Window
        Implements IConvertCallback
        Shared Sub New()

            Dim index As Integer = System.Reflection.Assembly.GetExecutingAssembly().Location.IndexOf("Samples")
            If index <> -1 Then
                strCurrentDirectory = System.Reflection.Assembly.GetExecutingAssembly().Location.Substring(0, index)
                imageDirectory = strCurrentDirectory & "Samples\Bin\Images\WpfDemoImages\"

                strTessdataDirectory = strCurrentDirectory & "Samples\Bin\tessdata"
                mSettingsPath = strCurrentDirectory & "Samples\Bin\Templates\"
            Else
                index = System.Reflection.Assembly.GetExecutingAssembly().Location.LastIndexOf("\")
                If index <> -1 Then
                    strCurrentDirectory = System.Reflection.Assembly.GetExecutingAssembly().Location.Substring(0, index + 1)
                Else
                    strCurrentDirectory = Environment.CurrentDirectory & "\"
                End If
                imageDirectory = strCurrentDirectory & "Images\WpfDemoImages\"
            End If
        End Sub

        Private m_CoreForImageThum As ImageCore = Nothing
        Private m_CoreForImageViewer As ImageCore = Nothing
        Private m_StrProductKey As String
        Public Sub New()
            InitializeComponent()
            m_StrProductKey = "t0068UwAAAEQABDxqjGfgEzhVYureL0kGxugcsvIqCDGTPTsR5nLaQsNupIc17Y5vpMZAWBDsd6Xw3NMYzdHlHwiKUrfe/cU="
            m_CoreForImageViewer = New ImageCore()
            m_CoreForImageThum = New ImageCore()
            m_TwainManager = New TwainManager(m_StrProductKey)
            dsViewer.Bind(m_CoreForImageViewer)
            dsViewerThum.Bind(m_CoreForImageThum)
            m_PDFRasterizer = New PDFRasterizer(m_StrProductKey)
            m_PDFCreator = New PDFCreator(m_StrProductKey)
            m_Tesseract = New Tesseract(m_StrProductKey)

            Try
                dpTitle.Background = New ImageBrush(New BitmapImage(New Uri(imageDirectory & "title.png", UriKind.RelativeOrAbsolute)))
                Dim ibd As New IconBitmapDecoder(New Uri(imageDirectory & "dnt_demo_icon.ico", UriKind.RelativeOrAbsolute), BitmapCreateOptions.None, BitmapCacheOption.[Default])
                Me.Icon = ibd.Frames(0)
            Catch
            End Try
            AddHandler dpTitle.MouseLeftButtonDown, New MouseButtonEventHandler(AddressOf MoveWindow)

            dsViewerThum.MouseShape = True
            dsViewerThum.SetViewMode(1, 4)
            dsViewerThum.AllowMultiSelect = True
            AddHandler dsViewerThum.OnMouseClick, New OnMouseClickHandler(AddressOf dsViewerThum_OnMouseClick)
            dsViewerThum.EnableKeyboardInteractive = False
            AddHandler dsViewerThum.OnViewerKeyDown, New KeyEventHandler(AddressOf dsViewerThum_OnViewerKeyDown)
            Dim dynamicDotNetTwainDirectory As String = strCurrentDirectory
            Dim index As Integer = System.Reflection.Assembly.GetExecutingAssembly().Location.IndexOf("Samples")

            dsViewer.MouseShape = False
            dsViewer.SetViewMode(-1, -1)
            m_CoreForImageViewer.ImageBuffer.MaxImagesInBuffer = 1
        End Sub



        Public Shared icons As Dictionary(Of [String], ImageBrush) = New Dictionary(Of String, ImageBrush)()
        Public Shared ReadOnly imageDirectory As String
        Public Shared ReadOnly strCurrentDirectory As String
        Public Shared ReadOnly strTessdataDirectory As String
        Public Shared ReadOnly mSettingsPath As String

        Private Sub Button_MouseEnter(sender As Object, e As MouseEventArgs)
            Dim btn As Button = DirectCast(sender, Button)

            If btn.Name = "btnHand" AndAlso dsViewer.MouseShape Then
                Return
            ElseIf btn.Name = "btnArrow" AndAlso Not dsViewer.MouseShape Then
                Return
            End If

            Dim key As String = "hover/" & Convert.ToString(btn.Tag)
            If Not icons.ContainsKey(key) Then
                Try
                    icons.Add(key, New ImageBrush(New BitmapImage(New Uri(imageDirectory & key & ".png", UriKind.RelativeOrAbsolute))))
                Catch
                End Try
            End If
            Try
                btn.Background = icons(key)
            Catch
            End Try
        End Sub

        Private Sub Button_MouseLeave(sender As Object, e As MouseEventArgs)
            Dim btn As Button = DirectCast(sender, Button)

            If btn.Name = "btnHand" AndAlso dsViewer.MouseShape Then
                Return
            ElseIf btn.Name = "btnArrow" AndAlso Not dsViewer.MouseShape Then
                Return
            End If

            Dim key As String = "normal/" & Convert.ToString(btn.Tag)
            If Not icons.ContainsKey(key) Then
                Try
                    icons.Add(key, New ImageBrush(New BitmapImage(New Uri(imageDirectory & key & ".png", UriKind.RelativeOrAbsolute))))
                Catch
                End Try
            End If
            Try
                btn.Background = icons(key)
            Catch
            End Try
        End Sub

        Private Sub Button_Loaded(sender As Object, e As RoutedEventArgs)
            Button_MouseLeave(sender, Nothing)

            Dim btn As Button = DirectCast(sender, Button)
            If btn.Name = "btnHand" AndAlso dsViewer.MouseShape Then
                Dim args As New MouseButtonEventArgs(Mouse.PrimaryDevice, 0, MouseButton.Left)
                args.RoutedEvent = Button.PreviewMouseDownEvent
                Button_PreviewMouseDown(sender, args)

                Dim argsA As New MouseEventArgs(Mouse.PrimaryDevice, 0)
                argsA.RoutedEvent = Button.MouseLeaveEvent
                Button_MouseLeave(btnArrow, argsA)
            ElseIf btn.Name = "btnArrow" AndAlso Not dsViewer.MouseShape Then
                Dim args As New MouseButtonEventArgs(Mouse.PrimaryDevice, 0, MouseButton.Left)
                args.RoutedEvent = Button.PreviewMouseDownEvent
                Button_PreviewMouseDown(sender, args)

                Dim argsA As New MouseEventArgs(Mouse.PrimaryDevice, 0)
                argsA.RoutedEvent = Button.MouseLeaveEvent
                Button_MouseLeave(btnHand, argsA)
            End If
        End Sub

        Private Sub Button_PreviewMouseDown(sender As Object, e As MouseButtonEventArgs)
            If e.ChangedButton = MouseButton.Left Then
                Dim btn As Button = DirectCast(sender, Button)
                Dim key As String = "active/" & Convert.ToString(btn.Tag)
                If Not icons.ContainsKey(key) Then
                    Try
                        icons.Add(key, New ImageBrush(New BitmapImage(New Uri(imageDirectory & key & ".png", UriKind.RelativeOrAbsolute))))
                    Catch
                    End Try
                End If
                Try
                    btn.Background = icons(key)
                Catch
                End Try
            End If
        End Sub

        Private Sub Button_PreviewMouseUp(sender As Object, e As MouseButtonEventArgs)
            Button_MouseLeave(sender, Nothing)
        End Sub

        Private Sub CloseWindow(sender As Object, e As RoutedEventArgs)
            Me.Close()
            m_TwainManager.Dispose()
        End Sub

        Private Sub MaxWindow(sender As Object, e As RoutedEventArgs)
            If WindowState = WindowState.Maximized Then
                WindowState = WindowState.Normal
            ElseIf WindowState = WindowState.Normal Then
                WindowState = WindowState.Maximized
            End If
        End Sub

        Private Sub MinWindow(sender As Object, e As RoutedEventArgs)
            WindowState = WindowState.Minimized
        End Sub

        Private Sub MoveWindow(sender As Object, e As MouseButtonEventArgs)
            DragMove()
        End Sub

        Private Sub UpdateImageInfo()
            If m_CoreForImageThum.ImageBuffer.CurrentImageIndexInBuffer >= 0 Then
                If m_CoreForImageViewer.ImageBuffer.CurrentImageIndexInBuffer < 0 Then
                    m_CoreForImageViewer.IO.LoadImage(m_CoreForImageThum.ImageBuffer.GetBitmap(m_CoreForImageThum.ImageBuffer.CurrentImageIndexInBuffer))
                Else
                    m_CoreForImageViewer.ImageBuffer.SetBitmap(m_CoreForImageViewer.ImageBuffer.CurrentImageIndexInBuffer, m_CoreForImageThum.ImageBuffer.GetBitmap(m_CoreForImageThum.ImageBuffer.CurrentImageIndexInBuffer))
                End If
            End If

            tbCurrent.Text = (m_CoreForImageThum.ImageBuffer.CurrentImageIndexInBuffer + 1).ToString()
            tbAll.Text = m_CoreForImageThum.ImageBuffer.HowManyImagesInBuffer.ToString()
        End Sub

        Private Sub dsViewerThum_OnViewerKeyDown(sender As Object, e As KeyEventArgs)
            Select Case e.Key
                Case Key.PageDown, Key.PageUp, Key.Home, Key.[End], Key.Left, Key.Right, _
                    Key.Up, Key.Down
                    UpdateImageInfo()
                    Exit Select
                Case Else
                    Exit Select
            End Select
        End Sub

        Private Sub dsViewerThum_OnMouseClick(sender As Object, e As OnMouseClickEventArgs)
            UpdateImageInfo()
        End Sub

        Private Sub dynamicDotNetTwainThum_OnPostAllTransfers(sender As Object, e As RoutedEventArgs)
            UpdateImageInfo()
        End Sub

        Private m_TwainManager As TwainManager = Nothing
        Private Sub Scan_Click(sender As Object, e As RoutedEventArgs)
            If m_TwainManager.SourceCount > 0 Then
                Dim scanWnd As New ScanWindow()
                scanWnd.Owner = Me
                scanWnd.TWAIN = m_TwainManager
                scanWnd.CoreForImageThum = m_CoreForImageThum
                scanWnd.SetTotalImageTextBox(tbAll)
                scanWnd.SetCurrentImageTextBox(tbCurrent)
                scanWnd.CoreForImageViewer = m_CoreForImageViewer
                scanWnd.WindowStartupLocation = WindowStartupLocation.CenterOwner
                scanWnd.ShowDialog()
            Else
                MessageBox.Show("There is no scan source!", "Scan Warning", MessageBoxButton.OK, MessageBoxImage.Warning)
            End If
        End Sub

        Private m_PDFRasterizer As PDFRasterizer = Nothing
        Private m_PDFCreator As PDFCreator = Nothing
        Private Sub Load_Click(sender As Object, e As RoutedEventArgs)
            Dim dlg As New OpenFileDialog()
            dlg.Filter = "All Supported Files(*.jpg;*.jpe;*.jpeg;*.jfif;*.bmp;*.png;*.tif;*.tiff;*.pdf;*.gif)|*.jpg;*.jpe;*.jpeg;*.jfif;*.bmp;*.png;*.tif;*.tiff;*.pdf;*.gif|JPEG(*.jpg;*.jpeg;*.jpe;*.jfif)|*.jpg;*.jpeg;*.jpe;*.jfif|BMP(*.bmp)|*.bmp|PNG(*.png)|*.png|TIFF(*.tif;*.tiff)|*.tif;*.tiff|PDF(*.pdf)|*.pdf|GIF(*.gif)|*.gif"
            dlg.Multiselect = True
            If dlg.ShowDialog().Value Then
                For Each strFileName As [String] In dlg.FileNames
                    Dim pos As Integer = strFileName.LastIndexOf(".")
                    If pos <> -1 Then
                        Dim strSuffix As String = strFileName.Substring(pos, strFileName.Length - pos).ToLower()
                        If strSuffix.CompareTo(".pdf") = 0 Then
                            m_PDFRasterizer.ConvertMode = Dynamsoft.PDF.Enums.EnumConvertMode.enumCM_RENDERALL
                            m_PDFRasterizer.ConvertToImage(strFileName, "", 200, TryCast(Me, IConvertCallback))
                            Continue For
                        End If
                    End If
                    m_CoreForImageThum.IO.LoadImage(strFileName)
                Next
                UpdateImageInfo()
            End If
        End Sub

        Private Sub Barcode_Click(sender As Object, e As RoutedEventArgs)
            If m_CoreForImageThum.ImageBuffer.HowManyImagesInBuffer > 0 Then

                Try
                    Dim m_BarcodeReader As BarcodeReader = New BarcodeReader()
                    m_BarcodeReader.LicenseKeys = m_StrProductKey
                    m_BarcodeReader.LoadSettingsFromFile(mSettingsPath & "template_aggregation.json")
                    Dim bmp As Bitmap = CType((m_CoreForImageThum.ImageBuffer.GetBitmap(m_CoreForImageThum.ImageBuffer.CurrentImageIndexInBuffer)), Bitmap)
                    Dim beforeRead As DateTime = DateTime.Now
                    Dim aryResult As TextResult() = m_BarcodeReader.DecodeBitmap(bmp, "All_DEFAULT")
                    Dim afterRead As DateTime = DateTime.Now
                    Dim timeElapsed As Integer = CInt((afterRead - beforeRead).TotalMilliseconds)
                    Me.ShowResult(aryResult, timeElapsed)
                Catch exp As Exception
                    MessageBox.Show(exp.Message, "Decoding Error", MessageBoxButton.OK, MessageBoxImage.[Error])
                End Try
            End If
        End Sub
        Private Sub ShowResult(aryResult As TextResult(), timeElapsed As Integer)
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
        Private Function AddBarcodeText(result As String, barcodetext As String) As String
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

        Private Function ConvertLocationPointToRect(points As System.Drawing.Point()) As System.Drawing.Rectangle
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

            Dim temp As System.Drawing.Rectangle = New System.Drawing.Rectangle(left, top, (right - left), (bottom - top))
            Return temp
        End Function

        Private m_Tesseract As Tesseract = Nothing
        Private Sub OCR_Click(sender As Object, e As RoutedEventArgs)
            If dsViewerThum.CurrentSelectedImageIndicesInBuffer.Count > 1 OrElse (dsViewerThum.CurrentSelectedImageIndicesInBuffer.Count = 1 AndAlso dsViewerThum.CurrentSelectedImageIndicesInBuffer(0) >= 0) Then
                m_Tesseract.ResultFormat = Dynamsoft.OCR.Enums.ResultFormat.Text
                m_Tesseract.Language = "eng"
                m_Tesseract.TessDataPath = strTessdataDirectory
                Dim tempListIndex As List(Of Short) = dsViewerThum.CurrentSelectedImageIndicesInBuffer
                Dim tempListBitmap As List(Of Bitmap) = Nothing
                If tempListIndex IsNot Nothing Then
                    If tempListBitmap Is Nothing Then
                        tempListBitmap = New List(Of Bitmap)()
                    End If
                    For Each sIndex As Short In tempListIndex
                        tempListBitmap.Add(m_CoreForImageThum.ImageBuffer.GetBitmap(sIndex))
                    Next
                End If
                Dim bytes As Byte() = m_Tesseract.Recognize(tempListBitmap)
                If bytes IsNot Nothing Then
                    Dim dlg As New SaveFileDialog()
                    dlg.Filter = "Text File(*.txt)|*.txt"
                    If dlg.ShowDialog().Value Then
                        System.IO.File.WriteAllBytes(dlg.FileName, bytes)
                    End If
                End If
            End If
        End Sub

        Private Sub Hand_Click(sender As Object, e As RoutedEventArgs)
            dsViewer.MouseShape = True
            Dim args As New MouseButtonEventArgs(Mouse.PrimaryDevice, 0, MouseButton.Left)
            args.RoutedEvent = Button.PreviewMouseDownEvent
            Button_PreviewMouseDown(sender, args)

            Dim argsA As New MouseEventArgs(Mouse.PrimaryDevice, 0)
            argsA.RoutedEvent = Button.MouseLeaveEvent
            Button_MouseLeave(btnArrow, argsA)
        End Sub

        Private Sub Arrow_Click(sender As Object, e As RoutedEventArgs)
            dsViewer.MouseShape = False

            Dim args As New MouseButtonEventArgs(Mouse.PrimaryDevice, 0, MouseButton.Left)
            args.RoutedEvent = Button.PreviewMouseDownEvent
            Button_PreviewMouseDown(sender, args)

            Dim argsA As New MouseEventArgs(Mouse.PrimaryDevice, 0)
            argsA.RoutedEvent = Button.MouseLeaveEvent
            Button_MouseLeave(btnHand, argsA)
        End Sub

        Private Sub Zoom_Click(sender As Object, e As RoutedEventArgs)
            Dim zoomWnd As New ZoomWindow(dsViewer.Zoom)
            zoomWnd.Owner = Me
            If zoomWnd.ShowDialog().Value Then
                dsViewer.Zoom = zoomWnd.ZoomRatio
            End If
        End Sub

        Private Sub Switch_Click(sender As Object, e As RoutedEventArgs)

            If dsViewerThum.CurrentSelectedImageIndicesInBuffer.Count <> 2 Then
                MessageBox.Show("Please select two images before switching. You can select multiple images by pressing CTRL key and clicking mouse.", "switch warning", MessageBoxButton.OK, MessageBoxImage.Warning)
            Else
                m_CoreForImageThum.ImageBuffer.SwitchImage(CShort(dsViewerThum.CurrentSelectedImageIndicesInBuffer(0)), CShort(dsViewerThum.CurrentSelectedImageIndicesInBuffer(1)))

                UpdateImageInfo()
            End If
        End Sub

        Private Sub RotateRight_Click(sender As Object, e As RoutedEventArgs)
            If m_CoreForImageThum.ImageBuffer.CurrentImageIndexInBuffer >= 0 Then
                m_CoreForImageThum.ImageProcesser.RotateRight(m_CoreForImageThum.ImageBuffer.CurrentImageIndexInBuffer)
            End If
            UpdateImageInfo()
        End Sub

        Private Sub RotateLeft_Click(sender As Object, e As RoutedEventArgs)
            If m_CoreForImageThum.ImageBuffer.CurrentImageIndexInBuffer >= 0 Then
                m_CoreForImageThum.ImageProcesser.RotateLeft(m_CoreForImageThum.ImageBuffer.CurrentImageIndexInBuffer)
                UpdateImageInfo()
            End If
        End Sub

        Private Sub Mirror_Click(sender As Object, e As RoutedEventArgs)
            If m_CoreForImageThum.ImageBuffer.CurrentImageIndexInBuffer >= 0 Then
                m_CoreForImageThum.ImageProcesser.Mirror(m_CoreForImageThum.ImageBuffer.CurrentImageIndexInBuffer)
                UpdateImageInfo()
            End If
        End Sub

        Private Sub Flip_Click(sender As Object, e As RoutedEventArgs)
            If m_CoreForImageThum.ImageBuffer.CurrentImageIndexInBuffer >= 0 Then
                m_CoreForImageThum.ImageProcesser.Flip(m_CoreForImageThum.ImageBuffer.CurrentImageIndexInBuffer)
                UpdateImageInfo()
            End If
        End Sub

        Private Sub FitWindow_Click(sender As Object, e As RoutedEventArgs)
            dsViewer.IfFitWindow = True
        End Sub

        Private Sub OriginalSize_Click(sender As Object, e As RoutedEventArgs)
            dsViewer.Zoom = 1
            dsViewer.IfFitWindow = False
        End Sub

        Private Sub Cut_Click(sender As Object, e As RoutedEventArgs)
            Dim index As Short = m_CoreForImageThum.ImageBuffer.CurrentImageIndexInBuffer
            If index >= 0 Then
                Dim rect As Rect = dsViewer.GetSelectionRect(m_CoreForImageViewer.ImageBuffer.CurrentImageIndexInBuffer)
                If rect.Height <> 0 AndAlso rect.Width <> 0 Then
                    m_CoreForImageThum.ImageProcesser.CutFrameToClipborad(index, CInt(Math.Truncate(rect.Left)), CInt(Math.Truncate(rect.Top)), CInt(Math.Truncate(rect.Right)), CInt(Math.Truncate(rect.Bottom)))
                    UpdateImageInfo()
                End If
            End If
        End Sub


        Private Sub Crop_Click(sender As Object, e As RoutedEventArgs)
            Dim index As Short = m_CoreForImageThum.ImageBuffer.CurrentImageIndexInBuffer
            If index >= 0 Then
                Dim rect As System.Windows.Rect = dsViewer.GetSelectionRect(m_CoreForImageViewer.ImageBuffer.CurrentImageIndexInBuffer)
                If rect.Height <> 0 AndAlso rect.Width <> 0 Then
                    m_CoreForImageThum.ImageProcesser.Crop(index, CInt(Math.Truncate(rect.Left)), CInt(Math.Truncate(rect.Top)), CInt(Math.Truncate(rect.Right)), CInt(Math.Truncate(rect.Bottom)))
                    UpdateImageInfo()

                End If

            End If
        End Sub

        Private Sub Delete_Click(sender As Object, e As RoutedEventArgs)
            Dim index As Short = m_CoreForImageThum.ImageBuffer.CurrentImageIndexInBuffer
            If index >= 0 Then
                m_CoreForImageThum.ImageBuffer.RemoveImage(index)
                m_CoreForImageViewer.ImageBuffer.RemoveAllImages()
                UpdateImageInfo()
            End If
        End Sub

        Private Sub DeleteAll_Click(sender As Object, e As RoutedEventArgs)
            If m_CoreForImageThum.ImageBuffer.HowManyImagesInBuffer > 0 Then
                m_CoreForImageThum.ImageBuffer.RemoveAllImages()
            End If
            If m_CoreForImageViewer.ImageBuffer.HowManyImagesInBuffer > 0 Then
                m_CoreForImageViewer.ImageBuffer.RemoveAllImages()
            End If
            UpdateImageInfo()
        End Sub

        Private Sub First_Click(sender As Object, e As RoutedEventArgs)
            If m_CoreForImageThum.ImageBuffer.HowManyImagesInBuffer > 0 Then
                m_CoreForImageThum.ImageBuffer.CurrentImageIndexInBuffer = CShort(0)
                UpdateImageInfo()
            End If
        End Sub

        Private Sub Previous_Click(sender As Object, e As RoutedEventArgs)
            If m_CoreForImageThum.ImageBuffer.CurrentImageIndexInBuffer > 0 Then
                m_CoreForImageThum.ImageBuffer.CurrentImageIndexInBuffer = CShort(m_CoreForImageThum.ImageBuffer.CurrentImageIndexInBuffer - 1)
                UpdateImageInfo()
            End If
        End Sub

        Private Sub Next_Click(sender As Object, e As RoutedEventArgs)
            If m_CoreForImageThum.ImageBuffer.CurrentImageIndexInBuffer < m_CoreForImageThum.ImageBuffer.HowManyImagesInBuffer - 1 Then
                m_CoreForImageThum.ImageBuffer.CurrentImageIndexInBuffer = CShort(m_CoreForImageThum.ImageBuffer.CurrentImageIndexInBuffer + 1)
                UpdateImageInfo()
            End If
        End Sub

        Private Sub Last_Click(sender As Object, e As RoutedEventArgs)
            If m_CoreForImageThum.ImageBuffer.HowManyImagesInBuffer > 0 Then
                m_CoreForImageThum.ImageBuffer.CurrentImageIndexInBuffer = CShort(m_CoreForImageThum.ImageBuffer.HowManyImagesInBuffer - 1)
                UpdateImageInfo()
            End If
        End Sub

        Private Sub Save_Click(sender As Object, e As RoutedEventArgs)
            Try
                Dim saveWnd As New SaveWindow()
                saveWnd.Owner = Me
                saveWnd.Core = m_CoreForImageThum
                saveWnd.PDFCreator = m_PDFCreator
                saveWnd.WindowStartupLocation = WindowStartupLocation.CenterOwner
                saveWnd.ShowDialog()
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try

        End Sub

#Region "IConvertCallback Members"

        Public Sub LoadConvertResult(result As ConvertResult) Implements IConvertCallback.LoadConvertResult
            m_CoreForImageThum.IO.LoadImage(result.Image)
        End Sub

#End Region

    End Class

End Namespace


