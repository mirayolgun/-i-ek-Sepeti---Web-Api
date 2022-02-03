using Autofac;
using CicekSepeti.Business.Abstract;
using CicekSepeti.Business.Concrete;
using CicekSepeti.Data.Abstract;
using CicekSepeti.Data.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace CicekSepeti.Business.DependencyResolvers
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<EfProductDal>().As<IProductDal>().SingleInstance();
            builder.RegisterType<EfBasketItemDal>().As<IBasketItemDal>().SingleInstance();

            builder.RegisterType<BasketItemManager>().As<IBasketItemService>().SingleInstance();
            builder.RegisterType<ProductManager>().As<IProductService>().SingleInstance();

            builder.RegisterType<HttpContextAccessor>().As<IHttpContextAccessor>();
        }
    }
}
