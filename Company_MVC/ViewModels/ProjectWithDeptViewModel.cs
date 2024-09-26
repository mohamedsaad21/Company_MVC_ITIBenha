using Company_MVC.Models;

namespace Company_MVC.ViewModels
{
    public class ProjectWithDeptViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public int DepartmentId { get; set; }
        public List<Department> Departments { get; set; } = new List<Department>();
    }
}
