using AcademyCalendarApi.DTOs;
using AcademyCalendarApi.Entities;
using AcademyCalendarApi.Interfaces;
using AutoMapper;

namespace AcademyCalendarApi.Services
{
    public class ClassService : IClassService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ClassService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<BasicClassDto>> GetAllAsync()
        {
            var classes = await _unitOfWork.ClassRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<BasicClassDto>>(classes);
        }

        public async Task<ClassDto> GetByIdAsync(int id)
        {
            var academyClass = await _unitOfWork.ClassRepository.GetByIdAsync(id);
            return _mapper.Map<ClassDto>(academyClass);
        }

        public async Task AddAsync(AddClassDto classDto)
        {
            var academyClass = _mapper.Map<Class>(classDto);
            await _unitOfWork.ClassRepository.AddAsync(academyClass);
            await _unitOfWork.SaveAllAsync();
        }

        public async Task DeleteByIdAsync(int id)
        {
            await _unitOfWork.ClassRepository.DeleteByIdAsync(id);
            await _unitOfWork.SaveAllAsync();
        }

        public async Task Update(UpdateClassDto classDto)
        {
            var academyClass = await _unitOfWork.ClassRepository.GetByIdAsync(classDto.Id);
            
            academyClass.Type = classDto.Type;
            academyClass.StartedAt = classDto.StartedAt;
            academyClass.EndedAt = classDto.EndedAt;

            _unitOfWork.ClassRepository.Update(academyClass);
            
            await _unitOfWork.SaveAllAsync();
        }
    }
}