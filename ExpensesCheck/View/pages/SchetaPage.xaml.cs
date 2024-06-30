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
using ExpensesCheck.Model;

namespace ExpensesCheck.View.pages
{
    /// <summary>
    /// Логика взаимодействия для SchetaPage.xaml
    /// </summary>
    public partial class SchetaPage : Page
    {
        public SchetaPage()
        {
            InitializeComponent();
            List<MoneyBank> MoneyBanks = new List<MoneyBank>();
            MoneyBank wallet = new MoneyBank("Карта", 17000, Brushes.AliceBlue, "scheta.png", TypeOfMoneyBank.Счет);
            MoneyBank wallet1 = new MoneyBank("brat", 17000, Brushes.GreenYellow, "scheta.png", TypeOfMoneyBank.Счет);
            MoneyBanks.Add(wallet);
            MoneyBanks.Add(wallet1);
            lvScheta.ItemsSource = MoneyBanks;
        }
    }
}
