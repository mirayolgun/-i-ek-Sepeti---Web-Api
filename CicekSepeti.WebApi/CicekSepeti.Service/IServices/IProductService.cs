using CicekSepeti.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CicekSepeti.Service.IServices
{
    public interface IProductService
    {
        Task<IList<Product>> GetProductsAsync();
        Task<Product> GetProductAsync(int productId);
    }
}
