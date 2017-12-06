using OpenQA.Selenium;

namespace Selenium.Support
{
    public class Locator
    {
        public Element Element { get; private set; }
        public By FindBy { get; private set; }

        public Locator(Element element, By findBy)
        {
            Element = element;
            FindBy = findBy;
        }
    }
}
