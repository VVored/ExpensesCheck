using ExpensesCheck.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ExpensesCheck.Controller
{
    public class OperationController
    {
        private readonly List<Operation> operations;
        public OperationController(List<Operation> operations)
        {
            this.operations = operations;
        }
        public void AddOperation(decimal amount, MoneyBank sender, MoneyBank recipient)
        {
            Operation operation = new Operation(amount, sender, recipient, DateTime.Now);
            sender.TotalBank -= amount;
            recipient.TotalBank += amount;
            operations.Add(operation);
            /*SaveChangesToXml();*/
        }
        /*private void SaveChangesToXml();*/
    }
}
