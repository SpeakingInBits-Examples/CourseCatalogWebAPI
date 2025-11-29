using CourseCatalog.Core.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace CourseCatalogWinForms
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            var host = Host.CreateDefaultBuilder()
                .ConfigureServices((context, services) =>
                {
                    // Configure HttpClient for the API
                    services.AddHttpClient<CourseApiService>(client =>
                    {
                        client.BaseAddress = new Uri("https://localhost:7060/");
                        client.Timeout = TimeSpan.FromSeconds(30);
                    });

                    // Register Form1
                    services.AddTransient<Form1>();
                })
                .Build();

            var form = host.Services.GetRequiredService<Form1>();
            Application.Run(form);
        }
    }
}