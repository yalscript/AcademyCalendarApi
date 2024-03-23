using AcademyCalendarApi.Controllers;
using AcademyCalendarApi.DTOs;
using AcademyCalendarApi.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace AcademyCalendarApi.Tests.Controllers
{
    public class TeacherControllerTest
    {
        private readonly TeacherController _teacherController;
        private readonly Mock<ITeacherService> _mockTeacherService;

        public TeacherControllerTest() {
            _mockTeacherService = new Mock<ITeacherService>();

            _teacherController = new TeacherController(_mockTeacherService.Object);
        }

        [Fact]
        public async Task GetAll_ReturnsListOfTeachers()
        {
            // Arrange
            var teachers = new List<BasicTeacherDto>
            {
                new BasicTeacherDto { Id = 1, Name = "Teacher 1" },
                new BasicTeacherDto { Id = 2, Name = "Teacher 2" },
            };

            _mockTeacherService.Setup(service => service.GetAllAsync()).ReturnsAsync(teachers);

            // Act
            var result = await _teacherController.GetAll();

            // Assert
            var actionResult = Assert.IsType<ActionResult<IEnumerable<BasicTeacherDto>>>(result);
            var okObjectResult = Assert.IsType<OkObjectResult>(actionResult.Result);
            var model = Assert.IsAssignableFrom<IEnumerable<BasicTeacherDto>>(okObjectResult.Value);
            Assert.Equal(teachers, model);
        }

        [Fact]
        public async Task GetById_ReturnsTeacherById()
        {
            // Arrange
            var teacherId = 1;
            var teacherDto = new TeacherDto { Id = teacherId, Name = "Teacher 1" };

            _mockTeacherService.Setup(service => service.GetByIdAsync(teacherId)).ReturnsAsync(teacherDto);

            // Act
            var result = await _teacherController.GetById(teacherId);

            // Assert
            var actionResult = Assert.IsType<ActionResult<TeacherDto>>(result);
            var okObjectResult = Assert.IsType<OkObjectResult>(actionResult.Result);
            var model = Assert.IsType<TeacherDto>(okObjectResult.Value);
            Assert.Equal(teacherDto, model);
        }

        [Fact]
        public async Task GetById_ReturnsNotFound_WhenTeacherNotFound()
        {
            // Arrange
            var teacherId = 1;
            TeacherDto nullTeacherDto = null!; 

            _mockTeacherService.Setup(service => service.GetByIdAsync(teacherId)).ReturnsAsync(nullTeacherDto);

            // Act
            var result = await _teacherController.GetById(teacherId);

            // Assert
            var actionResult = Assert.IsType<ActionResult<TeacherDto>>(result);
            Assert.IsType<NotFoundResult>(actionResult.Result);
        }

        [Fact]
        public async Task AddAsync_ReturnsCreatedResponse_WhenTeacherAddedSuccessfully()
        {
            // Arrange
            var newTeacherName = "New Teacher";
            var teacherDto = new AddTeacherDto { Name = newTeacherName };
            var addedTeacherDto = new BasicTeacherDto { Id = 1, Name = newTeacherName };

            _mockTeacherService.Setup(service => service.AddAsync(teacherDto)).ReturnsAsync(addedTeacherDto);

            // Act
            var result = await _teacherController.AddAsync(teacherDto);

            // Assert
            var actionResult = Assert.IsType<ActionResult<BasicTeacherDto>>(result);
            var createdAtActionResult = Assert.IsType<CreatedAtActionResult>(actionResult.Result);
            var model = Assert.IsType<BasicTeacherDto>(createdAtActionResult.Value);
            Assert.Equal(addedTeacherDto, model);
        }

        [Fact]
        public async Task Update_ReturnsNoContent_WhenTeacherUpdatedSuccessfully()
        {
            // Arrange
            var teacherDto = new UpdateTeacherDto { Id = 1, Name = "Updated Teacher" };

            // Act
            var result = await _teacherController.Update(teacherDto);

            // Assert
            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public async Task DeleteByIdAsync_ReturnsNoContent_WhenTeacherDeletedSuccessfully()
        {
            // Arrange
            var teacherId = 1;

            // Act
            var result = await _teacherController.DeleteByIdAsync(teacherId);

            // Assert
            Assert.IsType<NoContentResult>(result);
        }
    }
}