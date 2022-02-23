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
using System.Windows.Shapes;

namespace BeautySalon
{
    /// <summary>
    /// Логика взаимодействия для AuthWindow.xaml
    /// </summary>
    public partial class AuthWindow : Window
    {
        public AuthWindow()
        {
            InitializeComponent();
        }

        public void OpenMainWindow()
        {
            MainWindow mainWindow = new MainWindow();
            ComboBoxItem ComboItem = (ComboBoxItem)RoleComboBox.SelectedItem;
            Trace.WriteLine("ComboItem.Tag " + Convert.ToInt32(ComboItem.Tag));
            mainWindow.SetRole(Convert.ToInt32(ComboItem.Tag));
            mainWindow.Show();
            this.Close();
        }

        public bool PasswordCheck(int Level, string Password)
        {
            switch (Level)
            {
                case 0:
                    return true;

                case 1:
                    if (Password == "0000")
                        return true;
                    else
                        return false;

                default:
                    return false;
            }
        }

        // Нужна нормальная проверка пароля

        private void EnterButton_Click(object sender, RoutedEventArgs e)
        {
            ComboBoxItem ComboItem = (ComboBoxItem)RoleComboBox.SelectedItem;
            string Role = Convert.ToString(ComboItem.Tag);
            if (PasswordCheck(Convert.ToInt32(Role), Convert.ToString(PasswordBox.Password)))
            {
                OpenMainWindow();
            }
            else
            {
                MessageBox.Show("Неправильный пароль");
            }
        }
    }
}
