using AcademyCalendarApi.Entities;
using AcademyCalendarApi.Interfaces;

namespace AcademyCalendarApi.Data.Repositories
{
    public class TeacherRepository : BaseRepository<Teacher>, ITeacherRepository
    {
        public TeacherRepository(DataContext context) : base(context)
        {
        }
    }
}