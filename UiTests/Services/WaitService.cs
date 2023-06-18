using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;

namespace UiTests.services;
using OpenQA.Selenium.Support.UI;

public class WaitService
{
    private IWebDriver _driver;
    private WebDriverWait wait;

    public WaitService(IWebDriver driver)
    {
        _driver = driver;
        this.wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(35));
    }

    public IWebElement waitForExists(By locator) {
        return wait.Until(ExpectedConditions.ElementExists(locator));
    }
    
    public IWebElement waitForClickable(By locator) {
        return wait.Until(ExpectedConditions.ElementToBeClickable(locator));
    }
    
    public IWebElement waitForVisability(By locator) {
        return wait.Until(ExpectedConditions.ElementIsVisible(locator));
    }
    
    public bool waitForInvisability(By locator) {
        return wait.Until(ExpectedConditions.InvisibilityOfElementLocated(locator));
    }

    public bool retryingFindClick(By by)
    {
        bool result = false;
        int attempts = 0;
        while (attempts < 5)
        {
            try
            {
                _driver.FindElement(by).Click();
                result = true;
                break;
            }
            catch (StaleElementReferenceException e)
            {
            }
            attempts++;
        }
        return result;
    }
}
