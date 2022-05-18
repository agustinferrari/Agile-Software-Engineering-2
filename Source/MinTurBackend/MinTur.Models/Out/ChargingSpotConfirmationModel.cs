using MinTur.Domain.BusinessEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MinTur.Models.Out
{
    public class ChargingSpotConfirmationModel
    {
        public string UniqueCode { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }


        public ChargingSpotConfirmationModel(ChargingSpot chargingSpot)
        {
            UniqueCode = chargingSpot.Id.ToString();
            Name = chargingSpot.Name;
            Address = chargingSpot.Address;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || obj.GetType() != GetType())
                return false;

            var reservationConfirmationModel = obj as ChargingSpotConfirmationModel;
            return UniqueCode == reservationConfirmationModel.UniqueCode;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(UniqueCode);
        }
    }
}
