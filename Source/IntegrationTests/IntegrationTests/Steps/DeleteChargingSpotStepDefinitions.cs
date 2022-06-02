using System;
using TechTalk.SpecFlow;
using IntegrationTests.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System.Collections.Generic;
using IntegrationTests.Models;
using TechTalk.SpecFlow.Assist;
using System.Linq;

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
            catch (Exception)
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
        public void WhenTheUserTriesToDeleteTheChargingSpot(Table names)
        {
            List<string> namesList = names.CreateSet<string>().ToList();


            SeleniumTestHelper helper = _scenarioContext.Get<SeleniumTestHelper>();
            helper.Url("http://localhost:4200/explore/charging-spots");

            bool tableFound = false;
            bool containsNameList = false;
            bool buttonFound = false;
            try
            {
                IWebElement chargingSpotTable = helper.WaitForElement(By.Id("charging-spot-table"));
                tableFound = true;
                IList<IWebElement> chargingSpots = helper.WaitForElements(By.XPath("//tr[]"));
                List<string> chargingSpotNames = new List<string>();
                foreach (IWebElement chargingSpot in chargingSpots)
                {
                    chargingSpotNames.Add(chargingSpot.FindElements(By.XPath("//td[]"))[1].Text);
                }

                foreach (string name in namesList)
                {
                    if (chargingSpotNames.Contains(name))
                    {
                        containsNameList = true;
                    }
                }

                IWebElement deleteButton = helper.WaitForElement(By.Name("delete"));
                buttonFound = true;
                helper.Click(deleteButton);
            }
            catch (Exception)
            {
                buttonFound = false;
            }
            finally
            {
                _scenarioContext.Set(containsNameList, "containsNameList");
                _scenarioContext.Set(tableFound, "tableFound");
                _scenarioContext.Set(buttonFound, "buttonFound");
            }
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

        [Then(@"the charging spot cannot be deleted")]
        public void TheChargingSpotCannotBeDeleted()
        {
            bool buttonFound = _scenarioContext.Get<bool>("buttonFound");
            Assert.IsFalse(buttonFound);
        }

        [Then(@"the charging spots by those names cannot be deleted")]
        public void TheChargingSpotByThoseNamesCannotBeDeleted()
        {
            bool tableFound = _scenarioContext.Get<bool>("tableFound");
            bool containsNameList = _scenarioContext.Get<bool>("containsNameList");
            Assert.IsTrue(tableFound && !containsNameList);
        }

        private void DeleteChargingSpot()
        {
            SeleniumTestHelper helper = _scenarioContext.Get<SeleniumTestHelper>();
            helper.Url("http://localhost:4200/explore/charging-spots");

            bool buttonFound = false;
            bool tableFound = false;
            try
            {
                IWebElement chargingSpotTable = helper.WaitForElement(By.Id("charging-spot-table"));
                tableFound = true;
                IWebElement deleteButton = helper.WaitForElement(By.Name("delete"));
                buttonFound = true;
                helper.Click(deleteButton);
            }
            catch (Exception)
            {
                buttonFound = false;
            }
            finally
            {
                _scenarioContext.Set(tableFound, "tableFound");
                _scenarioContext.Set(buttonFound, "buttonFound");
            }
        }

    }
}