using System;
using System.Globalization;
using System.Linq;
using AutoMapper;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using MyApp.Core.Interfaces;
using MyApp.Data;
using MyApp.ViewModels;

namespace MyApp.Core.Commands
{
    public class SetBirthdayCommand:ICommand
    {
        private readonly SampleDbContext context;
        private readonly Mapper mapper;

        public SetBirthdayCommand(SampleDbContext context, Mapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        public string Execute(string[] args)
        {

            var id = int.Parse(args[0]);
            var date = DateTime.ParseExact(args[1], "dd-MM-yyyy", CultureInfo.InvariantCulture);
            var employee = context.Employees.FirstOrDefault(x => x.EmployeeId == id);
            employee.Birthday = date;
            context.SaveChanges();
            var dto = mapper.CreateMappedObject<EmployeeDto>(employee);
            return $"Changed Birthday of the Employee {dto.FirstName+" "+dto.LastName} to {employee.Birthday?.ToString("dd-MM-yyyy")}";

        }
    }
}