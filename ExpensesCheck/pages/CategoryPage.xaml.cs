using LiveCharts;
using LiveCharts.Defaults;
using LiveCharts.Definitions.Charts;
using LiveCharts.Wpf;
using System.Windows.Controls;
using System.Windows.Media;

namespace ExpensesCheck.pages
{
    /// <summary>
    /// Логика взаимодействия для CategoryPage.xaml
    /// </summary>
    public partial class CategoryPage : Page
    {
        List<Category> categories;
        SeriesCollection pieSeries { get; set; }
        public CategoryPage()
        {
            InitializeComponent();
            List<Category> categories = new List<Category>() { new Category("ZZZ", 10, Brushes.Blue, "scheta.png"), new Category("VVV", 10, Brushes.Red, "scheta.png") };
            this.categories = categories;
            lvCatergory.ItemsSource = this.categories;
            foreach (var category in this.categories)
            {
                pieChart.Series.Add(new PieSeries
                {
                    Title = category.Name,
                    Values = new ChartValues<decimal> { category.TotalBank },
                    Fill = category.Color,
                    DataLabels = true,
                    LabelPoint = pieChart => string.Format("{0}", pieChart.Y),
                });
            }
        }
    }
}
