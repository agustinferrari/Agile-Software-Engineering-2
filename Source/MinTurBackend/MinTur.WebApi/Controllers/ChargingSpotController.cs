using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
using MinTur.BusinessLogicInterface.ResourceManagers;
using MinTur.Domain.BusinessEntities;
using MinTur.Models.Out;
using System.Collections.Generic;
using System.Linq;
using MinTur.WebApi.Filters;
using MinTur.Models.In;

namespace MinTur.WebApi.Controllers
{
    [EnableCors("AllowEverything")]
    [Route("api/chargingSpots")]
    [ApiController]
    [ServiceFilter(typeof(AdministratorAuthorizationFilter))]
    public class ChargingSpotController : ControllerBase
    {
        private readonly IChargingSpotManager _chargingSpotManager;

        public ChargingSpotController(IChargingSpotManager regionManager)
        {
            _chargingSpotManager = regionManager;
        }

        [HttpPost]
        public IActionResult CreateChargingSpot([FromBody] ChargingSpotIntentModel chargingSpotIntentModel)
        {
            ChargingSpot createdChargingSpot = _chargingSpotManager.RegisterChargingSpot(chargingSpotIntentModel.ToEntity());
            ChargingSpotConfirmationModel confirmation = new ChargingSpotConfirmationModel(createdChargingSpot);
            return Created("api/chargingSpots/" + createdChargingSpot.Id, confirmation);
        }

        [HttpDelete]
        public IActionResult DeleteChargingSpot([FromRoute] int existingChargingSpotId)
        {
            _chargingSpotManager.DeleteChargingSpotById(existingChargingSpotId);
            return Ok(new { ResultMessage = $"Charging spot {existingChargingSpotId} succesfuly deleted" });
        }
    }
}
