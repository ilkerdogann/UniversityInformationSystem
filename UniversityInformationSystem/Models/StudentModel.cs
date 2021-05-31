using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UniversityInformationSystem.Models
{
    public class StudentModel
    {

        public string Ad { get; set; }
        public string Soyad { get; set; }

        public int Id { get; set; }

        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public SelectList Departments { get; set; }
    }
}