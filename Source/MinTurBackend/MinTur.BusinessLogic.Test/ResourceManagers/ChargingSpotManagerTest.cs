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

        #region SetUp
        [TestInitialize]
        public void SetUp()
        {
            _chargingSpots = new List<ChargingSpot>();
            _repositoryFacadeMock = new Mock<IRepositoryFacade>(MockBehavior.Strict);

            LoadChargingSpots();
        }

        private void LoadChargingSpots()
        {
            Region testRegion = new Region() { Id = 1, Name = "TestName" };
            ChargingSpot chargingSpot1 = new ChargingSpot()
            {
                Id = 1,
                Name = "TestSpotOne",
                Address = "TestAddressOne",
                Region = testRegion,
                RegionId = 1,
                Description = "TestChargingSpotDescription"
            };
            _chargingSpots.Add(chargingSpot1);
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

        [TestMethod]
        public void GetAllChargingSpotsReturnsAsExpected()
        {
            _repositoryFacadeMock.Setup(r => r.GetAllChargingSpots()).Returns(_chargingSpots);

            ChargingSpotManager chargingSpotManager = new ChargingSpotManager(_repositoryFacadeMock.Object);
            List<ChargingSpot> retrievedChargingSpots = chargingSpotManager.GetAllChargingSpots();

            _repositoryFacadeMock.VerifyAll();
            CollectionAssert.AreEquivalent(retrievedChargingSpots, _chargingSpots);
        }

        #region Helpers

        public ChargingSpot CreateChargingSpotWithSpecificId(int id)
        {
            Region testRegion = new Region() { Id = 1, Name = "TestName" };
            return  new ChargingSpot()
            {
                Id = id,
                Name = "TestSpotOne",
                Address = "TestAddressOne",
                Region = testRegion,
                RegionId = 1,
                Description = "TestChargingSpotDescription"
            };
        }

        #endregion
    }
}