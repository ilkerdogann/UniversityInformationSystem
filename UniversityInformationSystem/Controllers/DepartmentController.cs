using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityInformationSystem.Models;

namespace UniversityInformationSystem.Controllers
{
    public class DepartmentController : Controller
    {
        public ActionResult Index()
        {
            var context = new Context();
            var departmenties = context.Departments.ToList();
            var model = new List<DepartmentModel>();
            foreach (var item in departmenties)
            {
                var departmentName = item.BolumAd;
                model.Add(new DepartmentModel { BolumAd = departmentName });
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
            var department = context.Departments.FirstOrDefault(a => a.FakulteID == id);
            var model = new DepartmentModel();
            model.BolumAd = department.BolumAd;
            return View(model);
        }

        public ActionResult Delete()
        {
            var context = new Context();
            return View();
        }
    }
}