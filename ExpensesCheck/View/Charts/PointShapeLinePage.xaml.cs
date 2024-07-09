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
using ExpensesCheck.Model;

namespace ExpensesCheck.View.Charts
{
    /// <summary>
    /// Логика взаимодействия для PointShapeLinePage.xaml
    /// </summary>
    public partial class PointShapeLinePage : Page
    {
        OperationController controller = new OperationController();
        public PointShapeLinePage()
        {
            InitializeComponent();
            List<Operation> operations = controller.GetOperations();
            PointShapeLine pointShapeLine = new PointShapeLine(operations);
            DataContext = pointShapeLine;
        }
    }
}
