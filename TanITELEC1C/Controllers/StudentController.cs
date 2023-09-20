using Microsoft.AspNetCore.Mvc;
using TanITELEC1C.Models;

namespace TanITELEC1C.Controllers
{
    public class StudentController : Controller
    {
        List<Student> StudentList = new List<Student>
        {
            new Student()
            {
                Id= 1,FirstName = "John Paolo",LastName = "Tan", Course = Course.IT , dateEnrolled = DateTime.Parse("24/07/2021"), Email = "johnpaolo.tan.cics@ust.edu.ph"

            },
            new Student()
            {
                Id= 2,FirstName = "Ryan",LastName = "Dy", Course = Course.CS , dateEnrolled = DateTime.Parse("24/07/2021"), Email = "ryan.dy.cics@ust.edu.ph"
            },
            new Student()
            {
                Id= 3,FirstName = "Herald",LastName = "Oliveros", Course = Course.IS, dateEnrolled = DateTime.Parse("24/07/2021"), Email = "herald.oliveros.cics@ust.edu.ph"
            }
        };
        public IActionResult Index()
        {

            return View(StudentList);
        }

        public IActionResult ShowDetail(int id)
        {
            //Search for the student whose id matches the given id
            Student? student = StudentList.FirstOrDefault(st => st.Id == id);

            if (student != null)//was an student found?
                return View(student);

            return NotFound();
        }

        [HttpGet]
        public IActionResult AddStudent()
        {

            return View();

        }

        [HttpPost]
        public IActionResult AddStudent(Student newstudent) {
        
        StudentList.Add(newstudent);
            return View("Index", StudentList);
        
        }

        [HttpGet]
        public IActionResult UpdateStudent(int id) {

            Student? student = StudentList.FirstOrDefault(st => st.Id == id);

            if (student != null)//was an student found?
                return View(student);

            return NotFound();
        
        }

        [HttpPost]
        public IActionResult UpdateStudent(Student studentChanges) {

            Student? student = StudentList.FirstOrDefault(st => st.Id == studentChanges.Id);

            if (student != null) { 
            
                student.FirstName = studentChanges.FirstName;
                student.LastName = studentChanges.LastName;
                student.Course = studentChanges.Course;
                student.Email = studentChanges.Email;
                student.dateEnrolled = studentChanges.dateEnrolled;
            
            }

            return View("Index", StudentList);

        }

        



    }
    
}
