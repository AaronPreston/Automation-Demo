using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;

namespace Automation.Demo.API
{
    public static class Automation
    {
        public static ChromeDriver Init()
        {
            var chromeOptions = new ChromeOptions();
            chromeOptions.AddArgument("--log-level=3");
            chromeOptions.AddArgument("--silent");
            chromeOptions.AddArgument("--ignore-certificate-errors");
            chromeOptions.AddArgument("--disable-infobars");
            chromeOptions.AddExcludedArgument("enable-automation");
            chromeOptions.AddAdditionalCapability("useAutomationExtension", false);
            chromeOptions.AddArgument("headless");
            var chromeService = ChromeDriverService.CreateDefaultService();
            chromeService.SuppressInitialDiagnosticInformation = true;
            chromeService.HideCommandPromptWindow = true;
            var driver = new ChromeDriver(chromeService, chromeOptions);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);
            driver.Manage().Window.Size = new Size(1920, 1080);
            driver.Manage().Window.Position = new Point(0, 0);

            return driver;
        }
    }
}
