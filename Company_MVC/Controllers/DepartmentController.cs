using Company_MVC.Models;
using Company_MVC.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Company_MVC.Controllers
{
    public class DepartmentController : Controller
    {
        CompanyDbContext Context = new CompanyDbContext();
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult GetAll()
        {
            var Departments = Context.Departments.Select(D => new Department
            {
                Id = D.Id,
                Name = D.Name,
                Manager = D.Manager,                
            }).ToList();
            return View(Departments);
        }
        public IActionResult Details(int id)
        {

            var Department = Context.Departments.FirstOrDefault(D => D.Id == id);
            if (Department == null)
                return NotFound();
            return View(Department);
        }
        public IActionResult GetAddForm()
        {
            List<Employee> emps = Context.Departments.Include(d => d.Manager)
                .Select(d => d.Manager)
                .ToList();
            var DeptVM = new DepartmentWithEmpViewModel();
            List<Employee> Managers = Context.Employees.Except<Employee>(emps).Distinct().ToList();
            DeptVM.Managers = Managers;
            return View(DeptVM);
        }
        [HttpPost]
        public IActionResult SaveAdd(DepartmentWithEmpViewModel DeptVM)
        {
            if (ModelState.IsValid)
            {
                var Department = new Department
                {
                    Name = DeptVM.Name,
                    
                    ManagerId = DeptVM.ManagerId,
                };
                Context.Departments.Add(Department);
                Context.SaveChanges();
                return RedirectToAction(nameof(GetAll));
            }
            var Employees = Context.Employees.ToList();
            DeptVM.Managers = Employees;
            return View(nameof(GetAddForm), DeptVM);
        }
        public IActionResult GetEditForm(int id)
        {
            var Department = Context.Departments.Include(D => D.Manager).SingleOrDefault(D => D.Id == id);
            if (Department == null)
                return NotFound();
            var DeptVM = new DepartmentWithEmpViewModel
            {
                Id = id,
                Name = Department.Name,
                ManagerId = Department.ManagerId
            };
            var Managers = Context.Employees.ToList();
            DeptVM.Managers = Managers;
            return View(DeptVM);
        }
        public IActionResult SaveEdit(DepartmentWithEmpViewModel DeptVM)
        {
            if (ModelState.IsValid)
            {
                var Department = Context.Departments.SingleOrDefault(e => e.Id == DeptVM.Id);
                if (Department == null)
                    return NotFound();
                Department.Name = DeptVM.Name;
                Department.ManagerId = DeptVM.ManagerId;
                Context.Departments.Update(Department);
                Context.SaveChanges();
                return RedirectToAction(nameof(GetAll));
            }
            var Managers = Context.Employees.ToList();
            DeptVM.Managers = Managers;
            return View(DeptVM);
        }
        public IActionResult Delete(int id)
        {
            var Department = Context.Departments.SingleOrDefault(D => D.Id == id);
            if (Department == null)
                return NotFound();
            Context.Departments.Remove(Department);
            Context.SaveChanges();
            return RedirectToAction(nameof(GetAll));
        }

    }
}
