using Microsoft.VisualStudio.TestTools.UnitTesting;
using MinTur.Domain.BusinessEntities;
using MinTur.Models.In;
using System;
using System.Collections.Generic;
using System.Text;

namespace MinTur.Models.Test.In
{
    [TestClass]
    public class ChargingSpotIntentModelTest
    {
        [TestMethod]
        public void ToEntityReturnsAsExpected()
        {
            ChargingSpotIntentModel chargingSpotIntentModel = new ChargingSpotIntentModel()
            {
                Name = "Cargador Ancap",
                Address = "General Flores 1232",
                RegionId = 1,
                Description = "Cargador Ancap descripcion"
            };
            ChargingSpot chargingSpot = chargingSpotIntentModel.ToEntity();

            Assert.IsTrue(chargingSpotIntentModel.Name == chargingSpot.Name);
            Assert.IsTrue(chargingSpotIntentModel.Address == chargingSpot.Address);
            Assert.IsTrue(chargingSpotIntentModel.RegionId == chargingSpot.RegionId);
            Assert.IsTrue(chargingSpotIntentModel.Description == chargingSpot.Description);
        }
    }
}
