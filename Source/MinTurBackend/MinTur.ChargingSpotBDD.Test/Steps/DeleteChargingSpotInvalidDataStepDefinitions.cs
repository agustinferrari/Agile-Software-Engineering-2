using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
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
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace MinTur.ChargingSpotBDD.Test
{
    [Binding]
    public class RemoveChargingSpotInvalidDataStepDefinitions
    {

        private readonly ScenarioContext _scenarioContext;
        private ChargingSpotController _chargingSpotController;
        private IChargingSpotManager _chargingSpotManager;
        private IRepositoryFacade _chargingSpotRepository;

        private Exception _actualException;

        public RemoveChargingSpotInvalidDataStepDefinitions(ScenarioContext context)
        {
            _scenarioContext = context;
            _actualException = null;
            _chargingSpotRepository = new RepositoryFacade(ContextFactory.GetNewContext(ContextType.Memory));
            _chargingSpotManager = new ChargingSpotManager(_chargingSpotRepository);
            _chargingSpotController = new ChargingSpotController(_chargingSpotManager);
        }


        [Given(@"an existing, logged user")]
        public void GivenAnExistingLoggedUser(Table table)
        {
            _scenarioContext.Set(table.CreateInstance<AdministratorIntentModel>);
        }

        [Given(@"a not existing ChargingSpot:")]
        public void GivenANotExistingChargingSpot(Table table)
        {
            _scenarioContext.Set(table.CreateInstance<ChargingSpot>);
        }

        [When(@"the user tries to delete the not existing charging spot")]
        public void WhenTheUserTriesToDeleteTheNotExistingChargingSpot()
        {
            try
            {
                ChargingSpot existing = _scenarioContext.Get<ChargingSpot>();
                IActionResult result = _chargingSpotController.DeleteChargingSpot(existing.Id);
                _scenarioContext.Set(result);
            }
            catch (ResourceNotFoundException e)
            {
                _actualException = e;
            }
        }

        [Then(@"the error 'Could not find specified charging spot' should be raised")]
        public void ThenTheErrorCouldNotDeleteChargingSpotBecauseItDoesNotExistShouldBeRaised(string expectedErrorMessage)
        {
            Assert.IsNotNull(_actualException, "No error was raised");
            Assert.IsInstanceOfType(_actualException, typeof(ResourceNotFoundException));
            Assert.AreEqual(_actualException.Message, expectedErrorMessage);

            _actualException = null;
        }

    }
}