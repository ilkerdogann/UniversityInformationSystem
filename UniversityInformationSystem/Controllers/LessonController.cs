using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityInformationSystem.Entities;
using UniversityInformationSystem.Models;

namespace UniversityInformationSystem.Controllers
{
    public class LessonController : Controller
    {
       
        public ActionResult Index()
        {
            var context = new Context();
            var lessons = context.Lessons.ToList();
            var model = new List<LessonModel>();
            foreach (var item in lessons)
            {
                var lessonName = item.DersAdi;
                var lessonId = item.DersID;
                model.Add(new LessonModel { DersAdi = lessonName, Id = lessonId });
            }
            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(LessonModel model)
        {
            var context = new Context();
            var lesson = new Lesson();
            lesson.DersAdi = model.DersAdi;
            context.Lessons.Add(lesson);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            var context = new Context();
            var lesson = context.Lessons.FirstOrDefault(a => a.DersID == id);
            var model = new LessonModel();
            model.DersAdi = lesson.DersAdi;
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(LessonModel model)
        {
            var context = new Context();
            var lesson = context.Lessons.FirstOrDefault(a => a.DersID == model.Id);
            lesson.DersAdi = model.DersAdi;
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            var context = new Context();
            var lesson = context.Lessons.FirstOrDefault(a => a.DersID == id);
            context.Lessons.Remove(lesson);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}