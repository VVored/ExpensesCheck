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

namespace ExpensesCheck.View
{
    /// <summary>
    /// Логика взаимодействия для CategoryPage.xaml
    /// </summary>
    public partial class CategoryPage : Page
    {
        List<MoneyBank> categories;
        public CategoryPage()
        {
            InitializeComponent();
            List<MoneyBank> categories = new List<MoneyBank>() { new MoneyBank(1, "ZZZ", 10, Brushes.Blue, "scheta.png", TypeOfMoneyBank.Категория), new MoneyBank(1, "VVV", 10, Brushes.Red, "scheta.png", TypeOfMoneyBank.Категория) };
            this.categories = categories;
            lvCatergory.ItemsSource = this.categories;
            foreach (var MoneyBank in this.categories)
            {
                pieChart.Series.Add(new PieSeries
                {
                    Title = MoneyBank.Name,
                    Values = new ChartValues<decimal> { MoneyBank.TotalBank },
                    Fill = MoneyBank.Color,
                    DataLabels = true,
                    LabelPoint = pieChart => string.Format("{0}", pieChart.Y),
                });
            }
        }
    }
}
