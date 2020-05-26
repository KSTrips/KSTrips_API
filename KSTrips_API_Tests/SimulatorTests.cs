using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using KSTrips.Application.Services;
using KSTrips.Domain.Entities;
using KSTrips.Infrastructure.Interfaces;
using Moq;
using NUnit.Framework;

namespace KSTrips_API_Tests
{

    [TestFixture]
    public class SimulatorTests
    {
        private Mock<IUnitOfWork> _unitOfWork;
        private SimulationService _simulationService;
        private List<CarCategory> _carCategory;
        private List<ExpenseCategory> _expenseCategory;

        [SetUp]
        public void SetUp()
        {
            _unitOfWork = new Mock<IUnitOfWork>();
            _simulationService = new SimulationService(_unitOfWork.Object);
            _carCategory = new List<CarCategory>
            {
                new CarCategory()
                {
                    Id = 0,
                    Description = string.Empty,
                    CarTypes = string.Empty,
                    IsActive = true
                }
            };

            _expenseCategory = new List<ExpenseCategory>
            {
                new ExpenseCategory()
                {
                    Id = 0,
                    Description = string.Empty,
                    IsActive = true
                }
            };
        }

        [Test]
        public void GetCarCategories_WhenResultExist_ReturnCarCategories()
        {
            // Arrange
            _unitOfWork.Setup(uow => uow.CarRepository.GetCarCategories())
                .ReturnsAsync(_carCategory);

            // Act
            var result = _simulationService.GetCarCategories();

            // Assert
            Assert.That(result.Result, Is.Not.Null);
            Assert.That(result.Result.Count, Is.GreaterThan(0));
            Assert.That(result, Is.TypeOf<Task<List<CarCategory>>>());
        }

        [Test]
        public void GetTypeExpenseCategories_WhenResultExist_ReturnExpenses()
        {
            // Arrange
            _unitOfWork.Setup(uow => uow.ExpenseRepository.GetExpenseCategories())
                .ReturnsAsync(_expenseCategory);

            // Act
            var result = _simulationService.GetExpenseCategories();

            // Assert
            Assert.That(result.Result, Is.Not.Null);
            Assert.That(result.Result.Count, Is.GreaterThan(0));
            Assert.That(result, Is.TypeOf<Task<List<ExpenseCategory>>>());
        }
    }
}
