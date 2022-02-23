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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BeautySalon
{
    /// <summary>
    /// Логика взаимодействия для TODOListUC.xaml
    /// </summary>
    public partial class TODOListUC : UserControl
    {
        public TODOListUC()
        {
            InitializeComponent();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow win = (MainWindow)Window.GetWindow(this);
            win.MainWindowSpaceControle(win.myServices);
        }

        public void UpdateInfo()
        {
            //TODO Добавь условие на записи на ближайшие дни
            DataTable todoDT = SQLClass.ReturnDT(@"SELECT
CONCAT(Client.LastName, ' ', Client.FirstName, ' ', Client.Patronymic) as 'ФИО',
Client.Email,
Client.Phone,
Service.Title,
ClientService.StartTime
FROM ClientService
LEFT JOIN Client on Client.ID = ClientService.ClientID
LEFT JOIN Service on Service.ID = ClientService.ServiceID
WHERE ClientService.StartTime > CAST('" + DateTime.Now.ToString() + "' AS DateTime) AND ClientService.StartTime < CAST('" + DateTime.Now.AddDays(2).ToString() + "' AS DateTime)");

            for (int i = 0; i < todoDT.Rows.Count; i++)
            {
                TODOCard card = new TODOCard();
                card.ClientStr = todoDT.Rows[i].ItemArray[0].ToString();
                card.EmailStr = todoDT.Rows[i].ItemArray[1].ToString();
                card.PhoneStr = todoDT.Rows[i].ItemArray[2].ToString();
                card.ServiceStr = todoDT.Rows[i].ItemArray[3].ToString();
                card.TimeStart = todoDT.Rows[i].ItemArray[4].ToString();
                TodoSP.Children.Add(card);
            }
        }
        
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            UpdateInfo();
        }

        private void UserControl_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            UpdateInfo();
        }
    }
}
