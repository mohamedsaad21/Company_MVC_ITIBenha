using Company_MVC.Models;
using Company_MVC.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Company_MVC.Controllers
{
    public class ProjectController : Controller
    {
        CompanyDbContext Context = new CompanyDbContext();
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult GetAll()
        {
            var Projects = Context.Projects.Select(P => new Project
            {
                Id = P.Id,
                Name = P.Name,
                Location = P.Location,
                Department = P.Department,
            }).ToList();
            return View(Projects);
        }
        public IActionResult Details(int id)
        {

            var Project = Context.Projects.FirstOrDefault(P => P.Id == id);
            if (Project == null)
                return NotFound();
            return View(Project);
        }
        public IActionResult GetAddForm()
        {
            var PrjVM = new ProjectWithDeptViewModel();
            var Departments = Context.Departments.ToList();
            PrjVM.Departments = Departments;
            return View(PrjVM);
        }
        [HttpPost]
        public IActionResult SaveAdd(ProjectWithDeptViewModel PrjVM)
        {
            if (ModelState.IsValid)
            {
                var Project = new Project
                {
                    Name = PrjVM.Name,
                    Location = PrjVM.Location,
                    DepartmentId = PrjVM.DepartmentId,
                };
                Context.Projects.Add(Project);
                Context.SaveChanges();
                return RedirectToAction(nameof(GetAll));
            }
            var Departments = Context.Departments.ToList();
            PrjVM.Departments = Departments;
            return View(nameof(GetAddForm), PrjVM);
        }
        public IActionResult GetEditForm(int id)
        {
            var Project = Context.Projects.SingleOrDefault(P => P.Id == id);
            if (Project == null)
                return NotFound();
            var ProjVM = new ProjectWithDeptViewModel
            {
                Id = id,
                Name = Project.Name,
                Location = Project.Location,
                DepartmentId= Project.DepartmentId,
            };
            var Departments = Context.Departments.ToList();
            ProjVM.Departments = Departments;
            return View(ProjVM);
        }
        public IActionResult SaveEdit(ProjectWithDeptViewModel ProjVM)
        {
            if (ModelState.IsValid)
            {
                var Project = Context.Projects.SingleOrDefault(P => P.Id == ProjVM.Id);
                if (Project == null)
                    return NotFound();
                Project.Name = ProjVM.Name;
                Project.Location = ProjVM.Location;
                Project.DepartmentId = ProjVM.DepartmentId;
                Context.Projects.Update(Project);
                Context.SaveChanges();
                return RedirectToAction(nameof(GetAll));
            }
            var Departments = Context.Departments.ToList();
            ProjVM.Departments = Departments;
            return View(ProjVM);
        }
        public IActionResult Delete(int id)
        {
            var Project = Context.Projects.SingleOrDefault(P => P.Id == id);
            if (Project == null)
                return NotFound();
            Context.Projects.Remove(Project);
            Context.SaveChanges();
            return RedirectToAction(nameof(GetAll));
        }
    }
}
