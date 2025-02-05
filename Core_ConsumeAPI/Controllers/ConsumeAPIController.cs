using Core_ConsumeAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Drawing;

namespace Core_ConsumeAPI.Controllers
{
    public class ConsumeAPIController : Controller
    {
        ConsumeAPI consume = new ConsumeAPI();
        Student objstud = new Student();
        public IActionResult Index()
        {
            Country();
            objstud.ListStudent = consume.StudList();
            return View(objstud);
        }
        [HttpPost]
        public IActionResult Create(Student obj)
        {
            if(obj==null) return Json("Data Not Found");
            try
            {
                consume.SaveStudent(obj);
                return Json("Data Saved");
            }
            catch
            {
                return Json("Data Not Saved");
            }
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            if (id == 0) return Json("not found");
            return Json(consume.StudList().Find(x => x.Id == id));
            //return Json(consume.GetByIdAsync(id));
        }
        [HttpPost]
        public IActionResult Edit(Student obj)
        {
            if (obj == null) return Json("Data Not Found");
            try
            {
                if(consume.UpdateStudent(obj)) return Json("Data Updated");
                return Json("Failed to Updated..!");
            }
            catch
            {
                return Json("Data Not Updated");
            }   
        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
            if (id == 0) return Json("not found");
            try
            {
                if (consume.DeleteStudent(id)) return Json("Data Deleted");
                return Json("Failed to Deleted..!");
            }
            catch
            {
                return Json("Data Not Deleted");
            }
        }
        public async Task<IActionResult> Details(int id) 
        {
            objstud =await consume.GetByIdAsync(id);
            return PartialView("Details",objstud);
        }
        [HttpGet]
        public IActionResult StudentList()
        {
            var ListStudent = consume.StudList();
            return Json(ListStudent);
        }
        public void Country()
        {
            ViewBag.Country=consume.ListCountry();
        }
        [HttpGet]
        public IActionResult GetState(string country)
        {
            return Json(consume.ListState(country));
        }
        [HttpGet]
        public async Task<IActionResult> GetCity(string country,string state)
        {
            return Json(await consume.ListCityAsync(country,state));
        }
    }
}
