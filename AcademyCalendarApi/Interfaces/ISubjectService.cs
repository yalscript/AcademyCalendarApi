using AcademyCalendarApi.DTOs;

namespace AcademyCalendarApi.Interfaces
{
    public interface ISubjectService
    {
        Task<IEnumerable<BasicSubjectDto>> GetAllAsync();
        Task<SubjectDto> GetByIdAsync(int id);
        Task AddAsync(AddSubjectDto subjectDto);
        Task Update(UpdateSubjectDto subjectDto);
        Task DeleteByIdAsync(int id);
    }
}