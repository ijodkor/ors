using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using ORS.Apps.Regions.Entities;
using ORS.Apps.Regions.Models;

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

    [HttpGet("districts")]
    public async Task<List<District>> Districts([BindRequired, FromQuery(Name = "provinceId")] int provinceId) {
        Console.WriteLine(provinceId);
        return await service.Districts(provinceId);
    }
}