using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DemoAutomation.PageObjects.ShoppingDemoPages
{
    public abstract class SeleniumElement
    {
        protected IWebDriver Driver { get; }
        protected WebDriverWait Wait { get; }

        protected SeleniumElement(IWebDriver driver)
        {
            Driver = driver;
            Wait = new WebDriverWait(Driver, TimeSpan.FromMilliseconds(20000));
        }

        protected SeleniumElement(IWebDriver driver, double waitTimeSeconds)
        {
            Driver = driver;
            Wait = new WebDriverWait(Driver, TimeSpan.FromMilliseconds(waitTimeSeconds * 1000));
        }

        protected IWebElement GetElement(By locator)
        {
            var retry = 10;

            while (true)
            {
                try
                {
                    return Driver?.FindElement(locator);
                }
                catch (Exception)
                {
                    if (--retry <= 0)
                        return null;
                }
            }
        }

        protected List<IWebElement> GetElements(By locator)
        {
            var retry = 5;

            while (true)
            {
                try
                {
                    return Driver?.FindElements(locator).ToList();
                }
                catch (Exception)
                {
                    if (--retry <= 0)
                        return new List<IWebElement> { };
                }
            }
        }
    }
}