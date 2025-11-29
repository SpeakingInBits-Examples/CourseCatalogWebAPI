namespace CourseCatalogWinForms.Models;

/// <summary>
/// Represents a course from the API.
/// </summary>
public class Course
{
    public int Id { get; set; }
    public required string Title { get; set; }
    public byte NumCredits { get; set; }
    public DateOnly StartDate { get; set; }

    public override string ToString()
    {
        return $"{Title} - {NumCredits} credits - Starts: {StartDate:MM/dd/yyyy}";
    }
}
