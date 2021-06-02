using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using UniversityInformationSystem.Entities;
using UniversityInformationSystem.Models;

namespace UniversityInformationSystem.Controllers
{
    public class StudentLessonController : Controller
    {
        public ActionResult Index()
        {
            var kategoriler = new List<SelectListItem>();
            for (int i = 2000; i <= DateTime.Now.Year; i++)
            {
                kategoriler.Add(new SelectListItem { Text = $"{i}-{i + 1}", Value = $"{i}-{i + 1}" });
            }
            ViewBag.Years = new SelectList(kategoriler, "Value", "Text");
            return View();
        }

        public ActionResult GetLesson(string year, string semester, int ogrenciNo)
        {
            var context = new Context();
            var student = context.Students.FirstOrDefault(a => a.OgrenciNo == ogrenciNo);
            var model = new StudentLessonModel();
            model.Id = student.OgrenciNo;
            model.OgrenciAd = student.Ad;
            model.OgrenciSoyad = student.Soyad;
            model.OgrenciBolum = student.Department.BolumAd;
            model.Yil = year;
            model.Yariyil = semester;
            var studentLesson = context.StudentLessons
                .Where(s => s.OgrenciNo == ogrenciNo && s.Yariyil == semester && s.Yil == year).ToList();
            foreach (var item in studentLesson)
            {
                var lessonModel = new LessonModel();
                lessonModel.DersAdi = item.Lesson.DersAdi;
                lessonModel.Id = item.DersID;
                model.Lessons.Add(lessonModel);
            }
            return PartialView("_Lessons", model);
        }

        public ActionResult Note()
        {
            var context = new Context();
            var lessons = context.Lessons.ToList();
            var kategoriler = new List<SelectListItem>();
            foreach (var item in lessons)
            {
                kategoriler.Add(new SelectListItem { Text = item.DersAdi, Value = item.DersID.ToString() });
            }
            ViewBag.Lessons = new SelectList(kategoriler, "Value", "Text");
            return View();
        }

        public ActionResult GetStudents(int dersId)
        {
            var context = new Context();
            var students = context.StudentLessons.Where(s => s.DersID == dersId).ToList();
            var models = new List<EnterNoteModel>();
            foreach (var item in students)
            {
                var model = new EnterNoteModel();
                model.OgrenciAdi = item.Student.Ad;
                model.OgrenciSoyadi = item.Student.Soyad;
                model.OgrenciBolumu = item.Student.Department.BolumAd;
                model.OgrenciNo = item.OgrenciNo;
                model.Yariyil = item.Yariyil;
                model.Yil = item.Yil;
                model.DersId = item.DersID;
                models.Add(model);
            }
            return PartialView("_Students", models);
        }

        public ActionResult EnterNote(int ogrNo, int dersId, string year)
        {
            var context = new Context();
            var not = context.StudentLessons.FirstOrDefault(n => n.OgrenciNo == ogrNo && n.Yil == year && n.DersID == dersId);
            var model = new NoteModel();
            model.Vize = not.Vize;
            model.Final = not.Final;
            model.OgrenciNo = ogrNo;
            model.DersId = dersId;
            model.Yil = year;
            return View(model);
        }

        [HttpPost]
        public ActionResult EnterNote(NoteModel model)
        {
            var context = new Context();
            var not = context.StudentLessons.FirstOrDefault(n => n.OgrenciNo == model.OgrenciNo && n.Yil == model.Yil && n.DersID == model.DersId);
            not.Vize = model.Vize;
            not.Final = model.Final;
            context.SaveChanges();
            return RedirectToAction("Note");
        }

        public ActionResult AddLesson()
        {
            var context = new Context();
            var kategoriler = new List<SelectListItem>();
            for (int i = 2000; i <= DateTime.Now.Year; i++)
            {
                kategoriler.Add(new SelectListItem { Text = $"{i}-{i + 1}", Value = $"{i}-{i + 1}" });
            }
            ViewBag.Year = new SelectList(kategoriler, "Value", "Text");
            var lessons = context.Lessons.ToList();
            var kategoriler1 = new List<SelectListItem>();
            foreach (var item in lessons)
            {
                kategoriler1.Add(new SelectListItem { Text = item.DersAdi, Value = item.DersID.ToString() });
            }
            ViewBag.Lessons = new SelectList(kategoriler1, "Value", "Text");
            return View();
        }

        [HttpPost]
        public ActionResult AddLesson(int ogrNo, int dersId, string year, string semester)
        {
            var context = new Context();
            var entity = new StudentLesson();
            entity.OgrenciNo = ogrNo;
            entity.DersID = dersId;
            entity.Yil = year;
            entity.Yariyil = semester;
            context.StudentLessons.Add(entity);
            context.SaveChanges();
            var kategoriler = new List<SelectListItem>();
            for (int i = 2000; i <= DateTime.Now.Year; i++)
            {
                kategoriler.Add(new SelectListItem { Text = $"{i}-{i + 1}", Value = $"{i}-{i + 1}" });
            }
            ViewBag.Year = new SelectList(kategoriler, "Value", "Text");
            var lessons = context.Lessons.ToList();
            var kategoriler1 = new List<SelectListItem>();
            foreach (var item in lessons)
            {
                kategoriler1.Add(new SelectListItem { Text = item.DersAdi, Value = item.DersID.ToString() });
            }
            ViewBag.Lessons = new SelectList(kategoriler1, "Value", "Text");
            return View();
        }

        public ActionResult Delete(int dersId, int ogrNo, string year)
        {
            var context = new Context();
            var studentLesson = context.StudentLessons.FirstOrDefault(a => a.DersID == dersId && a.Yil == year && a.OgrenciNo == ogrNo);
            context.StudentLessons.Remove(studentLesson);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}