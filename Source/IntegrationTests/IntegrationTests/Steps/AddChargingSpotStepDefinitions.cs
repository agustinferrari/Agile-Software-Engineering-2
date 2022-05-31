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
            //helper.Quit();
        }

        [When(@"the user tries to add the new charging spot")]
        public void WhenTheUserTriesToAddTheNewChargingSpot()
        {
            SeleniumTestHelper helper = _scenarioContext.Get<SeleniumTestHelper>();
            helper.Url("http://localhost:4200/explore/charging-spot");

            IWebElement openFormButton = helper.WaitForElement(By.Id("charging-spot-form-button"));
            helper.Click(openFormButton);

            string name = _scenarioContext.Get<string>("chargingSpotName");
            string address = _scenarioContext.Get<string>("chargingSpotAddress");
            string description = _scenarioContext.Get<string>("chargingSpotDescription");
            string regionName = _scenarioContext.Get<string>("chargingSpotRegionName");


            helper.CreateChargingSpotInForm(name,address,description, regionName);
        

        }


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