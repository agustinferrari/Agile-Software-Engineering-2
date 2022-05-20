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
    public class AddChargingSpotStepDefinitions
    {

        private readonly ScenarioContext _scenarioContext;
        private ChargingSpotController _chargingSpotController;
        private Exception _actualException;

        public AddChargingSpotStepDefinitions(ScenarioContext context, ChargingSpotController chargingSpotController)
        {
            _scenarioContext = context;
            _chargingSpotController = chargingSpotController;
        }

        [Given(@"a Region already registered:")]
        public void GivenARegionAlreadyRegistered(Table table)
        {
            _scenarioContext.Set(table.CreateSet<Region>());
        }

        [Given(@"a new ChargingSpot:")]
        public void GivenANewChargingSpot(Table table)
        {
            _scenarioContext.Set(table.CreateSet<ChargingSpot>());
        }

        [When(@"the user tries to add the new charging spot")]
        public void WhenTheUserTriesToAddTheNewChargingSpot()
        {
            ChargingSpot chargingSpot = _scenarioContext.Get<ChargingSpot>();
            ChargingSpotIntentModel newModel = new ChargingSpotIntentModel()
            {
                Name = chargingSpot.Name,
                Address = chargingSpot.Address,
                RegionId = chargingSpot.Region.Id,
                Description = chargingSpot.Description
            };
            try
            {
                _chargingSpotController.CreateChargingSpot(newModel);
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
