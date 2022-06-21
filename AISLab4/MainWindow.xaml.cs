using System.IO;
using System.Windows;
using System.Xml.Linq;

namespace AISLab4
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private XDocument xDoc;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                xDoc = XDocument.Load("CarDealer.xml");
                listBoxCar.DataContext = xDoc.Descendants("CarDealer").Elements();
                textBoxShowXML.Text = xDoc.ToString();
            }
            catch (FileNotFoundException ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }

        private void addBtn_Click(object sender, RoutedEventArgs e)
        {
            XElement newCar = new XElement("car",
                new XAttribute("id", -1),
                new XElement("model", "'Модель'"),
                new XElement("company", "'Фирма'"),
                new XElement("price", "'Цена'"),
                new XElement("body", "'Кузов'"),
                new XElement("responsible", "'Ответственный'"),
                new XElement("power", "'Мощность'"));
            xDoc.Element("CarDealer").Element("car").AddBeforeSelf(newCar);
            UpdateData();
        }

        private void removeBtn_Click(object sender, RoutedEventArgs e)
        {
            int i = listBoxCar.SelectedIndex;
            if (i < 0)
            {
                return;
            }
            XElement selectedCar = (XElement)listBoxCar.SelectedItem;
            selectedCar.Remove();
            UpdateData();
        }

        private void saveXData_Click(object sender, RoutedEventArgs e)
        {
            textBoxShowXML.Text = xDoc.ToString();
            xDoc.Save("CarDealer.xml");
        }
        
        private void UpdateData()
        {
            listBoxCar.DataContext = xDoc.Descendants("CarDealer").Elements();
            textBoxShowXML.Text = xDoc.ToString();
            xDoc.Save("CarDealer.xml");
        }
    }
}
