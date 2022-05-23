﻿using Audio.Microservice.Model;
using Microsoft.EntityFrameworkCore;

namespace Audio.Microservice.Context
{
    public class AudioDbContext : DbContext
    {
        public AudioDbContext(DbContextOptions<AudioDbContext> options) : base(options)
        {
        }

        public DbSet<AudioModel> Songs { get; set; }

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
