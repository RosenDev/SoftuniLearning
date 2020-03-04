using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using ProductShop.DTOs;
using Newtonsoft.Json;
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
        public static string GetProductsInRange(ProductShopContext context)
        {
          
            var products = context.Products.Where(x=>x.Price>=500m&&x.Price<=1000m).OrderBy(x=>x.Price).Select(x=>new
            {
                x.Name,
                x.Price,
                Seller=x.Seller.FirstName+" "+x.Seller.LastName
            }).ProjectTo<ProductDto>()
                .ToList();
            return JsonConvert.SerializeObject(products,Formatting.None);
        }
    }
}