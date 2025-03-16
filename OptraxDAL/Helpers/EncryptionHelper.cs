using System.Security.Cryptography;

namespace OptraxDAL.Helpers
{
    public static class AesEncryptionHelper
    {
        private static byte[] _key = [];
        private static byte[] _iv = [];

        public static void Initialize(string keyBase64, string ivBase64)
        {
            if (string.IsNullOrEmpty(keyBase64) || string.IsNullOrEmpty(ivBase64))
            {
                throw new ArgumentException("Key and IV cannot be null or empty.");
            }

            _key = Convert.FromBase64String(keyBase64);
            _iv = Convert.FromBase64String(ivBase64);
        }

        public static string Encrypt(string plainText)
        {
            if (_key == null || _iv == null)
                throw new InvalidOperationException("AesEncryptionHelper is not initialized.");

            using Aes aesAlg = Aes.Create();
            aesAlg.Key = _key;
            aesAlg.IV = _iv;

            using var encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);
            using var msEncrypt = new MemoryStream();
            using var csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write);
            using var swEncrypt = new StreamWriter(csEncrypt);
            swEncrypt.Write(plainText);
            swEncrypt.Close();

            return Convert.ToBase64String(msEncrypt.ToArray());
        }

        public static string Decrypt(string cipherText)
        {
            if (_key == null || _iv == null)
                throw new InvalidOperationException("AesEncryptionHelper is not initialized.");

            var buffer = Convert.FromBase64String(cipherText);

            using Aes aesAlg = Aes.Create();
            aesAlg.Key = _key;
            aesAlg.IV = _iv;

            using var decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);
            using var msDecrypt = new MemoryStream(buffer);
            using var csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read);
            using var srDecrypt = new StreamReader(csDecrypt);

            return srDecrypt.ReadToEnd();
        }
    }
}