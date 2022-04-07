using FoodTrackingApp.Controllers;
using FoodTrackingApp.Models;
using FoodTrackingApp.Repositories;
using Moq;
using NUnit.Framework;

namespace FoodTrackerTests
{
    public class FoodsControllerTests
    {
        private FoodsController foodsController;
        private Mock<IFood> mockfoodRepo;
        private Food food, foodWith_id;

        [SetUp]
        public void Setup()
        {
            mockfoodRepo = new Mock<IFood>();
            foodsController = new FoodsController(mockfoodRepo.Object);
            foodWith_id = food = new Food
            { 
                Username = "lyn@gmail.com",
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
        public void Index_ReturnsViewWithListOfFoodRecords()
        {
            //Arrange

            //Act

            //Assert

        }

        [Test]
        public void PostMethodCreate_InsertsFoodintoRecord()
        {

            mockfoodRepo.Setup(repo => repo.InsertFoodRecord(food));

        }

        [Test]
        public void SearchResults_ReturnsFilteredIndexbyPhrase()
        {
            //Arrange

            //Act

            //Assert
            Assert.Pass();
        }
    }
}