using Guider.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Guider.Persistence.Data
{
    public class GuiderContext : IdentityDbContext<User, IdentityRole<int>, int>
    {
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Appointment> Appointment { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<SubCategory> SubCategories { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Consultant> Consultants { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
        public GuiderContext(DbContextOptions options) : base(options) { }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
