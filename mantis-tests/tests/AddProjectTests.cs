using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace mantis_tests
{
    [TestFixture]
    public class AddProjectTests : AuthTestBase
    {
        [Test]
        public void AddProjectTest()
        {
            ProjectData project = new ProjectData()
            {
                Name = "Project_" + GenerateRandomNumber(1000),
                Status = "10",
                InheritGlobalCategories = true,
                ViewStatus = "10",
                Discription = "Discription"
            };

            List<ProjectData> oldProjects = appManager.ProjectManagement.GetProjectList();

            appManager.ProjectManagement.Create(project);

            List<ProjectData> newProjects = appManager.ProjectManagement.GetProjectList();

            oldProjects.Add(project);
            oldProjects.Sort();
            newProjects.Sort();
            Assert.AreEqual(oldProjects, newProjects);
        }
    }
}
