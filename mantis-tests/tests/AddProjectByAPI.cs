using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace mantis_tests
{   
    [TestFixture]
    public class AddProjectByAPI : TestBase
    {
        [Test]
        public void AddProjectTestAPI()
        {
            AccountData account = new AccountData()
            {
                Username = "administrator",
                Password = "password"
            };

            ProjectData project = new ProjectData()
            {
                Name = "Project_" + GenerateRandomNumber(1000),
                Status = "10",
                InheritGlobalCategories = true,
                ViewStatus = "10",
                Description = "Discription"
            };

            List<ProjectData> oldProjects = appManager.API.GetProjectList(account);

            appManager.API.CreateNewProject(account, project);

            List<ProjectData> newProjects = appManager.API.GetProjectList(account);

            oldProjects.Add(project);
            oldProjects.Sort();
            newProjects.Sort();
            Assert.AreEqual(oldProjects, newProjects);
        }
    }
}
