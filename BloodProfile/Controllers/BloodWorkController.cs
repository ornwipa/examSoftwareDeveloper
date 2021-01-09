using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BloodProfile.Services;
using BloodProfile.Models;

namespace BloodProfile.Controllers
{
    public class BloodWorkController : Controller
    {
        private readonly IBloodWorkService _bloodWorkService;
        public BloodWorkController(IBloodWorkService bloodWorkService)
        {
            _bloodWorkService = bloodWorkService;
        }
        public async Task<IActionResult> Index()
        {
            // Get blood work records from database
            var records = await _bloodWorkService.GetBloodWorkAsync();

            // Put records into a model
            var model = new BloodWorkList()
            {
                Records = records
            };

            // render view using the model     
            return View(model);
        }
        public PartialViewResult Details(Guid Id)
        {
            var model = _bloodWorkService.GetSpecificBloodWorkAsync(Id);
            return PartialView(model);            
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
    }
}
