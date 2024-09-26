using Company_MVC.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace Company_MVC.ViewModels
{
    public class DepartmentWithEmpViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ManagerId { get; set; }
        public List<Employee> Managers { get; set; } = new List<Employee>();
    }
}
