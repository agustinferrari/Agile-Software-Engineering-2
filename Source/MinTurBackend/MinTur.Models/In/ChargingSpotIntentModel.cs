using MinTur.Domain.BusinessEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MinTur.Models.In
{
    public class ChargingSpotIntentModel
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public int RegionId { get; set; }
        public string Description { get; set; }

        public ChargingSpot ToEntity()
        {
            return new ChargingSpot
            {
                Name = Name,
                Address = Address,
                RegionId = RegionId,
                Description = Description
            };
        }
    }
}
