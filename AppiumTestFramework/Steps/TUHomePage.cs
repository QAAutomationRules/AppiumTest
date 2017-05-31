using AppiumAutomationFramework.Hooks;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Interfaces;
using OpenQA.Selenium.Appium.MultiTouch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace AppiumTestFramework.Steps
{
    [Binding]
    public sealed class TUHomePage
    {
        // For additional details on SpecFlow step definitions see http://go.specflow.org/doc-stepdef

        IWebDriver driver = ScenarioContext.Current.Get<IWebDriver>("IWebDriver");

        [Given(@"I go to the ""(.*)"" Home Page")]
        public void GivenIGoToTheHomePage(string url)
        {
            WebDriverSetup.Goto(url);
        }

        [When(@"I Tap the My Credit Score and Report button")]
        public void WhenITapTheMyCreditScoreAndReportButton()
        {
            IWebElement element = driver.FindElement(By.XPath("//span[contains(text(),'My Credit Score & Report')]"));

            //element.Click();

            TouchAction action = new TouchAction((IPerformsTouchActions)driver);
            action.Tap((IMobileElement<IWebElement>) element).Perform();
        }

        [Then(@"I am able to sign up to receive My Credit Score")]
        public void ThenIAmAbleToSignUpToReceiveMyCreditScore()
        {
            
        }

    }
}
