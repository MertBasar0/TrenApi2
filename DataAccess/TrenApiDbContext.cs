using Entities;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class TrenApiDbContext : DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(databaseName: "TrenApiDbContext");
        }

        public DbSet<Train>? Trains { get; set; }
        public DbSet<Carriage>? Carriages { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //EagerLoading

            //modelBuilder.Entity<Carriage>().Navigation(x => x.Train).AutoInclude();

            //modelBuilder.Entity<Detail>().Navigation(x => x.RezervationDetail).AutoInclude();
        }
    }
}
