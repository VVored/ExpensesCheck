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

namespace ExpensesCheck.pages
{
    /// <summary>
    /// Логика взаимодействия для CategoryPage.xaml
    /// </summary>
    public partial class CategoryPage : Page
    {
        public CategoryPage()
        {
            InitializeComponent();
            List<Category> categories = new List<Category>();
            Category category = new Category("Еда", 0, Brushes.AliceBlue, "scheta.png");
            Category category1 = new Category("Еда", 0, Brushes.Yellow, "scheta.png");
            categories.Add(category);
            categories.Add(category1);
            lvCatergory.ItemsSource = categories;
        }
    }
}
