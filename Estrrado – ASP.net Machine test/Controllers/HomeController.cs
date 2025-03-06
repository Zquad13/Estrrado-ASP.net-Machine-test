using System.Diagnostics;
using Estrrado___ASP.net_Machine_test.Models;
using Microsoft.AspNetCore.Mvc;

namespace Estrrado___ASP.net_Machine_test.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
      
        [HttpGet]
        public ActionResult Registration()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Registration(Student student)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    using (var db = new StudentDbContext())
                    {
                        // Add the student and qualifications to the database
                        db.Students.Add(student);
                        db.SaveChanges();
                    }

                    return RedirectToAction("Details", new { id = student.StudentId });
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "An error occurred while saving the student: " + ex.Message);
                }
            }

            // If ModelState is invalid, return the same view with the model
            return View(student);
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string email, string password)
        {
            using (var db = new StudentDbContext())
            {
                var user = db.Students.FirstOrDefault(s => s.Email == email && s.Password == password);

                if (user != null)
                {
                    // Store user info in session
                    HttpContext.Session.SetString("UserEmail", user.Email);
                    HttpContext.Session.SetString("UserName", user.FirstName);

                    return RedirectToAction("Dashboard"); // Redirect to a dashboard after login
                }
                else
                {
                    ViewBag.ErrorMessage = "Invalid email or password.";
                    return View();
                }
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
