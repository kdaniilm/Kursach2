using BLL.Interfaces;
using BLL.Servises;
using Kursach2.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Kursach2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICategoriesService _categoriesService;

        public HomeController(ILogger<HomeController> logger, ICategoriesService categoriesService)
        {
            _logger = logger;
            _categoriesService = categoriesService;
        }
        public async Task<IActionResult> Index()
        {
            var categories = await _categoriesService.GetAllCategories();
            return View(categories);
        }

       

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
