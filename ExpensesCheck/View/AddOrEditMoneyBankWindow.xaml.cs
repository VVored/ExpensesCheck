﻿using ExpensesCheck.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.Metadata;
using System.Reflection;
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
using Mono.Cecil;
using Mono.Cecil.Cil;

namespace ExpensesCheck.View
{
    /// <summary>
    /// Логика взаимодействия для AddOrEditMoneyBankWindow.xaml
    /// </summary>
    public partial class AddOrEditMoneyBankWindow : Window
    {
        MoneyBank moneyBank { get; set; }
        public AddOrEditMoneyBankWindow(MoneyBank moneyBank)
        {
            InitializeComponent();
            this.moneyBank = moneyBank;
            this.moneyBank.LoadImage();
            if (moneyBank.Id != "")
            {
                deleteButton.Visibility = Visibility.Visible;
            }
            DataContext = this.moneyBank;
        }

        private void loadImage(object sender, RoutedEventArgs e)
        {
            string filename = "";
            var dialog = new Microsoft.Win32.OpenFileDialog();
            dialog.DefaultExt = ".jpg";
            dialog.Filter = "Images (*.png;*.jpg;*jpeg)|*.png;*.jpg;*jpeg";

            bool? result = dialog.ShowDialog();
            if (result == true)
            {
                filename = dialog.FileName;
                var allBytes = File.ReadAllBytes(filename);
                string fileTitle = System.IO.Path.GetFileName(dialog.FileName);
                string path = "..\\..\\..\\imgs\\" + fileTitle;
                if (!File.Exists(path))
                {
                    File.Copy(filename, path, true);
                }
                moneyBank.Image = fileTitle;
                moneyBank.LoadImage();
                imagePicture.Source = moneyBank.ImageSource;
            }
        }
        private void SaveMoneyBankClick(object sender, RoutedEventArgs e)
        {
            if (moneyBank.Id == "")
            {
                moneyBank.Id = Guid.NewGuid().ToString("N");
                MainWindow.moneyBankController.AddMoneyBank(moneyBank);
            }
            MainWindow.moneyBankController.SaveChangesToXml();
            Close();
        }

        private void RemoveMoneyBankClick(object sender, RoutedEventArgs e)
        {
            MainWindow.moneyBankController.RemoveMoneyBank(moneyBank);
            MainWindow.moneyBankController.SaveChangesToXml();
            Close();
        }
    }
}
