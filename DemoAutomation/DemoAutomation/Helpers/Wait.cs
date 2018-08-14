using DemoAutomation.UITests;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace DemoAutomation.Helpers
{
    public class Wait : TestBase
    {
        private WebDriverWait wait { get; set; }

        public Wait()
        {
            wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(20));
        }

        public void PageToLoad()
        {
            wait.Until(x => (IJavaScriptExecutor)Driver)
                .ExecuteScript("return document.readyState")
                .Equals("complete");
        }
    }
}