using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Interfaces
{
    public interface ISecurityService
    {
        public string HashPassword(string password);


    }
}
