using Company_MVC.Models;
using System.ComponentModel.DataAnnotations;

namespace Company_MVC.ViewModels
{
    public class EmployeeWithDeptViewModel
    {
        public int Id { get; set; }
        [Required]
        [MinLength(3, ErrorMessage = "First Name must be at least 3 characters")]
        [MaxLength(25, ErrorMessage = "First Name must be at most 25 characters")]
        public string FirstName { get; set; }
        [Required]
        [MinLength(3, ErrorMessage = "Last Name must be at least 3 characters")]
        [MaxLength(25, ErrorMessage = "Last Name must be at most 25 characters")]
        public string LastName { get; set; }
        [Required]
        [MaxLength(1, ErrorMessage = "Must be F Or M")]
        [MinLength(1, ErrorMessage = "Gender must contain a character")]
        public string Gender { get; set; }
        [Required]
        [Range(8000, 14000)]
        public decimal Salary { get; set; }
        [Required]
        [RegularExpression("(Cairo|Alex)", ErrorMessage = "Address Must be Only in Cairo Or Alex")]
        public string Address { get; set; }
        public int? DepartmentId { get; set; }
        public List<Department> Departments { get; set; } = new List<Department>();
    }
}
