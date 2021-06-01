using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityInformationSystem.Entities;
using UniversityInformationSystem.Models;

namespace UniversityInformationSystem.Controllers
{
    public class DepartmentController : Controller
    {
        public ActionResult Index()
        {
            var context = new Context();
            var departmenties = context.Departments.OrderByDescending(a => a.Faculty.FakulteAd).ToList();
            var model = new List<DepartmentModel>();
            foreach (var item in departmenties)
            {
                var departmentName = item.BolumAd;
                var departmentId = item.BolumID;
                var facultyId= item.Faculty.FakulteID;
                var faculty = context.Faculties.FirstOrDefault(a => a.FakulteID == facultyId);
                model.Add(new DepartmentModel { BolumAd = departmentName, Id = departmentId, FakulteAd = faculty.FakulteAd  });
            }
            return View(model);
        }

        public ActionResult Create()
        {
            var context = new Context();
            var model = new DepartmentModel();
            var faculties = context.Faculties.ToList();
            var kategoriler = new List<SelectListItem>();
            foreach (var item in faculties)
            {   
                kategoriler.Add(new SelectListItem { Text = item.FakulteAd, Value = item.FakulteID.ToString() });
            }
            model.Faculties = new SelectList(kategoriler, "Value", "Text");
            return View(model);
        }
        
        [HttpPost]
        public ActionResult Create(DepartmentModel model)
        {
            var context = new Context();
            var department = new Department();
            department.BolumAd = model.BolumAd;
            department.FakulteID = model.FakulteId;
            context.Departments.Add(department);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            var context = new Context();
            var department = context.Departments.FirstOrDefault(a => a.BolumID == id);
            var model = new DepartmentModel();
            model.BolumAd = department.BolumAd; 
            var faculties = context.Faculties.ToList();
            var kategoriler = new List<SelectListItem>();
            foreach (var item in faculties)
            {
                kategoriler.Add(new SelectListItem { Text = item.FakulteAd, Value = item.FakulteID.ToString() });
            }
            model.Faculties = new SelectList(kategoriler, "Value", "Text");
            model.FakulteId = department.FakulteID;
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(DepartmentModel model)
        {
            var context = new Context();
            var department = context.Departments.FirstOrDefault(a => a.BolumID == model.Id);
            department.BolumAd = model.BolumAd;
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            var context = new Context();
            var department = context.Departments.FirstOrDefault(a => a.BolumID == id);
            context.Departments.Remove(department);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}