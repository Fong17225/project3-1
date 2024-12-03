using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Project3.Models;



namespace Proj3.Controllers;

public class AdminController : Controller
{
    // ApplicationDbContext db =new ApplicationDbContext();

    private readonly ILogger<AdminController> _logger;

    public AdminController(ILogger<AdminController> logger)
    {
        _logger = logger;
    }

    public IActionResult Admin()
    {
        // var account = db.Accounts.ToList();

        return View();
    }

    public IActionResult adminstudent()
    {
        // var account = db.Accounts.ToList();
        return View();
    }

    public IActionResult adminedit()
    {
        return View();
    }

    public IActionResult admin_student_course()
    {
        return View();
    }

    public IActionResult admin_student_course_edit()
    {
        return View();
    }

    public IActionResult admin_feedback()
    {
        return View();
    }

    public IActionResult admin_feedback_view()
    {
        return View();
    }

    public IActionResult admin_exam()
    {
        return View();
    }

    public IActionResult admin_exam_student()
    {
        return View();
    }

    public IActionResult admin_exam_edit()
    {
        return View();
    }

    public IActionResult admin_exam_assess()
    {
        return View();
    }

    public IActionResult admin_exam_add()
    {
        return View();
    }

    public IActionResult admin_course()
    {
        return View();
    }

    public IActionResult admin_course_student()
    {
        return View();
    }

    public IActionResult admin_course_edit()
    {
        return View();
    }

    public IActionResult admin_course_add()
    {
        return View();
    }

    public IActionResult admin_class()
    {
        return View();
    }

    public IActionResult admin_class_student_edit()
    {
        return View();
    }

    public IActionResult admin_class_student_add()
    {
        return View();
    }

    public IActionResult admin_class_edit()
    {
        return View();
    }

    public IActionResult admin_class_add()
    {
        return View();
    }

    public IActionResult admin_account()
    {
        return View();
    }

    public IActionResult admin_account_edit()
    {
        return View();
    }

    public IActionResult admin_account_add()
    {
        return View();
    }

    public IActionResult admin_class_student()
    {
        return View();
    }

    public IActionResult admin_student_add()
    {
        return View();
    }

    public IActionResult login()
    {
        return View();
    }


    public IActionResult adminstudentedit()
    {
        return View();
    }

    // [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    // public IActionResult Error()
    // {
    //     return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    // }
}