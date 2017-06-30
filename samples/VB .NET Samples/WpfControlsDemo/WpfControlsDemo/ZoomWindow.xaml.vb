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

''' <summary>
''' Interaction logic for ZoomWindow.xaml
''' </summary>
Namespace WpfControlsDemo
    Partial Public Class ZoomWindow
        Inherits Window
        Public Sub New(fZoom As Single)
            InitializeComponent()
            tbRatio.Text = (fZoom * 100).ToString()
            tbRatio.Focus()
        End Sub

        Private m_fRatio As Single

        Private Sub OK_Click(sender As Object, e As RoutedEventArgs)
            Try
                m_fRatio = Single.Parse(tbRatio.Text)
                If m_fRatio < 2 OrElse m_fRatio > 6500 Then
                    lbHint.Content = "Please input a float number between 2 and 6500"
                    Return
                End If
            Catch exp As Exception
                lbHint.Content = "Please input a float number between 2 and 6500"
                Return
            End Try
            Me.DialogResult = True
        End Sub

        Private Sub Cancel_Click(sender As Object, e As RoutedEventArgs)
            Me.DialogResult = False
        End Sub

        Public ReadOnly Property ZoomRatio() As Single
            Get
                Return m_fRatio / 100
            End Get
        End Property
    End Class
End Namespace

