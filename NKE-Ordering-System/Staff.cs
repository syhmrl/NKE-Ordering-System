using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NKE_Ordering_System
{
    class Staff : Admin
    {
        NKEOrderDataContext db = new NKEOrderDataContext();
        public int _Id { get; set; }
        public string _Name { get; set; }
        public string _Password { get; set; }
        public string _Role { get; set; }
        public bool exist { get; set; }
        public bool isStaff { get; set; }
        public bool isAdmin { get; set; }

        public void SaveUser()
        {
            IEnumerable<User> queryUser =
                from staff in db.Users
                where staff.Name == _Name
                select staff;

            if (queryUser.Count() != 0)
            {
                exist = true;
                /*int checkID = 1;
                do
                {
                    generateID();

                    checkID = (from IDQ in db.Users
                               where IDQ.UserID == _Id
                               select IDQ).Count();
                } while (checkID != 0);*/
            }
            else
            {
                exist = false;

                User user = new User();
                user.UserID = _Id;
                user.Name = _Name;
                user.Password = _Password;
                user.Role = _Role;

                db.Users.InsertOnSubmit(user);
                db.SubmitChanges();
            }
        }

        public int generateID()
        {
            Random random = new Random();
            int newID = random.Next(1000, 9999);
            _Id = newID;
            return _Id;
        }

        public void loginUser()
        {
            IEnumerable<User> queryStaff =
                from staff in db.Users
                where staff.Name == _Name
                where staff.Password == _Password
                where staff.Role == "Staff"
                select staff;

            IEnumerable<User> queryAdmin =
                from staff in db.Users
                where staff.Name == _Name
                where staff.Password == _Password
                where staff.Role == "Manager"
                select staff;

            if (queryStaff.Count() != 0)
            {
                isStaff = true;
                isAdmin = false;
                
            }
            else if (queryAdmin.Count() != 0)
            {
                isAdmin = true;
                isStaff = false;
            }
            else
            {
                isStaff = false;
                isAdmin = false;
            }

            foreach (User user in queryStaff)
            {
                _Id = user.UserID;
            }

            foreach (User admin in queryAdmin)
            {
                _Id = admin.UserID;
            }
        }

    }
}
