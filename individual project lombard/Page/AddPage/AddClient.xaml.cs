using individual_project_lombard.Components;
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
    /// Логика взаимодействия для AddClient.xaml
    /// </summary>
    public partial class AddClient
    {
        public AddClient()
        {
            InitializeComponent();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            
            try
            {
                string NameClient = Name.Text.Trim();
                string SurnameClient = Surname.Text.Trim();
                string PartClient = Part.Text.Trim();
                string Birthday = DataBirth.Text.Trim();
                string AdressClient = Address.Text.Trim();
                string PhoneClient = Phone.Text.Trim();
                string EmailClient = Email.Text.Trim();

                if (NameClient.Length > 0 && SurnameClient.Length > 0 && PartClient.Length > 0 && AdressClient.Length > 0 && PhoneClient.Length > 0 && EmailClient.Length > 0)
                {
                    Dbconnect.db.Client.Add(new Client
                    {
                        Name = NameClient,
                        Surname = SurnameClient,
                        Patronymic = PartClient,
                        Birthday = Convert.ToDateTime(Birthday),
                        RegAddress = AdressClient,
                        Email = EmailClient,
                        Phone = PhoneClient,
                    });

                    Dbconnect.db.SaveChanges();
                    MessageBox.Show("Успешно добавлен новый клиент");
                    NavigationService.Navigate(new Client());
                }
                else
                {
                    MessageBox.Show("Заполните данные!");
                }
            }
            catch
            {
                MessageBox.Show("Введите правильные данные!\nЗаполните номер в виде: 89998887766\nДату в виде: 2022-12-22 ");
            }
        }

        private void Next_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void BtnAddImage_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
