using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UniversityInformationSystem.Entities
{
    public class Department
    {
        [Key]
        public int BolumID { get; set; }
        public string BolumAd { get; set; }

        [ForeignKey("Faculty")]
        public int FakulteID { get; set; }
        public virtual Faculty Faculty { get; set; }
    }
}