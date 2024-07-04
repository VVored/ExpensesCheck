using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ExpensesCheck
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void SchetaPageOpen(object sender, RoutedEventArgs e)
        {
            frame.NavigationService.Navigate(new View.SchetaPage());
        }

        private void CategoryPageOpen(object sender, RoutedEventArgs e)
        {
            frame.NavigationService.Navigate(new View.CategoryPage());
        }

        private void HistoryOfOperationsPage(object sender, RoutedEventArgs e)
        {
            frame.NavigationService.Navigate(new View.HistoryOfOperationsPage());
        }

        private void StatPageOpen(object sender, RoutedEventArgs e)
        {
            frame.NavigationService.Navigate(new View.StatPage());
        }
    }
}