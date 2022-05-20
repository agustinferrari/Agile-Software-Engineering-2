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

        [Given(@"an existing ChargingSpot:")]
        public void GivenAnExistingChargingSpot(Table table)
        {
            _scenarioContext.Set(table.CreateInstance<ChargingSpot>);
        }

        [When(@"the user tries to delete the existing charging spot")]
        public void WhenTheUserTriesToDeleteTheExistingChargingSpot()
        {
            ChargingSpot existing = _scenarioContext.Get<ChargingSpot>();
            try
            {
                _chargingSpotController.DeleteChargingSpot(existing.Id);
            }
            catch (Exception ex)
            {
                _actualException = ex;
            }
        }

        [Then(@"an error '([^']*)' should be raised")]
        public void ThenAnErrorShouldBeRaised(string expectedErrorMessage)
        {
            Assert.IsNotNull(_actualException, "No error was raised");
            Assert.AreEqual(expectedErrorMessage, _actualException.Message);

            _actualException = null;
        }
    }
}
