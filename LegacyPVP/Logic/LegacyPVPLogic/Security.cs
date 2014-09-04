using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace LegacyPVP.Logic.LegacyPVPLogic
{
    public class Security
    {
        /// <summary>
        /// Super Simple MD5 Encrypter
        /// </summary>
        /// <param name="inputBytes">What bytes do you want encrypted</param>
        /// <returns>Encrypted Text</returns>
        internal static Byte[] Encrypt(byte[] inputBytes)
        {
            MD5 md5 = System.Security.Cryptography.MD5.Create();
            return md5.ComputeHash(inputBytes);
        }

        /// <summary>
        /// Legacy PVP Login Service
        /// </summary>
        /// <param name="originalString"></param>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public static string EncryptDes(string originalString, string username, string password)
        {
            DESCryptoServiceProvider cryptoProvider = new DESCryptoServiceProvider();
            MemoryStream memoryStream = new MemoryStream();
            CryptoStream cryptoStream = new CryptoStream(memoryStream,
                cryptoProvider.CreateEncryptor(ASCIIEncoding.ASCII.GetBytes(username), ASCIIEncoding.ASCII.GetBytes(password)), CryptoStreamMode.Write);
            StreamWriter writer = new StreamWriter(cryptoStream);
            writer.Write(originalString);
            writer.Flush();
            cryptoStream.FlushFinalBlock();
            writer.Flush();
            return Convert.ToBase64String(memoryStream.GetBuffer(), 0, (int)memoryStream.Length);
        }

        /// <summary>
        /// Legacy PVP Login Service
        /// </summary>
        /// <param name="cryptedString"></param>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public static string DecryptDes(string cryptedString, string username, string password)
        {
            DESCryptoServiceProvider cryptoProvider = new DESCryptoServiceProvider();
            MemoryStream memoryStream = new MemoryStream
                    (Convert.FromBase64String(cryptedString));
            CryptoStream cryptoStream = new CryptoStream(memoryStream,
                cryptoProvider.CreateDecryptor(ASCIIEncoding.ASCII.GetBytes(username), ASCIIEncoding.ASCII.GetBytes(password)), CryptoStreamMode.Read);
            StreamReader reader = new StreamReader(cryptoStream);
            return reader.ReadToEnd();
        }
    }
}
