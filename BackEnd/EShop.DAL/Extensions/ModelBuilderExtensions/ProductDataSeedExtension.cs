using Bogus.DataSets;
using EShop.ENTITIES.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop.DAL.Extensions.ModelBuilderExtensions
{
    public static class ProductDataSeedExtension
    {


        public static void SeedProduct(ModelBuilder modelBuilder)
        {

            List<Product> products = new List<Product>();
            Random rnd = new Random();

            for (int i = 1; i <= 30; i++) //30 tane fake veri olusturacak 
            {
                Product product = new Product()
                {
                    ID = i,
                    ProductName = new Commerce("tr").ProductName(),
                    UnitPrice = Convert.ToDecimal(new Commerce("tr").Price()),
                    UnitsInStock = rnd.Next(0, 50),
                    CategoryID = rnd.Next(1, 11), //10 tane kategori olusturduk test için rasgele bunlardan biri olsun
                    ImagePath = "/images/ProductImages/Test.png",
                    KDV = 10
                };

                products.Add(product);
            }

            modelBuilder.Entity<Product>().HasData(products);
        }
    }
}
