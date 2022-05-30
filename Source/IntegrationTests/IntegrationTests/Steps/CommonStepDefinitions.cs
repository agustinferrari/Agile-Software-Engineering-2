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
            helper.Login(admin.Rows[0]["Email"], admin.Rows[0]["Password"]);
        }

        [Given(@"an existing region")]
        public void GivenAnExistingRegion(Table region)
        {
            string regionId = $"region-{region.Rows[0]["Id"]}";
            SeleniumTestHelper helper = _scenarioContext.Get<SeleniumTestHelper>();
            helper.Url("http://localhost:4200/explore/regions");
            helper.WaitForElement(By.Id(regionId));
        }

        [Given(@"no charging spots saved")]
        public void GivenNoChargingSpotsSaved()
        {
            SeleniumTestHelper helper = _scenarioContext.Get<SeleniumTestHelper>();
            helper.LoginWithCredentials();

            helper.Url("http://localhost:4200/explore/charging-spots");

            IList<IWebElement> errorMessages = helper.WaitForElements(By.Name("error"));
            bool found = false;
            foreach (IWebElement errorMessage in errorMessages)
            {
                if (errorMessage.Text == "No charging spots in system")
                {
                    found = true;
                }
            }
            if (!found)
            {
                IList<IWebElement> buttons = helper.WaitForElements(By.Name("delete"));
                foreach (IWebElement button in buttons)
                {
                    helper.Click(button);
                }
            }
            helper.Logout();
        }

        [Then(@"the error (.*) should be raised")]
        public void ThenTheErrorShouldBeRaised(string error)
        {
            SeleniumTestHelper helper = _scenarioContext.Get<SeleniumTestHelper>();
            IList<IWebElement> errorMessages = helper.WaitForElements(By.Name("error"));
            bool found = false;
            foreach (IWebElement errorMessage in errorMessages)
            {
                if (errorMessage.Text == error)
                {
                    found = true;
                }
            }
            Assert.IsTrue(found);
        }
    }
}