using AcademyCalendarApi.DTOs;
using AcademyCalendarApi.Entities;
using AcademyCalendarApi.Interfaces;
using AutoMapper;

namespace AcademyCalendarApi.Services
{
    public class ClassroomService : IClassroomService
    {
        private readonly IClassroomRepository _classroomRepository;
        private readonly IMapper _mapper;

        public ClassroomService(IClassroomRepository classroomRepository, IMapper mapper)
        {
            _classroomRepository = classroomRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<BasicClassroomDto>> GetAllAsync()
        {
            var classrooms = await _classroomRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<BasicClassroomDto>>(classrooms);
        }

        public async Task<ClassroomDto> GetByIdAsync(int id)
        {
            var classroom = await _classroomRepository.GetByIdAsync(id);
            return _mapper.Map<ClassroomDto>(classroom);
        }

        public async Task AddAsync(AddClassroomDto classroomDto)
        {
            var classroom = _mapper.Map<Classroom>(classroomDto);
            await _classroomRepository.AddAsync(classroom);
            await _classroomRepository.SaveAllAsync();
        }

        public async Task DeleteByIdAsync(int id)
        {
            await _classroomRepository.DeleteByIdAsync(id);
            await _classroomRepository.SaveAllAsync();
        }

        public async Task Update(UpdateClassroomDto classroomDto)
        {
            var classroom = await _classroomRepository.GetByIdAsync(classroomDto.Id);
            
            classroom.Name = classroomDto.Name;
            classroom.Seats = classroomDto.Seats;

            _classroomRepository.Update(classroom);
            
            await _classroomRepository.SaveAllAsync();
        }
    }
}