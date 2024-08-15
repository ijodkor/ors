using Microsoft.AspNetCore.Mvc;
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
    public async Task<List<District>> Districts() {
        return await service.Districts();
    }
}