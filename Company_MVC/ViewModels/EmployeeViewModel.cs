using Company_MVC.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Company_MVC.ViewModels
{
    public class EmployeeViewModel
    {
        public int Id { get; set; }
        
        public string FirstName { get; set; }
        
        public string LastName { get; set; }
        public DateOnly BirthDate { get; set; }
        
        public string Gender { get; set; }
        
        public string Address { get; set; }
        public int? DepartmentId { get; set; }
        public Department? WorkDepartment { get; set; }
        //public  List<Department> Departments { get; set; } = new List<Department>();
        public  List<Employee> Employees { get; set; } = new List<Employee>();

    }
}
