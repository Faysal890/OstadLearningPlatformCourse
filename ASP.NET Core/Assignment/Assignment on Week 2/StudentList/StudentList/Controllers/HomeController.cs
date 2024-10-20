using Microsoft.AspNetCore.Mvc;
using StudentList.Models;
using System.Diagnostics;

namespace StudentList.Controllers
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
            List<Student> StudentList = new List<Student>()
            {
                new Student() {Id = 1, Name = "Faysal", CourseId = 101},
                new Student() {Id = 2, Name = "Rakib", CourseId = 101},
                new Student() {Id = 3, Name = "Rahat Alam", CourseId = 102},
                new Student() {Id = 4, Name = "Shahin Khan", CourseId = 103}
            };

            List<Course> CourseList = new List<Course>()
            {
                new Course() {Id = 101, CourseName = "ASP.NET Core Career Track"},
                new Course() {Id = 102, CourseName = "App Development with Flutter"},
                new Course() {Id = 103, CourseName = "Full Stack Web Development with Python, Django & React"}
            };

            List<Teacher> Teachers = new List<Teacher>()
            {
                new Teacher() {Id = 1, Name = "Md. Nafiur Rahman Protik", CourseId = 101},
                new Teacher() {Id = 2, Name = "Rabbil Hasan", CourseId = 102},
                new Teacher() {Id = 3, Name = "Tamim Shahriar Subeen", CourseId = 103}
            };
            List<StudentInfo> ListOfStudent = new List<StudentInfo>();
            foreach(var std in StudentList)
            {
                StudentInfo stdInfo = new StudentInfo();
                stdInfo.Id = std.Id;
                stdInfo.Name = std.Name;
                string course = " ";
                foreach(var cur in CourseList)
                {
                    if(cur.Id == std.CourseId)
                    {
                        course = cur.CourseName;
                        break;
                    }
                }
                stdInfo.CourseName = course;
                string teacher = " ";
                foreach(var cur in Teachers)
                {
                    if(cur.CourseId == std.CourseId)
                    {
                        teacher = cur.Name;
                    }
                }
                stdInfo.TeacherName = teacher;
                ListOfStudent.Add(stdInfo);
            }
            return View(ListOfStudent);
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
