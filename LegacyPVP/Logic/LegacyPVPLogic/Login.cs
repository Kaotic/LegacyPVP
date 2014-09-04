using LegacyPVP.Pages;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegacyPVP.Logic.LegacyPVPLogic
{
    public class Login
    {
        /// <summary>
        /// Use this to check if a player has created a LegacyLogin Account
        /// </summary>
        internal static void GetPreviousAccounts()
        {
            if(!Directory.Exists(Path.Combine(Client.ExecutingDirectory, "Login")))
            {
                PageLogic.PageLogic.SwichMaserPage<CreateAccountPage>();
            }
            else
            {
                PageLogic.PageLogic.SwichMaserPage<LoginToAccountPage>();
            }
        }

        /// <summary>
        /// Use this to write stuff to a file
        /// </summary>
        /// <param name="Content">Content of the file</param>
        /// <param name="FileData">where do you want the file to go. This path does not have to exist</param>
        /// <param name="FileName">What do you want to name the file</param>
        internal static void CreateLoginFile(byte[] Content, string FileData, string FileName)
        {
            if (!Directory.Exists(FileData))
                Directory.CreateDirectory(FileData);
            var File = System.IO.File.Create(System.IO.Path.Combine(FileData, FileName));
            System.Text.ASCIIEncoding encoding = new System.Text.ASCIIEncoding();
            File.Write(Content, 0, Content.Length);
            File.Close();
        }

        /// <summary>
        /// Adds an account to LegacyPVP
        /// </summary>
        /// <param name="LOLLogin"></param>
        /// <param name="LOLPassword"></param>
        /// <param name="LOLIGN"></param>
        /// <param name="LOLRegion"></param>
        internal static void AddLolAccount(string LOLLogin, string LOLPassword, string LOLIGN, string LOLRegion)
        {
            //This account exists. No Need to add it again
            if (Directory.Exists(System.IO.Path.Combine(Client.ExecutingDirectory, "Login", LOLRegion, LOLIGN)))
                return;
            if (!Directory.Exists(System.IO.Path.Combine(Client.ExecutingDirectory, "Login", LOLRegion)))
                Directory.CreateDirectory(System.IO.Path.Combine(Client.ExecutingDirectory, "Login", LOLRegion));
            if (!Directory.Exists(System.IO.Path.Combine(Client.ExecutingDirectory, "Login", LOLRegion, LOLIGN)))
                Directory.CreateDirectory(System.IO.Path.Combine(Client.ExecutingDirectory, "Login", LOLRegion, LOLIGN));

            var User = System.IO.File.Create(System.IO.Path.Combine(Client.ExecutingDirectory, "Login", LOLRegion, LOLIGN, "Username.Encrypted"));
            var Pass = System.IO.File.Create(System.IO.Path.Combine(Client.ExecutingDirectory, "Login", LOLRegion, LOLIGN, "Password.Encrypted"));
            User.Close();
            Pass.Close();
            System.IO.StreamWriter Username = new System.IO.StreamWriter(System.IO.Path.Combine(Client.ExecutingDirectory, "Login", LOLRegion, LOLIGN, "Username.Encrypted"));
            Username.Write(Security.EncryptDes(LOLLogin, Client.Username, Client.Password));
            System.IO.StreamWriter Password = new System.IO.StreamWriter(System.IO.Path.Combine(Client.ExecutingDirectory, "Login", LOLRegion, LOLIGN, "Password.Encrypted"));
            Password.Write(Security.EncryptDes(LOLLogin, Client.Username, Client.Password));
            Username.Close();
            Password.Close();
        }
        internal static void DecryptLolAccounts(string Region, string PlayerIGN)
        {
            string UsernaneEncrypted = System.IO.File.ReadAllText(System.IO.Path.Combine(Client.ExecutingDirectory, "Login", Region, PlayerIGN, "Username.Encrypted"));
            string PasswordEncrypted = System.IO.File.ReadAllText(System.IO.Path.Combine(Client.ExecutingDirectory, "Login", Region, PlayerIGN, "Password.Encrypted"));
            string UsernameDecrypt = Security.DecryptDes(UsernaneEncrypted, Client.Username, Client.Password);
            string PasswordDecrypt = Security.DecryptDes(PasswordEncrypted, Client.Username, Client.Password);
            Logins LoginData = new Logins();
            LoginData.Username = UsernameDecrypt;
            LoginData.Password = PasswordDecrypt;
            LoginList.AccountData.Add(LoginData);
        }
    }
    public class LoginList
    {
        public static List<Logins> AccountData;
    }
    public class Logins
    {
        public String Username { get; set; }
        public String Password { get; set; }
    }
}
