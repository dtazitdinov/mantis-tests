using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace mantis_tests.tests
{
    [TestFixture]
    public class AddProjectTests : TestBase
    {
        [Test]
        public void AddProjectTest()
        {
            AccountData account = new AccountData()
            {
                Username = "administrator",
                Password = "password"
            };

            ProjectData project = new ProjectData("First Project")
            {
                Status = "10",
                InheritGlobalCategories = false,
                Visibility = "10",
                Discription = "First Project discription"
            };
            
            //go to homepage;
            appManager.Auth.Login(account);
            //go to management
            //go to projectManagement

            appManager.ManagementMenu.GoToProjectMenu();

            List<ProjectData> oldProjects = appManager.ProjectManagement.GetProjectList();

            appManager.ProjectManagement.AddProject(project);
            List<ProjectData> newProjects = appManager.ProjectManagement.GetProjectList();

            oldProjects.Sort();
            newProjects.Sort();

            Assert.AreEqual(oldProjects, newProjects);

            /*appManager.Navigator.GoToGroupsPage();
            List<GroupData> oldGroups = appManager.Groups.GetGroupsList();

            appManager.Groups.Create(newGroup);

            Assert.AreEqual(oldGroups.Count + 1, appManager.Groups.GetGroupsCount());

            List<GroupData> newGroups = appManager.Groups.GetGroupsList();
            oldGroups.Add(newGroup);
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);*/
        }
    }
}
