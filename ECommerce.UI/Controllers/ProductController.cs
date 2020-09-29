using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using ECommerce.UI.Models.Requests;
using ECommerce.UI.Models.ViewModels;
using ECommerce.UI.Services;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.UI.Controllers
{
    public class ProductController : Controller
    {
        private readonly IMapper _mapper;
        private readonly ProductService _service;
        private readonly CategoryService _categoryService;

        public ProductController(IMapper mapper, ProductService service, CategoryService categoryService)
        {
            _mapper = mapper;
            _service = service;
            _categoryService = categoryService;
        }

        public async Task<IActionResult> Index()
        {
            var products = await _service.GetProducts();
            var categories = await _categoryService.GetCategories();

            var model = new ProductIndexModel()
            {
                Products = _mapper.Map<List<ProductViewModel>>(products),
                Categories = _mapper.Map<List<CategoryViewModel>>(categories)

            };
            return View(model);
        }


        public async Task<IActionResult> Delete(int productId)
        {
            var statusCode = await _service.Delete(productId);

            switch (statusCode)
            {
                case HttpStatusCode.OK:
                    TempData["Message"] = "Deletion successed!";
                    TempData["DeleteStatus"] = "Success";
                    break;

                case HttpStatusCode.UnprocessableEntity:
                    TempData["Message"] = "Product not found!";
                    TempData["DeleteStatus"] = "Not Found";
                    break;

                case HttpStatusCode.NotFound:
                    TempData["Message"] = "Deletion failed!";
                    TempData["DeleteStatus"] = "Failed";
                    break;
            }

            return RedirectToAction("Index", "Product");
        }

        public async Task<IActionResult> Update(int productId)
        {
            var product = await _service.Get(productId);

            var model = _mapper.Map<ProductViewModel>(product);

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Update(ProductViewModel model)
        {
            var productUpdateRequest = _mapper.Map<ProductUpdateRequest>(model);

            await _service.Update(productUpdateRequest);

            return RedirectToAction("Update", "Product" ,new { productId = model.Id});
        }

        public IActionResult Create()
        {   
           
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductAddViewModel model)
        {
            
            var productCreateRequest = _mapper.Map<ProductCreateRequest>(model);

             await _service.Create(productCreateRequest);


            return RedirectToAction("Index", "Product");
        }
    }
}
