using System.Collections.ObjectModel;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Selenium.Support;

namespace Selenium.Pages
{
    public class MyAccountPage : TestPage
    {
        public MyAccountPage(ChromeDriver webDriver)
        {
            Setup(webDriver);
            Name = PageName.MyAccount;
            Url = "http://automationpractice.com/index.php?controller=my-account";
        }

        protected sealed override Collection<Locator> InitializeLocators()
        {
            return new Collection<Locator>
            {
                new Locator(Element.SignOutLink, By.LinkText("Sign out"))
            };
        }
    }
}
