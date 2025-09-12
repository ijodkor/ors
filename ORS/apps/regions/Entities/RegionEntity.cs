using ORS.Apps.Regions.Models;

namespace ORS.Apps.Regions.Entities;

public class RegionEntity() {
    public int id { get; set; }

    public string name { get; set; }
    
    public int? ParentId { get; set; }
    public int Order { get; set; }
    public double Latitude { get; set; }
    public double Longitude { get; set; }

    public Dictionary<string, string> names { get; } = new();

    public RegionEntity(Region region) : this() {
        id = region.Id;
        name = region.Name;
        ParentId = region.ParentId;
        Order = region.Order;
        Latitude = region.Latitude;
        Longitude = region.Longitude;
        
        names["uzl"] = region.NameUzl;
        names["uzk"] = region.NameUzk;
        names["ru"] = region.NameRu;
    }
}
