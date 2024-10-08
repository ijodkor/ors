using ORS.Apps.Regions.Models;

namespace ORS.Apps.Regions.Entities;

public class Province() {
    public int id { get; set; }

    public string name { get; set; }

    public Dictionary<string, string> names { get; } = new();

    public Province(Region region) : this() {
        id = region.Id;
        name = region.Name;

        names["uzl"] = region.NameUzl;
        names["uzk"] = region.NameUzk;
        names["ru"] = region.NameRu;
    }
}