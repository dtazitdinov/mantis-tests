using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using System.Net.FtpClient;
using System.IO;

namespace mantis_tests
{
    public class FtpHelper : HelperBase
    {
        private FtpClient client;
        public FtpHelper(ApplicationManager manager) : base(manager)
        {
            client = new FtpClient();
            client.Credentials = new System.Net.NetworkCredential("mantis", "mantis");
            client.Connect();
        }

        public void BackupFile(String path)
        {
            String backupPath = path + ".bak";
            if (File.Exists(backupPath))
            {
                return;
            }
            client.Rename(path, backupPath);

        }

        public void RestoreBackupFile(String path)
        {
            String backupPath = path + ".bak";
        }

        public void Upload(String path, Stream localFile)
        {

        }
    }
}
