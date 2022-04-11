using FoodTrackingApp2.Controllers;
using FoodTrackingApp2.Models;
using FoodTrackingApp2.Repositories;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;

namespace FoodTrackerTests
{
    public class FoodsControllerTests
    {
        private FoodController foodsController;
        private Mock<IFoodRepository> mockfoodRepo;
        private Food food, foodWith_id;

        [SetUp]
        public void Setup()
        {
            mockfoodRepo = new Mock<IFoodRepository>();
            foodsController = new FoodController(mockfoodRepo.Object);
            foodWith_id = food = new Food
            {
                Snacks = "N/A",
                Fat = "coconut oil",
                Protein = "chicken",
                Carbohydrate = "rice",
                Meal = MealType.Dinner,
                CreatedDate = System.DateTime.Now
            };
            foodWith_id.Id = 1;

        }
        [Test]
        public void Index_ReturnsView_WithListOfFoodRecords()
        {
            //Arrange

            IEnumerable<Food> foods = new[] { food, foodWith_id };
            mockfoodRepo.Setup(m => m.GetAll()).Returns(foods);

            //Act
            var result = foodsController.Index() as ViewResult;

            //Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Model);
            Assert.AreEqual(foods, result.Model);
        }

        [Test]
        public void Edit_ReturnsNotFound_WhenIdIs0()
        {
            var result = foodsController.Edit(0);
            Assert.That(result, Is.TypeOf<NotFoundResult>());
        }

        //[Test]
        //public void Edit_ShouldReturnFoodWithSameID()
        //{
        //    var food = new Food() { Id = 1 };
        //    mockfoodRepo.Setup(m => m.GetByID(1)).Returns(food);

        //    var result = foodsController.Edit(id:1);

        //    Assert.IsNotNull(result);
        //    Assert.AreEqual(food.Id, result.C);
        //}


        [Test]
        public void Delete_ReturnsView_WithFoodByID()
        {
            var food = new Food() { Id = 1 };
            mockfoodRepo.Setup(repo => repo.GetByID(1)).Returns(food);

            var result = foodsController.Delete(1) as ViewResult;

            Assert.AreEqual(food, result.Model);
        }

        [Test]
        public void DeletePOST_RedirectsToIndex()
        {
            var food = new Food() { Id = 1 };
            mockfoodRepo.Setup(repo => repo.GetByID(1)).Returns(food);

            var result = foodsController.DeletePOST(food.Id) as RedirectToActionResult;

            Assert.AreEqual("Index", result.ActionName);
        }

    }
}