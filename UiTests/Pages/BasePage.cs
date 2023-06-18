using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using UiTests.services;

namespace UiTests.pages;

public class BasePage
{
    protected IWebDriver driver;
    protected WaitService waitService;
    public static string orderNumber;

    public BasePage(IWebDriver driver, WaitService waitService)
    {
        this.driver = driver;
        this.waitService = waitService;
    }
    
    public void openPageByUrl(String pagePath) {
        driver.Navigate().GoToUrl(ConfigurationManager.AppSetting["baseURL"] + pagePath);
    }
}