using System.Collections.Generic;
using MyApp.Models;

namespace MyApp.ViewModels
{
    public class ManagerDto
    {
        public ManagerDto()
        {
        Employees=new List<EmployeeDto>();
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<EmployeeDto> Employees { get; set; }
    }
}