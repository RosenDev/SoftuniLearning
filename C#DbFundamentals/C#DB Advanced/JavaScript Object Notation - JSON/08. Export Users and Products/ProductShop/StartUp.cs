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
            public static string GetUsersWithProducts(ProductShopContext context)
        {

            var users = context.Users
                .Where(x => x.ProductsSold.Any(u => u.BuyerId != null))
                .OrderByDescending(x => x.ProductsSold.Count(a => a.BuyerId != null))
                .Select(x=>new
                {
                    x.FirstName,
                    x.LastName,
                    x.Age,
                    SoldProducts =
                   new
                    {Count=x.ProductsSold.Count(product=>product.BuyerId!= null),
                        Products=x.ProductsSold.Where(d=>d.BuyerId!=null).Select(z=>new
                        {
                            z.Name,
                            z.Price
                        }).ToList()

                    }

                }).ToList();
            var resolver= new DefaultContractResolver
            {
                NamingStrategy = new CamelCaseNamingStrategy(),
             

            };
            var json = JsonConvert.SerializeObject(new {UsersCount=users.Count,users},
                new JsonSerializerSettings {NullValueHandling = NullValueHandling.Ignore, ContractResolver = resolver,Formatting = Formatting.Indented });
            return json;
        }
 
    }
}