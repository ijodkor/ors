using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace ORS.Apps.Regions.Dto;

public class EntityListDto {
    [FromQuery(Name = "lang")]
    [SwaggerParameter(Description = "Language ([] - O\u2018zbekcha, uzk - Ўзбекча, ru - Русский)")]
    public string Lang { get; set; } = "uz";
    
    [FromQuery(Name = "page")]
    [Range(1, 1000, ErrorMessage = "Page must be greater than 1 and less than 1000.")]
    [SwaggerParameter(Description = "Page = 10")]
    public int Page { get; set; } = 1;
    
    [SwaggerIgnore]
    [Range(1, 200, ErrorMessage = "Limit must be less than 200.")]
    public int Limit { get; set; } = 200;
}