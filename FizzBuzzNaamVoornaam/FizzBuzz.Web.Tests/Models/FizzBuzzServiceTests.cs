using System;
using ExerciseHelpers;
using FizzBuzz.Web.Models;
using Moq;
using NUnit.Framework;

namespace FizzBuzz.Web.Tests.Models
{
    public class FizzBuzzServiceTests : ExerciseBase
    {
        private Mock<IFizzBuzzValidator> _fizzBuzzValidatorMock;
        private IFizzBuzzService _fizzBuzzService;
        [SetUp]
        public void Setup()
        {
            _fizzBuzzValidatorMock = new Mock<IFizzBuzzValidator>();
            _fizzBuzzService = new FizzBuzzService(_fizzBuzzValidatorMock.Object);
        }

        [Test]
        public void ThrowsFizzBuzzValidationExceptionWhenOneOfTheArgumentsIsInvalid()
        {
            //Arrange
            //"Mock the validator so that it always throws a FizzBuzzValidationException (Use 'Throws' method instead of 'Returns')"
            _fizzBuzzValidatorMock.Setup(v => v.Validate(0, It.IsAny<int>(), It.IsAny<int>())).Throws(new FizzBuzzValidationException());

            //Act + Assert
            //TODO: call GenerateFizzBuzzText and assert that it (re)throws the exception thrown by de IFizzBuzzValidator
            Assert.Throws<FizzBuzzValidationException>(() =>_fizzBuzzService.GenerateFizzBuzzText(0, It.IsAny<int>(), It.IsAny<int>()));
        }

        [Test]
        [TestCase(2, 3, 1, "1")]
        [TestCase(4, 5, 4, "1 2 3 Fizz")]
        [TestCase(5, 4, 4, "1 2 3 Buzz")]
        [TestCase(2, 3, 15, "1 Fizz Buzz Fizz 5 FizzBuzz 7 Fizz Buzz Fizz 11 FizzBuzz 13 Fizz Buzz")]
        [TestCase(2, 2, 4, "1 FizzBuzz 3 FizzBuzz")]
        public void ReturnsCorrectFizzBuzzTextWhenParametersAreValid(int fizzFactor, int buzzFactor, int lastNumber, string expected)
        {
            //Arrange

            //Act
            var result = _fizzBuzzService.GenerateFizzBuzzText(fizzFactor, buzzFactor, lastNumber);

            //Assert
            Assert.That(result, Is.EqualTo(expected));
        }
    }
}
