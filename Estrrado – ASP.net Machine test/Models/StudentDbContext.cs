using System.Data.Entity;


namespace Estrrado___ASP.net_Machine_test.Models
{
    public class StudentDbContext : DbContext
    {
        public StudentDbContext() : base("StudentDBConnectionString") { }

        public DbSet<Student> Students { get; set; }
        public DbSet<Qualification> Qualifications { get; set; }
        public DbSet<User> Users { get; set; }
     
        }
    
}