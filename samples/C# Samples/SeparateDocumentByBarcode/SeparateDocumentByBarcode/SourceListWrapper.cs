using System;
using System.Collections.Generic;
using System.Text;

namespace SeparateDocumentByBarcode
{
    public class SourceListWrapper
    {
        private List<string> m_listSourceNames = null;
        public SourceListWrapper(List<string> listSourceNames)
        {
            m_listSourceNames = listSourceNames;
        }

        private int m_SelectedIndex = 0;
        public int SelectSource()
        {
            SourceListForm temp = new SourceListForm(m_listSourceNames);
            temp.ShowDialog();
            m_SelectedIndex = temp.GetSelectedIndex();
            return m_SelectedIndex;
        }

    }
}
