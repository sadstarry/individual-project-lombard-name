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
using individual_project_lombard.User;

namespace individual_project_lombard.Page
{
    /// <summary>
    /// Логика взаимодействия для Money.xaml
    /// </summary>
    public partial class Money
    {
        public Money()
        {
            InitializeComponent();

            Loss.Text= Dbconnect.db.Money.ToList().Find(x => x.ID == 1).Loss.ToString();
            Income.Text = Dbconnect.db.Money.ToList().Find(x => x.ID == 1).Income.ToString();
            Plus.Text = Convert.ToString(Dbconnect.db.Money.ToList().Find(x => x.ID == 1).Loss - (-Dbconnect.db.Money.ToList().Find(x => x.ID == 1).Income));
        }
    }
}
