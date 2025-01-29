using ORS.Apps.Regions.Models;

namespace ORS.Apps.Regions.Entities;

public class Province() {
    public int Id { get; set; }

    public string Name { get; set; }
    public string ShortName { get; set; }

    private Dictionary<string, string> Names { get; } = new();

    public Province(Region region, string lang) : this() {
        Id = region.Id;
        Name = region.NameUzl;
        ShortName = region.Name;

        Names["uzl"] = region.NameUzl;
        Names["uzk"] = region.NameUzk;
        Names["ru"] = region.NameRu;
        Names["en"] = region.NameRu;
        Names["qq"] = region.NameRu;

        if (Names.ContainsKey(lang)) {
            Name = Names[lang];
        }
    }
}