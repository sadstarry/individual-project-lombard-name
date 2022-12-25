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
    /// Логика взаимодействия для PodrobneeClients.xaml
    /// </summary>
    public partial class PodrobneeClients 
    {
        Client Client;
        public PodrobneeClients(Client client)
        {
            InitializeComponent();

            Client = client;
            DataContext = Client;

            var EditClient = AccountUser.ClientEdit;

            ID.Text = Convert.ToString(EditClient.ID);
            Name.Text = Convert.ToString(EditClient.Name);
            Surname.Text = Convert.ToString(EditClient.Surname);
            Part.Text = Convert.ToString(EditClient.Patronymic);
            DataBirth.Text = Convert.ToString(EditClient.Birthday);
            Address.Text = Convert.ToString(EditClient.RegAddress);
            Email.Text = Convert.ToString(EditClient.Email);
            Phone.Text =  Convert.ToString(EditClient.Phone);
            


        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            Client SaveProd = Dbconnect.db.Client.Where(x => x.ID == AccountUser.ClientEdit.ID).FirstOrDefault();

            try
            {
                SaveProd.Name = Name.Text.Trim();
                SaveProd.Surname = Surname.Text.Trim();
                SaveProd.Patronymic = Part.Text.Trim();
                SaveProd.Birthday = Convert.ToDateTime(DataBirth.Text.Trim());
                SaveProd.RegAddress= Address.Text.Trim();
                SaveProd.Phone = Phone.Text.Trim();
                SaveProd.Email= Email.Text.Trim();

                Dbconnect.db.SaveChanges();
                MessageBox.Show("Изменения внесены!");
                NavigationService.Navigate(new Clients());
            }
            catch
            {
                MessageBox.Show("Вы ввели что-то не правильно!");
            }
        }

        private void Next_Click(object sender, RoutedEventArgs e)
        {
            Client SaveProd = Dbconnect.db.Client.Where(x => x.ID == AccountUser.ClientEdit.ID).FirstOrDefault();
            if (Name.Text.Trim() != SaveProd.Name || Surname.Text.Trim().ToLower() != SaveProd.Surname.ToLower().Trim() || Part.Text.Trim().ToLower() != SaveProd.Patronymic.ToLower().Trim() || DataBirth.Text.Trim() != Convert.ToString(SaveProd.Birthday).Trim() || Address.Text.Trim().ToLower() != SaveProd.RegAddress.Trim().ToLower() || Email.Text.Trim().ToLower() != SaveProd.Email.ToLower().Trim() || Phone.Text.Trim() != SaveProd.Phone.Trim())
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
                        SaveProd.Surname = Surname.Text.Trim();
                        SaveProd.Patronymic = Part.Text.Trim();
                        SaveProd.Birthday = Convert.ToDateTime(DataBirth.Text.Trim());
                        SaveProd.RegAddress = Address.Text.Trim();
                        SaveProd.Phone = Phone.Text.Trim();
                        SaveProd.Email = Email.Text.Trim();

                        Dbconnect.db.SaveChanges();
                        MessageBox.Show("Изменения внесены!");
                        NavigationService.Navigate(new Client());

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

        private void BtnAddImage_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog() { Filter = "*.png|*.png|*.jpeg|*.jpeg|*.jpg|*.jpg" };

            if (openFile.ShowDialog().GetValueOrDefault())
            {
                Client.Image = File.ReadAllBytes(openFile.FileName);
                Images.Source = new BitmapImage(new Uri(openFile.FileName));
            }
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Вы точно хотте удалить данного клиента?", "Предупреждение", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.No)
            {

            }
            else
            {
                Client Delete = Dbconnect.db.Client.Where(x => x.ID == AccountUser.ClientEdit.ID).FirstOrDefault();
                Delete.IsDelete = true;
                Dbconnect.db.SaveChanges();
                MessageBox.Show("Вы удалили данного клиента!");
                NavigationService.Navigate(new Clients());
            }
        }
    }
}
