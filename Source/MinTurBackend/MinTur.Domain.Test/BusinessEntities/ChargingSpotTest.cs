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
                Name = "Cargar parada!#",
                Address = "General Flores",
                RegionId = 1,
                Description = "Punto de carga",
            };

            chargingSpot.ValidOrFail();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidRequestDataException))]
        public void ChargingSpotWithInvalidAddressLengthFails()
        {
            ChargingSpot chargingSpot = new ChargingSpot()
            {
                Name = "Cargar parada 2",
                Address = "General Flores General Flores General Flores",
                RegionId = 1,
                Description = "Punto de carga",
            };

            chargingSpot.ValidOrFail();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidRequestDataException))]
        public void ChargingSpotWithInvalidAddressFormatFails()
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

        [TestMethod]
        [ExpectedException(typeof(InvalidRequestDataException))]
        public void ChargingSpotWithInvalidDescriptionLengthFails()
        {
            ChargingSpot chargingSpot = new ChargingSpot()
            {
                Name = "Cargar parada",
                Address = "General Flores",
                RegionId = 1,
                Description = "Punto de carga Punto de carga Punto de carga Punto de carga Punto de carga",
            };

            chargingSpot.ValidOrFail();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidRequestDataException))]
        public void ChargingSpotWithInvalidDescriptionFormatFails()
        {
            ChargingSpot chargingSpot = new ChargingSpot()
            {
                Name = "Cargar parada",
                Address = "General Flores",
                RegionId = 1,
                Description = "Punto de carga#!",
            };

            chargingSpot.ValidOrFail();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidRequestDataException))]
        public void ChargingSpotWithNullNameFails()
        {
            ChargingSpot chargingSpot = new ChargingSpot()
            {
                Name = "",
                Address = "General Flores",
                RegionId = 1,
                Description = "Punto de carga",
            };

            chargingSpot.ValidOrFail();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidRequestDataException))]
        public void ChargingSpotWithNullAddressFails()
        {
            ChargingSpot chargingSpot = new ChargingSpot()
            {
                Name = "Cargar parada",
                Address = "",
                RegionId = 1,
                Description = "Punto de carga",
            };

            chargingSpot.ValidOrFail();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidRequestDataException))]
        public void ChargingSpotWithNullDescriptionFails()
        {
            ChargingSpot chargingSpot = new ChargingSpot()
            {
                Name = "Cargar parada",
                Address = "General Flores",
                RegionId = 1,
                Description = "",
            };

            chargingSpot.ValidOrFail();
        }
    }
}