using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using ORS.Apps.Regions.Dto;
using ORS.Apps.Regions.Entities;
using ORS.core.Entities;
using ORS.core.Exceptions;

namespace ORS.Apps.Regions;

[ApiController]
[Route("api/regions")] // [Route("api/[controller]")]
public class RegionController(RegionService service) : Controller {
    // GET
    [HttpGet]
    public async Task<List<RegionEntity>> Index() {
        return await service.All();
    }

    [HttpGet("provinces")]
    public async Task<List<Province>> Provinces([FromQuery] LangDto dto) {
        return await service.Provinces(dto);
    }

    [HttpGet("districts")]
    public async Task<List<District>> Districts([BindRequired, FromQuery(Name = "provinceId")] int provinceId, [FromQuery(Name = "regionId")] int regionId, [FromQuery] LangDto dto) {
        if (regionId == 0) {
            regionId = provinceId;
        }

        return await service.Districts(regionId, dto);
    }

    [HttpGet("{id}")]
    public IActionResult District([BindRequired] int id, [FromQuery] LangDto dto) {
        try {
            return Ok(service.FindById(id, dto));
        } catch (ModelNotFoundException e) {
            return StatusCode(StatusCodes.Status404NotFound, new NotFoundEntity(e.Message));
        }
    }
    
    [HttpGet("by-location")]
    public IActionResult ByLocation([FromQuery] LocationDto dto, [FromQuery] LangDto query) {
        try {
            return Ok(service.GetByLocation(dto.Latitude, dto.Longitude, query));
        } catch (ModelNotFoundException e) {
            return StatusCode(StatusCodes.Status404NotFound, new NotFoundEntity(e.Message));
        }
    }
}