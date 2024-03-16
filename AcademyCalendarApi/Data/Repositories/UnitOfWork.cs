using AcademyCalendarApi.Interfaces;

namespace AcademyCalendarApi.Data.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext _context;

        public IClassroomRepository ClassroomRepository { get; }
        public ITeacherRepository TeacherRepository { get; }

        public UnitOfWork(DataContext context, IClassroomRepository classroomRepository, ITeacherRepository teacherRepository)
        {
            _context = context;
            ClassroomRepository = classroomRepository;
            TeacherRepository = teacherRepository;
        }

        public async Task<bool> SaveAllAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}