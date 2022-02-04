using CicekSepeti.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CicekSepeti.Core.Models
{
    public class Product : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Desciption { get; set; }
        public decimal Price { get; set; }
        public int UnitsInStock { get; set; }
        public BasketItem basketItem { get; set; }
    }
}
