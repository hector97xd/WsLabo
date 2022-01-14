using System;
using Microsoft.EntityFrameworkCore;
using WsLabo.Models;

namespace WsLabo.Context
{
    public class LaboDbContext : DbContext
    {
        public LaboDbContext()
        {

        }
        public LaboDbContext(DbContextOptions<LaboDbContext> options) : base(options)
        {
        }
        public virtual DbSet<Paciente> Paciente { get; set; }
        public virtual DbSet<TipoExamen> TipoExamen { get; set; }
        public virtual DbSet<Examen> Examen { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
            var connectionString = configuration.GetConnectionString("AppDb");
            optionsBuilder.UseSqlServer(connectionString);
        }

    }
}

