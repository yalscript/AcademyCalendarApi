using AcademyCalendarApi.DTOs;

namespace AcademyCalendarApi.Interfaces
{
    public interface ITeacherService
    {
        Task<IEnumerable<BasicTeacherDto>> GetAllAsync();
        Task<TeacherDto> GetByIdAsync(int id);
        Task AddAsync(AddTeacherDto teacherDto);
        Task Update(UpdateTeacherDto teacherDto);
        Task DeleteByIdAsync(int id);
    }
}