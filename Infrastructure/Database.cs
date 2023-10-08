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

        // Define DbSet properties for your entities (tables).
        public DbSet<User> Users { get; set; }
        public DbSet<Plan> Plans { get; set; }
        public DbSet<Chrono> Chronos { get; set; }
    }
}