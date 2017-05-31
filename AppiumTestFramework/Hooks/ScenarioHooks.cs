
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace AppiumAutomationFramework.Hooks
{
    [Binding]
    public class ScenarioHooks
    {

        WebDriverSetup webdriverSetup = new WebDriverSetup();

        [BeforeScenario]
        public virtual void Before()
        {
            webdriverSetup.Before();

        }

        [AfterScenario]
        public virtual void After()
        {
            webdriverSetup.After();
        }
    }
}
