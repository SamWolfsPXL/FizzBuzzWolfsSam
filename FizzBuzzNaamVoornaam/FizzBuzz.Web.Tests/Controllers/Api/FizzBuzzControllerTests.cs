using System;
using System.Configuration;
using System.Web.Http.Results;
using ExerciseHelpers;
using FizzBuzz.Web.Controllers.Api;
using FizzBuzz.Web.Models;
using Moq;
using NUnit.Framework;

namespace FizzBuzz.Web.Tests.Controllers.Api
{
    [TestFixture]
    public class FizzBuzzControllerTests : ExerciseBase
    {
        private Mock<IFizzBuzzService> _serviceMock;
        private FizzBuzzController _controller;
        [SetUp]
        public void Setup()
        {
            _serviceMock = new Mock<IFizzBuzzService>();
            _controller = new FizzBuzzController(_serviceMock.Object);
        }

        [Test]
        public void GetFizzBuzzText_ReturnsFizzBuzzTextGeneratedFromService()
        {
            //Arrange
            //"Mock the service so that it always returns some (randomly generated) string"
            var expectedText = Guid.NewGuid().ToString();
            _serviceMock.Setup(s => s.GenerateFizzBuzzText(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>())).Returns(expectedText);
          
            //Act
            var result = _controller.GetFizzBuzzText(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>()) as OkNegotiatedContentResult<string>;

            //Assert
            //TODO: assert that the correct IHttpActionResult is returned
            //TODO: assert that the FizzBuzzService was used correctly
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Content, Is.EqualTo(expectedText));
            _serviceMock.Verify(s => s.GenerateFizzBuzzText(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>()), Times.Once);
        }

        [Test]
        
        public void GetFizzBuzzText_ReturnsBadRequestIfServiceCannotGenerateText()
        {
            //Arrange"Mock the service so that it always throws a FizzBuzzValidationException (Use 'Throws' method instead of 'Returns')"
            _serviceMock.Setup(s => s.GenerateFizzBuzzText(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>())).Throws(new FizzBuzzValidationException());

            //Act
            var result = _controller.GetFizzBuzzText(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>()) as BadRequestResult;

            //Assert
            //TODO: assert that the correct IHttpActionResult is returned
            //TODO: assert that the FizzBuzzService was used correctly
            Assert.That(result, Is.Not.Null);
            _serviceMock.Verify(s => s.GenerateFizzBuzzText(0, It.IsAny<int>(), 0), Times.Once());
        }
    }
}
