using CourseCatalog.Core.Services;
using CourseCatalog.Core.Models;

namespace CourseCatalogWinForms;

public partial class Form1 : Form
{
    private readonly CourseApiService _courseApiService;

    public Form1(CourseApiService courseApiService)
    {
        InitializeComponent();
        _courseApiService = courseApiService;
    }

    private async void Form1_Load(object sender, EventArgs e)
    {
        await LoadCoursesAsync();
    }

    private async Task LoadCoursesAsync()
    {
        try
        {
            lstCourses.Items.Clear();
            lstCourses.Items.Add("Loading courses...");

            var courses = await _courseApiService.GetCoursesAsync();

            lstCourses.Items.Clear();

            if (courses.Any())
            {
                foreach (var course in courses)
                {
                    lstCourses.Items.Add(course);
                }
            }
            else
            {
                lstCourses.Items.Add("No courses found.");
            }
        }
        catch (Exception ex)
        {
            lstCourses.Items.Clear();
            lstCourses.Items.Add($"Error: {ex.Message}");
            MessageBox.Show($"Failed to load courses: {ex.Message}", "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private async void btnAddCourse_Click(object sender, EventArgs e)
    {
        Course newCourse = new()
        {
            Title = txtTitle.Text,
            NumCredits = (byte)nudNumCredits.Value,
            StartDate = DateOnly.FromDateTime(dtpStartDate.Value)
        };

        try
        {
            Course? addedCourse = await _courseApiService.CreateCourseAsync(newCourse);

            if (addedCourse != null)
            {
                MessageBox.Show("Added " + addedCourse.ToString());
                lstCourses.Items.Add(addedCourse);
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Failed to add course: {ex.Message}", "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}