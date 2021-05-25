using System.ComponentModel.DataAnnotations;

namespace UniversityInformationSystem.Entities
{
    public class Faculty
    {
        [Key]
        public int FakulteID { get; set; }
        public string FakulteAd { get; set; }
    }
}