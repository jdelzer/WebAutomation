using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Diagnostics;
using System.IO;
using System.Management.Automation;
using System.Reflection;

namespace DemoAutomation
{
    /// <summary>
    /// Selenium base class
    /// </summary>
    public sealed class Browser
    {
        internal IWebDriver Driver { get; set; }

        private bool DirectorySet { get; set; }

        /// <summary>
        /// Setup and initalize browser
        /// </summary>
        public void Initialize()
        {
            SetupChrome();
        }

        private void SetupChrome()
        {
            //Setup browser
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("--disable-extensions");
            options.AddArgument("--disable-notifications");
            options.AddArgument("start-maximized");
            options.AddArgument("no-sandbox");
            options.AddUserProfilePreference("credentials_enable_service", false);
            options.AddUserProfilePreference("profile.password_manager_enabled", false);
            options.SetLoggingPreference("browser", LogLevel.All);
            options.SetLoggingPreference("driver", LogLevel.All);

            Driver = new ChromeDriver(options);
        }

        /// <summary>
        /// Dispose driver
        /// </summary>
        public void Teardown()
        {
            try
            {
                Driver?.Quit();
                Driver?.Dispose();
                RunPowershellScript("Cleanup\\Scripts\\StopDriverProcesses.ps1");
            }
            catch (Exception)
            {
                //Ignore if browser has already been closed
            }
        }

        /// <summary>
        /// Run Powershell script
        /// </summary>
        /// <param name="scriptPath"></param>
        public void RunPowershellScript(string scriptPath)
        {
            using (PowerShell pshell = PowerShell.Create())
            {
                string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                pshell.AddScript($"{path}\\{scriptPath}");
                pshell.Invoke();
            }
        }

        /// <summary>
        /// Take screenshot and save to bin folder
        /// </summary>
        public void TakeScreenShot()
        {
            SetScreenShotDirectory();
            try
            {
                var ssdriver = Driver as ITakesScreenshot;
                var screenshot = ssdriver.GetScreenshot();
                string file = $"snapShot_{DateTime.Now:dd_MMMM_hh_mm_ss_tt}.png";
                screenshot.SaveAsFile(file, ScreenshotImageFormat.Png);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
            }

            ResetDirectory();
        }

        private void SetScreenShotDirectory()
        {
            if (!DirectorySet)
            {
                //Create and set directory to save screenshots
                Directory.GetCurrentDirectory();
                if (!Directory.Exists("Screenshots"))
                {
                    Directory.CreateDirectory("Screenshots");
                }
                Directory.SetCurrentDirectory("Screenshots");
            }

            DirectorySet = true;
        }

        private void ResetDirectory()
        {
            if (DirectorySet)
            {
                Directory.SetCurrentDirectory(AppDomain.CurrentDomain.BaseDirectory);
            }

            DirectorySet = false;
        }
    }
}