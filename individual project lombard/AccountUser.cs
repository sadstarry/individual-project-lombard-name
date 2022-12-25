using System;
using individual_project_lombard.Components;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace individual_project_lombard.User
{
    public class AccountUser
    {
        public static Account nameuser = new Account(); //Глобальная перменная для сохранения Айди зашедшего пользователя
        public static Product Prod = new Product(); // Для картинки

        public static int Block = new int(); //Для блокировки
        //Переменные для хранения добавляемый продуктов и клиентов в историю
        public static Product HisProduct = new Product();
        public static Client HisClient = new Client();

        //Переменные для редактирования товаров, клиентов, пользователей и тд)))))))))
        public static Product ProductEdit = new Product();
        public static Client ClientEdit = new Client();
        public static Account AccountEdit = new Account();

        public static Account ProdAccountID = new Account();     
    }


}
