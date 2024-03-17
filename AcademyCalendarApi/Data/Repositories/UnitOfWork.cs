using AcademyCalendarApi.Interfaces;

namespace AcademyCalendarApi.Data.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext _context;

        public IClassroomRepository ClassroomRepository { get; }
        public ITeacherRepository TeacherRepository { get; }
        public ISubjectRepository SubjectRepository { get; }
        public IClassRepository ClassRepository { get; }

        public UnitOfWork(
            DataContext context,
            IClassroomRepository classroomRepository,
            ITeacherRepository teacherRepository,
            ISubjectRepository subjectRepository,
            IClassRepository classRepository)
        {
            _context = context;
            ClassroomRepository = classroomRepository;
            TeacherRepository = teacherRepository;
            SubjectRepository = subjectRepository;
            ClassRepository = classRepository;
        }

        public async Task<bool> SaveAllAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}