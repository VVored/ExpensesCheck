using ExpensesCheck.Model;
using LiveCharts;
using LiveCharts.Defaults;
using LiveCharts.Definitions.Charts;
using LiveCharts.Wpf;
using System.Windows.Controls;
using System.Windows.Media;

namespace ExpensesCheck.View.pages
{
    /// <summary>
    /// Логика взаимодействия для MoneyBankPage.xaml
    /// </summary>
    public partial class CategoryPage : Page
    {
        List<MoneyBank> categories;
        SeriesCollection pieSeries { get; set; }
        public CategoryPage()
        {
            InitializeComponent();
            List<MoneyBank> categories = new List<MoneyBank>() { new MoneyBank("ZZZ", 10, Brushes.Blue, "scheta.png", TypeOfMoneyBank.Категория), new MoneyBank("VVV", 10, Brushes.Red, "scheta.png", TypeOfMoneyBank.Категория) };
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
