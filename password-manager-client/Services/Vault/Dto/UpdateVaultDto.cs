﻿using password_manager_client.Enum;

namespace password_manager_client.Services.Vault.Dto
{
    public class UpdateVaultDto
    {
        #region Properties

        public Guid Id { get; set; }
        public string Title { get; set; }
        public int ItemType { get; set; }
        public string EncryptedNotes { get; set; }
        public bool? IsFavorite { get; set; }


        public string? Username { get; set; }
        public string? EncryptedPassword { get; set; }
        public string? Url { get; set; }
        public byte[]? FavIcon { get; set; }


        public string? CardholderName { get; set; }
        public string? EncryptedCardNumber { get; set; }
        public string? ExpirationDate { get; set; }
        public string? EncryptedSecurityCode { get; set; }

        #endregion Properties
    }
}
