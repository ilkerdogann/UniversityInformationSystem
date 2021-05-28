using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityInformationSystem.Models;

namespace UniversityInformationSystem.Controllers
{
    public class LessonController : Controller
    {
        // GET: Lesson
        public ActionResult Index()
        {
            var context = new Context();
            var lessons = context.Lessons.ToList();
            var model = new List<LessonModel>();
            foreach (var item in lessons)
            {
                var lessonId = item.DersID;
                //model.Add(new LessonModel { Id = lessonId});
            }
            return View(model);
        }
        public ActionResult Create()
        {
            var context = new Context();
            return View();
        }

        public ActionResult Edit(int id)
        {
            var context = new Context();
            var lesson = context.Lessons.FirstOrDefault(a => a.DersID == id);
            var model = new LessonModel();
            //model.= lesson.DersID;
            return View(model);
        }

        public ActionResult Delete()
        {
            var context = new Context();
            return View();
        }
    }
}