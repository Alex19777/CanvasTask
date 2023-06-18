using OpenQA.Selenium;
using UiTests.services;

namespace UiTests.pages;

public class LoginPage : BasePage
{
    private By emailInputLocator = By.Name("user_name");
    private By passwordInputLocator = By.Id("login_pass");
    private By signInButtonLocator = By.Id("login_button");
    private By themesDropDownLocator = By.Id("login_theme");
    private By spectrumThemeLocator = By.XPath("//option[text() = 'Spectrum Theme']");
    
    public LoginPage(IWebDriver driver, WaitService waitService) : base(driver, waitService) {}

    public LoginPage InputCredentials(string email, string password)
    {
        driver.FindElement(emailInputLocator).SendKeys(email);
        driver.FindElement(passwordInputLocator).SendKeys(password);
        return this;
    }
    
    public HomePage ClickSingInButton()
    {
       driver.FindElement(signInButtonLocator).Click();
       return new HomePage(driver, waitService);
    }

	public LoginPage SwitchToTheme()
	{
		driver.FindElement(themesDropDownLocator).Click();
		driver.FindElement(spectrumThemeLocator).Click();
		return this;
	}
}