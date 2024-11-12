namespace password_manager_client.Models
{
    public static class Session
    {
        public static Guid UserId { get; private set; }
        public static string? AuthToken { get; private set; }
        public static string? PrivateKey { get; private set; }
        public static string? Username { get; private set; }

        public static bool IsAuthenticated => !string.IsNullOrEmpty(UserId.ToString()) && !string.IsNullOrEmpty(AuthToken) && !string.IsNullOrEmpty(PrivateKey) && !string.IsNullOrEmpty(Username);

        public static void StartSession(Guid userId, string authToken, string privateKey, string username)
        {
            UserId = userId;
            AuthToken = authToken;
            PrivateKey = privateKey;
            Username = username;
        }

        public static void EndSession()
        {
            UserId = Guid.Empty;
            AuthToken = null;
            PrivateKey = null;
            Username = null;
        }
    }

}
