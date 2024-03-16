using AcademyCalendarApi.Enums;

namespace AcademyCalendarApi.Entities
{
    public class Class : BaseEntity
    {
        public ClassType Type { get; set; }
        public DateTime StartedAt { get; set; }
        public DateTime EndedAt { get; set; }
        public int TeacherId { get; set; }
        public int SubjectId { get; set; }
        public int ClassroomId { get; set; }
        public Teacher Teacher { get; set; }
        public Subject Subject { get; set; }
        public Classroom Classroom { get; set; }
    }
}