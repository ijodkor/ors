using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace ORS.Apps.Country;

[ApiController]
[Route("api/countries")]
[SwaggerTag("Last update: 26.09.2025")]
public class CountryController : Controller {
    // GET
    [HttpGet]
    public Index() {
        return "api/countries";
    }
}