Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
Imports Dynamsoft.PDF
Imports Dynamsoft.Core
Imports Dynamsoft.Core.Enums
Imports System.IO
Imports System.Runtime.InteropServices

Namespace Rasterizer
    Partial Public Class Form1
        Inherits Form
        Implements IConvertCallback
        Implements ISave
        Private m_PDFRasteizer As Dynamsoft.PDF.PDFRasterizer = Nothing
        Private m_PDFCreator As PDFCreator = Nothing
        Private m_StrProductKey As String
        Private m_ImageCore As ImageCore = Nothing
        Public Sub New()
            InitializeComponent()
            Initialization()
            m_StrProductKey = "t0068UwAAAEQABDxqjGfgEzhVYureL0kGxugcsvIqCDGTPTsR5nLaQsNupIc17Y5vpMZAWBDsd6Xw3NMYzdHlHwiKUrfe/cU="
            m_PDFRasteizer = New Dynamsoft.PDF.PDFRasterizer(m_StrProductKey)
            m_PDFCreator = New PDFCreator(m_StrProductKey)
            m_ImageCore = New ImageCore()

            dsViewer1.Bind(m_ImageCore)

	    chbMultiPagePDF.Checked = False
            chbMultiPagePDF.Enabled = False
            chbMultiPageTIFF.Checked = False
            chbMultiPageTIFF.Enabled = False
        End Sub



        Protected Sub Initialization()
            Me.Icon = New Icon(GetType(Form), "wfc.ico")
            Me.cmbPDFResolution.DropDownStyle = ComboBoxStyle.DropDownList
            Me.cmbPDFResolution.Items.Add("100")
            Me.cmbPDFResolution.Items.Add("150")
            Me.cmbPDFResolution.Items.Add("200")
            Me.cmbPDFResolution.Items.Add("300")
            Me.cmbPDFResolution.SelectedIndex = 0

            Me.rdbBMP.Checked = True
        End Sub

        Private Sub btnLoadPDF_Click(sender As Object, e As EventArgs)
            Try
                Dim openfiledlg As New OpenFileDialog()
                openfiledlg.Filter = "PDF|*.PDF"
                openfiledlg.FilterIndex = 0
                openfiledlg.Multiselect = True

                If openfiledlg.ShowDialog() = DialogResult.OK Then
                    For Each strfilename As String In openfiledlg.FileNames
                        m_PDFRasteizer.ConvertMode = Dynamsoft.PDF.Enums.EnumConvertMode.enumCM_RENDERALL
                        m_PDFRasteizer.ConvertToImage(strfilename, "", Convert.ToInt32(cmbPDFResolution.Text), TryCast(Me, IConvertCallback))
                    Next
                End If
            Catch exp As Exception
                MessageBox.Show(exp.Message)
            End Try
        End Sub

        Private Sub btnSave_Click(sender As Object, e As EventArgs)
            Try
                If m_ImageCore.ImageBuffer.HowManyImagesInBuffer > 0 Then
                    Me.labMsg.Text = ""
                    Dim savefdlg As New SaveFileDialog()
                    savefdlg.InitialDirectory = System.IO.Directory.GetCurrentDirectory()
                    savefdlg.FileName = ""

                    If rdbBMP.Checked = True Then

                        savefdlg.Filter = "BMP File(*.bmp)| *.bmp"
                    End If

                    If rdbJPEG.Checked = True Then

                        savefdlg.Filter = "JPEG File(*.jpeg)| *.jpeg"
                    End If

                    If rdbPNG.Checked = True Then

                        savefdlg.Filter = "PNG File(*.png) | *.png"
                    End If

                    If rdbTIFF.Checked = True Then

                        savefdlg.Filter = "TIFF File(*.tiff)| *.tiff"
                    End If

                    If rdbPDF.Checked = True Then

                        savefdlg.Filter = "PDF File(*.pdf)| *.pdf"
                    End If

                    If savefdlg.ShowDialog() = DialogResult.OK Then

                        Dim strFilename As String = savefdlg.FileName

                        If rdbBMP.Checked = True Then
                            m_ImageCore.IO.SaveAsBMP(strFilename, m_ImageCore.ImageBuffer.CurrentImageIndexInBuffer)
                        End If

                        If rdbJPEG.Checked = True Then
                            m_ImageCore.IO.SaveAsJPEG(strFilename, m_ImageCore.ImageBuffer.CurrentImageIndexInBuffer)
                        End If

                        If rdbPNG.Checked = True Then
                            m_ImageCore.IO.SaveAsPNG(strFilename, m_ImageCore.ImageBuffer.CurrentImageIndexInBuffer)
                        End If

                        If rdbTIFF.Checked = True Then
                            Dim tempListIndex As New List(Of Short)()
                            If chbMultiPageTIFF.Checked = True Then
                                For sIndex As Short = 0 To m_ImageCore.ImageBuffer.HowManyImagesInBuffer - 1
                                    tempListIndex.Add(sIndex)
                                Next
                            Else
                                tempListIndex.Add(m_ImageCore.ImageBuffer.CurrentImageIndexInBuffer)
                            End If
                            m_ImageCore.IO.SaveAsTIFF(strFilename, tempListIndex)
                        End If

                        If rdbPDF.Checked = True Then
                            m_PDFCreator.Save(TryCast(Me, ISave), strFilename)
                        End If
                    End If
                Else
                    Me.labMsg.ForeColor = Color.Red
                    Me.labMsg.Text = "Please load a PDF file first"
                    Me.labMsg.Location = New Point(Me.groupBox2.Size.Width \ 2 - Me.labMsg.Size.Width \ 2, Me.labMsg.Location.Y)
                End If
            Catch exp As Exception
                MessageBox.Show(exp.Message)
            End Try
        End Sub

        Private Sub rdbBMP_CheckedChanged(sender As Object, e As EventArgs)
            chbMultiPagePDF.Checked = False
            chbMultiPagePDF.Enabled = False
            chbMultiPageTIFF.Checked = False
            chbMultiPageTIFF.Enabled = False
        End Sub

        Private Sub rdbJPEG_CheckedChanged(sender As Object, e As EventArgs)
            chbMultiPagePDF.Checked = False
            chbMultiPagePDF.Enabled = False
            chbMultiPageTIFF.Checked = False
            chbMultiPageTIFF.Enabled = False
        End Sub

        Private Sub rdbPNG_CheckedChanged(sender As Object, e As EventArgs)
            chbMultiPagePDF.Checked = False
            chbMultiPagePDF.Enabled = False
            chbMultiPageTIFF.Checked = False
            chbMultiPageTIFF.Enabled = False
        End Sub

        Private Sub rdbTIFF_CheckedChanged(sender As Object, e As EventArgs)
            chbMultiPagePDF.Checked = False
            chbMultiPagePDF.Enabled = False
            chbMultiPageTIFF.Checked = True
            chbMultiPageTIFF.Enabled = True
        End Sub

        Private Sub rdbPDF_CheckedChanged(sender As Object, e As EventArgs)
            chbMultiPagePDF.Checked = True
            chbMultiPagePDF.Enabled = True
            chbMultiPageTIFF.Checked = False
            chbMultiPageTIFF.Enabled = False
        End Sub

