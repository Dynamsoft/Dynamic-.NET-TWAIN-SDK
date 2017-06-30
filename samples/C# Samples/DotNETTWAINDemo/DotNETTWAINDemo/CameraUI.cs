using Dynamsoft.Core;
using Dynamsoft.UVC;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DotNet_TWAIN_Demo
{
    public partial class CameraUI : Form
    {
        public CameraUI()
        {
            InitializeComponent();
        }

        private Camera m_Camera = null; 
        public Camera Camera
        {
            set
            {
                m_Camera = value;
                m_Camera.SetVideoContainer(this.Handle);
            }
            get
            {
                return m_Camera;
            }
        }


        private void CameraUI_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (m_Camera != null)
                m_Camera.Close();
        }

        private void CameraUI_SizeChanged(object sender, EventArgs e)
        {
            if (m_Camera!=null)
            {
                m_Camera.ResizeVideoWindow(0, menuStrip1.Height, this.ClientRectangle.Width, this.ClientRectangle.Height);
            }

        }

        private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            m_Camera.DisplayPropertyPage();
        }
    }
}
