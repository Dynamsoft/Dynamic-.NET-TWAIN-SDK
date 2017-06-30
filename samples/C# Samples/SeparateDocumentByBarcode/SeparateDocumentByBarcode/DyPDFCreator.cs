using System;
using System.Collections.Generic;
using System.Text;
using Dynamsoft.PDF;
using Dynamsoft.Core;
using Dynamsoft.Core.Enums;

namespace SeparateDocumentByBarcode
{
     public class DyPDFCreator:ISave
    {
         private ImageCore m_ImageCore = null;
         private List<short> m_IndexList = null;
         private PDFCreator m_PDFCreator = null;

         public DyPDFCreator(ImageCore imageCore,List<short> indexList,PDFCreator pdfCreator)
         {
             m_ImageCore = imageCore;
             m_IndexList = indexList;
             m_PDFCreator = pdfCreator;
 
         }

         public void SaveAsPDF(string strFileName)
         {
             m_PDFCreator.Save(this as ISave,strFileName);
         }
        #region ISave Members

        public object GetAnnotations(int iPageNumber)
        {
            object tempObject = null;
            if (m_ImageCore != null&&m_IndexList!=null)
            {
                tempObject = m_ImageCore.ImageBuffer.GetMetaData(m_IndexList[iPageNumber],EnumMetaDataType.enumAnnotation);
            }
            return tempObject;
        }

        public System.Drawing.Bitmap GetImage(int iPageNumber)
        {
            System.Drawing.Bitmap tempBitmap = null;
            if (m_ImageCore != null && m_IndexList != null)
                tempBitmap = m_ImageCore.ImageBuffer.GetBitmap(m_IndexList[iPageNumber]);
            return tempBitmap;
        }

        public int GetPageCount()
        {
            int sCount = 0;
            if (m_IndexList != null)
                sCount = m_IndexList.Count;
            return sCount;
        }

        #endregion
    }
}
