using ORS.Apps.Regions.Models;

namespace ORS.Apps.Regions.Entities;

public class Province() {
    public int Id { get; set; }

    public string Name { get; set; }
    public string ShortName { get; set; }

    private Dictionary<string, string> Names { get; } = new();

    public Province(Region region, string lang) : this() {
        Id = region.Id;
        Name = region.NameUz;
        ShortName = region.Name;

        Names["uz"] = region.NameUz;
        Names["uzc"] = region.NameUzc;
        Names["ru"] = region.NameRu;
        Names["en"] = region.Name;
        Names["kaa"] = region.Name;

        if (Names.ContainsKey(lang)) {
            Name = Names[lang];
        }
    }
}