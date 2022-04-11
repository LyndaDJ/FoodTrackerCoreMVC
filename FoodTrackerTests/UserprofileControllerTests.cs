using FoodTrackingApp2.Controllers;
using FoodTrackingApp2.Models;
using FoodTrackingApp2.Repositories;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;

namespace FoodTrackerTests
{
    public class UserprofileControllerTests
    {
        private ProfileController profileController;
        private Mock<IProfileRepository> mockprofileRepo;
        private Profile profile, profileWith_id;
        [SetUp]
        public void Setup()
        {
            mockprofileRepo = new Mock<IProfileRepository>();
            profileController = new ProfileController(mockprofileRepo.Object);
            profileWith_id = profile = new Profile
            {
                Firstname ="Lynda",
                Lastname = "Dijeh",
                Height =   180,
                Weight =   180,
                Goalweight = 160
            };
            profileWith_id.Id = 1;

        }

        [Test]
        public void Details_returnsUserProfilebyId()
        {
            var profile = new Profile() { Id = 1 };
            mockprofileRepo.Setup(repo => repo.GetByID(1)).Returns(profile);

            var result = profileController.Details(1) as ViewResult;

            Assert.AreEqual(profile, result.Model);
        }

        [Test]
        public void Details_ReturnsNotFound_WhenIdIs0()
        {
            //Profile nullprofile = null;
            //mockprofileRepo.Setup(repo => repo.GetByID(0)).Returns(nullprofile);
            
            var result = profileController.Details(0);
            Assert.That(result, Is.TypeOf<NotFoundResult>());
        }

        //[Test]
        //public void Details_ReturnsNotFound_WhenProfileIsNull()
        //{
        //    Profile nullprofile = null;
        //    mockprofileRepo.Setup(repo => repo.GetByID(0)).Returns(nullprofile);   


        //    Assert.That(nullprofile., Is.TypeOf<NotFoundResult>());
        //}


    }
}
