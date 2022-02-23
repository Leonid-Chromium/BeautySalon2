using System;
using System.Collections.Generic;
using System.Data;
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
    /// Логика взаимодействия для EditWindow.xaml
    /// </summary>
    public partial class EditWindow : Window
    {
        public int serviceID { get; set; }

        //public string nameStr { get; set; }
        //public int price { get; set; }
        //public int duration { get; set; } = 0;
        //public string description { get; set; }
        //public int discount { get; set; } = 0;
        //public string mainImagePath { get; set; }

        public MainWindow mainWindow { get; set; }

        public EditWindow()
        {
            InitializeComponent();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            mainWindow.EditWinManage(-1);
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Вы уверенны что хотите изменить информации \"" + ServiceNameTB.Text + "\"", "Выберите один из вариантов", MessageBoxButton.YesNo, MessageBoxImage.Information, MessageBoxResult.Yes, MessageBoxOptions.DefaultDesktopOnly);

            if (result == MessageBoxResult.Yes)
            {
                string str1 = String.Format("UPDATE Service SET Title = '" + ServiceNameTB.Text);
                string str2 = String.Format("', Cost = " + Convert.ToInt32(PriceTB.Text));
                string str3 = String.Format(", DurationInSeconds = " + (Convert.ToInt32(DurationTB.Text) * 60));
                string str4 = String.Format(", Description = '" + DescriptionTB.Text);
                string str5 = String.Format("', Discount =" + Convert.ToInt32(DiscountTB.Text));
                string str6 = String.Format(", MainImagePath = '" + MainImagePath.Text);
                string queryStr = String.Format(str1 + str2 + str3 + str4 + str5 + str6 + "' WHERE Service.ID = " + serviceID);
                SQLClass.NoReturn(queryStr);
                this.Close();
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            DataTable dataTable = SQLClass.ReturnDT("SELECT * From Service WHERE ID = " + serviceID);

            //ServiceNameTB.Text = nameStr;
            //PriceTB.Text = price.ToString();
            //DurationTB.Text = duration.ToString();
            //DescriptionTB.Text = description;
            //DiscountTB.Text = discount.ToString();
            //MainImagePath.Text = mainImagePath;

            ServiceNameTB.Text = dataTable.Rows[0].ItemArray[1].ToString();
            PriceTB.Text = Convert.ToInt32(dataTable.Rows[0].ItemArray[2]).ToString();
            DurationTB.Text = (Convert.ToInt32(dataTable.Rows[0].ItemArray[3]) * 60).ToString();
            DescriptionTB.Text = dataTable.Rows[0].ItemArray[4].ToString();
            DiscountTB.Text = dataTable.Rows[0].ItemArray[5].ToString();
            MainImagePath.Text = dataTable.Rows[0].ItemArray[6].ToString();
        }
    }
}
