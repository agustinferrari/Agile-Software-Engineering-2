using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Primitives;
using MinTur.BusinessLogic.ResourceManagers;
using MinTur.BusinessLogicInterface.Security;
using MinTur.Domain.BusinessEntities;
using MinTur.Domain.BusinessEntities;
using MinTur.Models.In;
using MinTur.WebApi.Controllers;
using MinTur.WebApi.Filters;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace MinTur.ChargingSpotBDD.Test
{
    [Binding]
    public class RemoveChargingSpotStepDefinitions
    {

        private readonly ScenarioContext _scenarioContext;
        private ChargingSpotController _chargingSpotController;
        private ChargingSpotManager _chargingSpotManager;

        private Exception _actualException;

        public RemoveChargingSpotStepDefinitions(ScenarioContext context)
        {
            _scenarioContext = context;
            _chargingSpotManager = new ChargingSpotManager();
            _chargingSpotController = new ChargingSpotController(_chargingSpotManager);
        }

        [Given(@"an existing ChargingSpot:")]
        public void GivenAnExistingChargingSpot(Table table)
        {
            _scenarioContext.Set(table.CreateInstance<ChargingSpot>);
        }

        [When(@"the user tries to delete the existing charging spot")]
        public void WhenTheUserTriesToDeleteTheExistingChargingSpot()
        {
            RunFilterWithoutAdminToken();
            IActionResult authFilterResult = _scenarioContext.Get<IActionResult>();

            if (authFilterResult == null)
            {
                ChargingSpot existing = _scenarioContext.Get<ChargingSpot>();
                IActionResult result = _chargingSpotController.DeleteChargingSpot(existing.Id);
                _scenarioContext.Set(result);
            }
        }


        [Then(@"the error 'You must be logged in to delete a charging spot' should be raised")]
        public void ThenTheErrorYouMustNeLoggedIntoDeleteAChargingSpotShouldBeRaised()
        {
            IActionResult authFilterResult = _scenarioContext.Get<IActionResult>();
            JsonResult parsedResult = authFilterResult as JsonResult;
            Assert.IsNotNull(parsedResult, "No error was raised");
            Assert.IsTrue(parsedResult.StatusCode == StatusCodes.Status401Unauthorized);
            Assert.IsTrue(parsedResult.Value == "Please send your authorization token");

            _actualException = null;
        }

        #region
        private void RunFilterWithoutAdminToken()
        {
            Mock<IAuthenticationManager> authenticationManagerMock = new Mock<IAuthenticationManager>();
            AdministratorAuthorizationFilter filter = new AdministratorAuthorizationFilter(authenticationManagerMock.Object);

            Mock<IServiceProvider> serviceProviderMock = new Mock<IServiceProvider>();
            Mock<HttpContext> httpContextMock = new Mock<HttpContext>();
            httpContextMock.SetupGet(context => context.RequestServices)
                .Returns(serviceProviderMock.Object);
            httpContextMock.SetupGet(context => context.Request.Headers["Authorization"]).Returns(StringValues.Empty);
            ActionContext actionContextMock = new ActionContext(httpContextMock.Object, new Microsoft.AspNetCore.Routing.RouteData(),
                                                                 new Microsoft.AspNetCore.Mvc.Abstractions.ActionDescriptor());
            AuthorizationFilterContext authFilterContext = new AuthorizationFilterContext(actionContextMock, new List<IFilterMetadata>());

            AdministratorAuthorizationFilter administratorAuthorizationFilter = new AdministratorAuthorizationFilter(authenticationManagerMock.Object);
            administratorAuthorizationFilter.OnAuthorization(authFilterContext);
            _scenarioContext.Set(authFilterContext.Result);
        }
        #endregion
    }
}
