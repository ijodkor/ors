using Microsoft.AspNetCore.Mvc;
using ORS.Apps.Regions.Dto;
using ORS.core.Entities;
using ORS.core.Exceptions;

namespace ORS.Apps.Regions;

[ApiController]
[Route("api/quarters")]
public class QuarterController(QuarterService service) : Controller {
    // GET
    [HttpGet]
    public async Task<IActionResult> Index([FromQuery] EntityListDto dto) {
        var meta = await service.GetMeta(dto);
        var quarters = await service.All(dto);
        
        return Ok(
            new {
                data = new {
                    quarters
                },
                meta
            }
        );
    }

    [HttpGet("neighborhoods")]
    public async Task<IActionResult> Neighborhoods([FromQuery] LangDto dto) {
        return Ok(await service.Neighborhoods(dto));
    }

    [HttpGet("neighborhoods/{id}")]
    public IActionResult Neighborhood(int id, [FromQuery] LangDto dto) {
        try {
            return Ok(service.GetNeighborhoodById(id, dto));
        }
        catch (ModelNotFoundException e) {
            return NotFound(new NotFoundEntity(e.Message));
        }
    }
}