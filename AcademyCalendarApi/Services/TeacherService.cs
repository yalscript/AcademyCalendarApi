using AcademyCalendarApi.DTOs;
using AcademyCalendarApi.Entities;
using AcademyCalendarApi.Interfaces;
using AutoMapper;

namespace AcademyCalendarApi.Services
{
    public class TeacherService : ITeacherService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public TeacherService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<BasicTeacherDto>> GetAllAsync()
        {
            var teachers = await _unitOfWork.TeacherRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<BasicTeacherDto>>(teachers);
        }

        public async Task<TeacherDto> GetByIdAsync(int id)
        {
            var teacher = await _unitOfWork.TeacherRepository.GetByIdAsync(id);
            return _mapper.Map<TeacherDto>(teacher);
        }

        public async Task AddAsync(AddTeacherDto teacherDto)
        {
            var teacher = _mapper.Map<Teacher>(teacherDto);
            await _unitOfWork.TeacherRepository.AddAsync(teacher);
            await _unitOfWork.SaveAllAsync();
        }

        public async Task DeleteByIdAsync(int id)
        {
            await _unitOfWork.TeacherRepository.DeleteByIdAsync(id);
            await _unitOfWork.SaveAllAsync();
        }

        public async Task Update(UpdateTeacherDto teacherDto)
        {
            var teacher = await _unitOfWork.TeacherRepository.GetByIdAsync(teacherDto.Id);
            
            teacher.Name = teacherDto.Name;

            _unitOfWork.TeacherRepository.Update(teacher);
            
            await _unitOfWork.SaveAllAsync();
        }
    }
}