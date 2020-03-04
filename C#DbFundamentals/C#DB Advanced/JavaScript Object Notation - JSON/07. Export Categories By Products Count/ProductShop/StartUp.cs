using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using ProductShop.DTOs;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json.Linq;
using ProductShop.Data;
using ProductShop.Models;

namespace ProductShop
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
           Mapper.Initialize(x=>x.CreateMap<Product,ProductDto>().ForMember(productDto=>productDto.Seller,y=>y.MapFrom(product=>product.Seller.FirstName+" "+product.Seller.LastName)));
        }
                          public static string GetCategoriesByProductsCount(ProductShopContext context)
        {

            var cat = context.Categories
                .OrderByDescending(x => x.CategoryProducts.Count)
                .Select(x => new
                {
                   Category= x.Name,
                   ProductsCount= x.CategoryProducts.Count,
                    AveragePrice = x.CategoryProducts
                        .Select(y => y.Product)                        
                        .Average(z => z.Price).ToString("f2"),
                    TotalRevenue= x.CategoryProducts
                        .Select(y => y.Product)                    
                        .Sum(z => z.Price).ToString("F2")
                })
                .ToList();
            var resolver = new DefaultContractResolver()
            {
                NamingStrategy = new CamelCaseNamingStrategy()
            };
            var json = JsonConvert.SerializeObject(cat, new JsonSerializerSettings() {ContractResolver = resolver});
            return json;

        }
    }
}