using Microsoft.EntityFrameworkCore.Infrastructure;

namespace AcademyCalendarApi.Tests.Utils.Extensions
{
    public static class DatabaseFacadeExtensions
    {
        public static async Task ClearDatabaseAsync(this DatabaseFacade database)
        {
            await database.EnsureDeletedAsync();
            await database.EnsureCreatedAsync();
        }
    }
}