using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UniversityInformationSystem.Entities
{
    public class StudentLesson
    {
        [Key]
        [Column(Order = 1)]
        [ForeignKey("Lesson")]
        public int DersID { get; set; }

        [Key]
        [Column(Order = 2)]
        [ForeignKey("Student")]
        public int OgrenciNo { get; set; }

        [Key]
        [Column(Order = 3)]
        public int Yil { get; set; }
        public string Yariyil { get; set; }
        public int Vize { get; set; }
        public int Final { get; set; }
        public virtual Student Student { get; set; }
        public virtual Lesson Lesson { get; set; }
    }
}