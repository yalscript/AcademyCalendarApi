using AcademyCalendarApi.DTOs;
using AcademyCalendarApi.Entities;
using AcademyCalendarApi.Interfaces;
using AutoMapper;

namespace AcademyCalendarApi.Services
{
    public class SubjectService : ISubjectService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public SubjectService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<BasicSubjectDto>> GetAllAsync()
        {
            var subjects = await _unitOfWork.SubjectRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<BasicSubjectDto>>(subjects);
        }

        public async Task<SubjectDto> GetByIdAsync(int id)
        {
            var subject = await _unitOfWork.SubjectRepository.GetByIdAsync(id);
            return _mapper.Map<SubjectDto>(subject);
        }

        public async Task AddAsync(AddSubjectDto subjectDto)
        {
            var subject = _mapper.Map<Subject>(subjectDto);
            await _unitOfWork.SubjectRepository.AddAsync(subject);
            await _unitOfWork.SaveAllAsync();
        }

        public async Task DeleteByIdAsync(int id)
        {
            await _unitOfWork.SubjectRepository.DeleteByIdAsync(id);
            await _unitOfWork.SaveAllAsync();
        }

        public async Task Update(UpdateSubjectDto subjectDto)
        {
            var subject = await _unitOfWork.SubjectRepository.GetByIdAsync(subjectDto.Id);
            
            subject.Name = subjectDto.Name;

            _unitOfWork.SubjectRepository.Update(subject);
            
            await _unitOfWork.SaveAllAsync();
        }
    }
}