using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace ExpensesCheck.Model
{
    public enum TypeOfMoneyBank { Счет = 1, Категория = 2 };
    public class MoneyBank
    {
        public MoneyBank(string name, decimal totalBank, Color color, string image, TypeOfMoneyBank typeOfMoneyBank)
        {
            Id = Guid.NewGuid().ToString("N");
            Name = name;
            TotalBank = totalBank;
            Color = color;
            Image = image;
            Type = typeOfMoneyBank;
        }
        public MoneyBank()
        {
            Id = "";
            Name = "";
            TotalBank = 0;
            Color = Colors.Transparent;
            Image = "";
            Type = TypeOfMoneyBank.Категория;
        }
        public string Id { get; set; }
        public string Name { get; set; }
        public decimal TotalBank { get; set; }
        public Color Color { get; set; }
        public string Image { get; set; }
        public TypeOfMoneyBank Type { get; set; }
        public ImageSource ImageSource { get; set; }
        public virtual string ImagePath
        {
            get
            {
                if (Image != "")
                {
                    return "\\imgs\\" + Image;
                }
                else
                {
                    return "\\imgs\\empty.png";
                }
            }
        }
        public virtual string TotalBankToString
        {
            get
            {
                return TotalBank + " RUB";
            }
        }
        public virtual SolidColorBrush BrushFromColor
        {
            get
            {
                return new SolidColorBrush(Color);
            }
        }
        public void LoadImage()
        {
            ImageSource = new BitmapImage(new Uri(ImagePath, UriKind.Relative));
        }
    }
}
