using AutoMapper;
using CarDealer.Data;
using CarDealer.DTO;
using CarDealer.Models;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;

namespace CarDealer
{
    public class StartUp
    {

        public static void Main(string[] args)
        {
          
            Mapper.Initialize(x => x.AddProfile(new CarDealerProfile()));
          




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
        public static string ImportSuppliers(CarDealerContext context, string inputJson)
        {
            var suppliers = JsonConvert.DeserializeObject<List<Supplier>>(inputJson);
            context.Suppliers.AddRange(suppliers);
            context.SaveChanges();
            return $"Successfully imported {suppliers.Count}.";
        }

    
        public static string ImportCars(CarDealerContext context, string inputJson)
        {


            var cars = JsonConvert.DeserializeObject<List<CarDto>>(inputJson);

            foreach (var carDto in cars)
            {
                var car = Mapper.Map<Car>(carDto);
                context.Cars.Add(car);
               
                carDto.PartsId = carDto.PartsId.Distinct().ToList();
                foreach (var i in carDto.PartsId)
                {
                    context.PartCars.Add(new PartCar { Car = car, Part = context.Parts.Find(i) });

                  
                }



            }

            context.SaveChanges();
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
         public static string GetCarsFromMakeToyota(CarDealerContext context)
         {
             var toyotas = context.Cars
                 .Where(x => x.Make == "Toyota")
                 .OrderBy(x => x.Model)
                 .ThenByDescending(x => x.TravelledDistance)
                 .ProjectTo<CarDto>()
                 .ToList();
             return JsonConvert.SerializeObject(toyotas, Formatting.Indented);
         }

   
        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            var cars = context.Cars
                .Select(c => new
                {
                    car = new
                    {
                        c.Make,
                        c.Model,
                        c.TravelledDistance
                    },
                    parts = c.PartCars.Select(p => new
                    {
                        p.Part.Name,
                        Price = $"{p.Part.Price:F2}"
                    })
                });

            return JsonConvert.SerializeObject(cars, Formatting.Indented);

        }
    }
}