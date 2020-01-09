using System;
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
            //Console.WriteLine(GetEmployeesFromResearchAndDevelopment(context));
        }

        public static string GetEmployeesFromResearchAndDevelopment(SoftUniContext context)
        {
            var employees = context.Employees
                .Include(nameof(Department))
                .Select(x => new
            {
                x.FirstName,
                x.LastName,
                DepartmentName=x.Department.Name,
                 x.Salary
            })
            .Where(x=>x.DepartmentName== "Research and Development")
            .OrderBy(x=>x.Salary)
            .ThenByDescending(x=>x.FirstName)
            .ToList();
            var sb = new StringBuilder();
            foreach (var employee in employees)
            {

                sb.AppendLine($"{employee.FirstName} {employee.LastName} from {employee.DepartmentName} - ${employee.Salary:f2}");
            }

            return sb.ToString();
        }
    }
}
