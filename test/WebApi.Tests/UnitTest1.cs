using Microsoft.AspNetCore.Mvc;
using Moq;
using Stockpot.BusinessLogic.Recipes;
using Stockpot.WebApi.Controllers;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Stockpot.WebApi.Tests
{
    public class UnitTest1
    {
        private readonly RecipesController _controller;

        public UnitTest1()
        {
            var mockRepo = new Mock<RecipesService>();
            mockRepo
                .Setup(repo => repo.GetSingleOrDefault(It.IsAny<int>()))
                .Returns((int id) => {
                    return Task.FromResult(GetTestRecipes()
                        .Where(r => r.Id == id)
                        .FirstOrDefault());
                });

            _controller = new RecipesController(mockRepo.Object);
        }

        [Fact]
        public async void Return_NotFound_When_No_Data()
        {
            // Act
            var result = await _controller.Get(0);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async void Return_Ok_When_Data()
        {
            // Act
            var result = await _controller.Get(1);

            // Assert
            Assert.IsType<OkObjectResult>(result);
        }

        private IList<RecipeDto> GetTestRecipes()
        {
            return new List<RecipeDto> { new RecipeDto { Id = 1 } };
        }
    }
}
