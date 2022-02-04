using CicekSepeti.Business.Abstract;
using CicekSepeti.Business.Constants.Messages;
using CicekSepeti.Core.Models;
using CicekSepeti.Core.Utilities.Business;
using CicekSepeti.Core.Utilities.Result;
using CicekSepeti.Core.Utilities.Result.Error;
using CicekSepeti.Core.Utilities.Result.Success;
using CicekSepeti.Data.Abstract;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace CicekSepeti.Business.Concrete
{
    public class BasketItemManager : IBasketItemService
    {
        private IBasketItemDal _basketItemDal;
        private IProductService _productService;
        public BasketItemManager(IBasketItemDal basketItemDal, IProductService productService)
        {
            _basketItemDal = basketItemDal;
            _productService = productService;
        }

        public IDataResult<List<BasketItem>> GetAll()
        {
            
            return new SuccessDataResult<List<BasketItem>>(_basketItemDal.GetAll().ToList());
        }

        public IDataResult<BasketItem> GetById(int basketItemId)
        {
            return new SuccessDataResult<BasketItem>(_basketItemDal.Get(p => p.Id == basketItemId));
        }

        //Eklenmek istenen ürün sepette varsa var olan kaydın değerleri güncellenecektir.
        //Örneğin sepetteki product' ın Quantity değerini değiştirdik, bu durumda Product tablosunda 
        //yer alan UnitsInStock değeri değişecektir. Eklenmek istenen ürün sepette yoksa,
        //ProductId = 5 eklemek istiyoruz diyelim ve sepette bu ProductId' ye sahip ürün yok,
        //bu durumda basketItem' a yeni bir kayıt eklenecektir.   
        public IResult Add(BasketItem basketItem)
        {
            IResult result = BusinessRules.Run(CheckProductStock(basketItem));
            if (result != null)
            {
                return result;
            }

            var existingCartItem = _basketItemDal.Get(c => c.ProductId == basketItem.ProductId);
            if (existingCartItem != null)
            {
                basketItem.Id = existingCartItem.Id;
                _basketItemDal.Update(basketItem);

            }
            else
            {
                _basketItemDal.Add(basketItem);
            }
            return new SuccessResult(CartItemMessage.CartItemAddedSuccessfully);
        }

        private IResult CheckProductStock(BasketItem basketItem)
        {
            var product = _productService.GetById(basketItem.ProductId);
            if (product.Data.UnitsInStock > 0 && product.Data.UnitsInStock >= basketItem.Quantity)
            {
                product.Data.UnitsInStock = product.Data.UnitsInStock - basketItem.Quantity;
                _productService.Update(product.Data);
                return new SuccessResult();
            }
            return new ErrorResult(ProductMessage.ProductIsNotInStock);
        }

      



    }
}
