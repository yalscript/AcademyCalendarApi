using AcademyCalendarApi.DTOs;
using AcademyCalendarApi.Entities;
using AutoMapper;

namespace API.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Classroom, ClassroomDto>();
            CreateMap<Classroom, BasicClassroomDto>();
            CreateMap<AddClassroomDto, Classroom>();
            CreateMap<UpdateClassroomDto, Classroom>();
        }
    }
}