using AcademyCalendarApi.Data;
using Microsoft.EntityFrameworkCore;

namespace AcademyCalendarApi.Extensions
{
    public static class ApplicationDatabaseExtensions
    {
        public static IServiceCollection AddApplicationDatabase(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<DataContext>(options =>
            {
                options.UseSqlite(config.GetConnectionString("DefaultConnection"));
            });

            return services;
        }
    }
}