namespace password_manager_client.Responses.Auth
{
    public class LoginResponse
    {
        public Guid UserId { get; set; }
        public string Username { get; set; }
        public string Token { get; set; }
        public string PrivateKey { get; set; }
    }
}
