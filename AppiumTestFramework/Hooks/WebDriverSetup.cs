using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using System;
using System.Configuration;
using System.IO;
using TechTalk.SpecFlow;

namespace AppiumAutomationFramework.Hooks
{
    internal class WebDriverSetup
    {
        protected static IWebDriver webDriver { get; set; }
        protected static WebDriverWait wait { get; set; }
        public void Before()
        {
            webDriver = GetWebDriver(ConfigurationManager.AppSettings["OS"]);

            ScenarioContext.Current.Add("IWebDriver", webDriver);
        }

        public void After()
        {

            // if the web driver instance exists, call quit on it
            if (webDriver != null)
            {
                webDriver.Close();
                webDriver.Quit();
            }

        }

        private static IWebDriver GetWebDriver(string OS)
        {

            switch (OS.ToLower())
            {
                case "android":

                    Console.WriteLine("Connecting to Appium server");
                    
                    DesiredCapabilities androidcapabilities = new DesiredCapabilities();
                    androidcapabilities.SetCapability("chromedriverExecutable", Path.Combine(GetBasePath, @"Drivers\chromedriver.exe"));
                    //androidcapabilities.SetCapability(CapabilityType.BrowserName, "Browser");
                    androidcapabilities.SetCapability(CapabilityType.BrowserName, "Chrome");
                    androidcapabilities.SetCapability(CapabilityType.Platform, "Android");
                    androidcapabilities.SetCapability(CapabilityType.Version, "7.0");
                    androidcapabilities.SetCapability("Device", "Android");
                    androidcapabilities.SetCapability("deviceName", "Android Emulator");
                    webDriver = new AndroidDriver<IWebElement>(new Uri("http://127.0.0.1:4723/wd/hub"), androidcapabilities);
                    wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(20));
                    break;

                default:
                    throw new ApplicationException("Invalid platform type for direct drivers");
            }
            if (webDriver == null)
                throw new Exception("Could not start local webdriver, please check your settings and try again");
            return webDriver;
        }

        public static string GetBasePath
        {
            get
            {
                var basePath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
                basePath = basePath.Substring(0, basePath.Length - 10);
                return basePath;
            }
        }

        public static void Goto(string url)
        {
            double initialTimeout = wait.Timeout.Seconds;
            wait.Timeout = TimeSpan.FromSeconds(120);
            webDriver.Navigate().GoToUrl(url);
            wait.Timeout = TimeSpan.FromSeconds(initialTimeout);
        }
    }
}