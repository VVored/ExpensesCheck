using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpensesCheck
{
    public class Category
    {
        public Category(string name, decimal totalSum) 
        {
            Name = name;
            TotalSum = totalSum;
            Operations = new List<Operation>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal TotalSum { get; set; }
        public Color Color { get; set; }
        public List<Operation> Operations { get; set; }
    }

    public class Operation
    {
        public Operation (decimal moneyAmount, Category category, DateTime dateOfTransaction)
        {
            MoneyAmount = moneyAmount;
            Category = category;
            DateOfTransaction = dateOfTransaction;
        }
        public int Id { get; set; }
        public decimal MoneyAmount { get; set; }
        public Category Category { get; set; }
        public DateTime DateOfTransaction { get; set; }
    }
}
