using System;
using System.Text;
using System.Collections.Generic;
using NUnit.Framework;
using System.Net.FtpClient;
using System.IO;

namespace mantis_tests
{
    [TestFixture]
    public class AccountCreationTests : TestBase
    {
        [TestFixtureSetUp]
        public void setUpConfig()
        {
            appManager.Ftp.BackupFile(@"/config_inc.php");
            using (Stream localFile = File.Open(@"config_inc.php", FileMode.Open))
            {
                appManager.Ftp.Upload(@"/config_inc.php", localFile);
            }            
        }

        [Test]
        public void TestAccountRegistration()
        {
            AccountData account = new AccountData()
            {
                Username = "testUser",
                Password = "password",
                Email = "testuser@localhost.localdomain"
            };
            appManager.Registration.Register(account);
        }

        [TestFixtureTearDown]
        public void RestoreConfig()
        {
            appManager.Ftp.RestoreBackupFile(@"\config_inc.php");
        }
    }
}
