using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AutoMapper;
using CarDealer.Data;
using CarDealer.DTO;
using CarDealer.Models;
using Newtonsoft.Json;
using AutoMapper.QueryableExtensions;

namespace CarDealer
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Mapper.Initialize(x => x.AddProfile(new CarDealerProfile()));
        }
        public static string ImportSuppliers(CarDealerContext context, string inputJson)
        {
            var suppliers = JsonConvert.DeserializeObject<List<Supplier>>(inputJson);
            context.Suppliers.AddRange(suppliers);
            context.SaveChanges();
            return $"Successfully imported {suppliers.Count}.";
        }
        public static string ImportParts(CarDealerContext context, string inputJson)
        {
            var parts = JsonConvert.DeserializeObject<List<Part>>(inputJson)
                .Where(x => context.Suppliers.Any(u => u.Id == x.SupplierId))
                .ToList();
            context.Parts.AddRange(parts);
            context.SaveChanges();
            return $"Successfully imported {parts.Count}.";
        }
        public static string ImportCars(CarDealerContext context, string inputJson)
        {
           // Mapper.Initialize(x => x.AddProfile(new CarDealerProfile()));

            var cars = JsonConvert.DeserializeObject<List<CarDto>>(inputJson);

            foreach (var carDto in cars)
            {
                var car = Mapper.Map<Car>(carDto);
                context.Cars.Add(car);
                context.SaveChanges();
                foreach (var i in carDto.PartsId)
                {
                    context.PartCars.Add(new PartCar { Car = car, Part = context.Parts.Find(i) });

                    context.SaveChanges();
                }



            }


            return $"Successfully imported {cars.Count}.";
        }
        public static string ImportCustomers(CarDealerContext context, string inputJson)
        {
            var customers = JsonConvert.DeserializeObject<List<Customer>>(inputJson);
            context.Customers.AddRange(customers);
            context.SaveChanges();

            return $"Successfully imported {customers.Count}.";
        }
        public static string ImportSales(CarDealerContext context, string inputJson)
        {
            var sales = JsonConvert.DeserializeObject<List<Sale>>(inputJson);
            context.Sales.AddRange(sales);
            context.SaveChanges();

            return $"Successfully imported {sales.Count}.";
        }
        public static string GetOrderedCustomers(CarDealerContext context)
        {
            var customers = context.Customers
                .OrderBy(x => x.BirthDate)
                .ThenBy(x => x.IsYoungDriver)
                .ProjectTo<CustomerDto>()
                .ToList();
            return JsonConvert.SerializeObject(customers, Formatting.Indented);
        }
    }
}