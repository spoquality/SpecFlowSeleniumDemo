using System.Collections.ObjectModel;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Selenium.Support;

namespace Selenium.Pages
{
    public class SignInPage : TestPage
    {
     
        public SignInPage(ChromeDriver webDriver)
        {
            Setup(webDriver);
            Name = PageName.SignIn;
            Url = "http://automationpractice.com/index.php?controller=authentication&back=my-account";
        }

        protected sealed override Collection<Locator> InitializeLocators()
        {
            return new Collection<Locator>
            {
                new Locator(Element.SignInButton, By.Id("SubmitLogin")),
                new Locator(Element.NewUserEmail, By.Name("email_create")),
                new Locator(Element.CreateAnAccountButton, By.Id("SubmitCreate")),
                new Locator(Element.ExistingUserEmail, By.Id("email")),
                new Locator(Element.Password, By.Id("passwd"))
            };
        }    
    }
}
