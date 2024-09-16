using DatabaseFirstAspCore.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Build.Framework;
using Microsoft.Build.ObjectModelRemoting;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;
using System.Diagnostics;
using System.Net.WebSockets;

namespace DatabaseFirstAspCore.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly WatchListContext context;

        public HomeController(ILogger<HomeController> logger, WatchListContext context)
        {
            _logger = logger;
            this.context = context;
        }

        public async Task<IActionResult> Index()
        {
            var lstanime = await context.TblAnimeLists.ToListAsync();
            return View(lstanime);
        }
        public async Task<IActionResult> Create()
        {
            await ListStatus();
            return await Task.Run(() => View());
        }
        [HttpPost]
        public async Task<IActionResult> Create(TblAnimeList ani)
        {
            if (ModelState.IsValid)
            {
                if (ani == null) { return NotFound(); }
                
                    context.TblAnimeLists.Add(ani);
                    await context.SaveChangesAsync();
                    TempData["msg_success"] = "New anime added successfully...!";
                    TempData["edit"] = "no";
                    return RedirectToAction("Index");
                
            }
            return View();
        }
        public async Task<IActionResult> Details(int id)
        {
            var lstani = await context.TblAnimeLists.FirstOrDefaultAsync(x => x.Id == id);
            if (lstani == null)
            {
                return NotFound();
            }
            if (lstani == null)
            {
                return NotFound();
            }
            return View(lstani);
        }
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) { return NotFound(); }
            var lstani = context.TblAnimeLists.FirstOrDefault(x => x.Id == id);
            await ListStatus();
            TempData["edit"] = "yes";
            return await Task.Run(() => View("Create", lstani));
        }
        [HttpPost]
        public async Task<IActionResult> Edit(TblAnimeList ani)
        {
            if (ModelState.IsValid)
            {
                if (ani == null) { return NotFound(); };
                context.TblAnimeLists.Update(ani);
                await context.SaveChangesAsync();
                TempData["msg_update"] = "Update successfully...!";
                return RedirectToAction("Index");
            }

            return await Task.Run(() => View());
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) { return NotFound(); }
            var lstanime = context.TblAnimeLists.FirstOrDefault(x => x.Id == id);
            if (lstanime == null) { return NotFound(); }
            context.TblAnimeLists.Remove(lstanime);
            await context.SaveChangesAsync();
            TempData["msg_delete"] = "entry deleted successfully...!";
            return await Task.Run(() => View());
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
        public async Task ListStatus()
        {
            ViewBag.Sataus = context.TblStatuses
            .Select(status => new SelectListItem
            {
                Value = status.Sid.ToString(),  
                Text = status.Status      
            }).ToList();
        }
    }
}
