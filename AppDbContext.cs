using Microsoft.EntityFrameworkCore;
using newProject.Models;

namespace newProject
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }

        public DbSet<Emp_Master> Emp_Masters {get;set;}
        public DbSet<Salary_Master> Salary_Masters {get;set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Emp_Master>(emp =>
            {
                emp.ToTable("Emp_Master");
                emp.HasKey(e => e.Emp_Id);
            });
            modelBuilder.Entity<Salary_Master>(emp =>
            {
                emp.ToTable("Salary_Master");
                emp.HasKey(e => e.Salary_id);
            });
        }
    }
}