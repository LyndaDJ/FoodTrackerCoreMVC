using FoodTrackingApp2.Data;
using FoodTrackingApp2.Models;
using FoodTrackingApp2.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FoodTrackingApp2.Controllers
{
    public class FoodController : Controller
    {
        private IFoodRepository _foodrepo;

        public FoodController(IFoodRepository _foodrepo)
        {
            this._foodrepo = _foodrepo;
        }
        //GET
        public IActionResult Index()
        {
            IEnumerable<Food> objFoodList = from food in _foodrepo.GetAll() select food;
            return View(objFoodList);
        }

        //GET
        public IActionResult Create()
        {
            return View();
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Food food)
        {
            if (ModelState.IsValid)
            {
                _foodrepo.InsertFoodRecord(food);
                _foodrepo.Save();
                //TempData["success"] = "Food Record has been added";
                return RedirectToAction("Index");
            }
            return View(food);
        }

        //GET
        public IActionResult Edit(int id)
        {
            if(id==null||id== 0)
            {
                return NotFound(); 
            }
            Food foodFromDb = _foodrepo.GetByID(id);

            if(foodFromDb==null)
            {
                return NotFound();
            }
            return View(foodFromDb);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Food food)
        {
            if (ModelState.IsValid)
            {
                _foodrepo.UpdateFoodRecord(food);
                _foodrepo.Save();
                //TempData["success"] = "Food Record has been updated";
                return RedirectToAction("Index");
            }
            return View(food);
        }

        //GET
        public IActionResult Delete(int id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Food foodFromDb = _foodrepo.GetByID(id);

            if (foodFromDb == null)
            {
                return NotFound();
            }
            return View(foodFromDb);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(int id)
        {
            Food food = _foodrepo.GetByID(id);
            if (food == null)
            {
                return NotFound();
            }
            _foodrepo.DeleteFoodRecord(id);
            _foodrepo.Save();
            //TempData["success"] = "Food Record has been deleted";
            return RedirectToAction("Index");
    
        }

        //GET: Foods/Search
        public IActionResult Search()
        {
            return View();
        }

        [HttpPost]
        //POST: Foods/SearchResults
        public IActionResult SearchResults(string Phrase)
        {
            return View("Index", _foodrepo.GetFoodRecordsByPhrase(Phrase).ToList());
        }

        //GET: 
        public IActionResult SearchbyDate()
        {
            return View();
        }
        //POST: 
        [HttpPost]
        public IActionResult SearchbyDateResults(DateTime datefilter)
        {
            return View("Index", _foodrepo.GetFoodRecordsByDate(datefilter).ToList());
        }


    }
}
