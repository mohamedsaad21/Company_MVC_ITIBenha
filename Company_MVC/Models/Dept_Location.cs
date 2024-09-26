using System.ComponentModel.DataAnnotations.Schema;

namespace Company_MVC.Models
{
    public class Dept_Location
    {
        [ForeignKey("Department")]
        public int DepartmentId { get; set; }
        public string Location { get; set; }
        public Department Department { get; set; }
    }
}
