using ExpensesCheck.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls.Ribbon.Primitives;

namespace ExpensesCheck.Controller
{
    public class MoneyBankController
    {
        private readonly List<MoneyBank> moneyBanks;

        public void AddMoneyBank(MoneyBank moneyBank)
        {
            moneyBanks.Add(moneyBank);
            /*SaveChangesToXml();*/
        }
        public void RemoveMoneyBank(MoneyBank moneyBank) { 
            moneyBanks.Remove(moneyBank);
            /*SaveChangesToXml();*/
        }
        /*private void SaveChangesToXml();*/
    }
}
