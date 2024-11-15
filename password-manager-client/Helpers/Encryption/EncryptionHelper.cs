using System;
using System.Security.Cryptography;
using System.Text;

namespace password_manager_client.Helpers.Encryption
{
    public class EncryptionHelper
    {
        public static string EncryptWithRSA(string data, string base64PublicKey)
        {
            try
            {
                using (var rsa = RSA.Create())
                {
                    var keyBytes = Convert.FromBase64String(base64PublicKey);

                    rsa.ImportRSAPublicKey(keyBytes, out _);

                    var dataBytes = Encoding.UTF8.GetBytes(data);
                    var encryptedBytes = rsa.Encrypt(dataBytes, RSAEncryptionPadding.OaepSHA256);

                    return Convert.ToBase64String(encryptedBytes);
                }
            }
            catch (Exception e)
            {
                throw new CryptographicException("Failed to encrypt data.", e);
            }
        }
    }
}
