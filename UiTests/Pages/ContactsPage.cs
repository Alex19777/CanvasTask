using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using UiTests.services;

namespace UiTests.pages;

public class ContactsPage : BasePage
{
    private readonly By _createNewContactButtonLocator = By.XPath("//*[@name = 'SubPanel_create']");
    private readonly By _saveContactButtonLocator = By.Id("DetailForm_save2-label");
    private readonly By _roleItemLocator = By.Id("DetailFormbusiness_role-input-label");
    private readonly By _loadingWindowLocator = By.XPath("//*[text() = 'Loading ...']");
    private readonly By _categoryItemLocator = By.CssSelector("#DetailFormcategories-input");
    private readonly By _categoryItemOpenDropDownLocator = By.CssSelector(".input-field.select-list.rbullet.active.flat-bottom");
    private readonly By _categoryCustomersItemLocator = By.XPath("//*[contains(text(), 'Customers')]");
    private readonly By _categorySuppliersItemLocator = By.XPath("//*[contains(text(), 'Suppliers')]");
    private readonly By _roleCeoItemLocator = By.XPath("//*[contains(text(), 'CEO')]");
    private readonly By _firstNameInputLocator = By.Id("DetailFormfirst_name-input");
    private readonly By _lastNameInputLocator = By.Id("DetailFormlast_name-input");
    
    private Actions _actions;

    public ContactsPage(IWebDriver driver, WaitService waitService) : base(driver, waitService)
    {
        _actions = new Actions(driver);
    }

    public void AddContact(string name, string lastName)
    {
		waitService.retryingFindClick(_createNewContactButtonLocator);
		waitService.waitForInvisability(_loadingWindowLocator);
        waitService.waitForVisability(_firstNameInputLocator).SendKeys($"{name} {DateTime.Now.Millisecond}");
        waitService.waitForVisability(_lastNameInputLocator).SendKeys(lastName);
		waitService.waitForVisability(_categoryItemLocator).Click();
		_actions.MoveToElement(waitService.waitForVisability(_categoryCustomersItemLocator)).Click().Build().Perform();
        waitService.waitForInvisability(_categoryItemOpenDropDownLocator);
		waitService.waitForVisability(_categoryItemLocator).Click();
		_actions.MoveToElement(waitService.waitForVisability(_categorySuppliersItemLocator)).Click().Build().Perform();
        waitService.waitForClickable(_roleItemLocator).Click();
        waitService.waitForVisability(_roleCeoItemLocator).Click();
        waitService.waitForClickable(_saveContactButtonLocator).Click();
    }
}