using Microsoft.AspNetCore.Mvc;
using FoodTrackerCoreMVC.Models;

namespace FoodTrackerCoreMVC.Controllers
{
    public class UserController : Controller
    {
        public ActionResult Index(int id = 0)
        {
            User userModel = new User();
            return View(userModel);
        }
    }
}
