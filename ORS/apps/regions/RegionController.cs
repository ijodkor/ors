using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using ORS.Apps.Regions.Entities;

namespace ORS.Apps.Regions;

[ApiController]
[Route("api/regions")] // [Route("api/[controller]")]
public class RegionController(RegionService service) : Controller {
    // GET
    [HttpGet]
    public string[] Index() {
        return [];
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