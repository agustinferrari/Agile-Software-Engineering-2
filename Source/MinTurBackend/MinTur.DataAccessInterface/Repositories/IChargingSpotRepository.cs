using MinTur.Domain.BusinessEntities;
using System.Collections.Generic;

namespace MinTur.DataAccessInterface.Repositories
{
    public interface IChargingSpotRepository
    {
        void DeleteChargingSpotById(int chargingSpotId);
        int StoreChargingSpot(ChargingSpot chargingSpot);
        ChargingSpot GetChargingSpotById(int chargingSpotId);
        List<ChargingSpot> GetAllChargingSpots();
    }
}