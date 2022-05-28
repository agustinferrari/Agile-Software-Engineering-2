using MinTur.BusinessLogicInterface.ResourceManagers;
using MinTur.DataAccessInterface.Facades;
using MinTur.Domain.BusinessEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MinTur.BusinessLogic.ResourceManagers
{
    public class ChargingSpotManager : IChargingSpotManager
    {
        IRepositoryFacade _repositoryFacade;
        public ChargingSpotManager(IRepositoryFacade repositoryFacade){
            _repositoryFacade  = repositoryFacade;
        }
        public void DeleteChargingSpotById(int id)
        {
            _repositoryFacade.DeleteChargingSpotById(id);
        }

        public ChargingSpot RegisterChargingSpot(ChargingSpot chargingSpot)
        {
            chargingSpot.ValidOrFail();
            int newChargingSpotId = _repositoryFacade.StoreChargingSpot(chargingSpot);
            ChargingSpot createdChargingSpot = _repositoryFacade.GetChargingSpotById(newChargingSpotId);

            return createdChargingSpot;
        }

        public List<ChargingSpot> GetAllChargingSpots()
        {
            return _repositoryFacade.GetAllChargingSpots();
        }
    }
}
