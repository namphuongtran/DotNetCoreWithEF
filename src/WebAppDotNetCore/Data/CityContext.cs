using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppDotNetCore.Models;

namespace WebAppDotNetCore.Data
{
    public class CityContext : DbContext
    {
        public CityContext(DbContextOptions<CityContext> options) : base(options)
        {
        }

        public DbSet<CityInfo> City { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CityInfo>().ToTable("cityinfo");
        }
    }
}
