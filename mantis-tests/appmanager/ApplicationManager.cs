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

        public RegistrationHelper Registration { get; set; }
        public FtpHelper Ftp { get; set; }
        public JamesHelper James { get; set; }
        public ProjectManagementHelper ProjectManagement { get; set; }
        public ManagementMenuHelper ManagementMenu { get; set; }
        public LoginHelper Auth { get; set; }        

        protected string baseURL;

        private static ThreadLocal<ApplicationManager> appManager = new ThreadLocal<ApplicationManager>();

        private ApplicationManager()
        {
            FirefoxOptions options = new FirefoxOptions();
            options.BrowserExecutableLocation = @"c:\Program Files\Mozilla Firefox\firefox.exe";
            //options.BrowserExecutableLocation = @"c:\Program Files (x86)\Mozilla Firefox ESR\firefox.exe";
            options.UseLegacyImplementation = true;
            driver = new FirefoxDriver(options);
            //driver = new FirefoxDriver();
            baseURL = "http://localhost";
            verificationErrors = new StringBuilder();

            Registration = new RegistrationHelper(this);
            Ftp = new FtpHelper(this);
            James = new JamesHelper(this);
            ProjectManagement = new ProjectManagementHelper(this);
            ManagementMenu = new ManagementMenuHelper(this, baseURL);
            Auth = new LoginHelper(this);
        }

        public static ApplicationManager GetThreadInstance()
        {
            if (! appManager.IsValueCreated)
            {
                ApplicationManager newInstance = new ApplicationManager();
                newInstance.driver.Url = @"http://localhost/mantisbt-2.11.1/login_page.php";
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
