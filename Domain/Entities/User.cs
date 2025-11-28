using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.entities
{
    public class User
    {
        public Guid userId { get; private set; }
        public string name { get; private set; } = string.Empty;
        public string email { get; private set; } = string.Empty;
        public string passwordHash { get; private set; } = string.Empty;

        public User()
        {
        }

        public User(string name, string email, string passwordHash)
        {
            this.userId = Guid.NewGuid();
            this.name = name;
            this.email = email;
            this.passwordHash = passwordHash;
        }


    }
}
