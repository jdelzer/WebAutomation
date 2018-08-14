using OpenQA.Selenium;

namespace DemoAutomation.PageObjects.ShoppingDemoPages
{
    public class AccessoriesPage : PageBase
    {
        public AccessoriesPage(IWebDriver driver) : base(driver)
        {
        }

        public IWebElement AccessoriesHeader => GetElement(By.ClassName("entry-title"));
    }
}