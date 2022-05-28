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
            _scenarioContext.Pending();
        }

        [When(@"the user tries to add the new charging spot")]
        public void WhenTheUserTriesToAddTheNewChargingSpot()
        {
            _scenarioContext.Pending();
        }



        #region ChargingSpot_by_Steps

        [Given(@"a new ChargingSpot named (.*)")]
        public void GivenANewChargingSpotNamed(string name)
        {
            _scenarioContext.Pending();
        }

        [Given(@"located in (.*)")]
        public void GivenLocatedIn(string address)
        {
            _scenarioContext.Pending();
        }

        [Given(@"in the region (.*)")]
        public void GivenInTheRegion(int id)
        {
            _scenarioContext.Pending();
        }

        [Given(@"the description (.*)")]
        public void GivenTheDescription(string description)
        {
            _scenarioContext.Pending();
        }

        #endregion
    }
}