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
    /// Логика взаимодействия для PodrobneeProduct.xaml
    /// </summary>
    public partial class PodrobneeProduct
    {
        Product Product;
        public PodrobneeProduct(Product product)
        {
            InitializeComponent();

            if (AccountUser.ProductEdit.StatusID == 4)
            {
                Name.IsEnabled = false;
                Difi.IsEnabled= false;
                Price1.IsEnabled= false;
                Status.IsEnabled= false;
                Add.IsEnabled= false;
                BtnAddImage.IsEnabled= false;

                var EditProd = AccountUser.ProductEdit;
                var AccountEditProd = AccountUser.ProdAccountID;

                ID.Text = Convert.ToString(EditProd.ID);
                Name.Text = Convert.ToString(EditProd.Name);
                Difi.Text = Convert.ToString(EditProd.Description);
                Price1.Text = Convert.ToString(EditProd.Price);
                WorkPeople.Text = Convert.ToString(AccountEditProd.Name);
                Date.Text = Convert.ToString(EditProd.Data);
                Status.SelectedIndex = Convert.ToInt32(EditProd.StatusID) - 1;
            }
            else
            {
                Product = product;
                DataContext = Product;
                try
                {
                    var EditProd = AccountUser.ProductEdit;
                    var AccountEditProd = AccountUser.ProdAccountID;

                    ID.Text = Convert.ToString(EditProd.ID);
                    Name.Text = Convert.ToString(EditProd.Name);
                    Difi.Text = Convert.ToString(EditProd.Description);
                    Price1.Text = Convert.ToString(EditProd.Price);
                    WorkPeople.Text = Convert.ToString(AccountEditProd.Name);
                    Date.Text = Convert.ToString(EditProd.Data);
                    Status.SelectedIndex = Convert.ToInt32(EditProd.StatusID) - 1;
                }
                catch
                {
                    MessageBox.Show("Ой, что-то пошло не так!");
                }
            }
        }

        private void BtnAddImage_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog() { Filter = "*.png|*.png|*.jpeg|*.jpeg|*.jpg|*.jpg" };

            if (openFile.ShowDialog().GetValueOrDefault())
            {
                Product.Image = File.ReadAllBytes(openFile.FileName);
                Images.Source = new BitmapImage(new Uri(openFile.FileName));
            }

        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            Product SaveProd = Dbconnect.db.Product.Where(x => x.ID == AccountUser.ProductEdit.ID).FirstOrDefault();

           
            try
            {
                SaveProd.Name = Name.Text.Trim();
                SaveProd.Description = Difi.Text.Trim();
                SaveProd.Price = Convert.ToDecimal(Price1.Text.Trim());
                SaveProd.StatusID = Status.SelectedIndex + 1;

                Dbconnect.db.SaveChanges();
                MessageBox.Show("Изменения внесены!");
                NavigationService.Navigate(new ProductList());

                if (SaveProd.StatusID == 4 && SaveProd.IsDropToLoss != true)
                {
                    var Money = Dbconnect.db.Money.ToList().Find(x => x.ID == 1);
                    Money.Loss += Convert.ToInt32(SaveProd.Price);
                    SaveProd.IsDropToLoss = true;
                }
                else if (SaveProd.StatusID == 3 && SaveProd.IsDropToLoss != true)
                {
                    var Money = Dbconnect.db.Money.ToList().Find(x => x.ID == 1);
                    Money.Loss += Convert.ToInt32(Convert.ToDouble(SaveProd.Price)+Convert.ToDouble(SaveProd.Price)*0.2);
                    SaveProd.IsDropToLoss = true;
                }
            }
            catch
            {
                MessageBox.Show("Заполните поля правильно!");
            } 
        }

        private void Next_Click(object sender, RoutedEventArgs e)
        {
            Product SaveProd = Dbconnect.db.Product.Where(x => x.ID == AccountUser.ProductEdit.ID).FirstOrDefault();
            if (Name.Text.Trim() != SaveProd.Name || Difi.Text.Trim().ToLower() != SaveProd.Description.ToLower() || Convert.ToDecimal(Price1.Text.Trim()) != SaveProd.Price || Status.SelectedIndex + 1 != SaveProd.StatusID)
            {
                if (MessageBox.Show("Сохранить изменения", "Предупреждение", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.No)
                {
                    NavigationService.GoBack();
                }
                else
                {
                    try
                    {
                        SaveProd.Name = Name.Text.Trim();
                        SaveProd.Description = Difi.Text.Trim();
                        SaveProd.Price = Convert.ToDecimal(Price1.Text.Trim());
                        SaveProd.StatusID = Status.SelectedIndex + 1;

                        Dbconnect.db.SaveChanges();
                        MessageBox.Show("Изменения внесены!");
                        NavigationService.Navigate(new ProductList());

                        if (SaveProd.StatusID == 4 && SaveProd.IsDropToLoss != true)
                        {
                            var Money = Dbconnect.db.Money.ToList().Find(x => x.ID == 1);
                            Money.Loss += Convert.ToInt32(SaveProd.Price);
                            SaveProd.IsDropToLoss = true;
                        }
                        else if (SaveProd.StatusID == 3 && SaveProd.IsDropToLoss != true)
                        {
                            var Money = Dbconnect.db.Money.ToList().Find(x => x.ID == 1);
                            Money.Loss += Convert.ToInt32(Convert.ToDouble(SaveProd.Price) + Convert.ToDouble(SaveProd.Price) * 0.2);
                            SaveProd.IsDropToLoss = true;
                        }

                    }
                    catch
                    {
                        MessageBox.Show("Заполните поля правильно!");
                    }
                }
            }
            else
            {
                NavigationService.GoBack();
            }
            
        }

        private void Detele_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Вы точно хотте удалить данный товар?", "Предупреждение", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.No)
            {
                
            }
            else
            {
                Product Delete = Dbconnect.db.Product.Where(x => x.ID == AccountUser.ProductEdit.ID).FirstOrDefault();
                Delete.IsDelete = true;
                Dbconnect.db.SaveChanges();
                MessageBox.Show("Вы удалили данный товар!");
                NavigationService.Navigate(new ProductList());
            }
            
        }
    }
}
