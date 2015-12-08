Imports Dynamsoft.DotNet.TWAIN.Wpf
Namespace WpfControlsDemo
    Partial Public Class SaveWindow
        Inherits Window

        Public Sub New()
            InitializeComponent()
            m_twain = Nothing
            Try
                lbsave.Background = New ImageBrush(New BitmapImage(New Uri(Window1.imageDirectory + "normal\\save_now.png", UriKind.RelativeOrAbsolute)))
            Catch ex As Exception
            End Try
            lbSave.IsEnabled = True
            Me.txtFileName.Text = "DNTImage"
            Me.rbJPG.IsChecked = True
            Me.chkMultiPage.IsEnabled = False
        End Sub

        Private m_twain As Dynamsoft.DotNet.TWAIN.Wpf.DynamicDotNetTwain

        Public WriteOnly Property TWAIN() As DynamicDotNetTwain
            Set(ByVal value As DynamicDotNetTwain)
                m_twain = value

            End Set
        End Property

        Private Sub lbsave_MouseDown(ByVal sender As Object, ByVal e As MouseButtonEventArgs)
            If m_twain.HowManyImagesInBuffer = 0 Then
                MessageBox.Show("There is no images in the buffer.")
                Return
            End If
            Dim key As String : key = "active/" + "save_now"
            If (Not Window1.icons.ContainsKey(key)) Then
                Try
                    Window1.icons.Add(key, New ImageBrush(New BitmapImage(New Uri(Window1.imageDirectory + key + ".png", UriKind.RelativeOrAbsolute))))
                Catch ex As Exception
                End Try
            End If
            Try
                lbSave.Background = Window1.icons(key)
            Catch ex As Exception
            End Try

            Dim saveFileDialog As New Microsoft.Win32.SaveFileDialog
            Dim fileName As String
            fileName = txtFileName.Text.Trim()
            If (VerifyFileName(fileName)) Then
                saveFileDialog.FileName = Me.txtFileName.Text
                If (Convert.ToBoolean(rbJPG.IsChecked.GetValueOrDefault()) = True) Then
                    saveFileDialog.Filter = "JPEG|*.JPG;*.JPEG;*.JPE;*.JFIF"
                    saveFileDialog.DefaultExt = "jpg"
                    If (Convert.ToBoolean(saveFileDialog.ShowDialog().GetValueOrDefault()) = True) Then
                        m_twain.SaveAsJPEG(saveFileDialog.FileName, m_twain.CurrentImageIndexInBuffer)
                    End If
                End If

                If (Convert.ToBoolean(rbBMP.IsChecked.GetValueOrDefault()) = True) Then
                    saveFileDialog.Filter = "BMP|*.BMP"
                    saveFileDialog.DefaultExt = "bmp"
                    If (Convert.ToBoolean(saveFileDialog.ShowDialog().GetValueOrDefault()) = True) Then
                        m_twain.SaveAsBMP(saveFileDialog.FileName, m_twain.CurrentImageIndexInBuffer)
                    End If
                End If

                If (Convert.ToBoolean(rbPNG.IsChecked.GetValueOrDefault()) = True) Then
                    saveFileDialog.Filter = "PNG|*.PNG"
                    saveFileDialog.DefaultExt = "png"
                    If (Convert.ToBoolean(saveFileDialog.ShowDialog().GetValueOrDefault()) = True) Then
                        m_twain.SaveAsPNG(saveFileDialog.FileName, m_twain.CurrentImageIndexInBuffer)
                    End If
                End If

                If (Convert.ToBoolean(rbTIFF.IsChecked.GetValueOrDefault()) = True) Then
                    saveFileDialog.Filter = "TIFF|*.TIF;*.TIFF"
                    saveFileDialog.DefaultExt = "tiff"
                    If (Convert.ToBoolean(saveFileDialog.ShowDialog().GetValueOrDefault()) = True) Then
                        If (chkMultiPage.IsChecked = True) Then
                            m_twain.SaveAllAsMultiPageTIFF(saveFileDialog.FileName)
                        Else
                            m_twain.SaveAsTIFF(saveFileDialog.FileName, m_twain.CurrentImageIndexInBuffer)
                        End If
                    End If
                End If

                If (Convert.ToBoolean(rbPDF.IsChecked.GetValueOrDefault()) = True) Then
                    saveFileDialog.Filter = "PDF|*.PDF"
                    saveFileDialog.DefaultExt = "pdf"
                    If (Convert.ToBoolean(saveFileDialog.ShowDialog().GetValueOrDefault()) = True) Then
                        If (chkMultiPage.IsChecked = True) Then
                            m_twain.SaveAllAsPDF(saveFileDialog.FileName)
                        Else
                            m_twain.SaveAsPDF(saveFileDialog.FileName, m_twain.CurrentImageIndexInBuffer)
                        End If
                    End If
                End If
            Else
                Me.txtFileName.Focus()
            End If
        End Sub

        Private Sub lbsave_MouseEnter(ByVal sender As Object, ByVal e As MouseEventArgs)
            Dim key As String : key = "hover/" + "save_now"
            If (Not Window1.icons.ContainsKey(key)) Then
                Try
                    Window1.icons.Add(key, New ImageBrush(New BitmapImage(New Uri(Window1.imageDirectory + key + ".png", UriKind.RelativeOrAbsolute))))
                Catch ex As Exception
                End Try
            End If
            Try
                lbsave.Background = Window1.icons(key)
            Catch ex As Exception
            End Try
        End Sub

        Private Sub lbsave_MouseLeave(ByVal sender As Object, ByVal e As MouseEventArgs)
            Dim key As String : key = "normal/" + "save_now"
            If (Not Window1.icons.ContainsKey(key)) Then
                Try
                    Window1.icons.Add(key, New ImageBrush(New BitmapImage(New Uri(Window1.imageDirectory + key + ".png", UriKind.RelativeOrAbsolute))))
                Catch ex As Exception
                End Try
            End If
            Try
                lbsave.Background = Window1.icons(key)
            Catch ex As Exception
            End Try
        End Sub

        Private Function VerifyFileName(ByVal fileName As String) As Boolean
            Try

                If fileName.LastIndexOfAny(System.IO.Path.GetInvalidFileNameChars) = -1 Then
                    Return True
                End If
            Catch ex As Exception

            End Try
            MessageBox.Show("The file name contains invalid chars!", "Save Image To File", MessageBoxButton.OK, MessageBoxImage.Information)
            Return False
        End Function


        Private Sub rbJPG_Checked(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs)
            SetMultiPage(False)
        End Sub

        Private Sub rbBMP_Checked(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs)
            SetMultiPage(False)
        End Sub

        Private Sub rbPNG_Checked(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs)
            SetMultiPage(False)
        End Sub

        Private Sub rbTIFF_Checked(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs)
            SetMultiPage(True)
        End Sub


        Private Sub rbPDF_Checked(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs)
            SetMultiPage(True)
        End Sub

        Private Sub SetMultiPage(ByVal bChecked As Boolean)
            Me.chkMultiPage.IsChecked = bChecked
            Me.chkMultiPage.IsEnabled = bChecked
        End Sub
    End Class
End Namespace
