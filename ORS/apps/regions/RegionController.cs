using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
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
    public async Task<List<Province>> Provinces() {
        return await service.Provinces();
    }

    [HttpGet("provinces/{id}")]
    public IActionResult Province(int id) {
        try {
            return Ok(service.GetProvinceById(id));
        } catch (ModelNotFoundException e) {
            return NotFound(new NotFoundEntity(e.Message));
        }
    }

    [HttpGet("districts")]
    public async Task<List<District>> Districts([BindRequired, FromQuery(Name = "provinceId")] int provinceId) {
        return await service.Districts(provinceId);
    }

    [HttpGet("districts/{districtId}")]
    public IActionResult District([BindRequired] int districtId) {
        try {
            return Ok(service.GetDistrictById(districtId));
        } catch (ModelNotFoundException e) {
            return StatusCode(StatusCodes.Status404NotFound, new NotFoundEntity(e.Message));
        }
    }
}