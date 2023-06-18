using BoDi;
using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

[assembly: Parallelizable(ParallelScope.Fixtures)]
[assembly: LevelOfParallelism(3)]

namespace UiTests
{
    [Binding]
    public class Hooks
    {
        private BrowserFactory _browserFactory;
		private readonly IObjectContainer _objectContainer;
		private readonly IWebDriver _driver;

		public Hooks(IObjectContainer objectContainer)
        {
			_objectContainer = objectContainer;
			_browserFactory = new BrowserFactory();
			_driver = _browserFactory.GetDriver();
		}

		[BeforeScenario]
		public void BeforeScenario()
		{
			_objectContainer.RegisterInstanceAs<IWebDriver>(_driver);
		}

        [AfterScenario]
        public void AfterScenario()
        {
            _driver.Quit();
        }
    }
}