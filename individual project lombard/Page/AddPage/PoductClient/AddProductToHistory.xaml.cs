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
    /// Логика взаимодействия для AddProductToHistory.xaml
    /// </summary>
    public partial class AddProductToHistory
    {
        public AddProductToHistory()
        {
            InitializeComponent();
            ListProduct.ItemsSource = Dbconnect.db.Product.Where(x => (x.IsDelete != true) && (x.IsDropToHistory != true)).ToList();
        }

        private void Sort()
        {
            List<ClientProduct> Per = Dbconnect.db.ClientProduct.Where(x => x.IsDelete != true).ToList();
            List<Product> prod = Dbconnect.db.Product.Where(x => x.IsDelete != true).ToList();

            var templist = new List<Product>();

            for (int i = 0; i < Per.Count; i++)
            {
                for (int d = 0; d < prod.Count; d++)
                {
                    if (Per[d].ProductID == prod[d].ID)
                    {
                        if (ListProduct == null)
                        {
                            ListProduct.ItemsSource = templist.ToList();
                        }
                    }
                    else
                    {
                            templist.Add(prod[i]);
                            ListProduct.ItemsSource = templist.ToList();
                    }
                }
            }
        }
        private void AddToAHistory_Click(object sender, RoutedEventArgs e)
        {
            var BtnProd = (sender as Button).DataContext as Product;

            AccountUser.HisProduct = Dbconnect.db.Product.ToList().Find(x => x.ID == BtnProd.ID);
            MessageBox.Show("Этот товар добавлен в оформление");
            NavigationService.Navigate(new AddHistory());
            
        }

        private void Next_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
