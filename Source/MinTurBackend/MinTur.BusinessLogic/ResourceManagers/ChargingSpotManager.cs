using MinTur.BusinessLogicInterface.ResourceManagers;
using MinTur.Domain.BusinessEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MinTur.BusinessLogic.ResourceManagers
{
    public class ChargingSpotManager : IChargingSpotManager
    {
        public ChargingSpot RegisterChargingSpot(ChargingSpot chargingSpot)
        {
            return new ChargingSpot();
        }
    }
}
