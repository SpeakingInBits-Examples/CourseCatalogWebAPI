using System.ComponentModel.DataAnnotations;

namespace CourseCatalog.Core.Models;

/// <summary>
/// Represents a single college course in the course catalog.
/// </summary>
public class Course
{
    /// <summary>
    /// Primary key for the Course entity.
    /// </summary>
    [Key]
    public int Id { get; set; }

    /// <summary>
    /// Name of the course student sees in the catalog.
    /// Course names are always in English
    /// </summary>
    [RegularExpression(@"^[A-Za-z0-9\s.,'-]+$")]
    public required string Title { get; set; }

    /// <summary>
    /// Number of academic credits the course is worth.
    /// Should always be greater than or equal to 1.
    /// </summary>
    [Range(1, 25)]
    public byte NumCredits { get; set; }

    /// <summary>
    /// The first day of class for the course.
    /// </summary>
    public DateOnly StartDate { get; set; }

    /// <summary>
    /// String representation for display purposes.
    /// </summary>
    public override string ToString()
    {
        return $"{Title} - {NumCredits} credits - Starts: {StartDate:MM/dd/yyyy}";
    }
}
