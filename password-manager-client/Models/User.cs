﻿using password_manager_client.Models.Shared;

namespace password_manager_client.Models
{
    public class User : BaseEntity<Guid>
    {
        #region Properties
        public string Username { get; set; }
        public string MasterPassword { get; set; }
        public string? MasterPasswordHint { get; set; }
        public string PublicKey { get; set; }
        public string EncryptedPrivateKey { get; set; }
        public string EncryptedAESKey { get; set; }
        public string Salt { get; set; }

        #endregion Properties
    }
}