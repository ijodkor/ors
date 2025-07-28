using Microsoft.AspNetCore.Mvc;
using ORS.Apps.Authors.Entities;

namespace ORS.Apps.Authors;

[ApiController]
[Route("author")]
public class AuthorController {
    private static readonly string[] AuthorList = new[] {
        "Anvar"
    };

    [HttpGet("developers")]
    public Developer[] Developers() {
        var developers = Enumerable.Range(1, AuthorList.Length).Select(index => new Developer(
                AuthorList[Random.Shared.Next(AuthorList.Length)],
                DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                Random.Shared.Next(-20, 55)
            ))
            .ToArray();
        return developers;
    }
}
