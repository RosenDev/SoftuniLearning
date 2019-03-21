using System.Globalization;
using AutoMapper;
using MyApp.Core.Interfaces;
using MyApp.Data;
using MyApp.ViewModels;

namespace MyApp.Core.Commands
{
    public class EmployeePersonalInfoCommand:ICommand
    {
        private readonly SampleDbContext context;
        private readonly Mapper mapper;

        public EmployeePersonalInfoCommand(SampleDbContext context, Mapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        public string Execute(string[] args)
        {
            var id = int.Parse(args[0]);
            var employee = context.Employees.Find(id);
            var dto = mapper.CreateMappedObject<EmployeeDto>(employee);
            return $"ID: {id} - {dto.FirstName} {dto.LastName} -  ${dto.Salary:f2}\nBirthday: {employee.Birthday?.Date.ToString("dd-MM-yyyy", CultureInfo.InvariantCulture)}\nAddress: {employee.Address}";

        }
    }
}