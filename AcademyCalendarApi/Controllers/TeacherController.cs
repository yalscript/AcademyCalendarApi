using AcademyCalendarApi.DTOs;
using AcademyCalendarApi.Interfaces;
using API.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace AcademyCalendarApi.Controllers
{
    public class TeacherController : BaseApiController
    {
        private readonly ITeacherService _teacherService;

        public TeacherController(ITeacherService teacherService) {
            _teacherService = teacherService;
        }

        [HttpGet]
        public async Task<IEnumerable<BasicTeacherDto>> GetAll() {
            return await _teacherService.GetAllAsync();
        }

        [HttpGet("{id}")]
        public async Task<TeacherDto> GetById(int id) {
            return await _teacherService.GetByIdAsync(id);
        }

        [HttpPost]
        public async Task AddAsync(AddTeacherDto teacherDto) {
            await _teacherService.AddAsync(teacherDto);
        }

        [HttpPut]
        public async Task Update(UpdateTeacherDto teacherDto) {
            await _teacherService.Update(teacherDto);
        }

        [HttpDelete("{id}")]
        public async Task DeleteByIdAsync(int id) {
            await _teacherService.DeleteByIdAsync(id);
        }
    }
}