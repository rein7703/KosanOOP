using System;
using System.Collections.Generic;
using System.Text;

namespace KosanOOP
{
    class Member : User
    {
        public Member(string username, string password) : base (username, password)
        {
            this.Username = username;
            this.Password = password;
        }
    }
}
