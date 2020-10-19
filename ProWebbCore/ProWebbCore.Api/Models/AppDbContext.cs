using ProWebbCore.Shared;
using Microsoft.EntityFrameworkCore;

namespace ProWebbCore.Api.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Resume> Resumes { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<ProWebbCore.Shared.Project> Project { get; set; }
    }
}
