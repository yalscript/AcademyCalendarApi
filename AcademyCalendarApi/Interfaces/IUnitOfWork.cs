namespace AcademyCalendarApi.Interfaces
{
    public interface IUnitOfWork
    {
        IClassroomRepository ClassroomRepository { get; }
        ITeacherRepository TeacherRepository { get; }

        Task<bool> SaveAllAsync();
    }
}