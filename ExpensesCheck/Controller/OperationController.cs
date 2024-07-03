using ExpensesCheck.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Xml;

namespace ExpensesCheck.Controller
{
    public class OperationController
    {
        private readonly List<Operation> operations;
        private readonly MoneyBankController moneyBankController;
        public OperationController()
        {
            /*operations = ImportDataFromXml();*/
            operations = new List<Operation>() { new Operation(1, 100, new MoneyBank(1, "mew", 100, Brushes.AliceBlue, "scheta.png", TypeOfMoneyBank.Счет), new MoneyBank(1, "mew", 100, Brushes.AliceBlue, "scheta.png", TypeOfMoneyBank.Категория), DateTime.Now), new Operation(1, 100, new MoneyBank(1, "mew", 100, Brushes.AliceBlue, "scheta.png", TypeOfMoneyBank.Счет), new MoneyBank(1, "mew", 100, Brushes.AliceBlue, "scheta.png", TypeOfMoneyBank.Категория), DateTime.Now) };
            moneyBankController = new MoneyBankController();
        }
        public void AddOperation(int id,decimal amount, MoneyBank sender, MoneyBank recipient)
        {
            Operation operation = new Operation(id, amount, sender, recipient, DateTime.Now);
            sender.TotalBank -= amount;
            recipient.TotalBank += amount;
            operations.Add(operation);
            SaveChangesToXml();
        }
        private void SaveChangesToXml()
        {
            using (XmlWriter writer = XmlWriter.Create("..\\xmlFiles\\Operation.xml"))
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
        private List<Operation> ImportDataFromXml()
        {
            List<Operation> result = new List<Operation>();
            using (XmlReader reader = XmlReader.Create("..\\xmlFiles\\Operation.xml"))
            {
                while (reader.Read())
                {
                    var operation = new Operation();
                    if (reader.NodeType == XmlNodeType.Element && reader.Name == "id")
                    {
                        operation.Id = int.Parse(reader.ReadElementContentAsString());
                    }
                    if (reader.NodeType == XmlNodeType.Element && reader.Name == "moneyamount")
                    {
                        operation.MoneyAmount = decimal.Parse(reader.ReadElementContentAsString());
                    }
                    if (reader.NodeType == XmlNodeType.Element && reader.Name == "senderId")
                    {
                        operation.Sender = moneyBankController.GetById(int.Parse(reader.ReadElementContentAsString()));
                    }
                    if (reader.NodeType == XmlNodeType.Element && reader.Name == "recipientId")
                    {
                        operation.Recipient = moneyBankController.GetById(int.Parse(reader.ReadElementContentAsString()));
                    }
                    if (reader.NodeType == XmlNodeType.Element && reader.Name == "dateoftransaction")
                    {
                        operation.DateOfTransaction = DateTime.Parse(reader.ReadElementContentAsString());
                    }
                    if (operation.Id !=  0)
                    {
                        result.Add(operation);
                    }
                }
            }
            return result;
        }
        public List<Operation> GetOperations()
        {
            return operations;
        }
    }
}
