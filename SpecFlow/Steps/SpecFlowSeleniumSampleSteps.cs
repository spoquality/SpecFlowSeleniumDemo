using NUnit.Framework;
using Selenium.Pages;
using Selenium.Support;
using TechTalk.SpecFlow;

namespace SpecFlow.Steps
{
    [Binding]
    public class SpecFlowSeleniumSampleSteps
    {
        private AutomationTestSite automationTestSite;
        private User user;

        public SpecFlowSeleniumSampleSteps(AutomationTestSite automationTestSite, User user)
        {
            this.automationTestSite = automationTestSite;
            this.user = user;
        }

        [Given(@"I have navigated to my test site")]
        public void GivenIHaveNavigatedToMyTestSite()
        {
            automationTestSite.GoTo();
        }

        [Given(@"I have clicked the Sign In link")]
        public void GivenIHaveClickedTheSignInLink()
        {
            automationTestSite.ClickElementOnPage(PageName.Home, Element.SignInLink);
        }

        [Given(@"I have started the Create account process")]
        public void GivenIHaveStartedTheCreateAccountProcess()
        {
            GivenIHaveClickedTheSignInLink();
            WhenIEnterAnEmailAddress();
            WhenIClickTheCreateNewAccountButton();
        }

        [Given(@"I have already created a new user")]
        public void GivenIHaveAlreadyCreatedANewUser()
        {
            GivenIHaveStartedTheCreateAccountProcess();
            WhenIEnterTheMinimalInformationRequired();
            WhenIClickTheRegisterButton();
            automationTestSite.ClickElementOnPage(PageName.MyAccount, Element.SignOutLink);
        }

        [When(@"the Home page loads")]
        public void WhenTheHomePageLoads()
        {
            automationTestSite.PageLoaded();
        }

        [When(@"I click the Sign In link")]
        public void WhenIClickTheSignInLink()
        {
            automationTestSite.ClickElementOnPage(PageName.Home, Element.SignInLink);
        }

        [When(@"I enter an email address")]
        public void WhenIEnterAnEmailAddress()
        {
            automationTestSite.EnterTextIntoInputField(PageName.SignIn, Element.NewUserEmail, user.Email);
        }

        [When(@"I click the Create New Account button")]
        public void WhenIClickTheCreateNewAccountButton()
        {
            automationTestSite.ClickElementOnPage(PageName.SignIn, Element.CreateAnAccountButton);
        }

        [When(@"I enter the minimal information required")]
        public void WhenIEnterTheMinimalInformationRequired()
        {
            if (user.Title.Equals(Title.Mrs))
            {
                automationTestSite.ClickElementOnPage(PageName.CreateAccount, Element.MrsRadioButtonOption);
            }
            else
            {
                automationTestSite.ClickElementOnPage(PageName.CreateAccount, Element.MrRadioButtonOption);
            }
            automationTestSite.EnterTextIntoInputField(PageName.CreateAccount, Element.CustomerFirstName, user.FirstName);
            automationTestSite.EnterTextIntoInputField(PageName.CreateAccount, Element.CustomerLastName, user.LastName);
            automationTestSite.EnterTextIntoInputField(PageName.CreateAccount, Element.Password, user.Password);
            automationTestSite.EnterTextIntoInputField(PageName.CreateAccount, Element.AddressFirstName, user.FirstName);
            automationTestSite.EnterTextIntoInputField(PageName.CreateAccount, Element.AddressLastName, user.LastName);
            automationTestSite.EnterTextIntoInputField(PageName.CreateAccount, Element.Address, user.Address);
            automationTestSite.EnterTextIntoInputField(PageName.CreateAccount, Element.City, user.City);
            automationTestSite.SelectDropDownOption(PageName.CreateAccount, Element.State, user.State.ToString());
            automationTestSite.EnterTextIntoInputField(PageName.CreateAccount, Element.Zip, user.Zip);
            automationTestSite.EnterTextIntoInputField(PageName.CreateAccount, Element.MobilePhone, user.MobilePhone);
            automationTestSite.EnterTextIntoInputField(PageName.CreateAccount, Element.AddressAlias, user.AddressAlias);
        }

        [When(@"I click the Register button")]
        public void WhenIClickTheRegisterButton()
        {
            automationTestSite.ClickElementOnPage(PageName.CreateAccount, Element.RegisterButton);
        }

        [When(@"I enter my login information")]
        public void WhenIEnterMyLoginInformation()
        {
            WhenIClickTheSignInLink();
            automationTestSite.EnterTextIntoInputField(PageName.SignIn, Element.ExistingUserEmail, user.Email);
            automationTestSite.EnterTextIntoInputField(PageName.SignIn, Element.Password, user.Password);
        }

        [When(@"I click the Sign In button")]
        public void WhenIClickTheSignInButton()
        {
            automationTestSite.ClickElementOnPage(PageName.SignIn, Element.SignInButton);
        }

        [Then(@"the Sign In link appears on the Home page")]
        public void ThenTheSignInLinkAppearsOnTheHomePage()
        {
            Assert.IsTrue(automationTestSite.DoesElementExistOnPage(PageName.Home, Element.SignInLink));
        }

        [Then(@"I am taken to the Sign In page")]
        public void ThenIAmTakenToTheSignInPage()
        {
            var signInPage = (SignInPage)automationTestSite.GetPage(PageName.SignIn);
            Assert.IsTrue(signInPage.IsAt());
        }

        [Then(@"I am taken to the Create Account page")]
        public void ThenIAmTakenToTheCreateAccountPage()
        {
            var createAccountPage = (CreateAccountPage)automationTestSite.GetPage(PageName.CreateAccount);
            Assert.IsTrue(createAccountPage.IsAt());
        }

        [Then(@"my new user is successfully created")]
        public void ThenMyNewUserIsSuccessfullyCreated()
        {
            var myAccountPage = (MyAccountPage)automationTestSite.GetPage(PageName.MyAccount);
            Assert.IsTrue(myAccountPage.IsAt());
        }

        [Then(@"I successfully login to the site")]
        public void ThenISuccessfullyLoginToTheSite()
        {
            var myAccountPage = (MyAccountPage)automationTestSite.GetPage(PageName.MyAccount);
            Assert.IsTrue(myAccountPage.IsAt());
        }
    }
}
