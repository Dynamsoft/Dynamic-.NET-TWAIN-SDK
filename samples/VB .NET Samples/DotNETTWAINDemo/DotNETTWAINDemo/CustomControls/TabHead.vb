Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Windows.Forms

Public Class TabHead
    Inherits Label


    Sub New()
        MyBase.New()
        m_enumState = TabHeadState.ALLFOLDED
    End Sub


    Private m_bMultiTabHead As Boolean

    Property MultiTabHead() As Boolean
        Get
            Return m_bMultiTabHead
        End Get
        Set(ByVal value As Boolean)
            m_bMultiTabHead = value
        End Set
    End Property

    Private m_iIndex As Integer

    Property Index() As Integer
        Get
            Return m_iIndex
        End Get
        Set(ByVal value As Integer)
            m_iIndex = value
        End Set
    End Property

    Public Enum TabHeadState
        SELECTED
        FOLDED
        ALLFOLDED
    End Enum


    Private m_enumState As TabHeadState

    Property State() As TabHeadState
        Get
            Return m_enumState
        End Get
        Set(ByVal value As TabHeadState)
            m_enumState = Value
            If Value = TabHeadState.SELECTED Then
                If m_bMultiTabHead Then
                    Image = My.Resources.small_arrow_up
                Else
                    Image = My.Resources.big_arrow_up
                End If
            Else
                If m_bMultiTabHead Then
                    Image = My.Resources.small_arrow_down
                Else
                    Image = My.Resources.big_arrow_down
                End If
                Invalidate()
            End If
        End Set
    End Property

    Protected Overrides Sub OnPaintBackground(ByVal pevent As PaintEventArgs)
        Dim rec As Rectangle : rec = pevent.ClipRectangle
        If m_bMultiTabHead Then
            If m_enumState = TabHeadState.SELECTED Then
                MyBase.OnPaintBackground(pevent)
            Else
                Dim cTop As Color : cTop = Color.FromArgb(255, &HFA, &HFA, &HFA)
                Dim cBottom As Color : cBottom = Color.FromArgb(255, &HEB, &HEB, &HEB)
                Dim backBrush As System.Drawing.Drawing2D.LinearGradientBrush : backBrush = New System.Drawing.Drawing2D.LinearGradientBrush(rec.Location, New Point(rec.Left, rec.Bottom), cTop, cBottom)
                pevent.Graphics.FillRectangle(backBrush, pevent.ClipRectangle)
                backBrush.Dispose()

                Dim pen As Pen : pen = New Pen(Color.FromArgb(255, 208, 208, 208), 1)
                If Not m_enumState = TabHeadState.ALLFOLDED Then
                    Dim penBottom As Pen : penBottom = New Pen(Color.FromArgb(255, 165, 165, 165), 1)
                    pevent.Graphics.DrawLine(penBottom, rec.Left, rec.Bottom - 1, rec.Right - 1, rec.Bottom - 1)
                    penBottom.Dispose()
                    If m_iIndex Mod 2 = 0 Then
                        pevent.Graphics.DrawLine(pen, rec.Right - 1, rec.Top, rec.Right - 1, rec.Bottom - 1)
                    End If
                End If

                If m_iIndex Mod 2 = 1 Then
                    pevent.Graphics.DrawLine(pen, rec.Left, rec.Top, rec.Left, rec.Bottom - 1)
                End If
                pen.Dispose()
            End If
        Else
            Dim cTop As Color : cTop = Color.FromArgb(255, &HFA, &HFA, &HFA)
            Dim cBottom As Color : cBottom = Color.FromArgb(255, &HEB, &HEB, &HEB)
            Dim backBrush As System.Drawing.Drawing2D.LinearGradientBrush : backBrush = New System.Drawing.Drawing2D.LinearGradientBrush(rec.Location, New Point(rec.Left, rec.Bottom), cTop, cBottom)
            pevent.Graphics.FillRectangle(backBrush, pevent.ClipRectangle)
            backBrush.Dispose()
        End If
    End Sub
End Class
