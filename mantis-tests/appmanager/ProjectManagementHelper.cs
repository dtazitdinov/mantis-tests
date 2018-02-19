using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace mantis_tests
{
    public class ProjectManagementHelper : HelperBase
    {
        public ProjectManagementHelper(ApplicationManager manager) : base(manager)
        {
        }

        public void Create(ProjectData project)
        {
            manager.ManagementMenu.GoToManageProjectPage();
            InitProjectCreation();
            FillForm(project);
            SubmitProjectCreation();
        }

        public void Remove(string name)
        {
            manager.ManagementMenu.GoToManageProjectPage();
            Open(name);
            InitDelete();
            ConfirmDelete();
        }

        public void CheckProjectPresent()
        {
            manager.ManagementMenu.GoToManageProjectPage();

            if (IsElementPresent(driver.FindElements(By.TagName("tbody"))[0], By.XPath("tr[1]")))
            {
                return;
            }

            ProjectData project = new ProjectData()
            {
                Name = "Project_" + TestBase.GenerateRandomNumber(1000),
                Status = "10",
                InheritGlobalCategories = true,
                ViewStatus = "10",
                Discription = "Discription"
            };

            Create(project);
        }

        public void Open(string name)
        {
            driver.FindElement(By.XPath($"//div[@class = 'table-responsive'][1]//tbody//a[.='{name}']")).Click();
        }

        public void InitProjectCreation()
        {
            //driver.FindElement(By.XPath("//button[.='Create New Project']")).Click();
            driver.FindElement(By.XPath("//form[@action='manage_proj_create_page.php']")).Click();
        }

        public void SubmitProjectCreation()
        {
            driver.FindElement(By.CssSelector("input.btn-primary")).Click();
        }

        public void InitDelete()
        {
            driver.FindElement(By.Id("project-delete-form")).Click();
        }

        public void ConfirmDelete()
        {
            driver.FindElement(By.XPath("//input[@type='submit']")).Click();
        }

        public void FillForm(ProjectData project)
        {
            Type(By.Id("project-name"), project.Name);
            driver.FindElement(By.XPath($"//select[@id = 'project-status']/option[@value = '{project.Status}']")).Click();

            if (!project.InheritGlobalCategories)
            {
                driver.FindElement(By.Id("project-inherit-global")).Click();     
                
            }

            driver.FindElement(By.XPath($"//select[@id = 'project-view-state']/option[@value = '{project.ViewStatus}']")).Click();
            Type(By.Id("project-description"), project.Discription);
        }

        public List<ProjectData> GetProjectList()
        {
            manager.ManagementMenu.GoToManageProjectPage();
            List<ProjectData> list = new List<ProjectData>();

            ICollection<IWebElement> elements = driver.FindElements(By.TagName("tbody"))[0].FindElements(By.TagName("tr"));

            foreach (IWebElement element in elements)
            {
                ICollection<IWebElement> columns = element.FindElements(By.TagName("td"));

                list.Add(new ProjectData()
                {
                    Name = columns.ElementAt(0).FindElement(By.TagName("a")).Text,
                    Status = columns.ElementAt(1).Text,
                    Enabled = IsElementPresent(columns.ElementAt(2), By.TagName("i")),
                    ViewStatus = columns.ElementAt(3).Text,
                    Discription = columns.ElementAt(4).Text
                });
            }
            return list;
        }
    }
}
