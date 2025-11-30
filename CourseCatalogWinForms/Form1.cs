using CourseCatalog.Core.Services;
using CourseCatalog.Core.Models;
using System.ComponentModel.DataAnnotations;

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
        var newCourse = new Course
        {
            Title = txtTitle.Text.Trim(),
            NumCredits = (byte)nudNumCredits.Value,
            StartDate = DateOnly.FromDateTime(dtpStartDate.Value)
        };

        // Validate using data annotations from the Course model
        var validationContext = new ValidationContext(newCourse);
        var validationResults = new List<ValidationResult>();

        if (!Validator.TryValidateObject(newCourse, validationContext, validationResults, validateAllProperties: true))
        {
            // Show all validation errors
            var errors = string.Join(Environment.NewLine, validationResults.Select(r => r.ErrorMessage));
            MessageBox.Show($"Validation failed:{Environment.NewLine}{errors}", "Validation Error",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        btnAddCourse.Enabled = false;
        var previousCursor = Cursor;
        Cursor = Cursors.WaitCursor;

        try
        {
            var addedCourse = await _courseApiService.CreateCourseAsync(newCourse);

            if (addedCourse != null)
            {
                lstCourses.Items.Add(addedCourse);
                MessageBox.Show("Added " + addedCourse.ToString());
                
                // Clear input fields
                txtTitle.Clear();
                nudNumCredits.Value = 1;
                dtpStartDate.Value = DateTime.Today;
            }
            else
            {
                MessageBox.Show("Course cannot be added");
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Failed to add course: {ex.Message}", "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        finally
        {
            btnAddCourse.Enabled = true;
            Cursor = previousCursor;
        }
    }
}