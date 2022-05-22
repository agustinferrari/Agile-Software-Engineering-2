using MinTur.Domain.BusinessEntities;

namespace MinTur.DataAccessInterface.Repositories
{
    public interface IChargingSpotRepository
    {
        void DeleteChargingSpotById(int chargingSpotId);
        int StoreChargingSpot(ChargingSpot chargingSpot);
        ChargingSpot GetChargingSpotById(int chargingSpotId);

    }
}