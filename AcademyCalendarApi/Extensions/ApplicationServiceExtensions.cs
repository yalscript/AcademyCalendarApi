using AcademyCalendarApi.Data.Repositories;
using AcademyCalendarApi.Interfaces;
using AcademyCalendarApi.Services;

namespace AcademyCalendarApi.Extensions
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
        {           
            services.AddScoped<IClassroomService, ClassroomService>();
            services.AddScoped<IClassroomRepository, ClassroomRepository>();

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            return services;
        }
    }
}