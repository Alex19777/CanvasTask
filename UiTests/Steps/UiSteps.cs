using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using UiTests.Builders;
using UiTests.Configurations;
using UiTests.pages;
using UiTests.services;

namespace UiTests.Steps;

    [Binding]
    public class UiSteps
    {
        private IWebDriver _driver;
        private WaitService _waitService;
        private LoginPage _loginPage;
        private HomePage _homePage;
        private ContactsPage _contactsPage;
        private ContactPage _contactPage;
        private ReportsPage _reportsPage;
        private ActivityLogPage _activityLogPage;

	public UiSteps(IWebDriver driver)
    {
        _driver = driver;
        _waitService = new WaitService(_driver);
        _loginPage = new LoginPage(_driver, _waitService);
        _homePage = new HomePage(_driver, _waitService);
        _contactsPage = new ContactsPage(_driver, _waitService);
		_reportsPage = new ReportsPage(_driver, _waitService);
		_contactPage = new ContactPage(_driver, _waitService);
		_activityLogPage = new ActivityLogPage(_driver, _waitService);
	}

    [Given(@"User Login to crmcloud")]
    public void GivenUserLoginToCrmcloud()
    {
        _loginPage
            .SwitchToTheme()
            .InputCredentials(ConfigManager.BindConfiguration<LoginDataConfiguration>().email,
                            ConfigManager.BindConfiguration<LoginDataConfiguration>().password)
            .ClickSingInButton();
    }
    
    [When(@"User Navigate to Contacts")]
    public void WhenUserNavigateToContacts()
    {
        _homePage.NavigateToContacts();
    }

	[When(@"User Navigate to Reports")]
	public void WhenUserNavigateToReports()
	{
		_homePage.NavigateToReports();
	}

	[When(@"User run report")]
	public void WhenUserRunReport()
	{
		_reportsPage.runReport();
	}

	[When(@"User search (.*) report")]
	public void WhenUserSearchProjectProfitabilityReport(string reportToSearch)
	{
        _reportsPage.searchReport(reportToSearch);
	}

	[Then(@"Validate report information")]
	public void ThenValidateReportInformation()
	{
        var actualInformation = _reportsPage.GetReportInformation();

        Assert.True(actualInformation.Contains(DateTime.Now.Date.ToString("yyyy-MM-dd")));
	}

	[When(@"User create new contact with first name (.*), lastName (.*)")]
    public void WhenUserCreateNewContactWithFirstNameLastName(string firstName, string lastName)
    {
        _contactsPage.AddContact(firstName, lastName);
    }
   
    [Then(@"Validate contact information")]
    public void ThenValidateContactInformation()
    {
        var expectedContact = new ContactBuilder()
            .WithFirstName("Tom")
            .WithLastName("Ford")
            .WithCategories("Customers", "Suppliers")
            .WithRole("CEO")
            .Build();

        var actualContact = _contactPage.GetContactInformation();

        Assert.AreEqual(expectedContact, actualContact);
    }

	[When(@"User Navigate to ActivityLog")]
	public void WhenUserNavigateToActivityLog()
	{
		_homePage.NavigateToActivityLog();
	}

	[When(@"Check recent activity and delete them")]
	public void WhenCheckRecentActivityAndDeleteThem()
	{
		_activityLogPage.CheckActiveItem();
		_activityLogPage.DeleteItems();
	}

	[Then(@"Validate deleted information")]
	public void ThenValidateDeletedInformation()
	{
		var beforeDeletingResult = _activityLogPage.GetItemsBeforeDeleting();
		var afterDeletingResult = _activityLogPage.GetItemsAfterDeleting();
		CollectionAssert.AreNotEqual(beforeDeletingResult, afterDeletingResult);
	}
}
