using ORS.Apps.Regions.Models;

namespace ORS.Apps.Regions.Entities;

public class Province() {
    public int Id { get; set; }

    public string Name { get; set; }

    public Dictionary<string, string> Names { get; } = new();

    public Province(Region region) : this() {
        Id = region.Id;
        Name = region.Name;

        Names["uzl"] = region.NameUzl;
        Names["uzk"] = region.NameUzk;
        Names["ru"] = region.NameRu;
    }
}