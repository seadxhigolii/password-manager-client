using System;
using System.Security.Cryptography;
using System.Text;

namespace password_manager_client.Helpers
{
    public static class Session
    {
        public static Guid UserId { get; private set; }
        private static byte[]? encryptedAuthToken;
        private static byte[]? encryptedPrivateKey;
        private static byte[]? encryptedPublicKey;
        public static string? Username { get; private set; }

        public static bool IsAuthenticated => encryptedAuthToken != null && encryptedAuthToken.Length > 0;

        public static string? AuthToken
        {
            get => encryptedAuthToken != null ? DecryptData(encryptedAuthToken) : null;
            private set => encryptedAuthToken = value != null ? EncryptData(value) : null;
        }

        public static string? PrivateKey
        {
            get => encryptedPrivateKey != null ? DecryptData(encryptedPrivateKey) : null;
            private set => encryptedPrivateKey = value != null ? EncryptData(value) : null;
        }

        public static string? PublicKey
        {
            get => encryptedPublicKey != null ? DecryptData(encryptedPublicKey) : null;
            private set => encryptedPublicKey = value != null ? EncryptData(value) : null;
        }

        public static void StartSession(Guid userId, string authToken, string privateKey, string publicKey, string username)
        {
            UserId = userId;
            AuthToken = authToken;
            PrivateKey = privateKey;
            PublicKey = publicKey;
            Username = username;
        }

        public static void EndSession()
        {
            UserId = Guid.Empty;
            encryptedAuthToken = null;
            encryptedPrivateKey = null;
            encryptedPublicKey = null;
            Username = null;
        }

        private static byte[] EncryptData(string plainText)
        {
            byte[] data = Encoding.UTF8.GetBytes(plainText);
            return ProtectedData.Protect(data, null, DataProtectionScope.CurrentUser);
        }

        private static string DecryptData(byte[] encryptedData)
        {
            byte[] decryptedData = ProtectedData.Unprotect(encryptedData, null, DataProtectionScope.CurrentUser);
            return Encoding.UTF8.GetString(decryptedData);
        }
    }
}
