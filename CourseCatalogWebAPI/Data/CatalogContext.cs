using Microsoft.EntityFrameworkCore;
using CourseCatalogWebAPI.Models;

namespace CourseCatalogWebAPI.Data;

public class CatalogContext : DbContext
{
    public CatalogContext(DbContextOptions<CatalogContext> options) : base(options) { }

    public DbSet<Course> Courses { get; set; } = null!;
}
