using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Xml.Linq;

namespace AISLab4._2
{
    /// <summary>
    /// Логика взаимодействия для EmployeesPage.xaml
    /// </summary>
    public partial class EmployeesPage : Page
    {
        public EmployeesPage()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            XDocument docEmployees = XMLObjectModel.GetXDocument("employees.xml");
            var employees = from employe in docEmployees.Descendants("работник")
                            select employe;
            EmployeesDataGrid.ItemsSource = employees;
        }
    }
}
