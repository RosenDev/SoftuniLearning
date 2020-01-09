using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using SoftUni.Data;
using SoftUni.Models;

namespace SoftUni
{
  public  class StartUp
    {
        static void Main(string[] args)
        {
            //var context= new SoftUniContext();
            //Console.WriteLine(AddNewAddressToEmployee(context));
        }

        public static string  AddNewAddressToEmployee(SoftUniContext context)
        {
            var emp = context.Employees.Where(x => x.LastName == "Nakov");
var adress= new Address
{
    TownId = 4,
    AddressText = "Vitoshka 15",
    Employees = new List<Employee>(emp)
};
            context.Addresses.Add(adress);
            context.SaveChanges();
            var employees = context.Employees.Include(nameof(Address))
                .Select(x => new
                    {
                        x.AddressId,
                        x.Address.AddressText

                    }
                )
                .OrderByDescending(x => x.AddressId)
                .Take(10)
                .ToList();
            var sb = new StringBuilder();
            foreach (var employee in employees)
            {

                sb.AppendLine($"{employee.AddressText}");
            }

            return sb.ToString();
        }
    }
}
