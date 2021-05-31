using System.Collections.Generic;
using System.Linq;
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
                var ogrenciNo = item.OgrenciNo;
                var departmentName = item.Department.BolumAd;
                model.Add(new StudentModel { Ad = ogrenciAd, Soyad = ogrenciSoyad, Id = ogrenciNo, DepartmentName = departmentName });
            }
            return View(model);
        }

        public ActionResult Create()
        {
            var context = new Context();
            var model = new StudentModel();
            var departments = context.Departments.ToList();
            var kategoriler = new List<SelectListItem>();
            foreach (var item in departments)
            {
                kategoriler.Add(new SelectListItem { Text = item.BolumAd, Value = item.BolumID.ToString() });
            }
            model.Departments = new SelectList(kategoriler, "Value", "Text");
            return View(model);
        }

        [HttpPost]
        public ActionResult Create(StudentModel model)
        {
            var context = new Context();
            var student = new Student();
            student.Ad = model.Ad;
            student.Soyad = model.Soyad;
            student.OgrenciNo = model.Id;
            student.BolumID = model.DepartmentId;
            context.Students.Add(student);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            var context = new Context();
            var student = context.Students.FirstOrDefault(a => a.OgrenciNo == id);
            var model = new StudentModel();
            model.Ad = student.Ad;
            model.Soyad = student.Soyad;
            model.DepartmentId = student.BolumID;
            var departments = context.Departments.ToList();
            var kategoriler = new List<SelectListItem>();
            foreach (var item in departments)
            {
                kategoriler.Add(new SelectListItem { Text = item.BolumAd, Value = item.BolumID.ToString() });
            }
            model.Departments = new SelectList(kategoriler, "Value", "Text");
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(StudentModel model)
        {
            var context = new Context();
            var student = context.Students.FirstOrDefault(a => a.OgrenciNo == model.Id);
            student.Ad = model.Ad;
            student.Soyad = model.Soyad;
            student.BolumID = model.DepartmentId;
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            var context = new Context();
            var student = context.Students.FirstOrDefault(a => a.OgrenciNo == id);
            context.Students.Remove(student);
            context.SaveChanges();
            return RedirectToAction("Index");
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