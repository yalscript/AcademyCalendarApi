using AcademyCalendarApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace AcademyCalendarApi.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Classroom> Classrooms { get; set; }
    }
}