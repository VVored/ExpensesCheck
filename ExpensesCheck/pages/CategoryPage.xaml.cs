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
            List<Category> categories = new List<Category>() { new Category("Еда", 10, Brushes.AliceBlue, "scheta.png")};
            this.categories = categories;
            lvCatergory.ItemsSource = this.categories;
            foreach (var category in this.categories)
            {
                pieChart.Series.Add(new PieSeries
                {
                    Title = category.Name,
                    Values = new ChartValues<decimal> { category.TotalBank },
                    
                });
            }
        }

        private void Chart_OnDataClick(object sender, ChartPoint chartpoint)
        {
            var chart = (PieChart)chartpoint.ChartView;

            //clear selected slice.
            foreach (PieSeries series in chart.Series)
                series.PushOut = 0;

            var selectedSeries = (PieSeries)chartpoint.SeriesView;
            selectedSeries.PushOut = 8;
        }
    }
}
