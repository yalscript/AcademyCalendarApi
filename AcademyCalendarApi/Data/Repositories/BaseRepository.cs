using System.Linq.Expressions;
using AcademyCalendarApi.Entities;
using AcademyCalendarApi.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AcademyCalendarApi.Data.Repositories
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        private readonly DataContext _context;

        public BaseRepository(DataContext context)
        {
            _context = context;
        }

        public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _context.Set<TEntity>().ToListAsync();
        }

        public virtual async Task<TEntity> GetByIdAsync(int id)
        {
            return await _context.Set<TEntity>().FindAsync(id);
        }

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            return (await _context.AddAsync(entity)).Entity;
        }

        public void Update(TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }

        public async Task DeleteByIdAsync(int id)
        {
            var entity = await _context.Set<TEntity>().FindAsync(id);

            _context.Set<TEntity>().Remove(entity);
        }
    }
}