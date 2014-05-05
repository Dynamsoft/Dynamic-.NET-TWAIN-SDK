using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DotNet_TWAIN_Demo
{
    public partial class ZoomForm : Form
    {
        private int zoomRatio;
        
        public ZoomForm() : this(1)
        {
            
        }

        public ZoomForm(float ratio)
        {
            InitializeComponent();
            ZoomRatio = ratio;
            this.DialogResult = DialogResult.Cancel;

        }

        public float ZoomRatio
        {
            get { return zoomRatio / 100F; }
            set 
            {
                zoomRatio = (int)(value * 100 + 0.1);
                this.tbxZoomRatio.Text = zoomRatio.ToString();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            int ratio = -1;

            if (!int.TryParse(tbxZoomRatio.Text, out ratio) || ratio < 2 || ratio > 6500)
            {
                tbxZoomRatio.Focus();
                return;
            }
            else
                zoomRatio = ratio;

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void tbxZoomRatio_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == 13)
                btnOK_Click(this, null);
        }
    }
}
