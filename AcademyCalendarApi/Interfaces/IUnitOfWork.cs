namespace AcademyCalendarApi.Interfaces
{
    public interface IUnitOfWork
    {
        IClassroomRepository ClassroomRepository { get; }
        ITeacherRepository TeacherRepository { get; }
        ISubjectRepository SubjectRepository { get; }
        IClassRepository ClassRepository { get; }

        Task<bool> SaveAllAsync();
    }
}