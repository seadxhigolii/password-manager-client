using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace password_manager_client.Services.Auth.Dto
{
    public class RegisterDto
    {
        public string Username { get; set; }
        public string MasterPassword { get; set; }
        public string MasterPasswordRepeated { get; set; }
    }
}
