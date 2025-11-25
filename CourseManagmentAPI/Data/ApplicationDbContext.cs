using CourseManagmentAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace CourseManagmentAPI.Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):DbContext(options)
{
    public DbSet<Student>  Students { get; set; }
    public DbSet<Course>  Courses { get; set; }
    public DbSet<Module>  Modules { get; set; }
    public DbSet<StudentCourse>  StudentCourse { get; set; }
    
}