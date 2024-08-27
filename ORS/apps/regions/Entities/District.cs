using ORS.Apps.Regions.Models;

namespace ORS.Apps.Regions.Entities;

public class District() {
    public int id { get; set; }

    public string name { get; set; }

    public int provinceId { get; set; }

    public Dictionary<string, string> names { get; } = new();

    public District(Region region) : this() {
        id = region.Id;
        name = region.Name;
        provinceId = (int)region.ParentId!;

        names["uzl"] = region.NameUzl;
        names["uzk"] = region.NameUzk;
        names["ru"] = region.NameRu;
    }
}