using CicekSepeti.Business.Abstract;
using CicekSepeti.Business.Constants.Messages;
using CicekSepeti.Core.Models;
using CicekSepeti.Core.Utilities.Business;
using CicekSepeti.Core.Utilities.Result;
using CicekSepeti.Core.Utilities.Result.Error;
using CicekSepeti.Core.Utilities.Result.Success;
using CicekSepeti.Data.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CicekSepeti.Business.Concrete
{
    public class ProductManager : IProductService
    {
        private IProductDal _productDal;
        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;

        }

        public IResult Add(Product product)
        {
            _productDal.Add(product);
            return new SuccessResult(ProductMessage.ProductAddedSuccessfully);
        }

        public IDataResult<Product> GetById(int productId)
        {
            return new SuccessDataResult<Product>(_productDal.Get(p => p.Id == productId));
        }

        public IDataResult<List<Product>> GetAll()
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll().ToList());
        }

        public IDataResult<Product> GetByProductName(string productName)
        {
            return new SuccessDataResult<Product>(_productDal.Get(p => p.Name == productName));
        }

        public IResult Update(Product product)
        {
            _productDal.Update(product);
            return new SuccessResult(ProductMessage.ProductAddedSuccessfully);
        }

      
    }
}
