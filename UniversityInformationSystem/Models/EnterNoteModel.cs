using System.Collections.Generic;
using System.Web.Mvc;

namespace UniversityInformationSystem.Models
{
    public class EnterNoteModel
    {
        public int DersId { get; set; }
        public string Yil { get; set; }
        public string Yariyil { get; set; }
        public int OgrenciNo { get; set; }
        public string OgrenciAdi { get; set; }
        public string OgrenciSoyadi { get; set; }
        public string OgrenciBolumu { get; set; }
    }
}