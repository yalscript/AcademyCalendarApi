using AcademyCalendarApi.DTOs;

namespace AcademyCalendarApi.Interfaces
{
    public interface IClassService
    {
        Task<IEnumerable<BasicClassDto>> GetAllAsync();
        Task<ClassDto> GetByIdAsync(int id);
        Task AddAsync(AddClassDto classDto);
        Task Update(UpdateClassDto classDto);
        Task DeleteByIdAsync(int id);
    }
}