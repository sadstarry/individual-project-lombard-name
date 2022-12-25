using individual_project_lombard.Components;
using individual_project_lombard.User;
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

namespace individual_project_lombard.Page.AddPage.PoductClient
{
    /// <summary>
    /// Логика взаимодействия для AddClientToHistory.xaml
    /// </summary>
    public partial class AddClientToHistory
    {
        public AddClientToHistory()
        {
            InitializeComponent();
            ListProduct.ItemsSource = Dbconnect.db.Client.Where(x => x.IsDelete != true).ToList();
        }

        private void AddToAHistory_Click(object sender, RoutedEventArgs e)
        {
            var BtnClient = (sender as Button).DataContext as Client;

            AccountUser.HisClient = Dbconnect.db.Client.ToList().Find(x => x.ID == BtnClient.ID); //Заношу в глобал переменную айди добавляемого клиента
            MessageBox.Show("Этот товар добавлен в оформление");
            NavigationService.Navigate(new AddHistory());
        }

    }
}
