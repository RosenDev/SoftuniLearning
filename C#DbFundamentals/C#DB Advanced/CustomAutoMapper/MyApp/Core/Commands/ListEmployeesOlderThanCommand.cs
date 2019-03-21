using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using MyApp.Core.Interfaces;
using MyApp.Data;
using MyApp.ViewModels;

namespace MyApp.Core.Commands
{
    public class ListEmployeesOlderThanCommand:ICommand
    {
        private readonly SampleDbContext context;
        private readonly Mapper mapper;

        public ListEmployeesOlderThanCommand(SampleDbContext context, Mapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        public string Execute(string[] args)
        {
            var age = int.Parse(args[0]);
            var employees = context
                .Employees
                .Where(x => DateTime.Now.Year - x.Birthday.Value.Year > age)
                .OrderByDescending(x=>x.Salary)
                .ToList();

            var employeesDto = new List<EmployeeDto>();
            employees.ForEach(x=>employeesDto.Add(mapper.CreateMappedObject<EmployeeDto>(x)));

            var sb = new StringBuilder();
            employeesDto.ForEach(x=>sb.AppendLine($"{x.FirstName+" "+x.LastName} - ${x.Salary:f2} - Manager: {(x.Manager==null?"[no manager]":x.Manager.FirstName)}"));
           
            return sb.ToString().Trim();

        }
    }
}