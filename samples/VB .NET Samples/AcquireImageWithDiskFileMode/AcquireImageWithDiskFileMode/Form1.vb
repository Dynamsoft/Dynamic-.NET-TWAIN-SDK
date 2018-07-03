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
    Private strFileName As String

    Private m_StrProductKey As String

    Public Sub New()
        InitializeComponent()
        m_StrProductKey = "t0068UwAAAEQABDxqjGfgEzhVYureL0kGxugcsvIqCDGTPTsR5nLaQsNupIc17Y5vpMZAWBDsd6Xw3NMYzdHlHwiKUrfe/cU="
        m_ImageCore = New ImageCore()
        m_TwainManager = New TwainManager(m_StrProductKey)
        dsViewer1.Bind(m_ImageCore)

    End Sub




    Private Sub btnSelectSource_Click(sender As Object, e As System.EventArgs)
        Dim tempList As New List(Of String)()
        For i As Integer = 0 To m_TwainManager.SourceCount - 1
            tempList.Add(m_TwainManager.SourceNameItems(CShort(i)))
        Next
        Dim temp As New SourceListForm(tempList)
        temp.ShowDialog()
        Dim iSelectSource As Integer = temp.GetSelectedIndex()
        m_TwainManager.SelectSourceByIndex(CShort(iSelectSource))
    End Sub


    Private Sub btnAcquire_Click(sender As Object, e As System.EventArgs)
        If dlgFileSave.ShowDialog() = DialogResult.Cancel Then
            Return
        End If

        strFileName = dlgFileSave.FileName

        m_TwainManager.OpenSource()

        Try
            m_TwainManager.TransferMode = Dynamsoft.TWAIN.Enums.TWICapSetupXFer.TWSX_FILE
        Catch ex As Exception
            MessageBox.Show("The license for TWAIN module is invalid. Please contact support@dynamsoft.com to get a trial license.")
        End Try


        'Since the TWSX_FILE mode is not required by TWAIN specification,
        'it is better to read the value back to see if the File transfer mode is supported by the Source
        If m_TwainManager.TransferMode = Dynamsoft.TWAIN.Enums.TWICapSetupXFer.TWSX_FILE Then
            'the source supports the TWSX_FILE transfer mode.
            m_TwainManager.SetFileXFERInfo(strFileName, Dynamsoft.TWAIN.Enums.TWICapFileFormat.TWFF_BMP)
            'Sets file name and file format information.
            m_TwainManager.IfShowUI = False
            m_TwainManager.IfDisableSourceAfterAcquire = True
            'Acquire the image.
            m_TwainManager.EnableSource(TryCast(Me, IAcquireCallback))
        Else
            'the source doesn't support the TWSX_FILE transfer mode.
            MessageBox.Show("The source doesn't support the DiskFile transfer mode.")
        End If


    End Sub

    Public Sub OnPostAllTransfers() Implements IAcquireCallback.OnPostAllTransfers
        m_ImageCore.IO.LoadImage(strFileName)
    End Sub

    Public Function OnPostTransfer(bit As Bitmap) As Boolean Implements IAcquireCallback.OnPostTransfer
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
