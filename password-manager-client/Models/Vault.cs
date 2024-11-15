using password_manager_client.Enum;
using password_manager_client.Models.Shared;

namespace password_manager_client.Models
{
    public class Vault : BaseEntity<Guid>
    {
        #region Properties
        public Guid UserId { get; set; }
        public string Title { get; set; }
        public VaultItemTypeEnum ItemType { get; set; }
        public string EncryptedNotes { get; set; }
        public bool IsFavorite { get; set; }
        public DateTime? LastAccessedOn { get; set; }
        public string Username { get; set; }
        public string EncryptedPassword { get; set; }
        public string Url { get; set; }
        public int PasswordHistory { get; set; }
        public string CardholderName { get; set; }
        public string EncryptedCardNumber { get; set; }
        public string ExpirationDate { get; set; }
        public string EncryptedSecurityCode { get; set; }

        #endregion Properties
    }
}
