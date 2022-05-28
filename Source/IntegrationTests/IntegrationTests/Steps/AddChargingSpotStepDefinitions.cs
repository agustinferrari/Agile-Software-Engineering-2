using System;
using TechTalk.SpecFlow;
using IntegrationTests.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
namespace IntegrationTests.Steps
{
    [Binding]
    public class AddChargingSpotStepDefinitions
    {
        private readonly ScenarioContext _scenarioContext;

        public AddChargingSpotStepDefinitions(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _scenarioContext.Set<SeleniumTestHelper>(new SeleniumTestHelper());
        }

        [Then(@"the charging spot should be added successfully")]
        public void ThenTheChargingSpotShouldBeAddedSuccessfully()
        {
            SeleniumTestHelper helper = _scenarioContext.Get<SeleniumTestHelper>();

            IWebElement succeedMessage = helper.WaitForElement(By.Name("succeed"));
            Assert.IsNotNull(succeedMessage);
        }

        [When(@"the user tries to add the new charging spot")]
        public void WhenTheUserTriesToAddTheNewChargingSpot()
        {
            SeleniumTestHelper helper = _scenarioContext.Get<SeleniumTestHelper>();
            helper.Url("http://localhost:4200/explore/charging-spot");

            IWebElement openFormButton = helper.WaitForElement(By.Id("charging-spot-form-button"));
            helper.Click(openFormButton);

            FillForm();

            IWebElement createButton = helper.WaitForElement(By.Id("create-charging-spot-button"));
            helper.Click(createButton);
        }

        #region Helpers

        private void FillForm()
        {
            SeleniumTestHelper helper = _scenarioContext.Get<SeleniumTestHelper>();

            IWebElement name = helper.WaitForElement(By.Id("name"));
            IWebElement address = helper.WaitForElement(By.Id("address"));
            IWebElement description = helper.WaitForElement(By.Id("description"));
            IWebElement regions = helper.WaitForElement(By.Id("regions"));

            helper.FillTextBox(name, _scenarioContext.Get<string>("chargingSpotName"));
            helper.FillTextBox(address, _scenarioContext.Get<string>("chargingSpotAddress"));
            helper.FillTextBox(description, _scenarioContext.Get<string>("chargingSpotDescription"));
            helper.SelectDropDownValue(regions, "region-"+_scenarioContext.Get<int>("chargingSpotRegionId").ToString());
        }

        #endregion


        #region ChargingSpot_by_Steps

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
        public void GivenInTheRegion(int regionId)
        {
            _scenarioContext.Set(regionId, "chargingSpotRegionId");
        }

        [Given(@"the description (.*)")]
        public void GivenTheDescription(string description)
        {
            _scenarioContext.Set(description, "chargingSpotDescription");
        }

        #endregion
    }
}