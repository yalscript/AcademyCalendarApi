using AcademyCalendarApi.DTOs;
using AcademyCalendarApi.Entities;
using AcademyCalendarApi.Interfaces;
using AcademyCalendarApi.Services;
using AutoMapper;
using Moq;

namespace AcademyCalendarApi.Tests.Services
{
    public class TeacherServiceTests
    {
        private readonly TeacherService _teacherService;
        private readonly Mock<IUnitOfWork> _mockUnitOfWork;
        private readonly Mock<IMapper> _mockMapper;

        public TeacherServiceTests()
        {
            _mockUnitOfWork = new Mock<IUnitOfWork>();
            _mockMapper = new Mock<IMapper>();
            _teacherService = new TeacherService(_mockUnitOfWork.Object, _mockMapper.Object);
        }

        [Fact]
        public async Task GetAllAsync_ReturnsListOfTeachers()
        {
            // Arrange
            var teachers = new List<Teacher>
            {
                new Teacher { Id = 1, Name = "Teacher 1" },
                new Teacher { Id = 2, Name = "Teacher 2" }
            };

            var basicTeacherDtos = new List<BasicTeacherDto>
            {
                new BasicTeacherDto { Id = 1, Name = "Teacher 1" },
                new BasicTeacherDto { Id = 2, Name = "Teacher 2" }
            };

            _mockUnitOfWork
                .Setup(uow => uow.TeacherRepository.GetAllAsync())
                .ReturnsAsync(teachers);

            _mockMapper
                .Setup(mapper => mapper.Map<IEnumerable<BasicTeacherDto>>(teachers))
                .Returns(basicTeacherDtos);

            // Act
            var result = await _teacherService.GetAllAsync();

            // Assert
            Assert.Equal(basicTeacherDtos, result);
        }

        [Fact]
        public async Task GetByIdAsync_ReturnsTeacherDto_WhenTeacherExists()
        {
            // Arrange
            var teacherId = 1;
            var teacher = new Teacher { Id = teacherId, Name = "Teacher 1" };
            var teacherDto = new TeacherDto { Id = teacherId, Name = "Teacher 1" };

            _mockUnitOfWork
                .Setup(uow => uow.TeacherRepository.GetByIdAsync(teacherId))
                .ReturnsAsync(teacher);

            _mockMapper
                .Setup(mapper => mapper.Map<TeacherDto>(teacher))
                .Returns(teacherDto);

            // Act
            var result = await _teacherService.GetByIdAsync(teacherId);

            // Assert
            Assert.Equal(teacherDto, result);
        }

        [Fact]
        public async Task GetByIdAsync_ReturnsNull_WhenTeacherDoesNotExist()
        {
            // Arrange
            var teacherId = 1;

            _mockUnitOfWork
                .Setup(uow => uow.TeacherRepository.GetByIdAsync(teacherId))
                .ReturnsAsync((Teacher)null!);

            // Act
            var result = await _teacherService.GetByIdAsync(teacherId);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public async Task AddAsync_ReturnsAddedTeacherDto()
        {
            // Arrange
            var addTeacherDto = new AddTeacherDto { Name = "New Teacher" };
            var teacher = new Teacher { Id = 1, Name = "New Teacher" };
            var basicTeacherDto = new BasicTeacherDto { Id = 1, Name = "New Teacher" };

            _mockMapper
                .Setup(mapper => mapper.Map<Teacher>(addTeacherDto))
                .Returns(teacher);

            _mockUnitOfWork
                .Setup(uow => uow.TeacherRepository.AddAsync(teacher))
                .ReturnsAsync(teacher);

            _mockMapper
                .Setup(mapper => mapper.Map<BasicTeacherDto>(teacher))
                .Returns(basicTeacherDto);

            // Act
            var result = await _teacherService.AddAsync(addTeacherDto);

            // Assert
            Assert.Equal(basicTeacherDto, result);
        }

        [Fact]
        public async Task DeleteByIdAsync_DeletesTeacher()
        {
            // Arrange
            var teacherId = 1;

            _mockUnitOfWork
                .Setup(uow => uow.TeacherRepository.DeleteByIdAsync(teacherId));

            // Act
            await _teacherService.DeleteByIdAsync(teacherId);

            // Assert
            _mockUnitOfWork.Verify(uow => uow.TeacherRepository.DeleteByIdAsync(teacherId), Times.Once);
            _mockUnitOfWork.Verify(uow => uow.SaveAllAsync(), Times.Once);
        }

        [Fact]
        public async Task Update_UpdatesTeacher()
        {
            // Arrange
            var updateTeacherDto = new UpdateTeacherDto { Id = 1, Name = "Updated Teacher" };
            var teacher = new Teacher { Id = 1, Name = "Teacher" };

            _mockUnitOfWork
                .Setup(uow => uow.TeacherRepository.GetByIdAsync(updateTeacherDto.Id))
                .ReturnsAsync(teacher);

            _mockUnitOfWork
                .Setup(uow => uow.TeacherRepository.Update(teacher));

            // Act
            await _teacherService.Update(updateTeacherDto);

            // Assert
            Assert.Equal(updateTeacherDto.Name, teacher.Name);
            _mockUnitOfWork.Verify(uow => uow.TeacherRepository.Update(teacher), Times.Once);
            _mockUnitOfWork.Verify(uow => uow.SaveAllAsync(), Times.Once);
        }
    }
}
