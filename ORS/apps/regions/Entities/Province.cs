namespace ORS.Apps.Regions.Entities;

public class Province() {
    public int id { get; set; }

    public string name { get; set; }

    public Dictionary<string, string> names { get; } = new();

    public int order { get; set; } = 1;

    public Province(int id, string name) : this() {
        this.id = id;
        this.name = name;

        names["uzl"] = name;
        names["uzk"] = name;
        names["ru"] = name;
    }
}