using CicekSepeti.Business.Abstract;
using CicekSepeti.Business.Concrete;
using CicekSepeti.Core.DataAccess;
using CicekSepeti.Core.DataAccess.EntityFramework;
using CicekSepeti.Core.Entities;
using CicekSepeti.Core.Models;
using CicekSepeti.Core.Utilities.Result;
using CicekSepeti.Data.Abstract;
using CicekSepeti.Data.Concrete;
using CicekSepeti.Data.Concrete.Contexts;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CicekSepeti.WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddDbContext<CicekSepetidbContext>(opt => opt.UseInMemoryDatabase("TestDb"));

            services.AddTransient<IProductService, ProductManager>();
            services.AddTransient(typeof(IEntityRepository<>), typeof(EfEntityRepositoryBase<,>));
            services.AddTransient<IBasketItemService, BasketItemManager>();
            services.AddTransient<IEntity, Product>();
            services.AddTransient<IEntity, BasketItem>();
            services.AddTransient<IResult, Result>();
            //services.AddTransient(IResult, typeof(IDataResult<>));
            
            services.AddTransient(typeof(IDataResult<>), typeof(DataResult<>));
            services.AddTransient<IProductDal, EfProductDal>();
            services.AddTransient<IBasketItemDal, EfBasketItemDal>();

            services.AddControllers();
        }
       
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory, IServiceProvider serviceProvider)
        {

            if (env.IsDevelopment())
            {

                app.UseDeveloperExceptionPage();
                //var context = serviceProvider.GetService<CicekSepetidbContext>();
                //AddTestData(context);

                //using (var serviceScope = app.ApplicationServices.CreateScope())
                //{
                //    var services = serviceScope.ServiceProvider;
                //    var myDbContext = services.GetService<CicekSepetidbContext>();
                //    AddTestData(myDbContext);
                //}


                //var sp = services.BuildServiceProvider();

                //// Create a scope to obtain a reference to the database contexts
                //using (var scope = sp.CreateScope())
                //{
                //    var scopedServices = scope.ServiceProvider;
                //    var appDb = scopedServices.GetRequiredService<AppDbContext>();


                //using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
                //{
                //    var context = serviceScope.ServiceProvider.GetService<CicekSepetidbContext>();
                //    AddTestData(context);
                //}
            }
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }


        //private static void AddTestData(CicekSepetidbContext context)
        //{
        //    IList<Product> products = new List<Product>();
        //    products.Add(new Product { Id = 5, Name = "Tasarım Çiçek", Price = 90, Desciption = "Pembe incili Kutuda Renkli Lisyantuslar", UnitsInStock = 1});
        //    products.Add(new Product { Id = 6, Name = "Doğum Günü Çiçekleri", Price = 79, Desciption = "Mutluluk Kutusu", UnitsInStock = 8});
        //    products.Add(new Product { Id = 7, Name = "Çiçek Buketleri", Price = 94, Desciption = "Pembe Papatyalar Çiçek Buketi", UnitsInStock = 5});
        //    products.Add(new Product { Id = 8, Name = "Lilyum & Zambak", Price = 108, Desciption = "Kar Beyaz Gül ve Lilyum", UnitsInStock = 4});
        //    products.Add(new Product { Id = 9, Name = "Güller", Price = 200, Desciption = "100 Kırmızı Gül Çiçek Demeti", UnitsInStock = 6});
        //    context.Products.AddRange(products);

        //    IList<BasketItem> basketItems = new List<BasketItem>();
        //    basketItems.Add(new BasketItem { Id = 2, ProductId = 5, Quantity = 1});
        //    basketItems.Add(new BasketItem { Id = 1, ProductId = 1, Quantity = 2});
        //    context.BasketItems.AddRange(basketItems);

        //    context.SaveChanges();
        //}
    }
}
