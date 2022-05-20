using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MinTur.BusinessLogic.ResourceManagers;
using MinTur.DataAccessInterface.Facades;
using MinTur.Domain.BusinessEntities;
using System.Collections.Generic;
using MinTur.Exceptions;
using System.Linq;

namespace MinTur.BusinessLogic.Test.ResourceManagers
{
    [TestClass]
    public class ChargingSpotManagerTest
    {
        private List<ChargingSpot> _chargingSpots;
        private Mock<IRepositoryFacade> _repositoryFacadeMock;
        private Mock<Administrator> _administratorMock;

        #region SetUp
        [TestInitialize]
        public void SetUp()
        {
            _chargingSpots = new List<ChargingSpot>();
            _repositoryFacadeMock = new Mock<IRepositoryFacade>(MockBehavior.Strict);
            _administratorMock = new Mock<Administrator>(MockBehavior.Strict);

            LoadAdministrators();
        }

        private void LoadAdministrators()
        {
            Region testRegion = new Region() { Id = 1, Name = "TestName" };
            ChargingSpot administrator1 = new ChargingSpot()
            {
                Id = 1,
                Name = "TestSpotOne",
                Address = "TestAddressOne",
                Region = testRegion,
                RegionId = 1,
                Description = "TestChargingSpotDescription"
            };
            _chargingSpots.Add(administrator1);
        }

        #endregion


        [TestMethod]
        public void DeleteChargingSpotByIdDoesAsExpected()
        {
            ChargingSpot chargingSpotToDelete = _chargingSpots.FirstOrDefault();
            _repositoryFacadeMock.Setup(r => r.DeleteChargingSpotById(chargingSpotToDelete.Id));

            ChargingSpotManager chargingSpotManager = new ChargingSpotManager(_repositoryFacadeMock.Object);
            chargingSpotManager.DeleteChargingSpotById(chargingSpotToDelete.Id);

            _repositoryFacadeMock.VerifyAll();
        }


        #region Helpers

        public Administrator CreateAdministratorWithSpecificId(int id)
        {
            return new Administrator()
            {
                Id = id,
                Email = "email@email.com",
                Password = "password"
            };
        }

        #endregion
    }
}