using System;
using BoDi;
using Selenium.Pages;
using Selenium.Support;
using TechTalk.SpecFlow;

namespace SpecFlow.Hooks
{
    [Binding]
    public class WebDriverSupport : IDisposable
    {
        private readonly IObjectContainer objectContainer;
        private AutomationTestSite automationTestSite;
        private User user;

        public WebDriverSupport(IObjectContainer objectContainer)
        {
            this.objectContainer = objectContainer;
        }

        [BeforeScenario]
        public void InitializeWebDriver()
        {
            automationTestSite = new AutomationTestSite();
            user = new User();
            objectContainer.RegisterInstanceAs(automationTestSite);         
            objectContainer.RegisterInstanceAs(user);
        }

        [AfterScenario]
        public void Dispose()
        {
            automationTestSite?.Dispose();
        }

    }
}
