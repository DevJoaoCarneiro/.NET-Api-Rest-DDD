using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Request
{
    public class UserRequestDTO
    {
        public string name { get; set; } = string.Empty;

        public string email { get; set; } = string.Empty;

        public string password { get; set; } = string.Empty;
    }
}
