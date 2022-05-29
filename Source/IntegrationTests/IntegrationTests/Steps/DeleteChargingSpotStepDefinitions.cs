using System;
using TechTalk.SpecFlow;
using IntegrationTests.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System.Collections.Generic;
using IntegrationTests.Models;
using TechTalk.SpecFlow.Assist;

namespace IntegrationTests.Steps
{
    [Binding]
    public class DeleteChargingSpotStepDefinitions
    {
        private readonly ScenarioContext _scenarioContext;

        public DeleteChargingSpotStepDefinitions(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _scenarioContext.Set<SeleniumTestHelper>(new SeleniumTestHelper());
        }

        [Given(@"an existing ChargingSpot")]
        public void GivenAnExistingChargingSpot(Table table)
        {
            ChargingSpot chargingSpot = table.CreateInstance<ChargingSpot>();
            _scenarioContext.Set<ChargingSpot>(chargingSpot);
        }

        [Given(@"a charging spot with id (.*)")]
        public void GivenAChargingSpotWithId(int id)
        {
            _scenarioContext.Set(id, "chargingSpotId");
        }

        [When(@"the user tries to delete the charging spot")]
        public void WhenTheUserTriesToDeleteTheChargingSpot()
        {
            SeleniumTestHelper helper = _scenarioContext.Get<SeleniumTestHelper>();
            helper.Url("http://localhost:4200/explore/charging-spots");
            int chargingSpotId = _scenarioContext.Get<int>("chargingSpotId");

            IWebElement deleteChargingSpotButton = helper.WaitForElement(By.Id("delete-"+chargingSpotId));
            helper.Click(deleteChargingSpotButton);
        }


        [Then(@"the charging spot should be deleted from the database")]
        public void ThenTheChargingSpotShouldBeDeletedFromTheDatabase()
        {
            List<ChargingSpot> foundChargingSpots = GetChargingSpotsFromTable();
            ChargingSpot deletedChargingSpot = _scenarioContext.Get<ChargingSpot>();

            Assert.IsFalse(foundChargingSpots.Contains(deletedChargingSpot));
        }

        #region helpers
        private List<ChargingSpot> GetChargingSpotsFromTable()
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
                string regionName = columns[3].Text;

                foundChargingSpots.Add(new ChargingSpot
                {
                    Id = idCell,
                    Name = name,
                    Description = description,
                    RegionName = regionName
                });
            }

            return foundChargingSpots;
        }
        #endregion
    }
}