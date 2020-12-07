using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using power_classroom.Models;

namespace power_classroom.Services
{
    public interface INewsResourceService
    {
        Task<NewsResource> GetItemByIdAsync(Guid id);
        Task<NewsResource[]> GetNewsAsync();
        Task<NewsResource[]> GetResourceAsync();
        Task<bool> AddItemAsync(NewsResource newItem);
        Task<bool> UpdateItemAsync(Guid id, NewsResource currentItem);
    }
}