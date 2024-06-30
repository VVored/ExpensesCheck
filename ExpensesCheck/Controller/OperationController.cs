using ExpensesCheck.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

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
            SaveChangesToXml();
        }
        private void SaveChangesToXml()
        {
            using (XmlWriter writer = XmlWriter.Create("..\\xmlFiles\\MoneyBank.xml"))
            {
                writer.WriteStartDocument();
                writer.WriteStartElement("moneybanks");

                foreach (var i in operations)
                {
                    writer.WriteStartElement("moneybank");

                    writer.WriteElementString("id", i.Id.ToString());
                    writer.WriteElementString("moneyamount", i.MoneyAmount.ToString());
                    writer.WriteElementString("senderId", i.Sender.Id.ToString());
                    writer.WriteElementString("recipientId", i.Recipient.Id.ToString());
                    writer.WriteElementString("dateoftransaction", i.DateOfTransaction.ToString("f"));

                    writer.WriteEndElement();
                }

                writer.WriteEndElement();
                writer.WriteEndDocument();
            }
        }

    }
}
