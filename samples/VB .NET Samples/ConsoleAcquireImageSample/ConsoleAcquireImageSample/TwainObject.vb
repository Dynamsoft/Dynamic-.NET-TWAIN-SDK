Imports System.Collections.Generic
Imports System.Text
Imports Dynamsoft.TWAIN
Imports Dynamsoft.TWAIN.Interface
Imports System.IO
Imports System.Runtime.InteropServices

Public Class TwainObject
    Implements Dynamsoft.TWAIN.Interface.IAcquireCallback
    Private m_TwainManager As TwainManager = Nothing
    Private iPageNumber As Short = 0
    Private m_StrProductKey As String
    Public Sub New()
        m_StrProductKey = "t0068UwAAAEQABDxqjGfgEzhVYureL0kGxugcsvIqCDGTPTsR5nLaQsNupIc17Y5vpMZAWBDsd6Xw3NMYzdHlHwiKUrfe/cU="
        m_TwainManager = New TwainManager(m_StrProductKey)
    End Sub


    Public Function SelectSource() As Boolean
        Dim bRet As Boolean = False
        Console.WriteLine("Select a scanner:")
        Dim sSourceCount As Short = m_TwainManager.SourceCount
        For sIndex As Short = 0 To sSourceCount - 1
            Console.WriteLine(sIndex.ToString() + ". " + m_TwainManager.SourceNameItems(sIndex))
        Next
        Console.WriteLine("Enter the scanner index:")
        Dim temp As String = Console.ReadLine()
        Dim res As Integer = Int32.Parse(temp)
        If res > -1 AndAlso res < m_TwainManager.SourceCount Then
            bRet = m_TwainManager.SelectSourceByIndex(CShort(res))
            Console.WriteLine("Current Source name: " + m_TwainManager.CurrentSourceName)
        End If
        If Not bRet Then
            Console.WriteLine("Fail to select source.")
        End If
        Return bRet
    End Function

    Public Sub AcquireImage()
        m_TwainManager.IfDisableSourceAfterAcquire = True
        m_TwainManager.AcquireImage(TryCast(Me, IAcquireCallback))
    End Sub

    Public Sub Dispose()
        m_TwainManager.Dispose()
    End Sub
#Region "IAcquireCallback Members"

    Public Sub OnPostAllTransfers() Implements IAcquireCallback.OnPostAllTransfers
        m_TwainManager.CloseSourceManager()
        Console.WriteLine("Press any key to exit...")
        Console.ReadKey(True)
        Environment.[Exit](0)
    End Sub

    Public Function OnPostTransfer(bit As System.Drawing.Bitmap) As Boolean Implements IAcquireCallback.OnPostTransfer

        Console.WriteLine("The " + iPageNumber.ToString() + " pages of document has been scanned.")
        Dim path As String = System.IO.Path.GetTempPath()
        Dim temp As DateTime = DateTime.Now
        Dim year As Integer = temp.Year
        Dim month As Integer = temp.Month
        Dim day As Integer = temp.Day
        Dim hour As Integer = temp.Hour
        Dim min As Integer = temp.Minute
        Dim [date] As String = year.ToString() + "_" + month.ToString() + "_" + day.ToString() + "_" + hour.ToString() + "hour" + "_" + min.ToString() + "min"

        Dim filePath As String = (path & Convert.ToString("\")) + [date].ToString() + ".bmp"
        bit.Save(filePath)
        Console.WriteLine("Image has been saved. " + "The file path: " + filePath.ToString())
        Return True

    End Function

    Public Sub OnPreAllTransfers() Implements IAcquireCallback.OnPreAllTransfers
        Console.WriteLine("The scan task will begin.")
    End Sub

    Public Function OnPreTransfer() As Boolean Implements IAcquireCallback.OnPreTransfer
        iPageNumber += 1
        Console.WriteLine("The " & iPageNumber.ToString() & " pages of document will be scanned.")
        Return True
    End Function

    Public Sub OnSourceUIClose() Implements IAcquireCallback.OnSourceUIClose

    End Sub

    Public Sub OnTransferCancelled() Implements IAcquireCallback.OnTransferCancelled

    End Sub

    Public Sub OnTransferError() Implements IAcquireCallback.OnTransferError
    End Sub

#End Region
End Class
