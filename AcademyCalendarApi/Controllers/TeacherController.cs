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
        public async Task<ActionResult<IEnumerable<BasicTeacherDto>>> GetAll() {
            var teachers = await _teacherService.GetAllAsync();
            return Ok(teachers);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TeacherDto>> GetById(int id) {
            var teacher = await _teacherService.GetByIdAsync(id);

            if (teacher == null) {
                return NotFound();
            }
            
            return Ok(teacher);
        }

        [HttpPost]
        public async Task<ActionResult<BasicTeacherDto>> AddAsync(AddTeacherDto teacherDto) {
            var teacher = await _teacherService.AddAsync(teacherDto);
            return CreatedAtAction(nameof(GetById), teacher);
        }

        [HttpPut]
        public async Task<ActionResult> Update(UpdateTeacherDto teacherDto) {
            await _teacherService.Update(teacherDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteByIdAsync(int id) {
            await _teacherService.DeleteByIdAsync(id);
            return NoContent();
        }
    }
}