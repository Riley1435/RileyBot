using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using RileyBot.Models;

namespace DiscordBot.Data
{
    public class RileyBotContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Drop> Drops { get; set; }

        private static bool _created = false;
        public RileyBotContext()
        {
            if (!_created)
            {

                _created = true;
                Database.EnsureDeleted();
                Database.EnsureCreated();
            }
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlite("Data Source=RileyBot.db");
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
