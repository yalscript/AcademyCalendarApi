using AcademyCalendarApi.Entities;
using AcademyCalendarApi.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AcademyCalendarApi.Data.Repositories
{
    public class ClassroomRepository : IClassroomRepository
    {
        private readonly DataContext _context;

        public ClassroomRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Classroom>> GetAllAsync()
        {
            return await _context.Classrooms.ToListAsync();
        }

        public async Task<Classroom> GetByIdAsync(int id)
        {
            return await _context.Classrooms.FindAsync(id);
        }

        public async Task AddAsync(Classroom classroom)
        {
            await _context.AddAsync(classroom);
        }

        public void Update(Classroom classroom)
        {
            _context.Entry(classroom).State = EntityState.Modified;
        }

        public async Task DeleteByIdAsync(int id)
        {
            var classroom = await _context.Classrooms.FindAsync(id);

            _context.Classrooms.Remove(classroom);
        }
    }
}