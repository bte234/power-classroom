using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using power_classroom.Services;
using power_classroom.Models;

namespace power_classroom.Controllers
{
    public class NewsResourceController : Controller
    {
        private readonly INewsResourceService _newsResourceService;

        public NewsResourceController(INewsResourceService newsResourceService)
        {
            _newsResourceService = newsResourceService;
        }
        public async Task<IActionResult> Index()
        {
            //get items from db
            var resources = await _newsResourceService.GetResourceAsync();

            // Put items into a model
            var model = new NewsResourceViewModel()
            {
                NewsResourceList = resources
            };

            // Render view using the model
            return View(model);
        }

        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateNew(NewsResource newItem)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }

            var successful = await _newsResourceService.AddItemAsync(newItem);
            if (!successful)
            {
                return BadRequest("Could not add resource.");
            }

            return RedirectToAction("Index");
        }
    }
}