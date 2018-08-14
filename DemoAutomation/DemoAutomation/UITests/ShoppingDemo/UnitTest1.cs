using DemoAutomation.ExtensionMethods;
using DemoAutomation.PageObjects.ShoppingDemoPages;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System.Linq;

namespace DemoAutomation.UITests
{
    [TestClass]
    public class UnitTest1 : TestBase
    {
        private HomePage HomePage;
        private SharedElements Page;
        private AccessoriesPage AccessoriesPage;
        private IJavaScriptExecutor JSDriver;
        private SearchResultsPage SearchResultsPage;
        private ProductPage productPage;

        [TestInitialize]
        public void TestInitalize()
        {
            HomePage = new HomePage(Driver);
            Page = new SharedElements(Driver);
            AccessoriesPage = new AccessoriesPage(Driver);
            JSDriver = (IJavaScriptExecutor)Driver;
            SearchResultsPage = new SearchResultsPage(Driver);
            productPage = new ProductPage(Driver);
        }

        [TestCleanup]
        public void TestCleanup()
        {
        }

        [TestMethod]
        public void TestMethod1()
        {
            Driver.Navigate().GoToUrl("http://store.demoqa.com/");

            Assert.IsTrue(Page.MyAccountLink.Displayed);

            Assert.IsTrue(Page.CartCount.Text.Trim() == "0");

            Assert.IsTrue(Page.ProductCategories.Length == 6);

            Page.ProductCategoryMenu.ClickAndHold(Driver);

            Page.AccessoriesMenuItem.Click();

            Assert.AreEqual("Accessories", AccessoriesPage.AccessoriesHeader.Text);

            //HomePage.BuyNowButton.Click();
        }

        //[TestMethod]
        //public void HighlightExample()
        //{
        //    Driver.Navigate().GoToUrl("http://store.demoqa.com/");
        //    HighlightElement(Page.MyAccountLink);
        //}

        //private void HighlightElement(IWebElement Element, int Duration = 3)
        //{
        //    string OriginalStyle = Element.GetAttribute("style");

        //    JSDriver.ExecuteScript("arguments[0].setAttribute(arguments[1], arguments[2])",
        //        Element,
        //        "style",
        //        "border: 2px solid red; border-style: dashed;");

        //    Thread.Sleep(Duration * 1000);
        //    JSDriver.ExecuteScript("arguments[0].setAttribute(arguments[1], arguments[2])",
        //        Element,
        //        "style",
        //        OriginalStyle);
        //}

        [TestMethod]
        public void Search_ReturnsCorrectProducts()
        {
            string searchText = "iPad";

            Driver.Navigate().GoToUrl("http://store.demoqa.com/");

            Page.SearchBar.SendKeys(searchText);

            Page.SearchBar.SendKeys(Keys.Enter);

            var count = SearchResultsPage.ResultsGroup.Count;

            var result = SearchResultsPage.ResultsGroup.FindAll(x => x.Text.Contains(searchText));

            //  Assert.AreEqual(3, count, $"Expected 3 items but got {count}");
            Assert.IsTrue(result.Count == 2, $"Expected 2 items but got {result.Count}");
        }

        [TestMethod]
        public void FooterItems_NavigateToCorrectItem()
        {
            Driver.Navigate().GoToUrl("http://store.demoqa.com/");

            var itemToClickOn = Page.FooterItemGroup.First().FindElement(By.TagName("a"));

            string itemText = itemToClickOn.Text;

            itemToClickOn.Click();

            Assert.IsTrue(productPage.ProductTitle.Text.Contains(itemText.TrimEnd('.')),
                $"Expected {itemText.TrimEnd('.')} but was {productPage.ProductTitle.Text}");
        }
    }
}