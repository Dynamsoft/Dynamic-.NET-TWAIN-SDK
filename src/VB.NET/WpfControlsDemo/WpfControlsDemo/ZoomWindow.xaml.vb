Namespace WpfControlsDemo
    Partial Public Class ZoomWindow
        Inherits Window
        Public Sub New(ByVal fZoom As Single)
            InitializeComponent()
            tbRatio.Text = (fZoom * 100).ToString()
            tbRatio.Focus()
        End Sub

        Private m_fRatio As Single

        Private Sub OK_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
            Try
                m_fRatio = Single.Parse(tbRatio.Text)

                If m_fRatio < 2 Or m_fRatio > 6500 Then
                    lbHint.Content = "Please input a float number between 2 and 6500"
                    Return
                End If

            Catch exp As Exception
                lbHint.Content = "Please input a float number between 2 and 6500"
                Return
            End Try
            Me.DialogResult = True
        End Sub

        Private Sub Cancel_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
            Me.DialogResult = False
        End Sub

        Public ReadOnly Property ZoomRatio() As Single
            Get
                Return m_fRatio / 100
            End Get
        End Property
      
    End Class
End Namespace
