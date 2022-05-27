using System;
using TechTalk.SpecFlow;

namespace IntegrationTests.Steps
{
    [Binding]
    public class CommonStepDefinitions
    {
        private readonly ScenarioContext _scenarioContext;

        public CommonStepDefinitions(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [Given(@"a logged in admin")]
        public void GivenALoggedInAdmin(Table admin)
        {
            _scenarioContext.Pending();
        }

        [Given(@"an existing region")]
        public void GivenAnExistingRegion(Table region)
        {
            _scenarioContext.Pending();
        }

        [Then(@"the error (.*) should be raised")]
        public void ThenTheErrorShouldBeRaised(string error)
        {
            _scenarioContext.Pending();
        }
    }
}