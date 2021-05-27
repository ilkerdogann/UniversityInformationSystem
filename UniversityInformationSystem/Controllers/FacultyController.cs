using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
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
            var context = new Context();
            return View();
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

        public ActionResult Delete()
        {
            var context = new Context();
            return View();
        }
    }
}