using individual_project_lombard.Components;
using individual_project_lombard.Page.AddPage;
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

namespace individual_project_lombard.Page
{
    /// <summary>
    /// Логика взаимодействия для Clients.xaml
    /// </summary>
    public partial class Clients
    {
        public Clients()
        {
            InitializeComponent();
            ListProduct.ItemsSource = Dbconnect.db.Client.ToList().Where(x => x.IsDelete != true);
            Sort();
        }

        private void TbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            Sort();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddPage.AddClient());
        }

        private void AddToAHistory_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var BtnProd = (sender as Button).DataContext as Client;
            AccountUser.ClientEdit = Dbconnect.db.Client.Where(x => x.ID == BtnProd.ID).FirstOrDefault();


            NavigationService.Navigate(new PodrobneeClients(AccountUser.ClientEdit));
        }

        private void Sort()
        {
            List<Client> products = Dbconnect.db.Client.Where(x => x.IsDelete != true).ToList();

            if (TbSearch.Text.Length > 0)
            {
                products = products.Where(x => (x.Name != null && x.Name.ToLower().Contains(TbSearch.Text.ToLower())) || (x.Surname != null && x.Surname.ToLower().Contains(TbSearch.Text.ToLower()))).ToList();
                if (ListProduct != null)
                {
                    ListProduct.ItemsSource = products.ToList();
                }

            }
            else
            {
                ListProduct.ItemsSource = products.ToList();
            }
        }
    }
}
