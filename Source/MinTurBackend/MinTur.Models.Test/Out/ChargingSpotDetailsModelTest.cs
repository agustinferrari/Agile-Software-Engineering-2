using MinTur.Domain.BusinessEntities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MinTur.Models.Out;
using System;
using System.Linq;

namespace MinTur.Models.Test.Out
{
    [TestClass]
    public class ChargingSpotDetailsModelTest
    {
        [TestMethod]
        public void ChargingSpotDetailsModelGetsCreatedAsExpected() 
        {
            Region region = new Region() { Name = "Metropolitana" };

            ChargingSpot chargingSpot = new ChargingSpot()
            {
                Address = "Direccion",
                Description = "Descripcion ....",
                Name = "Punto carga 1",
                Region = region
            };

            ChargingSpotDetailsModel chargingSpotModel = new ChargingSpotDetailsModel(chargingSpot);

            Assert.AreEqual(chargingSpot.Id, chargingSpotModel.Id);
            Assert.AreEqual(chargingSpot.Name, chargingSpotModel.Name);
            Assert.AreEqual(chargingSpot.Description, chargingSpotModel.Description);
            Assert.AreEqual(chargingSpot.Region.Name, chargingSpotModel.RegionName);
        }
    }
}
