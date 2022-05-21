using MinTur.DataAccess.Contexts;
using MinTur.DataAccess.Repositories;
using MinTur.Domain.BusinessEntities;
using MinTur.Exceptions;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MinTur.DataAccess.Test.Repositories
{
    [TestClass]
    public class ChargingSpotRepositoryTest
    {
        private ChargingSpotRepository _repository;
        private NaturalUruguayContext _context;

        [TestInitialize]
        public void SetUp()
        {
            _context = ContextFactory.GetNewContext(ContextType.Memory);
            _repository = new ChargingSpotRepository(_context);
        }

        [TestCleanup]
        public void CleanUp()
        {
            _context.Database.EnsureDeleted();
        }

        [TestMethod]
        public void DeleteChargingSpotReturnsAsExpected()
        {
            ChargingSpot chargingSpotToBeDeleted = CreateChargingSpot();
            _context.Set<Region>().Add(chargingSpotToBeDeleted.Region);
            _context.Set<ChargingSpot>().Add(chargingSpotToBeDeleted);
            _context.SaveChanges();

            _repository.DeleteChargingSpotById(chargingSpotToBeDeleted.Id);
            Region regionInDb = _context.Set<Region>().ToList()[0];
            List<ChargingSpot> chargingSpotsInDB = _context.Set<ChargingSpot>().ToList();
            Assert.AreEqual(0, chargingSpotsInDB.Count);
            Assert.AreEqual(chargingSpotToBeDeleted.Region, regionInDb);
        }

        [TestMethod]
        [ExpectedException(typeof(ResourceNotFoundException))]
        public void DeleteChargingSpotWhichDoesntExist()
        {
            _repository.DeleteChargingSpotById(-4);
        }

        #region Helpers
        private ChargingSpot CreateChargingSpot()
        {
            return new ChargingSpot()
            {
                Address = "Direccion",
                Description = "Descripcion ....",
                Name = "Hotel Italiano carga",
                Region = new Region()
                {
                    Name = "SurOeste"
                }
            };
        }

        #endregion
    }
}
