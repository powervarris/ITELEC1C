using Microsoft.AspNetCore.Mvc;
using TanITELEC1C.Models;
using TanITELEC1C.Services;

namespace TanITELEC1C.Controllers
{
    public class InstructorController : Controller
    {
        private readonly IMyFakeDataService _dummyDatas;

        public InstructorController(IMyFakeDataService dummyDatas)
        {

            _dummyDatas = dummyDatas;

        }


        public IActionResult Index()
        {

            return View(_dummyDatas.InstructorList);
        }

        public IActionResult ShowDetail(int id)
        {
            Instructor? instructor = _dummyDatas.InstructorList.FirstOrDefault(st => st.Id == id);

            if (instructor != null)
                return View(instructor);

            return NotFound();
        }

        [HttpGet]
        public IActionResult AddInstructor()
        {

            return View();

        }

        [HttpPost]
        public IActionResult AddInstructor(Instructor newinstructor)
        {

            _dummyDatas.InstructorList.Add(newinstructor);
            return RedirectToAction("Index");

        }

        [HttpGet]
        public IActionResult UpdateInstructor(int id)
        {

            Instructor? instructor = _dummyDatas.InstructorList.FirstOrDefault(st => st.Id == id);

            if (instructor != null)

                return View(instructor);

            return NotFound();

        }

        [HttpPost]
        public IActionResult UpdateInstructor(Instructor instructorChanges)
        {

            Instructor? instructor = _dummyDatas.InstructorList.FirstOrDefault(st => st.Id == instructorChanges.Id);
            if (instructor != null)
            {

                instructor.FirstName = instructorChanges.FirstName;
                instructor.LastName = instructorChanges.LastName;
                instructor.Rank = instructorChanges.Rank;
                instructor.HiringDate = instructorChanges.HiringDate;
                instructor.IsTenured = instructorChanges.IsTenured;

            }

            return RedirectToAction("Index");

        }

        [HttpGet]
        public IActionResult DeleteInstructor(int id)
        {

            Instructor? instructor = _dummyDatas.InstructorList.FirstOrDefault(st => st.Id == id);

            if (instructor != null)//was an student found?
                return View(instructor);

            return NotFound();

        }

        [HttpPost]
        public IActionResult DeleteInstructor(Student removeInstructor)
        {

            Instructor? instructor = _dummyDatas.InstructorList.FirstOrDefault(st => st.Id == removeInstructor.Id);

            if (instructor != null)//was an student found?
                _dummyDatas.InstructorList.Remove(instructor);
            return RedirectToAction("Index");

        }

    }
}