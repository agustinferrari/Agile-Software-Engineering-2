using MinTur.Domain.BusinessEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MinTur.BusinessLogicInterface.ResourceManagers
{
    public interface IChargingSpotManager
    {
        ChargingSpot RegisterChargingSpot(ChargingSpot chargingSpot);
        void DeleteChargingSpotById(int id);

    }
}
