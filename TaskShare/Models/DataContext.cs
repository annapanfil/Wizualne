using Microsoft.EntityFrameworkCore;

namespace TaskShare.Models
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
            modelbuilder.Entity<Task>()
                .HasKey(t => new { t.Id });
            modelbuilder.Entity<Task>()
                .HasOne(t => t.User)
                .WithMany(u => u.Tasks)
                .HasForeignKey(t => t.UserID);
        }

        public DbSet<Issue> Issues { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DbSet<Task> Tasks { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
