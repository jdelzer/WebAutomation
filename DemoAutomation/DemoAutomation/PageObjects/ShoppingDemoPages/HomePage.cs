using OpenQA.Selenium;

namespace DemoAutomation.PageObjects.ShoppingDemoPages
{
    public class HomePage : PageBase
    {
        public HomePage(IWebDriver driver) : base(driver)
        {
        }

        public IWebElement BuyNowButton => GetElement(By.ClassName("buynow"));
    }
}