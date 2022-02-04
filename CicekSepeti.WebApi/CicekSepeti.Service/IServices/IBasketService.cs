using CicekSepeti.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CicekSepeti.Service.IServices
{
    public interface IBasketService
    {
        Task<BasketItem> AddItemintoBasketAsync(BasketItem basketItem);
        Task<IList<BasketItem>> GetBasketItemsAsync(int userId);

    }
}
