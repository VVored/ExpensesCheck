using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace ExpensesCheck
{
    interface IManipulationWithMoneyBank
    {
        public void Replenishment(decimal amount, MoneyBank moneyBank);
        public void Debit(decimal amount, MoneyBank moneyBank);
    }
    public abstract class MoneyBank
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
                return AppDomain.CurrentDomain.BaseDirectory + ".\\.\\" + Image;
            }
        }
    }
    public class Category : MoneyBank
    {
        public Category(string name, decimal totalSum)
        {
            Name = name;
            TotalBank = 0;
        }
    }

    public class Operation
    {
        public Operation (decimal moneyAmount, MoneyBank sender, MoneyBank recipient, DateTime dateOfTransaction)
        {
            MoneyAmount = moneyAmount;
            SenderMoneyBank = sender;
            RecipientMoneyBank = recipient;
            DateOfTransaction = dateOfTransaction;
        }
        public int Id { get; set; }
        public decimal MoneyAmount { get; set; }
        public MoneyBank SenderMoneyBank { get; set; }
        public MoneyBank RecipientMoneyBank { get; set; }
        public DateTime DateOfTransaction { get; set; }
    }
    public class Wallet : MoneyBank, IManipulationWithMoneyBank
    {
        public List<Operation> Operations { get; set; }
        public void Debit(decimal amount, MoneyBank moneyBank)
        {
            Operation debitOperation = new Operation(amount, this, moneyBank, DateTime.Now);
            Operations.Add(debitOperation);
            TotalBank -= amount;
            moneyBank.TotalBank += amount;
        }

        public void Replenishment(decimal amount, MoneyBank moneyBank)
        {
            Operation replenishmentOperation = new Operation(amount, moneyBank, this, DateTime.Now);
            Operations.Add(replenishmentOperation);
            moneyBank.TotalBank -= amount;
            TotalBank += amount;
        }
    }
}
