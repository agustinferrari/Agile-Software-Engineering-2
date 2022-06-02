using Microsoft.VisualStudio.TestTools.UnitTesting;
using MinTur.BusinessLogic.ResourceManagers;
using MinTur.DataAccess.Contexts;
using MinTur.DataAccess.Facades;
using MinTur.DataAccessInterface.Facades;
using MinTur.Models.In;
using MinTur.WebApi.Controllers;
using System;
using TechTalk.SpecFlow;

namespace MinTur.ChargingSpotBDD.Test.Steps
{
    [Binding]
    public class AddChargingSpotWithInvalidDataStepDefinitions
    {
        private readonly ScenarioContext _scenarioContext;
        private readonly ChargingSpotManager _chargingSpotManager;
        private readonly IRepositoryFacade _chargingSpotRepository;
        private readonly ChargingSpotController _chargingSpotController;

        public AddChargingSpotWithInvalidDataStepDefinitions(ScenarioContext context)
        {
            _scenarioContext = context;
            _chargingSpotRepository = new RepositoryFacade(ContextFactory.GetNewContext(ContextType.Memory));
            _chargingSpotManager = new ChargingSpotManager(_chargingSpotRepository);
            _chargingSpotController = new ChargingSpotController(_chargingSpotManager);

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