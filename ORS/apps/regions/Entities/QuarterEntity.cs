using ORS.Apps.Regions.Models;

namespace ORS.Apps.Regions.Entities;

public enum LanguageCode {
    Uz, // Uzbek
    Ru, // Russian
    En // English
}

public class QuarterEntity {
    public int Id { get; set; }

    public string Name { get; set; }
    public string Suffix { get; set; }

    public int RegionId { get; set; }

    public Dictionary<string, string> Names { get; }

    public int Order { get; set; }

    public QuarterEntity(Quarter quarter) {
        if (quarter.Type == Quarter.TYPE_COUNTRYSIDE) {
            Suffix = GetCountrySide()["uz"];
        }

        if (quarter.Type == Quarter.TYPE_CITY) {
            Suffix = GetCitySide()["uz"];
        }
        
        if (quarter.Type == Quarter.TYPE_NEIGHBORHOOD) {
            Suffix = GetNeighbourhood()["uz"];
        }
        
        if (quarter.Type == Quarter.TYPE_VILLAGE) {
            Suffix = GetVillageSide()["uz"];
        }
        
        Id = quarter.Id;
        Name = quarter.Name;
        RegionId = quarter.RegionId;
        Order = quarter.Order;
    }

    private Dictionary<string, string> GetCountrySide() {
        return new Dictionary<string, string> {
            ["uz"] = "QFY",
            ["uzk"] = "ҚФЙ",
            ["ru"] = "ҚФЙ",
            ["en"] = "OFY",
            ["qq"] = "ҚФЙ"
        };
    }
    
    private Dictionary<string, string> GetVillageSide() {
        return new Dictionary<string, string> {
            ["uz"] = "OFY",
            ["uzk"] = "ОФЙ",
            ["ru"] = "ОФЙ",
            ["en"] = "OFY",
            ["qq"] = "ОФЙ"
        };
    }
    
    private Dictionary<string, string> GetCitySide() {
        return new Dictionary<string, string> {
            ["uz"] = "SHFY",
            ["uzk"] = "ШФЙ",
            ["ru"] = "ШФЙ",
            ["en"] = "SHFY",
            ["qq"] = "ШФЙ"
        };
    }
    
    private Dictionary<string, string> GetNeighbourhood() {
        return new Dictionary<string, string> {
            ["uz"] = "MFY",
            ["uzk"] = "МФЙ",
            ["ru"] = "МФЙ",
            ["en"] = "MFY",
            ["qq"] = "МФЙ"
        };
    }
}