using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System.Diagnostics;
using WebAppDemo.Models;
using WebAppDemo.Data.Services;
using WebAppDemo.Data.Model;
using WebAppDemo.Data.Repository;

namespace WebAppDemo.Controllers
{
    public class HomeController : Controller
    {
        private UserService UserService; 
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, UserService obj)
        {
            _logger = logger;
            this.UserService = obj;
        }
        public IActionResult User()
        {
            return View();
        }

        public IActionResult UserRegistration()
        {

            List<tblUser> lstTblUsers = UserService.UserListData();
            //UserRegistrationViewModel obj = new UserRegistrationViewModel();
            //obj.lstUsers = lstTblUsers;
            //obj.User = new tblUser();
            UserRegistrationViewModel obj = new UserRegistrationViewModel
            {
                User = new tblUser(),  
                lstUsers = lstTblUsers 
            };
            return View(obj);
        }
        public IActionResult SaveUserRegistration(UserRegistrationViewModel obj)
        {
            if (obj.User.RegistrationId == 0)
            {
                UserService.SaveUser(obj);
            }
            else
            {
                UserService.UpdateById(obj);
            }
            return RedirectToAction("UserRegistration");
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult UsersList()
        {
           List<tblUser> lstTblUsers =  UserService.UserListData();
           return View(lstTblUsers);
        }

        public IActionResult GetUserById(int id)
        {

            List<tblUser> lstTblUsers = UserService.UserListData();
            var data = UserService.GetById(id);
            UserRegistrationViewModel obj = new UserRegistrationViewModel();
            obj.User = data;
            obj.lstUsers = lstTblUsers;
            return View("UserRegistration",obj);
        }
        [HttpPost]
        public IActionResult DeleteUser(int id)
        {

            UserRegistrationViewModel obj = new UserRegistrationViewModel();
            obj.User = new tblUser();
            obj.User.RegistrationId = id;
            UserService.DeleteById(obj);
            return RedirectToAction("UserRegistration");
        }
        //public IActionResult UpdateUserById(UserRegistrationViewModel obj)
        //{
        //    UserService.UpdateById(obj);
        //    return RedirectToAction("UserRegistration");
        //}


        public IActionResult Privacy()
        {
            //this.userservuce.dgs(Model)
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}