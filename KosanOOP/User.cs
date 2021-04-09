using System;
using System.Collections.Generic;
using System.Text;

namespace KosanOOP
{
    class User
    {
        public string Username { get; protected set; }
        public string Password { get; protected set; }

        public User(string username, string password)
        {
            this.Username = username;
            this.Password = password;
        }

    }
}