#Region "IConvertCallback Members"

        Public Sub LoadConvertResult(result As ConvertResult) Implements IConvertCallback.LoadConvertResult
            m_ImageCore.IO.LoadImage(result.Image)
            m_ImageCore.ImageBuffer.SetMetaData(m_ImageCore.ImageBuffer.CurrentImageIndexInBuffer, EnumMetaDataType.enumAnnotation, result.Annotations, True)
        End Sub

#End Region

#Region "ISave Members"

        Public Function GetAnnotations(iPageNumber As Integer) As Object Implements ISave.GetAnnotations
            If chbMultiPagePDF.Checked Then
                Return m_ImageCore.ImageBuffer.GetMetaData(CShort(iPageNumber), EnumMetaDataType.enumAnnotation)
            Else
                Return m_ImageCore.ImageBuffer.GetMetaData(m_ImageCore.ImageBuffer.CurrentImageIndexInBuffer, EnumMetaDataType.enumAnnotation)
            End If

        End Function

        Public Function GetImage(iPageNumber As Integer) As Bitmap Implements ISave.GetImage
            If chbMultiPagePDF.Checked Then
                Return m_ImageCore.ImageBuffer.GetBitmap(CShort(iPageNumber))
            Else
                Return m_ImageCore.ImageBuffer.GetBitmap(m_ImageCore.ImageBuffer.CurrentImageIndexInBuffer)
            End If

        End Function

        Public Function GetPageCount() As Integer Implements ISave.GetPageCount
            If chbMultiPagePDF.Checked Then
                Return m_ImageCore.ImageBuffer.HowManyImagesInBuffer
            Else
                Return 1
            End If

        End Function

#End Region
    End Class
End Namespace
