using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityInformationSystem.Entities;
using UniversityInformationSystem.Models;

namespace UniversityInformationSystem.Controllers
{
    public class StudentController : Controller
    {
        public ActionResult Index()
        {
            var context = new Context();
            var students = context.Students.ToList();
            var model = new List<StudentModel>();
            foreach (var item in students)
            {
                var ogrenciAd = item.Ad;
                var ogrenciSoyad = item.Soyad;
                model.Add(new StudentModel { Ad = ogrenciAd, Soyad = ogrenciSoyad });
                
            }
            return View(model);
        }

        public ActionResult Create()
        {
            var context = new Context();
            return View();
        }

        public ActionResult Search()
        {
            return View();
        }

        public ActionResult SearchLessons(int ogrenciNo)
        {
            var context = new Context();
            var student = context.Students.FirstOrDefault(a => a.OgrenciNo == ogrenciNo);
            var lessons = new List<StudentLesson>();
            if (student != null)
            {
                lessons = context.StudentLessons.Where(a => a.OgrenciNo == student.OgrenciNo).ToList();
            }
            var models = new List<LessonModel>();
            foreach (var item in lessons)
            {
                var model = new LessonModel();
                model.DersAdi = item.Lesson.DersAdi;
                models.Add(model);
            }
            return PartialView("_Lessons", models);
        }
    }
}