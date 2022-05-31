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
            try
            {
                _scenarioContext.Get<SeleniumTestHelper>();
            }
            catch (Exception e)
            {
                _scenarioContext.Set<SeleniumTestHelper>(new SeleniumTestHelper());
            }
        }

        [Given(@"an existing ChargingSpot")]
        public void GivenAnExistingChargingSpot(Table table)
        {
            ChargingSpot chargingSpot = table.CreateInstance<ChargingSpot>();
            _scenarioContext.Set<ChargingSpot>(chargingSpot);
        }

        [When(@"the user tries to delete the charging spot")]
        public void WhenTheUserTriesToDeleteTheChargingSpot()
        {
            DeleteChargingSpot();
        }

        [When(@"the user deletes the charging spot")]
        public void WhenTheUserDeletesTheChargingSpot()
        {
            SeleniumTestHelper helper = _scenarioContext.Get<SeleniumTestHelper>();
            helper.LoginWithCredentials();
            DeleteChargingSpot();
        }



        [Then(@"the charging spot should be deleted from the database")]
        public void ThenTheChargingSpotShouldBeDeletedFromTheDatabase()
        {
            SeleniumTestHelper helper = _scenarioContext.Get<SeleniumTestHelper>();
            List<ChargingSpot> foundChargingSpots = helper.GetChargingSpotsFromTable();
            ChargingSpot deletedChargingSpot = _scenarioContext.Get<ChargingSpot>();

            Assert.IsFalse(foundChargingSpots.Contains(deletedChargingSpot));
            
            //helper.Quit();
        }

        [Then(@"no delete button should be found")]
        public void ThenNoDeleteButtonShouldBeFound()
        {
            bool buttonFound = _scenarioContext.Get<bool>("buttonFound");

            Assert.IsFalse(buttonFound);
        }
        
        private void DeleteChargingSpot()
        {
            SeleniumTestHelper helper = _scenarioContext.Get<SeleniumTestHelper>();
            helper.Url("http://localhost:4200/explore/charging-spots");

            bool buttonFound = false;
            try
            {
                IWebElement deleteButton = helper.WaitForElement(By.Name("delete"));
                buttonFound = true;
                helper.Click(deleteButton);
            }
            catch (Exception e)
            {
                buttonFound = false;
            }
            finally
            {
                _scenarioContext.Set(buttonFound, "buttonFound");
            }            
        }

    }
}