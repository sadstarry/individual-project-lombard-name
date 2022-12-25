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

namespace individual_project_lombard.Page
{
    /// <summary>
    /// Логика взаимодействия для History.xaml
    /// </summary>
    public partial class History
    {
        public History()
        {
            InitializeComponent();
            ListProduct.ItemsSource = Dbconnect.db.ClientProduct.Where(x => x.IsDelete != true).ToList();
            Sort();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AccountUser.Block = 1;
            //Переходим для добавления новой сдачи товара, для истории
            NavigationService.Navigate(new AddPage.AddHistory());
        }

        private void TbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            Sort();
        }
        private void Sort()
        {
            //Как сделать сортировку то?
            //Ну типа........................................................................................
            //Сортировка абакадабра заработый 
            List<Client> client = Dbconnect.db.Client.Where(x => x.IsDelete != true).ToList();
            List<Product> product = Dbconnect.db.Product.Where(x => x.IsDelete != true).ToList();
            List<ClientProduct> histor = Dbconnect.db.ClientProduct.Where(x => x.IsDelete != true).ToList();

            var templist = new List<ClientProduct>();
           
            //products = products.Where(x => (x.Name != null && x.Name.ToLower().Contains(TbSearch.Text.ToLower())) || (x.Description != null && x.Description.ToLower().Contains(TbSearch.Text.ToLower()))).ToList();
            //Как сделать так, чтобы поиск работал не через айдишник, а через нейм и тдтдтд. Как я понимаю без перебора данных не обойтись
            if (ListProduct != null)
            {
                for(int i = 0; i < histor.Count; i++)
                {
                   if (product.Where(x => x.ID == histor[i].ProductID).FirstOrDefault() != null && client.Where(x => x.ID == histor[i].ClientID).FirstOrDefault() != null) {
                        templist.Add(histor[i]);
                    }
                }

                templist = templist.Where(x => (product.Where(y => y.ID == x.ProductID).FirstOrDefault() != null && product.Where(y => y.ID == x.ProductID).FirstOrDefault().Name.ToLower().Contains(TbSearch.Text.ToLower())) || (client.Where(z => z.ID == x.ClientID).FirstOrDefault() != null && client.Where(z => z.ID == x.ClientID).FirstOrDefault().Name.ToLower().Contains(TbSearch.Text.ToLower()))).ToList();


                ListProduct.ItemsSource= templist.ToList();
            }
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if(AccountUser.nameuser.RoleId== 1)
            {
                if (MessageBox.Show("Вы точно хотите удалить данный товар?", "Предупреждение", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.No)
                {

                }
                else
                {
                    var BtnProd = (sender as Button).DataContext as ClientProduct;
                    BtnProd.IsDelete = true;
                    Dbconnect.db.SaveChanges();
                    MessageBox.Show("Вы удалили данную запись!");
                }
            }
            else
            {
                MessageBox.Show("У вас недостаточно прав!\nОбратитесь к администратору!");
            }

        }

}
    }
