using ORS.Apps.Regions.Models;

namespace ORS.Apps.Regions.Entities;

public class RegionEntity() {
    public int id { get; set; }

    public string name { get; set; }
    
    public int? ParentId { get; set; }
    public int Rank { get; set; }

    public Dictionary<string, string> names { get; } = new();

    public RegionEntity(Region region) : this() {
        id = region.Id;
        name = region.Name;
        ParentId = region.ParentId;
        Rank = region.Order;
        
        names["uzl"] = region.NameUzl;
        names["uzk"] = region.NameUzk;
        names["ru"] = region.NameRu;
    }
}