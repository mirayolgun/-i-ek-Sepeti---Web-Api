using CicekSepeti.Core.Models;
using CicekSepeti.Service.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CicekSepeti.Service.Services
{
    public class BasketService : IBasketService
    {
        private readonly IRepository _iRepository;
        public BasketService(IRepository iRepository)
        {
            _iRepository = iRepository;
        }

        public async Task<BasketItem> AddItemintoBasketAsync(BasketItem basketItem)
        {
            IEnumerable<BasketItem> basketItems = await _iRepository.GetAsync<BasketItem>();
            //this is for primary key generate becuase the actuall database is not not connected, once we have actuall db connected the following live of code will be remove
            if (basketItems.Count() > 0)
            {
                basketItem.Id = basketItems.Last().Id + 1;
            }
            else
            {
                basketItem.Id = 1;
            }

            _iRepository.Create(basketItem);
            await _iRepository.SaveAsync();
            return basketItem;
        }

        public async Task<IList<BasketItem>> GetBasketItemsAsync(int userId)
        {
            var basketItems = await _iRepository.GetAsync<BasketItem>();
            basketItems = PopulateProductIntoBasketItem(basketItems.ToList());
            return basketItems.ToList();
        }

        private List<BasketItem> PopulateProductIntoBasketItem(List<BasketItem> basketItems)
        {
            foreach (var basketItem in basketItems)
            {
                basketItem.Product = _iRepository.GetById<Product>(basketItem.ProductId);
            }

            return basketItems;
        }
    }
}
