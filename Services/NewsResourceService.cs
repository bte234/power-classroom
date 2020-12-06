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

        public async Task<NewsResource[]> GetResourceAsync()
        {
            var resources = await _context.NewsResourceList
                .Where(x => x.ArticleType == "Resource" || x.ArticleType == "resource")
                .ToArrayAsync();
            return resources;
        }

        public async Task<bool> AddItemAsync(NewsResource newItem)
        {
            newItem.Id = Guid.NewGuid();

            _context.NewsResourceList.Add(newItem);

            var saveResult = await _context.SaveChangesAsync();
            return saveResult == 1;
        }
    }
}