using OpenQA.Selenium;
using UiTests.services;

namespace UiTests.pages;

public class PaymentPage : BasePage
{ 
    private By _placeOrderButtonLocator = By.CssSelector(".action.primary.checkout");
    private By _continueButtonLocator = By.CssSelector(".action.primary.continue");
    private By _orderNumberLinkLocator = By.CssSelector(".order-number");
    
    public PaymentPage(IWebDriver driver, WaitService waitService) : base(driver, waitService)
    {
    }

    public PaymentPage ClickPlaceOrderButton()
    {
        var placeOrderButton = waitService.waitForVisability(_placeOrderButtonLocator);
        IJavaScriptExecutor jsExecutor = (IJavaScriptExecutor)driver;
        jsExecutor.ExecuteScript("arguments[0].click();", placeOrderButton);
        return this;
    }

    public HomePage ClickContinueButton()
    {
        orderNumber = driver.FindElement(_orderNumberLinkLocator).Text;
        waitService.waitForVisability(_continueButtonLocator).Click();
        return new HomePage(driver, waitService);
    }
}