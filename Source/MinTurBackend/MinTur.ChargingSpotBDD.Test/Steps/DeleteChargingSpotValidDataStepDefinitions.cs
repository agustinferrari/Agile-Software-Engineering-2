using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Primitives;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MinTur.BusinessLogic.ResourceManagers;
using MinTur.BusinessLogicInterface.ResourceManagers;
using MinTur.BusinessLogicInterface.Security;
using MinTur.DataAccess.Contexts;
using MinTur.DataAccess.Facades;
using MinTur.DataAccessInterface.Facades;
using MinTur.Domain.BusinessEntities;
using MinTur.Domain.BusinessEntities;
using MinTur.Exceptions;
using MinTur.Models.In;
using MinTur.WebApi.Controllers;
using MinTur.WebApi.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace MinTur.ChargingSpotBDD.Test
{
    [Binding]
    public class DeleteChargingSpotValidDataStepDefinitions
    {

        private readonly ScenarioContext _scenarioContext;
        private NaturalUruguayContext _dbContext;
        private ChargingSpotController _chargingSpotController;
        private IChargingSpotManager _chargingSpotManager;
        private IRepositoryFacade _chargingSpotRepository;

        private Exception _actualException;

        public DeleteChargingSpotValidDataStepDefinitions(ScenarioContext context)
        {
            _scenarioContext = context;
            _actualException = null;
            _dbContext = ContextFactory.GetNewContext(ContextType.Memory);
            _chargingSpotRepository = new RepositoryFacade(_dbContext);
            _chargingSpotManager = new ChargingSpotManager(_chargingSpotRepository);
            _chargingSpotController = new ChargingSpotController(_chargingSpotManager);
        }


        [Given(@"an existing, logged admin")]
        public void GivenAnExistingLoggedUser(Table table)
        {
            _scenarioContext.Set(table.CreateInstance<AdministratorIntentModel>);
        }

        [Given(@"the existing Region:")]
        public void GivenTheExistingRegion(Table table)
        {
            Region region = table.CreateInstance<Region>();
            _dbContext.Set<Region>().Add(region);
            _dbContext.SaveChanges();
        }

        [Given(@"the existing ChargingSpot:")]
        public void GivenTheExistingChargingSpot(Table table)
        {
            ChargingSpot charingSpot = table.CreateInstance<ChargingSpot>();
            _dbContext.Set<ChargingSpot>().Add(charingSpot);
            _dbContext.SaveChanges();
            List<ChargingSpot> chargingSpotsOnDBBeforeDelete = _dbContext.Set<ChargingSpot>().ToList();
            _scenarioContext.Set(charingSpot);
            _scenarioContext.Set(chargingSpotsOnDBBeforeDelete);
        }

        [When(@"the user tries to delete the charging spot")]
        public void WhenTheUserTriesToDeleteTheNotExistingChargingSpot()
        {
            ChargingSpot existing = _scenarioContext.Get<ChargingSpot>();
            IActionResult result = _chargingSpotController.DeleteChargingSpot(existing.Id);
            _scenarioContext.Set(result);
        }

        [Then(@"the charging spot should be deleted from the database")]
        public void ThenTheErrorCouldNotDeleteChargingSpotBecauseItDoesNotExistShouldBeRaised()
        {
            List<ChargingSpot> chargingSpotsOnDBBeforeDelete = _scenarioContext.Get<List<ChargingSpot>>();
            Assert.AreEqual(1, chargingSpotsOnDBBeforeDelete.Count);
            List<ChargingSpot> chargingSpotsOnDB = _dbContext.Set<ChargingSpot>().ToList();
            Assert.AreEqual(0, chargingSpotsOnDB.Count);
        }

    }
}
