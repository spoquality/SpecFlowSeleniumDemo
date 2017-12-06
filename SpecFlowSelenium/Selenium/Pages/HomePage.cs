using System.Collections.ObjectModel;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Selenium.Support;

namespace Selenium.Pages
{
    public class HomePage : TestPage
    {
        public HomePage(ChromeDriver webDriver)
        {
            Setup(webDriver);
            Name = PageName.Home;
            Url = "http://automationpractice.com/index.php";
        }

        protected sealed override Collection<Locator> InitializeLocators()
        {
            return new Collection<Locator>
            {
                new Locator(Element.SignInLink, By.XPath("//*[@id=\"header\"]/div[2]/div/div/nav/div[1]/a"))
            };
        }

        
    }
}
