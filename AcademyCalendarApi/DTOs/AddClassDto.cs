using AcademyCalendarApi.Enums;

namespace AcademyCalendarApi.DTOs
{
    public class AddClassDto
    {
        public ClassType Type { get; set; }
        public DateTime StartedAt { get; set; }
        public DateTime EndedAt { get; set; }
        public int TeacherId { get; set; }
        public int ClassroomId { get; set; }
        public int SubjectId { get; set; }
    }
}