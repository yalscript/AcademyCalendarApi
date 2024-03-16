using AcademyCalendarApi.Interfaces;

namespace AcademyCalendarApi.Entities
{
    public class Teacher : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}