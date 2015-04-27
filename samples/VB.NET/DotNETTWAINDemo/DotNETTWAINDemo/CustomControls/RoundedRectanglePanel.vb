Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Windows.Forms

Public Class RoundedRectanglePanel
    Inherits Panel

    Sub New()
        MyBase.New()
        Me.Padding = New Padding(1, 1, 1, 1)
    End Sub

    Sub RoundedRectanglePanel_SizeChanged(ByVal sender As Object, ByVal e As EventArgs) Handles Me.SizeChanged
        Dim bmp As Bitmap : bmp = New Bitmap(Me.Bounds.Width, Me.Bounds.Height)
        Dim g As Graphics : g = Graphics.FromImage(bmp)

        Dim bounds As Rectangle : bounds = New Rectangle(0, 0, Me.Bounds.Width, Me.Bounds.Height)
        Dim cTopBorder As Color : cTopBorder = Color.FromArgb(255, 221, 221, 221)
        Dim cBottomBorder As Color : cBottomBorder = Color.FromArgb(255, 165, 165, 165)
        Dim cTop As Color : cTop = Color.FromArgb(255, &HFA, &HFA, &HFA)
        Dim cBottom As Color : cBottom = Color.FromArgb(255, &HEB, &HEB, &HEB)
        Dim backBrush As System.Drawing.Drawing2D.LinearGradientBrush : backBrush = New System.Drawing.Drawing2D.LinearGradientBrush(bounds.Location, New Point(bounds.Left, bounds.Bottom), cTop, cBottom)
        Dim borderBrush As System.Drawing.Drawing2D.LinearGradientBrush : borderBrush = New LinearGradientBrush(bounds.Location, New Point(bounds.Left, bounds.Bottom), cTopBorder, cBottomBorder)
        Dim pen As System.Drawing.Pen : pen = New Pen(borderBrush)
        Dim graphicPath As System.Drawing.Drawing2D.GraphicsPath : graphicPath = GetRoundedRect(New RectangleF(bounds.X, bounds.Y, bounds.Width - 1, bounds.Height - 1), 3)

        g.SmoothingMode = SmoothingMode.AntiAlias
        g.FillPath(backBrush, graphicPath)
        g.DrawPath(Pen, graphicPath)

        Me.BackgroundImage = bmp

        backBrush.Dispose()
        borderBrush.Dispose()
        Pen.Dispose()
        graphicPath.Dispose()
        g.Dispose()
    End Sub

#Region "Refrenced (CodeProject)"

    Private Function GetRoundedRect(ByVal baseRect As RectangleF, ByVal radius As Single) As GraphicsPath
        ' if corner radius is less than or equal to zero, 
        ' return the original rectangle 
        If radius <= 0.0F Then
            Dim mPath As GraphicsPath : mPath = New GraphicsPath()
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
        Dim diameter As Single : diameter = radius * 2.0F
        Dim sizeF As SizeF : sizeF = New SizeF(diameter, diameter)
        Dim arc As RectangleF : arc = New RectangleF(baseRect.Location, sizeF)
        Dim path As GraphicsPath : path = New System.Drawing.Drawing2D.GraphicsPath()

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

    Private Function GetCapsule(ByVal baseRect As RectangleF) As GraphicsPath
        Dim diameter As Single
        Dim arc As RectangleF
        Dim path As GraphicsPath : path = New System.Drawing.Drawing2D.GraphicsPath()
        Try
            If baseRect.Width > baseRect.Height Then
                ' return horizontal capsule 
                diameter = baseRect.Height
                Dim sizeF As SizeF : sizeF = New SizeF(diameter, diameter)
                arc = New RectangleF(baseRect.Location, sizeF)
                path.AddArc(arc, 90, 180)
                arc.X = baseRect.Right - diameter
                path.AddArc(arc, 270, 180)
            ElseIf baseRect.Width < baseRect.Height Then
                ' return vertical capsule 
                diameter = baseRect.Width
                Dim sizeF As SizeF : sizeF = New SizeF(diameter, diameter)
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
