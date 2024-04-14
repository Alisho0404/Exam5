using Domain.Enteties;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class DataContext:DbContext
    {
        public DataContext(DbContextOptions<DataContext> options):base(options)
        {
            
        } 
        public DbSet<Challenge> Challenges { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Location> Locations { get; set; } 
        public DbSet<Participant> Participants { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        { 
            modelBuilder.Entity<Group>()
                .HasMany(x=>x.Participants)
                .WithOne(x=> x.Group)
                .HasForeignKey(x=>x.GroupId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Participant>()
                .HasOne(x => x.Location)
                .WithOne(x => x.Participant);

            modelBuilder.Entity<Group>()
                .HasMany(x => x.Challenges)
                .WithOne(x => x.Group)
                .OnDelete(DeleteBehavior.Restrict);
                
            base.OnModelCreating(modelBuilder);
        }
    }
}
