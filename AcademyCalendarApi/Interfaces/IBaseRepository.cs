using AcademyCalendarApi.Entities;

namespace AcademyCalendarApi.Interfaces
{
    public interface IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<TEntity> GetByIdAsync(int id);
        Task AddAsync(TEntity classroom);
        void Update(TEntity classroom);
        Task DeleteByIdAsync(int id);
    }
}