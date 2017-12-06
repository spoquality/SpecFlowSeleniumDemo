using System.Collections.ObjectModel;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Selenium.Support;

namespace Selenium.Pages
{
    public class CreateAccountPage : TestPage
    {
        public CreateAccountPage(ChromeDriver webDriver)
        {
            Setup(webDriver);
            Name = PageName.CreateAccount;
            Url = "http://automationpractice.com/index.php?controller=authentication&back=my-account#account-creation";
        }

        protected sealed override Collection<Locator> InitializeLocators()
        {
            return new Collection<Locator>
            {
                new Locator(Element.MrsRadioButtonOption, By.Id("id_gender2")),
                new Locator(Element.CustomerFirstName, By.Id("customer_firstname")),
                new Locator(Element.CustomerLastName, By.Id("customer_lastname")),
                new Locator(Element.Email, By.Id("email")),
                new Locator(Element.Password, By.Id("passwd")),
                new Locator(Element.AddressFirstName, By.Id("firstname")),
                new Locator(Element.AddressLastName, By.Id("lastname")),
                new Locator(Element.Address, By.Id("address1")),
                new Locator(Element.City, By.Id("city")),
                new Locator(Element.State, By.Id("id_state")),
                new Locator(Element.Zip, By.Id("postcode")),
                new Locator(Element.Country, By.Id("id_country")),
                new Locator(Element.MobilePhone, By.Id("phone_mobile")),
                new Locator(Element.AddressAlias, By.Id("alias")),
                new Locator(Element.RegisterButton, By.Id("submitAccount"))
            };
        }
    }
}
