using CicekSepeti.Core.Models;
using CicekSepeti.Data.Concrete.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CicekSepeti.Data.Helper
{

    //Database' e test dataları ekliyorum. Ardından migration atıyorum ve database' e ekleniyor.
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(
              new Product
                  {
                      Id = 1,
                      Name = "Tasarım Çiçek",
                      Price = 90,
                      Desciption = "Pembe incili Kutuda Renkli Lisyantuslar",
                      UnitsInStock = 1
                  },
              new Product
              {
                  Id = 2,
                  Name = "Doğum Günü Çiçekleri",
                  Price = 79,
                  Desciption = "Mutluluk Kutusu",
                  UnitsInStock = 8
              },
              new Product
              {
                  Id = 3,
                  Name = "Çiçek Buketleri",
                  Price = 94,
                  Desciption = "Pembe Papatyalar Çiçek Buketi",
                  UnitsInStock = 5
              },
              new Product
              {
                  Id = 4,
                  Name = "Lilyum & Zambak",
                  Price = 108,
                  Desciption = "Kar Beyaz Gül ve Lilyum",
                  UnitsInStock = 4
              },
              new Product
              {
                  Id = 5,
                  Name = "Güller",
                  Price = 200,
                  Desciption = "100 Kırmızı Gül Çiçek Demeti",
                  UnitsInStock = 6
              }
            );

            modelBuilder.Entity<BasketItem>(o =>
            {
                o.HasData(
                new BasketItem()
                {
                    Id = 1,
                    Quantity = 1,
                    ProductId = 1
                },
                new BasketItem()
                {
                    Id = 2,
                    Quantity = 3,
                    ProductId = 2
                },
                new BasketItem()
                {
                    Id = 3,
                    Quantity = 5,
                    ProductId = 3
                });
            });
        }
    }
}
