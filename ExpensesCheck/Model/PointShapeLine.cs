using ExpensesCheck.Controller;
using LiveCharts;
using LiveCharts.Wpf;

namespace ExpensesCheck.Model
{
    class PointShapeLine : BasicChart
    {
        public PointShapeLine(List<Operation> operations)
        {
            MoneyBankController moneyBankController = new MoneyBankController();
            List<MoneyBank> moneyBanks = moneyBankController.GetMoneyBanks();
            foreach (var moneyBank in moneyBanks)
            {
                ChartValues<decimal> monthsValues = new ChartValues<decimal>();
                for (int i = 1; i < 13; i++)
                {
                    decimal monthlyValue = operations.Where(operation => operation.DateOfTransaction.Month == i && operation.Recipient == moneyBank).Sum(operation => operation.MoneyAmount);
                    monthsValues.Add(monthlyValue);
                }
                SeriesCollection.Add(new LineSeries
                {
                    Title = moneyBank.Name,
                    Values = monthsValues,
                    Fill = moneyBank.Color,
                    DataLabels = true
                });
            }
            Labels = ["Jan", "Feb", "Mar", "Apr", "May"];
            YFormatter = value => value.ToString("C");
        }
    }
}
