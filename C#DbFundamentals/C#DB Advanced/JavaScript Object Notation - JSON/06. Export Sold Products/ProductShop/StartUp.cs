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
               public static string GetSoldProducts(ProductShopContext context)
        {

           var users= context.Users
                .Where(x => x.ProductsSold.Any(y => y.BuyerId != null))
                .OrderBy(x => x.LastName)
                .ThenBy(x => x.FirstName)
                .Select(x => new
                {
                    x.FirstName,
                    x.LastName,
                    SoldProducts = x.ProductsSold.Where(z => z.BuyerId != null)
                        .Select(a => new
                        {
                            a.Name,
                            a.Price,
                            BuyerFirstName = a.Buyer.FirstName,
                            BuyerLastName = a.Buyer.LastName
                        }).ToList()

                }).ToList();

            var resolver = new DefaultContractResolver()
            {
                NamingStrategy = new CamelCaseNamingStrategy()
            };
            var json = JsonConvert.SerializeObject(users, Formatting.Indented,new JsonSerializerSettings(){ContractResolver = resolver});
            return json;
        }
    }
}