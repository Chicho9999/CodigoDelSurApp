using CodigoDelSurApp.Application.Interfaces;
using CodigoDelSurApp.Controllers;
using CodigoDelSurApp.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace CodigoDelSur.Test
{
    public class Tests
    {
        [Test]
        public async Task GetBeerWithNameAsync()
        {
            // Arrange
            var mockRepository = new Mock<IBeerService>();
            List<Beer> beers = [new Beer { Id = 42, Description = "Test", Name = "Test" }];
            mockRepository.Setup(x => x.GetBeersNameAsync("Test")).ReturnsAsync(beers);
            var controller = new BeerController(mockRepository.Object);

            // Act
            var actionResult = await controller.GetBeersByName("Test");
            var contentResult = actionResult.Result as OkObjectResult;
            var beerResult = contentResult.Value as List<Beer>;

            // Assert
            Assert.That(beerResult, Is.Not.Null);
            Assert.That(beerResult.First().Id, Is.EqualTo(42));
        }
    }
}