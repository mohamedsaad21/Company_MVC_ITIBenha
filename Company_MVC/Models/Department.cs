using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Company_MVC.Models
{
    public class Department
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public DateOnly? ManagerStartDate { get; set; }
        #region Manager
        [ForeignKey("Manager")]
        public int ManagerId { get; set; }
        [InverseProperty("ManageDepartment")]
        public Employee Manager { get; set; }
        #endregion

        #region Work_DEpartment
        [InverseProperty("WorkDepartment")]
        public virtual List<Employee> Employee { get; set; } = new List<Employee>();
        #endregion
    }
}
