using System;
using KSTrips.Application.Services;
using KSTrips.Domain.Entities;
using KSTrips.Infrastructure.Interfaces;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KSTrips_API_Tests
{
    [TestFixture]
    public class UserTests
    {
        private Mock<IUnitOfWork> _unitOfWork;
        private UserService _userService;
        private List<User> _users;

        [SetUp]
        public void SetUp()
        {
            _unitOfWork = new Mock<IUnitOfWork>();
            _userService = new UserService(_unitOfWork.Object);
            _users = new List<User>
            {
                new User()
                {
                    Id = 0,
                    AuthZeroId = string.Empty,
                    Name = string.Empty,
                    UserName =  string.Empty,
                    Password = string.Empty,
                    IsActive = true
                }
            };
        }

        [Test]
        public void GetUsers_WhenResultExist_ReturnUsers()
        {
            // Arrange
            _unitOfWork.Setup(uow => uow.UserRepository.GetUsers())
                .ReturnsAsync(_users);

            // Act
            Task<List<User>> result = _userService.GetUsers();

            // Assert
            Assert.That(result.Result, Is.Not.Null);
            Assert.That(result.Result.Count, Is.GreaterThan(0));
            Assert.That(result, Is.TypeOf<Task<List<User>>>());
        }

        [Test]
        public void AddUsers_WhenResultExist_ReturnUsers()
        {

            // Arrange
            _unitOfWork.Setup(uow => uow.UserRepository.GetUsers())
                .ReturnsAsync(_users);

            User user = new User()
            {
                Id = 0,
                Name = "Test User",
                AuthZeroId = new Guid().ToString(),
                UserName = "",
                Password = "",
                DateCreated = DateTime.Now,
                Email = "",
                IsActive = true
            };

            // Act
            bool result = _userService.SaveUsers(user);

            // Assert
            _unitOfWork.Verify(uow => uow.UserRepository.SaveUsers(It.IsAny<User>()));
           // Assert.That(result, Is.EqualTo(true));
          
        }

        [Test]
        public void UpdateUsers_WhenResultExist_ReturnUsers()
        {
            // Arrange
            _unitOfWork.Setup(uow => uow.UserRepository.GetUsers())
                .ReturnsAsync(_users);

            List<User> users = new List<User>()
            {
                new User
                {
                    Id = 0,
                    Name = "Test User",
                    AuthZeroId = new Guid().ToString(),
                    UserName = "",
                    Password = "",
                    DateCreated = DateTime.Now,
                    Email = "",
                    IsActive = true
                }

            };

            // Act
            bool result = _userService.UpdateUsers(users);

            // Assert
            _unitOfWork.Verify(uow => uow.UserRepository.UpdateUsers(It.IsAny<List<User>>()));
           // Assert.That(result, Is.EqualTo(true));
           
        }

    }
}
