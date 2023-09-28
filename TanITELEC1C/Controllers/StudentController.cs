using Microsoft.AspNetCore.Mvc;
using TanITELEC1C.Models;
using TanITELEC1C.Services;

namespace TanITELEC1C.Controllers
{
    public class StudentController : Controller
    {
        private readonly IMyFakeDataService _dummyData;

        public StudentController(IMyFakeDataService dummyData)
        {

            _dummyData = dummyData;

        }

        public IActionResult Index()
        {

            return View(_dummyData.StudentList);
        }

        public IActionResult ShowDetail(int id)
        {
            //Search for the student whose id matches the given id
            Student? student = _dummyData.StudentList.FirstOrDefault(st => st.Id == id);

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

            _dummyData.StudentList.Add(newstudent);
            return RedirectToAction("Index");

        }

        [HttpGet]
        public IActionResult UpdateStudent(int id)
        {

            Student? student = _dummyData.StudentList.FirstOrDefault(st => st.Id == id);

            if (student != null)//was an student found?
                return View(student);

            return NotFound();

        }

        [HttpPost]
        public IActionResult UpdateStudent(Student studentChanges)
        {

            Student? student = _dummyData.StudentList.FirstOrDefault(st => st.Id == studentChanges.Id);

            if (student != null)
            {

                student.FirstName = studentChanges.FirstName;
                student.LastName = studentChanges.LastName;
                student.Course = studentChanges.Course;
                student.Email = studentChanges.Email;
                student.dateEnrolled = studentChanges.dateEnrolled;

            }

            return RedirectToAction("Index");

        }

        [HttpGet]
        public IActionResult DeleteStudent(int id)
        {

            Student? student = _dummyData.StudentList.FirstOrDefault(st => st.Id == id);

            if (student != null)//was an student found?
                return View(student);

            return NotFound();

        }

        [HttpPost]
        public IActionResult DeleteStudent(Student removeStudent)
        {

            Student? student = _dummyData.StudentList.FirstOrDefault(st => st.Id == removeStudent.Id);

            if (student != null)//was an student found?
                _dummyData.StudentList.Remove(student);
            return RedirectToAction("Index");

        }





    }

}