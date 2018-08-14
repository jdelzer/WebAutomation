using DemoAutomation.PageObjects.DemoQAPages;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Interactions;

namespace DemoAutomation.UITests.DemoQATests
{
    [TestClass]
    public class DragAndDropTest : TestBase
    {
        private DraggablePage drag;
        private Actions action;

        public DragAndDropTest()
        {
            drag = new DraggablePage(Driver);
            action = new Actions(Driver);
        }

        [TestMethod]
        public void DragAndDrop()
        {
            //Driver.Navigate().GoToUrl("http://demoqa.com/draggable/");

            //action.ClickAndHold(drag.DraggableBox);
            //action.DragAndDropToOffset(drag.DraggableBox, 200, 60).Perform();

            Driver.Navigate().GoToUrl("http://demoqa.com/droppable/");

            //action.DragAndDrop(drag.DroppableBox, drag.DroppableBoxLarge).Build().Perform();

            action.ClickAndHold(drag.DroppableBox).MoveToElement(drag.DroppableBoxLarge).Release(drag.DroppableBox).Perform();
        }
    }
}