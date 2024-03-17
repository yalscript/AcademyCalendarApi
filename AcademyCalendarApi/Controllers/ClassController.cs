using AcademyCalendarApi.DTOs;
using AcademyCalendarApi.Interfaces;
using API.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace AcademyCalendarApi.Controllers
{
    public class ClassController : BaseApiController
    {
        private readonly IClassService _classService;

        public ClassController(IClassService classService) {
            _classService = classService;
        }

        [HttpGet]
        public async Task<IEnumerable<BasicClassDto>> GetAll() {
            return await _classService.GetAllAsync();
        }

        [HttpGet("{id}")]
        public async Task<ClassDto> GetById(int id) {
            return await _classService.GetByIdAsync(id);
        }

        [HttpPost]
        public async Task AddAsync(AddClassDto classDto) {
            await _classService.AddAsync(classDto);
        }

        [HttpPut]
        public async Task Update(UpdateClassDto classDto) {
            await _classService.Update(classDto);
        }

        [HttpDelete("{id}")]
        public async Task DeleteByIdAsync(int id) {
            await _classService.DeleteByIdAsync(id);
        }
    }
}