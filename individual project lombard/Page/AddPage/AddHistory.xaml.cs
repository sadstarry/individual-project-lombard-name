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

namespace individual_project_lombard.Page.AddPage
{
    /// <summary>
    /// Логика взаимодействия для AddHistory.xaml
    /// </summary>
    public partial class AddHistory
    {
        public AddHistory() 
        {
            InitializeComponent();
            try {
                ClientPost.Text = Dbconnect.db.Client.ToList().Find(x => x.ID == AccountUser.HisClient.ID).Name;
            }
            catch { }
            try {
                ProdPost.Text = Dbconnect.db.Product.ToList().Find(x => x.ID == AccountUser.HisProduct.ID).Name;
            }
            catch { }
        }

        private void BtnProd_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new PoductClient.AddProductToHistory());
        }

        private void BtnClient_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new PoductClient.AddClientToHistory());
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            try {
            Dbconnect.db.ClientProduct.Add(new ClientProduct
            {
                ProductID = AccountUser.HisProduct.ID,
                ClientID = AccountUser.HisClient.ID,
                AccountID = AccountUser.nameuser.ID,
                Data = DateTime.Now
            });
                Product Delete = Dbconnect.db.Product.Where(x => x.ID == AccountUser.HisProduct.ID).FirstOrDefault();
                Delete.IsDropToHistory = true;
            Dbconnect.db.SaveChanges();
            MessageBox.Show("Оформление завершено");
                AccountUser.Block = 0;
                AccountUser.HisProduct= null;
                AccountUser.HisClient= null;
                NavigationService.Navigate(new History());

            
            }
            catch
            {
                MessageBox.Show("Добавьте товар и клиента!\nНельзя добавлять пустоту!");
            }
        }

        private void Next_Click(object sender, RoutedEventArgs e)
        {
            AccountUser.Block = 0;
            AccountUser.HisProduct = null;
            AccountUser.HisClient = null;
            NavigationService.Navigate(new History());
        }
    }
}
