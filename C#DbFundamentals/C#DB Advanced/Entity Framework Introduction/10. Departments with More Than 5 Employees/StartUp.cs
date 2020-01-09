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
            var context= new SoftUniContext();
            Console.WriteLine(GetDepartmentsWithMoreThan5Employees(context));
        }

        public static string GetDepartmentsWithMoreThan5Employees(SoftUniContext context)
        {
            var sb = new StringBuilder();
            context.Departments
                .Include(d => d.Employees)
                .Include(d => d.Manager)
                .Where(d => d.Employees.Count > 5)
                .OrderBy(d => d.Employees.Count)
                .ThenBy(d => d.Name)
                .ToList()
                .ForEach(d => sb.AppendLine($"{d.Name} - {d.Manager.FirstName} {d.Manager.LastName}{Environment.NewLine}{String.Join(Environment.NewLine, d.Employees.OrderBy(e => e.FirstName).ThenBy(e => e.LastName).Select(e => $"{e.FirstName} {e.LastName} - {e.JobTitle}").ToList())}{Environment.NewLine}{new string('-', 10)}"));
           
           
             
            return sb.ToString();
        }
    }
}
