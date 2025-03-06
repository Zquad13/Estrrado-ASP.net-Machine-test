using Estrrado___ASP.net_Machine_test.Models;
using Estrrado___ASP.net_Machine_test.Utilities;
using Microsoft.AspNetCore.Mvc;

public class StudentController : Controller
{
    private StudentDbContext db = new StudentDbContext();

    [HttpGet]
    public ActionResult Registration()
    {
        return View();
    }

    [HttpPost]
    public ActionResult Registration(Student student)
    {
        if (!ModelState.IsValid)
        {
            // Hash password
            student.Password = PasswordHasher.HashPassword(student.Password);

            db.Students.Add(student);
            db.SaveChanges();
            return RedirectToAction("Details", new { id = student.StudentId });
        }
        return View(student);
    }

    public ActionResult Details(int id)
    {
        // Use string-based Include to load related Qualifications
        var student = db.Students
                        .Include("Qualifications") // Use string for navigation property
                        .SingleOrDefault(s => s.StudentId == id);

        if (student == null)
        {
            return HttpNotFound();
        }
        return View(student);
    }
    private ActionResult HttpNotFound()
    {
        throw new NotImplementedException();
    }
}