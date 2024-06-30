using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using ExpensesCheck.Model;


namespace ExpensesCheck.Controller
{
    public class MoneyBankController
    {
        private readonly List<MoneyBank> moneyBanks;

        public MoneyBankController(List<MoneyBank> moneyBanks)
        {
            this.moneyBanks = moneyBanks;
        }

        public void AddMoneyBank(MoneyBank moneyBank)
        {
            moneyBanks.Add(moneyBank);
            SaveChangesToXml();
        }
        public void RemoveMoneyBank(MoneyBank moneyBank)
        {
            moneyBanks.Remove(moneyBank);
            SaveChangesToXml();
        }
        private void SaveChangesToXml()
        {
            using (XmlWriter writer = XmlWriter.Create("..\\xmlFiles\\MoneyBank.xml"))
            {
                writer.WriteStartDocument();
                writer.WriteStartElement("moneybanks");

                foreach (var i in moneyBanks)
                {
                    writer.WriteStartElement("moneybank");

                    writer.WriteElementString("id", i.Id.ToString());
                    writer.WriteElementString("name", i.Name);
                    writer.WriteElementString("totalbank", i.TotalBank.ToString());
                    writer.WriteElementString("color", i.Color.Color.ToString());
                    writer.WriteElementString("image", i.Image);
                    writer.WriteElementString("type", i.Type.ToString());

                    writer.WriteEndElement();
                }

                writer.WriteEndElement();
                writer.WriteEndDocument();
            }
        }
    }
}
