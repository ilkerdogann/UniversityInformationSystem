using System.Web.Mvc;

namespace UniversityInformationSystem.Models
{
    public class StudentModel
    {
        public int Id { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public SelectList Departments { get; set; }
    }
}