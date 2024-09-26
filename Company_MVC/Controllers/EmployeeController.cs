using Company_MVC.Models;
using Company_MVC.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace Company_MVC.Controllers
{
    public class EmployeeController : Controller
    {
        CompanyDbContext Context = new CompanyDbContext();
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult GetAll()
        {
            var department = Context.Departments.ToList();
            var Emps = Context.Employees.ToList();

            var Employees = Context.Employees
                .Include(x => x.WorkDepartment).ToList();
                //.Select(emp => new Employee
                //{
                //    Id = emp.Id,
                //    FirstName = emp.FirstName,
                //    LastName = emp.LastName,
                //    BirthDate = emp.BirthDate,
                //    Gender = emp.Gender,
                //    Address = emp.Address,
                //    DepartmentId = emp.WorkDepartment.Id,
                    
                //}).ToList();
            return View(Employees);
        }
        public IActionResult Details(int id)
        {
            
            var employee = Context.Employees.FirstOrDefault(emp => emp.Id == id);
            if (employee == null)
                return NotFound();   
            return View(employee);
        }
        public IActionResult GetAddForm()
        {
            var EmpVM = new EmployeeWithDeptViewModel();
            var Departments = Context.Departments.ToList();
            EmpVM.Departments = Departments;
            return View(EmpVM);
        }
        [HttpPost]
        public IActionResult SaveAdd(EmployeeWithDeptViewModel EmpVM)
        {
            if (ModelState.IsValid)
            {
                var employee = new Employee
                {
                    FirstName = EmpVM.FirstName,
                    LastName = EmpVM.LastName,
                    Gender = EmpVM.Gender,
                    Address = EmpVM.Address,
                    DepartmentId = EmpVM.DepartmentId,
                };
                Context.Employees.Add(employee);
                Context.SaveChanges();
                return RedirectToAction(nameof(GetAll));
            }
            var Departments = Context.Departments.ToList();
            EmpVM.Departments = Departments;
            return View(nameof(GetAddForm),EmpVM);
        }
        public IActionResult GetEditForm(int id)
        {
            var Employee = Context.Employees.SingleOrDefault(x => x.Id == id);
            if (Employee == null)
                return NotFound();
            var EmpVM = new EmployeeWithDeptViewModel
            {
                Id = id,
                FirstName = Employee.FirstName,
                LastName = Employee.LastName,
                Gender = Employee.Gender,
                Address = Employee.Address,
                DepartmentId = Employee.DepartmentId,
            };
            var Departments = Context.Departments.ToList();
            EmpVM.Departments = Departments;
            return View(EmpVM);
        }
        public IActionResult SaveEdit(EmployeeWithDeptViewModel EmpVM)
        {
            if(ModelState.IsValid)
            {
                var employee = Context.Employees.SingleOrDefault(e => e.Id == EmpVM.Id);
                if (employee == null)
                    return NotFound();
                employee.FirstName = EmpVM.FirstName;
                employee.LastName = EmpVM.LastName;
                employee.Gender = EmpVM.Gender;
                employee.Address = EmpVM.Address;
                employee.DepartmentId = EmpVM.DepartmentId;                
                Context.Employees.Update(employee);
                Context.SaveChanges();
                return RedirectToAction(nameof(GetAll));
            }
            var Departments = Context.Departments.ToList();
            EmpVM.Departments = Departments;
            return View("GetEditForm", EmpVM);
        }
        public IActionResult Delete(int id)
        {
            var Employee = Context.Employees.SingleOrDefault(x => x.Id == id);
            if (Employee == null)
                return NotFound();
            Context.Employees.Remove(Employee);
            Context.SaveChanges();
            return RedirectToAction(nameof(GetAll));
        }
    }
}
