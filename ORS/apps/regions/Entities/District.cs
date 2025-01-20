using ORS.Apps.Regions.Models;

namespace ORS.Apps.Regions.Entities;

public class District() {
    public int Id { get; set; }

    public string Name { get; set; }

    public int ProvinceId { get; set; }

    public Dictionary<string, string> Names { get; } = new();

    public District(Region region) : this() {
        Id = region.Id;
        Name = region.Name;
        ProvinceId = (int)region.ParentId!;

        Names["uzl"] = region.NameUzl;
        Names["uzk"] = region.NameUzk;
        Names["ru"] = region.NameRu;
    }
}