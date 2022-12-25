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
using System.Windows.Threading;
using System.Windows.Shapes;
using System.IO;
using System.Security.Cryptography.X509Certificates;


namespace individual_project_lombard.Page
{
    /// <summary>
    /// Логика взаимодействия для Authorization.xaml
    /// </summary>
    public partial class Authorization 
    {
        string Login = "";
        string path = System.IO.Path.GetTempPath() + "Lom\\";
        public Authorization()
        {
            Directory.CreateDirectory(path);
            InitializeComponent();

                if (File.Exists(path + "login.txt"))
                {
                    
                    TbLogin.Text = check_file("login.txt");
                    SaveData.IsChecked = true;
                }

        }

        private void Auth_Click(object sender, RoutedEventArgs e)
        {
            Login = TbLogin.Text.Trim().ToLower(); 
            string Password = TbPassword.Text.Trim();
            bool SDLogin = SaveData.IsChecked.Value;

            if (Login.Length == 0 && Password.Length == 0)
            {
                MessageBox.Show("Заполните поля!");
            }
            else
            {
                var AuthUser = Dbconnect.db.Account.ToList().Find(x => x.Login == Login && x.Password == Password);
                if(AuthUser == null)
                {
                    MessageBox.Show("Не правильный логин или пароль");
                }
                else
                {
                    if (SDLogin)
                    {
                        create_file("login.txt", Login);
                    }
                    else
                    {
                        File.Delete(path + "login.txt");
                    }
                    AccountUser.nameuser = AuthUser;

                    if(AccountUser.nameuser.IsDelete == false || AccountUser.nameuser.IsDelete == null)
                    {
                        if (Dbconnect.db.Account.ToList().Find(x => x.Login == Login).RoleId == 1)
                        {
                            NavigationService.Navigate(new Interface());
                        }
                        else if (Dbconnect.db.Account.ToList().Find(x => x.Login == Login).RoleId == 2)
                        {
                            NavigationService.Navigate(new Interface());
                        }
                    }
                    else
                    {
                        MessageBox.Show("Этот аккаунт был удален!\nВы не можете авторизоваться в данной системе");
                    }
                }

            }
        }

        public void create_file(string name, string text)
        {
            using (FileStream fs = File.Create(path + name))
            {
                byte[] info = new UTF8Encoding(true).GetBytes(text);
                fs.Write(info, 0, info.Length);
            }

        }

        public string check_file(string name)
        {
            string temptext = "";
            using (StreamReader sr = File.OpenText(path + name))
            {
                while ((temptext = sr.ReadLine()) != null)
                {
                    return temptext;
                }
            }
            return temptext;
        }

    }
}
