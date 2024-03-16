namespace AcademyCalendarApi.Entities
{
    public class Teacher : BaseEntity
    {
        public string Name { get; set; }
        public ICollection<Subject> Subjects { get; } = new List<Subject>();
        public ICollection<Class> Classes { get; } = new List<Class>();
    }
}