using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UniversityInformationSystem.Entities
{
    public class Student
    {
        [Key]
        public int OgrenciID { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }

        [ForeignKey("Department")]
        public int BolumID { get; set; }
        public virtual Department Department { get; set; }
    }
}