using System;
using System.Globalization;
using System.Linq;
using AutoMapper;
using MyApp.Core.Interfaces;
using MyApp.Data;
using MyApp.ViewModels;

namespace MyApp.Core.Commands
{
    public class SetAddressCommand:ICommand
    {
        private readonly SampleDbContext context;
        private readonly Mapper mapper;

        public SetAddressCommand(SampleDbContext context, Mapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        public string Execute(string[] args)
        {
            var id = int.Parse(args[0]);
            var address = args[1];
            var employee = context.Employees.FirstOrDefault(x => x.EmployeeId == id);
            employee.Address = address;
            context.SaveChanges();
            var dto = mapper.CreateMappedObject<EmployeeDto>(employee);
            return $"Changed Address of the Employee {dto.FirstName + " " + dto.LastName} to {employee.Address}";


        }
    }
}