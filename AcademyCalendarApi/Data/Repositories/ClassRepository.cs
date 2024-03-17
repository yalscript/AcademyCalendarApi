using AcademyCalendarApi.Entities;
using AcademyCalendarApi.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AcademyCalendarApi.Data.Repositories
{
    public class ClassRepository : BaseRepository<Class>, IClassRepository
    {
        private readonly DataContext _context;

        public ClassRepository(DataContext context) : base(context)
        {
            _context = context;
        }

        public new async Task<IEnumerable<Class>> GetAllAsync()
        {
            return await _context.Classes
                .Include(x => x.Teacher)
                .Include(x => x.Subject)
                .Include(x => x.Classroom)
                .ToListAsync();
        }
    }
}