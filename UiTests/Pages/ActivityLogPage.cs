using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using UiTests.services;

namespace UiTests.pages;

public class ActivityLogPage : BasePage
{
	private Actions _actions;
	private readonly By _activeCheckboxLocator = By.XPath("//*[@name = 'mass[]']");
	private readonly By _actionsButtonLocator = By.XPath("//*[@class = 'listHead']/preceding::*[@class = 'uii uii-gear']");
	private readonly By _deleteItemLocator = By.XPath("//*[text() = 'Delete']");
	private readonly By _textItemsLocator = By.XPath("//*[@class = 'detailLink']//a");
	private readonly By _loadingWindowLocator = By.XPath("//*[text() = 'Loading ...']");
	private IList<IWebElement> _activeItemsCollection = new List<IWebElement>();
	private IList<string> _beforeDeletingItemsCollection = new List<string>();


	public ActivityLogPage(IWebDriver driver, WaitService waitService) : base(driver, waitService)
	{
		_actions = new Actions(driver);
	}

	public void CheckActiveItem()
	{
		waitService.waitForInvisability(_loadingWindowLocator);
		_activeItemsCollection = driver.FindElements(_activeCheckboxLocator).Take(3).ToList();
		_beforeDeletingItemsCollection = driver.FindElements(_textItemsLocator).Select(el => el.Text).Take(3).ToList();

		_activeItemsCollection.ToList().ForEach(el => el.Click());
	}

	public void DeleteItems()
	{
		_actions.MoveToElement(waitService.waitForVisability(_actionsButtonLocator)).Click().Build().Perform();
		waitService.waitForExists(_deleteItemLocator).Click();
		var alert = driver.SwitchTo().Alert;
		alert.Invoke().Accept();
	}

	public IList<string> GetItemsAfterDeleting()
	{
		waitService.waitForInvisability(_loadingWindowLocator);
		return driver.FindElements(_textItemsLocator).Select(el => el.Text).Take(3).ToList();
	}

	public IList<string> GetItemsBeforeDeleting()
	{
		return _beforeDeletingItemsCollection;
	}
}