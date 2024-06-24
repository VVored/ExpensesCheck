﻿using System;
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
    /// Логика взаимодействия для SchetaPage.xaml
    /// </summary>
    public partial class SchetaPage : Page
    {
        public SchetaPage()
        {
            InitializeComponent();
            List<Wallet> wallets = new List<Wallet>();
            Wallet wallet = new Wallet("Карта", 17000, Brushes.AliceBlue, "scheta.png");
            Wallet wallet1 = new Wallet("brat", 17000, Brushes.GreenYellow, "scheta.png");
            wallets.Add(wallet);
            wallets.Add(wallet1);
            lvScheta.ItemsSource = wallets;
        }
    }
}
