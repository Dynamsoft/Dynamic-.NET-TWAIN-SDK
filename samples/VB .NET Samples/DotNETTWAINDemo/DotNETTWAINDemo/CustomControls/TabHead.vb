Imports System.Collections.Generic
Imports System.Text
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Windows.Forms

Class TabHead
	Inherits Label
	Public Sub New()
			'this.SetStyle(ControlStyles.Opaque, true);
			'this.SetStyle(ControlStyles.OptimizedDoubleBuffer, false);
		MyBase.New()
	End Sub

	'protected override CreateParams CreateParams
	'{
	'    get
	'    {
	'        CreateParams param = base.CreateParams;
	'        param.ExStyle |= 0x20;
	'        return param;
	'    }
	'}

	Private m_bMultiTabHead As Boolean

	Public Property MultiTabHead() As Boolean
		Get
			Return m_bMultiTabHead
		End Get
		Set
			m_bMultiTabHead = value
		End Set
	End Property

	Private m_iIndex As Integer

	Public Property Index() As Integer
		Get
			Return m_iIndex
		End Get
		Set
			m_iIndex = value
		End Set
	End Property

	Public Enum TabHeadState
		SELECTED
		FOLDED
		ALLFOLDED
	End Enum

	Private m_enumState As TabHeadState = TabHeadState.ALLFOLDED

	Public Property State() As TabHeadState
		Get
			Return m_enumState
		End Get
		Set
			m_enumState = value
			If value = TabHeadState.SELECTED Then
				If m_bMultiTabHead Then
                    Image = small_arrow_up
                Else
                    Image = big_arrow_up
                End If
            ElseIf m_bMultiTabHead Then
                Image = small_arrow_down
            Else
                Image = big_arrow_down
			End If
			Invalidate()
		End Set
	End Property

	Protected Overrides Sub OnPaintBackground(pevent As PaintEventArgs)
		Dim rec As Rectangle = pevent.ClipRectangle
		If m_bMultiTabHead Then
			If m_enumState = TabHeadState.SELECTED Then
				MyBase.OnPaintBackground(pevent)
			Else
				Dim cTop As Color = Color.FromArgb(255, &Hfa, &Hfa, &Hfa)
				Dim cBottom As Color = Color.FromArgb(255, &Heb, &Heb, &Heb)
				Dim backBrush As New System.Drawing.Drawing2D.LinearGradientBrush(rec.Location, New Point(rec.Left, rec.Bottom), cTop, cBottom)
				pevent.Graphics.FillRectangle(backBrush, pevent.ClipRectangle)
				backBrush.Dispose()

				Dim pen As New Pen(Color.FromArgb(255, 208, 208, 208), 1)
				If m_enumState <> TabHeadState.ALLFOLDED Then
					Dim penBottom As New Pen(Color.FromArgb(255, 165, 165, 165), 1)
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
			Dim cTop As Color = Color.FromArgb(255, &Hfa, &Hfa, &Hfa)
			Dim cBottom As Color = Color.FromArgb(255, &Heb, &Heb, &Heb)
			Dim backBrush As New System.Drawing.Drawing2D.LinearGradientBrush(rec.Location, New Point(rec.Left, rec.Bottom), cTop, cBottom)
			pevent.Graphics.FillRectangle(backBrush, pevent.ClipRectangle)
			backBrush.Dispose()
		End If
	End Sub
End Class
