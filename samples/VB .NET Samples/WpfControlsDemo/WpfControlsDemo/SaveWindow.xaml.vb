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
Imports System.Windows.Shapes
Imports Dynamsoft.Core
Imports Dynamsoft.PDF
Imports Dynamsoft.Core.Enums


''' <summary>
''' Interaction logic for SaveWindow.xaml
''' </summary>
Namespace WpfControlsDemo
    Partial Public Class SaveWindow
        Inherits Window
        Implements ISave
        Public Sub New()
            InitializeComponent()
            Try
                lbSave.Background = New ImageBrush(New BitmapImage(New Uri(Window1.imageDirectory & "normal\save_now.png", UriKind.RelativeOrAbsolute)))
            Catch
            End Try
            lbSave.IsEnabled = True
            Me.txtFileName.Text = "DNTImage"
            Me.rbJPG.IsChecked = True
            Me.chkMultiPage.IsEnabled = False
        End Sub

        Private m_ImageCore As ImageCore = Nothing
        Public WriteOnly Property Core() As ImageCore
            Set(value As ImageCore)
                m_ImageCore = value
            End Set
        End Property

        Private m_PDFCreator As PDFCreator = Nothing
        Public WriteOnly Property PDFCreator() As PDFCreator
            Set(value As PDFCreator)
                m_PDFCreator = value
            End Set
        End Property

        Private Sub lbSave_MouseDown(sender As Object, e As MouseButtonEventArgs)
            If m_ImageCore.ImageBuffer.HowManyImagesInBuffer = 0 Then
                MessageBox.Show("There is no images in the buffer.")
                Return
            End If
            Dim key As String = "active/" & "save_now"
            If Not Window1.icons.ContainsKey(key) Then
                Try
                    Window1.icons.Add(key, New ImageBrush(New BitmapImage(New Uri(Window1.imageDirectory & key & ".png", UriKind.RelativeOrAbsolute))))
                Catch
                End Try
            End If
            Try
                lbSave.Background = Window1.icons(key)
            Catch
            End Try

            Dim saveFileDialog As New Microsoft.Win32.SaveFileDialog()
            Dim fileName As String = txtFileName.Text.Trim()
            If VerifyFileName(fileName) Then
                saveFileDialog.FileName = Me.txtFileName.Text

                If CBool(rbJPG.IsChecked.GetValueOrDefault()) = True Then
                    saveFileDialog.Filter = "JPEG|*.JPG;*.JPEG;*.JPE;*.JFIF"
                    saveFileDialog.DefaultExt = "jpg"
                    If CBool(saveFileDialog.ShowDialog().GetValueOrDefault()) = True Then
                        Try
                            m_ImageCore.IO.SaveAsJPEG(saveFileDialog.FileName, m_ImageCore.ImageBuffer.CurrentImageIndexInBuffer)
                        Catch ex As Exception
                            MessageBox.Show(ex.Message)
                        End Try

                    End If
                End If
                If CBool(rbBMP.IsChecked.GetValueOrDefault()) = True Then
                    saveFileDialog.Filter = "BMP|*.BMP"
                    saveFileDialog.DefaultExt = "bmp"
                    If CBool(saveFileDialog.ShowDialog().GetValueOrDefault()) = True Then
                        m_ImageCore.IO.SaveAsBMP(saveFileDialog.FileName, m_ImageCore.ImageBuffer.CurrentImageIndexInBuffer)
                    End If
                End If
                If CBool(rbPNG.IsChecked.GetValueOrDefault()) = True Then
                    saveFileDialog.Filter = "PNG|*.PNG"
                    saveFileDialog.DefaultExt = "png"
                    If CBool(saveFileDialog.ShowDialog().GetValueOrDefault()) = True Then
                        m_ImageCore.IO.SaveAsPNG(saveFileDialog.FileName, m_ImageCore.ImageBuffer.CurrentImageIndexInBuffer)
                    End If
                End If
                If CBool(rbTIFF.IsChecked.GetValueOrDefault()) = True Then
                    saveFileDialog.Filter = "TIFF|*.TIF;*.TIFF"
                    saveFileDialog.DefaultExt = "tiff"
                    If CBool(saveFileDialog.ShowDialog().GetValueOrDefault()) = True Then
                        ' Multi page TIFF
                        Dim tempListIndex As New List(Of Short)()
                        If chkMultiPage.IsChecked = True Then
                            For sIndex As Short = 0 To m_ImageCore.ImageBuffer.HowManyImagesInBuffer - 1
                                tempListIndex.Add(sIndex)
                            Next
                        Else
                            tempListIndex.Add(m_ImageCore.ImageBuffer.CurrentImageIndexInBuffer)
                        End If
                        m_ImageCore.IO.SaveAsTIFF(saveFileDialog.FileName, tempListIndex)
                    End If
                End If
                If CBool(rbPDF.IsChecked.GetValueOrDefault()) = True Then
                    saveFileDialog.Filter = "PDF|*.PDF"
                    saveFileDialog.DefaultExt = "pdf"
                    If CBool(saveFileDialog.ShowDialog().GetValueOrDefault()) = True Then

                        m_PDFCreator.Save(TryCast(Me, ISave), saveFileDialog.FileName)
                    End If
                End If
            Else
                Me.txtFileName.Focus()
            End If
        End Sub

        Private Sub lbSave_MouseEnter(sender As Object, e As MouseEventArgs)
            Dim key As String = "hover/" & "save_now"
            If Not Window1.icons.ContainsKey(key) Then
                Try
                    Window1.icons.Add(key, New ImageBrush(New BitmapImage(New Uri(Window1.imageDirectory & key & ".png", UriKind.RelativeOrAbsolute))))
                Catch
                End Try
            End If
            Try
                lbSave.Background = Window1.icons(key)
            Catch
            End Try
        End Sub

        Private Sub lbSave_MouseLeave(sender As Object, e As MouseEventArgs)
            Dim key As String = "normal/" & "save_now"
            If Not Window1.icons.ContainsKey(key) Then
                Try
                    Window1.icons.Add(key, New ImageBrush(New BitmapImage(New Uri(Window1.imageDirectory & key & ".png", UriKind.RelativeOrAbsolute))))
                Catch
                End Try
            End If
            Try
                lbSave.Background = Window1.icons(key)
            Catch
            End Try
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
            MessageBox.Show("The file name contains invalid chars!", "Save Image To File", MessageBoxButton.OK, MessageBoxImage.Information)
            Return False
        End Function

        Private Sub rbJPG_Checked(sender As Object, e As RoutedEventArgs)
            SetMultiPage(False)
        End Sub

        Private Sub rbBMP_Checked(sender As Object, e As RoutedEventArgs)
            SetMultiPage(False)
        End Sub

        Private Sub rbPNG_Checked(sender As Object, e As RoutedEventArgs)
            SetMultiPage(False)
        End Sub

        Private Sub rbTIFF_Checked(sender As Object, e As RoutedEventArgs)
            SetMultiPage(True)
        End Sub

        Private Sub rbPDF_Checked(sender As Object, e As RoutedEventArgs)
            SetMultiPage(True)
        End Sub

        Private Sub SetMultiPage(bChecked As Boolean)
            Me.chkMultiPage.IsChecked = bChecked
            Me.chkMultiPage.IsEnabled = bChecked
        End Sub

#Region "ISave Members"

        Public Function GetAnnotations(iPageNumber As Integer) As Object Implements ISave.GetAnnotations
            Return Nothing
        End Function

        Public Function GetImage(iPageNumber As Integer) As System.Drawing.Bitmap Implements ISave.GetImage
            If chkMultiPage.IsChecked = True Then
                Return m_ImageCore.ImageBuffer.GetBitmap(CShort(iPageNumber))
            Else
                Return m_ImageCore.ImageBuffer.GetBitmap(CShort(m_ImageCore.ImageBuffer.CurrentImageIndexInBuffer))
            End If
        End Function

        Public Function GetPageCount() As Integer Implements ISave.GetPageCount
            If chkMultiPage.IsChecked = True Then
                Return m_ImageCore.ImageBuffer.HowManyImagesInBuffer
            Else
                Return 1
            End If
        End Function

#End Region
    End Class
End Namespace

