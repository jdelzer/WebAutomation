using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace DemoAutomation.ExtensionMethods
{
    public static class MouseActions
    {
        public static void ClickAndHold(this IWebElement element, IWebDriver driver)
        {
            Actions actions = new Actions(driver);

            actions.MoveToElement(element);
            actions.ClickAndHold();
            actions.Perform();
        }
    }
}