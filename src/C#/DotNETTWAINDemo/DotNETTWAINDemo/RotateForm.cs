using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DotNet_TWAIN_Demo
{
    public partial class RotateForm : Form
    {
        public RotateForm()
        {
            InitializeComponent();

            this.tbxAngle.Text = "45";
            this.cbxInterPolation.SelectedIndex = 1;
            this.cbxKeepSize.Checked = false;
            this.tbxR.Text = "255";
            this.tbxG.Text = "255";
            this.tbxB.Text = "255";

            this.DialogResult = DialogResult.Cancel;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            double angle;
            int r, g, b;

            if (!double.TryParse(tbxAngle.Text, out angle))
            {
                tbxAngle.Focus();
                return;
            }

            if (!int.TryParse(tbxR.Text, out r) || r < 0 || r > 255 )
            {
                tbxR.Focus();
                return;
            }

            if (!int.TryParse(tbxG.Text, out g) || g < 0 || g > 255)
            {
                tbxG.Focus();
                return;
            }

            if (!int.TryParse(tbxB.Text, out b) || b < 0 || b > 255)
            {
                tbxB.Focus();
                return;
            }
            
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
