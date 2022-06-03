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
using System;
using System.Collections.Generic;
using System.Linq;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace MinTur.ChargingSpotBDD.Test
{
    [Binding]
    public class AddChargingSpotStepDefinitions
    {
        private readonly ScenarioContext _scenarioContext;
        private readonly ChargingSpotController _chargingSpotController;
        private readonly IChargingSpotManager _chargingSpotManager;
        private readonly IRepositoryFacade _chargingSpotRepository;
        private readonly NaturalUruguayContext _dbContext;

        public AddChargingSpotStepDefinitions(ScenarioContext context)
        {
            _scenarioContext = context;
            _chargingSpotRepository = new RepositoryFacade(ContextFactory.GetNewContext(ContextType.Memory));
            _chargingSpotManager = new ChargingSpotManager(_chargingSpotRepository);
            _chargingSpotController = new ChargingSpotController(_chargingSpotManager);
            _dbContext = ContextFactory.GetNewContext(ContextType.Memory);
        }

        [Given(@"a new ChargingSpot")]
        public void GivenANewChargingSpot(Table table)
        {
            ChargingSpotIntentModel chargingSpotIntentModel = table.CreateInstance<ChargingSpotIntentModel>();
            _scenarioContext.Set(chargingSpotIntentModel);

            List<ChargingSpot> chargingSpotsOnDBBeforAddition = _dbContext.Set<ChargingSpot>().ToList();
            _scenarioContext.Set(chargingSpotsOnDBBeforAddition);
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
        public void GivenLocatedInAddress(string address)
        {
            ChargingSpotIntentModel chargingSpot = _scenarioContext.Get<ChargingSpotIntentModel>();
            chargingSpot.Address = address;
            _scenarioContext.Set(chargingSpot);
        }

        [Given(@"in the region (.*)")]
        public void GivenInTheRegion(int regionId)
        {
            ChargingSpotIntentModel chargingSpot = _scenarioContext.Get<ChargingSpotIntentModel>();
            chargingSpot.RegionId = regionId;
            _scenarioContext.Set(chargingSpot);
        }

        [Given(@"the description (.*)")]
        public void GivenTheDescription(string description)
        {
            ChargingSpotIntentModel chargingSpot = _scenarioContext.Get<ChargingSpotIntentModel>();
            chargingSpot.Description = description;
            _scenarioContext.Set(chargingSpot);
        }

        [Given(@"the existing region")]
        public void GivenTheExistingRegion(Table table)
        {
            Region region = table.CreateInstance<Region>();
            _dbContext.Set<Region>().Add(region);
            _dbContext.SaveChanges();
        }

        [When(@"the user tries to add the charging spot")]
        public void WhenTheUserTriesToAddTheNewChargingSpot()
        {
            ChargingSpotIntentModel chargingSpot = _scenarioContext.Get<ChargingSpotIntentModel>();
            try
            {
                IActionResult auth = _scenarioContext.Get<IActionResult>("auth");
                JsonResult parsedResult = (JsonResult)auth;
                _scenarioContext.Set(parsedResult.Value, "result");
            }
            catch
            {
                try
                {
                   _chargingSpotController.CreateChargingSpot(chargingSpot);
                }
                catch (Exception e)
                {
                    _scenarioContext.Set(e.Message, "result");
                }
            }       
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
