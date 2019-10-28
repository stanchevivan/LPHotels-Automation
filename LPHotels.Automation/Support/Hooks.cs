using System;
using Fourth.Automation.Framework.Core;
using Fourth.Automation.Framework.Mobile.Resolvers;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace LPHotels.Automation.Support
{
    [Binding]
    public class Hooks
    {
        private IWebDriver driver;
        private ScenarioContext scenarioContext;

        public Hooks(IWebDriver driver, ScenarioContext scenarioContext)
        {
            this.driver = driver;
            this.scenarioContext = scenarioContext;
        }

        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            DriverFactory.Resolvers.Add(new AndroidResolver());
            DriverFactory.Resolvers.Add(new IOSResolver());
        }

        [AfterScenario]
        public void AfterScenario()
        {
            driver.Quit();
        }
    }
}
