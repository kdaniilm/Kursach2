using BLL.Interfaces;
using Core.Context;
using Domain.Entities;
using Domain.Models;
using Domain.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Servises
{
    public class ProductService : IProductService
    {
        private readonly ApplicationContext _context;
        public ProductService(ApplicationContext context)
        {
            _context = context;
        }
        public async Task<bool> AddProduct(Product product, List<Characteristic> characteristics, string categoryId, List<string> imagePathes)
        {
            if (product != null && characteristics != null && categoryId != null)
            {
                product.CategoryId = categoryId;
                _context.Products.Add(product);
                await _context.SaveChangesAsync();

                foreach (var characteristic in characteristics)
                {
                    characteristic.Product = product;
                    _context.Characteristics.Add(characteristic);
                }
                await _context.SaveChangesAsync();

                foreach(var imagePath in imagePathes)
                {
                    _context.Images.Add(new Image() { ImgPath = imagePath, Product = product});
                }
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }
        public async Task<List<ProductViewModel>> GetAllProducts()
        {
            var result = new List<ProductViewModel>();

            var products = await _context.Products.ToListAsync();
            
            foreach(var product in products)
            {
                var productVM = new ProductViewModel();
                productVM.CharactristicModels = new List<CharactristicModel>();
                productVM.Images = new List<string>();
                productVM.ProductModel = new ProductModel() { ProductName = product.ProductName, ProductPrice = product.ProductPrice};
                var characteristics = await _context.Characteristics.Where(c => c.ProductId == product.Id).ToListAsync();
                foreach (var characteristic in characteristics)
                {
                    productVM.CharactristicModels.Add(new CharactristicModel() { CharacteristicName = characteristic.CharacteristicName, CharacteristicValue = characteristic.CharacteristicValue });
                }

                var images = await _context.Images.Where(img => img.ProductId == product.Id).ToListAsync();
                foreach(var image in images)
                {
                    productVM.Images.Add(image.ImgPath);
                }
                result.Add(productVM);
            }
            return result;
        }

    }
}
