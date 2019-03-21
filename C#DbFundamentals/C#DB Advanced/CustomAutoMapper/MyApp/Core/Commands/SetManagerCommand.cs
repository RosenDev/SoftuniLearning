using AutoMapper;
using MyApp.Core.Interfaces;
using MyApp.Data;

namespace MyApp.Core.Commands
{
    public class SetManagerCommand:ICommand
    {
        private readonly SampleDbContext context;
   

        public SetManagerCommand(SampleDbContext context)
        {
            this.context = context;
      
        }
        public string Execute(string[] args)
        {
            var employeeId = int.Parse(args[0]);
            var managerId = int.Parse(args[1]);
            var manager = context.Employees.Find(managerId);
            var employee = context.Employees.Find(employeeId);
            employee.Manager = manager;
        
            context.SaveChanges();
            return $"Set employee {managerId} to be manager of {employeeId}";


        }
    }
}