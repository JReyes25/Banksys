using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banksys
{
    public class User
    {
        public string name { get; set; }
        public int userId { get; set; }
        public bool admin { get; set; }
        public float balance { get; set; }
        public string phone { get; set; }
        public string password { get; set; }


        public int Transfer(float amount, string name, string phone, List<User> UsersL)
        {
            if (this.balance >= amount)
            {
                UsersL[SearchUsersL(name, phone, UsersL)].balance += amount;
                this.balance -= amount;
                // Send confirmation mesage here
                return 1;
            }
            else return -1;
        }

        public int SearchUsersL(string name, string phone, List<User> UsersL)
        {
            int maxUsers = UsersL.Count;

            for (int i = 0; i <= maxUsers; i++)
            {
                if ((name == UsersL[i].name) && (phone == UsersL[i].phone))
                {
                    return i;
                }
            }
            return -1;
        }

    }
}
s