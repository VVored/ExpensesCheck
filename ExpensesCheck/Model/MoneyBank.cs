using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace ExpensesCheck.Model
{
    public enum TypeOfMoneyBank { Счет = 1, Категория = 2 };
    public class MoneyBank
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal TotalBank { get; set; }
        public SolidColorBrush Color { get; set; }
        public string Image { get; set; }
        public TypeOfMoneyBank Type { get; set; }
        public virtual string ImagePath
        {
            get
            {
                return "..\\imgs\\" + Image;
            }
        }
        public virtual string TotalBankToString
        {
            get
            {
                return TotalBank + " RUB";
            }
        }
        public MoneyBank(int id,string name, decimal totalBank, SolidColorBrush color, string image, TypeOfMoneyBank typeOfMoneyBank)
        {
            Id = id;
            Name = name;
            TotalBank = totalBank;
            Color = color;
            Image = image;
            Type = typeOfMoneyBank;
        }
        public MoneyBank()
        {
            Id = 0;
            Name = "";
            TotalBank = 0;
            Color = Brushes.Transparent;
            Image = "";
            Type = TypeOfMoneyBank.Категория;
        }
    }
}
