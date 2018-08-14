using OpenQA.Selenium;
using System.Collections.Generic;
using System.Linq;

namespace DemoAutomation.PageObjects.ShoppingDemoPages
{
    public class SearchResultsPage : PageBase
    {
        public SearchResultsPage(IWebDriver driver) : base(driver)
        {
        }

        public List<IWebElement> ResultsGroup => GetElements(By.XPath("//div[@id='grid_view_products_page_container']/div/div")).ToList();
    }
}