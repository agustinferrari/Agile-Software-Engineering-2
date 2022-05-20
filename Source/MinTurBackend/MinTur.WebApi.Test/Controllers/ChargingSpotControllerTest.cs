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
        private Mock<IChargingSpotManager> _chargingSpotManagerMock;

        #region SetUp
        [TestInitialize]
        public void SetUp()
        {
            _chargingSpotManagerMock = new Mock<IChargingSpotManager>(MockBehavior.Strict);
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
            _chargingSpotManagerMock.Setup(r => r.DeleteChargingSpotById(It.IsAny<int>()));
            ChargingSpotController chargingSpotController = new ChargingSpotController(_chargingSpotManagerMock.Object);

            IActionResult result = chargingSpotController.DeleteChargingSpot(existingChargingSpotId);
            CreatedResult createdResult = result as CreatedResult;

            _chargingSpotManagerMock.VerifyAll();
            JsonResult parsedResult = createdResult.Value as JsonResult;
            Assert.IsTrue(parsedResult.Value.Equals( $"Administrator {existingChargingSpotId} succesfuly deleted"));
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
        #endregion

    }
}