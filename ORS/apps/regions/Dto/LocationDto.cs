using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Swashbuckle.AspNetCore.Annotations;

namespace ORS.Apps.Regions.Dto;

public class LocationDto {
    [BindRequired, FromQuery(Name = "latitude")]
    [SwaggerParameter(Description = "Latitude")]
    public float Latitude { get; set; }

    [BindRequired, FromQuery(Name = "longitude")]
    [SwaggerParameter(Description = "Longitude")]
    public float Longitude { get; set; }
}