using System;
using System.Collections.Generic;
using System.Globalization;
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
            Console.WriteLine(GetLatestProjects(context));
        }

        public static string GetLatestProjects(SoftUniContext context)
        {
            var sb = new StringBuilder();
            var projects = context.Projects
               
                .Select(x => new
                {

                    x.Name,
                    x.Description,
                    x.StartDate
                }).OrderByDescending(x => x.StartDate)
                .Take(10)
                .OrderBy(x => x.Name)
               

                .ToList();
                projects.ForEach(x =>
                {
                    sb.AppendLine($"{x.Name}{Environment.NewLine}{x.Description}{Environment.NewLine}{x.StartDate}"); 

                });
            return sb.ToString().Trim();
        }
    }
}
