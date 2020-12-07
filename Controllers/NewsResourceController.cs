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
        public IActionResult Index()
        {
            // //get items from db
            // var resources = await _newsResourceService.GetResourceAsync();

            // // Put items into a model
            // var model = new NewsResourceViewModel()
            // {
            //     NewsResourceList = resources
            // };

            // // Render view using the model
            // return View(model);
            return View();
        }

        public async Task<IActionResult> Resources() {
            //get items from db
            var resources = await _newsResourceService.GetResourceAsync();

            // Put items into a model
            var model = new NewsResourceViewModel()
            {
                Title = "Resources",
                NewsResourceList = resources
            };

            // Render view using the model
            return View("List", model);
        }

        public async Task<IActionResult> News() {
            var news = await _newsResourceService.GetNewsAsync();
            var model = new NewsResourceViewModel() {
                Title = "News",
                NewsResourceList = news
            };

            return View("List", model);
        }

        public IActionResult AddArticle()
        {
            return View();
        }

        public async Task<IActionResult> Edit(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var item = await _newsResourceService.GetItemByIdAsync(id);
            return View("Edit", item);
        }

        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateNew(NewsResource newItem)
        {
            if (!ModelState.IsValid)
            {
                if (newItem.ArticleType == ArticleEnum.News) {
                    return RedirectToAction("News");
                } else {
                    return RedirectToAction("Resources");
                }
            }

            var successful = await _newsResourceService.AddItemAsync(newItem);
            if (!successful)
            {
                return BadRequest("Could not add resource.");
            }

            
            if (newItem.ArticleType == ArticleEnum.News) {
                return RedirectToAction("News");
            } else {
                return RedirectToAction("Resources");
            }
        }

        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(Guid id, NewsResource currentItem)
        {
            if (id == Guid.Empty)
            {
                if (currentItem.ArticleType == ArticleEnum.News) {
                    return RedirectToAction("News");
                } else {
                    return RedirectToAction("Resources");
                }
            }

            var success = await _newsResourceService.UpdateItemAsync(id, currentItem);
            if (!success)
            {
                return BadRequest("Could not update item.");
            }

            if (currentItem.ArticleType == ArticleEnum.News) {
                return RedirectToAction("News");
            } else {
                return RedirectToAction("Resources");
            }

            // return RedirectToAction("Index"); //TODO: gotta go to News or Resource
        }
    }
}