using CicekSepeti.Core.Models;
using CicekSepeti.Core.Utilities.Result;
using System;
using System.Collections.Generic;
using System.Text;

namespace CicekSepeti.Business.Abstract
{
    public interface IProductService
    {
        IResult Add(Product product);
        IDataResult<Product> GetById(int productId); 
        IDataResult<List<Product>> GetAll();
        IResult Update(Product product);
    }
}
