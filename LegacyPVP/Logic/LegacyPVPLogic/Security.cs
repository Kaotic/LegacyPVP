using System;
using System.Collections.Generic;
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
        
    }
}
