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
    public class LoginHelper : HelperBase
    {
        public LoginHelper(ApplicationManager manager) : base(manager) { }

        public void Login(AccountData account)
        {
            if (LoggedIn())
            {
                if (LoggedIn(account))
                {
                    return;
                }
                Logout();
            }
            EnterUsername(account.Username);
            EnterPassword(account.Password);
        }

        public bool LoggedIn()
        {
            return IsElementPresent(By.CssSelector("span.user-info"));
        }

        public bool LoggedIn(AccountData account)
        {
            return LoggedIn()
                && GetLoggedUserName() == account.Username;
        }

        private string GetLoggedUserName()
        {
            return driver.FindElement(By.CssSelector("span.user-info")).Text;             
        }

        public void Logout()
        {
            if (IsElementPresent(By.CssSelector("span.user-info")))
            {
                driver.FindElement(By.CssSelector("span.user-info")).Click();
                driver.FindElement(By.CssSelector("i.fa-sign-out")).Click();
            }
        }

        public void EnterUsername(string username)
        {
            Type(By.Name("username"), username);
            driver.FindElement(By.XPath("//input[@type='submit']")).Click();
        }

        public void EnterPassword(string password)
        {
            Type(By.Name("password"), password);
            driver.FindElement(By.XPath("//input[@type='submit']")).Click();
        }
    }
}
