using ORS.Apps.Authors.Entities;

namespace ORS.Apps.Authors;

public class AuthorApp {
    private static readonly string[] AuthorList = new[] {
        "Anvar"
    };

    public Author[] Authors() {
        var forecast = Enumerable.Range(1, AuthorList.Length).Select(index => new Author(
                AuthorList[Random.Shared.Next(AuthorList.Length)],
                DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                Random.Shared.Next(-20, 55)
            ))
            .ToArray();
        return forecast;
    }
}