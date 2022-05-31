namespace IntegrationTests.Models;
public class ChargingSpot
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }
    public int RegionId { get; set; }
    public string RegionName { get; set; }
    public string Description { get; set; }

    public override bool Equals(object obj)
    {
        return obj is ChargingSpot spot &&
               /*Id == spot.Id &&*/
               Name == spot.Name &&
               Address == spot.Address &&
               (RegionId == spot.RegionId ||
               RegionName == spot.RegionName) &&
               Description == spot.Description;
    }

}