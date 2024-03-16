using AcademyCalendarApi.Data.Repositories;
using AcademyCalendarApi.Interfaces;
using AcademyCalendarApi.Services;

namespace AcademyCalendarApi.Extensions
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
        {           
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<IClassroomService, ClassroomService>();
            services.AddScoped<IClassroomRepository, ClassroomRepository>();
            
            services.AddScoped<ITeacherService, TeacherService>();
            services.AddScoped<ITeacherRepository, TeacherRepository>();

            services.AddScoped<ISubjectService, SubjectService>();
            services.AddScoped<ISubjectRepository, SubjectRepository>();

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            return services;
        }
    }
}