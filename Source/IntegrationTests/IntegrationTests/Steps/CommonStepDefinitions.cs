using System;
using TechTalk.SpecFlow;
using IntegrationTests.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System.Collections.Generic;

namespace IntegrationTests.Steps
{
    [Binding]
    public class CommonStepDefinitions
    {
        private readonly ScenarioContext _scenarioContext;

        public CommonStepDefinitions(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _scenarioContext.Set<SeleniumTestHelper>(new SeleniumTestHelper());
        }

        [Given(@"a logged in admin")]
        public void GivenALoggedInAdmin(Table admin)
        {
            SeleniumTestHelper helper = _scenarioContext.Get<SeleniumTestHelper>();
            helper.Url("http://localhost:4200/");
            IWebElement loginNavbar = helper.WaitForElement(By.Id("login-navbar"));
            loginNavbar.Click();

            IWebElement email = helper.WaitForElement(By.Id("email"));
            email.SendKeys(admin.Rows[0]["Email"]);
            IWebElement pass = helper.WaitForElement(By.Id("password"));
            pass.SendKeys(admin.Rows[0]["Password"]);
            IWebElement loginButton = helper.WaitForElement(By.Id("login-button"));
            loginButton.Click();
        }

        [Given(@"an existing region")]
        public void GivenAnExistingRegion(Table region)
        {
            string regionId = $"region-{region.Rows[0]["Id"]}";
            SeleniumTestHelper helper = _scenarioContext.Get<SeleniumTestHelper>();
            helper.Url("http://localhost:4200/explore/regions");
            helper.WaitForElement(By.Id(regionId));
        }

        [Then(@"the error (.*) should be raised")]
        public void ThenTheErrorShouldBeRaised(string error)
        {
            SeleniumTestHelper helper = _scenarioContext.Get<SeleniumTestHelper>();
            IList<IWebElement> errorMessages = helper.WaitForElements(By.Name("error"));
            bool found = false;
            foreach (IWebElement errorMessage in errorMessages)
            {
                if(errorMessage.Text == error)
                {
                    found = true;
                }
            }
            Assert.IsTrue(found);
        }
    }
}