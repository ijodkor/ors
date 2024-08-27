using Microsoft.AspNetCore.Mvc;
using ORS.apps.MobileOperators.Models;

namespace ORS.apps.MobileOperators;

[ApiController]
[Route("api/mobile/operators")]
public class MobileOperatorController(OperatorService service) : Controller {
    // GET
    [HttpGet]
    public async Task<List<MobileOperator>> Index() {
        return await service.All();
    }
}