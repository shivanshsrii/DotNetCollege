using Microsoft.EntityFrameworkCore;
using UCrud.Models.Entities;

namespace UCrud.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<User> Users { get; set; }

    }
}
