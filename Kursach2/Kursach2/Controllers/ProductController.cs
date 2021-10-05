using AutoMapper;
using BLL.Interfaces;
using BLL.Servises;
using Domain.Entities;
using Domain.Models;
using Domain.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Kursach2.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICategoriesService _categoriesService;
        private readonly IWebHostEnvironment _webHostEnvironment;

        private readonly IMapper _mapper;

        private static List<string> _images = new List<string>();
        private static List<CharactristicModel> _charactristicModels = new List<CharactristicModel>();
        public ProductController(IProductService productService, ICategoriesService categoriesService, IMapper mapper, IWebHostEnvironment webHostEnvironment)
        {
            _productService = productService;
            _categoriesService = categoriesService;
            _mapper = mapper;
            _webHostEnvironment = webHostEnvironment;
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<ActionResult> AddProduct(List<IFormFile> files, string ProductName, float ProductPrice, string Category)
        {
            try
            {
                if (files != null)
                {
                    var folderName = Guid.NewGuid().ToString();
                    var folderPath = Path.Combine(_webHostEnvironment.WebRootPath, "Images");
                    var savePath = Path.Combine(folderPath, folderName);
                    if (!Directory.Exists(savePath))
                    {
                        Directory.CreateDirectory(savePath);
                    }
                    var dbPath = Path.Combine("https://", Request.Host.Value, "Images", folderName);
                    foreach (var file in files)
                    {
                        var filePath = Path.Combine(savePath, file.FileName);
                        dbPath = Path.Combine(dbPath, file.FileName);
                        _images.Add(dbPath);
                        using (var fileStream = new FileStream(filePath, FileMode.Create))
                        {
                            file.CopyTo(fileStream);
                        }
                    }
                }
                if (!string.IsNullOrEmpty(ProductName) && ProductPrice != 0 && !string.IsNullOrEmpty(Category))
                {
                    var productModel = new ProductModel() { ProductName = ProductName, ProductPrice = ProductPrice };
                    var product = _mapper.Map<ProductModel, Product>(productModel);

                    var characteristics = _mapper.Map<List<CharactristicModel>, List<Characteristic>>(_charactristicModels);

                    var categoryId = Category;
                    var res = await _productService.AddProduct(product, characteristics, categoryId, _images);
                }
                return View("AddProduct", await _categoriesService.GetAllCategories());
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpPost]
        public async Task<bool> RemoveProduct(string id)
        {
            var res = await _productService.RemoveProduct(id);

            return res;
        }

        [HttpPost]
        public async Task AddCharacteristics(string characteristicName, string characteristicValue)
        {
             await Task.Run(() =>_charactristicModels.Add(new CharactristicModel() { CharacteristicName = characteristicName, CharacteristicValue = characteristicValue }));
        }

        [HttpGet]
        public async Task<ActionResult> AddProduct()
        {
            var categories = await _categoriesService.GetAllCategories();
            return await Task.Run(() => View(categories));
        }
        public async Task<ActionResult> GetAllProducts(string CategoryId)
        {
            var category = new CategoryModel() { Id = CategoryId };
            var productList = await _productService.GetProductsWithFilters(category);

            return View(productList);
        }

        [HttpPost]
        public async Task AddCategory(CategoryModel categoryModel)
        {
            var category = _mapper.Map<Category>(categoryModel);
            await _categoriesService.AddCategory(category);
        }

        [HttpGet]
        public async Task<ActionResult> GetOneProduct(string id)
        {
            var product = await _productService.GetOneProduct(id);

            return View(product);
        }

        [HttpGet]
        public async Task<ActionResult> GetAllCategories()
        {
            var result = await _categoriesService.GetAllCategories();
            return View(result);
        }
    }
}
