using ORS.Apps.Regions.Models;

namespace ORS.Apps.Regions.Entities;

public class District() {
    public int Id { get; set; }

    public string Name { get; set; }
    public string ShortName { get; set; }

    public int? ProvinceId { get; set; }
    public int? RegionId { get; set; }

    private Dictionary<string, string> Names { get; } = new();

    public District(Region region, string lang) : this() {
        Id = region.Id;
        ProvinceId = region.ParentId;
        RegionId = region.ParentId;
        
        Name = region.NameUzl;
        ShortName = region.Name;

        Names["uz"] = region.NameUzl;
        Names["uzc"] = region.NameUzk;
        Names["ru"] = region.NameRu;
        Names["en"] = region.Name;
        Names["kaa"] = region.Name;
        
        if (Names.ContainsKey(lang)) {
            Name = Names[lang];
        }
    }
}