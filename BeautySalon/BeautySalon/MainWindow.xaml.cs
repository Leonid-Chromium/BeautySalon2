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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static int role { get; set; }

        public static int editService { get; set; } = -1;

        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = this;
            myServices.role = role;
            Trace.WriteLine("Role = " + role);
        }

        public void SetRole(int newRole)
        {
            role = newRole;
            UseRole();
        }

        private void UseRole()
        {
            try
            {
                myServices.role = role;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Фатальная ошибка");
            }
        }

        UserControl ActualSpace;

        public void MainWindowSpaceControle(UserControl userControl)
        {
            if (ActualSpace == null)
                ActualSpace = (UserControl)myServices;
            if (userControl == ActualSpace && ActualSpace.Visibility != Visibility.Collapsed)
            {
                userControl.Visibility = Visibility.Collapsed;
            }
            else
            {
                if (ActualSpace != null)
                    ActualSpace.Visibility = Visibility.Collapsed;
                userControl.Visibility = Visibility.Visible;
            }
            ActualSpace = userControl;
        }

        public int EditWinManage(int newEditService)
        {
            try
            {
                if (newEditService == -1)
                {
                    Trace.WriteLine("newEditService == -1");
                    editService = -1;
                    return 0;
                }
                else
                {
                    Trace.WriteLine("newEditService != -1");

                    if (editService == -1)
                    {
                        Trace.WriteLine("editService == -1");
                        editService = newEditService;
                        EditWindow editWindow = new EditWindow();
                        editWindow.serviceID = newEditService;
                        editWindow.mainWindow = this;
                        editWindow.Show();
                        return 0;
                    }
                    else if (editService == newEditService)
                    {
                        Trace.WriteLine("editService == newEditService");
                        MessageBox.Show("Вы уже редактируете это");
                        foreach (Window window in App.Current.Windows)
                        {
                            // если окно - объект EditWindow
                            if (window is EditWindow)
                                window.Activate();
                        }
                        return 0;
                    }
                    else
                    {
                        MessageBox.Show("Вы уже редактируете Сервис с ID = " + editService);
                        foreach (Window window in App.Current.Windows)
                        {

                            // если окно - объект EditWindow
                            if (window is EditWindow)
                                window.Activate();
                        }
                        return -1;
                    }
                }
            }
            catch(Exception ex)
            {
                Trace.WriteLine(ex.Message);
                return -1;
            }
        }

        private void Window_Activated(object sender, EventArgs e)
        {
            myServices.updataServicesList();
        }
    }
}
