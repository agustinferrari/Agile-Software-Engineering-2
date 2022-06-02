using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MinTur.BusinessLogic.ResourceManagers;
using MinTur.BusinessLogicInterface.ResourceManagers;
using MinTur.DataAccess.Contexts;
using MinTur.DataAccess.Facades;
using MinTur.DataAccessInterface.Facades;
using MinTur.Domain.BusinessEntities;
using MinTur.Models.In;
using MinTur.WebApi.Controllers;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace MyNamespace
{
    [Binding]
    public class AddChargingSpotWithValidDataStepDefinitions
    {
        private readonly ScenarioContext _scenarioContext;
        private readonly NaturalUruguayContext _dbContext;
        private readonly ChargingSpotController _chargingSpotController;
        private readonly IChargingSpotManager _chargingSpotManager;
        private readonly IRepositoryFacade _chargingSpotRepository;

        public AddChargingSpotWithValidDataStepDefinitions(ScenarioContext context)
        {
            _scenarioContext = context;
            _dbContext = ContextFactory.GetNewContext(ContextType.Memory);
            _chargingSpotRepository = new RepositoryFacade(_dbContext);
            _chargingSpotManager = new ChargingSpotManager(_chargingSpotRepository);
            _chargingSpotController = new ChargingSpotController(_chargingSpotManager);
        }

        [Given(@"an existing, logged in admin")]
        public void GivenAnExistingLoggedInAdmin(Table table)
        {
            _scenarioContext.Set(table.CreateInstance<AdministratorIntentModel>);
        }

        [Given(@"the existing region:")]
        public void GivenTheExistingRegion(Table table)
        {
            Region region = table.CreateInstance<Region>();
            _dbContext.Set<Region>().Add(region);
            _dbContext.SaveChanges();
        }

        [Given(@"a new ChargingSpot with valid data to add:")]
        public void GivenANewChargingSpotWithValidDataToAdd(Table table)
        {
            ChargingSpotIntentModel chargingSpotIntentModel = table.CreateInstance<ChargingSpotIntentModel>();
            _scenarioContext.Set(chargingSpotIntentModel);

            List<ChargingSpot> chargingSpotsOnDBBeforAddition = _dbContext.Set<ChargingSpot>().ToList();
            _scenarioContext.Set(chargingSpotsOnDBBeforAddition);
        }

        [When(@"the user tries to add the charging spot")]
        public void WhenTheUserTriesToAddTheChargingSpot()
        {
            ChargingSpotIntentModel chargingSpotToAdd = _scenarioContext.Get<ChargingSpotIntentModel>();
            IActionResult result = _chargingSpotController.CreateChargingSpot(chargingSpotToAdd);
            _scenarioContext.Set(result);
        }

        [Then(@"the charging spot should be added to the database")]
        public void ThenTheChargingSpotShouldBeAddedToTheDatabase()
        {
            List<ChargingSpot> chargingSpotsOnDBBeforAddition = _scenarioContext.Get<List<ChargingSpot>>();
            Assert.AreEqual(0, chargingSpotsOnDBBeforAddition.Count);
            List<ChargingSpot> chargingSpotsOnDB = _dbContext.Set<ChargingSpot>().ToList();
            Assert.AreEqual(1, chargingSpotsOnDB.Count);
            CleanUp();
        }

        [TestCleanup]
        public void CleanUp()
        {
            _dbContext.Database.EnsureDeleted();
        }

    }
}