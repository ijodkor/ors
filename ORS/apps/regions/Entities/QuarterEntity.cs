using ORS.Apps.Regions.Models;

namespace ORS.Apps.Regions.Entities;

public enum LanguageCode {
    Uz, // Uzbek
    Ru, // Russian
    En // English
}

public class QuarterEntity(Quarter quarter) {
    public int Id { get; set; } = quarter.Id;

    public string Name { get; set; } = quarter.Name;

    public int RegionId { get; set; } = quarter.RegionId;

    public Dictionary<string, string> Names { get; } = quarter.Names;

    public int Order { get; set; } = quarter.Order;
}