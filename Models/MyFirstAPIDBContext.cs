using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;
using cSharpApi.Models;

namespace cSharpApi.Models
{
    public class MyFirstAPIDBContext : DbContext
    {
        protected readonly IConfiguration Configuration;
        public MyFirstAPIDBContext(DbContextOptions<MyFirstAPIDBContext> options, IConfiguration configuration)
            : base(options)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            //var connectionString = Configuration.GetConnectionString("CustomerDataService");
            var connectionString = "Server=localhost;Port=3306;Database=pet_api_database;USER=root;password=root";


            options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
        }

        public DbSet<Owner> Owners { get; set; } = null!;
        public DbSet<Pet> Pets { get; set; } = null!;


    }
}