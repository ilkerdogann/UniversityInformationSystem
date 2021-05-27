using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
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
    }
}