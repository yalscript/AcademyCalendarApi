using AcademyCalendarApi.Enums;

namespace AcademyCalendarApi.DTOs
{
    public class BasicClassDto
    {
        public int Id { get; set; }
        public ClassType Type { get; set; }
        public DateTime StartedAt { get; set; }
        public DateTime EndedAt { get; set; }
        public BasicTeacherDto Teacher { get; set; }
        public BasicSubjectDto Subject { get; set; }
        public BasicClassroomDto Classroom { get; set; }
    }
}