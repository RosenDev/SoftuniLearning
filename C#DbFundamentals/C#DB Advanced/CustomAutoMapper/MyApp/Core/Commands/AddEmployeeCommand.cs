using AutoMapper;
using MyApp.Core.Interfaces;
using MyApp.Data;
using MyApp.Models;
using MyApp.ViewModels;

namespace MyApp.Core.Commands
{
    public class AddEmployeeCommand:ICommand
    {
        private readonly SampleDbContext context;
        private readonly Mapper mapper;

        public AddEmployeeCommand(SampleDbContext context, Mapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        public string Execute(string[] args)
        {
            var employee = new Employee()
            {
                FirstName = args[0],
                LastName = args[1],
                Salary = decimal.Parse(args[2])

            };
            context.Employees.Add(employee);
            context.SaveChanges();
            var employeeDto = mapper.CreateMappedObject<EmployeeDto>(employee);
            return $"Added Employee with Full Name = {employeeDto.FirstName+" "+employeeDto.LastName}";

        }
    }
}