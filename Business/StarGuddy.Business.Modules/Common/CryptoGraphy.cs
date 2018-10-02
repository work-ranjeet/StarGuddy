using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace StarGuddy.Business.Modules.Common
{
    public class CryptoGraphy
    {
        #region /// Variables
        private const int pbkdf2IterCount = 10000;
        private const int pbkdf2SubkeyLength = 256 / 8; // 256 bits
        private const int saltSize = 128 / 8; // 128 bits 
        #endregion

        private static byte[] EncryptionByte { get { return new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 }; } }


        #region /// Private methods
        public static string HashPasswordInternal(string password)
        {
            var salt = new byte[saltSize];
            var _rng = RandomNumberGenerator.Create();
            _rng.GetBytes(salt);

            var subkey = KeyDerivation.Pbkdf2(password, salt, KeyDerivationPrf.HMACSHA256, pbkdf2IterCount, pbkdf2SubkeyLength);

            var outputBytes = new byte[13 + salt.Length + subkey.Length];

            // Write format marker.
            outputBytes[0] = 0x01;

            // Write hashing algorithm version.
            WriteNetworkByteOrder(outputBytes, 1, (uint)KeyDerivationPrf.HMACSHA256);

            // Write iteration count of the algorithm.
            WriteNetworkByteOrder(outputBytes, 5, (uint)pbkdf2IterCount);

            // Write size of the salt.
            WriteNetworkByteOrder(outputBytes, 9, (uint)saltSize);

            // Write the salt.
            Buffer.BlockCopy(salt, 0, outputBytes, 13, salt.Length);

            // Write the SUBKEY.
            Buffer.BlockCopy(subkey, 0, outputBytes, 13 + saltSize, subkey.Length);

            return Convert.ToBase64String(outputBytes);
        }

        public static bool VerifyHashedPasswordInternal(string hashedPassword, string password)
        {
            try
            {
                var decodedHashedPassword = Convert.FromBase64String(hashedPassword);

                if (decodedHashedPassword.Length == 0)
                    return false;

                // Verify hashing format.
                if (decodedHashedPassword[0] != 0x01)
                    return false;

                // Read hashing algorithm version.
                var prf = (KeyDerivationPrf)ReadNetworkByteOrder(decodedHashedPassword, 1);

                // Read iteration count of the algorithm.
                var iterCount = (int)ReadNetworkByteOrder(decodedHashedPassword, 5);

                // Read size of the salt.
                var saltLength = (int)ReadNetworkByteOrder(decodedHashedPassword, 9);

                // Verify the salt size: >= 128 bits.
                if (saltLength < 128 / 8)
                    return false;

                // Read the salt.
                var salt = new byte[saltLength];
                Buffer.BlockCopy(decodedHashedPassword, 13, salt, 0, salt.Length);

                // Verify the SUBKEY length >= 128 bits.
                var subkeyLength = decodedHashedPassword.Length - 13 - salt.Length;
                if (subkeyLength < 128 / 8)
                    return false;

                // Read the SUBKEY.
                var expectedSubkey = new byte[subkeyLength];
                Buffer.BlockCopy(decodedHashedPassword, 13 + salt.Length, expectedSubkey, 0, expectedSubkey.Length);

                // Hash the given password and verify it against the expected SUBKEY.
                var actualSubkey = KeyDerivation.Pbkdf2(password, salt, prf, iterCount, subkeyLength);

                return ByteArraysEqual(actualSubkey, expectedSubkey);
            }
            catch
            {
                return false;
            }
        }

        private static uint ReadNetworkByteOrder(byte[] buffer, int offset)
        {
            return ((uint)(buffer[offset + 0]) << 24)
                | ((uint)(buffer[offset + 1]) << 16)
                | ((uint)(buffer[offset + 2]) << 8)
                | ((uint)(buffer[offset + 3]));
        }

        private static void WriteNetworkByteOrder(byte[] buffer, int offset, uint value)
        {
            buffer[offset + 0] = (byte)(value >> 24);
            buffer[offset + 1] = (byte)(value >> 16);
            buffer[offset + 2] = (byte)(value >> 8);
            buffer[offset + 3] = (byte)(value >> 0);
        }

        private static bool ByteArraysEqual(byte[] first, byte[] second)
        {
            if (ReferenceEquals(first, second))
            {
                return true;
            }

            if (first == null || second == null || first.Length != second.Length)
            {
                return false;
            }

            var areEqual = true;
            for (var counter = 0; counter < first.Length; counter++)
            {
                areEqual &= (first[counter] == second[counter]);
            }
            return areEqual;
        }
        #endregion

        #region /// Text Encryption
        public static async Task<string> EncryptText(string text, string securityStamp)
        {
            return await Task.Factory.StartNew(() =>
            {
                //if (string.IsNullOrEmpty(securityStamp))
                //{
                //    securityStamp = this._configuration.GetAppSettingValue(AppSettings.EncryptionKey);
                //}

                var clearBytes = Encoding.Unicode.GetBytes(text);
                using (var encryptor = Aes.Create())
                {
                    var rfc2898DeriveBytes = new Rfc2898DeriveBytes(securityStamp, EncryptionByte);
                    encryptor.Key = rfc2898DeriveBytes.GetBytes(32);
                    encryptor.IV = rfc2898DeriveBytes.GetBytes(16);

                    using (var memoryStream = new MemoryStream())
                    {
                        using (CryptoStream cs = new CryptoStream(memoryStream, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                        {
                            cs.Write(clearBytes, 0, clearBytes.Length);
                            cs.Close();
                        }

                        text = Convert.ToBase64String(memoryStream.ToArray());
                    }
                }

                return text;
            });
        }

        public static async Task<string> DecryptText(string encryptedText, string securityStamp)
        {
            return await Task.Factory.StartNew(() =>
            {
                //if (string.IsNullOrEmpty(securityStamp))
                //{
                //    securityStamp = this._configuration.GetAppSettingValue(AppSettings.EncryptionKey);
                //}

                encryptedText = encryptedText.Replace(" ", "+");

                var encryptionBytes = Convert.FromBase64String(encryptedText);
                using (Aes encryptor = Aes.Create())
                {
                    var rfc2898DeriveBytes = new Rfc2898DeriveBytes(securityStamp, EncryptionByte);
                    encryptor.Key = rfc2898DeriveBytes.GetBytes(32);
                    encryptor.IV = rfc2898DeriveBytes.GetBytes(16);

                    using (var memoryStream = new MemoryStream())
                    {
                        using (var cryptoStream = new CryptoStream(memoryStream, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                        {
                            cryptoStream.Write(encryptionBytes, 0, encryptionBytes.Length);
                            cryptoStream.Close();
                        }

                        encryptedText = Encoding.Unicode.GetString(memoryStream.ToArray());
                    }
                }

                return encryptedText;
            });
        }
        #endregion

        #region /// Object Encryption
        public static string EncryptObject(dynamic value)
        {
            using (var ms = new MemoryStream())
            {
                new BinaryFormatter().Serialize(ms, value);
                return Convert.ToBase64String(ms.ToArray());
            }

        }
        public static dynamic DecryptObject<T>(string base64String)
        {
            var bytes = Convert.FromBase64String(base64String);
            using (var ms = new MemoryStream(bytes, 0, bytes.Length))
            {
                ms.Write(bytes, 0, bytes.Length);
                ms.Position = 0;

                return (T)new BinaryFormatter().Deserialize(ms);
            }
        }
        #endregion
    }
}
