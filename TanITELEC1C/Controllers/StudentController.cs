using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TanITELEC1C.Data;
using TanITELEC1C.Models;

namespace TanITELEC1C.Controllers
{
    public class StudentController : Controller
    {
        private readonly AppDbContext _dbData;

        public StudentController(AppDbContext dbData)
        {

            _dbData = dbData;

        }

        [Authorize]
        public IActionResult Index()
        {

            return View(_dbData.Students);
        }

        public IActionResult ShowDetail(int id)
        {
            //Search for the student whose id matches the given id
            Student? student = _dbData.Students.FirstOrDefault(st => st.Id == id);

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
        public IActionResult AddStudent(Student newstudent)
        {

            _dbData.Students.Add(newstudent);
            _dbData.SaveChanges();
            return RedirectToAction("Index");

        }

        [HttpGet]
        public IActionResult UpdateStudent(int id)
        {

            Student? student = _dbData.Students.FirstOrDefault(st => st.Id == id);

            if (student != null)//was an student found?
                return View(student);

            return NotFound();

        }

        [HttpPost]
        public IActionResult UpdateStudent(Student studentChanges)
        {

            Student? student = _dbData.Students.FirstOrDefault(st => st.Id == studentChanges.Id);

            if (student != null)
            {

                student.FirstName = studentChanges.FirstName;
                student.LastName = studentChanges.LastName;
                student.Course = studentChanges.Course;
                student.Email = studentChanges.Email;
                student.dateEnrolled = studentChanges.dateEnrolled;
                _dbData.SaveChanges();

            }

            return RedirectToAction("Index");

        }

        [HttpGet]
        public IActionResult DeleteStudent(int id)
        {

            Student? student = _dbData.Students.FirstOrDefault(st => st.Id == id);

            if (student != null)//was an student found?
                return View(student);

            return NotFound();

        }

        [HttpPost]
        public IActionResult DeleteStudent(Student removeStudent)
        {

            Student? student = _dbData.Students.FirstOrDefault(st => st.Id == removeStudent.Id);

            if (student != null)//was an student found?
                _dbData.Students.Remove(student);
                _dbData.SaveChanges();
            return RedirectToAction("Index");

        }





    }

}