using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace ExpensesCheck
{
    interface IManipulationWithMoney
    {
        public void Replenishment(decimal amount, Category Category);
        public void Debit(decimal amount, Category Category);
    }
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal TotalBank { get; set; }
        public SolidColorBrush Color { get; set; }
        public string Image { get; set; }
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
        public Category(string name, decimal totalBank, SolidColorBrush color, string image)
        {
            Id = 0;
            Name = name;
            TotalBank = totalBank;
            Color = color;
            Image = image;
        }
    }

    public class Operation
    {
        public Operation (decimal moneyAmount, Category sender, Category recipient, DateTime dateOfTransaction)
        {
            Id = 0;
            MoneyAmount = moneyAmount;
            Sender = sender;
            Recipient = recipient;
            DateOfTransaction = dateOfTransaction;
        }
        public int Id { get; set; }
        public decimal MoneyAmount { get; set; }
        public Category Sender { get; set; }
        public Category Recipient { get; set; }
        public DateTime DateOfTransaction { get; set; }
    }
    public class Wallet : Category, IManipulationWithMoney
    {
        public Wallet(string name, decimal totalBank, SolidColorBrush color, string image) : base(name, totalBank, color, image) => Operations = new List<Operation>();

        public List<Operation> Operations { get; set; }
        public void Debit(decimal amount, Category Category)
        {
            Operation debitOperation = new Operation(amount, this, Category, DateTime.Now);
            Operations.Add(debitOperation);
            TotalBank -= amount;
            Category.TotalBank += amount;
        }

        public void Replenishment(decimal amount, Category Category)
        {
            Operation replenishmentOperation = new Operation(amount, Category, this, DateTime.Now);
            Operations.Add(replenishmentOperation);
            Category.TotalBank -= amount;
            TotalBank += amount;
        }
    }
}
