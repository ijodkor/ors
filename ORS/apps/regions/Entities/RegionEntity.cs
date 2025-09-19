using ORS.Apps.Regions.Models;

namespace ORS.Apps.Regions.Entities;

public class RegionEntity() {
    public int id { get; set; }
    
    public int? ParentId { get; set; }
    public int Order { get; set; }
    public double Latitude { get; set; }
    public double Longitude { get; set; }

    public Dictionary<string, string> Name { get; } = new();
    public Dictionary<string, string> ShortName { get; set; } = new();

    public RegionEntity(Region region) : this() {
        id = region.Id;
        ParentId = region.ParentId;
        Order = region.Order;
        Latitude = region.Latitude;
        Longitude = region.Longitude;
        
        Name["uz"] = region.NameUzl;
        Name["uzc"] = region.NameUzk;
        Name["ru"] = region.NameRu;
        Name["en"] = region.Name;
        Name["kaa"] = region.NameUzk;

        ShortName = region.ShortName;
    }
}
