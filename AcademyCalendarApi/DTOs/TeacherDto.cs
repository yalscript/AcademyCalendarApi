namespace AcademyCalendarApi.DTOs
{
    public class TeacherDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<SubjectDto> Subjects { get; set; }
    }
}