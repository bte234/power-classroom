using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using power_classroom.Data;
using power_classroom.Models;
using Microsoft.EntityFrameworkCore;

namespace power_classroom.Services
{
    public class NewsResourceService : INewsResourceService
    {
        private readonly ApplicationDbContext _context;

        public NewsResourceService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<NewsResource> GetItemByIdAsync(Guid id)
        {
            var item = await _context.NewsResourceList
                .Where(x => x.Id == id)
                .SingleOrDefaultAsync();
            return item;
        }

        public async Task<NewsResource[]> GetResourceAsync()
        {
            var resources = await _context.NewsResourceList
                .Where(x => x.ArticleType == ArticleEnum.Resource)
                .ToArrayAsync();
            return resources;
        }

        public async Task<NewsResource[]> GetNewsAsync() {
            var news = await _context.NewsResourceList
                .Where(x => x.ArticleType == ArticleEnum.News)
                .ToArrayAsync();
            return news;
        }

        public async Task<bool> AddItemAsync(NewsResource newItem)
        {
            newItem.Id = Guid.NewGuid();

            _context.NewsResourceList.Add(newItem);

            var saveResult = await _context.SaveChangesAsync();
            return saveResult == 1;
        }

        public async Task<bool> UpdateItemAsync(Guid id, NewsResource currentItem)
        {
            var data = await _context.NewsResourceList
                .Where(x => x.Id == id)
                .SingleOrDefaultAsync();

            if (data == null) return false;

            data.Title = currentItem.Title;
            data.Source = currentItem.Source;
            data.URL = currentItem.URL;

            var saveResult = await _context.SaveChangesAsync();
            return saveResult == 1;
        }
    }
}