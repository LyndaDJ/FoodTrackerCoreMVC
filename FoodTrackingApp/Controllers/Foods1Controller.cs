#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FoodTrackingApp.Data;
using FoodTrackingApp.Models;
using FoodTrackingApp.Repositories;
using System.Data;

namespace FoodTrackingApp.Controllers
{
    public class Foods1Controller : Controller
    {
        private IFood _food;

        public Foods1Controller()
        {
            _food = new FoodRepositoryClass(new ApplicationDbContext());
        }

        // GET: Foods1
        public ActionResult Index()
        {
            var foods = from food in _food.GetAll() select food;
            return View(foods);
        }

        public ActionResult Details(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Food rec = _food.GetByID(id);
            if (rec == null)
            {
                return NotFound();
            }  
            return View(rec);

        }

        public ActionResult Create()
        {
            return View(new Food());
        }

        [HttpPost]
        public ActionResult Create(Food food)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _food.InsertFoodRecord(food);
                    _food.Save();
                    return RedirectToAction(nameof(Index));
                }
            }
            catch(DataException)
            {
                ModelState.AddModelError("", "Unable to save changes. Please try again");

            }
            return View(food);

        }

        public ActionResult Edit(int id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Food food = _food.GetByID(id);
            if (food == null)
            {
                return NotFound();
            }
            return View(food);
        }
        [HttpPost]
        public ActionResult Edit(Food food)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    _food.UpdateFoodRecord(food);
                    _food.Save();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException)
            {
                ModelState.AddModelError("", "Unable to save changes. Please try again");
            }

            return View(food);
        }

        public ActionResult Delete(int id)
        {
            Food food = _food.GetByID(id);
            return View(food);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Food food = _food.GetByID(id);
            _food.DeleteFoodRecord(id);
            _food.Save();
            return RedirectToAction("Index");
        }

        public ActionResult Search()
        {
            return View();
        }

        //POST: Foods/SearchResults
        public ActionResult SearchResults([FromQuery] string Phrase)
        {
            return View("Index", _food.GetFoodRecordsByPhrase(Phrase).ToList());
        }

        //GET: 
        public ActionResult SearchbyDate()
        {
            return View();
        }
        //POST: 
        public ActionResult SearchbyDateResults(DateTime datefilter)
        {
            return View("Index", _food.GetFoodRecordsByDate(datefilter).ToList());
        }

    }
       
}
