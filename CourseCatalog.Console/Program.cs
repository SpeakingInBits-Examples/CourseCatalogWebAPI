using Microsoft.Extensions.DependencyInjection;
using CourseCatalog.Core.Services;
using CourseCatalog.Core.Models;

// Set up dependency injection
var services = new ServiceCollection();

// Configure HttpClient for the API
services.AddHttpClient<CourseApiService>(client =>
{
    client.BaseAddress = new Uri("https://localhost:7060/");
    client.Timeout = TimeSpan.FromSeconds(30);
});

var serviceProvider = services.BuildServiceProvider();

// Get the CourseApiService and fetch courses
var courseApiService = serviceProvider.GetRequiredService<CourseApiService>();

try
{
    Console.WriteLine("Fetching courses from API...\n");
    
    var courses = await courseApiService.GetCoursesAsync();

    if (courses.Any())
    {
        Console.WriteLine($"Found {courses.Count} course(s):\n");
        
        foreach (var course in courses)
        {
            Console.WriteLine($"ID: {course.Id}");
            Console.WriteLine($"Title: {course.Title}");
            Console.WriteLine($"Credits: {course.NumCredits}");
            Console.WriteLine($"Start Date: {course.StartDate:MM/dd/yyyy}");
            Console.WriteLine(new string('-', 50));
        }
    }
    else
    {
        Console.WriteLine("No courses found.");
    }
}
catch (Exception ex)
{
    Console.WriteLine($"Error: {ex.Message}");
}

Console.ReadKey();