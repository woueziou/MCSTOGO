using MCSTOGO.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace MCSTOGO.Data
{
    public class MCSDbContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public MCSDbContext(DbContextOptions<MCSDbContext> options, IConfiguration configuration) : base(options)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = _configuration.GetConnectionString("remote");
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql(connectionString, x => x.ServerVersion("5.7.31-mysql"));
            }
        }

        public DbSet<Photo> Photos { get; set; }
        public DbSet<Post> Posts { get; set; }
    }
}