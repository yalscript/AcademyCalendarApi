namespace AcademyCalendarApi.Entities
{
    public class Classroom : BaseEntity
    {
        public string Name { get; set; }
        public int SeatsNumber { get; set; }
        public ICollection<Class> Classes { get; } = new List<Class>();
    }
}