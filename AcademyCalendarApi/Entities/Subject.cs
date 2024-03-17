using System.ComponentModel.DataAnnotations.Schema;

namespace AcademyCalendarApi.Entities
{
    public class Subject : BaseEntity
    {
        public string Name { get; set; }
        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; }
        public ICollection<Class> Classes { get; } = new List<Class>();
        public ICollection<SubjectGroup> Groups { get; } = new List<SubjectGroup>();
    }
}