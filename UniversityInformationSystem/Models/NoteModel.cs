namespace UniversityInformationSystem.Models
{
    public class NoteModel
    {
        public int OgrenciNo { get; set; }
        public int DersId { get; set; }
        public string Yil { get; set; }
        public int? Vize { get; set; }
        public int? Final { get; set; }
    }
}