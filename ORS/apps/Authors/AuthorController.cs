using Microsoft.AspNetCore.Mvc;
using ORS.Apps.Authors.Entities;

namespace ORS.Apps.Authors;

[ApiController]
[Route("author")]
public class AuthorController {
    private static readonly string[] AuthorList = new[] {
        "Anvar"
    };

    [HttpGet]
    public Author Index() {
        return new Author(
            Company: new Company(
                Name: "Anvar",
                Phone: "995123264",
                Tin: 311128291,
                Ifut: 62010
            ),
            Requisites: new Requisites(
                Account: "20208000107012884001",
                Bank: "Hamkorbank ATB",
                BankCode: "00083"
            )
        );
    }

    [HttpGet("/developers")]
    public Developer[] Authors() {
        var forecast = Enumerable.Range(1, AuthorList.Length).Select(index => new Developer(
                AuthorList[Random.Shared.Next(AuthorList.Length)],
                DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                Random.Shared.Next(-20, 55)
            ))
            .ToArray();
        return forecast;
    }
}