using OpenQA.Selenium;

namespace DemoAutomation.PageObjects.ShoppingDemoPages
{
    public class ProductPage : PageBase
    {
        public ProductPage(IWebDriver driver) : base(driver)
        {
        }

        public IWebElement ProductTitle => GetElement(By.ClassName("prodtitle"));
    }
}