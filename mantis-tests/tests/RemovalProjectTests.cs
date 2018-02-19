using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace mantis_tests
{
    [TestFixture]
    public class RemovalProjectTests : AuthTestBase
    {
        [Test]
        public void RemovalProjectTest()
        {
            appManager.ProjectManagement.CheckProjectPresent();
            List<ProjectData> oldProjects = appManager.ProjectManagement.GetProjectList();

            ProjectData toBeRemoved = oldProjects[0];
            appManager.ProjectManagement.Remove(toBeRemoved.Name);

            List<ProjectData> newProjects = appManager.ProjectManagement.GetProjectList();
            oldProjects.RemoveAt(0);
            oldProjects.Sort();
            newProjects.Sort();
            Assert.AreEqual(oldProjects, newProjects);

            foreach (ProjectData project in newProjects)
            {
                Assert.AreNotEqual(project.Name, toBeRemoved.Name);
            }
        }

    }
}
