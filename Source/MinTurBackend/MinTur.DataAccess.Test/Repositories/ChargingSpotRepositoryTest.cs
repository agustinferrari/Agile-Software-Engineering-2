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
            int inexistentChargingSpot = -4;
            _repository.DeleteChargingSpotById(inexistentChargingSpot);
        }

        [TestMethod]
        [ExpectedException(typeof(ResourceNotFoundException))]
        public void GetChargingSpotByIdWhichDoesntExistThrowsException()
        {
            int inexistentChargingSpot = -3;
            _repository.GetChargingSpotById(inexistentChargingSpot);
        }

        [TestMethod]
        public void GetChargingSpotByIdReturnsAsExpected()
        {
            ChargingSpot expectedChargingSpot = CreateChargingSpot();
            _context.ChargingSpots.Add(expectedChargingSpot);
            _context.SaveChanges();

            ChargingSpot retrievedChargingSpot = _repository.GetChargingSpotById(expectedChargingSpot.Id);
            Assert.IsTrue(expectedChargingSpot.Equals(retrievedChargingSpot));
        }

        [TestMethod]
        public void StoreChargingSpotReturnsAsExpected()
        {
            ChargingSpot chargingSpot = LoadRelatedEntitiesAndCreateChargingSpot();
            int newChargingSpot= _repository.StoreChargingSpot(chargingSpot);

            Assert.AreEqual(chargingSpot.Id, newChargingSpot);
            Assert.IsNotNull(_context.ChargingSpots.Where(cs => cs.Id == newChargingSpot).FirstOrDefault());
        }

        [TestMethod]
        [ExpectedException(typeof(ResourceNotFoundException))]
        public void StoreChargingSpotNonExistentRegion()
        {
            ChargingSpot chargingSpot = LoadRelatedEntitiesAndCreateChargingSpot();
            chargingSpot.RegionId = -4;

            _repository.StoreChargingSpot(chargingSpot);
        }

        [TestMethod]
        public void GetAllReservationsOnEmptyRepository()
        {
            List<ChargingSpot> expectedReservations = new List<ChargingSpot>();
            List<ChargingSpot> retrievedChargingSpots = _repository.GetAllChargingSpots();

            CollectionAssert.AreEqual(expectedReservations, retrievedChargingSpots);
        }

        [TestMethod]
        public void GetAllReservationsReturnsAsExpected()
        {
            List<ChargingSpot> expectedChargingSpots = new List<ChargingSpot>();
            LoadChargingSpots(expectedChargingSpots);

            List<ChargingSpot> retrievedChargingSpots = _repository.GetAllChargingSpots();
            CollectionAssert.AreEqual(expectedChargingSpots, retrievedChargingSpots);
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

        public ChargingSpot LoadRelatedEntitiesAndCreateChargingSpot()
        {
            Region region = new Region() { Name = "Metropolitana" };

            _context.Regions.Add(region);
            _context.SaveChanges();
            _context.Entry(region).State = EntityState.Detached;

            ChargingSpot newChargingSpot = new ChargingSpot()
            {
                Address = "Direccion",
                Description = "Descripcion ....",
                Name = "Punto carga",
                RegionId = region.Id
            };

            return newChargingSpot;
        }

        public List<ChargingSpot> LoadRelatedEntitiesAndCreateChargingSpotsWithRegion()
        {
            Region region = new Region() { Name = "Metropolitana" };
            Region region2 = new Region() { Name = "Centro" };

            _context.Regions.Add(region);
            _context.Regions.Add(region2);
            _context.SaveChanges();
            _context.Entry(region).State = EntityState.Detached;
            _context.Entry(region2).State = EntityState.Detached;

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
                Region= region2
            };

            return new List<ChargingSpot>() { newChargingSpot1, newChargingSpot2 };
        }


        private void LoadChargingSpots(List<ChargingSpot> chargingSpots)
        {
            List<ChargingSpot> chargingSpotsloaded = LoadRelatedEntitiesAndCreateChargingSpotsWithRegion();
            foreach (ChargingSpot chargingSpot in chargingSpotsloaded)
            {
                Region aux = chargingSpot.Region;
                chargingSpot.RegionId = chargingSpot.Region.Id;
                chargingSpot.Region = null;
                _context.ChargingSpots.Add(chargingSpot);
                _context.SaveChanges();
                chargingSpot.Region = aux;
                chargingSpots.Add(chargingSpot);
            }
        }
        #endregion
    }
}
