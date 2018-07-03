Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
Imports Dynamsoft.TWAIN
Imports Dynamsoft.Forms
Imports Dynamsoft.Core
Imports Dynamsoft.TWAIN.Interface
Imports System.Runtime.InteropServices
Imports System.IO

Partial Public Class Form1
    Inherits Form
    Implements IAcquireCallback
    Private m_StrProductKey As String
    Private m_TwainManager As TwainManager = Nothing
    Private m_ImageCore As ImageCore = Nothing
    Public Sub New()
        InitializeComponent()
        m_StrProductKey = "t0068UwAAAEQABDxqjGfgEzhVYureL0kGxugcsvIqCDGTPTsR5nLaQsNupIc17Y5vpMZAWBDsd6Xw3NMYzdHlHwiKUrfe/cU="
        m_TwainManager = New TwainManager(m_StrProductKey)
        m_ImageCore = New ImageCore()
        dsViewer1.Bind(m_ImageCore)
    End Sub



    Private Sub Acquire_Click(sender As Object, e As EventArgs) Handles Acquire.Click

        Dim tempList As New List(Of String)()
        For i As Integer = 0 To m_TwainManager.SourceCount - 1
            tempList.Add(m_TwainManager.SourceNameItems(CShort(i)))
        Next
        Dim tempSourceListWrapper As New SourceListWrapper(tempList)

        Dim iSelectIndex As Integer = tempSourceListWrapper.SelectSource()
        If iSelectIndex = -1 Then
            Return
        Else
            m_TwainManager.IfDisableSourceAfterAcquire = True
            m_TwainManager.IfShowUI = True
            m_TwainManager.SelectSourceByIndex(CShort(iSelectIndex))
            m_TwainManager.AcquireImage(TryCast(Me, IAcquireCallback))
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

    Private Sub Form1_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        m_TwainManager.Dispose()
    End Sub
End Class
