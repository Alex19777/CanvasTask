using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using UiTests.services;

namespace UiTests.pages;

public class ReportsPage : BasePage
{
	private readonly By _loadingWindowLocator = By.XPath("//*[text() = 'Loading ...']");
	private readonly By _reportInfoLocator = By.TagName("h4");
	private readonly By _runArchiveReportButtonLocator = By.Name("FilterForm_archiveButton");
    private readonly By _reportItemLocator = By.ClassName("listViewNameLink");
    private readonly By _searchFieldLocator = By.XPath("//div[@class= 'input-field input-field-group input-search filter']/child::input");

	private Actions _actions;

    public ReportsPage(IWebDriver driver, WaitService waitService) : base(driver, waitService)
    {
        _actions = new Actions(driver);
    }

    public void searchReport(string reportToSearch)
    {
        driver.FindElement(_searchFieldLocator).SendKeys(reportToSearch);
        _actions.SendKeys(Keys.Enter).Perform();

		driver.FindElement(_searchFieldLocator).Click();
    }

	public void runReport()
	{
		driver.FindElement(_reportItemLocator).Click();
		waitService.waitForInvisability(_loadingWindowLocator);
		driver.FindElement(_runArchiveReportButtonLocator).Click();
	}

	public string GetReportInformation()
	{
		waitService.waitForInvisability(_loadingWindowLocator);
		return waitService.waitForVisability(_reportInfoLocator).Text;
	}
}