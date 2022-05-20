using MinTur.Domain.BusinessEntities;
using MinTur.Domain.BusinessEntities;
using MinTur.Models.In;
using MinTur.WebApi.Controllers;
using NUnit.Framework;
using System;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace MinTur.ChargingSpotBDD.Test
{
    [Binding]
    public class RemoveChargingSpotStepDefinitions
    {

        private readonly ScenarioContext _scenarioContext;
        private ChargingSpotController _chargingSpotController;
        private Exception _actualException;

        public RemoveChargingSpotStepDefinitions(ScenarioContext context, ChargingSpotController chargingSpotController)
        {
            _scenarioContext = context;
            _chargingSpotController = chargingSpotController;
        }


        [Given(@"a not logged in user")]
        public void GivenANotLoggedInuser()
        {
            _scenarioContext.Pending();
        }

        [Given(@"an existing ChargingSpot:")]
        public void GivenAnExistingChargingSpot(Table table)
        {
            _scenarioContext.Pending();
        }

        [When(@"the user tries to delete the new charging spot")]
        public void WhenTheUserTriesToDeleteTheNewChargingSpot()
        {
            _scenarioContext.Pending();
        }

        [Then(@"an error '([^']*)' should be raised")]
        public void ThenAnErrorShouldBeRaised(string expectedErrorMessage)
        {
            _scenarioContext.Pending();
        }

    }
}
