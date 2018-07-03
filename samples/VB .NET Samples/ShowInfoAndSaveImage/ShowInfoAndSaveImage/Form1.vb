Imports Dynamsoft.Core
Imports Dynamsoft.Core.Enums
Imports Dynamsoft.TWAIN
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
Imports Dynamsoft.TWAIN.Interface
Imports Dynamsoft.PDF
Imports System.Runtime.InteropServices
Imports System.IO

Partial Public Class Form1
    Inherits Form
    Implements IAcquireCallback
    Implements ISave
    Private sImageType As EnumImageFileFormat
    Private m_TwainManager As TwainManager = Nothing
    Private m_ImageCore As ImageCore = Nothing
    Private m_PDFCreator As Dynamsoft.PDF.PDFCreator = Nothing
    Private m_StrProductKey As String
    Public Sub New()
        InitializeComponent()
        m_StrProductKey = "t0068UwAAAEQABDxqjGfgEzhVYureL0kGxugcsvIqCDGTPTsR5nLaQsNupIc17Y5vpMZAWBDsd6Xw3NMYzdHlHwiKUrfe/cU="
        m_TwainManager = New TwainManager(m_StrProductKey)
        m_ImageCore = New ImageCore()
        dsViewer1.Bind(m_ImageCore)
        dsViewer1.SetViewMode(1, 1)
        BMPradio.Checked = True
        sImageType = 0
        MultiTIFF.Enabled = False
        MultiPDF.Enabled = False
        m_PDFCreator = New PDFCreator(m_StrProductKey)

        m_RefreshInfo = New RefreshInfo(AddressOf ShowImageInfo)
    End Sub



    Private Delegate Sub RefreshInfo(strImageXResolution As Integer, strImageYResolution As Integer, strImageWidth As Integer, strImageLength As Integer, strImageBitsPerixel As String, strImagePixelType As String, _
        strImageLayoutFrameLeft As String, strImageLayoutFrameTop As String, strImageLayoutFrameRight As String, strImageLayoutFrameBottom As String, strImageLayoutDocumentNumber As String, strImageLayoutPageNumber As String, _
        strImageLayoutFrameNumber As String)


    Private m_RefreshInfo As RefreshInfo

    Public Function GetImageSize() As String
        Dim ImageSize As String = ""
        If m_ImageCore.ImageBuffer.HowManyImagesInBuffer <> 0 Then
            ImageSize = m_ImageCore.IO.GetImageSizeWithSpecifiedType(m_ImageCore.ImageBuffer.CurrentImageIndexInBuffer, sImageType).ToString()
        End If
        Return ImageSize
    End Function

    Private Sub btnScan_Click(sender As Object, e As EventArgs)

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

    Private Sub TIFFradio_CheckedChanged(sender As Object, e As EventArgs)
        MultiTIFF.Enabled = True
        MultiPDF.Enabled = False
        sImageType = EnumImageFileFormat.WEBTW_TIF
        txtFileSize.Text = GetImageSize()
    End Sub

    Private m_PDFFileBytes As Byte() = Nothing
    Private Sub PDFradio_CheckedChanged(sender As Object, e As EventArgs)
        MultiTIFF.Enabled = False
        MultiPDF.Enabled = True
        m_PDFFileBytes = Nothing
        m_PDFFileBytes = m_PDFCreator.SaveAsBytes(TryCast(Me, ISave))
        txtFileSize.Text = "0"
        If m_PDFFileBytes IsNot Nothing Then
            txtFileSize.Text = m_PDFFileBytes.Length.ToString()
        End If

    End Sub

    Private Sub BMPradio_CheckedChanged(sender As Object, e As EventArgs)
        MultiTIFF.Enabled = False
        MultiPDF.Enabled = False
        sImageType = EnumImageFileFormat.WEBTW_BMP
        txtFileSize.Text = GetImageSize()

    End Sub

    Private Sub JPEGradio_CheckedChanged(sender As Object, e As EventArgs)
        MultiTIFF.Enabled = False
        MultiPDF.Enabled = False
        sImageType = EnumImageFileFormat.WEBTW_JPG
        txtFileSize.Text = GetImageSize()
    End Sub

    Private Sub PNGradio_CheckedChanged(sender As Object, e As EventArgs)
        MultiTIFF.Enabled = False
        MultiPDF.Enabled = False
        sImageType = EnumImageFileFormat.WEBTW_PNG
        txtFileSize.Text = GetImageSize()
    End Sub

    Private Sub BMPradio_MouseClick(sender As Object, e As MouseEventArgs)
        MultiTIFF.Enabled = False
        MultiPDF.Enabled = False
        sImageType = 0
        txtFileSize.Text = GetImageSize()
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs)
        Try
            If m_ImageCore.ImageBuffer.HowManyImagesInBuffer > 0 Then
                Dim strFile As String = ""
                If BMPradio.Checked = True Then
                    dlgFileSave.Filter = "BMP File (*.bmp)|*.bmp"
                ElseIf JPEGradio.Checked = True Then
                    dlgFileSave.Filter = "JPEG File (*.jpg)|*.jpg"
                ElseIf PNGradio.Checked = True Then
                    dlgFileSave.Filter = "PNG File (*.png)|*.png"
                ElseIf TIFFradio.Checked = True Then
                    dlgFileSave.Filter = "TIFF File (*.tif)|*.tif"
                ElseIf PDFradio.Checked = True Then
                    dlgFileSave.Filter = "PDF File (*.pdf)|*.pdf"
                End If
                dlgFileSave.InitialDirectory = System.IO.Directory.GetCurrentDirectory()
                dlgFileSave.FileName = ""
                If dlgFileSave.ShowDialog() = DialogResult.OK Then
                    strFile = dlgFileSave.FileName


                    If BMPradio.Checked = True Then
                        m_ImageCore.IO.SaveAsBMP(strFile, m_ImageCore.ImageBuffer.CurrentImageIndexInBuffer)
                    ElseIf JPEGradio.Checked = True Then

                        m_ImageCore.IO.SaveAsJPEG(strFile, m_ImageCore.ImageBuffer.CurrentImageIndexInBuffer)
                    ElseIf PNGradio.Checked = True Then

                        m_ImageCore.IO.SaveAsPNG(strFile, m_ImageCore.ImageBuffer.CurrentImageIndexInBuffer)
                    ElseIf TIFFradio.Checked = True Then
                        Dim tempImageIndex As New List(Of Short)()
                        If MultiTIFF.Checked = True Then
                            For sIndex As Short = 0 To m_ImageCore.ImageBuffer.HowManyImagesInBuffer - 1
                                tempImageIndex.Add(sIndex)
                            Next
                        Else
                            tempImageIndex.Add(m_ImageCore.ImageBuffer.CurrentImageIndexInBuffer)
                        End If

                        m_ImageCore.IO.SaveAsTIFF(strFile, tempImageIndex)
                    ElseIf PDFradio.Checked = True Then
                        m_PDFCreator.Save(TryCast(Me, ISave), strFile)
                    End If
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub btnRemove_Click(sender As Object, e As EventArgs)
        If m_ImageCore.ImageBuffer.CurrentImageIndexInBuffer > -1 Then
            m_ImageCore.ImageBuffer.RemoveImage(m_ImageCore.ImageBuffer.CurrentImageIndexInBuffer)
            btnScan.Enabled = True
        End If
    End Sub

    Private Sub Clear()
        m_ImageCore.ImageBuffer.RemoveAllImages()
        edtXResolution.Text = ""
        edtYResolution.Text = ""
        edtWidth.Text = ""
        edtLength.Text = ""
        edtBitsPerPixel.Text = ""
        edtPixelType.Text = ""

        edtFrameLeft.Text = ""
        edtFrameTop.Text = ""
        edtFrameRight.Text = ""
        edtFrameBottom.Text = ""
        edtDocNumber.Text = ""
        edtPageNumber.Text = ""
        edtFrameNumber.Text = ""

        txtFileSize.Text = GetImageSize()
    End Sub

    Private Sub dynamicDotNetTwain_OnPostTransfer()
        If m_ImageCore.ImageBuffer.HowManyImagesInBuffer >= m_ImageCore.ImageBuffer.MaxImagesInBuffer Then
            btnScan.Enabled = False
        End If
    End Sub

    Private Sub ShowImageInfo(strImageXResolution As Integer, strImageYResolution As Integer, strImageWidth As Integer, strImageLength As Integer, strImageBitsPerixel As String, strImagePixelType As String, _
        strImageLayoutFrameLeft As String, strImageLayoutFrameTop As String, strImageLayoutFrameRight As String, strImageLayoutFrameBottom As String, strDocumentNumber As String, strPageNumber As String, _
        strFrameNumber As String)
        edtXResolution.Text = strImageXResolution.ToString()
        edtYResolution.Text = strImageYResolution.ToString()
        edtWidth.Text = strImageWidth.ToString()
        edtLength.Text = strImageLength.ToString()
        edtBitsPerPixel.Text = strImageLength.ToString()
        edtPixelType.Text = strImagePixelType.ToString()
        edtFrameLeft.Text = strImageLayoutFrameLeft.ToString()
        edtFrameTop.Text = strImageLayoutFrameTop.ToString()
        edtFrameRight.Text = strImageLayoutFrameRight.ToString()
        edtFrameBottom.Text = strImageLayoutFrameBottom.ToString()


        edtDocNumber.Text = strDocumentNumber
        edtPageNumber.Text = strPageNumber
        edtFrameNumber.Text = strFrameNumber
        edtPageNumber.Text = m_TwainManager.ImageLayoutPageNumber.ToString()
        edtFrameNumber.Text = m_TwainManager.ImageLayoutFrameNumber.ToString()

        txtFileSize.Text = GetImageSize()
    End Sub

    Private Sub dynamicDotNetTwain_OnPreAllTransfers()
        Clear()
    End Sub

    Public Sub LoadConvertResult(result As ConvertResult)
    End Sub

    Public Sub OnPostAllTransfers() Implements IAcquireCallback.OnPostAllTransfers
        Me.BeginInvoke(m_RefreshInfo, CInt(Math.Truncate(m_TwainManager.ImageXResolution)), CInt(Math.Truncate(m_TwainManager.ImageYResolution)), CInt(m_TwainManager.ImageWidth), CInt(m_TwainManager.ImageLength), m_TwainManager.ImageBitsPerPixel.ToString(), _
            m_TwainManager.ImagePixelType.ToString(), m_TwainManager.GetImageLayout().Left.ToString(), m_TwainManager.GetImageLayout().Top.ToString(), m_TwainManager.GetImageLayout().Right.ToString(), m_TwainManager.GetImageLayout().Bottom.ToString(), m_TwainManager.ImageLayoutDocumentNumber.ToString(), _
            m_TwainManager.ImageLayoutPageNumber.ToString(), m_TwainManager.ImageLayoutFrameNumber.ToString())
        Console.WriteLine("OnPostAllTransfer")
    End Sub

    Public Function OnPostTransfer(bit As Bitmap) As Boolean Implements IAcquireCallback.OnPostTransfer
        m_ImageCore.ImageBuffer.RemoveAllImages()
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

    Public Function GetAnnotations(iPageNumber As Integer) As Object Implements ISave.GetAnnotations
        If MultiPDF.Checked Then
            Return m_ImageCore.ImageBuffer.GetMetaData(CShort(iPageNumber), EnumMetaDataType.enumAnnotation)
        Else
            Return m_ImageCore.ImageBuffer.GetMetaData(m_ImageCore.ImageBuffer.CurrentImageIndexInBuffer, EnumMetaDataType.enumAnnotation)
        End If
    End Function

    Public Function GetImage(iPageNumber As Integer) As Bitmap Implements ISave.GetImage
        If MultiPDF.Checked Then
            Return m_ImageCore.ImageBuffer.GetBitmap(CShort(iPageNumber))
        Else
            Return m_ImageCore.ImageBuffer.GetBitmap(m_ImageCore.ImageBuffer.CurrentImageIndexInBuffer)
        End If
    End Function

    Public Function GetPageCount() As Integer Implements ISave.GetPageCount
        If MultiPDF.Checked Then
            Return m_ImageCore.ImageBuffer.HowManyImagesInBuffer
        Else
            Return 1
        End If
    End Function
    Private Sub Form1_FormClosed(sender As Object, e As FormClosedEventArgs)
        m_TwainManager.Dispose()
    End Sub
End Class
