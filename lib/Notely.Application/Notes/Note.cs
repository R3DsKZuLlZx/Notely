namespace Notely.Application.Notes;

public class Note
{
    public const string Directory = "Notes";

    public required string FileName { get; set; }
    public required string Content { get; set; }
    public string Colour { get; set; } = "#fdfd96";
}
