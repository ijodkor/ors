using Microsoft.AspNetCore.Mvc;
using ORS.Apps.Regions.Dto;
using ORS.Apps.Regions.Entities;
using ORS.core.Entities;
using ORS.core.Exceptions;

namespace ORS.Apps.Regions;

[ApiController]
[Route("api/quarters")]
public class QuarterController(QuarterService service) : Controller {
    // GET
    [HttpGet]
    public async Task<List<QuarterEntity>> Index() {
        return await service.All();
    }

    [HttpGet("neighborhoods")]
    public async Task<List<Neighborhood>> Neighborhoods([FromQuery] LangDto dto) {
        return await service.Neighborhoods(dto);
    }

    [HttpGet("neighborhoods/{id}")]
    public IActionResult Neighborhood(int id, [FromQuery] LangDto dto) {
        try {
            return Ok(service.GetNeighborhoodById(id, dto));
        } catch (ModelNotFoundException e) {
            return NotFound(new NotFoundEntity(e.Message));
        }
    }
}