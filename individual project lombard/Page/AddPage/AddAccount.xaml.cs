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
    /// Логика взаимодействия для AddAccount.xaml
    /// </summary>
    public partial class AddAccount
    {
        public AddAccount()
        {
            InitializeComponent();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            string NameClient = Name.Text.Trim();
            string SurnameClietn = Surname.Text.Trim();
            string Login = Part.Text.Trim();
            string Password = DataBirth.Text.Trim();
            try
            {
                if (NameClient.Length > 0 && SurnameClietn.Length > 0 && Login.Length > 0 && Password.Length > 0 )
                {
                    Dbconnect.db.Account.Add(new Account
                    {
                        Name = NameClient,
                        Surname = SurnameClietn,
                        Login = Login,
                        Password = Password,
                        RoleId = 1
                    });

                    Dbconnect.db.SaveChanges();
                    MessageBox.Show("Успешно зарегистрирована новая учетная запись");
                    NavigationService.Navigate(new Accounts());
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

        }

        private void BtnAddImage_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
