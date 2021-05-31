using System.Web.Mvc;

namespace UniversityInformationSystem.Models
{
    public class DepartmentModel
    {
        public string BolumAd { get; set; }
        public int Id { get; set; }

        public string FakulteAd { get; set; }
        public int FakulteId { get; set; }
        public SelectList Faculties { get; set; }
    }
}