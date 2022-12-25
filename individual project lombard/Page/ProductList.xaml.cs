using individual_project_lombard.Components;
using individual_project_lombard.Page.AddPage;
using System;
using individual_project_lombard.User;
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
using System.Data;

namespace individual_project_lombard.Page
{
    /// <summary>
    /// Логика взаимодействия для ProductList.xaml
    /// </summary>
    /// 

    public partial class ProductList
    {
        public ProductList()
        {
            InitializeComponent();
            ListProduct.ItemsSource = Dbconnect.db.Product.ToList().Where(x => x.IsDelete != true);
            Sort();

        }

    

        private void TbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            Sort();
        }


        private void Add_Click(object sender, RoutedEventArgs e)
        {

            NavigationService.Navigate(new AddProduct());
        }

        private void podrobnee_Click(object sender, RoutedEventArgs e)
        {
            var BtnProd = (sender as Button).DataContext as Product;
            if(BtnProd.StatusID == 3 && AccountUser.nameuser.RoleId == 2)
            {
                MessageBox.Show("Вы не можете больше менять информацию о товаре!\nПри ошибки в заполнении обратитесь к администратору");
            }
            else
            {
                AccountUser.ProductEdit = Dbconnect.db.Product.Where(x => x.ID == BtnProd.ID).FirstOrDefault();
                AccountUser.ProdAccountID = Dbconnect.db.Account.Where(x => x.ID == BtnProd.AccaountID).FirstOrDefault();


                NavigationService.Navigate(new PodrobneeProduct(AccountUser.ProductEdit));
            }
        }

        private void Sort()
        {
            List<Product> products = Dbconnect.db.Product.Where(x => x.IsDelete != true).ToList();

            if ( TbSearch.Text.Length > 0)
            {
                products = products.Where(x => (x.Name != null && x.Name.ToLower().Contains(TbSearch.Text.ToLower())) || (x.Description != null && x.Description.ToLower().Contains(TbSearch.Text.ToLower()))).ToList();
                if(ListProduct != null)
                {
                    ListProduct.ItemsSource = products.ToList();
                }
                
            }
            else
            {
                ListProduct.ItemsSource = products.ToList();
            }

            ////Была попытка///
            List<Product> ProductStatus = new List<Product>();
            ProductStatus = Dbconnect.db.Product.ToList();
            for (int i = 0; i < ProductStatus.Count; i++)
            {
                var DateProd = Convert.ToDateTime(Dbconnect.db.Product.ToList().Find(x => x.ID == ProductStatus[i].ID).Data);
                Double ToPrice = Convert.ToDouble(Dbconnect.db.Product.ToList().Find(x => x.ID == ProductStatus[i].ID).Price);
                if (DateTime.Today > DateProd.AddMonths(1) && ProductStatus[i].StatusID == 1)
                {
                    Dbconnect.db.Product.ToList().Find(x => x.ID == ProductStatus[i].ID).StatusID = 2;
                    Dbconnect.db.Product.ToList().Find(x => x.ID == ProductStatus[i].ID).Price = Convert.ToDecimal(ToPrice + ToPrice * 0.2);
                    Dbconnect.db.SaveChanges();
                }
            }


        }

    }



    /*
     var BtnProd = (sender as Button).DataContext as Product;
            AccountUser.HisProduct = Dbconnect.db.Product.ToList().Find(x => x.ID == BtnProd.ID); //Заношу в глобал переменную айди добавляемого товара
            MessageBox.Show("Этот товар добавлен в оформление");


    public partial class Product //Визабилити !!!!!!!!!!!! важно !!!!!!!!!!!!!! запомнить
    {
        public Visibility AddToHis
        {
            get
            {
                if (AccountUser.Add == 1)
                {
                    return Visibility.Hidden;
                }
                else
                {
                    return Visibility.Visible;
                }
            }
        }
    }
    */
}
