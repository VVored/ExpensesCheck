using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Xml;
using ExpensesCheck.Model;


namespace ExpensesCheck.Controller
{
    public class MoneyBankController
    {
        private readonly List<MoneyBank> moneyBanks;

        public MoneyBankController()
        {
            moneyBanks = ImportDataFromXml();
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
            using (XmlWriter writer = XmlWriter.Create("..\\..\\..\\xmlFiles\\MoneyBank.xml"))
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
                    writer.WriteElementString("type", ((int)i.Type).ToString());

                    writer.WriteEndElement();
                }

                writer.WriteEndElement();
                writer.WriteEndDocument();
            }
        }
        private List<MoneyBank> ImportDataFromXml()
        {
            List<MoneyBank> result = new List<MoneyBank>();
            var brushConverter = new BrushConverter();
            using (XmlReader reader = XmlReader.Create("..\\..\\..\\xmlFiles\\MoneyBank.xml"))
            {
                while (reader.Read())
                {
                    var moneybank = new MoneyBank();
                    if (reader.NodeType == XmlNodeType.Element && reader.Name == "id")
                    {
                        moneybank.Id = reader.ReadElementContentAsString();
                    }
                    if (reader.NodeType == XmlNodeType.Element && reader.Name == "name")
                    {
                        moneybank.Name = reader.ReadElementContentAsString();
                    }
                    if (reader.NodeType == XmlNodeType.Element && reader.Name == "totalbank")
                    {
                        moneybank.TotalBank = decimal.Parse(reader.ReadElementContentAsString());
                    }
                    if (reader.NodeType == XmlNodeType.Element && reader.Name == "color")
                    {
                        moneybank.Color = (SolidColorBrush)brushConverter.ConvertFrom(reader.ReadElementContentAsString());
                        if (moneybank.Color == null)
                        {
                            moneybank.Color = Brushes.AliceBlue;
                        }
                    }
                    if (reader.NodeType == XmlNodeType.Element && reader.Name == "image")
                    {
                        moneybank.Image = reader.ReadElementContentAsString();
                    }
                    if (reader.NodeType == XmlNodeType.Element && reader.Name == "type")
                    {
                        /*moneybank.Type = (TypeOfMoneyBank)Enum.Parse(typeof(TypeOfMoneyBank), reader.ReadElementContentAsString()); если тип сохранен как строка*/
                        moneybank.Type = (TypeOfMoneyBank)int.Parse(reader.ReadElementContentAsString()); // если тип сохранен как значение
                    }
                    if (moneybank.Id != "")
                    {
                        result.Add(moneybank);
                    }
                }
            }
            return result;
        }
        public MoneyBank GetById(string id)
        {
            var result = new MoneyBank();
            foreach (var i in moneyBanks)
            {
                if (i.Id == id)
                {
                    result = i;
                    break;
                }
            } 
            return result;
        }
        public List<MoneyBank> GetMoneyBanks()
        {
            return moneyBanks;
        }
    }
}
