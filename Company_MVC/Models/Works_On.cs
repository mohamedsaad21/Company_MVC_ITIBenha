using System.ComponentModel.DataAnnotations.Schema;

namespace Company_MVC.Models
{
    public class Works_On
    {
        [ForeignKey("Employee")]
        public int EmployeeId { get; set; }
        [ForeignKey("Project")]
        public int ProjectId { get; set; }
        public int Hours { get; set; }
        public Employee Employee { get; set; }
        public Project Project { get; set; }
    }
}
