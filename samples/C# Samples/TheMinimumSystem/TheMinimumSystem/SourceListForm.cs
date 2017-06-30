using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TheMinimumSystem
{
    public partial class SourceListForm : Form
    {
        private List<string> m_ListSourceNames = null;
        private int m_SelectedIndex = -1;
        public SourceListForm(List<string> listSourceNames)
        {
            InitializeComponent();
            m_ListSourceNames = listSourceNames;
            if (m_ListSourceNames == null)
                button1.Enabled = false;

            foreach(string temp in m_ListSourceNames)
            {
                listBox1.Items.Add(temp);
            }
            listBox1.SelectedIndex = m_ListSourceNames.Count - 1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            m_SelectedIndex = listBox1.SelectedIndex;
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        public int GetSelectedIndex()
        {
            return m_SelectedIndex;
        }
    }
}
