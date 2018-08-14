using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;

namespace DemoAutomation.UITests
{
    [TestClass]
    public class TestBase
    {
        public static Browser Browser { get; private set; }
        public static IWebDriver Driver { get; private set; }

        [AssemblyInitialize]
        public static void AssemblyInitialize(TestContext context)
        {
            Browser = new Browser();
            Browser.Initialize();
            Driver = Browser.Driver;
        }

        [AssemblyCleanup]
        public static void AssemblyCleanup()
        {
            Browser.Teardown();
        }

        public virtual void Setup()
        {
        }

        public virtual void Cleanup()
        {
        }
    }
}