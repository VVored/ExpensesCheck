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
using System.Windows.Shapes;

namespace ExpensesCheck.View
{
    /// <summary>
    /// Логика взаимодействия для AddOperationWindow.xaml
    /// </summary>
    public partial class AddOperationWindow : Window
    {
        Operation operation { get; set; }
        public AddOperationWindow(Operation operation)
        {
            InitializeComponent();
            this.operation = operation;
            DataContext = this.operation;
        }

        private void EditSender(object sender, RoutedEventArgs e)
        {
            SelectMoneyBankWindow selectMoneyBankWindow = new SelectMoneyBankWindow(operation, "Sender");
            selectMoneyBankWindow.ShowDialog();
            DataContext = null;
            DataContext = operation;
        }

        private void EditRecipient(object sender, RoutedEventArgs e)
        {
            SelectMoneyBankWindow selectMoneyBankWindow = new SelectMoneyBankWindow(operation, "Recipient");
            selectMoneyBankWindow.ShowDialog();
            DataContext = null;
            DataContext = operation;
        }

        private void CreateOperation(object sender, RoutedEventArgs e)
        {
            operation.Id = Guid.NewGuid().ToString("N");
            if (operation.MoneyAmount > 0)
            {
                MainWindow.operationController.AddOperation(operation);
                MainWindow.moneyBankController.SaveChangesToXml();
                MainWindow.operationController.SaveChangesToXml();
                Close();
            }
        }
    }
}
