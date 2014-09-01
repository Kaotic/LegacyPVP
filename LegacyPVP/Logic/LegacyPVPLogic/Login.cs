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
    }
}
