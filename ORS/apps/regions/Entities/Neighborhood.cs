using ORS.Apps.Regions.Models;

namespace ORS.Apps.Regions.Entities;

public class Neighborhood {
    public int Id { get; set; }

    public string Name { get; set; }

    public int RegionId { get; set; }

    public Neighborhood(Quarter quarter, string lang) {
        Id = quarter.Id;
        RegionId = quarter.RegionId;

        Name = quarter.Name;

        if (quarter.Names.TryGetValue(lang, out var name)) {
            Name = name;
        }
    }
}