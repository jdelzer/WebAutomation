using OpenQA.Selenium;

namespace DemoAutomation.PageObjects.ShoppingDemoPages
{
    public class PageBase : SeleniumElement
    {
        protected PageBase(IWebDriver driver) : base(driver)
        {
        }

        public void WaitForPage()
        {
            Wait.Until(x => ((IJavaScriptExecutor)Driver).ExecuteScript("return document.readyState").Equals("complete"));
        }
    }
}