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
            throw new NotImplementedException();
        }

        public ChargingSpot GetChargingSpotById(int chargingSpotId)
        {
            throw new NotImplementedException();
        }
    }
}