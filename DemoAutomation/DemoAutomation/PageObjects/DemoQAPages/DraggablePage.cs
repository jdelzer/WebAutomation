using DemoAutomation.PageObjects.ShoppingDemoPages;
using OpenQA.Selenium;

namespace DemoAutomation.PageObjects.DemoQAPages
{
    public class DraggablePage : PageBase
    {
        public DraggablePage(IWebDriver driver) : base(driver)
        {
        }

        public IWebElement DraggableBox => GetElement(By.Id("draggable"));

        public IWebElement DroppableBox => GetElement(By.Id("draggableview"));
        public IWebElement DroppableBoxLarge => GetElement(By.Id("droppableview"));
    }
}