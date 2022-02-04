using CicekSepeti.Core.Models;
using CicekSepeti.Data.Helper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CicekSepeti.Data.Concrete.Contexts
{
    public class CicekSepetidbContext : DbContext
    {
        //public CicekSepetidbContext(DbContextOptions<CicekSepetidbContext> options)
        //  : base(options)
        //{

        //}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=.\\SQLEXPRESS; database=ciceksepetidb; integrated security=true;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Seed();

            //modelBuilder.Entity<Product>()
            //     .HasData(ModelsSeedingData.Products);
            //modelBuilder.Entity<BasketItem>()
            //    .HasData(ModelsSeedingData.BasketItems);
        }
        public DbSet<Product> Products { get; set; }

        public DbSet<BasketItem> BasketItems { get; set; }

    }
}
