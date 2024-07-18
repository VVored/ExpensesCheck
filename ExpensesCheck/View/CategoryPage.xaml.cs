using ExpensesCheck.Model;
using LiveCharts.Wpf;
using LiveCharts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ExpensesCheck.Controller;

namespace ExpensesCheck.View
{
    /// <summary>
    /// Логика взаимодействия для CategoryPage.xaml
    /// </summary>
    public partial class CategoryPage : Page
    {
        List<MoneyBank> categories = new List<MoneyBank>();
        public CategoryPage()
        {
            InitializeComponent();
            InitializeListView();
            InitializePieChart();
        }
        public void InitializePieChart()
        {
            pieChart.Series = new SeriesCollection();
            foreach (var MoneyBank in categories)
            {
                pieChart.Series.Add(new PieSeries
                {
                    Title = MoneyBank.Name,
                    Values = new ChartValues<decimal> { MoneyBank.TotalBank },
                    Fill = MoneyBank.BrushFromColor,
                    DataLabels = true,
                    LabelPoint = pieChart => string.Format("{0}", pieChart.Y),
                });
            }
        }
        public void InitializeListView()
        {
            categories = MainWindow.moneyBankController.GetMoneyBanks().Where(moneybank => moneybank.Type == TypeOfMoneyBank.Категория).ToList();
            lvCategory.ItemsSource = categories;
        }

        private void deleteCategory(object sender, RoutedEventArgs e)
        {
            var category = lvCategory.SelectedItem as MoneyBank;
            if (category != null)
            {
                MainWindow.moneyBankController.RemoveMoneyBank(category);
                MainWindow.moneyBankController.SaveChangesToXml();
                InitializeListView();
            }
        }

        private void addCategory(object sender, RoutedEventArgs e)
        {
            var category = new MoneyBank();
            AddOrEditMoneyBankWindow addOrEditMoneyBankWindow = new AddOrEditMoneyBankWindow(category);
            addOrEditMoneyBankWindow.ShowDialog();
            InitializeListView();
        }

        private void editCategory(object sender, RoutedEventArgs e)
        {
            var category = lvCategory.SelectedItem as MoneyBank;
            if (category != null)
            {
                AddOrEditMoneyBankWindow addOrEditMoneyBankWindow = new AddOrEditMoneyBankWindow(category);
                addOrEditMoneyBankWindow.ShowDialog();
                InitializeListView();
            }
        }

        private void addOperation(object sender, RoutedEventArgs e)
        {
            var category = lvCategory.SelectedItem as MoneyBank;
            if (category != null)
            {
                var operation = new Operation();
                operation.Recipient = category;
                AddOperationWindow addOperationWindow = new AddOperationWindow(operation);
                addOperationWindow.ShowDialog();
                InitializeListView();
                InitializePieChart();
            }
        }
    }
}
