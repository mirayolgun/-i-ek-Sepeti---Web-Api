using CicekSepeti.Core.Models;
using CicekSepeti.Core.Utilities.Result;
using System;
using System.Collections.Generic;
using System.Text;

namespace CicekSepeti.Business.Abstract
{
    public interface IBasketItemService
    {
        IResult Add(BasketItem cartItem);
        IDataResult<BasketItem> GetById(int basketItemId);
        IDataResult<List<BasketItem>> GetAll();
    }
}
