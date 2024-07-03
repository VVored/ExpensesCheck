using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpensesCheck.Model
{
    public class Operation
    {
        public Operation(int id,decimal moneyAmount, MoneyBank sender, MoneyBank recipient, DateTime dateOfTransaction)
        {
            Id = id;
            MoneyAmount = moneyAmount;
            Sender = sender;
            Recipient = recipient;
            DateOfTransaction = dateOfTransaction;
        }
        public Operation()
        {
            Id = 0;
            MoneyAmount = 0;
            Sender = null;
            Recipient = null;
            DateOfTransaction = DateTime.Now;
        }
        public int Id { get; set; }
        public decimal MoneyAmount { get; set; }
        public MoneyBank Sender { get; set; }
        public MoneyBank Recipient { get; set; }
        public DateTime DateOfTransaction { get; set; }
    }
}
