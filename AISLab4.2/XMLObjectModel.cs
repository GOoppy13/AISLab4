using System;
using System.Windows;
using System.Xml.Linq;

namespace AISLab4._2
{
    class XMLObjectModel
    {
        public static XDocument GetXDocument(string path)
        {
            try
            {
                XDocument xDoc = XDocument.Load(path);
                return xDoc;
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
                return null;
            }
        }
    }
}
