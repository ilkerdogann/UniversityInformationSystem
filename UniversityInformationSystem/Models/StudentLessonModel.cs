using System.Collections.Generic;

namespace UniversityInformationSystem.Models
{
    public class StudentLessonModel
    {
        public StudentLessonModel()
        {
            Lessons = new List<LessonModel>();
        }

        public int Id { get; set; }
        public string OgrenciAd{ get; set; }
        public string OgrenciSoyad { get; set; }
        public string OgrenciBolum{ get; set; }
        public string Yil { get; set; }
        public string Yariyil { get; set; }
        public List<LessonModel> Lessons { get; set; }
    }
}