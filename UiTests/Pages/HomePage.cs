using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using UiTests.services;

namespace UiTests.pages;

public class HomePage : BasePage
{
    private Actions _action;

	private readonly By _salesAndMarketingItemLocator = By.XPath("//a[text() = 'Sales & Marketing']");
	private readonly By _reportsAndSettingItemLocator = By.XPath("//a[text() = 'Reports & Settings']");
	private readonly By _contactsItemLocator =
        By.XPath("//a[text() = 'Contacts']");
	private readonly By _activityLogItemLocator = By.XPath("//*[text( )= 'Activity Log']");

	public HomePage(IWebDriver driver, WaitService waitService) : base(driver, waitService)
    {
        _action = new Actions(driver);
    }

    public ContactsPage NavigateToContacts()
    {
        waitService.waitForVisability(_salesAndMarketingItemLocator).Click();
        waitService.waitForVisability(_contactsItemLocator).Click();
        return new ContactsPage(driver, waitService);
    }

	public ReportsPage NavigateToReports()
	{
		waitService.waitForVisability(_reportsAndSettingItemLocator).Click();
		return new ReportsPage(driver, waitService);
	}

	public void NavigateToActivityLog()
	{
		_action.MoveToElement(waitService.waitForVisability(_reportsAndSettingItemLocator)).Click().Build().Perform();
		waitService.waitForClickable(_activityLogItemLocator).Click();
	}
}