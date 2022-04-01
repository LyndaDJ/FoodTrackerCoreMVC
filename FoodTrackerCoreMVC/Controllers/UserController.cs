using Microsoft.AspNetCore.Mvc;
using FoodTrackerCoreMVC.Models;

namespace FoodTrackerCoreMVC.Controllers
{
    public class UserController : Controller
    {
        [HttpGet]
        public ActionResult Index(int id = 0)
        {
            User userModel = new User();
            return View(userModel);
        }

        /*[HttpPost]
        public ActionResult Index(User user)
        {
            using (UserAcctEntities dbModel = new UserAcctEntities())
            {
                if (dbModel.AccountDetails.Any(x => x.Username == accountDetail.Username))
                {
                    ViewBag.DuplicateMessage = "This Username already exists.";
                    return View("AddorEdit", accountDetail);
                }
                dbModel.AccountDetails.Add(accountDetail);
                dbModel.SaveChanges();
            }
            ModelState.Clear();
            ViewBag.SuccessMessage = "Registration Successful";
            return View("AddorEdit", new AccountDetail());
        }*/
    }
}
