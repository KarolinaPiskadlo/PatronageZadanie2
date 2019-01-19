using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MySql.Data.EntityFrameworkCore.Extensions;
using PatronageZadanie2.Models;

namespace PatronageZadanie2.Data
{
    public class ConferenceRoomContext : DbContext
    {
        public ConferenceRoomContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<ConferenceRoom> ConferenceRoom { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL("server=localhost;port=3306;database=patronage;user=root;password=root");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ConferenceRoom>(entity =>
            {
                //entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired();
                entity.Property(e => e.Area).IsRequired();
                entity.Property(e => e.Capacity).IsRequired();
                entity.Property(e => e.WifiAcces).HasConversion<int>();
            });
        }
    }
}
