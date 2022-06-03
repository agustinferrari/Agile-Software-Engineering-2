using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Primitives;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MinTur.BusinessLogicInterface.Security;
using MinTur.DataAccess.Contexts;
using MinTur.Models.In;
using MinTur.WebApi.Filters;
using Moq;
using System;
using System.Collections.Generic;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace MinTur.ChargingSpotBDD.Test.Steps
{
    [Binding]
    public class CommonStepDefinitions
    {
        private readonly ScenarioContext _scenarioContext;
        private readonly NaturalUruguayContext _dbContext;

        public CommonStepDefinitions(ScenarioContext context)
        {
            _scenarioContext = context;
            _dbContext = ContextFactory.GetNewContext(ContextType.Memory);
        }

        [Given(@"a non-logged in admin")]
        public void GivenANonLoggedInAdmin()
        {
            RunFilterWithoutAdminToken();
        }

        [Given(@"a logged in admin")]
        public void GivenAnExistingLoggedInAdmin(Table table)
        {
            _scenarioContext.Set(table.CreateInstance<AdministratorIntentModel>);
        }

        [Then(@"the error (.*) should be raised")]
        public void ThenAnErrorShouldBeRaised(string error)
        {
            string resultError = _scenarioContext.Get<string>("result");
            Assert.AreEqual(error, resultError);
            CleanUp();
        }

        #region Helpers
        private void RunFilterWithoutAdminToken()
        {
            Mock<IAuthenticationManager> authenticationManagerMock = new Mock<IAuthenticationManager>();

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
            _scenarioContext.Set(authFilterContext.Result, "auth");
        }
        #endregion

        [TestCleanup]
        public void CleanUp()
        {
            _dbContext.Database.EnsureDeleted();
        }
    }
}