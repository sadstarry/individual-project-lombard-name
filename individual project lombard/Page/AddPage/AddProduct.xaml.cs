using individual_project_lombard.Components;
using individual_project_lombard.User;
using Microsoft.Win32;
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
using System.IO;
using System.Windows.Shapes;

namespace individual_project_lombard.Page.AddPage
{
    /// <summary>
    /// Логика взаимодействия для AddProduct.xaml
    /// </summary>
    public partial class AddProduct
    {
        
        public AddProduct()
        {
            InitializeComponent();

            
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            string NameProd = Name.Text.Trim();
            string Difiration = Difi.Text.Trim();
            string PriceProd = Price1.Text.Trim();

            try {
            if(NameProd.Length > 0 && Difiration.Length > 0 && PriceProd.Length > 0)
            {
                Dbconnect.db.Product.Add(new Product
                {
                    Name = NameProd,
                    Description = Difiration,
                    Price = Convert.ToDecimal(PriceProd),
                    Data = DateTime.Now,
                    StatusID = 1,
                    AccaountID = Convert.ToInt32(AccountUser.nameuser.ID)
                });
                    //Разобраться с переменной, либо соединить в одну типа ЗАРАБОТАНО
                    var Money = Dbconnect.db.Money.ToList().Find(x => x.ID == 1);
                    Money.Income -= Convert.ToInt32(PriceProd);

                    Dbconnect.db.SaveChanges();
                    MessageBox.Show("Товар успешно добавлен!");
                    NavigationService.Navigate(new ProductList());
            }
            else
            {
                MessageBox.Show("Заполните данные!");
            }
            }
            catch
            {
                MessageBox.Show("Введите правильные данные!");
            }
        }

        private void Next_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void BtnAddImage_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog() { Filter = "*.png|*.png|*.jpeg|*.jpeg|*.jpg|*.jpg" };

            if (openFile.ShowDialog().GetValueOrDefault())
            {
                //Product.Image = File.ReadAllBytes(openFile.FileName);
                Images.Source = new BitmapImage(new Uri(openFile.FileName));
            }
        }
    }
}
