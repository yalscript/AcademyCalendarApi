using AcademyCalendarApi.DTOs;
using AcademyCalendarApi.Interfaces;
using API.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace AcademyCalendarApi.Controllers
{
    public class ClassroomController : BaseApiController
    {
        private readonly IClassroomService _classroomService;

        public ClassroomController(IClassroomService classroomService) {
            _classroomService = classroomService;
        }

        [HttpGet]
        public async Task<IEnumerable<BasicClassroomDto>> GetAll() {
            return await _classroomService.GetAllAsync();
        }

        [HttpGet("{id}")]
        public async Task<ClassroomDto> GetById(int id) {
            return await _classroomService.GetByIdAsync(id);
        }

        [HttpPost]
        public async Task AddAsync(AddClassroomDto classroomDto) {
            await _classroomService.AddAsync(classroomDto);
        }

        [HttpPut]
        public async Task Update(UpdateClassroomDto classroomDto) {
            await _classroomService.Update(classroomDto);
        }

        [HttpDelete("{id}")]
        public async Task DeleteByIdAsync(int id) {
            await _classroomService.DeleteByIdAsync(id);
        }
    }
}