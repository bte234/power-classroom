using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using power_classroom.Models;

namespace power_classroom.Services
{
    public interface INewsResourceService
    {
        Task<NewsResource[]> GetResourceAsync();
        Task<bool> AddItemAsync(NewsResource newItem);
    }
}