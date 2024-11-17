using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace password_manager_client.Services.Vault.Dto
{
    public class GetVaultsByUserId
    {
        public Guid UserId { get; set; }
    }
}
