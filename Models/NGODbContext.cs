using Microsoft.EntityFrameworkCore;
namespace Orphanage.Models
{
    public class NGODbContext : DbContext
    {
        public NGODbContext(DbContextOptions<NGODbContext> options)
        : base(options) { }
        public DbSet<Donation> Donations { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<HomeEvent> HomeEvents { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Volunteer> Volunteers { get; set; }
    }
}