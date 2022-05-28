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
            _scenarioContext.Set<SeleniumTestHelper>(new SeleniumTestHelper());
        }

        [Given(@"no charging spots saved")]
        public void GivenNoChargingSpotsSaved()
        {
            SeleniumTestHelper helper = _scenarioContext.Get<SeleniumTestHelper>();
            helper.Url("http://localhost:4200/");
        }

        [When(@"the user requests the list of charging spots")]
        public void WhentTheUserRequestsTheListOfChargingSpots()
        {
            SeleniumTestHelper helper = _scenarioContext.Get<SeleniumTestHelper>();
            helper.Url("http://localhost:4200/charging-spot");
            IWebElement chargingSpotNavbar = helper.WaitForElement(By.Id("charging-spot-navbar"));
            chargingSpotNavbar.Click();
        }

        [Given(@"the charging spots")]
        public void GivenTheChargingSpots(Table chargingSpots)
        {
            List<ChargingSpot> chargingSpotList = chargingSpots.CreateSet<ChargingSpot>().ToList();
            _scenarioContext.Set<List<ChargingSpot>>(chargingSpotList);
        }

        [Then(@"a list containing the charging spots should be returned")]
        public void ThenAListContainingTheChargingSpotsShouldBeReturned()
        {
            SeleniumTestHelper helper = _scenarioContext.Get<SeleniumTestHelper>();
            IWebElement table = helper.WaitForElement(By.Id("charging-spot-table"));
            IList<IWebElement> rows = table.FindElements(By.TagName("tr"));

            List<ChargingSpot> foundChargingSpots = new List<ChargingSpot>();

            foreach (IWebElement row in rows)
            {
                IList<IWebElement> columns = row.FindElements(By.TagName("td"));
                int idCell = columns[0].Text == "" ? 0 : int.Parse(columns[0].Text);
                string name = columns[1].Text;
                string description = columns[2].Text;
                string address = columns[3].Text;
                string regionName = columns[4].Text;

                foundChargingSpots.Add(new ChargingSpot
                {
                    Id = idCell,
                    Name = name,
                    Description = description,
                    RegionName = regionName
                });
            }

            Assert.AreEqual(rows.Count, _scenarioContext.Get<List<ChargingSpot>>().Count);
            CollectionAssert.AreEqual(_scenarioContext.Get<List<ChargingSpot>>(), foundChargingSpots);
        }
    }
}