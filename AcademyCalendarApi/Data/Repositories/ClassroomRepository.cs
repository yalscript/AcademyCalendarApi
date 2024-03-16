using AcademyCalendarApi.Entities;
using AcademyCalendarApi.Interfaces;

namespace AcademyCalendarApi.Data.Repositories
{
    public class ClassroomRepository : BaseRepository<Classroom>, IClassroomRepository
    {
        public ClassroomRepository(DataContext context) : base(context)
        {
        }
    }
}