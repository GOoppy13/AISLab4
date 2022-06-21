using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Xml.Linq;

namespace AISLab4._2
{
    /// <summary>
    /// Логика взаимодействия для LaptopsPage.xaml
    /// </summary>
    public partial class LaptopsPage : Page
    {
        public LaptopsPage()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            XDocument docLaptops = XDocument.Load("laptops.xml");
            var laptops = from laptop in docLaptops.Descendants("Laptop")
                          select laptop;
            LaptopsDataGrid.ItemsSource = laptops;
        }
    }
}
