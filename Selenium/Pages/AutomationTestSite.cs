using System;
using System.Collections.ObjectModel;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using Selenium.Support;

namespace Selenium.Pages
{
    public class AutomationTestSite
    {
        public PageName PageName;
        public string BaseUrl;
        private ChromeDriver WebDriver;
        private Collection<TestPage> Pages;

        public AutomationTestSite()
        {
            WebDriver = new ChromeDriver();
            BaseUrl = "http://automationpractice.com/index.php";
            Pages = InitializePages();
        }

        private Collection<TestPage> InitializePages()
        {
            return new Collection<TestPage>
            {
				new HomePage(WebDriver),
				new SignInPage(WebDriver),
				new CreateAccountPage(WebDriver),
                new MyAccountPage(WebDriver)
            };
        }

        public void GoTo()
        {
            WebDriver.Navigate().GoToUrl(BaseUrl);
        }

        public bool PageLoaded()
        {
            try
            {
                var waitForDocumentReady = new WebDriverWait(WebDriver, TimeSpan.FromSeconds(10));
                waitForDocumentReady.Until((wdriver) =>
                    (WebDriver as IJavaScriptExecutor).ExecuteScript("return document.readyState").Equals("complete"));
                return true;
            }
            catch (TimeoutException timeoutException)
            {
                return false;
            }
        }

        public TestPage GetPage(PageName pageName)
        {
            return Pages.FirstOrDefault(page => page.Name.Equals(pageName));
        }

        public bool DoesElementExistOnPage(PageName pageName, Element element)
        {
            var locator = GetPage(pageName).GetLocator(element);
            try
            {
                WebDriver.FindElement(locator.FindBy);
            }
            catch (NoSuchElementException noSuchElementException)
            {
                return false;
            }
            return true;
        }

        public void ClickElementOnPage(PageName pageName, Element element)
        {
            var locator = GetPage(pageName).GetLocator(element);
            WebDriver.FindElement(locator.FindBy).Click();
            System.Threading.Thread.Sleep(5000);
        }

        public void EnterTextIntoInputField(PageName pageName, Element element, string text)
        {
            var locator = GetPage(pageName).GetLocator(element);
            WebDriver.FindElement(locator.FindBy).SendKeys(text);
        }

        public void SelectDropDownOption(PageName pageName, Element element, string optionToSelect)
        {
            var locator = GetPage(pageName).GetLocator(element);
            var selectOptionList = WebDriver.FindElement(locator.FindBy).FindElements(By.TagName("option"));
            foreach (IWebElement option in selectOptionList)
            {
                if (option.Text.Equals(optionToSelect))
                {
                    option.Click();
                    return;
                }
            }
            throw new InvalidSelectorException($"{element} option of {optionToSelect} not found");
        }

        public void Dispose()
        {
            WebDriver.Dispose();
        }
    }
}
