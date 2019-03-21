using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using AutoMapper;
using MyApp.Core.Interfaces;
using MyApp.Data;
using MyApp.ViewModels;

namespace MyApp.Core.Commands
{
    public class ManagerInfoCommand:ICommand

    {
        private readonly Mapper mapper;
        private readonly SampleDbContext context;

        public ManagerInfoCommand(Mapper mapper, SampleDbContext context)
        {
            this.mapper = mapper;
            this.context = context;
        }
        public string Execute(string[] args)
        {
            var sb = new StringBuilder();
            var id = int.Parse(args[0]);
            var allEmployees = context.Employees.ToList();
            var manager = context.Employees.Find(id);
            var dto = mapper.CreateMappedObject<ManagerDto>(manager);
            sb.AppendLine($"{dto.FirstName+" "+dto.LastName} | Employees: {dto.Employees.Count}");
           dto.Employees.ToList().ForEach(x=>sb.AppendLine($"- {x.FirstName+" "+x.LastName} - ${x.Salary:f2}"));
            return sb.ToString().Trim();
        }
    }
}