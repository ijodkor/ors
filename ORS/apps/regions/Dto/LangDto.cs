using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace ORS.Apps.Regions.Dto;

public class LangDto {
    [FromQuery(Name = "lang")]
    [SwaggerParameter(Description = "Language ([] - O\u2018zbekcha, uzc - Ўзбекча, ru - Русский)")]
    public string Lang { get; set; } = "uz";
}