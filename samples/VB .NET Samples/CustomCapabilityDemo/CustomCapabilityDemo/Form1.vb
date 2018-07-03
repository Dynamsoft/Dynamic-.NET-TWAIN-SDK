Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
Imports Dynamsoft.TWAIN
Imports Dynamsoft.Core
Imports Dynamsoft.TWAIN.Enums
Imports Dynamsoft.TWAIN.Interface
Imports System.IO
Imports System.Runtime.InteropServices

Partial Public Class Form1
    Inherits Form
    Implements IAcquireCallback
    Private m_TwainManager As TwainManager = Nothing
    Private m_ImageCore As ImageCore = Nothing
    Private m_StrProductKey As String
    Public Sub New()
        InitializeComponent()
        m_StrProductKey = "t0068UwAAAEQABDxqjGfgEzhVYureL0kGxugcsvIqCDGTPTsR5nLaQsNupIc17Y5vpMZAWBDsd6Xw3NMYzdHlHwiKUrfe/cU="
        m_ImageCore = New ImageCore()
        m_TwainManager = New TwainManager(m_StrProductKey)
        dsViewer1.Bind(m_ImageCore)
    End Sub


    Private Sub btnSetCapability_Click(sender As Object, e As EventArgs)
        Dim tempList As New List(Of String)()
        For i As Integer = 0 To m_TwainManager.SourceCount - 1
            tempList.Add(m_TwainManager.SourceNameItems(CShort(i)))
        Next
        Dim tempSourceListWrapper As New SourceListWrapper(tempList)
        Dim iSelectIndex As Integer = tempSourceListWrapper.SelectSource()
        If iSelectIndex = -1 Then
            Return
        Else
            m_TwainManager.SelectSourceByIndex(iSelectIndex)
            m_TwainManager.OpenSource()

            m_TwainManager.Capability = DirectCast(&H8001, Dynamsoft.TWAIN.Enums.TWCapability)
            m_TwainManager.CapType = Dynamsoft.TWAIN.Enums.TWCapType.TWON_ONEVALUE
            m_TwainManager.CapValue = 1
            Dim bRet As Boolean = m_TwainManager.CapSet()
            Dim dblValue As Double = m_TwainManager.CapValue
            If bRet Then
                MessageBox.Show("Successful.")
            Else
                MessageBox.Show("Failed.")
            End If
        End If

    End Sub

    Private Sub button1_Click(sender As Object, e As EventArgs)
        Dim tempList As New List(Of String)()
        For i As Integer = 0 To m_TwainManager.SourceCount - 1
            tempList.Add(m_TwainManager.SourceNameItems(CShort(i)))
        Next
        Dim tempSourceListWrapper As New SourceListWrapper(tempList)
        Dim iSelectIndex As Integer = tempSourceListWrapper.SelectSource()
        If iSelectIndex = -1 Then
            Return
        Else
            m_TwainManager.SelectSourceByIndex(iSelectIndex)
            m_TwainManager.OpenSource()

            m_TwainManager.Capability = DirectCast(&H8001, Dynamsoft.TWAIN.Enums.TWCapability)
            m_TwainManager.CapType = Dynamsoft.TWAIN.Enums.TWCapType.TWON_ONEVALUE
            m_TwainManager.CapValue = 1
            Dim bRet As Boolean = m_TwainManager.CapSet()
            Dim dblValue As Double = m_TwainManager.CapValue
            If bRet Then
                MessageBox.Show("Successful.")
            Else
                MessageBox.Show("Failed.")
            End If
        End If
    End Sub

    Private Sub button2_Click(sender As Object, e As EventArgs)
        m_TwainManager.IfDisableSourceAfterAcquire = True
        m_TwainManager.IfShowUI = True
        m_TwainManager.AcquireImage(TryCast(Me, IAcquireCallback))
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
