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
using Microsoft.AspNetCore.Authorization;
using FoodTrackingApp.Repositories;
using System.Data;

namespace FoodTrackingApp.Controllers
{
    public class FoodsController : Controller
    {
        private IFood _foodrepo;

        public FoodsController(IFood _foodrepo)
        {
            this._foodrepo = _foodrepo;
        }

        // GET: Foods
        public ActionResult Index()
        {
            var foods = from food in _foodrepo.GetAll() select food;
            return View(foods);
        }

        //GET: Foods/Search
        public ActionResult Search()
        {
            return View();
        }

        //POST: Foods/SearchResults
        public ActionResult SearchResults(string Phrase)
        {
            return View("Index", _foodrepo.GetFoodRecordsByPhrase(Phrase).ToList());
        }

        //GET: 
        public ActionResult SearchbyDate()
        {
            return View();
        }
        //POST: 
        public ActionResult SearchbyDateResults(DateTime datefilter)
        {
            return View("Index", _foodrepo.GetFoodRecordsByDate(datefilter).ToList());
        }

        // GET: Foods/Details/5
        public ActionResult Details(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Food rec = _foodrepo.GetByID(id);
            if (rec == null)
            {
                return NotFound();
            }
            return View(rec);
        }

        // GET: Foods/Create

        public ActionResult Create()
        {
            return View(new Food());
        }

        // POST: Foods/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind("Id,CreatedDate,Meal,Carbohydrate,Protein,Fat,Snacks")] Food food)
        {
            if (ModelState.IsValid)
            {
                _foodrepo.InsertFoodRecord(food);
                _foodrepo.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(food);
        }

        // GET: Foods/Edit/5
        public ActionResult Edit(int id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Food food = _foodrepo.GetByID(id);
            if (food == null)
            {
                return NotFound();
            }
            return View(food);
        }

        // POST: Foods/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, [Bind("Id,CreatedDate,Meal,Carbohydrate,Protein,Fat,Snacks")] Food food)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    _foodrepo.UpdateFoodRecord(food);
                    _foodrepo.Save();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException)
            {
                ModelState.AddModelError("", "Unable to save changes. Please try again");
            }

            return View(food);
        }

        // GET: Foods/Delete/5
        public ActionResult Delete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Food food = _foodrepo.GetByID(id);
            if (food == null)
            {
                return NotFound();
            }

            return View(food);
        }

        // POST: Foods/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Food food = _foodrepo.GetByID(id);
            _foodrepo.DeleteFoodRecord(id);
            _foodrepo.Save();
            return RedirectToAction("Index");
        }

    }

}
