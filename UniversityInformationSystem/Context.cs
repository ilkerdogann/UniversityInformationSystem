using System.Data.Entity;
using UniversityInformationSystem.Entities;

namespace UniversityInformationSystem
{
    public class Context : DbContext
    {
        public DbSet<Department> Departments { get; set; }
        public DbSet<Faculty> Faculties { get; set; }
        public DbSet<StudentLesson> StudentLessons { get; set; }
        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<Student> Students { get; set; }
    }
}