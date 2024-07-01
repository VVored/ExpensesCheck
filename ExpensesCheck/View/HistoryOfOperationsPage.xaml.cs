using ExpensesCheck.Controller;
using ExpensesCheck.Model;
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
    /// Логика взаимодействия для HistoryOfOperationsPage.xaml
    /// </summary>
    public partial class HistoryOfOperationsPage : Page
    {
        OperationController operationController;
        public HistoryOfOperationsPage()
        {
            InitializeComponent();
            List<Operation> operations = new List<Operation>() { new Operation(100, new MoneyBank("mew", 100, Brushes.AliceBlue, "scheta.png", TypeOfMoneyBank.Счет), new MoneyBank("mew", 100, Brushes.AliceBlue, "scheta.png", TypeOfMoneyBank.Категория), DateTime.Now), new Operation(100, new MoneyBank("mew", 100, Brushes.AliceBlue, "scheta.png", TypeOfMoneyBank.Счет), new MoneyBank("mew", 100, Brushes.AliceBlue, "scheta.png", TypeOfMoneyBank.Категория), DateTime.Now) };
            operationController = new OperationController(operations);
            lvOperations.ItemsSource = operations;
        }
    }
}
