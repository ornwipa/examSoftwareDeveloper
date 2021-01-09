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
                return BadRequest("Invalid input for data type.");
            }
            return RedirectToAction("Index");
        }
    }
}
