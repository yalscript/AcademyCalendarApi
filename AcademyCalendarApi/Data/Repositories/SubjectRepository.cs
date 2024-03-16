using AcademyCalendarApi.Entities;
using AcademyCalendarApi.Interfaces;

namespace AcademyCalendarApi.Data.Repositories
{
    public class SubjectRepository : BaseRepository<Subject>, ISubjectRepository
    {
        public SubjectRepository(DataContext context) : base(context)
        {
        }
    }
}