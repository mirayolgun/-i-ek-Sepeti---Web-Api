using CicekSepeti.Core.DataAccess.EntityFramework;
using CicekSepeti.Core.Models;
using CicekSepeti.Data.Abstract;
using CicekSepeti.Data.Concrete.Contexts;
using System;
using System.Collections.Generic;
using System.Text;

namespace CicekSepeti.Data.Concrete
{
    public class EfProductDal : EfEntityRepositoryBase<Product, CicekSepetidbContext>, IProductDal
    {
    }
}

