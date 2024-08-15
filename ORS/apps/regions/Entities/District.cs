namespace ORS.Apps.Regions.Entities;

public class District() {
    public int id { get; set; }

    public string name { get; set; }

    public int provinceId { get; set; }

    public Dictionary<string, string> names { get; } = new();

    public int order { get; set; } = 1;

    public District(int id, string name, int provinceId) : this() {
        this.id = id;
        this.name = name;
        this.provinceId = provinceId;
        
        names["uzl"] = name;
        names["uzk"] = name;
        names["ru"] = name;
    }
}