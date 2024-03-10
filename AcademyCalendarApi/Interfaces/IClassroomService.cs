using AcademyCalendarApi.DTOs;

namespace AcademyCalendarApi.Interfaces
{
    public interface IClassroomService
    {
        Task<IEnumerable<BasicClassroomDto>> GetAllAsync();
        Task<ClassroomDto> GetByIdAsync(int id);
        Task AddAsync(AddClassroomDto classroomDto);
        Task Update(UpdateClassroomDto classroomDto);
        Task DeleteByIdAsync(int id);
    }
}