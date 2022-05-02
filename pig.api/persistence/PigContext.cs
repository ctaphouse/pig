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
    public DbSet<Department>? Departments { get; set; }
}