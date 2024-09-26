using System.ComponentModel.DataAnnotations.Schema;

namespace Company_MVC.Models
{
    public class Dependent
    {
        [ForeignKey("Employee")]
        public int EmployeeId { get; set; }
        public string DependentName { get; set; }
        public DateOnly BirthDate { get; set; }
        public char Gender { get; set; }
        public string RelationShip {  get; set; }
        public Employee Employee { get; set; }
    }
}
