using password_manager_client.Enum;

namespace password_manager_client.Services.Vault.Dto
{
    public class CreateVaultDto
    {
        public Guid UserId { get; set; }
        public int ItemType { get; set; }
        public string Title { get; set; }
        public string EncryptedPassword { get; set; }
        public string Username { get; set; }
        public string? Url { get; set; }

    }
}
