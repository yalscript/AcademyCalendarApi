namespace AcademyCalendarApi.Entities
{
    public class SubjectGroup : BaseEntity 
    {
        public string Name { get; set; }
        public int StudentsNumber { get; set; }
        public int SubjectId { get; set; }
        public Subject Subject { get; set; }
    }
}