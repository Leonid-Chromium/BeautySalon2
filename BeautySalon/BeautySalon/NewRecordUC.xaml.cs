using System;
using System.Collections.Generic;
using System.Data;
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
    /// Логика взаимодействия для NewRecordUC.xaml
    /// </summary>
    public partial class NewRecordUC : UserControl
    {
        public NewRecordUC()
        {
            InitializeComponent();
        }

        public string getTime()
        {
            DateTime dateTime = new DateTime();
            if (DateDP.SelectedDate != null)
            {
                 dateTime = DateDP.SelectedDate.Value;
                Trace.WriteLine(HoursTB.Text != null && MinutsTB.Text != null);
                if (!(String.IsNullOrEmpty(HoursTB.Text) || String.IsNullOrEmpty(MinutsTB.Text)))
                {
                    double d1 = Convert.ToDouble(Convert.ToInt32(HoursTB.Text));
                    double d2 = Convert.ToDouble(Convert.ToInt32(MinutsTB.Text));
                    Trace.WriteLine(d1);
                    Trace.WriteLine(d2);
                    dateTime = dateTime.AddHours(d1);
                    dateTime = dateTime.AddMinutes(d2);
                }
            }    
            Trace.WriteLine(dateTime.ToString());
            return dateTime.ToString();
        }

        private void Clear()
        {
            ClientCB.SelectedItem = null;
            ServiceCB.SelectedItem = null;

            DateDP.SelectedDate = null;
            HoursTB.Text = null;
            MinutsTB.Text = null;

            CommentTB.Text = null;
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            MainWindow win = (MainWindow)Window.GetWindow(this);
            win.MainWindowSpaceControle(win.myServices);
        }

        private void AddNewRecord_Click(object sender, RoutedEventArgs e)
        {
            getTime();

            MessageBoxResult result = MessageBox.Show("Вы уверенны что хотите добавить нового клиента", "Выберите один из вариантов", MessageBoxButton.YesNo, MessageBoxImage.Information, MessageBoxResult.Yes, MessageBoxOptions.DefaultDesktopOnly);

            if (result == MessageBoxResult.Yes)
            {
                SQLClass.NoReturn(@"INSERT INTO ClientService (ClientID, ServiceID, StartTime, Comment) VALUES (" + ((ComboBoxItem)ClientCB.SelectedItem).Tag.ToString() + ", " + ((ComboBoxItem)ServiceCB.SelectedItem).Tag.ToString() + ", CAST('" + getTime() + "' AS DateTime), '" + CommentTB.Text + "')");
                Clear();
                Exit_Click(sender, e);
            }
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            UpdateInfo();
        }

        public void UpdateInfo()
        {
            DataTable ClientDT = SQLClass.ReturnDT("SELECT ID, CONCAT(LastName, ' ', FirstName, ' ', Patronymic) as 'ФИО' FROM Client");
            for (int i = 1; i <= ClientDT.Rows.Count; i++)
            {
                ComboBoxItem comboBoxItem = new ComboBoxItem();
                comboBoxItem.Tag = ClientDT.Rows[i - 1].ItemArray[0];
                comboBoxItem.Content = ClientDT.Rows[i - 1].ItemArray[1];
                ClientCB.Items.Add(comboBoxItem);
            }

            DataTable ServiceDT = SQLClass.ReturnDT("SELECT ID, Title FROM Service");
            for (int i = 1; i <= ClientDT.Rows.Count; i++)
            {
                ComboBoxItem comboBoxItem = new ComboBoxItem();
                comboBoxItem.Tag = ServiceDT.Rows[i - 1].ItemArray[0];
                comboBoxItem.Content = ServiceDT.Rows[i - 1].ItemArray[1];
                ServiceCB.Items.Add(comboBoxItem);
            }
        }

        private void UserControl_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            UpdateInfo();
        }
    }
}
