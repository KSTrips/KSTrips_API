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

        [SetUp]
        public void SetUp()
        {
            _unitOfWork = new Mock<IUnitOfWork>();
            _simulationService = new SimulationService(_unitOfWork.Object);
        }

        [Test]
        public void GetCarCategories_WhenResultExist_ReturnCarCategories()
        {
            // Act
            var result = _simulationService.GetCarCategories();

            // Assert
            Assert.That(result, Is.TypeOf<Task<List<CarCategory>>>());
        }

        public void GetTypeExpenseCategories_WhenResultExist_ReturnTypeExpenses()
        {
            // Act
            var result = _simulationService.GetExpenseCategories();

            // Assert
            Assert.That(result, Is.TypeOf<Task<List<ExpenseCategory>>>());
        }
    }
}
