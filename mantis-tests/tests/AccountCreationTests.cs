using System;
using System.Text;
using System.Collections.Generic;
using NUnit.Framework;

namespace mantis_tests
{
    [TestFixture]
    public class AccountCreationTests : TestBase
    {
        [TestFixtureSetUp]
        public void setUpConfig()
        {
            appManager.Ftp.BackupFile("");
            appManager.Ftp.Upload("", null);
        }

        [Test]
        public void TestAccountRegistration()
        {
            AccountData account = new AccountData()
            {
                Name = "testUser",
                Password = "password",
                Email = "testuser@localhost:8080.localdomain"
            };
            appManager.Registration.Register(account);
        }

        [TestFixtureTearDown]
        public void RestoreConfig()
        {
            appManager.Ftp.RestoreBackupFile("");
        }
    }
}
