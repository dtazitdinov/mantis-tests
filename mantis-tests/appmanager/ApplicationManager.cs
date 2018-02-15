using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace mantis_tests
{
    public class ApplicationManager
    {
        public IWebDriver driver;
        private StringBuilder verificationErrors;

        public RegistrationHelper Registration { get; }

        protected string baseURL;

        private static ThreadLocal<ApplicationManager> appManager = new ThreadLocal<ApplicationManager>();

        private ApplicationManager()
        {
            /*FirefoxOptions options = new FirefoxOptions();
            //options.BrowserExecutableLocation = @"c:\Program Files\Mozilla Firefox\firefox.exe";
            options.BrowserExecutableLocation = @"c:\Program Files (x86)\Mozilla Firefox ESR\firefox.exe";
            options.UseLegacyImplementation = true;
            driver = new FirefoxDriver(options);*/
            driver = new FirefoxDriver();
            baseURL = "http://localhost";
            verificationErrors = new StringBuilder();
            Registration = new RegistrationHelper(this);

        }

        public static ApplicationManager GetThreadInstance()
        {
            if (! appManager.IsValueCreated)
            {
                ApplicationManager newInstance = new ApplicationManager();
                newInstance.driver.Url = @"http://localhost:8080/mantisbt-2.11.1/login_page.php";
                appManager.Value = newInstance;                
            }
            return appManager.Value;
        }

        ~ApplicationManager()
        {
            try
            {
                driver.Quit();
            }
            catch(Exception)
            {
                //Ignor errors if unable to close the browser
            }
        }

        public IWebDriver Driver
        {
            get => driver;
        }
    }
}
