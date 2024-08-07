using Microsoft.AspNetCore.Mvc;

namespace ORS.Apps.Regions;

[ApiController]
[Route("api/regions")] // [Route("api/[controller]")]
public class RegionController : Controller {
    // GET
    [HttpGet]
    public string[] Index() {
        return [];
    }

    [HttpGet("provinces")]
    public string Provinces() {
        return "Provinces";
    }
}