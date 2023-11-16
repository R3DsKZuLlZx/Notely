namespace Notely.Application.Notes;

public class Note
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public required string Title { get; set; }
    public required string Content { get; set; }
    public string Colour { get; set; } = "#fdfd96";
}
