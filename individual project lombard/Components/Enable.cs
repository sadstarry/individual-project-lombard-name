using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using individual_project_lombard.Components;
using individual_project_lombard.User;

namespace individual_project_lombard.Components
{
    public partial class Product
    {
        public string enable
        {
            get
            {
                if (AccountUser.ProductEdit.StatusID == 4)
                {
                    return "false";
                }
                else
                {
                    return "true";
                }
            }
        }

    }
}
