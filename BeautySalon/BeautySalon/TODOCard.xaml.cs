using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BeautySalon
{
    /// <summary>
    /// Логика взаимодействия для TODOCard.xaml
    /// </summary>
    public partial class TODOCard : UserControl
    {
        public string ClientStr { get; set; }
        public string ServiceStr { get; set; }
        public string EmailStr { get; set; }
        public string PhoneStr { get; set; }
        public string TimeStart { get; set; }
        public string RemainingTime { get; set; }

        public TODOCard()
        {
            InitializeComponent();
        }

        public void UpdateCard()
        {
            ClientL.Content = ClientStr;
            ServiceL.Content = ServiceStr;
            EmailL.Content = EmailStr;
            PhoneL.Content = PhoneStr;
            DateTime TimeStartDT = DateTime.Parse(TimeStart);
            TimeStartL.Content = TimeStart;
            TimeSpan RemainingTimeTS = new TimeSpan();
            RemainingTimeTS = TimeStartDT - DateTime.Now;
            RemainingTimeL.Content = RemainingTimeTS.ToString();
            if(RemainingTimeTS.Hours < 1 && RemainingTimeTS.Hours >= 0)
            {
                BrushConverter brushConverter = new BrushConverter();
                Brush brush = (Brush)brushConverter.ConvertFromString("#EE2222");
                RemainingTimeL.Background = brush;
            }
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            UpdateCard();
        }
    }
}
