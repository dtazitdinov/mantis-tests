﻿using System;
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

        internal void Remove(string name)
        {
            manager.ManagementMenu.GoToManageProjectPage();
            Open(name);
            InitDelete();
            ConfirmDelete();
        }

        internal void CheckProjectPresent()
        {
            if (IsElementPresent(driver.FindElements(By.CssSelector("div.table-responsive"))[1], By.XPath("//tbody/tr[1]")))
            {
                return;
            }

            ProjectData project = new ProjectData()
            {
                Name = "Project_" + TestBase.GenerateRandomNumber(1000),
                Status = "development",
                InheritGlobalCategories = true,
                ViewStatus = "public",
                Discription = "Discription"
            };

            Create(project);
        }

        private void Open(string name)
        {
            driver.FindElement(By.XPath($"//div[@class = 'table-responsive'][1]//tbody//a[.='{name}']")).Click();
        }

        public void InitProjectCreation()
        {
            driver.FindElement(By.XPath("//button[.='Create New Project']")).Click();
        }

        private void SubmitProjectCreation()
        {
            driver.FindElement(By.XPath("//input[@value='Add Project']")).Click();
        }

        private void InitDelete()
        {
            driver.FindElement(By.Id("project-delete-form")).Click();
        }

        private void ConfirmDelete()
        {
            driver.FindElement(By.XPath("//input[@type='submit']")).Click();
        }

        private void FillForm(ProjectData project)
        {
            Type(By.Id("project-name"), project.Name);
            driver.FindElement(By.XPath($"//select[@id = 'project-status']/option[.='{project.Status}']")).Click();

            if (!project.InheritGlobalCategories)
            {
                driver.FindElement(By.Id("project-inherit-global")).Click();
            }

            driver.FindElement(By.XPath($"//select[@id = 'project-view-state']/option[.='{project.ViewStatus}']")).Click();
            Type(By.Id("project-description"), project.Discription);
        }

        public List<ProjectData> GetProjectList()
        {
            manager.ManagementMenu.GoToManageProjectPage();
            List<ProjectData> list = new List<ProjectData>();

            ICollection<IWebElement> elements = driver
                .FindElements(By.CssSelector("div.table-responsive"))[1]
                .FindElements(By.XPath("//tbody/tr"));

            foreach (IWebElement element in elements)
            {
                ICollection<IWebElement> columns = element.FindElements(By.TagName("td"));

                list.Add(new ProjectData()
                {
                    Name = columns.ElementAt(1).FindElement(By.TagName("a")).Text,
                    Status = columns.ElementAt(2).Text,
                    Enabled = IsElementPresent(columns.ElementAt(3), By.TagName("i")),
                    ViewStatus = columns.ElementAt(4).Text,
                    Discription = columns.ElementAt(5).Text
                });
            }
            return list;
        }
    }
}
