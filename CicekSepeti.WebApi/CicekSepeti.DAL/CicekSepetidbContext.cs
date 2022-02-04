using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace CicekSepeti.DAL
{
    public class CicekSepetidbContext : DbContext
    {
        public CicekSepetidbContext(DbContextOptions<CicekSepetidbContext> options)
           : base(options)
        {

        }

        public virtual DbSet<Product> Products { get; set; }

        public virtual DbSet<BasketItem> BasketItems { get; set; }

    }
}
