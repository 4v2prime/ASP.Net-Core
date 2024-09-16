using ASPCoreENTCode1st.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGet.DependencyResolver;
using System.Diagnostics;

namespace ASPCoreENTCode1st.Controllers
{
    public class HomeController : Controller
    {

        //private readonly ILogger<HomeController> _logger;

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}
        private readonly EmployeeDBContext employeeDB;
        public HomeController(EmployeeDBContext employeeDB)
        {
            this.employeeDB = employeeDB;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var emplist =employeeDB.Employees.ToList();
            return View(emplist);
        }
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.IsEdit = false;
            return View();
        }
        [HttpPost]
        public IActionResult Create(Employee emp)
        {
            employeeDB.Employees.Add(emp);
            employeeDB.SaveChanges();
            TempData["alert_msg"] = "Saved successfully...!";
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            Employee employee = employeeDB.Employees.SingleOrDefault(x => x.ID == id);
            return View("Create",employee);
        }
        [HttpPost]
        public IActionResult Edit(Employee emp)
        {
            Employee employee = employeeDB.Employees.SingleOrDefault(x => x.ID == emp.ID);
            if (employee != null) 
            {
                employeeDB.Update(emp);
                employeeDB.SaveChanges();
                TempData["alert_msg"] = "Updated successfully...!";
                ViewBag.IsEdit=true;
                return RedirectToAction("Index");
            }

            return View(employee);
        }
        [HttpGet]
        public IActionResult Details(int id)
        {
            Employee employee = employeeDB.Employees.SingleOrDefault(x => x.ID == id);
            return PartialView("Details",employee);
        }
    
        public IActionResult Delete(int id)
        {
            Employee employee = employeeDB.Employees.SingleOrDefault(x => x.ID == id);
            if (employee != null)
            {
                employeeDB.Employees.Remove(employee);
                employeeDB.SaveChanges();
                TempData["alert_msg"] = "Deleted successfully...!";
                return RedirectToAction("Index");
            }
            else
            {
                return View("error");
            }
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
