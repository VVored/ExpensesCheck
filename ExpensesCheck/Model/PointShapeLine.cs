using ExpensesCheck.Controller;
using LiveCharts;
using LiveCharts.Wpf;
using System.Windows.Media;

namespace ExpensesCheck.Model
{
    public class PointShapeLine : BasicChart
    {
        public PointShapeLine(List<Operation> operations)
        {
            MoneyBankController moneyBankController = new MoneyBankController();
            List<MoneyBank> categories = moneyBankController.GetMoneyBanks().Where(moneybank => moneybank.Type == TypeOfMoneyBank.Категория).ToList();
            foreach (var moneyBank in categories)
            {
                ChartValues<decimal> monthsValues = new ChartValues<decimal>();
                for (int i = 1; i < 13; i++)
                {
                    decimal monthlyValue = operations.Where(operation => operation.DateOfTransaction.Month == i && operation.DateOfTransaction.Year == DateTime.Now.Year && operation.Recipient.Id == moneyBank.Id).Sum(op => op.MoneyAmount);
                    monthsValues.Add(monthlyValue);
                }
                SeriesCollection.Add(new LineSeries
                {
                    Title = moneyBank.Name,
                    Values = monthsValues,
                    Fill = moneyBank.BrushFromColor,
                    DataLabels = true
                });
            }
        }
    }
}
