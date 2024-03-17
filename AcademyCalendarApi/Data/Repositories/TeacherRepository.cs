using AcademyCalendarApi.Entities;
using AcademyCalendarApi.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AcademyCalendarApi.Data.Repositories
{
    public class TeacherRepository : BaseRepository<Teacher>, ITeacherRepository
    {
        private readonly DataContext _context;

        public TeacherRepository(DataContext context) : base(context)
        {
            _context = context;
        }

        public override async Task<Teacher> GetByIdAsync(int id)
        {
            return await _context.Teachers
                .Include(x => x.Subjects)
                .FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}