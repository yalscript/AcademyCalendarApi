using AcademyCalendarApi.Data;
using AcademyCalendarApi.Data.Repositories;
using AcademyCalendarApi.Entities;
using AcademyCalendarApi.Tests.Utils.Extensions;
using Microsoft.EntityFrameworkCore;

namespace AcademyCalendarApi.Tests.Repositories
{
    
    public class TeacherRepositoryTests
    {
        private readonly DbContextOptions<DataContext> _dbContextOptions;
        private readonly DataContext _dataContext;
        private readonly TeacherRepository _teacherRepository;

        public TeacherRepositoryTests()
        {
            _dbContextOptions = new DbContextOptionsBuilder<DataContext>()
                .UseInMemoryDatabase(databaseName: "TestDb")
                .Options;

            _dataContext = new DataContext(_dbContextOptions);

            _teacherRepository = new TeacherRepository(_dataContext);
        }

        [Fact]
        public async Task GetByIdAsync_ReturnsTeacherWithSubjects()
        {
            // Arrange
            await _dataContext.Database.ClearDatabaseAsync();

            var teacher = new Teacher { Id = 1, Name = "Teacher 1" };
            var subject1 = new Subject { Id = 1, Name = "Subject 1" };
            var subject2 = new Subject { Id = 2, Name = "Subject 2" };
            
            teacher.Subjects.Add(subject1);
            teacher.Subjects.Add(subject2);
            
            await _dataContext.Teachers.AddAsync(teacher);
            await _dataContext.SaveChangesAsync();

            // Act
            var dbTeacher = await _teacherRepository.GetByIdAsync(1);

            // Assert
            Assert.NotNull(dbTeacher);
            Assert.Equal(1, dbTeacher.Id);
            Assert.Equal(2, dbTeacher.Subjects.Count);
        }

        [Fact]
        public async Task GetByIdAsync_ReturnsNull_WhenTeacherNotFound()
        {
            // Act
            var dbTeacher = await _teacherRepository.GetByIdAsync(-1);

            // Assert
            Assert.Null(dbTeacher);
        }

        [Fact]
        public async Task GetAllAsync_ReturnsAllTeachers()
        {
            // Arrange
            await _dataContext.Database.ClearDatabaseAsync();

            var teachers = new List<Teacher>
            {
                new Teacher { Id = 1, Name = "Teacher 1" },
                new Teacher { Id = 2, Name = "Teacher 2" }
            };
            
            await _dataContext.Teachers.AddRangeAsync(teachers);
            await _dataContext.SaveChangesAsync();
            
            // Act
            var dbTeachers = await _teacherRepository.GetAllAsync();
            
            // Assert
            Assert.Equal(2, dbTeachers.Count());
            Assert.Equal(dbTeachers, teachers);
        }

        [Fact]
        public async Task AddAsync_AddsNewTeacher()
        {
            // Arrange
            await _dataContext.Database.ClearDatabaseAsync();

            var newTeacher = new Teacher { Id = 1, Name = "New Teacher" };

            // Act
            var addedTeacher = await _teacherRepository.AddAsync(newTeacher);
            await _dataContext.SaveChangesAsync();

            // Assert
            Assert.Equal(1, await _dataContext.Teachers.CountAsync());
            Assert.NotNull(addedTeacher);
            Assert.Equal(1, addedTeacher.Id);
            Assert.Equal("New Teacher", addedTeacher.Name);
        }

        [Fact]
        public async Task Update_UpdatesTeacher()
        {
            // Arrange
            await _dataContext.Database.ClearDatabaseAsync();
            
            var subject1 = new Subject { Id = 1, Name = "Subject 1" };
            var subject2 = new Subject { Id = 2, Name = "Subject 2" };
            var subject3 = new Subject { Id = 3, Name = "Subject 3" };
            
            var teacher = new Teacher { Id = 1, Name = "Teacher 1" };
            teacher.Subjects.Add(subject1);
            teacher.Subjects.Add(subject2);

            await _dataContext.Teachers.AddAsync(teacher);
            await _dataContext.SaveChangesAsync();
            
            // Act
            teacher.Name = "Updated Teacher 1";
            teacher.Subjects.Remove(subject2);
            teacher.Subjects.Add(subject3);
            
            _teacherRepository.Update(teacher);

            // Assert
            var updatedTeacher = await _dataContext.Teachers.FindAsync(1);

            Assert.Equal(EntityState.Modified, _dataContext.Entry(teacher).State);
            Assert.NotNull(updatedTeacher);
            Assert.Equal("Updated Teacher 1", updatedTeacher.Name);
            Assert.Equal(2, updatedTeacher.Subjects.Count);
            Assert.Equal(3, updatedTeacher.Subjects.FirstOrDefault(x => x.Id == 3)!.Id);
            Assert.Null(updatedTeacher.Subjects.FirstOrDefault(x => x.Id == 2));
        }

        [Fact]
        public async Task DeleteByIdAsync_DeletesTeacher()
        {
            // Arrange
            await _dataContext.Database.ClearDatabaseAsync();

            var teacher = new Teacher { Id = 1, Name = "Teacher 1" };

            await _dataContext.Teachers.AddAsync(teacher);
            await _dataContext.SaveChangesAsync();
            
            // Act
            await _teacherRepository.DeleteByIdAsync(1);
            await _dataContext.SaveChangesAsync();

            // Assert
            Assert.Null(await _dataContext.Teachers.FindAsync(1));
        }
    }
}