using MinTur.Domain.BusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MinTur.Models.Out
{
    public class ChargingSpotDetailsModel
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string RegionName { get; set; }

        public ChargingSpotDetailsModel(ChargingSpot chargingSpot) 
        {
            Id = chargingSpot.Id;
            Name = chargingSpot.Name;
            Description = chargingSpot.Description;
            Address = chargingSpot.Address;
            RegionName = chargingSpot.Region.Name;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || obj.GetType() != GetType())
                return false;

            var chargingSpotDetailsModel = obj as ChargingSpotDetailsModel;
            return Id == chargingSpotDetailsModel.Id &&
                    Name == chargingSpotDetailsModel.Name;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id);
        }
    }
}
