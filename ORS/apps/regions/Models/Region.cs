using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ORS.Apps.Regions.Models;

[Table("regions")] // Schema = "public"
public class Region {
    [Column("id")] public int Id { get; set; }

    [Column("parent_id")] public int? ParentId { get; set; }

    [Column("name")] [Required] public string Name { get; set; }

    [Column("name_uzl")] public string NameUzl { get; set; }

    [Column("name_uzk")] public string NameUzk { get; set; }

    [Column("name_ru")] public string NameRu { get; set; }

    [Column("order")] public int Order { get; set; } = 1;
}