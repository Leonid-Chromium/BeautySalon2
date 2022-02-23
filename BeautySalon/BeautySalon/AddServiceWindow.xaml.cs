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
using System.Windows.Shapes;

namespace BeautySalon
{
    /// <summary>
    /// Логика взаимодействия для AddServiceWindow.xaml
    /// </summary>
    public partial class AddServiceWindow : Window
    {
        public AddServiceWindow()
        {
            InitializeComponent();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Вы уверенны что хотите добавить " + ServiceNameTB.Text + " в список услугу", "Выберите один из вариантов", MessageBoxButton.YesNo, MessageBoxImage.Information, MessageBoxResult.Yes, MessageBoxOptions.DefaultDesktopOnly);

            if (result == MessageBoxResult.Yes)
            {
                SQLClass.NoReturn(String.Format(@"INSERT INTO Service (Title, Cost, DurationInSeconds, Description, Discount, MainImagePath) VALUES ('" + ServiceNameTB.Text +"', " + Convert.ToInt32(PriceTB.Text) + ", " + Convert.ToInt32(DurationTB.Text) * 60 + ", '" + DescriptionTB.Text + "', " + Convert.ToInt32(DiscountTB.Text) + ", '" + MainImagePath.Text + "')"));
                this.Close();
            }
        }
    }
}
