using Domain.Entities;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface ICategoriesService
    {
        public Task<bool> AddCategory(Category category);

        public Task<List<CategoryModel>> GetAllCategories();
    }
}
