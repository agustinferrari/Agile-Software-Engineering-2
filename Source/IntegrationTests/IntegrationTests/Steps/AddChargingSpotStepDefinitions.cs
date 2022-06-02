using System;
using TechTalk.SpecFlow;
using IntegrationTests.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using IntegrationTests.Models;
using TechTalk.SpecFlow.Assist;
using System.Collections.Generic;

namespace IntegrationTests.Steps
{
    [Binding]
    public class AddChargingSpotStepDefinitions
    {
        private readonly ScenarioContext _scenarioContext;

        public AddChargingSpotStepDefinitions(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            try
            {
                _scenarioContext.Get<SeleniumTestHelper>();
            }
            catch (Exception e)
            {
                _scenarioContext.Set<SeleniumTestHelper>(new SeleniumTestHelper());
            }
        }

        [Then(@"the charging spot should be added successfully")]
        public void ThenTheChargingSpotShouldBeAddedSuccessfully()
        {
            SeleniumTestHelper helper = _scenarioContext.Get<SeleniumTestHelper>();

            IWebElement succeedMessage = helper.WaitForElement(By.Name("succeed"));
            Assert.IsNotNull(succeedMessage);
            //helper.Quit();
        }

        [When(@"the user tries to add the new charging spot")]
        public void WhenTheUserTriesToAddTheNewChargingSpot()
        {
            try
            {
                SeleniumTestHelper helper = _scenarioContext.Get<SeleniumTestHelper>();
                helper.Url("http://localhost:4200/explore/charging-spots");

                IWebElement openFormButton = helper.WaitForElement(By.Id("charging-spot-form-button"));
                helper.Click(openFormButton);

                string name = _scenarioContext.Get<string>("chargingSpotName");
                string address = _scenarioContext.Get<string>("chargingSpotAddress");
                string description = _scenarioContext.Get<string>("chargingSpotDescription");
                string regionName = _scenarioContext.Get<string>("chargingSpotRegionName");


                helper.CreateChargingSpotInForm(name, address, description, regionName);

            }
            catch(Exception e)
            {
                _scenarioContext.Set(e, "exception");
            }
        }

        [Then(@"the alert (.*) should be shown")]
        public void ThenTheErrorAlertShouldBeShown(string alert)
        {
            SeleniumTestHelper helper = _scenarioContext.Get<SeleniumTestHelper>();
            Assert.AreEqual(alert, helper.GetAlertText());
        }

        [Then(@"the user is not allowed to create the charging spot")]
        public void ThenTheUserIsNotAllowedToCreateTheChargingSpot()
        {
            Assert.AreEqual(new WebDriverTimeoutException().GetType(), _scenarioContext.Get<Exception>("exception").GetType());
        }

        [Then(@"the charging spot couldnt be created")]
        public void ThenTheChargingSpotCouldntBeCreated()
        {
            Assert.AreEqual(new InvalidOperationException().GetType(), _scenarioContext.Get<Exception>("exception").GetType());
        }

        #region ChargingSpot_by_Steps

        [Given(@"a new ChargingSpot")]
        public void GivenANewChargingSpot(Table table)
        {
            ChargingSpot chargingSpot = table.CreateInstance<ChargingSpot>();
            _scenarioContext.Set(chargingSpot.Name, "chargingSpotName");
            _scenarioContext.Set(chargingSpot.Address, "chargingSpotAddress");
            _scenarioContext.Set(chargingSpot.RegionName, "chargingSpotRegionName");
            _scenarioContext.Set(chargingSpot.Description, "chargingSpotDescription");
        }

        [Given(@"a new ChargingSpot named (.*)")]
        public void GivenANewChargingSpotNamed(string name)
        {
            _scenarioContext.Set(name, "chargingSpotName");
        }

        [Given(@"located in (.*)")]
        public void GivenLocatedIn(string address)
        {
            _scenarioContext.Set(address, "chargingSpotAddress");
        }

        [Given(@"in the region (.*)")]
        public void GivenInTheRegion(string regionName)
        {
            _scenarioContext.Set(regionName, "chargingSpotRegionName");
        }

        [Given(@"the description (.*)")]
        public void GivenTheDescription(string description)
        {
            _scenarioContext.Set(description, "chargingSpotDescription");
        }

        #endregion
    }
}