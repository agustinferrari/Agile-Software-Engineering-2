using MinTur.BusinessLogicInterface.ResourceManagers;
using MinTur.Domain.BusinessEntities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MinTur.Models.In;
using MinTur.Models.Out;
using Moq;
using System;
using System.Collections.Generic;
using MinTur.WebApi.Controllers;
using MinTur.Domain.Reports;
using System.Linq;

namespace MinTur.WebApi.Test.Controllers
{
    [TestClass]
    public class ChargingSpotControllerTest
    {
        private List<ChargingSpot> _chargingSpots;
        private List<ChargingSpotDetailsModel> _chargingSpotDetailsModels;
        private Mock<IChargingSpotManager> _chargingSpotManagerMock;

        #region SetUp
        [TestInitialize]
        public void SetUp()
        {
            _chargingSpots = new List<ChargingSpot>();
            _chargingSpotDetailsModels = new List<ChargingSpotDetailsModel>();
            _chargingSpotManagerMock = new Mock<IChargingSpotManager>(MockBehavior.Strict);
            
            LoadChargingSpots();
            LoadChargingSpotModels();
        }

        private void LoadChargingSpots()
        {
            List<ChargingSpot> chargingSpots = CreateChargingSpots();
            _chargingSpots = chargingSpots;
        }


        private void LoadChargingSpotModels()
        {
            foreach (ChargingSpot chargingSpot in _chargingSpots)
            {
                _chargingSpotDetailsModels.Add(new ChargingSpotDetailsModel(chargingSpot));
            }
        }
        #endregion

        [TestMethod]
        public void MakeReservationCreatedTest()
        {
            ChargingSpotIntentModel chargingSpotIntentModel = CreateChargingSpotIntentModel();
            ChargingSpot createdChargingSpot = CreateChargingSpotWithSpecificId();

            _chargingSpotManagerMock.Setup(r => r.RegisterChargingSpot(It.IsAny<ChargingSpot>())).Returns(createdChargingSpot);
            ChargingSpotController chargingSpotController = new ChargingSpotController(_chargingSpotManagerMock.Object);

            IActionResult result = chargingSpotController.CreateChargingSpot(chargingSpotIntentModel);
            CreatedResult createdResult = result as CreatedResult;

            _chargingSpotManagerMock.VerifyAll();
            Assert.IsTrue(createdResult.Value.Equals(new ChargingSpotConfirmationModel(createdChargingSpot)));
        }

        [TestMethod]
        public void DeleteChargingSpotOkTest()
        {
            int existingChargingSpotId = 1;
            string succesfulDeletitionMessage = new { ResultMessage = $"Charging spot {existingChargingSpotId} succesfuly deleted" }.ToString();

            _chargingSpotManagerMock.Setup(r => r.DeleteChargingSpotById(It.IsAny<int>()));
            ChargingSpotController chargingSpotController = new ChargingSpotController(_chargingSpotManagerMock.Object);

            IActionResult result = chargingSpotController.DeleteChargingSpot(existingChargingSpotId);
            OkObjectResult okResult = result as OkObjectResult;

            string retrievedResultMessage = okResult.Value.ToString();
            _chargingSpotManagerMock.VerifyAll();
            Assert.AreEqual(succesfulDeletitionMessage, retrievedResultMessage);
        }

        [TestMethod]
        public void GetAllChargingSpotsOkTest()
        {
            _chargingSpotManagerMock.Setup(c => c.GetAllChargingSpots()).Returns(_chargingSpots);
            ChargingSpotController chargingSpotController = new ChargingSpotController(_chargingSpotManagerMock.Object);

            IActionResult result = chargingSpotController.GetAll();
            OkObjectResult okResult = result as OkObjectResult;
            List<ChargingSpotDetailsModel> responseModel = okResult.Value as List<ChargingSpotDetailsModel>;

            _chargingSpotManagerMock.VerifyAll();
            CollectionAssert.AreEquivalent(responseModel, _chargingSpotDetailsModels);
        }

        #region Helpers
        private ChargingSpotIntentModel CreateChargingSpotIntentModel()
        {
            return new ChargingSpotIntentModel()
            {
                Name = "Cargador Ancap",
                Address = "General Flores 1232",
                RegionId = 1,
                Description = "Cargador Ancap descripcion"
            };
        }

        private ChargingSpot CreateChargingSpotWithSpecificId()
        {
            ChargingSpot chargingSpot = new ChargingSpot()
            {
                Id = 1,
                Name = "Cargador Ancap",
                Address = "General Flores 1232",
                Region = new Region()
                {
                    Id = 1,
                    Name = "SurOeste"
                },
                Description = "Cargador Ancap descripcion"
            };

            return chargingSpot;
        }

        public List<ChargingSpot> CreateChargingSpots()
        {
            Region region = new Region() { Name = "Metropolitana" };
            Region region2 = new Region() { Name = "Centro" };

            ChargingSpot newChargingSpot1 = new ChargingSpot()
            {
                Address = "Direccion",
                Description = "Descripcion ....",
                Name = "Punto carga 1",
                Region = region
            };
            ChargingSpot newChargingSpot2 = new ChargingSpot()
            {
                Address = "Direccion",
                Description = "Descripcion ....",
                Name = "Punto carga 2",
                Region = region2
            };

            return new List<ChargingSpot>() { newChargingSpot1, newChargingSpot2 };
        }
        #endregion

    }
}