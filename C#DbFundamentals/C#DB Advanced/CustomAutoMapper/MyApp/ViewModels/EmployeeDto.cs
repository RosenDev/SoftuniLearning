using MyApp.Models;

namespace MyApp.ViewModels
{
    public class EmployeeDto
    {
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public decimal Salary { get; set; }
        public EmployeeDto Manager { get; set; }
    }
}