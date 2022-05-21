using Microsoft.VisualStudio.TestTools.UnitTesting;
using MinTur.Domain.BusinessEntities;
using MinTur.Exceptions;

namespace MinTur.Domain.Test.BusinessEntities
{
    [TestClass]
    public class ChargingSpotTest
    {
        [TestMethod]
        [ExpectedException(typeof(InvalidRequestDataException))]
        public void ChargingSpotWithInvalidNameLengthFails()
        {
            ChargingSpot chargingSpot = new ChargingSpot()
            {
                Name = "Cargar parada 223 mas de 20 chars",
                Address = "General Flores",
                RegionId = 1,
                Description = "Punto de carga",
            };

            chargingSpot.ValidOrFail();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidRequestDataException))]
        public void ChargingSpotWithInvalidNameFormatFails()
        {
            ChargingSpot chargingSpot = new ChargingSpot()
            {
                Name = "Cargar parada",
                Address = "General Flores!#",
                RegionId = 1,
                Description = "Punto de carga",
            };

            chargingSpot.ValidOrFail();
        }
    }
}