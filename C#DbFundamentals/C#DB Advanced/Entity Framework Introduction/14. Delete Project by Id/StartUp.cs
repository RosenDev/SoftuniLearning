using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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
            Console.WriteLine(DeleteProjectById(context));
        }

        public static string DeleteProjectById(SoftUniContext context)
        {
            var sb = new StringBuilder();
            var project = context.Projects.Find(2);

            context.EmployeesProjects.ToList().ForEach(ep => context.EmployeesProjects.Remove(ep));
          
            context.Projects.Remove(project);
            context.SaveChanges();
            var projects = context.Projects.Take(10).ToList();
            projects.ForEach(x=>sb.AppendLine(x.Name));
            return sb.ToString().Trim();
        }
    }
}
