using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Xml.Linq;

namespace AISLab4._2
{
    /// <summary>
    /// Логика взаимодействия для AutoPage.xaml
    /// </summary>
    public partial class AutoPage : Page
    {
        public AutoPage()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            XDocument docAuto = XMLObjectModel.GetXDocument("CarDealer.xml");
            var autos = from car in docAuto.Descendants("car")
                        select car;
            AutoDataGrid.ItemsSource = autos;
        }
    }
}
