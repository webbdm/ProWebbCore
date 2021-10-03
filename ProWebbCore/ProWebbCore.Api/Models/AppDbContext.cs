using ProWebbCore.Shared;
using ProWebbCore.Shared.Life.Nutrition;
using Microsoft.EntityFrameworkCore;
using ProWebbCore.Shared.Numbers;

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
        public DbSet<Project> Project { get; set; }

        public DbSet<Meal> Meal { get; set; }
        public DbSet<Food> Food { get; set; }
        public DbSet<MealFood> MealFood { get; set; }

        public DbSet<Key> Key { get; set; }
        public DbSet<Note> Note { get; set; }
        public DbSet<KeyNote> KeyNote{ get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MealDTO>().Ignore(mf => mf.Foods);
        }

        
    }
}
