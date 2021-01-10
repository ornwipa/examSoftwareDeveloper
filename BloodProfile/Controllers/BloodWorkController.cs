using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using BloodProfile.Services;
using BloodProfile.Models;

namespace BloodProfile.Controllers
{
    // [Authorize]
    public class BloodWorkController : Controller
    {
        private readonly IBloodWorkService _bloodWorkService;
        // private readonly UserManager<ApplicationUser> _userManager;
        public BloodWorkController(IBloodWorkService bloodWorkService)
                                    //, UserManager<ApplicationUser> userManager)
        {
            _bloodWorkService = bloodWorkService;
            // _userManager = userManager;
        }

        public async Task<IActionResult> Index(string searchString, DateTime startDate, DateTime endDate)
        {
            // var currentUser = await _userManager.GetUserAsync(User);
            // if (currentUser == null) return Challenge(); // ask the user to login again
            
            // Get blood work records from database, including search
            var records = await _bloodWorkService.GetBloodWorkAsync(searchString, startDate, endDate);

            // Put records into a model
            var model = new BloodWorkList()
            {
                Records = records
            };

            // render view using the model     
            return View(model);
        }

        public IActionResult Details(Guid Id)
        {
            var model = _bloodWorkService.GetSpecificBloodWork(Id);
            return View(model);            
        }
       
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddRecord(BloodWork newBloodWork)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }
            var successful = await _bloodWorkService.AddRecordAsync(newBloodWork);
            if (!successful)
            {
                return BadRequest("Record could not be added.");
            }
            return RedirectToAction("Index");
        }

        public IActionResult EditRecord(Guid Id)
        {
            if (Id == Guid.Empty)
            {
                return NotFound();
            }
            var record = _bloodWorkService.GetSpecificBloodWork(Id);
            if (record == null)
            {
                return NotFound();
            }
            return View(record);
        }
        
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SaveEdit(Guid Id, BloodWork selectedBloodWork)
        {
            if (Id == Guid.Empty)
            {
                return RedirectToAction("Index");
            }
            var successful = await _bloodWorkService.EditRecordAsync(Id, selectedBloodWork);
            if (!successful)
            {
                return BadRequest("Invalid data");
            }
            return RedirectToAction("Index");
        }
    }
}
