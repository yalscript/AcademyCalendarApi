namespace AcademyCalendarApi.Interfaces
{
    public interface IUnitOfWork
    {
        IClassroomRepository ClassroomRepository { get; }
        Task<bool> SaveAllAsync();
    }
}