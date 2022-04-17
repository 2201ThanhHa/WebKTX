using KTX_MVC.Context;
using KTX_MVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace KTX_MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        MVCContext db;


        public HomeController(MVCContext _db)
        {
            db = _db;
        }

        public IActionResult Index()
        {
            IEnumerable<Students> studens = db.Students.Select(s => s).ToList();
            return View(studens);
        }

        public IActionResult Delete(String id)
        {
            Students student = db.Students.FirstOrDefault(s => s.StudentId == id);
            if (student != null)
            {
                db.Remove(student);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View();
        }

        public IActionResult Insert(Students data)
        {
            if (data != null)
            {
                db.Students.Add(data);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View();
        }

        public IActionResult Privacy()
        {
            IEnumerable<Students> studens = db.Students.Select(s => s).ToList();
            return View(studens);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}