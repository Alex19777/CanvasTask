using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using UiTests.Configurations;

namespace UiTests;

public class BrowserFactory
{
    private IWebDriver _driver;

    public IWebDriver GetDriver() {
        if (_driver == null)
        {
            _driver = CreateDriver();

            _driver.Navigate().GoToUrl(ConfigManager.BindConfiguration<BrowserConfiguration>().baseURL);
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(ConfigManager.BindConfiguration<BrowserConfiguration>().SmallWait);
            _driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(ConfigManager.BindConfiguration<BrowserConfiguration>().MediumWait);
        }

        return _driver;
    }

    public IWebDriver CreateDriver()
    {
        switch (ConfigManager.BindConfiguration<BrowserConfiguration>().browser)
        {
            case "chrome":
                var chromeOptions = new ChromeOptions();
                chromeOptions.AddArgument("headless");
                chromeOptions.AddArguments("--start-maximized");
                return new ChromeDriver();
                
            default:
                throw new NotSupportedException(
                    $"Browser '{ConfigManager.BindConfiguration<BrowserConfiguration>().browser}' is not supported.");
        }
    }
}