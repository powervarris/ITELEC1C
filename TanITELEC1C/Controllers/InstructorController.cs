﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TanITELEC1C.Data;
using TanITELEC1C.Models;

namespace TanITELEC1C.Controllers
{
    public class InstructorController : Controller
    {
        private readonly AppDbContext _dbDatas;
        private readonly IWebHostEnvironment _environment;

        public InstructorController(AppDbContext dbDatas, IWebHostEnvironment environment)
        {

            _dbDatas = dbDatas;
            _environment = environment;
        }

        [Authorize]
        public IActionResult Index()
        {

            return View(_dbDatas.Instructors);
        }

        public IActionResult ShowDetail(int id)
        {
            Instructor? instructor = _dbDatas.Instructors.FirstOrDefault(st => st.Id == id);

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

            string folder = "instructors/images/";
            string serverFolder = Path.Combine(_environment.WebRootPath, folder);
            string uniqueFileName = Guid.NewGuid().ToString() + "_" + newinstructor.UploadPhoto.FileName;
            string filePath = Path.Combine(serverFolder, uniqueFileName);
            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                newinstructor.UploadPhoto.CopyTo(fileStream);
            }
            newinstructor.imagePath = folder + uniqueFileName;

            if (!ModelState.IsValid)
            {
                return View(newinstructor);
                /**return View();
                _dbDatas.Instructors.Add(newinstructor);
                return RedirectToAction("Index");**/

            }

            _dbDatas.Instructors.Add(newinstructor);
            _dbDatas.SaveChanges();
            return RedirectToAction("Index");

        }

        [HttpGet]
        public IActionResult UpdateInstructor(int id)
        {

            Instructor? instructor = _dbDatas.Instructors.FirstOrDefault(st => st.Id == id);

            if (instructor != null)

                return View(instructor);

            return NotFound();

        }

        [HttpPost]
        public IActionResult UpdateInstructor(Instructor instructorChanges)
        {

            Instructor? instructor = _dbDatas.Instructors.FirstOrDefault(st => st.Id == instructorChanges.Id);
            if (instructor != null)
            {

                instructor.FirstName = instructorChanges.FirstName;
                instructor.LastName = instructorChanges.LastName;
                instructor.Rank = instructorChanges.Rank;
                instructor.HiringDate = instructorChanges.HiringDate;
                instructor.IsTenured = instructorChanges.IsTenured;
                _dbDatas.SaveChanges();

            }

            return RedirectToAction("Index");

        }

        [HttpGet]
        public IActionResult DeleteInstructor(int id)
        {

            Instructor? instructor = _dbDatas.Instructors.FirstOrDefault(st => st.Id == id);

            if (instructor != null)//was an student found?
                return View(instructor);

            return NotFound();

        }

        [HttpPost]
        public IActionResult DeleteInstructor(Student removeInstructor)
        {

            Instructor? instructor = _dbDatas.Instructors.FirstOrDefault(st => st.Id == removeInstructor.Id);

            if (instructor != null)//was an student found?
                _dbDatas.Instructors.Remove(instructor);
                _dbDatas.SaveChanges();
            return RedirectToAction("Index");

        }

    }
}