using Microsoft.EntityFrameworkCore;

namespace Company_MVC.Models
{
    public class CompanyDbContext : DbContext
    {
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<Project> Projects { get; set; }
        public virtual DbSet<Works_On> Employees_Projects { get; set; }
        public virtual DbSet<Dept_Location> Department_Locations { get; set; }
        public virtual DbSet<Dependent> Dependents { get; set; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=Company;Trusted_Connection=True;TrustServerCertificate=True;");
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Dept_Location>().HasKey("DepartmentId", "Location");
            modelBuilder.Entity<Works_On>().HasKey("EmployeeId", "ProjectId");
            modelBuilder.Entity<Dependent>().HasKey("EmployeeId", "DependentName");
            base.OnModelCreating(modelBuilder);
        }
    }
}
