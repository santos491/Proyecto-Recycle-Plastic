using Recycle_Plastic_API.Context.Configuration;
using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Recycle_Plastic_API.Context
{
    public class ProductContext : IdentityDbContext<IdentityUser>
    {
        public ProductContext(DbContextOptions options)
            :base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new ProductConfiguration());
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Events> events { get; set; }
        public DbSet<SitesRecycle> recycles { get; set; }
    }
}
