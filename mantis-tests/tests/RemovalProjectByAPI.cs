using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace mantis_tests
{
    [TestFixture]
    public class RemovalProjectByAPI : TestBase
    {            
        [Test]
        public void RemovalProjectAPI()
        {
            AccountData account = new AccountData()
            {
                Username = "administrator",
                Password = "password"
            };

            appManager.API.CheckProjectPresent(account);

            List<ProjectData> oldProjects = appManager.API.GetProjectList(account);

            ProjectData toBeRemoved = oldProjects[0];
            appManager.API.DeleteProject(account,toBeRemoved.Id);

            List<ProjectData> newProjects = appManager.API.GetProjectList(account);
            oldProjects.RemoveAt(0);
            oldProjects.Sort();
            newProjects.Sort();
            Assert.AreEqual(oldProjects, newProjects);

            foreach (ProjectData project in newProjects)
            {
                Assert.AreNotEqual(project.Id, toBeRemoved.Id);
            }
        }
    }
}

