using AcademyCalendarApi.DTOs;
using AcademyCalendarApi.Entities;
using AcademyCalendarApi.Interfaces;
using AutoMapper;

namespace AcademyCalendarApi.Services
{
    public class ClassroomService : IClassroomService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ClassroomService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<BasicClassroomDto>> GetAllAsync()
        {
            var classrooms = await _unitOfWork.ClassroomRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<BasicClassroomDto>>(classrooms);
        }

        public async Task<ClassroomDto> GetByIdAsync(int id)
        {
            var classroom = await _unitOfWork.ClassroomRepository.GetByIdAsync(id);
            return _mapper.Map<ClassroomDto>(classroom);
        }

        public async Task AddAsync(AddClassroomDto classroomDto)
        {
            var classroom = _mapper.Map<Classroom>(classroomDto);
            await _unitOfWork.ClassroomRepository.AddAsync(classroom);
            await _unitOfWork.SaveAllAsync();
        }

        public async Task DeleteByIdAsync(int id)
        {
            await _unitOfWork.ClassroomRepository.DeleteByIdAsync(id);
            await _unitOfWork.SaveAllAsync();
        }

        public async Task Update(UpdateClassroomDto classroomDto)
        {
            var classroom = await _unitOfWork.ClassroomRepository.GetByIdAsync(classroomDto.Id);
            
            classroom.Name = classroomDto.Name;
            classroom.Seats = classroomDto.Seats;

            _unitOfWork.ClassroomRepository.Update(classroom);
            
            await _unitOfWork.SaveAllAsync();
        }
    }
}