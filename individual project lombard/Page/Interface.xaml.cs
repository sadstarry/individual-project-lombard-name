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
    /// Логика взаимодействия для Interface.xaml
    /// </summary>
    public partial class Interface 
    {
        public Interface()
        {
            InitializeComponent();

            if (AccountUser.nameuser.RoleId == 1)
            {
                WorkPeople.Visibility = Visibility.Visible;
                Money.Visibility = Visibility.Visible;
            }
            else
            {
                WorkPeople.Visibility = Visibility.Collapsed;
                Money.Visibility = Visibility.Collapsed;
            }
        }

        private void exit_Click(object sender, RoutedEventArgs e)
        {
            
            NavigationService.Navigate(new Authorization());
            AccountUser.Block = 0;
            AccountUser.HisProduct = null;
            AccountUser.HisClient = null;
        }

        private void Client_Click(object sender, RoutedEventArgs e)
        {
            if (AccountUser.Block == 1)
            {
                MessageBox.Show("Нельзя перейти, пока вы оформляете прием!");
            }
            else
            {
                MyFrame.Navigate(new Clients());
            }
        }

        private void History_Click(object sender, RoutedEventArgs e)
        {
            if (AccountUser.Block == 1)
            {
                MessageBox.Show("Нельзя перейти, пока вы оформляете прием!");
            }
            else
            {
                MyFrame.Navigate(new History());
            }
        }

        private void WorkPeople_Click(object sender, RoutedEventArgs e)
        {
            if (AccountUser.Block == 1)
            {
                MessageBox.Show("Нельзя перейти, пока вы оформляете прием!");
            }
            else
            {
                MyFrame.Navigate(new Accounts());
            }
        }

        private void Money_Click(object sender, RoutedEventArgs e)
        {
            if (AccountUser.Block == 1)
            {
                MessageBox.Show("Нельзя перейти, пока вы оформляете прием!");
            }
            else
            {
                MyFrame.Navigate(new Money());
            }
        }

        private void Product_Click(object sender, RoutedEventArgs e)
        {
            if (AccountUser.Block == 1)
            {
                MessageBox.Show("Нельзя перейти, пока вы оформляете прием!");
            }
            else
            {
                MyFrame.Navigate(new ProductList());
            }
        }
    }
}
