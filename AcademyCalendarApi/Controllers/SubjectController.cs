using AcademyCalendarApi.DTOs;
using AcademyCalendarApi.Interfaces;
using API.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace AcademyCalendarApi.Controllers
{
    public class SubjectController : BaseApiController
    {
        private readonly ISubjectService _subjectService;

        public SubjectController(ISubjectService subjectService) {
            _subjectService = subjectService;
        }

        [HttpGet]
        public async Task<IEnumerable<BasicSubjectDto>> GetAll() {
            return await _subjectService.GetAllAsync();
        }

        [HttpGet("{id}")]
        public async Task<SubjectDto> GetById(int id) {
            return await _subjectService.GetByIdAsync(id);
        }

        [HttpPost]
        public async Task AddAsync(AddSubjectDto subjectDto) {
            await _subjectService.AddAsync(subjectDto);
        }

        [HttpPut]
        public async Task Update(UpdateSubjectDto subjectDto) {
            await _subjectService.Update(subjectDto);
        }

        [HttpDelete("{id}")]
        public async Task DeleteByIdAsync(int id) {
            await _subjectService.DeleteByIdAsync(id);
        }
    }
}