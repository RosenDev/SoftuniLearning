using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;
using SoftUni.Data;
using SoftUni.Models;

namespace SoftUni
{
  public  class StartUp
    {
        static void Main(string[] args)
        {
            var context= new SoftUniContext();
            Console.WriteLine(GetEmployeesInPeriod(context));
        }

        public static string GetEmployeesInPeriod(SoftUniContext context)
        {
            var employees = context.Employees.Select(x => new
                {
                    x.FirstName,
                    x.LastName,
                    ManagerFirstName = x.Manager.FirstName,
                    ManagerLastName = x.Manager.LastName,
                    Projects = x.EmployeesProjects.Select(y => y.Project) //.ToList()


                }).Where(x => x.Projects.Any(y => y.StartDate.Year >= 2001 && y.StartDate.Year <= 2003))
                .Take(10)
                .ToList();
                
            var sb = new StringBuilder();
            foreach (var employee in employees)
            {

                sb.AppendLine($"{employee.FirstName} {employee.LastName} - Manager: {employee.ManagerFirstName} {employee.ManagerLastName}");
                foreach (var project in employee.Projects)
                {
                    sb.AppendLine($"--{project.Name} - {project.StartDate.ToString("M/d/yyyy h:mm:ss tt",CultureInfo.InvariantCulture)} - { (project.EndDate!=null?project.EndDate?.ToString("M/d/yyyy h:mm:ss tt",CultureInfo.InvariantCulture):"not finished")}");
                }
            }
          
            return sb.ToString();
        }
    }
}
