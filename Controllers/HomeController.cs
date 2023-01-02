using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

using EmployeeApp.Models;
using EmployeeApp.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace EmployeeApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly personalContext _dbContext;

        public HomeController(personalContext context)
        {
            _dbContext = context;
        }

        public IActionResult Index()
        {
            List<Employee> list = _dbContext.Employees.Include(c => c.PositionObject).ToList();
            return View(list);
        }

        [HttpGet]
        public IActionResult EmployeeDetail(int employeeId)
        {
            // return empty employee with a list of positions
            EmployeeVM newEmployeeVM = new EmployeeVM()
            {
                EmployeeObject = new Employee(),
                PositionListObject = _dbContext.Positions.Select(position => new SelectListItem()
                {
                    Text = position.Description,
                    Value = position.PositionId.ToString(),
                }).ToList()
            };

            if(employeeId != 0)
            {
                newEmployeeVM.EmployeeObject = _dbContext.Employees.Find(employeeId);
            }

            return View(newEmployeeVM);
        }

        [HttpPost]
        public IActionResult EmployeeDetail(EmployeeVM objectEmployeeVM)
        {
            if(objectEmployeeVM.EmployeeObject.EmployeeId == 0)
            {
                _dbContext.Employees.Add(objectEmployeeVM.EmployeeObject);
            } 
            else
            {
                _dbContext.Employees.Update(objectEmployeeVM.EmployeeObject);
            }

            _dbContext.SaveChanges();

            return RedirectToAction("Index", "Home");
        }
    }
}