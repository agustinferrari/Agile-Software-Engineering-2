using System;
using System.Collections.Generic;
using System.Text;

namespace MinTur.Domain.BusinessEntities
{
    public class ChargingSpot
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public Region Region { get; set; }
        public int RegionId { get; set; }
        public string Description { get; set; }
    }
}
