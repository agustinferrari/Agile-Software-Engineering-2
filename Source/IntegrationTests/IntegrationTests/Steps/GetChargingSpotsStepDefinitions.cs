using System;
using TechTalk.SpecFlow;
using IntegrationTests.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using IntegrationTests.Models;
using TechTalk.SpecFlow.Assist;
using System.Linq;
using System.Collections.Generic;

namespace IntegrationTests.Steps
{
    [Binding]
    public class GetChargingSpotsStepDefinition
    {
        private readonly ScenarioContext _scenarioContext;

        public GetChargingSpotsStepDefinition(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            try
            {
                _scenarioContext.Get<SeleniumTestHelper>();
            }
            catch (Exception)
            {
                _scenarioContext.Set<SeleniumTestHelper>(new SeleniumTestHelper());
            }
        }

        [When(@"the user requests the list of charging spots")]
        public void WhentTheUserRequestsTheListOfChargingSpots()
        {
            SeleniumTestHelper helper = _scenarioContext.Get<SeleniumTestHelper>();
            helper.Url("http://localhost:4200/explore/charging-spots");
        }

        [Given(@"the charging spots")]
        public void GivenTheChargingSpots(Table chargingSpots)
        {
            SeleniumTestHelper helper = _scenarioContext.Get<SeleniumTestHelper>();
            bool loginStatus = false;
            try
            {
                loginStatus = _scenarioContext.Get<bool>("loginStatus");
            }
            catch (Exception)
            {
            }

            helper.DeleteAllChargingSpots(loginStatus);
            List<ChargingSpot> chargingSpotList = chargingSpots.CreateSet<ChargingSpot>().ToList();
            _scenarioContext.Set<List<ChargingSpot>>(chargingSpotList);

            foreach(ChargingSpot c in chargingSpotList){
                helper.Url("http://localhost:4200/admin/charging-spot-create");
                helper.CreateChargingSpotInForm(c.Name,c.Address, c.Description, _scenarioContext.Get<Region>().Name);
            }
            helper.Logout();
        }

        [Then(@"a list containing the charging spots should be returned")]
        public void ThenAListContainingTheChargingSpotsShouldBeReturned()
        {
            SeleniumTestHelper helper = _scenarioContext.Get<SeleniumTestHelper>();
            List<ChargingSpot> foundChargingSpots = helper.GetChargingSpotsFromTable();

            CollectionAssert.AreEqual(_scenarioContext.Get<List<ChargingSpot>>(), foundChargingSpots);
        }
    }
}