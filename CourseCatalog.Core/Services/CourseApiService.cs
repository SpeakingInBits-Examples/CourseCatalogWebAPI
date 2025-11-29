using System.Net.Http.Json;
using CourseCatalog.Core.Models;

namespace CourseCatalog.Core.Services;

/// <summary>
/// Service for communicating with the Course Catalog Web API.
/// </summary>
public class CourseApiService
{
    private readonly HttpClient _httpClient;

    public CourseApiService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    /// <summary>
    /// Gets all courses from the API.
    /// </summary>
    public async Task<List<Course>> GetCoursesAsync()
    {
        try
        {
            var courses = await _httpClient.GetFromJsonAsync<List<Course>>("api/courses");
            return courses ?? new List<Course>();
        }
        catch (HttpRequestException ex)
        {
            throw new Exception($"Failed to retrieve courses from API: {ex.Message}", ex);
        }
    }

    /// <summary>
    /// Creates a new course via the API.
    /// </summary>
    public async Task<Course?> CreateCourseAsync(Course course)
    {
        try
        {
            var response = await _httpClient.PostAsJsonAsync("api/courses", course);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<Course>();
        }
        catch (HttpRequestException ex)
        {
            throw new Exception($"Failed to create course: {ex.Message}", ex);
        }
    }
}
