using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ORS.Apps.MobileOperators.Models;

[Table("mobile_operators")] // Schema = "public"
public class MobileOperator {
    [Column("id")] public int Id { get; set; }

    [Column("name")] [Required] public string Name { get; set; }
}