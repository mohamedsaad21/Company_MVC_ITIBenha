using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Company_MVC.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public char Minit { get; set; }
        public DateOnly BirthDate { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        [Column(TypeName = "money")]
        public decimal Salary { get; set; }
        #region Work_Department
        [ForeignKey("WorkDepartment")]
        public int? DepartmentId { get; set; }
        public Department? WorkDepartment { get; set; }
        #endregion


        #region Supervisor
        [ForeignKey("Supervisor")]
        public int? SupervisorId { get; set; }
        public Employee Supervisor { get; set; }
        [InverseProperty("Supervisor")]
        public virtual List<Employee> Employees { get; set; }
        #endregion
        #region Manage_Department
        public Department ManageDepartment { get; set; }
        #endregion
        public virtual List<Works_On> WorksOn { get; set; }
        public virtual List<Dependent> Dependents { get; set; }
    }
}
