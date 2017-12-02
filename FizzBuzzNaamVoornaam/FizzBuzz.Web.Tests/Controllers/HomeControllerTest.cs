using System;
using System.Web.Mvc;
using ExerciseHelpers;
using FizzBuzz.Web.Controllers;
using FizzBuzz.Web.Models.FizzBuzzViewModels;
using NUnit.Framework;
using Assert = NUnit.Framework.Assert;

namespace FizzBuzz.Web.Tests.Controllers
{
    [TestFixture]
    public class HomeControllerTest : ExerciseBase
    {
        private HomeController _controller;
        [SetUp]
        public void Setup()
        {
            _controller = new HomeController();
        }

        [Test]
        public void Index_Get_ReturnsViewWithDefaultModel()
        {
            // Arrange
            FizzBuzzViewModel expectedViewModel = FizzBuzzViewModel.CreateDefault();

            // Act
            //TODO: invoke the Index() action
            var result = _controller.Index() as ViewResult; 

            // Assert
            //TODO: assert that the correct ActionResult is returned
            //TODO: assert that the correct ViewModel is used
            Assert.That(result, Is.Not.Null);
            var model = result.Model as FizzBuzzViewModel;
            Assert.That(model, Is.EqualTo(expectedViewModel));
        }

        [Test]
        public void Index_Post_ValidModel_ReturnsViewWithPostedModel()
        {
            // Arrange
            //TODO: create the model that is posted
            var random = new Random();
            var postedViewModel = new FizzBuzzViewModel
            {
                FizzFactor = random.Next(1, int.MaxValue),
                BuzzFactor = random.Next(1, int.MaxValue),
                LastNumber = null
            };

            // Act
            //TODO: invoke the Index(FizzBuzzViewModel model) action
            var result = _controller.Index(postedViewModel) as ViewResult;

            // Assert
            //TODO: assert that the correct ActionResult is returned
            //TODO: assert that the posted ViewModel is used again in the View
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Model, Is.EqualTo(postedViewModel));
        }
    }
}
