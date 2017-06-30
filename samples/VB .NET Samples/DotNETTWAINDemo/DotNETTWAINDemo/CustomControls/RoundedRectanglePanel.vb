Imports System.Collections.Generic
Imports System.Text
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Windows.Forms

Class RoundedRectanglePanel
	Inherits Panel
	Public Sub New()
		MyBase.New()
		Me.Padding = New Padding(1, 1, 1, 1)
		AddHandler Me.SizeChanged, New EventHandler(AddressOf RoundedRectanglePanel_SizeChanged)
	End Sub

	Private Sub RoundedRectanglePanel_SizeChanged(sender As Object, e As EventArgs)
		Dim bmp As New Bitmap(Bounds.Width, Bounds.Height)
		Dim g As Graphics = Graphics.FromImage(bmp)

		Dim bounds__1 As New Rectangle(0, 0, Bounds.Width, Bounds.Height)
		Dim cTopBorder As Color = Color.FromArgb(255, 221, 221, 221)
		Dim cBottomBorder As Color = Color.FromArgb(255, 165, 165, 165)
		Dim cTop As Color = Color.FromArgb(255, &Hfa, &Hfa, &Hfa)
		Dim cBottom As Color = Color.FromArgb(255, &Heb, &Heb, &Heb)
		Dim backBrush As New System.Drawing.Drawing2D.LinearGradientBrush(bounds__1.Location, New Point(bounds__1.Left, bounds__1.Bottom), cTop, cBottom)
		Dim borderBrush As System.Drawing.Drawing2D.LinearGradientBrush = New LinearGradientBrush(bounds__1.Location, New Point(bounds__1.Left, bounds__1.Bottom), cTopBorder, cBottomBorder)
		Dim pen As System.Drawing.Pen = New Pen(borderBrush)
		Dim graphicPath As System.Drawing.Drawing2D.GraphicsPath = GetRoundedRect(New RectangleF(bounds__1.X, bounds__1.Y, bounds__1.Width - 1, bounds__1.Height - 1), 3)

		g.SmoothingMode = SmoothingMode.AntiAlias
		g.FillPath(backBrush, graphicPath)
		g.DrawPath(pen, graphicPath)

		Me.BackgroundImage = bmp

		backBrush.Dispose()
		borderBrush.Dispose()
		pen.Dispose()
		graphicPath.Dispose()
		g.Dispose()
	End Sub

	#Region "Refrenced (CodeProject)"
	Private Function GetRoundedRect(baseRect As RectangleF, radius As Single) As GraphicsPath
		' if corner radius is less than or equal to zero, 
		' return the original rectangle 
		If radius <= 0F Then
			Dim mPath As New GraphicsPath()
			mPath.AddRectangle(baseRect)
			mPath.CloseFigure()
			Return mPath
		End If

		' if the corner radius is greater than or equal to 
		' half the width, or height (whichever is shorter) 
		' then return a capsule instead of a lozenge 
		If radius >= (Math.Min(baseRect.Width, baseRect.Height)) / 2.0 Then
			Return GetCapsule(baseRect)
		End If

		' create the arc for the rectangle sides and declare 
		' a graphics path object for the drawing 
		Dim diameter As Single = radius * 2F
		Dim sizeF As New SizeF(diameter, diameter)
		Dim arc As New RectangleF(baseRect.Location, sizeF)
		Dim path As GraphicsPath = New System.Drawing.Drawing2D.GraphicsPath()

		' top left arc 
		path.AddArc(arc, 180, 90)

		' top right arc 
		arc.X = baseRect.Right - diameter
		path.AddArc(arc, 270, 90)

		' bottom right arc 
		arc.Y = baseRect.Bottom - diameter
		path.AddArc(arc, 0, 90)

		' bottom left arc
		arc.X = baseRect.Left
		path.AddArc(arc, 90, 90)

		path.CloseFigure()
		Return path
	End Function

	Private Function GetCapsule(baseRect As RectangleF) As GraphicsPath
		Dim diameter As Single
		Dim arc As RectangleF
		Dim path As GraphicsPath = New System.Drawing.Drawing2D.GraphicsPath()
		Try
			If baseRect.Width > baseRect.Height Then
				' return horizontal capsule 
				diameter = baseRect.Height
				Dim sizeF As New SizeF(diameter, diameter)
				arc = New RectangleF(baseRect.Location, sizeF)
				path.AddArc(arc, 90, 180)
				arc.X = baseRect.Right - diameter
				path.AddArc(arc, 270, 180)
			ElseIf baseRect.Width < baseRect.Height Then
				' return vertical capsule 
				diameter = baseRect.Width
				Dim sizeF As New SizeF(diameter, diameter)
				arc = New RectangleF(baseRect.Location, sizeF)
				path.AddArc(arc, 180, 180)
				arc.Y = baseRect.Bottom - diameter
				path.AddArc(arc, 0, 180)
			Else
				' return circle 
				path.AddEllipse(baseRect)
			End If
		Catch ex As Exception
			path.AddEllipse(baseRect)
		Finally
			path.CloseFigure()
		End Try
		Return path
	End Function
	#End Region
End Class
