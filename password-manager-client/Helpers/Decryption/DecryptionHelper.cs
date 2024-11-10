using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;

namespace password_manager_client.Helpers.Decryption
{
    public class DecryptionHelper
    {
        public static byte[] DeriveKeyFromPassword(string password, byte[] salt)
        {
            return KeyDerivation.Pbkdf2(
                password: password,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: 100_000,
                numBytesRequested: 32); // 256-bit key
        }

        public static byte[] DecryptWithAES(byte[] encryptedData, byte[] key)
        {
            using (var aes = Aes.Create())
            {
                aes.Key = key;

                var iv = new byte[16];
                Array.Copy(encryptedData, 0, iv, 0, iv.Length);
                aes.IV = iv;

                var cipherText = new byte[encryptedData.Length - iv.Length];
                Array.Copy(encryptedData, iv.Length, cipherText, 0, cipherText.Length);

                using var decryptor = aes.CreateDecryptor(aes.Key, aes.IV);
                return decryptor.TransformFinalBlock(cipherText, 0, cipherText.Length);
            }
        }
    }
}
