using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.DotNet.Scaffolding.Shared.CodeModifier.CodeChange;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Project3.Models; // Thay đổi namespace cho phù hợp với dự án của bạn
using RestSharp;
using System;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;


namespace Proj3.Controllers
{
    public class AdminController : Controller
    {
        
        private readonly ApplicationDbContext _context;
        
        public AdminController(ApplicationDbContext context, ILogger<AdminController> logger)
        {
            _context = context; // Khởi tạo DbContext
            
        }

        // Hành động để hiển thị danh sách tài khoản
        public ActionResult admin_account()
        {
            List<Account> accounts = _context.Accounts.ToList(); // Lấy danh sách tài khoản
            return View(accounts); // Truyền danh sách vào view
        }

        // Hành động để xóa tài khoản
        [HttpPost] // Chỉ định rằng đây là phương thức POST
        public ActionResult admin_account_delete(int id)
        {
            var account = _context.Accounts.Find(id); // Tìm tài khoản theo ID
            if (account != null)
            {
                _context.Accounts.Remove(account); // Xóa tài khoản khỏi DbContext
                _context.SaveChanges(); // Lưu thay đổi vào cơ sở dữ liệu
            }
            return RedirectToAction("admin_account"); // Chuyển hướng về trang danh sách tài khoản
        }

        // Hành động để hiển thị form thêm tài khoản
        public ActionResult admin_account_add()
        {
            return View();
        }

        // Hành động để xử lý thêm tài khoản
        [HttpPost]
        public ActionResult admin_account_add(Account account)
        {
            
                account.CreatedAt = DateTime.UtcNow; // Đặt thời gian tạo
                _context.Accounts.Add(account); // Thêm tài khoản vào DbContext
                _context.SaveChanges(); // Lưu thay đổi vào cơ sở dữ liệu
                return RedirectToAction("admin_account"); // Chuyển hướng về trang danh sách tài khoản
            
           
        }

        [HttpGet]
        public ActionResult admin_account_edit(int id)
        {
            var existingAccount = _context.Accounts.Find(id);
            if (existingAccount == null)
            {
                return NotFound();
            }
            return View(existingAccount);
        }



        // Phương thức POST: Cập nhật tài khoản
        [HttpPost]
        public ActionResult admin_account_edit(Account accounts)
        {
            var existingAccount = _context.Accounts.Find(accounts.AccountId);
            if (existingAccount == null)
            {
                return NotFound();
            }

            existingAccount.Username = accounts.Username;
            existingAccount.FullName = accounts.FullName;
            existingAccount.Email = accounts.Email;
            existingAccount.Password = accounts.Password;

            _context.SaveChanges();
            return RedirectToAction("admin_account");
        }

        public ActionResult admin_course()
        {
            List<Course> courses = _context.Courses.ToList(); // Lấy danh sách tài khoản
            return View(courses); // Truyền danh sách vào view
        }

       

        // Hành động để hiển thị form thêm khóa học
        public ActionResult admin_course_add()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> admin_course_add(Course course)
        {
            

            course.CreatedAt = DateTime.UtcNow; // Đặt thời gian tạo
            _context.Courses.Add(course); // Thêm khóa học vào DbContext
            _context.SaveChanges(); // Lưu thay đổi vào cơ sở dữ liệu
            return RedirectToAction("admin_course"); // Chuyển hướng về trang danh sách khóa học
        }

        



        [HttpGet]
        public ActionResult admin_course_edit(int id)
        {
            var existingCourse = _context.Courses.Find(id);
            if (existingCourse == null)
            {
                return NotFound();
            }
            return View(existingCourse);
        }



        // Phương thức POST: Cập nhật tài khoản
        [HttpPost]
        public ActionResult admin_course_edit(Course courses)
        {
            var existingCourse = _context.Courses.Find(courses.CourseId);
            if (existingCourse == null)
            {
                return NotFound();
            }

            existingCourse.Name = courses.Name;
            existingCourse.Description = courses.Description;
            existingCourse.Price = courses.Price;
            existingCourse.ImageUrl = courses.ImageUrl;
            existingCourse.CategoryId = courses.CategoryId;

            _context.SaveChanges();
            return RedirectToAction("admin_course");
        }

        // Hành động để xóa tài khoản
        [HttpPost]
        public ActionResult admin_course_delete(int id)
        {
            var course = _context.Courses.Find(id); // Tìm khóa học theo ID
            if (course != null)
            {
                _context.Courses.Remove(course); // Xóa khóa học khỏi DbContext
                _context.SaveChanges(); // Lưu thay đổi vào cơ sở dữ liệu
            }
            return RedirectToAction("admin_course"); // Chuyển hướng về trang danh sách khóa học
        }

        public ActionResult admin_course_view()
        {
            List<Course> courses = _context.Courses.ToList(); // Lấy danh sách tài khoản
            return View(courses); // Truyền danh sách vào view
        }

        

        // Hành động để hiển thị danh sách lớp học
        public async Task<ActionResult> admin_class()
        {
            // Lấy danh sách lớp học cùng với thông tin khóa học và giảng viên
            var classes = await _context.Classes
                .Include(c => c.Course)        // Kết nối với bảng Course
                .Include(c => c.Instructor)    // Kết nối với bảng Instructor
                .ToListAsync();                 // Thực hiện truy vấn và lấy kết quả

            return View(classes); // Truyền danh sách vào view
        }


        public ActionResult adminstudent()
        {
            return View();
        }

        public ActionResult admin()
        {
            return View();
        }
    }
    
}
