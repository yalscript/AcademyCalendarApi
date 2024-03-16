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

            CreateMap<Teacher, TeacherDto>();
            CreateMap<Teacher, BasicTeacherDto>();
            CreateMap<AddTeacherDto, Teacher>();
            CreateMap<UpdateTeacherDto, Teacher>();

            CreateMap<Subject, SubjectDto>();
            CreateMap<Subject, BasicSubjectDto>();
            CreateMap<AddSubjectDto, Subject>();
            CreateMap<UpdateSubjectDto, Subject>();
        }
    }
}