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
    /// Логика взаимодействия для SelectMoneyBankWindow.xaml
    /// </summary>
    public partial class SelectMoneyBankWindow : Window
    {
        List<MoneyBank> moneyBanks = MainWindow.moneyBankController.GetMoneyBanks();
        Operation operation;
        string senderOrRecipient;
        public SelectMoneyBankWindow(Operation operation, string senderOrRecipient)
        {
            InitializeComponent();
            this.operation = operation;
            this.senderOrRecipient = senderOrRecipient;
            lvMoneyBanks.ItemsSource = MainWindow.moneyBankController.GetMoneyBanks();
        }
        private void tbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            Search();
        }
        private void cbFilterByType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Filter();
        }

        private void cbSortByParams_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Sort();
        }
        public void Search()
        {
            if (tbSearch.Text.Length > 0)
            {
                moneyBanks = moneyBanks.Where(moneybank => moneybank.Name.ToLower().Contains(tbSearch.Text.ToLower())).ToList();
            }
            InitializeListView();
        }
        public void Sort()
        {
            if (cbSortByParams.SelectedIndex == 0)
            {
                moneyBanks = moneyBanks.OrderBy(moneybank => moneybank.Name).ToList();
                InitializeListView();
            }
            else
            {
                moneyBanks = moneyBanks.OrderBy(moneybank => moneybank.TotalBank).ToList();
                InitializeListView();
            }
        }
        public void Filter()
        {
            if (cbFilterByType.SelectedIndex != 0)
            {
                moneyBanks = MainWindow.moneyBankController.GetMoneyBanks();
                moneyBanks = moneyBanks.Where(moneybank => (int)moneybank.Type == cbFilterByType.SelectedIndex).ToList();
                InitializeListView();
            }
            else
            {
                moneyBanks = MainWindow.moneyBankController.GetMoneyBanks();
                InitializeListView();
            }
            Search();
            Sort();
        }
        public void InitializeListView()
        {
            lvMoneyBanks.ItemsSource = null;
            lvMoneyBanks.ItemsSource = moneyBanks;
        }

        private void SelectMoneyBank(object sender, RoutedEventArgs e)
        {
            var selectedItem = lvMoneyBanks.SelectedItem as MoneyBank;
            if (selectedItem != null)
            {
                if (senderOrRecipient == "Sender")
                {
                    operation.Sender = selectedItem;
                }
                else if (senderOrRecipient == "Recipient")
                {
                    operation.Recipient = selectedItem;
                }
                Close();
            }
        }
    }
}
