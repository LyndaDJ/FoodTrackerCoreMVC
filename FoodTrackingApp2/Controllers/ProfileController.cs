using FoodTrackingApp2.Data;
using FoodTrackingApp2.Models;
using FoodTrackingApp2.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FoodTrackingApp2.Controllers
{
    public class ProfileController : Controller
    {
        private IProfileRepository _profilerepo;

        public ProfileController(IProfileRepository _profilerepo)
        {
            this._profilerepo = _profilerepo;
        }

        // GET: UserProfiles/Details/5
        public ActionResult Details(int id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            Profile profile_detail = _profilerepo.GetByID(id);
            if (profile_detail == null)
            {
                return NotFound();
            }
            return View(profile_detail);
        }

        // GET: UserProfiles/Create
        public ActionResult Create()
        {
            return View(new Profile());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Profile profile)
        {
            if (ModelState.IsValid)
            {
                _profilerepo.CreateNewprofile(profile);
                _profilerepo.Save();
                return RedirectToAction("Details", new { id = profile.Id });

            }
            return View(profile);
        }


        
       /* //GET
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var profileFromDb = _db.Profiles.Find(id);

            if (profileFromDb == null)
            {
                return NotFound();
            }
            return View(profileFromDb);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Profile profile)
        {
            if (ModelState.IsValid)
            {
                _db.Profiles.Update(profile);
                _db.SaveChanges();
                return RedirectToAction("Details", new { id = profile.Id });
            }
            return View(profile);
        }*/



    }
}
