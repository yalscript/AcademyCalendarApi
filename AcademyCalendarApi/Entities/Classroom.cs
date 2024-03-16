using AcademyCalendarApi.Interfaces;

namespace AcademyCalendarApi.Entities
{
    public class Classroom : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Seats { get; set; }
    }
}