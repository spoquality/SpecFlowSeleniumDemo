using System.Collections.ObjectModel;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Selenium.Support
{
    public abstract class TestPage
    {
        public PageName Name { get; protected set; }
        protected ChromeDriver WebDriver;
        protected Collection<Locator> Locators;
        public string Url { get; protected set; }

        protected void Setup(ChromeDriver webDriver)
        {
            WebDriver = webDriver;
            Locators = InitializeLocators();
        }

        protected abstract Collection<Locator> InitializeLocators();

        public Locator GetLocator(Element element)
        {
            return Locators.FirstOrDefault(locator => locator.Element.Equals(element));
        }

        public virtual bool IsAt()
        {
            return WebDriver.Url.Equals(Url);
        }
    }
}
