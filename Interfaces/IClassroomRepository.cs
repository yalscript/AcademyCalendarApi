using AcademyCalendarApi.Entities;

namespace AcademyCalendarApi.Interfaces
{
    public interface IClassroomRepository
    {
        Task<IEnumerable<Classroom>> GetAllAsync();
        Task<Classroom> GetByIdAsync(int id);
        Task AddAsync(Classroom classroom);
        void Update(Classroom classroom);
        Task DeleteByIdAsync(int id);
        Task<bool> SaveAllAsync();
    }
}