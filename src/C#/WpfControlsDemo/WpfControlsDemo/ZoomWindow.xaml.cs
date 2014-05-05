using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfControlsDemo
{
    /// <summary>
    /// Interaction logic for ZoomWindow.xaml
    /// </summary>
    public partial class ZoomWindow : Window
    {
        public ZoomWindow(float fZoom)
        {
            InitializeComponent();
            tbRatio.Text = (fZoom * 100).ToString();
            tbRatio.Focus();
        }

        float m_fRatio;

        private void OK_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                m_fRatio = float.Parse(tbRatio.Text);
                if (m_fRatio < 2 || m_fRatio > 6500)
                {
                    lbHint.Content = "Please input a float number between 2 and 6500";
                    return;
                }
            }
            catch (Exception exp)
            {
                lbHint.Content = "Please input a float number between 2 and 6500";
                return;
            }
            this.DialogResult = true;
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }

        public float ZoomRatio
        {
            get
            {
                return m_fRatio / 100;
            }
        }
    }
}
