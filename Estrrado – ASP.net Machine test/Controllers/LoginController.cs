using Estrrado___ASP.net_Machine_test.Models;
using Estrrado___ASP.net_Machine_test.Utilities;
using Microsoft.AspNetCore.Mvc;

public class LoginController : Controller
{
    private StudentDbContext db = new StudentDbContext();

    [HttpGet]
    public ActionResult Login()
    {
        return View();
    }

    [HttpPost]
    public ActionResult Login(string username, string password)
    {
        var hashedPassword = PasswordHasher.HashPassword(password);
        var user = db.Students.FirstOrDefault(u => u.Username == username && u.Password == hashedPassword);

        if (user != null)
        {
            return RedirectToAction("Index", "Student");
        }
        else
        {
            ViewBag.Error = "Invalid credentials";
            return View();
        }
    }
}