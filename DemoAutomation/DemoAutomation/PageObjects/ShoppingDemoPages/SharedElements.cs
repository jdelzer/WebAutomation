using OpenQA.Selenium;
using System.Collections.Generic;
using System.Linq;

namespace DemoAutomation.PageObjects.ShoppingDemoPages
{
    public class SharedElements : PageBase
    {
        public SharedElements(IWebDriver driver) : base(driver)
        {
        }

        public IWebElement MyAccountLink => GetElement(By.ClassName("account_icon"));
        public IWebElement CheckoutLink => GetElement(By.ClassName("cart_icon"));
        public IWebElement CartCount => CheckoutLink.FindElement(By.ClassName("count"));

        public IWebElement ProductCategoryMenu => GetElement(By.Id("menu-item-33"));
        public IWebElement[] ProductCategories => ProductCategoryMenu.FindElements(By.TagName("li")).ToArray();

        public IWebElement AccessoriesMenuItem => GetElement(By.Id("menu-item-34"));

        public IWebElement SearchBar => GetElement(By.XPath("//input[contains(@class,'search')]"));
        public List<IWebElement> FooterItemGroup => GetElements(By.XPath("//ul[@class='group']/li"));
    }
}