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
    /// Логика взаимодействия для Services.xaml
    /// </summary>
    public partial class Services : UserControl
    {
        public int role { get; set; }

        private DataTable serviceDT = new DataTable("Service data view");

        public Services()
        {
            InitializeComponent();
            this.DataContext = this;
        }

        public DataTable FilterAndSort(DataTable dataTable)
        {
            DataView dataView = new DataView();
            dataTable.TableName = "Service data view";
            dataView.Table = dataTable;

            ComboBox sortPriceCB = SortPrice;
            string sortPriceStr = ((ComboBoxItem)sortPriceCB.SelectedItem).Tag.ToString();
            Trace.WriteLine("sortPriceStr = " + sortPriceStr);
            if (sortPriceStr != "None")
            {
                dataView.Sort = "Cost " + sortPriceStr;
            }

            ComboBox filterCB = FilterDiscount;
            int filter = Convert.ToInt32(((ComboBoxItem)filterCB.SelectedItem).Tag.ToString());
            Trace.WriteLine("filter = " + filter);
            if (filter != 0)
            {
                switch(filter)
                {
                    case 1:
                        dataView.RowFilter = "Discount >= 0 AND Discount <5";
                        break;

                    case 2:
                        dataView.RowFilter = "Discount >= 5 AND Discount <15";
                        break;

                    case 3:
                        dataView.RowFilter = "Discount >= 15 AND Discount <30";
                        break;

                    case 4:
                        dataView.RowFilter = "Discount >= 30 AND Discount <70";
                        break;

                    case 5:
                        dataView.RowFilter = "Discount >= 70 AND Discount <100";
                        break;
                }
            }

            string search = Search.Text.Trim();
            if (search != String.Empty)
            {
                string filter2 = "Title Like '%" + search + "%' OR Description Like '%" + search + "%'";
                Trace.WriteLine(filter2);
                dataView.RowFilter = filter2;
            }

            return dataView.ToTable();
        }

        public void DisplayServices()
        {
            DataTable FSserviceDT = FilterAndSort(serviceDT);

            ServicesSP.Children.Clear();

            for (int i = 0; i < FSserviceDT.Rows.Count; i++)
            {
                ServiceCard serviceCard = new ServiceCard();
                serviceCard.userRole = role;
                serviceCard.services = this;

                serviceCard.ID = Convert.ToInt32(FSserviceDT.Rows[i].ItemArray[0]);
                serviceCard.nameStr = Convert.ToString(FSserviceDT.Rows[i].ItemArray[1]);
                serviceCard.price = Convert.ToInt32(FSserviceDT.Rows[i].ItemArray[2]);
                serviceCard.duration = Convert.ToInt32(FSserviceDT.Rows[i].ItemArray[3]) / 60;
                serviceCard.discount = Convert.ToInt32(FSserviceDT.Rows[i].ItemArray[5]);
                ServicesSP.Children.Add(serviceCard);
            }
        }

        public void updataServicesList()
        {
            serviceDT = SQLClass.ReturnDT(@"SELECT * FROM Service");

            DisplayServices();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            if (role == 1)
            {
                AdminPanel.Visibility = Visibility.Visible;
            }
            updataServicesList();
        }

        private void SortPrice_DropDownClosed(object sender, EventArgs e)
        {
            DisplayServices();
        }

        private void FilterDiscount_DropDownClosed(object sender, EventArgs e)
        {
            DisplayServices();
        }

        private void Search_TextChanged(object sender, TextChangedEventArgs e)
        {
            DisplayServices();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            AddServiceWindow addServiceWindow = new();
            addServiceWindow.Show();
        }

        private void NewClientButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow win = (MainWindow)Window.GetWindow(this);
            win.MainWindowSpaceControle(win.newClientUC);
        }

        private void NewRecordButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow win = (MainWindow)Window.GetWindow(this);
            win.MainWindowSpaceControle(win.newRecordUC);
        }

        private void RecordsButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow win = (MainWindow)Window.GetWindow(this);
            win.MainWindowSpaceControle(win.todoListUC);
        }
    }
}
