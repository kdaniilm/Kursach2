using Domain.Entities;
using Domain.Models;
using Domain.ViewModels;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IProductService
    {
        public Task<bool> AddProduct(Product product, List<Characteristic> characteristic, string categoryId, List<string> images);

        public Task<List<ProductViewModel>> GetAllProducts();

        public Task<ProductViewModel> GetOneProduct(string id);

        public Task<List<ProductViewModel>> GetProductsWithFilters(CategoryModel category);

        public Task<bool> RemoveProduct(string id);
    }
}
