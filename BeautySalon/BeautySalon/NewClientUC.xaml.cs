using System;
using System.Data;
using System.Windows;
using System.Windows.Controls;

namespace BeautySalon
{
    /// <summary>
    /// Логика взаимодействия для NewClientUC.xaml
    /// </summary>
    public partial class NewClientUC : UserControl
    {
        public ClientClass client { get; set; } = new ClientClass();

        public NewClientUC()
        {
            InitializeComponent();
        }

        public void UpdateInfo()
        {
            DateTime now = DateTime.Now;
            RegistrationDP.SelectedDate = now;

            GenderCB.Items.Clear();

            DataTable genderDT = SQLClass.ReturnDT("SELECT Code, Name FROM Gender");

            for (int i = 1; i <= genderDT.Rows.Count; i++)
            {
                ComboBoxItem comboBoxItem = new ComboBoxItem();
                comboBoxItem.Tag = genderDT.Rows[i - 1].ItemArray[0];
                comboBoxItem.Content = genderDT.Rows[i - 1].ItemArray[1];
                GenderCB.Items.Add(comboBoxItem);
            }
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            UpdateInfo();
        }

        private void NewClientButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Вы уверенны что хотите добавить нового клиента", "Выберите один из вариантов", MessageBoxButton.YesNo, MessageBoxImage.Information, MessageBoxResult.Yes, MessageBoxOptions.DefaultDesktopOnly);

            if (result == MessageBoxResult.Yes)
            {
                SQLClass.NoReturn(@"INSERT INTO Client (FirstName, LastName, Patronymic, Birthday, RegistrationDate, Email, Phone, GenderCode, PhotoPath)
                                    VALUES('" + FirstNameTB.Text + "', '" + LastNameTB.Text + "', '" + PatronymicTB.Text + "', CAST('" + BirthdayDP.SelectedDate.ToString() + "' AS DateTime), CAST('" + RegistrationDP.SelectedDate.ToString() + "' AS DateTime), '" + EmailTB.Text + "', '" + PhoneTB.Text + "', " +((ComboBoxItem)GenderCB.SelectedItem).Tag.ToString() + ", '" + PhotoPathTB.Text + "')");
                Exit_Click(sender, e);
            }
            
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            MainWindow win = (MainWindow)Window.GetWindow(this);
            win.MainWindowSpaceControle(win.myServices);
        }

        private void UserControl_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            UpdateInfo();
        }
    }
}
