using CourseCatalog.Core.Services;

namespace CourseCatalogWinForms
{
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

        private void btnAddCourse_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This feature is coming soon");
        }
    }
}
