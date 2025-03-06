using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace ORS.Apps.Regions.Models;

[Table("quarters")]
public class Quarter {
    public const short TYPE_COUNTRYSIDE = 1;   // QFY
    public const short TYPE_CITY = 2;          // SHFY
    public const short TYPE_NEIGHBORHOOD = 3;  // MFY
    public const short TYPE_VILLAGE = 4;       // OFY
    
    [Column("id")]
    public int Id { get; set; }

    [Column("type")]
    public short Type { get; set; } = TYPE_COUNTRYSIDE;

    [Column("region_id")]
    public int RegionId { get; set; }

    [Column("name")] [Required]
    public string Name { get; set; }

    [NotMapped]
    public Dictionary<string, string> Names { get; set; }

    [Column("ord")]
    public int Order { get; set; } = 1;
    
    // JSONB column as a string for manual serialization
    [JsonIgnore]
    [Column("names")]
    public string NamesJson  {
        get => JsonConvert.SerializeObject(Names); // Convert dictionary to JSON string
        set => Names = JsonConvert.DeserializeObject<Dictionary<string, string>>(value) ?? new Dictionary<string, string>(); // Convert JSON string back to dictionary
    }
}