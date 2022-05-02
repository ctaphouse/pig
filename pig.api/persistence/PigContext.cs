using Microsoft.EntityFrameworkCore;
using pig.api.persistence.entities;

namespace pig.api.persistence;

public class PigContext: DbContext
{
    public PigContext(DbContextOptions<PigContext> options) : base(options)
    {
        
    }

    public DbSet<Student>? Students { get; set; }
    public DbSet<Course>? Courses { get; set; }
    public DbSet<CourseStudent>? CourseStudent { get; set; }
    public DbSet<Department>? Departments { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<CourseStudent>()
        .HasKey(e => new { e.CourseId, e.StudentId});

        modelBuilder.Entity<Student>()
        .HasMany(s => s.Courses)
        .WithMany(c => c.Students)
        .UsingEntity<CourseStudent>(
            j => j.HasOne(j => j.Course).WithMany().HasForeignKey(j => j.CourseId),
            j => j.HasOne(j => j.Student).WithMany().HasForeignKey(j => j.StudentId));
    }
}