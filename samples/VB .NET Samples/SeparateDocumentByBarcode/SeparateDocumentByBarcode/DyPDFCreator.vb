Imports System.Collections.Generic
Imports System.Text
Imports Dynamsoft.PDF
Imports Dynamsoft.Core
Imports Dynamsoft.Core.Enums

Public Class DyPDFCreator
	Implements ISave
	Private m_ImageCore As ImageCore = Nothing
	Private m_IndexList As List(Of Short) = Nothing
	Private m_PDFCreator As PDFCreator = Nothing

	Public Sub New(imageCore As ImageCore, indexList As List(Of Short), pdfCreator As PDFCreator)
		m_ImageCore = imageCore
		m_IndexList = indexList

		m_PDFCreator = pdfCreator
	End Sub

	Public Sub SaveAsPDF(strFileName As String)
		m_PDFCreator.Save(TryCast(Me, ISave), strFileName)
	End Sub
	#Region "ISave Members"

	Public Function GetAnnotations(iPageNumber As Integer) As Object Implements ISave.GetAnnotations
		Dim tempObject As Object = Nothing
		If m_ImageCore IsNot Nothing AndAlso m_IndexList IsNot Nothing Then
			tempObject = m_ImageCore.ImageBuffer.GetMetaData(m_IndexList(iPageNumber), EnumMetaDataType.enumAnnotation)
		End If
		Return tempObject
	End Function

	Public Function GetImage(iPageNumber As Integer) As System.Drawing.Bitmap Implements ISave.GetImage
		Dim tempBitmap As System.Drawing.Bitmap = Nothing
		If m_ImageCore IsNot Nothing AndAlso m_IndexList IsNot Nothing Then
			tempBitmap = m_ImageCore.ImageBuffer.GetBitmap(m_IndexList(iPageNumber))
		End If
		Return tempBitmap
	End Function

	Public Function GetPageCount() As Integer Implements ISave.GetPageCount
		Dim sCount As Integer = 0
		If m_IndexList IsNot Nothing Then
			sCount = m_IndexList.Count
		End If
		Return sCount
	End Function

	#End Region
End Class
