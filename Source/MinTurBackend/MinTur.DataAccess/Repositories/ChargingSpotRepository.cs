using Microsoft.EntityFrameworkCore;
using MinTur.DataAccessInterface.Repositories;
using MinTur.Domain.BusinessEntities;
using MinTur.Exceptions;
using System;
using System.Linq;

namespace MinTur.DataAccess.Repositories
{
    public class ChargingSpotRepository : IChargingSpotRepository
    {
        protected DbContext Context { get; set; }

        public ChargingSpotRepository(DbContext dbContext)
        {
            Context = dbContext;
        }

        public void DeleteChargingSpotById(int chargingSpotId)
        {
            ChargingSpot chargingSpotFromDb = Context.Set<ChargingSpot>().FirstOrDefault(c => c.Id == chargingSpotId);

            if (chargingSpotFromDb == null)
            {
                throw new ResourceNotFoundException("Could not find specified charging spot");
            }

            Context.Set<ChargingSpot>().Remove(chargingSpotFromDb);
            Context.SaveChanges();
        }

        public int StoreChargingSpot(ChargingSpot chargingSpot)
        {
            if (!RegionExists(chargingSpot.RegionId))
                throw new ResourceNotFoundException("Could not find specified region");

            chargingSpot.Region = Context.Set<Region>().Where(r => r.Id == chargingSpot.RegionId).FirstOrDefault();
            StoreChargingSpotInDb(chargingSpot);

            return chargingSpot.Id;
        }

        public ChargingSpot GetChargingSpotById(int chargingSpotId)
        {
            if (!ChargingSpotExists(chargingSpotId))
                throw new ResourceNotFoundException("Could not find specified charging spot");

            ChargingSpot retrievedChargingSpot = Context.Set<ChargingSpot>().AsNoTracking().Where(cs => cs.Id == chargingSpotId).Include(cs => cs.Region)
                .FirstOrDefault();

            return retrievedChargingSpot;
        }

        private bool ChargingSpotExists(int chargingSpotId)
        {
            ChargingSpot chargingSpot = Context.Set<ChargingSpot>().AsNoTracking().Where(cs => cs.Id == chargingSpotId).FirstOrDefault();
            return chargingSpot != null;
        }

        private bool RegionExists(int regionId)
        {
            Region region = Context.Set<Region>().AsNoTracking().Where(r => r.Id == regionId).FirstOrDefault();
            return region != null;
        }

        private void StoreChargingSpotInDb(ChargingSpot chargingSpot)
        {
            Context.Entry(chargingSpot.Region).State = EntityState.Unchanged;

            Context.Set<ChargingSpot>().Add(chargingSpot);
            Context.SaveChanges();

            Context.Entry(chargingSpot.Region).State = EntityState.Detached;
        }
    }
}