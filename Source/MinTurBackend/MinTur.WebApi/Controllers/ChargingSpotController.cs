﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
using MinTur.BusinessLogicInterface.ResourceManagers;
using MinTur.Domain.BusinessEntities;
using MinTur.Models.Out;
using System.Collections.Generic;
using System.Linq;
using MinTur.WebApi.Filters;
using MinTur.Models.In;
using System;

namespace MinTur.WebApi.Controllers
{
    [EnableCors("AllowEverything")]
    [Route("api/chargingSpots")]
    [ApiController]
    public class ChargingSpotController : ControllerBase
    {
        private readonly IChargingSpotManager _chargingSpotManager;

        public ChargingSpotController(IChargingSpotManager chargingSpotManager)
        {
            _chargingSpotManager = chargingSpotManager;
        }

        [HttpPost]
        [ServiceFilter(typeof(AdministratorAuthorizationFilter))]
        public IActionResult CreateChargingSpot([FromBody] ChargingSpotIntentModel chargingSpotIntentModel)
        {
            ChargingSpot createdChargingSpot = _chargingSpotManager.RegisterChargingSpot(chargingSpotIntentModel.ToEntity());
            ChargingSpotConfirmationModel confirmation = new ChargingSpotConfirmationModel(createdChargingSpot);
            string route = "api/chargingSpots/";
            return Created(route + createdChargingSpot.Id, confirmation);
        }

        [HttpDelete("{id:int}")]
        [ServiceFilter(typeof(AdministratorAuthorizationFilter))]
        public IActionResult DeleteChargingSpot([FromRoute] int id)
        {
            _chargingSpotManager.DeleteChargingSpotById(id);
            return Ok(new { ResultMessage = $"Charging spot {id} succesfuly deleted" });
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            List<ChargingSpot> retrievedChargingSpots = _chargingSpotManager.GetAllChargingSpots();
            List<ChargingSpotDetailsModel> chargingSpotDetails = retrievedChargingSpots.Select(charingSpot => new ChargingSpotDetailsModel(charingSpot)).ToList();
            return Ok(chargingSpotDetails);
        }
    }
}
