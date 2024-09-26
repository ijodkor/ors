namespace ORS.core.Entities;

public class NotFoundEntity(string message = "") {
    public bool Success { get; set; } = false;

    public string Message { get; set; } = message;
}