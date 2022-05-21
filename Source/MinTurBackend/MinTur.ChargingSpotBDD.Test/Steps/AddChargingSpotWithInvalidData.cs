using Microsoft.VisualStudio.TestTools.UnitTesting;
using MinTur.BusinessLogic.ResourceManagers;
using MinTur.DataAccessInterface.Facades;
using MinTur.Models.In;
using MinTur.WebApi.Controllers;
using System;
using TechTalk.SpecFlow;

namespace MinTur.ChargingSpotBDD.Test.Steps
{
    public class AddChargingSpotWithInvalidData
    {
        private readonly ScenarioContext _scenarioContext;
        private ChargingSpotManager _chargingSpotManager;
        private IRepositoryFacade _chargingSpotRepository;
        private ChargingSpotController _chargingSpotController;

        public AddChargingSpotWithInvalidData(ScenarioContext context)
        {
            _scenarioContext = context;
            _chargingSpotManager = new ChargingSpotManager(_chargingSpotRepository);
        }

        [Given(@"a new ChargingSpot named (.*)")]
        public void GivenANewChargingSpotNamed(string name)
        {
            ChargingSpotIntentModel chargingSpot = new ChargingSpotIntentModel()
            {
                Name = name
            };
            _scenarioContext.Set(chargingSpot);
        }

        [Given(@"located in (.*)")]
        public void AndLocatedInAddress(string address)
        {
            ChargingSpotIntentModel chargingSpot = _scenarioContext.Get<ChargingSpotIntentModel>();
            chargingSpot.Address = address;
            _scenarioContext.Set(chargingSpot);
        }

        [Given(@"in the region (.*)")]
        public void AndInTheRegion(int regionId)
        {
            ChargingSpotIntentModel chargingSpot = _scenarioContext.Get<ChargingSpotIntentModel>();
            chargingSpot.RegionId = regionId;
            _scenarioContext.Set(chargingSpot);
        }

        [Given(@"the description (.*)")]
        public void AndTheDescription(string description)
        {
            ChargingSpotIntentModel chargingSpot = _scenarioContext.Get<ChargingSpotIntentModel>();
            chargingSpot.Description = description;
            _scenarioContext.Set(chargingSpot);
        }

        [When(@"the user tries to add the new charging spot with invalid data")]
        public void WhenTheUserTriesToAddTheNewChargingSpot()
        {
            ChargingSpotIntentModel chargingSpot = _scenarioContext.Get<ChargingSpotIntentModel>();
            try
            {
                _chargingSpotController.CreateChargingSpot(chargingSpot);
            }
            catch (Exception e)
            {
                _scenarioContext.Set(e);
            }
        }

        [Then(@"the following error (.*) should be raised")]
        public void ThenAnErrorShouldBeRaised(string error)
        {
            Exception e = _scenarioContext.Get<Exception>();
            Assert.AreEqual(error, e.Message);
        }
    }
}