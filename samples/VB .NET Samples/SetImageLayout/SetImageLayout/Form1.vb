Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
Imports Dynamsoft.TWAIN
Imports Dynamsoft.Core
Imports Dynamsoft.TWAIN.Interface
Imports System.Runtime.InteropServices
Imports System.IO
Imports Dynamsoft.Common

Partial Public Class Form1
    Inherits Form
    Implements IAcquireCallback
    Private m_TwainManager As TwainManager = Nothing
    Private m_ImageCore As ImageCore = Nothing
    Private m_StrProductKey As String
    Public Sub New()
        InitializeComponent()
        m_StrProductKey = "t0068MgAAAENENwNWc7+efmkY+t7se6XaRPFZkvfB7QWiTjHiLykxngQdY09pzVtOvrefXBbVvYFbJSluECHlyxaOvHwUADk="
        m_TwainManager = New TwainManager(m_StrProductKey)
        m_ImageCore = New ImageCore()
        dsViewer1.Bind(m_ImageCore)

        If m_TwainManager.SourceCount > 0 Then
            For i As Short = 0 To m_TwainManager.SourceCount - 1
                Dim strSourceName As String = m_TwainManager.SourceNameItems(i)
                If strSourceName IsNot Nothing Then
                    cbxSources.Items.Add(strSourceName)
                End If
            Next
            AddHandler cbxSources.SelectedIndexChanged, AddressOf cbxSources_SelectedIndexChanged
            cbxSources.SelectedIndex = 0
        Else
            MessageBox.Show(Me, "There is no scanner detected!" & vbLf & " " & "Please ensure that at least one (virtual) scanner is installed.", "Information")
            Return

        End If
    End Sub



    Private Sub btnSetAndAcquire_Click(sender As Object, e As System.EventArgs)
        Dim fFrameLeft As Single, fFrameTop As Single, fFrameRight As Single, fFrameBottom As Single, frameTemp As Single

        Try
            fFrameLeft = Convert.ToSingle(edtFrameLeft.Text)
            fFrameTop = Convert.ToSingle(edtFrameTop.Text)
            fFrameRight = Convert.ToSingle(edtFrameRight.Text)
            fFrameBottom = Convert.ToSingle(edtFrameBottom.Text)

            If fFrameLeft > fFrameRight Then
                frameTemp = fFrameLeft
                fFrameLeft = fFrameRight
                fFrameRight = frameTemp
            End If

            If fFrameTop > fFrameBottom Then
                frameTemp = fFrameTop
                fFrameTop = fFrameBottom
                fFrameBottom = frameTemp
            End If
        Catch generatedExceptionName As Exception
            MessageBox.Show("Please input numerical values in the input boxes.", "Error")
            Return
        End Try

        If fFrameLeft = fFrameRight OrElse fFrameTop = fFrameBottom Then
            MessageBox.Show("Input Value Error: don't make left equal to right, or top equal to bottom.", "Error")
            Return
        End If
        If fFrameLeft < fDefaultFrameLeft OrElse fFrameTop < fDefaultFrameTop OrElse fFrameRight > fDefaultFrameRight OrElse fFrameBottom > fDefaultFrameBottom Then
            Dim drImageLayout As DialogResult = MessageBox.Show("Input values are out of rangles,do you want to continue?", "Warning", MessageBoxButtons.YesNo)
            If drImageLayout = System.Windows.Forms.DialogResult.Yes Then
            Else
                Return
            End If
        End If
        If m_TwainManager.SetImageLayout(New Margin(fFrameLeft, fFrameTop, fFrameRight, fFrameBottom)) = False Then
            MessageBox.Show("Fail to set image layout", "Error")
        Else
            m_TwainManager.IfShowUI = False

            m_TwainManager.IfDisableSourceAfterAcquire = True
            m_TwainManager.EnableSource(TryCast(Me, IAcquireCallback))
        End If
    End Sub

    Private fDefaultFrameLeft As Single, fDefaultFrameTop As Single, fDefaultFrameRight As Single, fDefaultFrameBottom As Single


    Private Sub cbxSources_SelectedIndexChanged(sender As Object, e As EventArgs)
        If DirectCast(sender, ComboBox).SelectedIndex >= 0 AndAlso DirectCast(sender, ComboBox).SelectedIndex < m_TwainManager.SourceCount Then
            m_TwainManager.SelectSourceByIndex(cbxSources.SelectedIndex)
            m_TwainManager.OpenSource()
            m_TwainManager.ResetImageLayout()
            Dim tempMargin As Margin = m_TwainManager.GetImageLayout()
            fDefaultFrameLeft = tempMargin.Left
            fDefaultFrameTop = tempMargin.Top
            fDefaultFrameRight = tempMargin.Right
            fDefaultFrameBottom = tempMargin.Bottom
            fDefaultFrameLeft = CSng(CInt(Math.Truncate(fDefaultFrameLeft * 10))) / 10
            fDefaultFrameTop = CSng(CInt(Math.Truncate(fDefaultFrameTop * 10))) / 10
            fDefaultFrameRight = CSng(CInt(Math.Truncate(fDefaultFrameRight * 10))) / 10
            fDefaultFrameBottom = CSng(CInt(Math.Truncate(fDefaultFrameBottom * 10))) / 10
            edtFrameLeft.Text = fDefaultFrameLeft.ToString()
            edtFrameTop.Text = fDefaultFrameTop.ToString()
            edtFrameRight.Text = fDefaultFrameRight.ToString()
            edtFrameBottom.Text = fDefaultFrameBottom.ToString()
            lblFrameLeft.Text = String.Format("(0 ~ " & fDefaultFrameRight.ToString() & ")")
            lblFrameTop.Text = String.Format("(0 ~ " & fDefaultFrameBottom.ToString() & ")")
            lblFrameRight.Text = String.Format("(0 ~ " & fDefaultFrameRight.ToString() & ")")
            lblFrameBottom.Text = String.Format("(0 ~ " & fDefaultFrameBottom.ToString() & ")")
        End If
    End Sub

    Public Sub OnPostAllTransfers() Implements IAcquireCallback.OnPostAllTransfers
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
    End Sub

    Public Sub OnTransferCancelled() Implements IAcquireCallback.OnTransferCancelled
    End Sub

    Public Sub OnTransferError() Implements IAcquireCallback.OnTransferError
    End Sub

    Private Sub Form1_FormClosed(sender As Object, e As FormClosedEventArgs)
        m_TwainManager.Dispose()
    End Sub
End Class
