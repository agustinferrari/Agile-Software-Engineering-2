using System;
using TechTalk.SpecFlow;

namespace IntegrationTests.Steps
{
    [Binding]
    public class DeleteChargingSpotStepDefinitions
    {
        private readonly ScenarioContext _scenarioContext;

        public DeleteChargingSpotStepDefinitions(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [Given(@"an existing ChargingSpot")]
        public void GivenAnExistingChargingSpot(Table chargingSpot)
        {
            _scenarioContext.Pending();
        }

        [Given(@"a charging spot with id (.*)")]
        public void GivenAChargingSpotWithId(int id)
        {
            _scenarioContext.Pending();
        }

        [When(@"the user tries to delete the charging spot")]
        public void WhenTheUserTriesToDeleteTheChargingSpot()
        {
            _scenarioContext.Pending();
        }

        [Given(@"an existing ChargingSpot")]
        public void GivenAnExistingChargingSpot(Table chargingSpot)
        {
            _scenarioContext.Pending();
        }


        [Then(@"the charging spot should be deleted from the database")]
        public void ThenTheChargingSpotShouldBeDeletedFromTheDatabase()
        {
            _scenarioContext.Pending();
        }
    }
}