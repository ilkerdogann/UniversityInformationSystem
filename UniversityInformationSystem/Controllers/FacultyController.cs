using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using UniversityInformationSystem.Entities;
using UniversityInformationSystem.Models;

namespace UniversityInformationSystem.Controllers
{
    public class FacultyController : Controller
    {
        public ActionResult Index()
        {
            var context = new Context();
            var faculties = context.Faculties.ToList();
            var model = new List<FacultyModel>();
            foreach (var item in faculties)
            {
                var facultyName = item.FakulteAd;
                var facultyId = item.FakulteID;
                model.Add(new FacultyModel { FakulteAd = facultyName, Id = facultyId });
            }
            return View(model);
        }
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(FacultyModel model)
        {
            var context = new Context();
            var faculty = new Faculty();
            faculty.FakulteAd = model.FakulteAd;
            context.Faculties.Add(faculty);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            var context = new Context();
            var faculty = context.Faculties.FirstOrDefault(a => a.FakulteID == id);
            var model = new FacultyModel();
            model.Id = faculty.FakulteID;
            model.FakulteAd = faculty.FakulteAd;
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(FacultyModel model)
        {
            var context = new Context();
            var faculty = context.Faculties.FirstOrDefault(a => a.FakulteID == model.Id);
            faculty.FakulteAd = model.FakulteAd;
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            var context = new Context();
            var faculty = context.Faculties.FirstOrDefault(a => a.FakulteID == id);
            context.Faculties.Remove(faculty);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}