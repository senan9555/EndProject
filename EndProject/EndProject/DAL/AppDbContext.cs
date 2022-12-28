
using EndProject.Helpers;
using EndProject.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EndProject.DAL
{
    public class AppDbContext:IdentityDbContext<AppUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext>options):base(options) 
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Kassa>().HasData(new Kassa { Id= 1, Balance=0,LastModifiedMoney=0,LastModified="yoxdur",LastModifiedBy="yoxdur",LastModifiedTime=System.DateTime.UtcNow.AddHours(4)});
            builder.Entity<HasAdmin>().HasData(new HasAdmin { Id= 1,HaSAdmin=false});
        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Expense> Expenses { get; set; }
        public DbSet<Income> Incomes { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<Wage> Wages { get; set; }
        public DbSet<Kassa> Kassas { get; set; }
        public DbSet<Medicine> Medicines { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Showcase> Showcases { get; set; }
        public DbSet<HasAdmin> HasAdmins { get; set; }
    }
}
