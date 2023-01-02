using Microsoft.EntityFrameworkCore;

namespace _145233.SweetBase.Models
{
    public class DataContext: DbContext
    {
        private IConfiguration _configuration;

        public DataContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(_configuration.GetConnectionString("SqliteConnectionString"));
        }

        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {
            // join tables
            modelbuilder.Entity<Product>()
                .HasKey(t => new { t.Id });
            modelbuilder.Entity<Product>()
                .HasOne(t => t.Producent)
                .WithMany(u => u.Products)
                .HasForeignKey(t => t.ProducentID);
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Producent> Producents { get; set; }
    }
}
