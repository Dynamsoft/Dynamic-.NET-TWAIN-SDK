using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace DotNet_TWAIN_Demo
{
    class TabHead : Label
    {
        public TabHead()
            : base()
        {
            //this.SetStyle(ControlStyles.Opaque, true);
            //this.SetStyle(ControlStyles.OptimizedDoubleBuffer, false);
        }

        //protected override CreateParams CreateParams
        //{
        //    get
        //    {
        //        CreateParams param = base.CreateParams;
        //        param.ExStyle |= 0x20;
        //        return param;
        //    }
        //}

        private bool m_bMultiTabHead;

        public bool MultiTabHead
        {
            get { return m_bMultiTabHead; }
            set { m_bMultiTabHead = value; }
        }

        private int m_iIndex;

        public int Index
        {
            get { return m_iIndex; }
            set { m_iIndex = value; }
        }

        public enum TabHeadState
        {
            SELECTED,
            FOLDED,
            ALLFOLDED
        }

        private TabHeadState m_enumState = TabHeadState.ALLFOLDED;

        public TabHeadState State
        {
            get { return m_enumState; }
            set 
            { 
                m_enumState = value;
                if (value == TabHeadState.SELECTED)
                    if (m_bMultiTabHead)
                        Image = Properties.Resources.small_arrow_up;
                    else
                        Image = Properties.Resources.big_arrow_up;
                else
                    if (m_bMultiTabHead)
                        Image = Properties.Resources.small_arrow_down;
                    else
                        Image = Properties.Resources.big_arrow_down;
                Invalidate();
            }
        }

        protected override void  OnPaintBackground(PaintEventArgs pevent)
        {
            Rectangle rec = pevent.ClipRectangle;
            if (m_bMultiTabHead)
            {
                if (m_enumState == TabHeadState.SELECTED)
                {
                    base.OnPaintBackground(pevent);
                }               
                else
                {
                    Color cTop = Color.FromArgb(255, 0xFA, 0xFA, 0xFA);
                    Color cBottom = Color.FromArgb(255, 0xEB, 0xEB, 0xEB);
                    System.Drawing.Drawing2D.LinearGradientBrush backBrush = new System.Drawing.Drawing2D.LinearGradientBrush(rec.Location, new Point(rec.Left, rec.Bottom), cTop, cBottom);
                    pevent.Graphics.FillRectangle(backBrush, pevent.ClipRectangle);
                    backBrush.Dispose();

                    Pen pen = new Pen(Color.FromArgb(255, 208, 208, 208), 1);
                    if (m_enumState != TabHeadState.ALLFOLDED)
                    {
                        Pen penBottom = new Pen(Color.FromArgb(255, 165, 165, 165), 1);
                        pevent.Graphics.DrawLine(penBottom, rec.Left, rec.Bottom - 1, rec.Right - 1, rec.Bottom - 1);
                        penBottom.Dispose();
                        if (m_iIndex % 2 == 0)
                            pevent.Graphics.DrawLine(pen, rec.Right - 1, rec.Top, rec.Right - 1, rec.Bottom - 1);
                    }

                    if (m_iIndex % 2 == 1)
                        pevent.Graphics.DrawLine(pen, rec.Left, rec.Top, rec.Left, rec.Bottom - 1);
                    
                    pen.Dispose();
                }
            }
            else
            {
                Color cTop = Color.FromArgb(255, 0xFA, 0xFA, 0xFA);
                Color cBottom = Color.FromArgb(255, 0xEB, 0xEB, 0xEB);
                System.Drawing.Drawing2D.LinearGradientBrush backBrush = new System.Drawing.Drawing2D.LinearGradientBrush(rec.Location, new Point(rec.Left, rec.Bottom), cTop, cBottom);
                pevent.Graphics.FillRectangle(backBrush, pevent.ClipRectangle);
                backBrush.Dispose();
            }
        }
    }
}
