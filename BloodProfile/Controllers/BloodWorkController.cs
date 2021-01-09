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
    }
}
