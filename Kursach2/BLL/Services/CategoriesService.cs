using BLL.Interfaces;
using Core.Context;
using Domain.Entities;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Servises
{
    public class CategoriesService : ICategoriesService
    {
        private readonly ApplicationContext _context;
        public CategoriesService(ApplicationContext context)
        {
            _context = context;
        }
        public async Task<bool> AddCategory(Category category)
        {
            try
            {
                if (category != null)
                {
                    _context.Categories.Add(category);
                    await _context.SaveChangesAsync();

                    return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }

            public async Task<List<CategoryModel>> GetAllCategories()
        {
            try
            {
                var categories = await _context.Categories.ToListAsync();
                var categoryModels = new List<CategoryModel>();
                foreach (var category in categories)
                {
                    categoryModels.Add(new CategoryModel() { Id = category.Id, CategoryName = category.CategoryName });
                }

                return categoryModels;
            }
            catch(Exception ex)
            {
                return null;
            }
        }

        public async Task<bool> RmoveCategory(string name)
        {
            try
            {
                var removeItem = _context.Categories.FirstOrDefault(c => c.CategoryName == name);
                _context.Categories.Remove(removeItem);
                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
