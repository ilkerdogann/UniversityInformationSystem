using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UniversityInformationSystem.Entities
{
    public class Lesson
    {
        [Key]
        public int DersID { get; set; }

        [ForeignKey("Student")]
        public int OgrenciID { get; set; }
        public int Yil { get; set; }
        public int Yariyil { get; set; }
        public int Vize { get; set; }
        public int Final { get; set; }
        public virtual Student Student { get; set; }
    }
}