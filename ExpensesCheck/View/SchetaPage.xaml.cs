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
    /// Логика взаимодействия для SchetaPage.xaml
    /// </summary>
    public partial class SchetaPage : Page
    {
        public SchetaPage()
        {
            InitializeComponent();
            InitializeListView();
        }

        public void InitializeListView()
        {
            List<MoneyBank> wallets = MainWindow.moneyBankController.GetMoneyBanks().Where(moneybank => moneybank.Type == TypeOfMoneyBank.Счет).ToList();
            lvScheta.ItemsSource = wallets;
        }

        private void deleteWallet(object sender, RoutedEventArgs e)
        {
            var wallet = (sender as Button).DataContext as MoneyBank;
            if (wallet != null)
            {
                MainWindow.moneyBankController.RemoveMoneyBank(wallet);
                MainWindow.moneyBankController.SaveChangesToXml();
                InitializeListView();
            }
        }

        private void AddWalletWindowOpen(object sender, RoutedEventArgs e)
        {
            MoneyBank newMoneyBank = new MoneyBank();
            newMoneyBank.Type = TypeOfMoneyBank.Счет;
            AddOrEditMoneyBankWindow addOrEditMoneyBankWindow = new AddOrEditMoneyBankWindow(newMoneyBank);
            addOrEditMoneyBankWindow.ShowDialog();
            InitializeListView();
        }

        private void EditWalletWindowOpen(object sender, RoutedEventArgs e)
        {
            var wallet = (sender as Button).DataContext as MoneyBank;
            AddOrEditMoneyBankWindow addOrEditMoneyBankWindow = new AddOrEditMoneyBankWindow(wallet);
            addOrEditMoneyBankWindow.ShowDialog();
            InitializeListView();
        }
    }
}
