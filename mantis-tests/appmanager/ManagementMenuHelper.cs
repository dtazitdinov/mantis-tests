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
    public class ManagementMenuHelper :HelperBase
    {
        public string baseURL;

        public ManagementMenuHelper(ApplicationManager manager, string baseURL) : base(manager)
        {
            this.baseURL = baseURL;
        }

        public void GoToManageProjectPage()
        {
            driver.Navigate().GoToUrl(baseURL + ":8080/mantisbt-2.11.1/manage_proj_page.php");
        }

        public void GoToMyWiewPage()
        {
            if (driver.Url == baseURL + ":8080/mantisbt-2.11.1/my_view_page.php")
            {
                return;
            }
            driver.Navigate().GoToUrl(baseURL + ":8080/mantisbt-2.11.1/my_view_page.php");
        }
    }
}
