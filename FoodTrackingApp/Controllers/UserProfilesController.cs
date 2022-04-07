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
    public class UserProfilesController : Controller
    {
        private IUserProfile _userProfilerepo;

        public UserProfilesController(IUserProfile userProfilerepo)
        {
            this._userProfilerepo = _userProfilerepo;
        }

        // GET: UserProfiles/Details/5
        public ActionResult Details(string username)
        {
            if (username == null)
            {
                return RedirectToPage("/Account/Login", new { area = "Identity" });
            }

            UserProfile profile_detail = _userProfilerepo.GetByUsername(username);
            if (profile_detail == null)
            {
                return RedirectToAction("Create", "UserProfiles");
            }
            return View(profile_detail);
        }
        
        // GET: UserProfiles/Create
        public ActionResult Create()
        {
            return View(new UserProfile());
        }

        // POST: UserProfiles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind("UserprofileId,Firstname,Lastname,Height,Weight,Goalweight")] UserProfile userProfile)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _userProfilerepo.CreateNewprofile(userProfile);
                    _userProfilerepo.Save();
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (DataException)
            {
                ModelState.AddModelError("", "Unable to save changes. Please try again");

            }
            return View(userProfile);
        }

        // GET: UserProfiles/Edit/5
        public ActionResult Edit(int id)
        {
            if (id == null)
            {
                return NotFound();
            }
            UserProfile userProfile = _userProfilerepo.GetByID(id);
            if (userProfile == null)
            {
                return NotFound();
            }
            return View(userProfile);
        }

        // POST: UserProfiles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, [Bind("UserprofileId,Firstname,Lastname,Height,Weight,Goalweight")] UserProfile userProfile)
        {
            if (id != userProfile.UserprofileId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _userProfilerepo.EditProfile(userProfile);
                _userProfilerepo.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(userProfile);
        }
    }
}
