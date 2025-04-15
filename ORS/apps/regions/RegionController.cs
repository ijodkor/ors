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

    [HttpGet("provinces/{id}")]
    public IActionResult Province(int id, [FromQuery] LangDto dto) {
        try {
            return Ok(service.GetProvinceById(id, dto));
        } catch (ModelNotFoundException e) {
            return NotFound(new NotFoundEntity(e.Message));
        }
    }

    [HttpGet("districts")]
    public async Task<List<District>> Districts([BindRequired, FromQuery(Name = "provinceId")] int provinceId, [FromQuery] LangDto dto) {
        return await service.Districts(provinceId, dto);
    }

    [HttpGet("districts/{districtId}")]
    public IActionResult District([BindRequired] int districtId, [FromQuery] LangDto dto) {
        try {
            return Ok(service.GetDistrictById(districtId, dto));
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