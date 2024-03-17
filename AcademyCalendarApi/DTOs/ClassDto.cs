using AcademyCalendarApi.Enums;

namespace AcademyCalendarApi.DTOs
{
    public class ClassDto
    {
        public int Id { get; set; }
        public ClassType Type { get; set; }
        public DateTime StartedAt { get; set; }
        public DateTime EndedAt { get; set; }
    }
}