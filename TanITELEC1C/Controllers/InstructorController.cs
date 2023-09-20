using Microsoft.AspNetCore.Mvc;
using TanITELEC1C.Models;

namespace TanITELEC1C.Controllers
{
    public class InstructorController : Controller
    {
        List<Instructor> InstructorList = new List<Instructor>
        {
            new Instructor()
            {
                Id= 1,FirstName = "Gabriel", LastName = "Montano", Rank = Rank.Professor, HiringDate = DateTime.Parse("24/01/2020"), IsTenured = true
            },
            new Instructor()
            {
                Id= 2,FirstName = "Beatriz", LastName = "Lacsamana", Rank = Rank.AssistantProfessor, HiringDate = DateTime.Parse("17/04/2017"), IsTenured = false
            },
            new Instructor()
            {
                Id= 3,FirstName = "Ronina", LastName = "Tayuan", Rank = Rank.AssociateProfessor, HiringDate = DateTime.Parse("12/07/2019"), IsTenured = false
            }
        };
        public IActionResult Index()
        {

            return View(InstructorList);
        }

        public IActionResult ShowDetail(int id)
        {
            Instructor? instructor = InstructorList.FirstOrDefault(st => st.Id == id);

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

            InstructorList.Add(newinstructor);
            return View("Index", InstructorList);

        }

        [HttpGet]
        public IActionResult UpdateInstructor(int id)
        {

            Instructor? instructor = InstructorList.FirstOrDefault(st => st.Id == id);

            if (instructor != null)

                return View(instructor);

            return NotFound();

        }

        [HttpPost]
        public IActionResult UpdateInstructor(Instructor instructorChanges)
        {

            Instructor? instructor = InstructorList.FirstOrDefault(st => st.Id == instructorChanges.Id);
            if (instructor != null)
            {

                instructor.FirstName = instructorChanges.FirstName;
                instructor.LastName = instructorChanges.LastName;
                instructor.Rank = instructorChanges.Rank;
                instructor.HiringDate = instructorChanges.HiringDate;
                instructor.IsTenured = instructorChanges.IsTenured;

            }

            return View("Index", InstructorList);

        }

    }
}
