using OpenQA.Selenium;
using UiTests.Builders;
using UiTests.models;
using UiTests.services;

namespace UiTests.pages;

public class ContactPage : BasePage
{
    private readonly By _categoriesLocator = By.XPath("//ul[@class = 'summary-list']/child::li[@class='']");
    private readonly By _contactFullNameLocator = By.TagName("h3");
    private readonly By _contactRoleLocator = By.XPath("//div[@class = 'column form-cell sm-6 cell-business_role span-1']/child::div[@class = 'form-entry label-left']/child::div[@class = 'form-value']");
    
    public ContactPage(IWebDriver driver, WaitService waitService) : base(driver, waitService) {}

    public ContactModel GetContactInformation()
    {
    	var contactModel = new ContactBuilder()
            .WithFirstName(waitService.waitForVisability(_contactFullNameLocator).Text.Trim().Split(' ').First())
            .WithLastName(waitService.waitForVisability(_contactFullNameLocator).Text.Trim().Split(' ').Last())
            .WithCategories(waitService.waitForVisability(_categoriesLocator).Text
                .Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries).Last().Replace(" ","").Split(','))
            .WithRole(waitService.waitForVisability(_contactRoleLocator).Text)
            .Build();

    	return contactModel;
    }
}