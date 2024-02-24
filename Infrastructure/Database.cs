using Domain;
using Microsoft.EntityFrameworkCore;
using System.Data.SqlClient;



namespace Infrastructure
{
    public class Database : DbContext
    {
        private const string ConnectionString = "Server=MSI;DataBase=ChronoCraft;Integrated Security=SSPI";

        public Database(DbContextOptions<Database> options) : base(options)
        {
        }
        public static SqlConnection GetConnection()
        {
            return new SqlConnection(ConnectionString);
        }

        // Define DbSet properties for your entities (tables).
        public DbSet<User> Users { get; set; }
        public DbSet<Plan> Plans { get; set; }
        public DbSet<Chrono> Chronos { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("Users").HasKey(e => e.Id);
            modelBuilder.Entity<Plan>().ToTable("Plans").HasKey(e => e.Id);
            modelBuilder.Entity<Chrono>().ToTable("Chronos").HasKey(e => e.Id);
            modelBuilder.Entity<SchreduledPlan>().ToTable("SchreduledPlans").HasKey(e => e.Id);
        }
    }
}