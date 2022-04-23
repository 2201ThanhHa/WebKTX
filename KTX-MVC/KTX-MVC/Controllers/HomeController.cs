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
          
            return View();
        }

        public IActionResult Delete(String id)
        {
            Students student = db.Students.FirstOrDefault(s => s.Id == id);
            if (student != null)
            {
                db.Remove(student);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View();
        }

        public IActionResult Insert(FormSubmit data)
        {
            try
            {
                Students student = new Students();
                student.Id = data.StudentId;
                student.StudentName = data.StudentName;
                student.StudentDob = data.StudentDob;
                student.StudentSex = data.StudentSex;
                student.StudentPhone = data.StudentPhone;
                student.StudentEmail = data.StudentEmail;
                student.StudentLink = data.StudentLink;
                student.StudentSpecialized = data.StudentSpecialized;
                student.StudentMajors = data.StudentMajors;
                student.StudentPrioritize = data.StudentPrioritize;
                student.StudentPrioritizeImage = data.StudentPrioritizeImage;
                student.StudentNote = data.StudentNote;

                db.Students.Add(student);
                db.SaveChanges();

                Parrents parrent = new Parrents();
                parrent.StudentsId = data.Id;
                parrent.Address = data.StudentAddress + " - " + data.StudentAddress3 + " - " + data.StudentAddress2 + " - " + data.StudentAddress1;
                parrent.DadName = data.DadName;
                parrent.DadPhone = data.DadPhone;

                db.Parrents.Add(parrent);
                db.SaveChanges();

                ViewBag.Status = 201;
                return View();
            } catch (Exception e)
            {
                ViewBag.Status = 301;
                return View();
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