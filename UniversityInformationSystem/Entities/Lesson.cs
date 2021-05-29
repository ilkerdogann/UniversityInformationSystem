using System.ComponentModel.DataAnnotations;

namespace UniversityInformationSystem.Entities
{
    public class Lesson
    {
        [Key]
        public int DersID { get; set; }
        public string DersAdi { get; set; }
    }
}