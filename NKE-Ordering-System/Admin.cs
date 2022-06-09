using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NKE_Ordering_System
{
    class Admin
    {
        public string Access_Password { get; set; }
        public bool ValidateAdmin { get; set; }
        public void accessPasswordValidation()
        {
            if(Access_Password == "admin123")
            {
                ValidateAdmin = true;
            }
            else
            {
                ValidateAdmin = false;
            }
        }
    }
}
