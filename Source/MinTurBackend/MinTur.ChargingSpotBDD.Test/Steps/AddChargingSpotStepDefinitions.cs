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
    public class AddChargingSpotStepDefinitions
    {

        private readonly ScenarioContext _scenarioContext;
        private ChargingSpotController _chargingSpotController;
        private ChargingSpotManager _chargingSpotManager;
        private Exception _actualException;

        public AddChargingSpotStepDefinitions(ScenarioContext context)
        {
            _scenarioContext = context;
            _chargingSpotManager = new ChargingSpotManager();
            _chargingSpotController = new ChargingSpotController(_chargingSpotManager);
        }

        [Given(@"a new ChargingSpot:")]
        public void GivenANewChargingSpot(Table table)
        {
            _scenarioContext.Set(table.CreateInstance<ChargingSpotIntentModel>());
        }

        [When(@"the user tries to add the new charging spot")]
        public void WhenTheUserTriesToAddTheNewChargingSpot()
        {
            RunFilterWithoutAdminToken();
            IActionResult authFilterResult = _scenarioContext.Get<IActionResult>();

            if (authFilterResult == null)
            {
                ChargingSpotIntentModel chargingSpot = _scenarioContext.Get<ChargingSpotIntentModel>();
                IActionResult result = _chargingSpotController.CreateChargingSpot(chargingSpot);
                _scenarioContext.Set(result);
            }
        }

        [Then(@"an error '([^']*)' should be raised")]
        public void ThenAnErrorShouldBeRaised(string expectedErrorMessage)
        {
            IActionResult result = _scenarioContext.Get<IActionResult>();
            JsonResult parsedResult = result as JsonResult;
            Assert.IsNotNull(parsedResult);
            Assert.AreEqual(parsedResult.StatusCode, StatusCodes.Status401Unauthorized);
            Assert.AreEqual(parsedResult.Value,expectedErrorMessage);
        }

        #region Helpers
        private void RunFilterWithoutAdminToken() {
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
