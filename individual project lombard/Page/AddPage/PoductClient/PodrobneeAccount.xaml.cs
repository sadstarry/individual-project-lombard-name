using individual_project_lombard.Components;
using individual_project_lombard.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Policy;
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
    /// Логика взаимодействия для PodrobneeAccount.xaml
    /// </summary>
    public partial class PodrobneeAccount 
    {
        public PodrobneeAccount()
        {
            InitializeComponent();

            var EditAcc = AccountUser.AccountEdit;

            ID.Text = Convert.ToString(EditAcc.ID);
            Name.Text = Convert.ToString(EditAcc.Name);
            Surname.Text = Convert.ToString(EditAcc.Surname);
            Login.Text = Convert.ToString(EditAcc.Login);
            Password.Text = Convert.ToString(EditAcc.Password);
            Role.SelectedIndex = Convert.ToInt32(EditAcc.RoleId) - 1;
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            Account SaveProd = Dbconnect.db.Account.Where(x => x.ID == AccountUser.AccountEdit.ID).FirstOrDefault();

            try
            {
                SaveProd.Name = Name.Text.Trim();
                SaveProd.Surname = Surname.Text.Trim();
                SaveProd.Login = Login.Text.Trim();
                SaveProd.Password = Password.Text.Trim();
                SaveProd.RoleId = Role.SelectedIndex + 1;

                Dbconnect.db.SaveChanges();
                MessageBox.Show("Изменения внесены!");
                NavigationService.Navigate(new Accounts());
            }
            catch
            {
                MessageBox.Show("Вы ввели что-то не правильно!");
            }
        }

        private void Next_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Вы точно хотите удалить данный Аккаунт?", "Предупреждение", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.No)
            {

            }
            else
            {
                Account Delete = Dbconnect.db.Account.Where(x => x.ID == AccountUser.AccountEdit.ID).FirstOrDefault();
                Delete.IsDelete = true;
                Dbconnect.db.SaveChanges();
                MessageBox.Show("Вы удалили данный товар!");
                NavigationService.Navigate(new Accounts());
            }
        }
    }
}
