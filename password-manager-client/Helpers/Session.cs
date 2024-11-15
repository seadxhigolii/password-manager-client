namespace password_manager_client.Helpers
{
    public static class Session
    {
        public static Guid UserId { get; private set; }
        public static string? AuthToken { get; private set; }
        public static string? PrivateKey { get; private set; }
        public static string? PublicKey { get; private set; }
        public static string? Username { get; private set; }

        public static bool IsAuthenticated => !string.IsNullOrEmpty(AuthToken);

        public static void StartSession(Guid userId, string authToken, string privateKey, string publicKey, string username)
        {
            UserId = userId;
            AuthToken = authToken;
            PrivateKey = privateKey;
            Username = username;
            PublicKey = publicKey;
        }

        public static void EndSession()
        {
            UserId = Guid.Empty;
            AuthToken = null;
            PrivateKey = null;
            Username = null;
            PublicKey = null;
        }
    }

}
