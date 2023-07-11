using Microsoft.EntityFrameworkCore;

namespace TestApp.Models
{
    public class ContextDB : DbContext
    {
        public DbSet<employees> employees { get; set; }
        public DbSet<Areas> Areas { get; set; }
        public DbSet<Cities> Cities { get; set; }
        public DbSet<Countries> Countries { get; set; }
        public DbSet<FamilyStatus> FamilyStatus { get; set; }
        public DbSet<Quarters> Quarters { get; set; }
        public DbSet<Militarys> Militarys { get; set; }
        public DbSet<Educations> Educations { get; set; }
        public DbSet<ForSearch> ForSearch { get; set; }

        public ContextDB(DbContextOptions<ContextDB> options): base(options) 
        { 
            Database.EnsureCreated();
        }
    }
}
