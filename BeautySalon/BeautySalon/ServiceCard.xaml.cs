using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    /// Логика взаимодействия для ServiceCard.xaml
    /// </summary>
    public partial class ServiceCard : UserControl
    {
        public int userRole { get; set; } = 0;
        public Services services { get; set; }

        public int ID { get; set; }
        public string nameStr { get; set; }
        public int price { get; set; }
        public int duration { get; set; } = 0;
        public string description { get; set; }
        public int discount { get; set; } = 0;
        public string mainImagePath { get; set; }

        public ServiceCard()
        {
            InitializeComponent();
            this.DataContext = this;
        }

        public int update()
        {
            try
            {
                if (userRole != 0)
                {

                    EditButton.Visibility = Visibility.Visible;
                    DeleteButton.Visibility = Visibility.Visible;
                }

                NameLabel.Content = nameStr;
                if (discount != 0)
                {
                    OldPriceLabel.Content = String.Format("Old price: " + price);
                    PriceLabel.Content = String.Format((price-((price/100)*discount)) + " рублей за " + duration + " минут");
                    DiscountLabel.Content = String.Format("* скидка " + discount + "%");
                    BrushConverter brushConverter = new BrushConverter();
                    Brush brush = (Brush)brushConverter.ConvertFromString("#A3F06C");
                    CardGrid.Background = brush;
                }
                else
                {
                    PriceLabel.Content = String.Format(price + " рублей за " + duration + " минут");
                    //Note Первый костыль
                    DiscountLabel.Content = String.Format(" ");
                }

                return 0;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                return -1;
            }
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            foreach (Window window in App.Current.Windows)
            {
                // если окно - объект MainWindow
                if (window is MainWindow)
                {
                    MainWindow mainWindow = (MainWindow) window;
                    mainWindow.EditWinManage(ID);
                }
            }
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Вы уверенны что хотите удалить информацию о \"" + nameStr + "\"", "Выберите один из вариантов", MessageBoxButton.YesNo, MessageBoxImage.Information, MessageBoxResult.Yes, MessageBoxOptions.DefaultDesktopOnly);

            if (result == MessageBoxResult.Yes)
            {
                string queryStr = String.Format("DELETE FROM Service WHERE Service.ID = " + ID);
                SQLClass.NoReturn(queryStr);
                services.updataServicesList();
            }
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            update();
        }
    }
}
