using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace mantis_tests
{
    public class RegistrationHelper : HelperBase
    {
        private string baseUrl;

        public RegistrationHelper(ApplicationManager manager, string baseUrl) : base(manager)
        {
            this.baseUrl = baseUrl;
        }

        internal void Register(AccountData account)
        {
            OpenMainPage();
            OpenRegistrationForm();
            FillRegistrationForm(account);
            SubmitRegistration();
        }

        private void OpenRegistrationForm()
        {
            //driver.FindElement(By.ClassName("toolbar center")).FindElement(By.TagName("a")).Click();
            driver.FindElement(By.XPath("//div[@class='toolbar center']/a")).Click();
        }

        private void SubmitRegistration()
        {
            manager.driver.FindElement(By.XPath("//input[@type='submit']")).Click();
        }

        private void FillRegistrationForm(AccountData account)
        {
            Type(By.Id("username"), account.Username);
            Type(By.Id("email-field"), account.Email);
        }

        private void OpenMainPage()
        {
            manager.driver.Url = baseUrl + "/login_page.php";
        }
    }
}
