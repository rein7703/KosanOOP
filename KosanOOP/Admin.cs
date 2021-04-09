using System;
using System.Collections.Generic;
using System.Text;

namespace KosanOOP
{
    class Admin : User
    {
        
        public Admin(string username, string password) : base(username, password)
        {
            this.Username = username;
            this.Password = password;
        }
        
    }
}
