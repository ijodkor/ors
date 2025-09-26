using Microsoft.AspNetCore.Mvc;
using ORS.Apps.MobileOperators.Models;

namespace ORS.Apps.MobileOperators;

[ApiController]
[Route("api/mobile/operators")]
public class MobileOperatorController(OperatorService service) : Controller {
    // GET
    [HttpGet]
    public async Task<List<MobileOperator>> Index() {
        return await service.All();
    }
}