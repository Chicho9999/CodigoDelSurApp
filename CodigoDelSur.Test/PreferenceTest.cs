using CodigoDelSurApp.Application.Interfaces;
using CodigoDelSurApp.Controllers;
using CodigoDelSurApp.Domain.Entities;
using CodigoDelSurApp.Dtos;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace CodigoDelSur.Test
{
    public class PreferenceTest
    {
        [Test]
        public async Task Add_preference_to_user_success()
        {
            // Arrange
            var mockRepository = new Mock<IPreferenceService>();
            var userPreferenceDto = new UserPreferenceDto { PreferenceKey = "Test", PreferenceValue = "Test" };

            mockRepository.Setup(x => x.CreatePreferenceAsync(It.IsAny<UserPreference>())).ReturnsAsync(true);
            var controller = new PreferenceController(mockRepository.Object);

            // Act
            var actionResult = await controller.CreatePreferenceAsync(userPreferenceDto);
            var contentResult = actionResult.Result as OkResult;

            // Assert
            Assert.That(contentResult, Is.Not.Null);
            Assert.That(contentResult.StatusCode, Is.EqualTo(200));
        }

        [Test]
        public async Task Add_preference_to_user_error()
        {
            // Arrange
            var mockRepository = new Mock<IPreferenceService>();
            var userPreferenceDto = new UserPreferenceDto { PreferenceKey = "Test", PreferenceValue = "Test" };

            mockRepository.Setup(x => x.CreatePreferenceAsync(It.IsAny<UserPreference>())).ReturnsAsync(false);
            var controller = new PreferenceController(mockRepository.Object);

            // Act
            var actionResult = await controller.CreatePreferenceAsync(userPreferenceDto);
            var contentResult = actionResult.Result as BadRequestObjectResult;

            // Assert
            Assert.That(contentResult, Is.Not.Null);
            Assert.That(contentResult.StatusCode, Is.EqualTo(400));
        }
    }
}