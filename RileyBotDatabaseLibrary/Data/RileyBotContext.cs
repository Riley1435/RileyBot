using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using RileyBotDatabaseLibrary.Models;

namespace RileyBotDatabaseLibrary.Data
{
    public class RileyBotContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Drop> Drops { get; set; }

        public RileyBotContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlite(@"Data Source=C:\Users\riley\source\repos\RileyBot\RileyBotDatabaseLibrary\RileyBot.db");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<User>(entity =>
            {
                entity.HasIndex(e => e.DiscordId).IsUnique();
            });
        }
    }
}
