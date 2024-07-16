using ExpensesCheck.Controller;
using LiveCharts.Wpf;
using LiveCharts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Windows.Media;

namespace ExpensesCheck.Model
{
    public class StackedColumn : BasicChart
    {
        public StackedColumn(List<Operation> operations)
        {
            MoneyBankController moneyBankController = new MoneyBankController();
            List<MoneyBank> moneyBanks = moneyBankController.GetMoneyBanks().Where(moneybank => moneybank.Type == TypeOfMoneyBank.Категория).ToList();
            foreach (var moneyBank in moneyBanks)
            {
                ChartValues<decimal> monthsValues = new ChartValues<decimal>();
                for (int i = 1; i < 13; i++)
                {
                    decimal monthlyValue = operations.Where(operation => operation.DateOfTransaction.Month == i && operation.DateOfTransaction.Year == DateTime.Now.Year && operation.Recipient.Id == moneyBank.Id).Sum(op => op.MoneyAmount);
                    monthsValues.Add(monthlyValue);
                }
                SeriesCollection.Add(new StackedColumnSeries
                {
                    Title = moneyBank.Name,
                    Values = monthsValues,
                    Fill = moneyBank.BrushFromColor,
                    StackMode = StackMode.Values,
                    DataLabels = true
                });
            }
        }
    }
}
