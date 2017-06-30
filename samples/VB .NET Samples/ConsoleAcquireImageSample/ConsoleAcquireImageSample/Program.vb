Imports System.Collections.Generic
Imports System.Text

Class Program
	Friend Shared Sub Main(args As String())
		Dim tempTwainObject As New TwainObject()
		Console.WriteLine("Start a scan job:")
		If tempTwainObject.SelectSource() Then
			tempTwainObject.AcquireImage()
		End If
	End Sub
End Class
